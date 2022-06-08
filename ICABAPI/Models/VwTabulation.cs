using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwTabulation
    {
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? SubId { get; set; }
        public int? BarCode { get; set; }
        public decimal? Marks { get; set; }
        public string Grade { get; set; }
    }
}
