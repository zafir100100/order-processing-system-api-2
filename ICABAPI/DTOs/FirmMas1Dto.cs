using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ICABAPI.DTOs
{
    public class FirmMas1Dto
    {
        public FirmMas1Dto()
        {
            FirmMas2s = new HashSet<FirmMas2Dto>();
            ProPartners = new HashSet<ProPartnerDto>();
        }
        public int FId { get; set; }
        public string FName { get; set; }
        public int FType { get; set; }
        public DateTime? DoDeed { get; set; }
        public int NumPartner { get; set; }
        public int FIRMREGNO { get; set; }
        public string Entryuser { get; set; }
        public int? FirmMas1Id { get; set; }
        public virtual ICollection<FirmMas2Dto> FirmMas2s { get; set; }
        public virtual ICollection<ProPartnerDto> ProPartners { get; set; }
    }
    public class ProPartnerDto
    {
        [JsonIgnore]
        public int FId { get; set; }
        public int MemId { get; set; }
    }

 
}