using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace ProgramStudent
{
    class Kitchen : ILocation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<FoodProduct> FoodInKitchenList { get; set; }

        public Kitchen()
        {
            Name = "Kitchen";
            IsActive = true;
            FoodInKitchenList = new List<FoodProduct>
            {
                new FoodProduct("Yoghurt", 3, new DateTime(2060, 12,1), 10)
            };
        }

        public void Hub(Player player)
        {
            while (true)
            {
                
                if(player.Inventory.Count > 0)
                {
                    foreach (FoodProduct food in player.Inventory)
                    {
                        FoodInKitchenList.Add(food);
                    }
                }                                        
                player.Inventory.Clear();

                Console.Clear();
                Console.WriteLine(File.ReadAllText(Game.ART + "kitchen.txt"));
                Console.WriteLine("== Dorm: Kitchen ==");
                Console.WriteLine("1. Food");
                Console.WriteLine("0. Back");
                Console.WriteLine("\nSTATS:");
                player.ShowPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("\nWhat you want to do? (Number) : ");

                string ans = Console.ReadLine();

                if (ans == "1")
                {
                    Console.Clear();
                    if (FoodInKitchenList.Count > 0)
                    {
                        Console.WriteLine("Food in the kitchen: ");
                        DisplayFoodInList();

                        Console.WriteLine("\nWhat you want to eat? (0 if you want to leave): ");
                        string anss = Console.ReadLine();
                        if (anss == "0")
                            break;

                        FoodProduct food;
                        while (true)
                        {
                            try
                            {
                                food = (from f in FoodInKitchenList where f.Name == anss select f).First();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("There is no this kind of food in the kitchen :<");
                                Console.WriteLine("\nWhat you want to do? (Number): ");
                                anss = Console.ReadLine();
                            }
                        }


                        if (food != null)
                        {
                            FoodInKitchenList.Remove(food);
                            player.Statistics[0].Increase(food.FoodValue);
                            player.PlayerTime.Calendar = player.PlayerTime.Calendar.AddMinutes(15);

                        }
                        else
                        {
                            Console.WriteLine("There is no food like that");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No food bruh, click something to go on");
                        Console.ReadKey();
                    }
                }
                else if (ans == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Choose the number: ");
                    Thread.Sleep(1500);
                }
            }
        }

        public void DisplayFoodInList()
        {
            foreach (var product in FoodInKitchenList)
            {
                Console.WriteLine(product.Name + ", Food points: " + product.FoodValue
                                               + ", Valid date: " + product.ValidDate);
            }
        }
    }
}
