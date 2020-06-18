using System;
using System.IO;

namespace ExStrategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FileInfo fi = new FileInfo(@"C:\mydir\myfile.ext");

            ReadFile strategy;
            if (fi.Length < 1073741824)
            {
                strategy = new ReadInMemory();
            }
            else
            {
                strategy = new ReadInFile();
            }

            EncryptManager encryptManager = new EncryptManager(strategy);
            encryptManager.Process();
        }
    }
}
