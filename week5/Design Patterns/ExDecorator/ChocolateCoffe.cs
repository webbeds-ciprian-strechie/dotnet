using System;
using System.Collections.Generic;
using System.Text;

namespace ExDecorator
{
    class ChocolateCofee : ICondimentedCofee
    {
        private string price = "4$";

        protected ICoffee cofee;

        public ChocolateCofee(ICoffee cofee)
        {
            this.cofee = cofee;
        }


        public string GetDescription()
        {
            return this.cofee.GetDescription() + " + " + "Chocolate";
        }

        public string GetPrice()
        {
            return this.cofee.GetPrice() + " + " + this.price;
        }

        public string GetIngredientName()
        {
            return "Chocolate";
        }
    }
}
