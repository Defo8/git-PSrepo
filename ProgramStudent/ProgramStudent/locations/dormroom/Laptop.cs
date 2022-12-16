using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace ProgramStudent
{
    public class Laptop
    {
        public const int PREPARE = 5;
        public bool IsOperable { get; set; }
        public List<INote> NoteList { get; set; }
        public Laptop()
        {
            IsOperable = true;
            NoteList = new List<INote>();
        }
        public void LaptopHub(Player player)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(File.ReadAllText(Game.ART + "laptop.txt"));
                Console.WriteLine("");
                Console.WriteLine("Calendary: " + Time.Calendar);
                Console.WriteLine("== Dorm: Laptop ==");
                Console.WriteLine("1. Talk with someone on PresentBook");
                Console.WriteLine("2. Play games");
                Console.WriteLine("3. Prepare fo classes");
                Console.WriteLine("4. Start new note");
                Console.WriteLine("5. Display all notes");
                Console.WriteLine("0. Back");
                Console.WriteLine("\nSTATS:");
                player.ShowPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Choose what you want to do(numer): ");
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "1":
                        TalkWithBuddy(player);
                        break;
                    case "2":
                        PlayGames(player);
                        break;
                    case "3":
                        PrepareForClasses(player);
                        break;
                    case "4":
                        StartNewNote(player);
                        break;
                    case "5":
                        DisplayAllNotes();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Type a propriet number bruh...");
                        break;

                }
            }
        }
        public void StartNewNote(Player player)
        {
            Console.WriteLine("Type a name for this note");
            string name = Console.ReadLine();
            NotesFactory factory = new NotesFactory();
            NoteList.Add(factory.MakeNote(name));

            Random rnd = new Random();
            Roommate roommate = new Roommate();

            NoteList.Add(roommate.GiveNote());
        }

        public void DisplayAllNotes()
        {
            foreach(INote note in NoteList)
            {
                Console.WriteLine(note.Name+", Making progress: "+note.MakeingProgress+", Learn points: "+note.LearnProgress);
            }
            Console.ReadKey();
        }

        public void PrepareForClasses(Player player)
        {
            Console.WriteLine("How long do you want to prepare?(hours, min 1):");
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
                        player.KnowledgePoints += h * PREPARE;
                        string wrtie = "*Learning...";
                        foreach (char t in wrtie)
                        {
                            Console.Write(t);
                            Thread.Sleep(300);
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

        public void TalkWithBuddy(Player player)
        {
            Console.Clear();

            string chat = "*Chat, Chat, Chat...";
            foreach (char t in chat)
            {
                Console.Write(t);
                Thread.Sleep(20);
            }
            Time.Calendar = Time.Calendar.AddMinutes(15);
            player.TimeConsequence.UpdateIfNeeded(player);
            player.ChangeStatisticsCurrentValue(typeof(Company), 5);
            player.ChangeStatisticsCurrentValue(typeof(MentalHealth), 3);
        }

        public void PlayGames(Player player)
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("How long do you want to play? (minimum 1 h):");
                int time;

                while (true)
                {
                    try
                    {
                        time = Int32.Parse(Console.ReadLine());
                        if (time < 0)
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


                //if czy time < 1;
                Time.Calendar = Time.Calendar.AddHours(time);
                player.TimeConsequence.UpdateIfNeeded(player);
                player.ChangeStatisticsCurrentValue(typeof(Company), 5 * time);
                player.ChangeStatisticsCurrentValue(typeof(MentalHealth), 3 * time);

                string chat = "*Playing...";
                foreach (char t in chat)
                {
                    Console.Write(t);
                    Thread.Sleep(20);
                }
                break;
            }
        }
    }
}
