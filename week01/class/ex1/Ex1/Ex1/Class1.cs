using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex1
{
    public class Class1
    {
        public static void Main()
        {
            Stack<char> s = new Stack<char>();
            int numberOfKeys = 3;
            ConsoleKeyInfo chinput;
            for (int i = 0; i < numberOfKeys; i++)
            {
                Console.WriteLine("Enter key:");
                chinput = Console.ReadKey();
                s.Push(chinput.KeyChar);
            }

            Console.WriteLine("Keys in reverse order are:");

            for (int i = 0; i < numberOfKeys; i++)
            {
                Console.WriteLine(s.Pop());
            }
        }
    }
}
