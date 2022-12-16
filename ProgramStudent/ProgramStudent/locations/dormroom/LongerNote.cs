using System;
using System.Threading;

namespace ProgramStudent
{
    public class LongerNote : INote
    {
        public const int LONGERNOTE = 7;
        public string Name { get; set; }
        public int KnowledgeValue { get; set; }
        public int LearnProgress { get; set; }
        public int MakeingProgress { get; set; }

        public LongerNote(string name, int value, int learnTime, int makeTime)
        {
            Name = name;
            KnowledgeValue = value;
            LearnProgress = learnTime;
            MakeingProgress = makeTime;
        }


        public void WorkOnIt(Player player)
        {
            if (MakeingProgress == 100)
            {
                Console.WriteLine("This note is ended");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("How long do you want to work on it?(hours, min 1):");
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
                        Time.Calendar = Time.Calendar.AddHours(h);
                        player.TimeConsequence.UpdateIfNeeded(player);
                        if (MakeingProgress + h * 20 > 100)
                        {
                            MakeingProgress = 100;
                            player.KnowledgePoints += KnowledgeValue;
                        }
                            
                        else
                        {
                            MakeingProgress += h * 20;
                        }
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("You must type the number");
                }

            }
        }

        public void LearnFromIt(Player player)
        {
            if (LearnProgress >= 100)
            {
                Console.WriteLine("You know everthing form this note");
                Thread.Sleep(3000);
                return;
            }
            else if (MakeingProgress != 100)
            {
                Console.WriteLine("This note is not valid to learn from");
                Thread.Sleep(3000);
                return;
            }

            Console.WriteLine("How long do you want to learn from it?(hours, min 1):");
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
                        Time.Calendar = Time.Calendar.AddHours(h);
                        player.TimeConsequence.UpdateIfNeeded(player);
                        player.KnowledgePoints += h * LONGERNOTE;
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("You must type the number");
                }
            }

        }
    }
}
