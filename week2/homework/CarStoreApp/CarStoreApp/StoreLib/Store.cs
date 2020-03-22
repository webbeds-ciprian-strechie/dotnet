using System;
using System.Collections.Generic;
using System.Text;
using CarStoreApp.PersonLib;
using CarStoreApp.ProducerLib;
using CarStoreApp.StoreLib.OrderLib;
using CarStoreApp.VehicleLib;

namespace CarStoreApp.StoreLib
{
    class Store : IStore
    {

        private List<IOrder> orders;

        private IProducer producer;

        public string Name { get; set; }
        public string City { get; set; }

        public Store(IProducer producer)
        {
            this.producer = producer;
            orders = new List<IOrder>();
        }

        public IVehicle? getCarByDetails(string name, string model, int year)
        {
            return this.producer.getCarByDetails(name, model, year);
        }

        public string getDeliveryTime()
        {
            return this.producer.getDeliveryTime(this.City);
        }
        public void addNewOrder(IPerson p, IVehicle v, decimal price, string deliverTime)
        {
            if (!orders.Exists((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED))
            {
                Console.WriteLine("Created a  new order for {0} price= {1} deliver time = {2}", p.Name, price, deliverTime);

                orders.Add(new Order()
                {
                    ProducerName = producer.Name,
                    ProducerPrice = v.Price,
                    AgreedPrice = price,
                    DeliverTime = deliverTime,
                    Car = v,
                    Person = p,
                    Status = ORDER_STATUS.CONFIRMED
                }); 
            }
            else
            {
                Console.WriteLine("An order with same details already exits!");
            }
        }

        public void cancelOrder(IPerson p, IVehicle v)
        {
            IOrder order = orders.Find((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED);
            if (order != null)
            {
                order.Status = ORDER_STATUS.CANCELLED;
                Console.WriteLine("Canceled order for {0} - Car details: {1} {2} {3}", p.Name, v.Name, v.Model, v.Year);
            }
            else
            {
                Console.WriteLine("No order was found with specified details");
            }

        }

        private void finishOrder(IPerson p, IVehicle v)
        {
            IOrder order = orders.Find((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED);
            if (order != null)
            {
                order.Status = ORDER_STATUS.DONE;
                Console.WriteLine(" Order is DONE for {0} - Car details: {1} {2} {3}", p.Name, v.Name, v.Model, v.Year);
            }
            else
            {
                Console.WriteLine("No order was found with specified details");
            }
        }

        public void receiveCar(IPerson p, IVehicle v)
        {
            Console.WriteLine("Car received!");
            this.producer.deliver(v);
            this.finishOrder(p, v);
        }
    }
}
