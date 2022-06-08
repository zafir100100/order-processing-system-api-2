using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ICABAPI.Models
{
    public partial class MarksAllot
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
       // public string Test { get; set; }
    }
}