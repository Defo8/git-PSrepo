using System;
using System.Threading;

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
            for(int i=0; i<5; i++)
            {
                player.Statistics.RemoveAt(i);
            }
            player.Statistics.Insert(0, player.Statistics[2]);
            player.Statistics.Insert(1, player.Statistics[2]);

            while (true)
            {

                Console.Clear();
                Console.WriteLine("== Dorm == " + "Calendary: " + player.Time.Calendar + " " + player.Time.Calendar.DayOfWeek);
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
                player.Time.Calendar = player.Time.Calendar.AddMinutes(15);
                player.TimeConsequence.UpdateIfNeeded(player);
                player.Statistics[3].Increase(10);
                player.Statistics[4].Increase(5);
                
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

            int SleepGain = h * 23; // dodac do const 13
            int EnergyGain = h * 23;

            player.ShowPlayerInfo();

            if (h > 0)
            {
                player.Statistics[1].Increase(EnergyGain);
                player.Statistics[2].Increase(SleepGain);
                player.Time.Calendar = player.Time.Calendar.AddHours(h);
                player.TimeConsequence.UpdateIfNeeded(player);
                if(player.Statistics[1].CurrentValue < 20 && player.Statistics[2].CurrentValue < 20)
                {
                    player.Statistics[1].Increase(EnergyGain);
                    player.Statistics[2].Increase(SleepGain);
                }
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
