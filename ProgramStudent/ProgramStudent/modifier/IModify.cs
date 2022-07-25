using System;
using System.Collections.Generic;

namespace ProgramStudent
{
    public interface IModify
    {
        public string Name { get; set; }
        public DateTime Duration { get; set; }
        public string Description { get; set; }
        public Player player { get; set; }
        public Dictionary<Type, int> TypeModifierDict { get; set; }
        public void Execute();
        public void Undo();
    }
}
