using System;

namespace ProgramStudent
{
    public class NotesFactory
    {
        public INote MakeNote(string name)
        {
            Console.WriteLine("What note do you want to make? : ");
            Console.WriteLine("Longer");
            Console.WriteLine("Faster");
            string ans = Console.ReadLine();
            while(true)
            {
                if (ans == "Longer")
                    return MakeLongerNote(name);
                else if (ans == "Faster")
                    return MakeFastNote(name);
                else
                    Console.WriteLine("Pick beetween Faster or Longer");
            }
            

        }

        public FastNote MakeFastNote(string name)
        {
            return new FastNote(name, 30, 0, 100);
        }

        public LongerNote MakeLongerNote(string name)
        {
            return new LongerNote(name, 70, 0, 000);
        }
    }
}
