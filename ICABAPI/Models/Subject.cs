using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Subject
    {
        public int SubId { get; set; }
        public string SubCode { get; set; }
        public int Parent { get; set; }
        public int Topparent { get; set; }
        public string SubName { get; set; }
        public string Lr { get; set; }
        public int Depth { get; set; }
        public int SubOrder { get; set; }
        public int? UdsubCode { get; set; }
        public string Entryuser { get; set; }
        [DefaultValue(0)]
        public int Outofmarks { get; set; }

        // public byte? SubId { get; set; }
        // public string SubCode { get; set; }
        // public byte? Parent { get; set; }
        // public byte? Topparent { get; set; }
        // public string SubName { get; set; }
        // public string Lr { get; set; }
        // public bool? Depth { get; set; }
        // public byte? SubOrder { get; set; }
        // public byte? UdsubCode { get; set; }
        // public string Entryuser { get; set; }
    }
}
