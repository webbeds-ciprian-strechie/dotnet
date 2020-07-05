using System;
using System.Linq;
namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] vowels = {'a','e','i', 'o', 'u'};
            Console.WriteLine("Input a symbol: ");
            char key = Console.ReadKey().KeyChar;
            Console.WriteLine("");

            if (Char.IsDigit(key))
            {
                Console.WriteLine("It's a digit");
            }
            else if (Char.IsLetter(key))
            {
                string isLowerStr = Char.IsLower(key) ? " a lowercase " : " a uppercase ";
                string isVowelStr = " letter ";
                if (vowels.Contains(Char.ToLower(key)))
                {
                    isVowelStr = " vowel ";
                }
                Console.WriteLine("It's " + isLowerStr + " " + isVowelStr);
            } 
            else
            {
                Console.WriteLine("It's other symbol");
            }
        }
    }
}
