using HappyToothWebApplication.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        private readonly HappyToothEntities _context;

        public AppointmentsController(HappyToothEntities context)
        {
            _context = context;
        }

        // 1. Получить все записи для конкретного пациента
        [HttpGet]
        [Route("patient/{patientId}")]
        public IHttpActionResult GetAppointmentsForPatient(int patientId)
        {
            var appointments = _context.appointments
                .Where(a => a.patient_id == patientId)
                .OrderBy(a => a.appointment_time)
                .Select(a => new AppointmentResponse(a))
                .ToList();

            return Ok(appointments);
        }

        // 2. Получить все записи для конкретного врача
        [HttpGet]
        [Route("doctor/{doctorId}")]
        public IHttpActionResult GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = _context.appointments
                .Where(a => a.doctor_id == doctorId)
                .OrderBy(a => a.appointment_time)
                .Select(a => new AppointmentResponse(a))
                .ToList();

            return Ok(appointments);
        }

        // 3. Получить предстоящие записи
        [HttpGet]
        [Route("upcoming")]
        public IHttpActionResult GetUpcomingAppointments()
        {
            var appointments = _context.appointments
                .Where(a => a.appointment_time > DateTime.Now && a.status == "запланирован")
                .OrderBy(a => a.appointment_time)
                .Select(a => new AppointmentResponse(a))
                .ToList();

            return Ok(appointments);
        }
    }
}