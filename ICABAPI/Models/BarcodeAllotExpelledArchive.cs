using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class BarcodeAllotExpelledArchive
    {
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public byte? SessionYear { get; set; }
        public int? SubId { get; set; }
        public byte? MonthId { get; set; }
        public long? BarCode { get; set; }
        public int? UdSlno { get; set; }
        public string UserId { get; set; }
    }
}
