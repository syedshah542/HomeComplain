using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeComplain.Models
{
    public class UserDetail
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(80)]
        public string EmailId { get; set; }

        [MaxLength(40)]
        public string Password { get; set; }

        [MaxLength(40)]
        public string Contact { get; set; }

        public bool IsAdmin { get; set; }
    }
}
