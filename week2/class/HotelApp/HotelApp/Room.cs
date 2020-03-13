using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    class Room
    {
        private string name;
        private Rate rate;
        private byte adults;
        private byte children;

        public string Name { get => name; set => name = value; }
        public byte Adults { get => adults; set => adults = value; }
        public byte Children { get => children; set => children = value; }
        public Rate Rate { get => rate; set => rate = value; }

        public decimal GetPriceForDays(int numberOfDays)
        {
            return rate.Amount * numberOfDays;
        }

        public decimal GetRateAmount()
        {
            return this.Rate.Amount;
        }

        public void Print()
        {
            Console.WriteLine("Room Name: {0}", this.Name);
            Console.WriteLine("\tAdults: {0}", this.Adults);
            Console.WriteLine("\tChildren: {0}", this.Children);
            this.Rate.Print();
        }
    }
}
