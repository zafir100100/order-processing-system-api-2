using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Bankbranch
    {
        public decimal? Branchcode { get; set; }
        public string Branchname { get; set; }
        public string Routing { get; set; }
        public string Swiftcode { get; set; }
        public decimal? Chequebankcode { get; set; }
        public string Chequebankname { get; set; }
    }
}
