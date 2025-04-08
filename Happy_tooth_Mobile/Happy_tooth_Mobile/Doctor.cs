using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
   
    public class Doctor
    {
        [PrimaryKey, AutoIncrement]
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }

        [ForeignKey(typeof(User))]
        public int? UserId { get; set; }
    }
}
