using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStudent
{

    public class UniversityClass
    {
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Presence { get; set; }
        public ClassType ClassType { get; set; }
        public DayOfWeek ClassDayOfWeek { get; set; }
        public UniversityClass(string name, ClassType classType, TimeSpan startTime, TimeSpan endTime, DayOfWeek classDayOfWeek)
        {
            Name = name;
            ClassType = classType;
            EndTime = endTime;
            Presence = false;
            StartTime = startTime;
            ClassDayOfWeek = classDayOfWeek;
        }
    }
}
