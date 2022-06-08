using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwRollAlloted
    {
        public int? Ref { get; set; }
        public byte? SessionYear { get; set; }
        public byte? MonthId { get; set; }
        public int? ExamLevel { get; set; }
        public string FormNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public byte? StudType { get; set; }
    }
}
