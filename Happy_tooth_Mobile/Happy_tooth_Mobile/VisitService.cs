using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
   
    public class VisitService
    {
        [ForeignKey(typeof(Visit))]
        public int VisitId { get; set; }

        [ForeignKey(typeof(Service))]
        public int ServiceId { get; set; }

        public int Quantity { get; set; }
    }

}
