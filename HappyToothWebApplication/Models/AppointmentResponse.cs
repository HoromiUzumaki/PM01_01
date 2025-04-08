using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyToothWebApplication.Models
{
    public class AppointmentResponse
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }

        public AppointmentResponse(appointments appointment)
        {
            AppointmentId = appointment.appointment_id;
            PatientId = appointment.patient_id;
            DoctorId = appointment.doctor_id;
            AppointmentTime = appointment.appointment_time;
            Status = appointment.status;
        }
    }
}