using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherTasks
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
        static void Main(string[] args)
        {
            Console.WriteLine("File Watcher Tasks!");

            _lock = new object();
            tokenSource = new CancellationTokenSource();
            watcherToken = tokenSource.Token;
            _content = new Dictionary<string, string>();

            Task watcherTask = Task.Factory.StartNew(() =>
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
            }, watcherToken);

            consumers = new List<Task>(MAX_CONSUMERS);

            watcherTask.Wait();

            foreach (KeyValuePair<string, string> data in _content)
            {
                Console.WriteLine(data.Key + " : " + data.Value.Substring(0, data.Value.Length > MAX_FILE_CONTENT_LENGTH ? MAX_FILE_CONTENT_LENGTH : data.Value.Length));
            }

            Console.WriteLine("Done!");
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);

            if (consumers.Count >= MAX_CONSUMERS)
            {
                int index = Task.WaitAny(consumers.ToArray());
                consumers.RemoveAt(index);
            }

            var task = Task.Factory.StartNew(() =>
            {
                Process(e);

            }, watcherToken);

            consumers.Add(task);
            Console.WriteLine("consumers:" + consumers.Count);
        }

        private static void Process(FileSystemEventArgs msg)
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
        }
    }
}
