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

        public Course(string name, string descript, int kp, int presenceExept, DateTime startTime, double length)
        {
            Name = name;
            Description = descript;
            KP = kp;
            Presence = false;
            PresenceExeptionPoints = presenceExept;
            StartTime = startTime;
            Length = length;
        }

        public void SetPresence(bool isPresent)
        {
            if (isPresent)
                Presence = true;
            else
                Presence = false;
        }
    }
}
