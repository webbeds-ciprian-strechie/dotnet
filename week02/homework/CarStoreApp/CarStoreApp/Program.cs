using System;
using CarStoreApp.PersonLib;
using CarStoreApp.StoreLib;
using CarStoreApp.ProducerLib;
using CarStoreApp.VehicleLib;
using CarStoreApp.LoggerLib;

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

            Store storeFord = new Store(new FordProducer(), new FileLogger())
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
            

            Store storeSkoda = new Store(new SkodaProducer(), new FileLogger())
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

            if (carFord != null)
            {
                storeFord.cancelOrder(p, carFord);
            }

            if (carSkoda != null)
            {
                storeSkoda.receiveCar(p, carSkoda);
            }
        }
    }
}
