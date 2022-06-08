using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Stutype23exempsub
    {
        public int? Ref { get; set; }
        public string FormNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public byte? MonthId { get; set; }
        public byte? SessionYear { get; set; }
        public byte? ExamcenId { get; set; }
        public DateTime? TrainingSt { get; set; }
        public DateTime? TrainingEnd { get; set; }
        public byte? LastAppearedMonthid { get; set; }
        public byte? LastAppearedYear { get; set; }
        public int? LastAppearedRollno { get; set; }
        public int? LastAppearedExamlevel { get; set; }
        public bool? EntryType { get; set; }
        public string AttenAttached { get; set; }
        public string TrainingAttached { get; set; }
        public bool? Validity { get; set; }
        public string ReasonInvalid { get; set; }
        public string Entryuser { get; set; }
        public string FitnessAttached { get; set; }
        public byte? StudType { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
    }
}
