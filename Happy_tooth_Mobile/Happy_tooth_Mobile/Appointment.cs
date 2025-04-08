using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
   
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int AppointmentId { get; set; }

        [ForeignKey(typeof(Patient))]
        public int PatientId { get; set; }

        [ForeignKey(typeof(Doctor))]
        public int DoctorId { get; set; }

        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }
    }
}
