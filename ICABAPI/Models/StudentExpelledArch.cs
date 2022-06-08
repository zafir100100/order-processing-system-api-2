using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StudentExpelledArch
    {
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public byte? SessionFrom { get; set; }
        public byte? ExamcenId { get; set; }
        public string YearFrom { get; set; }
        public string YearTo { get; set; }
        public byte? SessionTo { get; set; }
        public string Reason { get; set; }
        public string Entryuser { get; set; }
        public string Status { get; set; }
        public int? Rollno { get; set; }
        public byte? ExamYear { get; set; }
        public byte? MonthId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string EditDelete { get; set; }
    }
}
