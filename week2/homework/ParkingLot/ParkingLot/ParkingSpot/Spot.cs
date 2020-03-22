using ParkingLot.ParkingVehicle;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.ParkingSpot
{
    abstract class Spot
    {
        private String number;
        private bool isFree = true;
        private Vehicle vehicle;
        private ParkingSpotType type;

        public bool IsFree { get => isFree; set => this.isFree = value; }
        public ParkingSpotType Type { get => type; set => type = value; }
        public string Number { get => number; set => number = value; }

        public Spot(ParkingSpotType type)
        {
            this.type = type;
        }

        public void assignVehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            this.IsFree = false;
        }

        public void removeVehicle()
        {
            this.vehicle = null;
            this.IsFree = true;
        }
    }
}
