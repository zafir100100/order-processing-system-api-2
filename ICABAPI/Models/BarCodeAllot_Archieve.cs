using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICABAPI.Models
{
    [Table("BARCODEALLOTARCHIEVE")]
    public class BarCodeAllot_Archieve
    {
       
        public int ID { get; set; }
        public string CHANGEUSER { get; set; }
        public int TRACKID { get; set; }
        public string CHANGETIME { get; set; }
        public DateTime CHANGEDATE { get; set; }
        public string PCINFO { get; set; }
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? SubId { get; set; }
        public int? MonthId { get; set; }
        public int? BarCode { get; set; }
        public int? UdSlno { get; set; }
        public string UserId { get; set; }
        public string EVENT {get;set;}
        
    }
}