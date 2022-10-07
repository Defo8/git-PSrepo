using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using System.Linq;

namespace ProgramStudent
{
    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    class Game
    {
        public static string ART;
        public static string SAVE;

        public bool IsSaveLoaded { get; set; }
        public bool PasToMainMenu { get; set; }
        public Player player { get; set; }
        //public List<ILocation> Locations { get; set; }
        public Game()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            ART = projectDirectory + @"\resources\ASCII\";
            SAVE = projectDirectory + @"\saves\";
            IsSaveLoaded = false;
            player = new Player(); // DWA RAZY PRZYPISUJE
        }
        public void SaveGame()
        {
            Console.WriteLine("Name for save:");
            string name = Console.ReadLine();

            var option = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var Playerjson = JsonConvert.SerializeObject(player, option);
            File.WriteAllText(SAVE + name + ".json", Playerjson);
            Console.WriteLine("SUCESS!!!");
            Thread.Sleep(3000);
        }

        public void LoadGame()
        {

            DirectoryInfo d = new DirectoryInfo(SAVE); 

            FileInfo[] Files = d.GetFiles("*.json"); 

            Console.Clear();

            Console.WriteLine("Your saves: ");

            foreach (FileInfo file in Files)
            {
                Console.WriteLine(file.Name);
            }

            Console.WriteLine("\n Which of them do you want to load?: ");
            string ans = Console.ReadLine();
            var option = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            try
            {
                string json = File.ReadAllText(SAVE + ans); 
                
                player = JsonConvert.DeserializeObject<Player>(json, option);
               
                Console.WriteLine("LOADING SAVE SUCCESS");
                IsSaveLoaded = true;
                Thread.Sleep(1500);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ekhem... There is no file like this, try again: " + e.Message);
                Thread.Sleep(5000);
            }
        }

        public void Credits()
        {
            Console.WriteLine("Game made by: Rafal Brzoza");
            Thread.Sleep(3000);
        }

        public void Quit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to leave?");
            Console.WriteLine("YES OR NO");
            string ans = Console.ReadLine();
            while (true)
            {
                if (ans == "YES")
                {
                    Environment.Exit(0);
                }
                else if (ans == "NO")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Type YES if you want to leave and NO if you want to stay... Damn...");
                    ans = Console.ReadLine();
                }
            }
        }

        public void StartNewGame()
        {
            Console.Clear();
            //PlayerBio bio = HUD.IntroNewGame();
            //player.PlayerInfo = bio;
            //IsSaveLoaded = true;
        
            StartGame();
        }

        public void StartGame()
        {
            if(IsSaveLoaded == false)
            {
                Console.Clear();
                //PlayerBio bio = HUD.IntroNewGame(); //temporary off
                //player.PlayerInfo = bio;
                IsSaveLoaded = true;
                player.Locations[0].Hub(player);
            }
            else
            {
          
                player.Locations[0].Hub(player);
            }
                        
        }

        public void Menu()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                Console.WriteLine(File.ReadAllText(ART + "menu.txt"));
                Console.Title = "PROGRAM:   S  .   T   .   U   .   D   .   E   .   N   .   T";
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "What you want hmm...? - , - : START NEW GAME, CONTINUE, SAVE GAME, LOAD GAME, CREDITS, QUIT: "));
                Console.WriteLine();
                string ans = Console.ReadLine();
                switch (ans)
                {
                    case "START NEW GAME":
                        StartNewGame();
                        break;
                    case "CONTINUE":
                        StartGame();
                        break;
                    case "SAVE GAME":
                        SaveGame();
                        //Menu();
                        break;
                    case "LOAD GAME":                      
                        LoadGame();
                        break;
                    case "CREDITS":
                        Credits();
                        break;
                    case "QUIT":
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Type upper-case: START NEW GAME or SAVE GAME or START or LOAD GAME or CREDITS or QUIT! >: /");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        public void StartEvent()
        {

        }

        public void ExamSeason()
        {

        }
    }
}
