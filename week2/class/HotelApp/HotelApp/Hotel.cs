using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    class Hotel
    {
        private string name;
        private string city;
        private List<Room> rooms;

        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public decimal GetPriceForNumberOfRooms(int numberOfRooms)
        {
            decimal price = 0;
            if (numberOfRooms > Rooms.Count)
            {
                throw new Exception("Not enough rooms!");
            }
            for(int i =0; i< numberOfRooms; i++)
            {
                price += Rooms[i].Rate.Amount;
            }

            return price;
        }
        public void Print()
        {
            Console.WriteLine("Hotel Name: {0}", this.Name);
            Console.WriteLine("City: {0}", this.City);
            Console.WriteLine("<<<Rooms>>");
            foreach(Room r in Rooms)
            {
                r.Print();
            }
            
        }
    }
}
