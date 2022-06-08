using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuCancel
    {
        public int? RegNo { get; set; }
        public DateTime? CancellationDate { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        //public int? ExamRollno { get; set; }
        public int? CwFlag { get; set; }
        public string CwReason { get; set; }
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public DateTime? Periodfrom { get; set; }
        public DateTime? Periodto { get; set; }
        public int? Id { get; set; }

    }
}
