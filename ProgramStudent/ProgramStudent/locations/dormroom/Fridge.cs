using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProgramStudent
{
    class Fridge
    {
        public List<FoodProduct> FoodInList { get; set; }

        public Fridge()
        {
            FoodInList = new List<FoodProduct>
            {
                new FoodProduct("Yoghurt", 3, new DateTime(2060, 12,1), 10)
            };
        }

        public void FridgeHub(Player player)
        {
            while (true)
            {         
                if(player.Inventory.Count > 0)
                {
                    foreach (FoodProduct food in player.Inventory)
                    {
                        FoodInList.Add(food);
                    }
                }                                        
                player.Inventory.Clear();

                Console.Clear();
                Console.WriteLine("== Dorm: Fridge ==");
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
                    if (FoodInList.Count > 0)
                    {
                        Console.WriteLine("Food in the fridge: ");
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
                                food = (from f in FoodInList where f.Name == anss select f).First();
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("There is no this kind of food in the fridge :<");
                                Console.WriteLine("\nWhat you want to do? (Number): ");
                                anss = Console.ReadLine();
                            }
                        }


                        if (food != null)
                        {
                            FoodInList.Remove(food);
                            player.Statistics[0].Increase(food.FoodValue);
                            Time.Calendar = Time.Calendar.AddMinutes(15);

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
            foreach (var product in FoodInList)
            {
                Console.WriteLine(product.Name + ", Food points: " + product.FoodValue
                                               + ", Valid date: " + product.ValidDate);
            }
        }
    }
}
