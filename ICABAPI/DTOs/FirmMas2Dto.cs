using System;
using System.Text.Json.Serialization;

namespace ICABAPI.DTOs
{
    public class FirmMas2Dto
    {
        public int BrType { get; set; }
        public int? LocId { get; set; }
        public string Address { get; set; }
        
        [JsonIgnore]
        public int FId { get; set; }
        
    }
}