using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex1();
           //Ex2();
           Ex3();
        }

        public static void Ex1()
        {
            Console.WriteLine("Input a string:");
            string input = Console.ReadLine();
            HashSet<char> uniqueLetters = new HashSet<char>(input.ToCharArray());

            Console.WriteLine("String without duplicates:");
            foreach (int i in uniqueLetters)
            {
                Console.Write((char)i);
            }

        }

        public static void Ex2()
        {
            int[] numbers = { 5, 8, 5, 7, 5, 8, 5, 5, 5, 9 };
            float procOcc;
            int currentOcc;
            bool haveMajority = false;
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (occurences.TryGetValue(number, out currentOcc))
                {
                    currentOcc++;
                    occurences[number] = currentOcc;
                }
                else
                {
                    occurences.Add(number, 1);
                }

            }

            foreach (KeyValuePair<int, int> item in occurences)
            {
                procOcc = (float)item.Value / numbers.Length * 100;
                if (procOcc > 50)
                {
                    Console.WriteLine("Number with majority is {0} with {1} occurences.", item.Key, item.Value);
                    haveMajority = true;
                    break;
                }
            }

            if (!haveMajority)
            {
                Console.WriteLine("No number has majority.");
            }
        }

        public static void Ex3()
        {
            int currentOcc;
            Console.WriteLine("Input a string:");
            string input = Console.ReadLine();
            Dictionary<char, int> occurences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (occurences.TryGetValue(input[i], out currentOcc))
                {
                    currentOcc++;
                    occurences[input[i]] = currentOcc;
                }
                else
                {
                    occurences.Add(input[i], 1);
                }

            }

            Console.WriteLine("Occurences:");
            foreach (KeyValuePair<char, int> item in occurences)
            {
                Console.WriteLine("{0} => {1} occurences.", item.Key, item.Value);
            }
        }
    }

}
