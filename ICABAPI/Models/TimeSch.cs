using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class TimeSch
    {
        public int? RefNo { get; set; }
        public byte? SubId { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ExamTime1 { get; set; }
        public string ExamTime2 { get; set; }
        public string SubName { get; set; }
        public byte? MonthId { get; set; }
        public byte? ExamLevel { get; set; }
        public byte? SessionYear { get; set; }
    }
}
