using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Yearinfo
    {
        public byte Yearcode { get; set; }
        public string Openingfield { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Description { get; set; }
        public string AnotherDescription { get; set; }
    }
}
