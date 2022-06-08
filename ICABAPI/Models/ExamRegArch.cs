using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ExamRegArch
    {
        public int? Ref { get; set; }
        public string FormNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public int? ExamcenId { get; set; }
        public DateTime? TrainingSt { get; set; }
        public DateTime? TrainingEnd { get; set; }
        public int? LastAppearedMonthid { get; set; }
        public int? LastAppearedYear { get; set; }
        public int? LastAppearedRollno { get; set; }
        public int? LastAppearedExamlevel { get; set; }
        public int? EntryType { get; set; }
        public string AttenAttached { get; set; }
        public string TrainingAttached { get; set; }
        public int? Validity { get; set; }
        public string ReasonInvalid { get; set; }
        public string Entryuser { get; set; }
        public string FitnessAttached { get; set; }
        public int? StudType { get; set; }
        public int? ChangeId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string EditDelete { get; set; }
        public string ChangeUser { get; set; }
        public string PcInfo { get; set; }
    }
}
