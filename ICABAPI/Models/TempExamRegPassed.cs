﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class TempExamRegPassed
    {
        public int? ExamSl { get; set; }
        public int? RefNo { get; set; }
        public int? StuRegNo { get; set; }
        public string ExamNamePassed { get; set; }
        public int? RollnoPassed { get; set; }
        public string SessionPassed { get; set; }
        public string ExamcenPassed { get; set; }
        public int? SessionYear { get; set; }
    }
}
