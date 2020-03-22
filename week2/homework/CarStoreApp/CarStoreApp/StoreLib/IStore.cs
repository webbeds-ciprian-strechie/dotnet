using System;
using System.Collections.Generic;
using System.Text;
using CarStoreApp.VehicleLib;
using CarStoreApp.PersonLib;

namespace CarStoreApp.StoreLib
{
    interface IStore
    {
        public string Name { get; set; }

        public string City { get; set; }

        public IVehicle? getCarByDetails(string name, string model, int year);
        public void addNewOrder(IPerson p, IVehicle v, decimal price, string deliverTime);

        public void cancelOrder(IPerson p, IVehicle v);

        public void receiveCar(IPerson p, IVehicle v);
    }
}
