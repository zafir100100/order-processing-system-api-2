using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StudentExpelled
    {
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        //public int? ExamcenId { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public int? SessionFrom { get; set; }
        public int? SessionTo { get; set; }
        public string Reason { get; set; }
        public string Entryuser { get; set; }
        public string Status { get; set; }
        //public int? Rollno { get; set; }
        //public int? ExamYear { get; set; }
        //public int? MonthId { get; set; }
        public DateTime? ExpulsionDate { get; set; }
        public DateTime? WithdrawnDate { get; set; }
    }
}
