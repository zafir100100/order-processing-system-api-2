using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuReg1
    {
        [Required]
        public int RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public int? RegYear { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public int UserDobChangeLimit { get; set; } = 1;
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
        public int? StudType { get; set; }
        //[DefaultValue(null)]
        //public byte[] Defaultimage { get; set; }
        //[DefaultValue(null)]
        //public byte[] Requestednewimage { get; set; }
        [MaxLength(1)]
        [DefaultValue(0)]
        public int? Imageapprovalpending { get; set; }
        public string Salutation { get; set; }
        public string AltMobNo { get; set; }
        public string FirmName { get; set; }
        public string PrinName { get; set; }
        [DefaultValue(0)]
        public decimal? PrinID { get; set; }
        public string ArticleSname { get; set; }
        [DefaultValue(0)]
        public decimal? GenStuType { get; set; }
        [DefaultValue(null)]
        public string RequestedImagepath { get; set; }

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
        // public byte? StudType { get; set; }
        // public int Id { get; set; }
    }
}
