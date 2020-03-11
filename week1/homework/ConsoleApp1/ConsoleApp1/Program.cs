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
            //Ex3();
            //Ex4();
            //Ex5();
            //Ex6();
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

        public static void Ex4()
        {
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Ex4Rec(sentence);
        }

        public static void Ex4Rec(LinkedList<string> sentence)
        {
            Console.WriteLine(sentence.Last.Value);
            sentence.RemoveLast();
            if (sentence.Count > 0)
            {
                Ex4Rec(sentence);
            }
        }

        public static void Ex5()
        {
            Console.WriteLine("Input a string:");
            char[] input = Console.ReadLine().ToCharArray();
            if (input.Length == 0)
            {
                Console.WriteLine("Invalid data!");
                return;
            }
            LinkedList<char> word = new LinkedList<char>(input);
            LinkedListNode<char> next;
            LinkedListNode<char> current = word.First;
            LinkedListNode<char> node;

            while (current != null)
            {
                node = current.Next;
                while (node != null)
                {
                    if (node.Value == current.Value)
                    {
                        next = node.Next;
                        word.Remove(node);
                        node = next;
                    }
                    else
                    {
                        node = node.Next;
                    }
                }

                current = current.Next;
            }

            Console.WriteLine("String without duplicates:");
            foreach (char chr in word)
            {
                Console.Write((char)chr + " ");
            }
        }

        public static void Ex6()
        {
            Console.WriteLine("Input a string:");
            string input = Console.ReadLine();
            int lastSpace = input.LastIndexOf(' ');
            if (lastSpace == -1)
            {
                Console.WriteLine("No space found");
            }
            int cnt = input.Substring(lastSpace + 1).Length;
            Console.Write(cnt);
        }

        /*
         * Arrays
         */
        public static void Ex72()
        {
            string[] input = new string[0];

            string[] names = new string[1];
            names[0] = "Han Solo";
            Console.WriteLine(names[0]);

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        /*
         * Lists
         */
        public static void Ex73()
        {
            List<string> characters = new List<string>();
            characters.Add("Chewbacca");
            Console.WriteLine(characters[0]);

            characters = new List<string>()
            {
                "Luke Skywalker",
                "Han Solo",
                "Chewbacca"
            };
            characters.Remove("Luke Skywalker");

            characters = new List<string>()
            {
                "Luke Skywalker",
                "Han Solo",
                "Chewbacca"
            };

            characters.RemoveAt(2);

            foreach (string str in characters)
            {
                Console.WriteLine(str);
            }
        }

        /*
         * Dictionaries
         */
        public static void Ex74()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            Dictionary<string, int> people = new Dictionary<string, int>();

            people.Add("Ciprian", 34);
            people["Mihai"] = 28;
            Console.WriteLine(people["Ciprian"]);

            Dictionary<string, bool> characters = new Dictionary<string, bool>()
            {
                { "Luke", true },
                { "Han", false },
                { "Chewbacca", false }
            };

            characters.Remove("Han");

            characters = new Dictionary<string, bool>()
            {
                { "Luke", true },
                { "Han", false },
                { "Chewbacca", false }
            };

            foreach (var chr in characters)
            {
                Console.WriteLine(chr.Value);
            }
        }

        /*
         * Collections
         */
        public static void Ex75()
        {
            Queue<int> primes = new Queue<int>();
            primes.Enqueue(1);
            primes.Enqueue(3);
            primes.Enqueue(5);
            primes.Enqueue(7);
            primes.Enqueue(9);

            int total = 0;

            foreach (int p in primes)
            {
                total += p;
            }

            Console.WriteLine(total);
        }

        /*
         * Stacks
         */
        public static void Ex76()
        {
            Stack<string> films = new Stack<string>();
            films.Push("Film 1");
            films.Push("Film 2");
            films.Push("Film 3");

            do
            {
                Console.WriteLine(films.Pop());
            }
            while (films.Count > 0);
        }

        /*
         * 
         */
        public static void Ex77()
        {
            LinkedList<string> movies = new LinkedList<string>();
            movies.AddFirst("Avatar");
            LinkedListNode<string> titanic = new LinkedListNode<string>("Titanic");
            movies.AddLast(titanic);
            movies.AddAfter(titanic, new LinkedListNode<string>("Star Wars: The Force Awakens"));

            LinkedList<string> droids = new LinkedList<string>();

            droids.AddLast("C-3PO");
            droids.AddLast("AZI-3");
            droids.AddLast("R2-D2");
            droids.AddLast("IG-88");
            droids.AddLast("2-1B");

            droids.Remove("C-3PO");
            droids.Remove("R2-D2");
            droids.RemoveLast();
        }


    }
}
