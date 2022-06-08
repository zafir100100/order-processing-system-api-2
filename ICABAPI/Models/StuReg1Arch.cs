using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuReg1Arch
    {
        public int? RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public int? RegYear { get; set; }
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
        public int? ChangeId { get; set; }
        public DateTime? ChangeDate { get; set; }
        public string ChangeTime { get; set; }
        public string EditDelete { get; set; }
        public string ChangeUser { get; set; }
        public int? StudType { get; set; }
        [DefaultValue(null)]
        public byte[] Defaultimage { get; set; }

        // public int? RegNo { get; set; }
        // public DateTime? RegDate { get; set; }
        // public byte? RegYear { get; set; }
        // public DateTime? PeriodFrom { get; set; }
        // public DateTime? PeriodTo { get; set; }
        // public string NationalId { get; set; }
        // public string Name { get; set; }
        // public string FName { get; set; }
        // public string MName { get; set; }
        // public string PreAdd { get; set; }
        // public string PerAdd { get; set; }
        // public string Ph { get; set; }
        // public string Cell { get; set; }
        // public string Email { get; set; }
        // public DateTime? Dob { get; set; }
        // public string Gender { get; set; }
        // public string Nationality { get; set; }
        // public int? FId { get; set; }
        // public int? PrinEnrNo { get; set; }
        // public string Religion { get; set; }
        // public string Fax { get; set; }
        // public string Imagepath { get; set; }
        // public string BloodGr { get; set; }
        // public string Entryuser { get; set; }
        // public int? ChangeId { get; set; }
        // public DateTime? ChangeDate { get; set; }
        // public string ChangeTime { get; set; }
        // public string EditDelete { get; set; }
        // public string ChangeUser { get; set; }
        // public byte? StudType { get; set; }
    }
}
