using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Happy_tooth_Mobile
{
   
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
