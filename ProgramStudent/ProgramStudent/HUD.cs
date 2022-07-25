using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace ProgramStudent
{
    public static class HUD
    {
        public static PlayerBio IntroNewGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string dots = "...";
            string hmm = "\n *gwizdanie* \n *szelest papierow*";

            foreach (char t in dots)
            {
                Thread.Sleep(150);
                Console.Write(t);
            }

            foreach (char t in hmm)
            {
                Thread.Sleep(150);
                Console.Write(t);
            }

            Thread.Sleep(2500);
            Console.WriteLine("\n");

            List<string> texts = new List<string>
            {
                "Oh! HELLO! ",
                "I'm so sorry, I didn't see ypu there...\n",
                "Aaay... We have a lot of work today \n",
                "Are you here to submit documents? \n",
                "GREAT!!!!\n",
                "...\n",
                "Ekhem...\n",
                "If you say so, sit. We have some things to do:\n"
            };

            foreach (string line in texts)
            {
                foreach (char c in line)
                {
                    Thread.Sleep(50);
                    Console.Write(c);
                }

                Thread.Sleep(750);
            }

            PlayerBio playerBio = new PlayerBio();
            Console.Write("NAME: ");
            playerBio.CharacterName = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("SURRNAME: ");
            playerBio.CharacterSurrname = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("PLAE OF BIRTH: ");
            playerBio.City = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("STREET ADRESS: ");
            playerBio.Street = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("PHONE NUMBER: ");

            while (true)
            {                             
                playerBio.PhoneNumber = Console.ReadLine();
                foreach (char c in playerBio.PhoneNumber)
                {
                    if(!char.IsDigit(c))
                    {
                        Console.WriteLine("You must type digits only...");
                        break;
                    }
                    
                }
                if (playerBio.PhoneNumber.Length > 9)
                {
                    Console.WriteLine("Type 9 digits,  no more");
                    Console.WriteLine("");
                    Console.Write("PHONE NUMBER: ");
                }
                else if (playerBio.PhoneNumber.Length < 9)
                {
                    Console.WriteLine("This phone number is too short (9 d`)...");
                    Console.WriteLine("");
                    Console.Write("PHONE NUMBER: ");
                }
                else if (playerBio.PhoneNumber.Length == 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Do you know how phone number looks");
                }
            }
            Console.WriteLine("");
            Console.Write("Email: ");
            playerBio.Email = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("FACULTY: ");
            playerBio.Faculty = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("FIELD OF STUDY: ");
            playerBio.FieldOfstudy = Console.ReadLine();

            playerBio.ShowPlayerBio();

            Console.WriteLine("ARE YOU SURE? YOU WON'T CHANGE IT: YESK/NO \n");
            string ans = Console.ReadLine();

            while (true)
            {
                if (ans == "YES")
                {
                    string text1 = "\nGood to know! " + playerBio.CharacterName + "... Welcom in Colleage!";
                    foreach (char c in text1)
                    {
                        Thread.Sleep(50);
                        Console.Write(c);
                    }
                    Thread.Sleep(750);
                    string initt = "\n[STARTING THE GAME]";
                    foreach (char c in initt)
                    {
                        Thread.Sleep(50);
                        Console.Write(c);
                    }

                    return playerBio;

                    // TUTAJ PRZENIESIENIE DO GRY

                }
                else if (ans == "NIE")
                {
                    Console.WriteLine("Ah... Maybe should you try next time another year...? ");

                    return new PlayerBio();
                }
                else
                {
                    Console.WriteLine("Please... type what they are demanding from you");
                }
            }
        }

        public static void MenuIntro()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            string agh = File.ReadAllText(Game.ART + "agh.txt");

            for (int i = 0; i < 4; i++)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine(agh);
                Console.Title = "WELCOME";
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(agh);
                Console.Title = "TO";
                Console.BackgroundColor = ConsoleColor.Black;
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(agh);
                Console.Title = "PROGRAM";
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine(File.ReadAllText(Game.ART + "agh.txt"));
                Console.Title = "S  .   T   .   U   .   D   .   E   .   N   .   T";
                Thread.Sleep(500);
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }

            Console.ResetColor();
            Console.Clear();
            Thread.Sleep(1500);

            List<string> text = new List<string>
            {
              "Inicjalizacja...",
              "U C Z",
              "S I E",
              "P I L N I E ",
              "S T U D E N C I E",
              " ; )"
            };

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i <= text[j].Length - 1; i++)
                {
                    Thread.Sleep(70);
                    Console.Write(text[j][i]);
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }

                Thread.Sleep(150);
                var position = Console.GetCursorPosition();
                Console.SetCursorPosition(position.Left + 15, position.Top + 10);
            }

            Console.WriteLine(File.ReadAllText(Game.ART + "menu.txt"));
            Console.Title = "PROGRAM:   S  .   T   .   U   .   D   .   E   .   N   .   T  ";
        }
    }
}
