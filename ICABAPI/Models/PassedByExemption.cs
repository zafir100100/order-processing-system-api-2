using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class PassedByExemption
    {
        public byte? StudType { get; set; }
        public int? ExamLevel { get; set; }
        public byte? ExamSession { get; set; }
        public byte? ExamYear { get; set; }
        public int? RegNo { get; set; }
        public int? ExmptSubid { get; set; }
        public int? ExamRollno { get; set; }
    }
}
