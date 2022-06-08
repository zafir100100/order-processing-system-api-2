using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuInfoWebAdmit
    {
        public int? Ref { get; set; }
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? ExamLevel { get; set; }
        public int? SessionYear { get; set; }
        public int? MonthId { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string PreAdd { get; set; }
        public string Imagepath { get; set; }
        public DateTime? Dob { get; set; }
        public string Examlevel1 { get; set; }
        public string CenName { get; set; }
        public string CenAddr { get; set; }
        public bool? Msg { get; set; }
    }
}
