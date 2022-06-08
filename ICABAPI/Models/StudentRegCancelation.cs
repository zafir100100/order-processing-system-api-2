using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StudentRegCancelation
    {
        public int? RegNo { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Firmname { get; set; }
        public string PrinName { get; set; }
        public string Reason { get; set; }
        public DateTime? CanDate { get; set; }
        public string Entryuser { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime? Withdrawn_Date { get; set; }
    }
}
