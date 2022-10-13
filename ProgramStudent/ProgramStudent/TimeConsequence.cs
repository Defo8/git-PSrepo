using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    public class TimeConsequence : Time
    {
        public static readonly TimeSpan HOUR = new DateTime(1, 1, 1, 1, 0, 0) - new DateTime(1, 1, 1, 0, 0, 0);
        public DateTime LastChangeCalendar { get; set; }
        public int LastYear { get; set; }
        public int LastMonth { get; set; }
        public int LastDay { get; set; }
        public List<Event> ListOfEvent { get; set; }
        public TimeConsequence(DateTime date)
        {
            LastChangeCalendar = date;
            LastYear = date.Year;
            LastMonth = date.Month;
            LastDay = date.Day;
        }

        public void UpdateIfNeeded(Player player) 
        {
            
            TimeSpan ourDiffrence = player.Time.Calendar - player.TimeConsequence.LastChangeCalendar;
            double totalHoursPast = Math.Floor(ourDiffrence.TotalHours);
            Random rnd = new Random();
            if (ourDiffrence >= HOUR)
            {
                if (ourDiffrence.TotalHours > 3)
                {
                    LastChangeCalendar = LastChangeCalendar.Add(ourDiffrence);
                    Console.Clear();
                    Console.WriteLine("REMEMBER! IF YOU STUDY YOU WILL PASS, IF YOU NOT YOU WON'T... :) ");
                    Thread.Sleep(2000);
                    for (int i = 0; i < totalHoursPast; i++)
                    {
                        player.ChangeStatisticsCurrentValue(typeof(Food), -rnd.Next(8, 16));
                        player.ChangeStatisticsCurrentValue(typeof(Energy), -rnd.Next(7, 10));
                        player.ChangeStatisticsCurrentValue(typeof(Company), -rnd.Next(4, 5));
                        player.ChangeStatisticsCurrentValue(typeof(Sleep), -rnd.Next(6, 11));
                        if (rnd.Next(100) > 65)
                            player.ChangeStatisticsCurrentValue(typeof(MentalHealth), rnd.Next(0, 18));
                    }

                    foreach (Needmant stat in player.Statistics)
                    {
                        if (stat.CurrentValue == 0)
                        {
                            stat.IfCurrentValueZero();
                        }
                    }

                    if (player.Time.Calendar >= player.Time.EndOfSemester)
                    {
                        while (true)
                        {
                            if (player.KnowledgePoints >= 15000)
                            {
                                Console.WriteLine("GRATULACJE!!! UDALO CI SIE ZDAC SESJE");
                                Environment.Exit(0);
                            }
                            else
                                Console.WriteLine("NIESTETY NIE UDALO CI SIE ZDAC SESJI");
                            Environment.Exit(0);
                        }
                    }

                    return;
                }

                LastChangeCalendar = LastChangeCalendar.Add(ourDiffrence);


                for (int i = 0; i < totalHoursPast; i++)
                {
                    player.ChangeStatisticsCurrentValue(typeof(Food), -rnd.Next(4, 16));
                    player.ChangeStatisticsCurrentValue(typeof(Energy), -rnd.Next(5, 10));
                    player.ChangeStatisticsCurrentValue(typeof(Company), -rnd.Next(1, 5));
                    player.ChangeStatisticsCurrentValue(typeof(Sleep), -rnd.Next(5, 10));
                    if (rnd.Next(100) > 70)
                        player.ChangeStatisticsCurrentValue(typeof(MentalHealth), rnd.Next(-15, 15));
                }
            }

            if(player.Time.Calendar >= player.Time.EndOfSemester)
            {
                while(true)
                {
                    if(player.KnowledgePoints >= 15000)
                    {
                        Console.WriteLine("GRATULACJE!!! UDALO CI SIE ZDAC SESJE");
                        Environment.Exit(0);
                    }                       
                    else
                        Console.WriteLine("NIESTETY NIE UDALO CI SIE ZDAC SESJI");
                        Environment.Exit(0);
                }    
            }

            // MakeEvents(player); // DO TESTOW;
        }

        public void MakeEvents(Player player)
        {
            Random rnd = new Random();
            Dictionary<Type, int> ChorobaCGDict = new Dictionary<Type, int>
            {
                {typeof(Sleep), -2 },
                {typeof(Energy), -5 },
                {typeof(Food), -3},               
            };

            Dictionary<Type, int> ChorobaMVDict = new Dictionary<Type, int>
            {
                {typeof(Sleep), -5 },
                {typeof(Energy), -15 },
                {typeof(Food), -5},
            };

            IModify ChorobaCG = new ChangeMaxValueModifier(player, "Illness", player.Time.Calendar.AddDays(7), "You feel sick", ChorobaMVDict);
            Event ChorobaEvent = new Event("You got sick!", "You are sick and you feel bad", ChorobaCG);

            ListOfEvent = new List<Event>
            {
                ChorobaEvent
            };

            ChorobaEvent.Occur(player);

        }



    }
}
