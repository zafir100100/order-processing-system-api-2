using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Member
    {
        public int MemId { get; set; }
        public string Name { get; set; }
        public short Enrno { get; set; }
        //public int Adminyear { get; set; }
        //public string Academic { get; set; }
        public int Prof { get; set; }
        // public string FName { get; set; }
        // public string MName { get; set; }
        // public string PreAdd { get; set; }
        // public string CountName { get; set; }
        // public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        // public string Fax { get; set; }
        // public string Web { get; set; }
        // public DateTime? DateEnr { get; set; }
        // public string BAdd { get; set; }
        // public string BloodGr { get; set; }
        // public int? StuReg { get; set; }
        // public string NId { get; set; }
        // public string PassNo { get; set; }
        // public byte ChildrenNo { get; set; }
        // public string Res { get; set; }
        // public int P { get; set; }
        // public string Entryuser { get; set; }
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
       
    }
}
