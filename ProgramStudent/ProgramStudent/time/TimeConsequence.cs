using System;
using System.Collections.Generic;
using System.Threading;

namespace ProgramStudent
{
    public class TimeConsequence
    {
        public static readonly TimeSpan HOUR = new DateTime(1, 1, 1, 1, 0, 0) - new DateTime(1, 1, 1, 0, 0, 0);
        public DateTime LastChangeCalendar { get; set; }
        public int LastYear { get; set; }
        public int LastMonth { get; set; }
        public int LastDay { get; set; }
        public List<Event> ListOfEvent { get; set; }
        public TimeConsequence()
        {
            LastChangeCalendar = new DateTime(2054, 10, 1, 9, 0, 0);
            LastYear = LastChangeCalendar.Year;
            LastMonth = LastChangeCalendar.Month;
            LastDay = LastChangeCalendar.Day;
        }
        public TimeConsequence(DateTime date)
        {
            LastChangeCalendar = date;
            LastYear = date.Year;
            LastMonth = date.Month;
            LastDay = date.Day;
        }

        public void UpdateIfNeeded(Player player) 
        {
            
            TimeSpan TIME_PAST_FROM_LAST_UPDATE = player.PlayerTime.Calendar - player.TimeConsequence.LastChangeCalendar;
            double HOURS_PAST_FROM_LAST_UPDATE = Math.Floor(TIME_PAST_FROM_LAST_UPDATE.TotalHours);
            Random rnd = new Random();
            if (TIME_PAST_FROM_LAST_UPDATE.TotalHours >= 1)
            {
                if (TIME_PAST_FROM_LAST_UPDATE.TotalHours > 11) // to reward strange and destructiv behavior like sleeping 11h+ or playing games for 11h + 
                {
                    LastChangeCalendar = LastChangeCalendar.Add(TIME_PAST_FROM_LAST_UPDATE);
                    Console.Clear();
                    Console.WriteLine("REMEMBER! IF YOU STUDY YOU WILL PASS, IF YOU NOT YOU WON'T... :) ");
                    Thread.Sleep(2000);
                    for (int i = 0; i < HOURS_PAST_FROM_LAST_UPDATE; i++)
                    {
                        player.ChangeStatisticsCurrentValue(typeof(Food), -rnd.Next(6, 16));
                        player.ChangeStatisticsCurrentValue(typeof(Energy), -rnd.Next(10, 15));
                        player.ChangeStatisticsCurrentValue(typeof(Company), -rnd.Next(4, 5));
                        player.ChangeStatisticsCurrentValue(typeof(Sleep), -rnd.Next(6, 11));
                        if (rnd.Next(100) > 50)
                            player.ChangeStatisticsCurrentValue(typeof(MentalHealth), rnd.Next(0, 18));
                    }

                    foreach (Needmant potentialStatWith0points in player.Statistics)
                    {
                        if (potentialStatWith0points.CurrentValue == 0)
                        {
                            potentialStatWith0points.IfCurrentValueZero();
                        }
                    }

                    if (player.PlayerTime.Calendar >= player.PlayerTime.EndOfSemester)
                    {
                        while (true)
                        {
                            if (player.KnowledgePoints >= 15000)
                            {
                                Console.WriteLine("CONGRATS!!! UDALO CI SIE ZDAC SESJE");
                                Environment.Exit(0);
                            }
                            else
                                Console.WriteLine("NIESTETY NIE UDALO CI SIE ZDAC SESJI");
                            Environment.Exit(0);
                        }
                    }

                    return;
                }

                LastChangeCalendar = LastChangeCalendar.Add(TIME_PAST_FROM_LAST_UPDATE);


                for (int i = 0; i < HOURS_PAST_FROM_LAST_UPDATE; i++)
                {
                    player.ChangeStatisticsCurrentValue(typeof(Food), -rnd.Next(4, 16));
                    player.ChangeStatisticsCurrentValue(typeof(Energy), -rnd.Next(5, 10));
                    player.ChangeStatisticsCurrentValue(typeof(Company), -rnd.Next(1, 5));
                    player.ChangeStatisticsCurrentValue(typeof(Sleep), -rnd.Next(5, 10));
                    if (rnd.Next(100) > 70)
                        player.ChangeStatisticsCurrentValue(typeof(MentalHealth), rnd.Next(-15, 15));
                }
            }

            if(player.PlayerTime.Calendar >= player.PlayerTime.EndOfSemester)
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
        }
    }
}
