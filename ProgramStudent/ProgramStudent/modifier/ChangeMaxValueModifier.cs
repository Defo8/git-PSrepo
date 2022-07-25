using System;
using System.Collections.Generic;

namespace ProgramStudent
{
    class ChangeMaxValueModifier : IModify
    {
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public string Description { get; set; }
        public Player player { get; set; }

        public Dictionary<Type, int> TypeModifierDict { get; set; }

        public ChangeMaxValueModifier(Player newPlayer, string name, DateTime duration, string description, Dictionary<Type, int> typeModfierDict)
        {
            player = newPlayer;
            Description = description;
            Name = name;
            Duration = duration;
            TypeModifierDict = typeModfierDict;
        }

        public void Execute()
        {
            foreach (var item in TypeModifierDict)
            {
                player.ChangeStatisticsMaxValue(item.Key, item.Value);
            }
        }

        public void Undo()
        {
            foreach (var item in TypeModifierDict)
            {
                player.ChangeStatisticsMaxValue(item.Key, 100);

                foreach (Needmant stat in player.Statistics)
                {
                    if (stat.MaxValue > 100)
                        stat.MaxValue = 100;
                }

                /*if (player.food.MaxValue > 100)
                    player.food.MaxValue = 100;
                else if (player.energy.MaxValue > 100)
                    player.energy.MaxValue = 100;
                else if (player.sleep.MaxValue > 100)
                    player.sleep.MaxValue = 100;
                else if (player.sleep.MaxValue > 100)
                    player.sleep.MaxValue = 100;
                else if (player.company.MaxValue > 100)
                    player.company.MaxValue = 100;
                else if (player.mentalHealth.MaxValue > 100)
                    player.mentalHealth.MaxValue = 100;*/
            }
        }
    }
}
