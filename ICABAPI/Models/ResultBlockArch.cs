using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ResultBlockArch
    {
        public int? RegNo { get; set; }
        public int? Rollno { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public DateTime? BlockDate { get; set; }
        public string Reason { get; set; }
        public string Entryuser { get; set; }
        public DateTime? BackDate { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string BackReason { get; set; }
        public string Entryuserb { get; set; }
    }
}
