using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Get interval in seconds:");
            int sec = int.Parse(Console.ReadLine());
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            MyTimer.InitTimer(sec);

            Console.WriteLine("Shutingdown the application...");

            //MyTimer.StopTimer();

        }
    }
}
