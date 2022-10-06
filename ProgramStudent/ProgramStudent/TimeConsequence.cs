using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    public class TimeConsequence : Time
    {
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
            TimeSpan Houer = new DateTime(1, 1, 1, 1, 0, 0) - new DateTime(1, 1, 1, 0, 0, 0);
            TimeSpan ourDiffrence = player.Time.Calendar - player.TimeConsequence.LastChangeCalendar;
            double rr = Math.Floor(ourDiffrence.TotalHours);
            Random rnd = new Random();
            if (ourDiffrence >= Houer)
            {
                if (ourDiffrence.TotalHours > 14)
                {
                    LastChangeCalendar = LastChangeCalendar.Add(ourDiffrence);
                    Console.Clear();
                    Console.WriteLine("REMEMBER! IF YOU STUDY YOU WILL PASS, IF YOU NOT YOU WON'T... :) ");
                    Thread.Sleep(2000);
                    for (int i = 0; i < rr/2; i++)
                    {
                        player.ChangeStatisticsCurrentValue(typeof(Food), -rnd.Next(9));
                        player.ChangeStatisticsCurrentValue(typeof(Energy), -rnd.Next(9));
                        player.ChangeStatisticsCurrentValue(typeof(Company), -rnd.Next(9));
                        player.ChangeStatisticsCurrentValue(typeof(Sleep), -rnd.Next(9));
                        if (rnd.Next(100) > 70)
                            player.ChangeStatisticsCurrentValue(typeof(MentalHealth), -rnd.Next(4));
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


                for (int i = 0; i < rr/2; i++)
                {
                    player.Statistics[0].Decrease(rnd.Next(15));
                    player.Statistics[1].Decrease(rnd.Next(15));
                    player.Statistics[2].Decrease(rnd.Next(15));
                    player.Statistics[3].Decrease(rnd.Next(8));
                    if (rnd.Next(100) > 70)
                        player.Statistics[4].Decrease(3);
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
