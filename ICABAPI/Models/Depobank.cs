using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Depobank
    {
        public byte? DbId { get; set; }
        public string DbCode { get; set; }
        public byte? Parent { get; set; }
        public byte? Topparent { get; set; }
        public string DbName { get; set; }
        public string Lr { get; set; }
        public bool? Depth { get; set; }
        public byte? DbOrder { get; set; }
    }
}
