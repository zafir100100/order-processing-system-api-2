using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class GradeSy
    {
        public int ExamLevel { get; set; }
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int RefNo { get; set; }
        public int SubId { get; set; }

        // public int? ExamLevel { get; set; }
        // public byte? SessionYear { get; set; }
        // public byte? MonthId { get; set; }
        // public byte? RefNo { get; set; }
        // public byte? SubId { get; set; }
    }
}
