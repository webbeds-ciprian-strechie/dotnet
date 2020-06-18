using System;

namespace ExDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoffee expreso = new ExpressoCoffe("1$");
            ICoffee filtered = new FilteredCoffe("2$");

            Console.WriteLine(expreso.GetDescription() + " = " + expreso.GetPrice());
            Console.WriteLine(filtered.GetDescription() + " = " + filtered.GetPrice());

            ICoffee expresoMilk = new MilkCofee(expreso);
            Console.WriteLine(expresoMilk.GetDescription() + " = " + expresoMilk.GetPrice());

            ICoffee filteredMilk = new MilkCofee(filtered);
            Console.WriteLine(filteredMilk.GetDescription() + " = " + filteredMilk.GetPrice());

            ICoffee filteredMilkChocolate = new ChocolateCofee(filteredMilk);
            Console.WriteLine(filteredMilkChocolate.GetDescription() + " = " + filteredMilkChocolate.GetPrice());
        }
    }
}
