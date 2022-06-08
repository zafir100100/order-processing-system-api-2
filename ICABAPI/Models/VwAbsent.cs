using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwAbsent
    {
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public byte? MonthId { get; set; }
        public byte? SessionYear { get; set; }
        public byte? SubId { get; set; }
    }
}
