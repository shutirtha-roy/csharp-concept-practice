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
            //https://www.tutorialsteacher.com/linq




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

            //Method Syntax
            var innerJoinInt = stringValuesOne.Join(
                            stringValuesTwo,
                            stringOne => stringOne,
                            stringTwo => stringTwo,
                            (stringOne, stringTwo) => stringOne);

            //foreach (var val in innerJoinInt)
            //{
            //    Console.WriteLine(val);
            //}

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

            //var innerJoinVehicle = vehicles.Join(
            //            toolList,
            //            vehicle => vehicle.GeneralId,
            //            tool => tool.Id,
            //            (vehicle, tool) => new  // result selector
            //            {
            //                VehicleName = vehicle.VehicleName,
            //                ToolName = tool.ToolName
            //            });

            //foreach (var pair in innerJoinVehicle)
            //{
            //    Console.WriteLine($"{pair.VehicleName}\t{pair.ToolName}");
            //}

            var innerJoinVehicle = toolList.Join(
                        vehicles,
                        tool => tool.Id,
                        vehicle => vehicle.GeneralId,
                        (tool, vehicle) => new  // result selector
                        {
                            ToolName = tool.ToolName,
                            VehicleName = vehicle.VehicleName
                        });

            //foreach (var pair in innerJoinVehicle)
            //{
            //    Console.WriteLine($"{pair.ToolName}\t{pair.VehicleName}");
            //}


            //Query Syntax
            var innerJoinQuery = from v in vehicles
                                 join t in toolList
                                 on v.GeneralId equals t.Id
                                 select new
                                 {
                                     VehicleName = v.VehicleName,
                                     ToolName = t.ToolName
                                 };

            #endregion
            #region GROUP JOIN

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            toolList = new List<Tools>()
            {
                new Tools(){ GeneralId = 1, ToolName = "Tool 1"  },
                new Tools(){ GeneralId = 2, ToolName = "Tool 2"  },
                new Tools(){ GeneralId = 3, ToolName = "Tool 3" }
            };


            //Method Syntax
            var groupJoin = toolList.GroupJoin(vehicles,
                                tool => tool.GeneralId,
                                vehicle => vehicle.GeneralId,
                                (tool, vehiclesGroup) => new
                                {
                                    Vehicles = vehiclesGroup,
                                    ToolFullName = tool.ToolName
                                });

            //foreach (var item in groupJoin)
            //{
            //    Console.WriteLine(item.ToolFullName);

            //    foreach (var vehicle in item.Vehicles)
            //    {
            //        Console.WriteLine(vehicle.VehicleName);
            //    }
            //}


            //Query Syntax
            var groupNewJoin = from tool in toolList
                               join vehicle in vehicles
                               on tool.GeneralId equals vehicle.GeneralId
                               into vehicleGroup
                               select new
                               {
                                   Vehicles = vehicleGroup,
                                   ToolName = tool.ToolName
                               };

            //foreach (var item in groupNewJoin)
            //{
            //    Console.WriteLine(item.ToolName);

            //    foreach(var vehicle in item.Vehicles)
            //    {
            //        Console.WriteLine(vehicle.VehicleName);
            //    }
            //}

            #endregion
            #region SELECT
            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            //Query Syntax
            var selectResultVehicle = from vehicle in vehicles
                                      select new
                                      {
                                          Name = $"Awesome->{vehicle.VehicleName}",
                                          Weight = vehicle.Weight
                                      };

            //Method Syntax
            selectResultVehicle = vehicles.Select(vehicle => new
            {
                Name = vehicle.VehicleName,
                Weight = vehicle.Weight
            });

            //foreach (var item in selectResultVehicle)
            //{
            //    Console.WriteLine($"Vehicle Name: {item.Name} {item.Weight}");
            //}

            #endregion
            #region All, Any

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            bool areAllVehiclesLight = vehicles.All(vehicle => vehicle.Weight > 20 && vehicle.Weight < 40);
            //Console.WriteLine(areAllVehiclesLight);

            bool areAnyVehiclesLight = vehicles.Any(vehicle => vehicle.Weight > 20 && vehicle.Weight < 40);
            //Console.WriteLine(areAnyVehiclesLight);


            #endregion
            #region Contains

            IList<string> stringFruitList = new List<string>() { "apple", "mango", "banana" };
            bool resultFruit = stringFruitList.Contains("apple1");
            //Console.WriteLine(resultFruit);

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            Vehicle vh = new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50 };

            //Console.WriteLine(vehicles.Contains(vh, new VehicleComparer()));

            #endregion
            #region Aggregate
            IList<string> names = new List<string>() { "Samin", "Apurba", "Arnob" };

            //Aggregate in Method Syntax C#
            var commaNames = names.Aggregate((strOne, strTwo) => strOne + ", " + strTwo);
            //Console.WriteLine(commaNames);

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            //Aggregate Method with Seed Value
            string commaSeperatedVehicleNames = vehicles.Aggregate<Vehicle, string>(
                                                "Vehicle Names: ",
                                                (strOne, v) => strOne += v.VehicleName + ",");

            //Console.WriteLine(commaSeperatedVehicleNames);


            //Aggregate with Seed Value C#
            int sumOfVehicleWeight = vehicles.Aggregate<Vehicle, int>(0,
                                                (totalWeight, v) => totalWeight += v.Weight);

            //Console.WriteLine(sumOfVehicleWeight);


            //Aggregate Method with Result Selector
            commaSeperatedVehicleNames = vehicles.Aggregate<Vehicle, string, string>(
                                         String.Empty, //seed value
                                         (strOne, v) => strOne += v.VehicleName + ",",
                                         strOne => strOne.Substring(0, strOne.Length - 1));

            //Console.WriteLine(commaSeperatedVehicleNames);

            #endregion
            #region Average
            IList<int> digits = new List<int>() { 10, 20, 30, 44 };
            //Console.WriteLine(digits.Average());

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            //Console.WriteLine(vehicles.Average(v => v.Weight));


            #endregion
            #region Count
            digits = new List<int>() { 10, 20, 30, 44 };
            //Console.WriteLine(digits.Count());
            //Console.WriteLine(digits.Count(i => i % 2 == 1));

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            Console.WriteLine(vehicles.Count());
            Console.WriteLine(vehicles.Count(v => v.VehicleId % 2 == 0));


            #endregion
        }
    }
}