using HappyToothWebApplication.Models;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/visits")]
    public class VisitsController : ApiController
    {
        private readonly HappyToothEntities _context;

        public VisitsController(HappyToothEntities context)
        {
            _context = context;
        }

        // 4. Получить завершенные визиты пациента
        [HttpGet]
        [Route("patient/{patientId}/completed")]
        public IHttpActionResult GetCompletedVisitsForPatient(int patientId)
        {
            var visits = _context.visits
                .Join(_context.appointments,
                    visit => visit.appointment_id,
                    appointment => appointment.appointment_id,
                    (visit, appointment) => new { Visit = visit, Appointment = appointment })
                .Where(x => x.Appointment.patient_id == patientId)
                .Select(x => new VisitResponse(x.Visit))
                .ToList();

            return Ok(visits);
        }
    }
}