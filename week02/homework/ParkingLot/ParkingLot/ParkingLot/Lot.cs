using ParkingLot.ParkingSpot;
using ParkingLot.ParkingTicket;
using ParkingLot.ParkingVehicle;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.ParkingLot
{
    class Lot
    {
        private string name;
        private Dictionary<string, Spot> carSpots;
        private Dictionary<string, Spot> motorbikeSpots;
        private Dictionary<string, Spot> vanSpots;

        private readonly decimal RATE_PER_HOUR = 10.99M;

        private readonly byte DEFAULT_HOURS_TAX = 1;

        public string Name { get => name; set => name = value; }

        public Lot()
        {
            this.carSpots = new Dictionary<string, Spot>();
            this.motorbikeSpots = new Dictionary<string, Spot>();
            this.vanSpots = new Dictionary<string, Spot>();
        }
        public void addParkingSpot(Spot spot)
        {
            switch (spot.Type)
            {
                case ParkingSpotType.CAR:
                    carSpots.Add(spot.Number, spot);
                    break;
                case ParkingSpotType.VAN:
                    vanSpots.Add(spot.Number, spot);
                    break;
                case ParkingSpotType.MOTORBIKE:
                    motorbikeSpots.Add(spot.Number, spot);
                    break;
                default:
                    Console.WriteLine("Wrong parking spot type!");
                    break;
            }
        }

        public void assignVehicleToSpot(Vehicle vehicle, Spot spot)
        {
            spot.assignVehicle(vehicle);

            Ticket ticket = new Ticket()
            {
                Number = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString(),
                IssuedAt = DateTime.Now,
                RatePerHour = RATE_PER_HOUR,
                Status = TicketStatus.ACTIVE,
                ParkingSpot = spot
            };

            vehicle.assignTicket(ticket);
        }

        public Spot? GetNextFreeSpot(ParkingSpotType spotType)
        {
            Dictionary<string, Spot>? spot = new Dictionary<string, Spot>();
            switch (spotType)
            {
                case ParkingSpotType.CAR:
                    spot = carSpots;
                    break;
                case ParkingSpotType.VAN:
                    spot = vanSpots;
                    break;
                case ParkingSpotType.MOTORBIKE:
                    spot = motorbikeSpots;
                    break;
                default:
                    Console.WriteLine("Wrong parking spot type!");
                    break;
            }

            if (spot == null)
            {
                return null;
            }

            foreach (KeyValuePair<string, Spot> elem in spot)
            {
                if (elem.Value.IsFree)
                {
                    return elem.Value;
                }
            }

            Console.WriteLine("All spots {0} are full!", spotType);

            return null;
        }

        public void freeSpot(Ticket ticket)
        {
            ticket.PayedAmount = ticket.RatePerHour * (decimal)(DateTime.Now.AddHours(DEFAULT_HOURS_TAX) - ticket.IssuedAt).TotalHours;
            ticket.PayedAt = DateTime.Now;
            ticket.Status = TicketStatus.PAID;
            ticket.ParkingSpot.removeVehicle();
            ticket.print();
        }

        public void displayParkingBoard()
        {
            Console.WriteLine("\nCar spots free/total: {0}/{1} ", getTotalFree(carSpots), carSpots.Count);
            Console.WriteLine("Motorbike spots free/total: {0}/{1} ", getTotalFree(motorbikeSpots), motorbikeSpots.Count);
            Console.WriteLine("VAN spots free/total: {0}/{1} ", getTotalFree(vanSpots), vanSpots.Count);
        }

        private int getTotalFree(Dictionary<string, Spot> spot)
        {
            int totalFree = 0;
            foreach (KeyValuePair<string, Spot> elem in spot)
            {
                if (elem.Value.IsFree)
                {
                    totalFree++;
                }
            }
            return totalFree;
        }
    }
}
