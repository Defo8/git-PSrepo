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
                new FoodProduct("Jogurt", 3, new DateTime(2060, 12,1), 10)
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
                Console.WriteLine("== Akademik: Lodowka ==");
                Console.WriteLine("1. Jedz");
                Console.WriteLine("0. Powrot");
                Console.WriteLine("\nSTATY:");
                player.ShowPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Wybierz co chcesz zrobic (numer): ");

                string ans = Console.ReadLine();

                if (ans == "1")
                {
                    Console.Clear();
                    if (FoodInList.Count > 0)
                    {
                        Console.WriteLine("Jedzenie w lodowce: ");
                        DisplayFoodInList();

                        Console.WriteLine("\nWybierz co chesz zjesc: ");
                        string anss = Console.ReadLine();
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
                                Console.WriteLine("Nie takiego jedzenia w twojej lodowce :<");
                                Console.WriteLine("\nWybierz co chesz zjesc: ");
                                anss = Console.ReadLine();
                            }
                        }


                        if (food != null)
                        {
                            FoodInList.Remove(food);
                            player.Statistics[0].Increase(food.FoodValue);
                            player.Time.Calendar = player.Time.Calendar.AddMinutes(15);

                        }
                        else
                        {
                            Console.WriteLine("Nie ma takiego jedzenia");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nie masz nic w lodówce, kliknij aby powrócić");
                        Console.ReadKey();
                    }
                }
                else if (ans == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wpisz ktorys z podanych numerow");
                    Thread.Sleep(1500);
                }
            }
        }

        public void DisplayFoodInList()
        {
            foreach (var product in FoodInList)
            {
                Console.WriteLine(product.Name + ", Wartosc odrzywcza: " + product.FoodValue
                                               + ", Data waznosci: " + product.ValidDate);
            }
        }
    }
}
