using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyToothWebApplication.Models
{
    public class DoctorScheduleResponse
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public DoctorScheduleResponse(doctor_schedule schedule)
        {
            ScheduleId = schedule.schedule_id;
            DoctorId = schedule.doctor_id;
            DayOfWeek = schedule.day_of_week;
            StartTime = schedule.start_time;
            EndTime = schedule.end_time;
        }
    }
}