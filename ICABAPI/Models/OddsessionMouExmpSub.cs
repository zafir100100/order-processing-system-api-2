using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class OddsessionMouExmpSub
    {
        public byte? StudType { get; set; }
        public int? ExamLevel { get; set; }
        public byte? ExamSession { get; set; }
        public byte? ExamYear { get; set; }
        public int? RegNo { get; set; }
        public int? ExmptSubid { get; set; }
        public byte? Calendermonthid { get; set; }
        public string Calendermonth { get; set; }
        public byte? SubId { get; set; }
        public string SubName { get; set; }
        public bool? Status { get; set; }
    }
}
