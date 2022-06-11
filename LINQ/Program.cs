using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static bool isLight(Vehicle vehicle)
        {
            return vehicle.Weight > 30 && vehicle.Weight <= 50;
        }
        static void Main(string[] args)
        {
            //Basic Concepts
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            # region Basic LINQ Query Syntax
            //Console.WriteLine("Query Syntax");
            var evenNumbers = (from num in numbers
                               where num % 2 == 0
                               select num).ToArray();
            //Console.WriteLine($"Even numbers are {string.Join(" ", evenNumbers)}");
            #endregion
            # region Basic LINQ Method Syntax
            //Console.WriteLine("Method Syntax");
            var oddNumbers = numbers.Where(num => num % 2 == 1).ToArray();
            //Console.WriteLine($"Odd numbers are {string.Join(" ", oddNumbers)}");
            #endregion

            #region WHERE clause
            Console.WriteLine("WHERE clause");
            //Query Syntax
            Console.WriteLine("WHERE Query Syntax clause");

            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 63 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45 }
            };

            var seperatedVehicles = (from vehicle in vehicles
                                     where vehicle.Weight > 30 && vehicle.Weight <= 50
                                     select vehicle.VehicleName).ToArray();

            Console.WriteLine($"Seperated Vehicle: {string.Join("->", seperatedVehicles)}");

            var seperatedVehiclesMethod = (from vehicle in vehicles
                                           where isLight(vehicle)
                                           select vehicle).ToArray();

            foreach(var vehicle in seperatedVehiclesMethod)
            {
                Console.WriteLine($"{vehicle.VehicleId} {vehicle.VehicleName} {vehicle.Weight}");
            }

            #endregion
        }
    }
}
