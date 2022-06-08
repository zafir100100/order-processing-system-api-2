using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ICABAPI.Models
{
    public partial class FirmMas1
    {
        public FirmMas1()
        {
            FirmMas2s = new HashSet<FirmMas2>();
            ProPartners = new HashSet<ProPartner>();
           
        }
       
        public int FId { get; set; }
        public string FName { get; set; }
        public int FType { get; set; }
        public DateTime? DoDeed { get; set; }
        public int NumPartner { get; set; }
        public int FIRMREGNO { get; set; }
        public string Entryuser { get; set; }
        public int? FirmMas1Id { get; set; }
        public virtual ICollection<FirmMas2> FirmMas2s { get; set; }
        public virtual ICollection<ProPartner> ProPartners { get; set; }

    }
    
    
}
