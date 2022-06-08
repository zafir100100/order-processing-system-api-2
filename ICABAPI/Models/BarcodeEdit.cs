using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class BarcodeEdit
    {
        public int Id { get; set; }
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? SubId { get; set; }
        public int? MonthId { get; set; }
        public int? BarCode { get; set; }
        public int? UdSlno { get; set; }
        public string UserId { get; set; }
        public DateTime? Editdate { get; set; }
        public string Edittime { get; set; }
        public string Userid1 { get; set; }
        public int? Editpart { get; set; }
        public string EditDelete { get; set; }
        public string PcInfo { get; set; }
    }
}
