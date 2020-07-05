using System;
using System.Collections.Generic;
using System.Text;
using CarStoreApp.VehicleLib;

namespace CarStoreApp.ProducerLib
{
    class FordProducer: Producer
    {
        public FordProducer()
        {

            autoPark = new Dictionary<string, IVehicle>();

            IVehicle v1 = new Vehicle()
            {
                Name = "Ford",
                Model = "Focus",
                Year = 2015,
                Price = 15000,
                VIN = "JT4RN01P0N7057480"
            };
            autoPark.Add(v1.VIN, v1);

            IVehicle v2 = new Vehicle()
            {
                Name = "Ford",
                Model = "Focus",
                Year = 2019,
                Price = 20000,
                VIN = "5XYKT3A17BG157871"
            };
            autoPark.Add(v2.VIN, v2);

            deliveryTime = new Dictionary<string, string>()
                                            {
                                                {"Iasi","3 weeks"},
                                                {"Bucuresti", "4 weeks"},
                                            };
        }
    }
}
