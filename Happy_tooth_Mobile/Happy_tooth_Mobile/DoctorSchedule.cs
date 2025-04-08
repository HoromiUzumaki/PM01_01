using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
    
    public class DoctorSchedule
    {
        [PrimaryKey, AutoIncrement]
        public int ScheduleId { get; set; }

        [ForeignKey(typeof(Doctor))]
        public int DoctorId { get; set; }

        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
