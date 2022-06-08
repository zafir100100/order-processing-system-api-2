using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class FlagForDecode
    {
        public byte? SessionYear { get; set; }
        public byte? MonthId { get; set; }
        public byte? ExamLevel { get; set; }
        public decimal? Flag { get; set; }
    }
}
