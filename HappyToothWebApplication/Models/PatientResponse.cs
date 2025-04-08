using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyToothWebApplication.Models
{
    public class PatientResponse
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? UserId { get; set; }

        public PatientResponse(patients patient)
        {
            PatientId = patient.patient_id;
            FullName = patient.full_name;
            Phone = patient.phone;
            Email = patient.email;
            BirthDate = patient.birth_date;
            UserId = patient.user_id;
        }
    }
}