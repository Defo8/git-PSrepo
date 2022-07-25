using System;
using System.Threading;
namespace ProgramStudent
{
    public class Sleep : Needmant
    {
        public Sleep()
        {
            MaxValue = 100;
            CurrentValue = 100;
            Name = "Sleep";
            Modifier = 0;
        }

        override public void Increase(int amount)
        {
            if (CurrentValue + amount + Modifier > 100)
                CurrentValue = MaxValue;
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
                    Console.WriteLine("This is the end for you here. All what you want is just sleep... [0 Sleep]");
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
                    Console.WriteLine("You just want to sleep...");
                    TokenOfZero++;
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
