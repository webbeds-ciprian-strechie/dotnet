using System;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get a number");
            int i = int.Parse(Console.ReadLine());
            if (i < 1 || i > 100)
            {
                throw new RangeException<int>(1, 100);
            }

            Console.WriteLine("Get a date");
            DateTime d = DateTime.Parse(Console.ReadLine());

            DateTime dStart = DateTime.Parse("1.1.1980");
            DateTime dEnd = DateTime.Parse("31.12.2013");
            if (d < dStart || d > dEnd)
            {
                throw new RangeException<DateTime>(dStart, dEnd);
            }
        }
    }
}
