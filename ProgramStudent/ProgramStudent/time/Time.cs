using System;

namespace ProgramStudent
{
    public class Time
    {
        public DateTime Calendar { get; set; }
        public DateTime EndOfSemester { get; set; }
        public Time()
        {
            Calendar = new DateTime(2054, 10, 1, 9, 00, 00);
            EndOfSemester = new DateTime(2055, 1, 14, 16, 00, 00);
        }
        public TimeSpan CurrentTime()
        {
            return Calendar.TimeOfDay;
        }
        public TimeSpan HowFarToExams()
        {
            return EndOfSemester - Calendar;
        }       
    }
}
