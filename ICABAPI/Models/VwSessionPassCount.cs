using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwSessionPassCount
    {
        public int RegNo { get; set; }
        public int ExamRollno { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int NoSubApp { get; set; }
        public int NoPassSub { get; set; }
        public int NoFailSub { get; set; }
    }
}
