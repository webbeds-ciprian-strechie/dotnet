using System;
using System.Collections.Generic;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Hotel h = new Hotel();
            h.Name = "HILTON";
            h.City = "LONDON";

            h.Rooms = new List<Room>();
            h.Rooms.Add(new Room());
            h.Rooms[0].Name = "DELUXE";
            h.Rooms[0].Children = 1;
            h.Rooms[0].Adults = 2;
            h.Rooms[0].Rate = new Rate();
            h.Rooms[0].Rate.Amount = 10;
            h.Rooms[0].Rate.Currency = "USD";

            Room room = new Room();
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
                Console.WriteLine("Get number of rooms:");
                if(int.TryParse(Console.ReadLine(), out int numberOfRooms))
                {
                    var price = h.GetPriceForNumberOfRooms(numberOfRooms);
                    Console.WriteLine("The price is:{0}", price);
                }
                else
                {
                    Console.WriteLine("Invalid number of rooms!");
                }

                Console.WriteLine("Get number of days:");
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
