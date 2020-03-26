using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            SystemClock sc = new SystemClock();
            Console.WriteLine("Now:"  + sc.Now.ToString());
            Console.WriteLine("UtcNow:" + sc.UtcNow.ToString());
            Console.WriteLine("Today:" + sc.Today.ToString());
            Console.WriteLine("Today:" + sc.Today.ToString("ddd dd MMM yyyy"));
        }
    }
}
