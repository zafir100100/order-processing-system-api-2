using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwSessionPassCountBack
    {
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public byte? MonthId { get; set; }
        public byte? SessionYear { get; set; }
        public decimal? NoSubApp { get; set; }
        public decimal? NoPassSub { get; set; }
        public decimal? NoFailSub { get; set; }
    }
}
