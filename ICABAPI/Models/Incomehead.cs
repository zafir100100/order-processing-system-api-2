using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Incomehead
    {
        public byte? InheadId { get; set; }
        public string InheadCode { get; set; }
        public byte? Parent { get; set; }
        public byte? Topparent { get; set; }
        public string Name { get; set; }
        public string Lr { get; set; }
        public bool? Depth { get; set; }
        public byte? InheadidOrder { get; set; }
    }
}
