using CarStoreApp.PersonLib;
using CarStoreApp.ProducerLib;
using CarStoreApp.VehicleLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStoreApp.StoreLib.OrderLib
{
    public enum ORDER_STATUS { CONFIRMED, CANCELLED, DONE };
    interface IOrder
    {
        public string ProducerName { get; set; }
        public decimal ProducerPrice { get; set; }
        public string DeliverTime { get; set; }
        public IVehicle Car { get; set; }
        public IPerson Person { get; set; }
        public ORDER_STATUS Status { get; set; }
    }
}
