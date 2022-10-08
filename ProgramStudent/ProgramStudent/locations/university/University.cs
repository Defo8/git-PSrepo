using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    public class University : ILocation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public void Hub(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Academy == " + "Calendary: " + player.Time.Calendar + " " + player.Time.Calendar.DayOfWeek);
                Console.WriteLine("1. Attend on classes");
                Console.WriteLine("0. Go somwehere else");
                Console.WriteLine("What you want to do? (Number): ");
                Console.WriteLine("\nSTATS:");
                player.ShowPlayerInfo();

                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        AttendOnClasses(player);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Type number form 1-5. If you type 0, you will leave to main menu");
                        break;
                }             
            }
        }

        public void AttendOnClasses(Player player)
        {
            player.KnowledgePoints += 50;
            player.Time.Calendar = player.Time.Calendar.AddHours(3);
            player.TimeConsequence.UpdateIfNeeded(player);
            Console.WriteLine("Attending on Classes...");
            Thread.Sleep(2000);
        }


    }
}
