using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStudent
{
    class Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int KP { get; set; }
        public bool Presence { get; set; }
        public int PresenceExeptionPoints { get; set; }
        public DateTime StartTime { get; set; }
        public double Length { get; set; }
    }
}
