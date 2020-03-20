using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;



namespace Ex2
{
    
    class MyTimer
    {
        private static bool status = true;

        public static void InitTimer(int seconds)
        {          
            long startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long current;

            Console.WriteLine("Press any key to prevent exit...");
            var tHold = Task.Run(() => Console.ReadKey(true));

            while (!tHold.IsCompleted)
            {
                current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                if (current - startTime >= seconds)
                {
                    Console.WriteLine("Elipsed {0} sec", seconds);
                    startTime = current;
                }
            }
        }
    }
}
