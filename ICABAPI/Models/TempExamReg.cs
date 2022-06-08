using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ICABAPI.Models
{
    public partial class TempExamReg
    {
        public int RegNo { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int Ref { get; set; }
        public string FormNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public int ExamRollno { get; set; }
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
        public string CcEnrno { get; set; }
        public string CcSession { get; set; }
        public int? CcYear { get; set; }
        public string Exfeepayslipno { get; set; }
        public DateTime? Exfeepayslipdate { get; set; }
        public string Exfeepayslipbank { get; set; }
        public string Exfeepayslipbr { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public string Annfeepayslipno { get; set; }
        public DateTime? Annfeepayslipdate { get; set; }
        public string Annfeepayslipbank { get; set; }
        public string Annfeepayslipbr { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
        [DefaultValue(0)]
        public decimal? Fapprove { get; set; }
        // can't submit a form twice
        [DefaultValue(1)]
        public decimal? Formsubmitstatus { get; set; }
        public int? MaintbRef { get; set; }
        public string PaymentMode { get; set; }
        [DefaultValue(null)]
        public string FilepathAttenAttached { get; set; }
        [DefaultValue(null)]
        public string FilepathTrainingAttached { get; set; }
        [DefaultValue(null)]
        public string FilepathFitnessAttached { get; set; }
        [DefaultValue(null)]
        public string FilepathExfeeuploadPayslip { get; set; }
        [DefaultValue(null)]
        public string FilepathAnnfeeuploadPayslip { get; set; }
    }
}
