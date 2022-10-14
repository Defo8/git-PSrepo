using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    class Shop: ILocation
    {
        public static readonly TimeSpan CLOSINGHOUR = new TimeSpan(22, 0, 0);
        public static readonly TimeSpan OPENINGOUR = new TimeSpan(7, 0, 0);
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<FoodProduct> ListOfFood { get; set; }

        public Shop()
        {
            Name = "Shop";
            IsActive = true;
            ListOfFood = new List<FoodProduct>
            {               
                new FoodProduct("Bread", 2, new DateTime(2054, 11, 23), 40, mass: 450), // kromka chleba 50g
                new FoodProduct("Banana", 2, new DateTime(2054, 11, 23), 8),
                new FoodProduct("Cheese", 5, new DateTime(2054, 11, 23), 35, mass: 200),
                new FoodProduct("Ham", 4, new DateTime(20), 50, mass: 200)

            };
        }

        public void Hub(Player player)
        {
            while (true)
            {
                if (Time.Calendar.TimeOfDay > CLOSINGHOUR || Time.Calendar.TimeOfDay < OPENINGOUR) // add to function
                {
                    Console.WriteLine("Shop is closed... (Open at 7:00 - 22: 00)");
                    IsActive = false;
                    Time.Calendar.AddMinutes(-20);
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    IsActive = true;
                }

                Console.Clear();
                Console.WriteLine("== Shop  == " + "Calendary: " + Time.Calendar + " " + Time.Calendar.DayOfWeek);
                Console.WriteLine("1. Buy something");
                Console.WriteLine("0. Go somwehere else");
                Console.WriteLine("What you want to do? (Number): ");
                Console.WriteLine("\nSTATS:");
                player.ShowPlayerInfo();

                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        BuySomthing(player);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Type number form 1-5. If you type 0, you will leave to main menu");
                        break;
                }

            }
        }

        public void BuySomthing(Player player)
        {
            Console.WriteLine("What you want to buy?");
            foreach(FoodProduct food in ListOfFood)
            {
                Console.WriteLine(food.Name + ", " + food.Cost + ", "+ food.ValidDate);
            }
            string ans = Console.ReadLine();

            foreach(FoodProduct food in ListOfFood)
            {
                if(ans == food.Name)
                {
                    Console.WriteLine("Do you want to buy "+ food.Name+" for: "+food.Cost+"? YES/NO");
                    string anss = Console.ReadLine();
                    if(anss == "YES")
                    {
                        if(player.Money - food.Cost < 0)
                        {
                            
                            Console.WriteLine("You don't have money");
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            if (player.Inventory.Contains(food))
                                player.Inventory.Find(x => x == food).Amount += 1;
                            else
                                player.Inventory.Add(food);                      
                        }                     
                    }
                }
            }
        }
    }
}
