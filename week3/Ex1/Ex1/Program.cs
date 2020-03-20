using System;
using System.Collections.Generic;


namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
/*            Console.WriteLine("Hello World!");
                       List<int> l = new List<int>();*/


            MyList<int> ml = new MyList<int>(5);
            ml.Add(10);
            ml.Add(20);
            ml.Add(30);

            int found1 = ml.Find(20);
            Console.WriteLine("Elem found is {0}", found1);

            MyList<string> ml2 = new MyList<string>(7);
            ml2.Add("sss");
            ml2.Add("ff");
            ml2.Add("gggg");

            string found2 = ml2.Find("gggg");
            Console.WriteLine("Elem is ", found2);
        }
    }
}
