using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class VwUnsuccessList
    {
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public byte? SessionYear { get; set; }
        public byte? MonthId { get; set; }
        public long? BarCode { get; set; }
        public int? SubId { get; set; }
        public decimal? Marks { get; set; }
        public decimal? Outmarks { get; set; }
        public string Grade { get; set; }
        public short? Examiner { get; set; }
        public short? Scriptsl { get; set; }
    }
}
