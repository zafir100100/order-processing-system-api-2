using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class TbwebTimeSch
    {
        public int? Ref { get; set; }
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? RefNo { get; set; }
        public byte? SubId { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ExamTime1 { get; set; }
        public string ExamTime2 { get; set; }
        public string SubName { get; set; }
        public byte? MonthId { get; set; }
        public int? ExamLevel { get; set; }
        public byte? SessionYear { get; set; }
    }
}
