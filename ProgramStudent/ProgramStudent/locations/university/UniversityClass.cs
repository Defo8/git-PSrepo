using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStudent.locations.university
{

    class UniversityClass
    {
        public static readonly TimeSpan TIMEOFRECITATION = new TimeSpan(1, 30, 0);
        public static readonly TimeSpan TIMEOFLECTURE = new TimeSpan(1, 30, 0);

        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public bool Presence { get; set; }
        public UniversityClass(string name, TimeSpan duration, bool presence)
        {
            Name = name;
            Duration = duration;
            Presence = presence;
        }

    }
}
