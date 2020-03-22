using System;
using System.Collections.Generic;
using System.Text;
using CarStoreApp.VehicleLib;

namespace CarStoreApp.ProducerLib
{
    class SkodaProducer : Producer
    {
        public SkodaProducer()
        {
            autoPark = new Dictionary<string, IVehicle>();

            IVehicle v1 = new Vehicle()
            {
                Name = "Skoda",
                Model = "Octavia",
                Year = 2018,
                Price = 14000,
                VIN = "3D7UT2CL0BG625027"
            };
            autoPark.Add(v1.VIN, v1);

            IVehicle v2 = new Vehicle()
            {
                Name = "Skoda",
                Model = "Superb",
                Year = 2019,
                Price = 1500,
                VIN = "JH4CC2660PC002236"
            };
            autoPark.Add(v2.VIN, v2);

            deliveryTime = new Dictionary<string, string>()
                                            {
                                                {"Iasi","5 weeks"},
                                                {"Bucuresti", "3 weeks"},
                                            };
        }
    }
}
