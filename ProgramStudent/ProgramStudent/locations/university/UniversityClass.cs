using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStudent.locations.university
{

    class UniversityClass
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Presence { get; set; }
        public ClassT ClassType { get; set; }
        public UniversityClass(string name, TimeSpan duration, ClassT classType, TimeSpan startTime)
        {
            Name = name;
            ClassType = classType;
            Duration = duration;
            Presence = false;
            StartTime = startTime;
        }
    }
}
