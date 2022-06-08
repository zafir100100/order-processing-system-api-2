using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ResultBlock
    {
        [Key]

       

        public int Id { get; set; }
        public int? RegNo { get; set; }
        public int? Rollno { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public DateTime? BlockDate { get; set; }
        public string Reason { get; set; }
        public string Entryuser { get; set; }
        public string Status { get; set; }

    }
}
