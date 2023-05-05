using System;
using System.Collections.Generic;

namespace ProgramStudent
{
    public enum ClassType
    {
        Lecture,
        Recitation,
        Labolatory
    }

    public class Timetable
    {
        public List<List<UniversityClass>> Table { get; set; }

        public Timetable()
        {
            Table = CreatTimetable();
        }
        
        private List<List<UniversityClass>> CreatTimetable()
        {
            List<UniversityClass> Monday = new List<UniversityClass>()
            {
                new UniversityClass("Construction Record", ClassType.Lecture, new TimeSpan(8, 0, 0), new TimeSpan(9, 30, 0), DayOfWeek.Monday),
                new UniversityClass("Technics of production", ClassType.Lecture, new TimeSpan(9, 45, 0), new TimeSpan(11, 15, 0), DayOfWeek.Monday),
                new UniversityClass("Technics of IT", ClassType.Lecture, new TimeSpan(11, 30, 0), new TimeSpan(13, 0, 0), DayOfWeek.Monday),
                new UniversityClass("Physic 1",  ClassType.Lecture, new TimeSpan(13, 15, 0), new TimeSpan(14, 45, 0), DayOfWeek.Monday),
            };

            List<UniversityClass> Tuesday = new List<UniversityClass>()
            {   
                new UniversityClass("Math 1", ClassType.Lecture, new TimeSpan(10, 0, 0), new TimeSpan(11, 30, 0), DayOfWeek.Tuesday),
                new UniversityClass("Chemistry", ClassType.Lecture, new TimeSpan(11, 45, 0), new TimeSpan(13, 15, 0), DayOfWeek.Tuesday),
                new UniversityClass("Physic 1", ClassType.Recitation, new TimeSpan(14, 30, 0), new TimeSpan(16, 0, 0), DayOfWeek.Tuesday),
            };

            List<UniversityClass> Wednesday = new List<UniversityClass>()
            {
                new UniversityClass("Construction Record", ClassType.Recitation, new TimeSpan(8, 0, 0), new TimeSpan(9, 30, 0), DayOfWeek.Wednesday),
                new UniversityClass("Chemistry", ClassType.Recitation, new TimeSpan(13, 0, 0), new TimeSpan(14, 30, 0), DayOfWeek.Wednesday),
                new UniversityClass("Math 1", ClassType.Recitation, new TimeSpan(17, 30, 0), new TimeSpan(19, 0, 0), DayOfWeek.Wednesday)
            };

            List<UniversityClass> Thursday = new List<UniversityClass>()
            {
                new UniversityClass("Technics of IT", ClassType.Recitation, new TimeSpan(9, 0, 0), new TimeSpan(10, 30, 0), DayOfWeek.Thursday),
            };

            List<UniversityClass> Friday = new List<UniversityClass>()
            {
                new UniversityClass("Technics of production", ClassType.Recitation, new TimeSpan(9, 30, 0), new TimeSpan(11, 0, 0), DayOfWeek.Friday),
            };

            List<List<UniversityClass>> timeTable = new List<List<UniversityClass>>()
            {
                Monday,
                Tuesday,
                Wednesday,
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
