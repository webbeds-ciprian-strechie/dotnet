using CarStoreApp.VehicleLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.ProducerLib
{
    interface IProducer
    {
        public string Name { get; set; }

        public IVehicle? getCarByDetails(string name, string model, int year);
        public string getDeliveryTime(string city);
        public void deliver(IVehicle v);
    }
}
