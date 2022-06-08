using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ConversionCourseMark
    {
        public int? StudentSlno { get; set; }
        public int? BatchNo { get; set; }
        public int? MarksSlno { get; set; }
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public int? SubId { get; set; }
        public int? SessionYear { get; set; }
        public int? Rollno { get; set; }
        public string Classsession { get; set; }
        public int? ExamcenId { get; set; }
        public string Entryuser { get; set; }
        public string Reason { get; set; }
    }
}
