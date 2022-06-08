using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class FirmMas2
    {
       
        public int FId { get; set; }
        public int BrType { get; set; }
        public string Address { get; set; }
        public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string ContPer { get; set; }
        public int? LocId { get; set; }
        public DateTime? DoStart { get; set; }
        public int Id { get; set; }
        public int? FirmMas1Id { get; set; }

        public virtual FirmMas1 FirmMas1 { get; set; }

      
       
    }
}
