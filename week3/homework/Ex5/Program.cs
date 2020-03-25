using System;
using System.Collections.Generic;

namespace Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1 };
            for (var i = 0; i < 10; i++)
            {
                numbers.Add(ReadNumber(numbers[numbers.Count - 1], 100));
            }

            numbers.Add(100);

            Console.WriteLine(String.Join<int>('<', numbers));
        }

        public static int ReadNumber(int start, int end)
        {
            int n;
            Console.WriteLine("Get a number:");
            try
            {
                n = int.Parse(Console.ReadLine());
                if (n <= start || n >= end)
                {
                    throw new Exception($"The number need to be greater than {start} and lower than {end}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Invalid number or non-number text is entered", ex);
            }

            return n;
        }
    }
}
