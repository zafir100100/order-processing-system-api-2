using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class MarksAllotExpelledArchive
    {
        public byte? SessionYear { get; set; }
        public byte? MonthId { get; set; }
        public int? SubId { get; set; }
        public long? BarCode { get; set; }
        public short? Examiner { get; set; }
        public short? Scriptsl { get; set; }
        public decimal? Outmarks { get; set; }
        public decimal? Marks { get; set; }
        public string Grade { get; set; }
        public decimal? Grace { get; set; }
        public string Entryuser { get; set; }
    }
}
