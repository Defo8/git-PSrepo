using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    class University : ILocation
    {
        public static readonly TimeSpan CLOSINGHOUR = new TimeSpan(21, 0, 0);
        public static readonly TimeSpan OPENINGOUR = new TimeSpan(6, 0, 0);
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Timetable Classes { get; set; }
        public University()
        {
            Name = "University";
            IsActive = true;
            Classes = new Timetable();
        }
        public void Hub(Player player)
        {
            while (true)
            {
                if (Time.Calendar.TimeOfDay > CLOSINGHOUR || Time.Calendar.TimeOfDay < OPENINGOUR)
                {
                    Console.Clear();
                    Console.WriteLine("University is closed... (Open at 6:00 - 21: 00)");
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
                Console.WriteLine("== Academy == " + "Calendary: " + Time.Calendar + " " + Time.Calendar.DayOfWeek);
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
            UniversityClass currentClasses = ReturnAvailableClasses();
            if (currentClasses == null)
            {
                Console.Clear();
            }
            else
            {
                string text = "Attending...";
                foreach(char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(200);
                }
                currentClasses.Presence = true;
                player.KnowledgePoints += 50;
                Time.Calendar += currentClasses.EndTime - currentClasses.StartTime;
                player.TimeConsequence.UpdateIfNeeded(player);
            }
        }

        private UniversityClass ReturnAvailableClasses()
        {
            DayOfWeek currentDayOfWeek = Time.Calendar.DayOfWeek;
            if (currentDayOfWeek == DayOfWeek.Monday)
            {
                foreach (UniversityClass clas in Classes.Table[0])
                {
                    if (clas.StartTime > Time.Calendar.TimeOfDay && Time.Calendar.TimeOfDay < clas.EndTime)
                        return DecideAboutAttending(clas);
                }
                Console.WriteLine("There is no classes that you can attend on right now");
                Thread.Sleep(1500);
                return null;
            }
            else if (currentDayOfWeek == DayOfWeek.Tuesday)
            {
                foreach (UniversityClass clas in Classes.Table[1])
                {
                    if (clas.StartTime > Time.Calendar.TimeOfDay && Time.Calendar.TimeOfDay < clas.EndTime)
                        return DecideAboutAttending(clas);
                }
                Console.WriteLine("There is no classes that you can attend on right now");
                Thread.Sleep(1500);
                return null;
            }
            else if (currentDayOfWeek == DayOfWeek.Wednesday)
            {
                foreach (UniversityClass clas in Classes.Table[2])
                {
                    if (clas.StartTime > Time.Calendar.TimeOfDay && Time.Calendar.TimeOfDay < clas.EndTime)
                        return DecideAboutAttending(clas);
                }
                Console.WriteLine("There is no classes that you can attend on right now");
                Thread.Sleep(1500);
                return null;
            }
            else if (currentDayOfWeek == DayOfWeek.Thursday)
            {
                foreach (UniversityClass clas in Classes.Table[3])
                {
                    if (Time.Calendar.TimeOfDay > clas.StartTime && Time.Calendar.TimeOfDay < clas.EndTime)
                        return DecideAboutAttending(clas);
                }
                Console.WriteLine("There is no classes that you can attend on right now");
                Thread.Sleep(1500);
                return null;
            }
            else if (currentDayOfWeek == DayOfWeek.Friday)
            {
                foreach (UniversityClass clas in Classes.Table[4])
                {
                    if (clas.StartTime > Time.Calendar.TimeOfDay && Time.Calendar.TimeOfDay < clas.EndTime)
                        return DecideAboutAttending(clas);
                }
                Console.WriteLine("There is no classes that you can attend on right now");
                Thread.Sleep(1500);
                return null;
            }
            else
            {
                Console.WriteLine("Weekend! Free time!");
                return null;
            }

        }

        private UniversityClass DecideAboutAttending(UniversityClass clas)
        {
            while (true)
            {
                Console.WriteLine($"{clas.Name} class is going on right now");
                Console.WriteLine("Do you want to take a part? YES/NO");
                string answer = Console.ReadLine();
                answer = answer.ToLower();
                if (answer == "yes")
                {
                    return clas;
                }
                else if (answer == "no")
                {
                    Console.WriteLine("You don't go on your class");
                    Thread.Sleep(1500);
                    return null;
                }
                else
                {
                    Console.WriteLine("Type yes or no");
                    Thread.Sleep(1500);
                }
            }
        }
    }
}
