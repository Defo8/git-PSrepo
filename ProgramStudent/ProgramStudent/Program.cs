using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;

namespace ProgramStudent
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;  
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);        
            
            Game game = new Game();

            DateTime date1 = new DateTime(2055, 10, 1);
            DateTime date2 = new DateTime(2056, 1, 28);
            TimeSpan s = date1 - date2;
            Console.WriteLine(s);
            Console.ReadKey();

            //HUD.MenuIntro();
            game.Menu();

        }
    }   
}
