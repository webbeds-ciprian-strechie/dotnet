using ParkingLot.ParkingSpot;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot.ParkingTicket
{
    class Ticket
    {
        private string number;
        private DateTime issuedAt;
        private DateTime payedAt;
        private decimal ratePerHour;
        private decimal payedAmount;
        private Spot parkingSpot;

        public string Number { get => number; set => number = value; }
        public DateTime IssuedAt { get => issuedAt; set => issuedAt = value; }
        public decimal RatePerHour { get => ratePerHour; set => ratePerHour = value; }
        public DateTime PayedAt { get => payedAt; set => payedAt = value; }
        public decimal PayedAmount { get => payedAmount; set => payedAmount = value; }
        public TicketStatus Status { get; set; }
        public Spot ParkingSpot { get => parkingSpot; set => parkingSpot = value; }

        public void print()
        {
            Console.WriteLine($"Ticket Number: {Number} - Issued At: {IssuedAt.ToString()} - RatePerHour : {RatePerHour} EUR - Payed At: {PayedAt.ToString()} - PayedAmount:{PayedAmount:N3} - Status: {Status.ToString()} - ParkingSpot: {ParkingSpot.Number}");
        }
    }
}
