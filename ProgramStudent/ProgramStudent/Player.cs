using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace ProgramStudent
{
    public class Player
    {
        [JsonProperty("statistics", ObjectCreationHandling = ObjectCreationHandling.Replace)] // YAY! 
        public List<Needmant> Statistics { get; set; }
        public List<IProduct> Inventory { get; set; } = new();
        public ILocation CurrentLocation { get; set; }
        public Time PlayerTime { get; set; }
        public TimeConsequence TimeConsequence { get; set; }
        public Timetable Timetable { get; set; }
        public double Money { get; set; }
        public int KnowledgePoints { get; set; }
        public List<IModify> ActiveModifers { get; set; } = new();
        public PlayerBio PlayerInfo { get; set; }
        public List<ILocation> Locations { get; set; } 
        public List<INPC> KnownNPC { get; set; } = new();
        public bool NewPlayer { get; set; } = true;
        public Player()
        {

            if(NewPlayer)
            {
                PlayerInfo = new PlayerBio();

                Statistics = new List<Needmant>
                {
                    new Food(),
                    new Energy(),
                    new Sleep(),
                    new Company(),
                    new MentalHealth()
                };

                KnownNPC.Add(new Roommate());
                Locations = new List<ILocation> { new DormRoom(), new University(), new Shop(), };
                CurrentLocation = Locations[0];
                
                TimeConsequence = new TimeConsequence(new DateTime(2054, 10, 1, 9, 0, 0));
                PlayerTime = new Time();

                Money = 500;
                KnowledgePoints = 0;
                NewPlayer = false;
                Timetable = new Timetable();
            }
        }
        public void ChangeLocation()
        {
            Console.WriteLine("Where do you want to go?");
            Console.WriteLine("1. University");
            Console.WriteLine("2. Ladybird's shop");
            Console.WriteLine("0. Stay here");
            string ans = Console.ReadLine();
            if(ans == "1")
            {
                CurrentLocation = Locations[1];
            }
            else if(ans == "2")
            {
                CurrentLocation = Locations[2];
            }
            PlayerTime.Calendar.AddMinutes(20);
            TimeConsequence.UpdateIfNeeded(this);                   
        }
        public void ChangeStatisticsMaxValue(Type needmant, int amount)
        {
            if (needmant == typeof(Food))
            {
                Statistics[0].MaxValue += amount;

                if (Statistics[0].CurrentValue > Statistics[0].MaxValue)
                    Statistics[0].CurrentValue = Statistics[0].MaxValue;
            }
            else if (needmant == typeof(Energy))
            {
                Statistics[1].MaxValue += amount;
                if (Statistics[1].CurrentValue > Statistics[1].MaxValue)
                    Statistics[1].CurrentValue = Statistics[1].MaxValue;
            }
            else if (needmant == typeof(Sleep))
            {
                Statistics[2].MaxValue += amount;
                if (Statistics[2].CurrentValue > Statistics[2].MaxValue)
                    Statistics[2].CurrentValue = Statistics[2].MaxValue;
            }
            else if (needmant == typeof(Company))
            {
                Statistics[3].MaxValue += amount;
                if (Statistics[3].CurrentValue > Statistics[3].MaxValue)
                    Statistics[3].CurrentValue = Statistics[3].MaxValue;
            }
            else if (needmant == typeof(MentalHealth))
            {
                Statistics[4].MaxValue += amount;
                if (Statistics[4].CurrentValue > Statistics[4].MaxValue)
                    Statistics[4].CurrentValue = Statistics[4].MaxValue;
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
        public void ChangeStatisticsCurrentValue(Type needmant, int amount)
        {
            if (needmant == typeof(Food))
            {
                Statistics.Find(x => x.Name == "Food").Increase(amount);
;
                if (Statistics.Find(x => x.Name == "Food").CurrentValue > Statistics.Find(x => x.Name == "Food").MaxValue)
                    Statistics.Find(x => x.Name == "Food").CurrentValue = Statistics.Find(x => x.Name == "Food").MaxValue;
            }
            else if (needmant == typeof(Energy))
            {
                Statistics.Find(x => x.Name == "Energy").Increase(amount);
                
                if (Statistics.Find(x => x.Name == "Energy").CurrentValue > Statistics.Find(x => x.Name == "Energy").MaxValue)
                    Statistics.Find(x => x.Name == "Energy").CurrentValue = Statistics.Find(x => x.Name == "Energy").MaxValue;
            }
            else if (needmant == typeof(Sleep))
            {
                Statistics.Find(x => x.Name == "Sleep").Increase(amount);

                if (Statistics.Find(x => x.Name == "Sleep").CurrentValue > Statistics.Find(x => x.Name == "Sleep").MaxValue)
                    Statistics.Find(x => x.Name == "Sleep").CurrentValue = Statistics.Find(x => x.Name == "Sleep").MaxValue;
            }
            else if (needmant == typeof(Company))
            {
                Statistics.Find(x => x.Name == "Company").Increase(amount);

                if (Statistics.Find(x => x.Name == "Company").CurrentValue > Statistics.Find(x => x.Name == "Company").MaxValue)
                    Statistics.Find(x => x.Name == "Company").CurrentValue = Statistics.Find(x => x.Name == "Company").MaxValue;
            }
            else if (needmant == typeof(MentalHealth))
            {
                Statistics.Find(x => x.Name == "MentalHealth").Increase(amount);

                if (Statistics.Find(x => x.Name == "MentalHealth").CurrentValue > Statistics.Find(x => x.Name == "MentalHealth").MaxValue)
                    Statistics.Find(x => x.Name == "MentalHealth").CurrentValue = Statistics.Find(x => x.Name == "MentalHealth").MaxValue;
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
        public void ShowPlayerInfo()
        {
            foreach (Needmant stat in Statistics)
            {
                if (stat.Name == "Food")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(stat.Name + "\n");
                    for (int i = 0; i < stat.CurrentValue/10; i++)
                    {                                             
                        Console.Write("██");                       
                    }
                    Console.Write(stat.CurrentValue);
                    Console.WriteLine("\n");
                }
                else if (stat.Name == "Energy")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(stat.Name + "\n");
                    for (int i = 0; i < stat.CurrentValue / 10; i++)
                    {
                        Console.Write("██");
                    }
                    Console.Write(stat.CurrentValue);
                    Console.WriteLine("\n");
                }
                else if (stat.Name == "Sleep")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(stat.Name + "\n");
                    for (int i = 0; i < stat.CurrentValue / 10; i++)
                    {
                        Console.Write("██");
                    }
                    Console.Write(stat.CurrentValue);
                    Console.WriteLine("\n");
                }
                else if (stat.Name == "Company")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(stat.Name + "\n");
                    for (int i = 0; i < stat.CurrentValue / 10; i++)
                    {
                        Console.Write("██");
                    }
                    Console.Write(stat.CurrentValue);
                    Console.WriteLine("\n");
                }
                else if (stat.Name == "MentalHealth")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(stat.Name + "\n");
                    for (int i = 0; i < stat.CurrentValue / 10; i++)
                    {
                        Console.Write("██");
                    }
                    Console.Write(stat.CurrentValue);
                    Console.WriteLine("\n");
                }

                Console.ResetColor();
            }
                
            Console.WriteLine("Knwoledge Points: " + KnowledgePoints);
            Console.WriteLine("Money: " + Money);
                    
            if(ActiveModifers.Count > 0)
            {
                Console.WriteLine("\n\n Modifiers: ");
                foreach (IModify mod in ActiveModifers)
                {
                    Console.WriteLine(mod.Name + "\n" + mod.Description);
                }
            }
          
        }
        public void AddModifier(IModify modifier)
        {
            if (ActiveModifers.Contains(modifier) == false)
                ActiveModifers.Add(modifier);
            else
                Console.WriteLine("There is modifier like this");
        }
        public void CheckForModifier()
        {
            List<IModify> outdatedModList = new List<IModify>();  // List agregating  outdated modifiers

            if (ActiveModifers.Capacity != 0)
            {
                foreach (IModify mod in ActiveModifers)  // Invoker for commands (Modifiers). 
                {
                    if (ModfierValidDateCheck(mod)) // If ValidDateCheck returns true - it execute command, what means modifier is active 
                    {
                        mod.Execute();
                    }
                    else // If validation check  is fale that means we have to undo changes
                    {
                        mod.Undo();
                        outdatedModList.Add(mod);
                    }
                }

                foreach (IModify mod in outdatedModList) // After we undo our changes we can remove outdated modifiers from the list
                {
                    ActiveModifers.Remove(mod);
                }
            }
            else
            {
                Console.WriteLine("No modifiers in activeModifiers");
            }
        }
        public bool ModfierValidDateCheck(IModify mod)  // Check valid date, if it is negative timespan it means that modfiers is out of date (false)
        {
            TimeSpan endofTime = PlayerTime.Calendar - PlayerTime.Calendar;

            if (mod.Duration - PlayerTime.Calendar >= endofTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
