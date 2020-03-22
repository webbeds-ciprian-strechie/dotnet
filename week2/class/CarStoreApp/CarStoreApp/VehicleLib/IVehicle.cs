using System;
using System.Collections.Generic;
using System.Text;


namespace CarStoreApp.VehicleLib
{
    interface IVehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string VIN { get; set; }
    }
}
