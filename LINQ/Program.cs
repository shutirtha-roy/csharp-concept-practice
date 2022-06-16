﻿using System;
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
            #region OrderBy
            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45 }
            };


            //Query Syntax
            var orderByVehicles = from v in vehicles
                                  orderby v.VehicleId
                                  select v;

            var orderByVehiclesDescending = from v in vehicles
                                            orderby v.VehicleId descending
                                            select v.VehicleId;

            //Console.WriteLine(string.Join(" ", orderByVehiclesDescending));

            //Method Syntax
            var orderByVehiclesMethod = vehicles.OrderBy(v => v.VehicleId);
            orderByVehiclesMethod = vehicles.OrderByDescending(v => v.VehicleId);

            //foreach (var vehicle in orderByVehiclesMethod)
            //{
            //    Console.WriteLine(vehicle.VehicleName);
            //}


            #endregion
            #region ThenBy Query
            var orderByThenVehiclesMethod = vehicles.OrderBy(v => v.VehicleId).ThenBy(v => v.Weight);
            orderByThenVehiclesMethod = vehicles.OrderByDescending(v => v.VehicleId).ThenByDescending(v => v.Weight);
            #endregion
            #region GroupBy Query and ToLookup Query

            //Query syntax
            var groupedVehicleWeight = from v in vehicles
                                       group v by v.Weight;

            //Method syntax
            groupedVehicleWeight = vehicles.GroupBy(v => v.Weight);

            //ToLoopup 
            groupedVehicleWeight = vehicles.ToLookup(v => v.Weight);

            //foreach (var ageGroup in groupedVehicleWeight)
            //{
            //    Console.WriteLine($"Weight Group: {ageGroup.Key}"); //Every Group has 1 key 

            //    foreach (Vehicle v in ageGroup) // Each group has collection within itself
            //    {
            //        Console.WriteLine($"Vehicle Name: {v.VehicleName}");
            //    }
            //}
            #endregion
            #region Join Query - INNER JOIN
            List<int> stringValuesOne = new List<int>()
            {
                1, 2, 3, 4
            };

            List<int> stringValuesTwo = new List<int>()
            {
                1, 2, 7, 8
            };

            var innerJoinInt = stringValuesOne.Join(
                            stringValuesTwo,
                            stringOne => stringOne,
                            stringTwo => stringTwo,
                            (stringOne, stringTwo) => stringOne);

            foreach (var val in innerJoinInt)
            {
                Console.WriteLine(val);
            }

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            IList<Tools> toolList = new List<Tools>()
            {
                new Tools(){ Id = 1, ToolName = "Tool 1"  },
                new Tools(){ Id = 2, ToolName = "Tool 2"  },
                new Tools(){ Id = 3, ToolName = "Tool 3" }
            };

            //Method Syntax
            var innerJoinVehicle = vehicles.Join(
                        toolList,
                        vehicle => vehicle.GeneralId,
                        tool => tool.Id,
                        (vehicle, tool) => new  // result selector
                        {
                            VehicleName = vehicle.VehicleName,
                            ToolName = tool.ToolName
                        });

            //foreach (var pair in innerJoinVehicle)
            //{
            //    Console.WriteLine($"{pair.VehicleName}\t{pair.ToolName}");
            //}


            #endregion
        }
    }
}
