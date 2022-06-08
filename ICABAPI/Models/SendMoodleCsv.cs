using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Models
{
    public partial class SendMoodleCsv
    {
        public decimal Id { get; set; }
        public int? RegNoTo { get; set; }
        public int? RegNoFrom { get; set; }
        public string Password { get; set; }
        public string Cohort1 { get; set; }
        public DateTime? DownloadDateTime { get; set; }
        public int Subid { get; set; }
        public int SessionYear { get; set; }
        public int Monthid { get; set; }
        public string Username { get; set; }
    }
}
