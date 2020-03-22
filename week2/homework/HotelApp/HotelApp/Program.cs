using System;
using System.Collections.Generic;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hotel> hotels = new List<Hotel>();
            Hotel h = new Hotel();
            h.Name = "HILTON";
            h.City = "LONDON";

            hotels.Add(h);

            h.Rooms = new List<Room>();
            Room room;

            room = new Room();
            room.Name = "DELUXE";
            room.Children = 1;
            room.Adults = 2;
            room.Rate = new Rate();
            room.Rate.Amount = 10;
            room.Rate.Currency = "USD";

            h.Rooms.Add(room);

            room = new Room();
            room.Name = "DOUBLE";
            room.Children = 0;
            room.Adults = 2;
            room.Rate = new Rate();
            room.Rate.Amount = 5;
            room.Rate.Currency = "USD";

            h.Rooms.Add(room);

            h.Print();

            try
            {
                Console.WriteLine("Get number of rooms for reservation:");
                if(int.TryParse(Console.ReadLine(), out int numberOfRooms))
                {
                    var price = h.GetPriceForNumberOfRooms(numberOfRooms);
                    Console.WriteLine("The price is:{0}", price);
                }
                else
                {
                    Console.WriteLine("Invalid number of rooms!");
                }

                Console.WriteLine("Get number of days for reservation:");
                if (int.TryParse(Console.ReadLine(), out int numberOfDays))
                {
                    Console.WriteLine("Prices for rooms are:");
                    foreach (Room r in h.Rooms)
                    {
                        Console.WriteLine("\t {0} - {1} {2}", r.Name, r.GetPriceForDays(numberOfDays), r.Rate.Currency);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }

                Console.WriteLine("Find a room with a price lower than :");
                if (int.TryParse(Console.ReadLine(), out int minPrice))
                {
                    h.GetRoomWithLowestPrice(minPrice);
                }
                else
                {
                    Console.WriteLine("Invalid number of rooms!");
                }

                hotels.Remove(h);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
