using System;
using System.Threading;

namespace ProgramStudent
{
    public class Company : Needmant
    {
        public Company()
        {
            MaxValue = 100;
            CurrentValue = 100;
            Name = "Company";
            Modifier = 0;
            ID = 4;
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
            if(TokenOfZero == 3)
            {
                while(true)
                {
                    Console.Clear();
                    Console.WriteLine("This is the end for you and your lonely soul. All this studying is not for you, you feel to lonley... [0 Company]");
                    Console.WriteLine("You can type something if you want but only EXIT is an option");
                    string ans = Console.ReadLine();
                    if(ans == "EXIT")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Random rnd = new Random();
                if (rnd.Next(100) > 90)
                {                   
                    Console.Clear();
                    Console.WriteLine("You just feel too lonley...");
                    TokenOfZero++;
                    Thread.Sleep(2000);
                }
 
            }
        }
    }
}
