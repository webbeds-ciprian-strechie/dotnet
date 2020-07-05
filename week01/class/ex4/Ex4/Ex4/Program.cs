using System;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input height: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int height);

            if (isInt)
            {
                if(height<150)
                {
                   //case height: ;
                }
            }
        }
    }
}
