using ParkingLot.ParkingTicket;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.ParkingVehicle
{
    abstract class Vehicle
    {
        private String licenseNumber;
        private VehicleType type;
        private Ticket parkingTicket;

        public Vehicle(VehicleType type)
        {
            this.type = type;
        }

        public string LicenseNumber { get => licenseNumber; set => licenseNumber = value; }

        public void assignTicket(Ticket ticket)
        {
            this.parkingTicket = ticket;

            ticket.print();
        }

        public Ticket getTicket()
        {
            this.parkingTicket.print();

            return this.parkingTicket;
        }
    }
}
