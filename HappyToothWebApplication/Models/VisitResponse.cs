using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyToothWebApplication.Models
{
    public class VisitResponse
    {
        public int VisitId { get; set; }
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public decimal TotalPrice { get; set; }

        public VisitResponse(visits visit)
        {
            VisitId = visit.visit_id;
            AppointmentId = visit.appointment_id;
            Diagnosis = visit.diagnosis;
            Treatment = visit.treatment;
            TotalPrice = visit.total_price ?? 0;
        }
    }
}