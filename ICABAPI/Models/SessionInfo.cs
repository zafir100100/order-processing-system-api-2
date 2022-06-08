using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class SessionInfo
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionDetailsName { get; set; }

        // public byte? SessionId { get; set; }
        // public string SessionName { get; set; }
    }
}
