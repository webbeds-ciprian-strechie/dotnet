using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            Console.WriteLine("Input first number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Input operation:: ");
            string operation = Console.ReadLine().ToString();

            Console.WriteLine("Input second number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());



            switch (operation)
            {
                case "-":
                     result = firstNumber - secondNumber;
                    break;
                case "+":
                     result = firstNumber + secondNumber;
                    break;
                case "/":
                     result = (double)firstNumber / secondNumber;
                    break;
                case "*":
                     result  = firstNumber * secondNumber;
                    break;
                default: Console.WriteLine("Error on operation!"); break;
            }

            Console.WriteLine("Expected Output :");
            Console.WriteLine(firstNumber + " " + operation + " " + secondNumber + " = " + result);
        }
    }
}
