using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
    
    public class Visit
    {
        [PrimaryKey, AutoIncrement]
        public int VisitId { get; set; }

        [ForeignKey(typeof(Appointment))]
        public int AppointmentId { get; set; }

        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public decimal TotalPrice { get; set; }
        
        [ManyToOne]
        public Appointment Appointment { get; set; }
    }

}
