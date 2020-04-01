using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "karunya123.edu  , www.karunya.edu, www.karunya.edu,  http://karunya.edu, https://karunya.edu, www.karunyauniversity.in  ,  https://mykarunya.edu, https://www.karunya.edu  ,  google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";
            List<string> urls;

            Console.WriteLine("\t1.Extract all the URLs");
            urls = p1(text);

            Console.WriteLine("\t2.Display all the URLs which start with https://");
            p2(urls);

            Console.WriteLine("\t3.URLs ending with .edu");
            p3(urls);

            Console.WriteLine("\t4.Replace all the vowels in url with given character");
            string letter = "X";
            p4(urls, letter);

            Console.WriteLine("\t5.Replace all the numbers in the URL with 1 and display");
            letter = "1";
            p5(urls, letter);

            Console.WriteLine("\t6.Display all duplicate URLs");

            Console.WriteLine("\t7.Concatenate any two URLs");
            Console.WriteLine("\t8.Given any URL, display last occurence of any repeating character");
            Console.WriteLine("\t9.Insert [URL] at the beginning of URLs");
            Console.WriteLine("\t10.Find out first occurence of character in given url");
            Console.WriteLine("\t11.List out all the URLs with substring 'oo' in it.");
        }

 

        public static void p5(List<string> urls, string letter)
        {
            string newString;
            foreach (string url in urls)
            {
                Regex regex = new Regex(@"[0-9]");
                newString = regex.Replace(url, letter);
                Console.WriteLine(newString);
            }
        }

        public static void p4(List<string> urls, string letter)
        {
            string newString;
            foreach (string url in urls)
            {
                Regex regex = new Regex("[aeiou]");
                newString = regex.Replace(url, letter);
                Console.WriteLine(newString);
            }
        }

        public static void p3(List<string> urls)
        {
            foreach (string url in urls)
            {
                Regex regex = new Regex(@".edu\z");
                Match match = regex.Match(url);
                if (match.Success)
                {
                    Console.WriteLine(url);
                }
            }
        }

        public static void p2(List<string> urls)
        {
            foreach (string url in urls)
            {
                Regex regex = new Regex("^https://");
                Match match = regex.Match(url);
                if (match.Success)
                {
                    Console.WriteLine(url);
                }
            }
        }

        public static List<string> p1(String text)
        {
            List<string> urls = text.Split(',').Select(s => s.Trim()).ToList();
            foreach (string url in urls)
            {
                Console.WriteLine(url);
            }

            return urls;
        }
    }
}
