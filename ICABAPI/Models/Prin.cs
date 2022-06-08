using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Prin
    {
        public int? MemId { get; set; }
        public short? Enrno { get; set; }
        public DateTime? DateEnr { get; set; }
        public bool? P { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int? FId { get; set; }
    }
}
