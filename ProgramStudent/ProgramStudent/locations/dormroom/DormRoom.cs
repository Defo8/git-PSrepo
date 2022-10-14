using System;
using System.Threading;
using System.IO;

namespace ProgramStudent
{
    class DormRoom : ILocation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsRoommateIn { get; set; }
        public Fridge Fridge { get; set; }
        public Laptop Laptop { get; set; }

        public DormRoom()
        {
            Name = "Dorm";
            IsActive = true;
            IsRoommateIn = true;
            Fridge = new Fridge();
            Laptop = new Laptop();
        }

        public void Hub(Player player)
        {          

            while (true)
            {

                Console.Clear();
                Console.WriteLine(File.ReadAllText(Game.ART + "dorm.txt"));
                Console.WriteLine("== Dorm == " + "Calendary: " + Time.Calendar + " " + Time.Calendar.DayOfWeek);
                Console.WriteLine("1. Sleep");
                Console.WriteLine("2. Laptop");
                Console.WriteLine("3. Fridge");
                Console.WriteLine("4. Talk with Roommate");
                Console.WriteLine("5. Door");
                Console.WriteLine("0. Main Menu");
                Console.WriteLine("What you want to do? (Number): ");
                Console.WriteLine("\nSTATS:");
                player.ShowPlayerInfo();

                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        SleepInBed(player);                       
                        break;
                    case "2":
                        Laptop.LaptopHub(player);
                        break;
                    case "3":
                        Fridge.FridgeHub(player);
                        break;
                    case "4":
                        TalkWithRoommate(player);
                        break;
                    case "5":
                        player.ChangeLocation();
                        player.CurrentLocation.Hub(player);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Type number form 1-5. If you type 0, you will leave to main menu");
                        break;
                }
            }
        }

        public void TalkWithRoommate(Player player)
        {
            Console.Clear();
            if (IsRoommateIn)
            {
                string talk = "*Talk, talk, talk...";
                foreach (char t in talk)
                {
                    Console.Write(t);
                    Thread.Sleep(20);
                }
                Time.Calendar = Time.Calendar.AddMinutes(15);
                player.TimeConsequence.UpdateIfNeeded(player);
                player.ChangeStatisticsCurrentValue(typeof(Company), 7);
                player.ChangeStatisticsCurrentValue(typeof(MentalHealth), 5);

            }
            else
            {
                Console.WriteLine("Roommate is somewher else");               
            }
        }

        public void SleepInBed(Player player)
        {
            Console.Clear();
            Console.WriteLine("How long do you want to sleep? (0 makes you back to Dorm view): ");

            int h;
            while (true)
            {
                try
                {
                    h = Int32.Parse(Console.ReadLine());
                    if (h < 0)
                    {
                        Console.WriteLine("Time lower than 0");
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("You must type the number");
                }
            }

            int SleepGain = h * 20; // add to const
            int EnergyGain = h * 20;

            player.ShowPlayerInfo();

            if(h > 0) // if h = 0, back to doormroom
            {
                
                Time.Calendar = Time.Calendar.AddHours(h);
                player.TimeConsequence.UpdateIfNeeded(player);
                player.ChangeStatisticsCurrentValue(typeof(Energy), EnergyGain);
                player.ChangeStatisticsCurrentValue(typeof(Sleep), SleepGain);

                Console.Clear();

                string zzz = "Z Z Z Z Z z z z z. . .";

                foreach (char c in zzz)
                {
                    Console.Write(c);
                    Thread.Sleep(10);
                }       
            }
            
        }
    }
}
