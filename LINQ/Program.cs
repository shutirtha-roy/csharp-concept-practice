using System;
using System.Collections;
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
            //https://www.tutorialsteacher.com/linq/linq-filtering-operators-where

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
            #region WHERE Query
            //Console.WriteLine("WHERE clause");
            

            List<Vehicle> vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 63 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45 }
            };

            //Query Syntax
            //Console.WriteLine("WHERE Query Syntax clause");

            var seperatedVehicles = (from vehicle in vehicles
                                     where vehicle.Weight > 30 && vehicle.Weight <= 50
                                     select vehicle.VehicleName).ToArray();

            //Console.WriteLine($"Seperated Vehicle: {string.Join("->", seperatedVehicles)}");

            var seperatedVehiclesMethod = (from vehicle in vehicles
                                           where isLight(vehicle)
                                           select vehicle).ToArray();

            //foreach(var vehicle in seperatedVehiclesMethod)
            //{
            //    Console.WriteLine($"{vehicle.VehicleId} {vehicle.VehicleName} {vehicle.Weight}");
            //}

            //Multiple Where Clause
            var newSeperatedVehicles = (from vehicle in vehicles
                                     where vehicle.Weight > 30
                                     where vehicle.Weight <= 50
                                     select vehicle.VehicleName).ToArray();

            //Method Syntax
            //Console.WriteLine("Method Syntax");
            var seperatedMethodVehicles = vehicles.Where(v => v.Weight > 30 && v.Weight <= 50);

            var seperatedResult = vehicles.Where((s, i) =>
            {
                if (i % 2 == 0)
                    return true;

                return false;
            });

            //Multiple WHERE Clause
            var newMethodSeperatedResult = vehicles.Where(v => v.Weight > 30).Where(v => v.Weight <= 50);
            #endregion
            #region OfType Query
            ArrayList randomBoxList = new ArrayList();
            randomBoxList.Add(1);
            randomBoxList.Add("flower");
            randomBoxList.Add(true);
            randomBoxList.Add(5);
            randomBoxList.Add(new Vehicle() { VehicleId = 0, VehicleName = "Cool Car", Weight = 32 });

            //Query Syntax
            var intArray = from v in randomBoxList.OfType<int>()
                              select v;

            //Console.WriteLine(string.Join(" ", intArray));

            //Method Syntax
            intArray = randomBoxList.OfType<int>();
            //Console.WriteLine(string.Join(" ", intArray));
            #endregion


        }
    }
}
