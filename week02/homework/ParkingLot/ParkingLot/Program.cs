using ParkingLot.ParkingLot;
using ParkingLot.ParkingSpot;
using ParkingLot.ParkingVehicle;
using System;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            Lot lot = new Lot()
            {
                Name = "Palas"
            };

            /*
             * Add Spots to Parking Lot
             */

            for (int i = 0; i < 10; i++)
            {
                lot.addParkingSpot(new CarSpot() { Number = "C" + i });
                lot.addParkingSpot(new MotorbikeSpot() { Number = "M" + i });
                lot.addParkingSpot(new VanSpot() { Number = "V" + i });
            }

            lot.displayParkingBoard();

            /*
             * Add CARs to parking
             */
            Vehicle? v = null;
            for (int i = 0; i < 11; i++)
            {

                Spot? s = lot.GetNextFreeSpot(ParkingSpotType.CAR);
                if (s != null)
                {
                    v = new Car() { LicenseNumber = "IS-" + i + "-MAI" };
                    lot.assignVehicleToSpot(v, s);
                }
            }

            lot.displayParkingBoard();

            /*
             * Remove CARs from parking
             */
            if (v != null)
            {
                lot.freeSpot(v.getTicket());
            }

            lot.displayParkingBoard();

            /*
             * Add MOTORBIKEs
             */
            for (int i = 0; i < 3; i++)
            {

                Spot? s = lot.GetNextFreeSpot(ParkingSpotType.MOTORBIKE);
                if (s != null)
                {
                    v = new MotorBike() { LicenseNumber = "IS-" + i + "-SPP" };
                    lot.assignVehicleToSpot(v, s);
                }
            }

            lot.displayParkingBoard();

            /*
            * Add VANs
            */
            for (int i = 0; i < 5; i++)
            {

                Spot? s = lot.GetNextFreeSpot(ParkingSpotType.VAN);
                if (s != null)
                {
                    v = new Van() { LicenseNumber = "IS-" + i + "-SIE" };
                    lot.assignVehicleToSpot(v, s);
                }
            }

            lot.displayParkingBoard();

        }
    }
}
