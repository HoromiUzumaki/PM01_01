using HappyToothWebApplication.Models;
using System.Linq;
using System.Web.Http;

namespace HappyToothWebApplication.Controllers
{
    [RoutePrefix("api/revenue")]
    public class RevenueController : ApiController
    {
        private readonly HappyToothEntities _context;

        public RevenueController(HappyToothEntities context)
        {
            _context = context;
        }

        // 5. Расчет общего дохода
        [HttpGet]
        [Route("total")]
        public IHttpActionResult CalculateTotalRevenue()
        {
            var totalRevenue = _context.visits.Sum(v => v.total_price ?? 0);
            return Ok(new { TotalRevenue = totalRevenue });
        }

        // 6. Расчет дохода по типам услуг
        [HttpGet]
        [Route("by-service")]
        public IHttpActionResult CalculateRevenueByService()
        {
            var revenueByService = _context.visit_services
                .Join(_context.services,
                    vs => vs.service_id,
                    s => s.service_id,
                    (vs, s) => new { ServiceName = s.name, Revenue = s.price * (vs.quantity ?? 1) })
                .GroupBy(x => x.ServiceName)
                .Select(g => new RevenueByServiceResponse
                {
                    ServiceName = g.Key,
                    Revenue = g.Sum(x => x.Revenue)
                })
                .ToList();

            return Ok(revenueByService);
        }
    }
}