using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
    
    public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

}
