using System;
using System.Collections.Generic;

namespace ProgramStudent
{
    public enum ClassT
    {
        Lecture,
        Recitation,
        Labolatory
    }

    public class Timetable
    {
        public static readonly TimeSpan TIMEOFRECITATION = new TimeSpan(1, 30, 0);
        public static readonly TimeSpan TIMEOFLECTURE = new TimeSpan(1, 30, 0);
        public List<List<UniversityClass>> Table { get; set; }

        public Timetable()
        {
            Table = CreatTimetable();
        }
        
        public List<List<UniversityClass>> CreatTimetable()
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

            return timeTable;
        }

        public void ShowTimetable()
        {
            Console.WriteLine("Monday");
            foreach(UniversityClass clas in Table[0])
            {
                Console.WriteLine(clas.Name + ", " + clas.StartTime);
            }
            Console.WriteLine();

            Console.WriteLine("Tuesday");
            foreach (UniversityClass clas in Table[1])
            {
                Console.WriteLine(clas.Name + ", " + clas.StartTime);
            }
            Console.WriteLine();

            Console.WriteLine("Wensday");
            foreach (UniversityClass clas in Table[2])
            {
                Console.WriteLine(clas.Name + ", " + clas.StartTime);
            }
            Console.WriteLine();

            Console.WriteLine("Thursday");
            foreach (UniversityClass clas in Table[3])
            {
                Console.WriteLine(clas.Name + ", " + clas.StartTime);
            }
            Console.WriteLine();

            Console.WriteLine("Friday");
            foreach (UniversityClass clas in Table[4])
            {
                Console.WriteLine(clas.Name + ", " + clas.StartTime);
            }
        }
        
    }
}
