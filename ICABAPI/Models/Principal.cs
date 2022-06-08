using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Principal
    {
        public int? EnrNo { get; set; }
        public int MemId { get; set; }
        //public DateTime? DateEnr { get; set; }
        //public DateTime? DoPracstart { get; set; }
        public int? FId { get; set; }
        //public int? PerMStu { get; set; }
        //public int? PerFStu { get; set; }
        //public int? PreMStu { get; set; }
        //public int? PreFStu { get; set; }
        //public int? DirMStu { get; set; }
        //public int? DirFStu { get; set; }
        //public int? TransMStu { get; set; }
        //public int? TransFStu { get; set; }
        //public int? SpMStu { get; set; }
        //public int? SpFStu { get; set; }
        //public int Year { get; set; }
        //public int Month { get; set; }
        public string PreStatus { get; set; }
        //public string DoExpire { get; set; }
        public int? PrinId { get; set; }
        //public DateTime DECEASEDDATE { get; set; }
        public int Id { get; set; }
        public DateTime DECEASEDDATE { get; set; }
    }
}
