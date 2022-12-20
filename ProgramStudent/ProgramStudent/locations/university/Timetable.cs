using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramStudent.locations.university
{
    enum ClassT
    {
        Lecture,
        Recitation,
        Labolatory
    }

    class Timetable
    {
        public static readonly TimeSpan TIMEOFRECITATION = new TimeSpan(1, 30, 0);
        public static readonly TimeSpan TIMEOFLECTURE = new TimeSpan(1, 30, 0);
        public List<List<UniversityClass>> Table { get; set; }
        
        public void CreatTimetable()
        {
            List<UniversityClass> Monday = new List<UniversityClass>()
            {
                new UniversityClass("Construction Record", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(8, 0, 0)),
                new UniversityClass("Technics of production", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(9, 45, 0)),
                new UniversityClass("Technics of IT", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(11, 30, 0)),
                new UniversityClass("Physic 1", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(13, 15, 0)),
            };

            List<UniversityClass> Tuesday = new List<UniversityClass>()
            {   
                new UniversityClass("Math 1", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(10, 0, 0)),
                new UniversityClass("Chemistry", TIMEOFLECTURE, ClassT.Lecture, new TimeSpan(11, 45, 0)),
                new UniversityClass("Physic 1", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(14, 30, 0)),
            };

            List<UniversityClass> Wensday = new List<UniversityClass>()
            {
                new UniversityClass("Construction Record", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(8, 0, 0)),
                new UniversityClass("Chemistry", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(13, 0, 0)),
                new UniversityClass("Math 1", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(17, 30, 0)),
            };

            List<UniversityClass> Thursday = new List<UniversityClass>()
            {
                new UniversityClass("Technics of IT", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(9, 0, 0)),
            };

            List<UniversityClass> Friday = new List<UniversityClass>()
            {
                new UniversityClass("Technics of production", TIMEOFRECITATION, ClassT.Recitation, new TimeSpan(9, 30, 0)),
            };

            List<List<UniversityClass>> timeTable = new List<List<UniversityClass>>()
            {
                Monday,
                Tuesday,
                Wensday,
                Thursday,
                Friday
            };

            Table = timeTable;
        }
        
    }
}
