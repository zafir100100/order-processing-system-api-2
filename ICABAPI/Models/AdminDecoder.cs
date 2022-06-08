using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class AdminDecoder
    {
        public int? ExamLevel { get; set; }
        public byte? MonthId { get; set; }
        public byte? SessionYear { get; set; }
        public byte? UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public string Who { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Entryuser { get; set; }
    }
}
