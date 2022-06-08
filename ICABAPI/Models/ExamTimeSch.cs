using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ExamTimeSch
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int? Id { get; set; }
        public int OrderNo { get; set; }
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int ExamLevel { get; set; }
        public int SubId { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamTime1 { get; set; }
        public string ExamTime2 { get; set; }
        public string ExamTime3 { get; set; }
        public string ExamTime4 { get; set; }
        public int? Slot { get; set; }
        public int? RollFrom { get; set; }
        public int? RollTo { get; set; }
    }
}
