using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherThreads
{
    class Program
    {
        private static Dictionary<string, string> _content;
        private static SemaphoreSlim _semaphore;

        private const int MAX_CONSUMERS = 4;
        private const int MAX_FILES = 10;
        private const int MAX_FILE_CONTENT_LENGTH = 50;

        private static ManualResetEvent WatcherResetEvent;

        static void Main(string[] args)
        {
            Console.WriteLine("File Watcher Threads!");

            _content = new Dictionary<string, string>();
            _semaphore = new SemaphoreSlim(MAX_CONSUMERS);

            WatcherResetEvent = new ManualResetEvent(false);

            Thread watcherThread = new Thread(FileWatcherThread);
            watcherThread.Start();

            // /wait for watcherThread to finish their execution 
            watcherThread.Join();

            foreach (KeyValuePair<string, string> data in _content)
            {
                Console.WriteLine(data.Key + " : " + data.Value.Substring(0, data.Value.Length > MAX_FILE_CONTENT_LENGTH ? MAX_FILE_CONTENT_LENGTH : data.Value.Length));
            }

            Console.WriteLine("Done!");
        }

        private static void FileWatcherThread()
        {
            Console.WriteLine("Watcher Started.");
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"..\..\..\..\folder\";
            watcher.Created += FileSystemWatcher_Created;
            watcher.Filter = "*.txt";
            watcher.EnableRaisingEvents = true;

            // Wait for notification to cancel the Watcher
            WatcherResetEvent.WaitOne();

            Console.WriteLine("Watcher Canceled.");
            watcher.Dispose();
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);

            new Thread(Process).Start(e);
        }

        private static void Process(object msg)
        {
            _semaphore.Wait();

            if (_content.Count >= MAX_FILES - 1)
            {
                // Cancel the Watcher
                WatcherResetEvent.Set();
            }
            else
            {
                FileSystemEventArgs fileInfo  = (FileSystemEventArgs)msg;
                string text = File.ReadAllText(fileInfo.FullPath);
                _content.Add(fileInfo.Name, text);
            }

            _semaphore.Release();
        }
    }
}
