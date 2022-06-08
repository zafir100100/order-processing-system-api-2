using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class MarksEditArchive
    {
        public byte? SessionYear { get; set; }
        public byte? MonthId { get; set; }
        public int? SubId { get; set; }
        public long? BarCode { get; set; }
        public short? Scriptsl { get; set; }
        public decimal? Marks { get; set; }
        public decimal? Prevmarks { get; set; }
        public string Entryuser { get; set; }
        public string ChangeUser { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string PcInfo { get; set; }
        public int? TrackId { get; set; }
    }
}
