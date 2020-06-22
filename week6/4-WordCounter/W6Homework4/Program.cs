using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace W6Homework4
{
    class Program
    {
        static string[] fileEntries;
        static int totalWordsCount;
        static ConcurrentDictionary<string, string> dictionary;
        static List<string> wordInFiles;
        static ConcurrentDictionary<string, string> wordCategories;

        const string WORD_TO_FIND = "nlefa";
        static async Task Main(string[] args)
        {
            Console.WriteLine("W6Homework4!");

            List<Task> tasks = new List<Task>();

            fileEntries = Directory.GetFiles(@"..\..\..\..\data\");

            tasks.Add(Task.Factory.StartNew(() => CountOfAllWords()));
            tasks.Add(Task.Factory.StartNew(() => CountOfDistinctWords()));
            tasks.Add(Task.Factory.StartNew(() => SearchForSpecificWord()));
            tasks.Add(Task.Factory.StartNew(() => GroupWordsPerCategories()));

            Task.WaitAll(tasks.ToArray());


            Console.WriteLine("Done!");
        }

        private static void CountOfAllWords()
        {
            List<Task> tasks = new List<Task>();
            foreach (string file in fileEntries)
            {
                var task = Task.Run(() =>
                {
                    Console.WriteLine("CountOfAllWords - file:" + file);
                    string text = File.ReadAllText(file);
                    string[] words = text.Split(Environment.NewLine);
                    Interlocked.Add(ref totalWordsCount, words.Length);
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("CountOfAllWords:" + totalWordsCount);
        }

        private static void CountOfDistinctWords()
        {
            List<Task> tasks = new List<Task>();
            dictionary = new ConcurrentDictionary<string, string>();
            foreach (string file in fileEntries)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("CountOfDistinctWords - file:" + file);
                    string text = File.ReadAllText(file);
                    string[] words = text.Split(Environment.NewLine);
                    foreach (string word in words)
                    {
                        dictionary.TryAdd(word, "");
                    }

                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("CountOfDistinctWords:" + dictionary.Count);
            dictionary.Clear();
        }

        private static void SearchForSpecificWord()
        {
            wordInFiles = new List<string>();
            List<Task> tasks = new List<Task>();
            foreach (string file in fileEntries)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("SearchForSpecificWord - file:" + file);
                    string text = File.ReadAllText(file);
                    if (text.IndexOf(WORD_TO_FIND) != -1)
                    {
                        wordInFiles.Add(file);
                    }
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("SearchForSpecificWord found in file(s):" + String.Join(',', wordInFiles.ToArray()));
        }

        private static void GroupWordsPerCategories()
        {
            List<Task> tasks = new List<Task>();
            wordCategories = new ConcurrentDictionary<string, string>();
            foreach (string file in fileEntries)
            {
                var task = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("CountOfDistinctWords - file:" + file);
                    string text = File.ReadAllText(file);
                    string[] words = text.Split(Environment.NewLine);
                    foreach (string word in words)
                    {
                        string type = "l";
                        if (word.Length <= 5)
                        {
                            type = "xs";
                        }
                        else if (word.Length <= 10)
                        {
                            type = "s";
                        }
                        else if (word.Length <= 15)
                        {
                            type = "m";
                        }

                        wordCategories.TryAdd(word, type);
                    }

                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            string[] types = new string[] { "xs", "s", "m", "l" };
            foreach (string type in types)
            {
                Console.WriteLine("GroupWordsPerCategories <" + type + ">:" + wordCategories.Values.Where(item => item == type).Count());

            }
            wordCategories.Clear();
        }
    }
}
