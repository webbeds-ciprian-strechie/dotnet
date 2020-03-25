using System;

namespace Ex6
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 simpleBitArray = new BitArray64(11); //1011

            Console.WriteLine(simpleBitArray[2] == simpleBitArray[3]); //false
            Console.WriteLine("BitArray:");
            foreach (var value in simpleBitArray)
            {
                Console.Write(value);
            }

            simpleBitArray[2] = 1;

            Console.WriteLine("");
           Console.WriteLine(simpleBitArray[2] == simpleBitArray[3]); //true
            Console.WriteLine("BitArray:");
            foreach (var value in simpleBitArray)
            {
                Console.Write(value);
            }

            //simpleBitArray[65] = 0; //exception
        }
    }
}
