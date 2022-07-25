using System;
using System.Collections.Generic;

namespace ProgramStudent
{
    class ChangeStatGainModifier : IModify
    {
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public string Description { get; set; }
        public Player player { get; set; }
        public Dictionary<Type, int> TypeModifierDict { get; set; }

        public ChangeStatGainModifier(Player newPlayer, string name, DateTime duration,
                                      string description, Dictionary<Type, int> typeModifierDict)
        {
            player = newPlayer;
            Description = description;
            Name = name;
            Duration = duration;
            TypeModifierDict = typeModifierDict;
        }

        public void Execute()
        {
            foreach (var item in TypeModifierDict)
            {
                if (item.Key == typeof(Food))
                    player.Statistics[0].Modifier += item.Value;
                else if (item.Key == typeof(Energy))
                    player.Statistics[1].Modifier += item.Value;
                else if (item.Key == typeof(Sleep))
                    player.Statistics[2].Modifier += item.Value;
                else if (item.Key == typeof(Company))
                    player.Statistics[3].Modifier += item.Value;
                else if (item.Key == typeof(MentalHealth))
                    player.Statistics[4].Modifier += item.Value;
            }
        }

        public void Undo()
        {
            foreach (var item in TypeModifierDict)
            {
                if (item.Key == typeof(Food))
                    player.Statistics[0].Modifier -= item.Value;
                else if (item.Key == typeof(Energy))
                    player.Statistics[1].Modifier -= item.Value;
                else if (item.Key == typeof(Sleep))
                    player.Statistics[2].Modifier -= item.Value;
                else if (item.Key == typeof(Company))
                    player.Statistics[3].Modifier -= item.Value;
                else if (item.Key == typeof(MentalHealth))
                    player.Statistics[4].Modifier -= item.Value;
            }
        }
    }
}
