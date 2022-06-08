using System;
using System.Collections.Generic;


namespace ICABAPI.Models
{
    public partial class ResultLock
    {
        public int ExamLevel { get; set; }
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int RLock { get; set; }
        public string Entryuser { get; set; }

        // public int? ExamLevel { get; set; }
        // public byte? SessionYear { get; set; }
        // public byte? MonthId { get; set; }
        // public bool? RLock { get; set; }
        // public string Entryuser { get; set; }
    }
}
