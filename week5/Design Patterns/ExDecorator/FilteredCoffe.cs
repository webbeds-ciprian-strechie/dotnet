namespace ExDecorator
{
    class FilteredCoffe: ICoffee
    {
        private string price;
        private string description = "Filtered Coffe";

        public FilteredCoffe(string price)
        {
            this.price = price;
        }

        public string GetPrice()
        {
            return this.price;
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}
