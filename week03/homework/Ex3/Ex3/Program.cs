using System;
using System.Collections.Generic;
using IEnumerableExt;
namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sum: {0}", ints.Sum());
            Console.WriteLine("Prod:{0}", ints.Prod());
            Console.WriteLine("Min: {0}", ints.Min());
            Console.WriteLine("Max: {0}", ints.Max());
            Console.WriteLine("Avg: {0}", ints.Avg());
        }
    }
}
