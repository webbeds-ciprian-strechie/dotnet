using CarStoreApp.PersonLib;
using CarStoreApp.VehicleLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.StoreLib.OrderLib
{
    class Order : IOrder
    {
        private string producerName;
        private decimal producerPrice;
        private string deliverTime;
        private IVehicle car;
        private IPerson person;
        private decimal agreedPrice;
        private ORDER_STATUS status;

        public string ProducerName { get => this.producerName; set => this.producerName = value; }
        public decimal ProducerPrice { get => this.producerPrice; set => this.producerPrice = value; }

        public decimal AgreedPrice { get => this.agreedPrice; set => this.agreedPrice = value; }
        public string DeliverTime { get => this.deliverTime; set => this.deliverTime = value; }
        public IVehicle Car { get => this.car; set => this.car = value; }
        public IPerson Person { get => this.person; set => this.person = value; }
        public ORDER_STATUS Status { get => this.status; set => this.status = value; }
    }
}
