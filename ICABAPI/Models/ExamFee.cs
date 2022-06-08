using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ExamFee
    {
        public decimal Id { get; set; }
        public decimal ExamLevel { get; set; }
        public decimal SubId { get; set; }
        public decimal MonthId { get; set; }
        public decimal SessionYear { get; set; }
        public decimal? Amount { get; set; }
    }
}
