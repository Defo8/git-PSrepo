using System;
using System.Threading;

namespace ProgramStudent
{
    public class MentalHealth : Needmant
    {
        public MentalHealth()
        {
            MaxValue = 100;
            CurrentValue = 100;
            Name = "MentalHealth";
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
                    Console.WriteLine("This is the end for you and your mind. Being paranoic is hard. You see and hear what other don't. You end up in hospital for mental ill [0 Mental Health]");
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
                if (rnd.Next(100) > 30)
                {
                    Console.Clear();
                    Console.WriteLine("Things getting weird...");
                    TokenOfZero++;
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
