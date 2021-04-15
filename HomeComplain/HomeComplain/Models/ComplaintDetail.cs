using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeComplain.Models
{
    public class ComplaintDetail
    {
        [PrimaryKey, AutoIncrement]
        public int ComplaintID { get; set; }

        [MaxLength(100)]
        public string ComplaintTitle { get; set; }

        [MaxLength(80)]
        public string ComplatintType { get; set; }

        public DateTime ComplaintDate { get; set; }

        [MaxLength(200)]
        public string ComplaintDiscription { get; set; }

        [MaxLength(200)]
        public string ComplaintSolution { get; set; }

        [MaxLength(60)]
        public string ComplaintStatus { get; set; }

        [MaxLength(80)]
        public string Complaintner { get; set; }

        public int UserID { get; set; }
    }
}
