using System;
using System.Threading;
namespace ProgramStudent
{
    public class Energy : Needmant
    {
        public Energy()
        {
            MaxValue = 100;
            CurrentValue = 100;
            Name = "Energy";
            Modifier = 0;
            ID = 2;
        }

        override public void Increase(int amount)
        {
            if (CurrentValue + (amount + Modifier) > 100)
                CurrentValue = MaxValue;
            else if (CurrentValue + (amount + Modifier) < 0)
                CurrentValue = 0;
            else
                CurrentValue += amount + Modifier;
        }

        override public void Decrease(int amount)
        {
            if (CurrentValue - amount - Modifier <= 0)
                CurrentValue = 0;
            else
                CurrentValue -= amount - Modifier;
        }

        override public void IfCurrentValueZero()
        {
            if (TokenOfZero == 3)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("This is the end for you here. All this studying is not for you, you are exhausted... [0 Energy]");
                    Console.WriteLine("You can type something if you want but only EXIT is an option");
                    string ans = Console.ReadLine();
                    if (ans == "EXIT")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                if (rnd.Next(100) > 70)
                {
                    Console.Clear();
                    Console.WriteLine("You feel exhausted...");
                    TokenOfZero++;
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
