using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Barseq
    {
        public int Id { get; set; }
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public int? ExamLevel { get; set; }
        public int? Scriptqty { get; set; }
        public int? Barfrom { get; set; }
        public int? Barto { get; set; }
    }
}
