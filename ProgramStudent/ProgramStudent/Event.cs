using System;

namespace ProgramStudent
{
    public class  Event 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IModify EventModifier { get; set; }

        public Event(string name, string description, IModify eventMod)
        {
            Name = name;
            Description = description;
            EventModifier = eventMod;
        }

        public void Occur(Player player)
        {
            Console.Clear();
            Console.WriteLine("== " + Name + " ==");
            Console.WriteLine(Description);

            foreach (var item in EventModifier.TypeModifierDict)
            {
                Console.WriteLine(item.Key.Name + ": " + item.Value);
            }

            player.AddModifier(EventModifier);
            player.CheckForModifier();
            Console.ReadKey();


        }
    }
}
