using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherAwait
{
    class Program
    {
        private static Dictionary<string, string> _content;
        private static List<Task> consumers;

        private const int MAX_CONSUMERS = 4;
        private const int MAX_FILES = 10;
        private const int MAX_FILE_CONTENT_LENGTH = 50;

        private static object _lock;
        private static CancellationTokenSource tokenSource;
        private static CancellationToken watcherToken;
        static async Task Main(string[] args)
        {
            Console.WriteLine("File Watcher Await!");

            _lock = new object();
            tokenSource = new CancellationTokenSource();
            watcherToken = tokenSource.Token;
            _content = new Dictionary<string, string>();
            consumers = new List<Task>(MAX_CONSUMERS);

            await FileSystemWatcher();

            foreach (KeyValuePair<string, string> data in _content)
            {
                Console.WriteLine(data.Key + " : " + data.Value.Substring(0, data.Value.Length > MAX_FILE_CONTENT_LENGTH ? MAX_FILE_CONTENT_LENGTH : data.Value.Length));
            }

            Console.WriteLine("Done!");
        }


        private static async Task FileSystemWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"..\..\..\..\folder\";
            watcher.Created += FileSystemWatcher_Created;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;
            while (true)
            {
                if (watcherToken.IsCancellationRequested)
                {
                    Console.WriteLine("Watcher Canceled.");
                    watcher.Dispose();
                    break;
                }
            }
        }


        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);

            CreateTask(e);

            Console.WriteLine("consumers:" + consumers.Count);
        }


        private static async Task CreateTask(FileSystemEventArgs e)
        {
            if (consumers.Count >= MAX_CONSUMERS)
            {
                Task t = await Task.WhenAny(consumers.ToArray());
                consumers.Remove(t);
            }
            await Process(e);
        }


        private static async Task Process(FileSystemEventArgs msg)
        {
            consumers.Add(Task.Run(() =>
            {
                lock (_lock)
                {
                    if (_content.Count == MAX_FILES)
                    {
                        tokenSource.Cancel();
                        return;
                    }
                    string text = File.ReadAllText(msg.FullPath);
                    _content.Add(msg.Name, text);
                }
            }));

        }
    }
}
