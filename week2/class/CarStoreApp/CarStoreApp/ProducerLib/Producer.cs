using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarStoreApp.VehicleLib;

namespace CarStoreApp.ProducerLib
{
    abstract class Producer : IProducer
    {
        protected Dictionary<string, IVehicle> autoPark;

        protected Dictionary<string, string> deliveryTime;
        protected string name;

        public string Name { get => this.name; set => this.name = value; }

        public string getDeliveryTime(string city)
        {
            if (deliveryTime.TryGetValue(city, out string time))
            {
                return time;
            }
            else
            {
                return "Not available for delivery in {0} " + city;
            }
        }
        public IVehicle? getCarByDetails(string name, string model, int year)
        {
            Dictionary<string, IVehicle> cars = autoPark.Where((elem) => elem.Value.Name == name && elem.Value.Model == model && elem.Value.Year == year).ToDictionary(elem=> elem.Key, elem => elem.Value);
            if (cars.Count> 0 )
            {
                return cars.First().Value;
            }

            return null;
        }

        public void deliver(IVehicle v)
        {
            autoPark.Remove(v.VIN);
        }
    }
}
