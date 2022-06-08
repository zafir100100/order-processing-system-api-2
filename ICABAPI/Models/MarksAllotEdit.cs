using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class MarksAllotEdit
    {
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public int? SubId { get; set; }
        public int? BarCode { get; set; }
        public int? Examiner { get; set; }
        public int? Scriptsl { get; set; }
        public decimal? Outmarks { get; set; }
        public decimal? Marks { get; set; }
        public string Grade { get; set; }
        public decimal? Grace { get; set; }
        public string Entryuser { get; set; }
        public int? ChangeMood { get; set; }
        public int? TrackId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string EditDelete { get; set; }
        public string ChangeUser { get; set; }
        public string PcInfo { get; set; }
    }
}
