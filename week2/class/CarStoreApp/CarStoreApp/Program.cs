using System;
using CarStoreApp.PersonLib;
using CarStoreApp.StoreLib;
using CarStoreApp.ProducerLib;
using CarStoreApp.VehicleLib;

namespace CarStoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Name = "Alex"
            };

            Store storeFord = new Store(new FordProducer())
            {
                Name = "FordStore",
                City = "Bucuresti"
            };


            IVehicle carFord = storeFord.getCarByDetails("Ford", "Focus", 2015);
            if (carFord != null)
            {
                string deliverTime = storeFord.getDeliveryTime();
                storeFord.addNewOrder(p, carFord, 1500, deliverTime);
            }
            

            Store storeSkoda = new Store(new SkodaProducer())
            {
                Name = "SkodaStore",
                City = "Bucuresti"
            };

            IVehicle carSkoda = storeSkoda.getCarByDetails("Skoda", "Octavia", 2018);
            if (carSkoda != null)
            {
                string deliverTime = storeSkoda.getDeliveryTime();
                storeSkoda.addNewOrder(p, carSkoda, 1400, deliverTime);
            }

            storeFord.cancelOrder(p, carFord);

            storeSkoda.receiveCar(p, carSkoda);
        }
    }
}
