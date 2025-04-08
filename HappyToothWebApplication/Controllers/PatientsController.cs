using HappyToothWebApplication.Models;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/patients")]
    public class PatientsController : ApiController
    {
        private readonly HappyToothEntities _context;

        public PatientsController(HappyToothEntities context)
        {
            _context = context;
        }

        // 9. Получить пациентов по году рождения
        [HttpGet]
        [Route("by-birth-year/{year}")]
        public IHttpActionResult GetPatientsByBirthYear(int year)
        {
            var patients = _context.patients
                .Where(p => p.birth_date.HasValue && p.birth_date.Value.Year == year)
                .OrderBy(p => p.birth_date)
                .Select(p => new PatientResponse(p))
                .ToList();

            return Ok(patients);
        }
    }
}