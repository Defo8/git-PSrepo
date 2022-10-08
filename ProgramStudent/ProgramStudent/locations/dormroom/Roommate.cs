using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgramStudent
{
    class Roommate : INPC
    {
        public string Name { get; set; }
        public int FriendPoints { get; set; }

        public Roommate()
        {
            Name = "Adam";
            FriendPoints = 10;
        }

        public FastNote GiveNote()
        {
            Console.WriteLine(" w8 w8 w8.... you know what? You are such a bad, I will give my notes");
            Thread.Sleep(4000);
            return new FastNote("Adam's Notes", 25, 0, 100);
        }

    }
}
