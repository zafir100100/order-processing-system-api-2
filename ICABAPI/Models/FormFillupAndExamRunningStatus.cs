using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class FormFillupAndExamRunningStatus
    {
        public decimal ExamLevel { get; set; }
        public decimal MonthId { get; set; }
        public decimal SessionYear { get; set; }
        public decimal FormFillupStatus { get; set; }
        public decimal ExamRunningStatus { get; set; }
    }
}
