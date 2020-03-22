using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.VehicleLib
{
    class Vehicle : IVehicle
    {
        private string name;
        private string model;
        private int year;
        private decimal price;
        private string vin;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string VIN
        {
            get { return this.vin; }
            set { this.vin = value; }
        }
    }
}
