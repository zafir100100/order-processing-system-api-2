using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Decodelog
    {
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public int? ExamLevel { get; set; }
        public string Decoder { get; set; }
        public DateTime? Ddate { get; set; }
        public string Dtime { get; set; }
        public string UserId { get; set; }
        public string Decoder2nd { get; set; }
    }
}
