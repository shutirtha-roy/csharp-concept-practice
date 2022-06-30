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
            #region Problems 
            //Problem w3Resource
            LINQProblemw3 problem = new();
            //problem.Excercise1();
            //problem.Excercise2();
            //problem.Excercise3();
            //problem.Excercise4();
            //problem.Excercise5();
            //problem.Excercise6();
            #endregion
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

            //Console.WriteLine(vehicles.Count());
            //Console.WriteLine(vehicles.Count(v => v.VehicleId % 2 == 0));


            #endregion
            #region Max


            digits = new List<int>() { 10, 60, 30, 44 };
            //Console.WriteLine(digits.Max());
            //Console.WriteLine(digits.Max(i => i % 2 == 0));

            var largestEvenElements = digits.Max(i =>
                                        {
                                            if (i % 2 == 0)
                                                return i;

                                            return 0;
                                        });

            //Console.WriteLine(largestEvenElements);

            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            int maxVehicleId = vehicles.Max(v => v.VehicleId);

            //Console.WriteLine(maxVehicleId);


            var vehicleName = vehicles.Max();
            //Console.WriteLine($"{vehicleName.VehicleId} => {vehicleName.VehicleName}");
            #endregion
            #region Sum
            digits = new List<int>() { 10, 20, 30, 44, 31 };
            //Console.WriteLine(digits.Sum());

            var sumOfEvenNumbers = digits.Sum(i =>
                                            {
                                                if (i % 2 == 0)
                                                    return i;

                                                return 0;
                                            });

            //Console.WriteLine(sumOfEvenNumbers);


            vehicles = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            var thirtySumVehicles = vehicles.Sum(v =>
                                                {
                                                    if (v.Weight >= 30)
                                                    {
                                                        //return v.Weight;
                                                        return 1;
                                                    }
                                                        

                                                    return 0;
                                                });

            //Console.WriteLine(thirtySumVehicles);
            #endregion
            #region ElementAt, ElementAtOrDefault

            digits = new List<int>() { 10, 20, 30, 44, 31 };

            //Console.WriteLine(digits.ElementAt(0));
            //Console.WriteLine(digits.ElementAtOrDefault(6));

            #endregion
            #region First & FirstOrDefault

            digits = new List<int>() { 10, 20, 30, 44, 31 };
            //Console.WriteLine(digits.First());
            //Console.WriteLine(digits.First(i => i % 2 == 1));
            //Console.WriteLine(digits.FirstOrDefault(i => i % 2 == 1));
            //Console.WriteLine(digits.First(i => i > 30));


            IList<string> strV = new List<string>() { "One", "Two" };
            //Console.WriteLine(strV.FirstOrDefault(s => s.Contains("w")));
            #endregion
            #region Last & LastOrDefault

            digits = new List<int>() { 10, 20, 30, 44, 31 };
            //Console.WriteLine(digits.Last());
            //Console.WriteLine(digits.Last(i => i % 2 == 1));
            //Console.WriteLine(digits.LastOrDefault(i => i % 2 == 0));
            //Console.WriteLine(digits.Last(i => i > 30));

            strV = new List<string>() { "One", "Two", "w" };
            //Console.WriteLine(strV.LastOrDefault(s => s.Contains("w")));
            #endregion
            #region Single & SingleOrDefault

            digits = new List<int>() { 10, 20, 30, 44, 31 };
            //Console.WriteLine(digits.Single());
            //Console.WriteLine(digits.SingleOrDefault());
            //Console.WriteLine(digits.Single(i => i % 2 == 1));
            #endregion
            #region SequenceEqual

            IList<string> strListOne = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            IList<string> strListTwo = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            //Console.WriteLine(strListOne.SequenceEqual(strListTwo));

            IList<Vehicle> vehiclesOne = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            IList<Vehicle> vehiclesTwo = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            //Console.WriteLine(vehiclesOne.SequenceEqual(vehiclesTwo, new VehicleComparer()));
            #endregion
            #region Concat
            IList<string> fruit1 = new List<string>() { "apple", "pineapple" };
            IList<string> fruit2 = new List<string>() { "banana", "watermelon" };

            var fruit3 = fruit1.Concat(fruit2);
            //Console.WriteLine(string.Join(" ", fruit3));
            #endregion
            #region DefaultIfEmpty
            IList<int> emptyInt = new List<int>() {  };
            var list1 = emptyInt.DefaultIfEmpty();
            var list2 = emptyInt.DefaultIfEmpty(-1);

            //Console.WriteLine(list1.Count());
            //Console.WriteLine(list1.ElementAt(0));

            //Console.WriteLine(list2.Count());
            //Console.WriteLine(list2.ElementAt(0));

            IList<Vehicle> emptyVehicleList = new List<Vehicle>();
            var newVehicleList1 = emptyVehicleList.DefaultIfEmpty(new Vehicle());
            var newVehicleList2 = emptyVehicleList.DefaultIfEmpty(new Vehicle()
                                                                {
                                                                    VehicleId = 0,
                                                                    VehicleName = ""
                                                                });

            //Console.WriteLine(newVehicleList1.Count());
            //Console.WriteLine(newVehicleList1.ElementAt(0));

            //Console.WriteLine(newVehicleList2.Count());
            //Console.WriteLine(newVehicleList2.ElementAt(0).VehicleId);


            #endregion
            #region Empty, Range, Repeat


            //Empty
            var emptyEnumerableCollectionOne = Enumerable.Empty<string>();
            var emptyEnumerableCollectionTwo = Enumerable.Empty<Vehicle>();

            //Console.WriteLine(emptyEnumerableCollectionOne.Count());
            //Console.WriteLine(emptyEnumerableCollectionOne.GetType().Name);

            //Console.WriteLine(emptyEnumerableCollectionTwo.Count());
            //Console.WriteLine(emptyEnumerableCollectionTwo.GetType().Name);


            //Range
            var intValues = Enumerable.Range(10, 10);

            //Console.WriteLine(intValues.Count());
            //Console.WriteLine(intValues.ElementAtOrDefault(3));


            //Repeat
            var intRepeatValues = Enumerable.Repeat<int>(3, 5);

            //foreach(var intRepeatValue in intRepeatValues)
            //{
            //    Console.WriteLine(intRepeatValue);
            //}
            #endregion
            #region Distinct
            digits = new List<int>() { 1, 1, 1, 2, 4, 4, 6, 8 };

            //Console.WriteLine(string.Join(" ", digits));
            //Console.WriteLine(string.Join(" ", digits.Distinct()));

            vehiclesOne = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            var distinctVehicle = vehiclesOne.Distinct(new VehicleComparer());

            foreach(Vehicle vehicle in distinctVehicle)
            {
                //Console.WriteLine(vehicle.VehicleName);
            }

            #endregion
            #region Except

            IList<int> dig1 = new List<int>() { 1, 2, 4, 5, 6, 3 };
            IList<int> dig2 = new List<int>() { 6, 11, 4, 5, 9, 4 };

            var exceptResult = dig1.Except(dig2);
            //Console.WriteLine(string.Join(" ", exceptResult));

            vehiclesOne = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 1, VehicleName = "BMW", Weight = 30, GeneralId = 1 },
                new Vehicle() { VehicleId = 2, VehicleName = "Toyota", Weight = 50, GeneralId = 2 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 4, VehicleName = "Alfa Romeo", Weight = 1, GeneralId = 1 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            vehiclesTwo = new List<Vehicle>()
            {
                new Vehicle() { VehicleId = 6, VehicleName = "NewBMW", Weight = 10, GeneralId = 8 },
                new Vehicle() { VehicleId = 7, VehicleName = "Workhorse", Weight = 40, GeneralId = 12 },
                new Vehicle() { VehicleId = 3, VehicleName = "Audi", Weight = 24, GeneralId = 3 },
                new Vehicle() { VehicleId = 7, VehicleName = "Waymo", Weight = 11, GeneralId = 11 },
                new Vehicle() { VehicleId = 5, VehicleName = "Tata", Weight = 45, GeneralId = 2 }
            };

            var exceptVehicleResult = vehiclesOne.Except(vehiclesTwo, new VehicleComparer());
            
            foreach(var vehicle in exceptVehicleResult)
            {
                Console.WriteLine(vehicle.VehicleName);
            }
            #endregion
        }
    }
}