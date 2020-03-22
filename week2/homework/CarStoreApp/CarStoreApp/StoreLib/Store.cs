using System;
using System.Collections.Generic;
using System.Text;
using CarStoreApp.LoggerLib;
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

        private ILogger logger;

        public string Name { get; set; }
        public string City { get; set; }

        public Store(IProducer producer, ILogger logger)
        {
            this.producer = producer;
            this.logger = logger;
            orders = new List<IOrder>();
        }

        public IVehicle? getCarByDetails(string name, string model, int year)
        {
            IVehicle car =  this.producer.getCarByDetails(name, model, year);
            if (car == null)
            {
                logger.Log($"{this.Name} - No results were founf for Car details: {name} {model} {year}");
            }
            return car;
        }

        public string getDeliveryTime()
        {
            return this.producer.getDeliveryTime(this.City);
        }
        public void addNewOrder(IPerson p, IVehicle v, decimal price, string deliverTime)
        {
            if (!orders.Exists((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED))
            {
                logger.Log($"{this.Name} - Created a  new CONFIRMED order for {p.Name} with price = {price} EUR and deliver time = {deliverTime} -- Car details: {v.Name} {v.Model} {v.Year}");

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
                logger.Log($"{this.Name} - An order with same details already exits!");
            }
        }

        public void cancelOrder(IPerson p, IVehicle v)
        {
            IOrder order = orders.Find((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED);
            if (order != null)
            {
                order.Status = ORDER_STATUS.CANCELLED;
                logger.Log($"{this.Name} - Canceled order for {p.Name} - Car details: {v.Name} {v.Model} {v.Year}");
            }
            else
            {
                logger.Log($"{this.Name} - No order was found with specified details");
            }

        }

        private void finishOrder(IPerson p, IVehicle v)
        {
            IOrder order = orders.Find((elem) => elem.Person.Name == p.Name && elem.Car.VIN == v.VIN && elem.Status == ORDER_STATUS.CONFIRMED);
            if (order != null)
            {
                order.Status = ORDER_STATUS.DONE;
                logger.Log($"{this.Name} - Order is DONE for {p.Name} - Car details: {v.Name} {v.Model} {v.Year}");
            }
            else
            {
                logger.Log($"{this.Name} - No order was found with specified details");
            }
        }

        public void receiveCar(IPerson p, IVehicle v)
        {
            this.producer.deliver(v);
            logger.Log($"{this.Name} - Car received!");
            this.finishOrder(p, v);
        }
    }
}
