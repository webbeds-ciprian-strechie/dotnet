using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    class Rate
    {
        private decimal amount;

        private string currency;

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        public string Currency { get => currency; set => currency = value; }

        public void Print()
        {
            Console.WriteLine("Rate Price {0} {1}", this.Amount, this.Currency );
        }
    }
}
