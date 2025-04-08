using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
   
    public class Patient
    {
        [PrimaryKey, AutoIncrement]
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey(typeof(User))]
        public int UserId { get; set; }
    }
}
