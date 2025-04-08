using HappyToothWebApplication.Models;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/services")]
    public class ServicesController : ApiController
    {
        private readonly HappyToothEntities _context;

        public ServicesController(HappyToothEntities context)
        {
            _context = context;
        }

        // 10. Получить популярные услуги
        [HttpGet]
        [Route("popular/{topCount}")]
        public IHttpActionResult GetPopularServices(int topCount)
        {
            var popularServices = _context.visit_services
                .Join(_context.services,
                    vs => vs.service_id,
                    s => s.service_id,
                    (vs, s) => new { ServiceName = s.name, Quantity = vs.quantity ?? 1 })
                .GroupBy(x => x.ServiceName)
                .OrderByDescending(g => g.Sum(x => x.Quantity))
                .Take(topCount)
                .Select(g => new PopularServiceResponse
                {
                    ServiceName = g.Key,
                    Quantity = g.Sum(x => x.Quantity)
                })
                .ToList();

            return Ok(popularServices);
        }
    }
}