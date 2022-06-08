using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class GradeSysChanged
    {
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public int? RefNo { get; set; }
        public int? SubId { get; set; }
        public string ChangeReason { get; set; }
        public string ChangeUser { get; set; }
        public int? TrackId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string Time { get; set; }
    }
}
