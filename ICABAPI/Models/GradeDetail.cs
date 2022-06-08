using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class GradeDetail
    {
        public int RefNo { get; set; }
        public decimal GradeSl { get; set; }
        public int StartingMarks { get; set; }
        public int EndingMarks { get; set; }
        public string LetterGrade { get; set; }

        // public byte? RefNo { get; set; }
        // public decimal? GradeSl { get; set; }
        // public byte? StartingMarks { get; set; }
        // public byte? EndingMarks { get; set; }
        // public string LetterGrade { get; set; }
    }
}
