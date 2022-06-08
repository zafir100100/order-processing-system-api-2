using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ICABAPI.Models
{
    public partial class BarcodeAllot
    {   
       
       
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? SubId { get; set; }
        public int? MonthId { get; set; }
        public int? BarCode { get; set; }
        public int? UdSlno { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
    }
}
