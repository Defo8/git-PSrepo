using System;
using System.Threading;
namespace ProgramStudent
{
    public class Food : Needmant
    {
        public Food()
        {
            MaxValue = 100;
            CurrentValue = 100;
            Name = "Food";
            Modifier = 0;
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
            if (TokenOfZero == 7)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("This is the end for you. You did not eat for too long so you end up in hospital for 2 months [0 Food]");
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
                if (rnd.Next(100) > 60)
                {
                    Console.Clear();
                    Console.WriteLine("You are really hungry...");
                    TokenOfZero++;
                    Thread.Sleep(2000);
                }
            }
        }
    }
}
