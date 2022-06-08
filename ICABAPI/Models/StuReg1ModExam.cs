using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuReg1ModExam
    {
        public int? RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public byte? RegYear { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
        public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int? FId { get; set; }
        public int? PrinEnrNo { get; set; }
        public string Religion { get; set; }
        public string Fax { get; set; }
        public string Imagepath { get; set; }
        public string BloodGr { get; set; }
        public string Entryuser { get; set; }
        public byte? SessionYear { get; set; }
        public bool? MonthId { get; set; }
        public byte? StudType { get; set; }
    }
}
