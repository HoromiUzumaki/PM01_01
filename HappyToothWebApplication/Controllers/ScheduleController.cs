using HappyToothWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        private readonly HappyToothEntities _context;

        public ScheduleController(HappyToothEntities context)
        {
            _context = context;
        }

        // 7. Получить расписание врача
        [HttpGet]
        [Route("doctor/{doctorId}")]
        public IHttpActionResult GetDoctorSchedule(int doctorId)
        {
            var schedule = _context.doctor_schedule
                .Where(ds => ds.doctor_id == doctorId)
                .OrderBy(ds => ds.day_of_week)
                .Select(ds => new DoctorScheduleResponse(ds))
                .ToList();

            return Ok(schedule);
        }

        // 8. Получить доступные временные слоты
        [HttpGet]
        [Route("doctor/{doctorId}/available-slots")]
        public IHttpActionResult GetAvailableTimeSlots(int doctorId, [FromUri] DateTime date)
        {
            var dayOfWeek = GetRussianDayOfWeek(date.DayOfWeek);

            var schedule = _context.doctor_schedule
                .FirstOrDefault(ds => ds.doctor_id == doctorId && ds.day_of_week == dayOfWeek);

            if (schedule == null)
                return Ok(new List<TimeSlotResponse>());

            var appointments = _context.appointments
                .Where(a => a.doctor_id == doctorId &&
                           DbFunctions.TruncateTime(a.appointment_time) == date.Date &&
                           a.status != "отменен")
                .Select(a => a.appointment_time.TimeOfDay)
                .ToList();

            var availableSlots = new List<TimeSlotResponse>();
            var currentTime = schedule.start_time;
            var endTime = schedule.end_time;

            while (currentTime < endTime)
            {
                if (!appointments.Contains(currentTime))
                {
                    availableSlots.Add(new TimeSlotResponse { Time = currentTime.ToString(@"hh\:mm") });
                }
                currentTime = currentTime.Add(TimeSpan.FromMinutes(30));
            }

            return Ok(availableSlots);
        }

        private string GetRussianDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "пн";
                case DayOfWeek.Tuesday:
                    return "вт";
                case DayOfWeek.Wednesday:
                    return "ср";
                case DayOfWeek.Thursday:
                    return "чт";
                case DayOfWeek.Friday:
                    return "пт";
                case DayOfWeek.Saturday:
                    return "сб";
                case DayOfWeek.Sunday:
                    return "вс";
                default:
                    return ""; 
            }
        }
    }
}