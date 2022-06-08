using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Seatplan
    {
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int ExamLevel { get; set; }
        public DateTime ExamDate { get; set; }
        public int CenId { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string RoomNo { get; set; }
        public int? NoOfSeat { get; set; }
        public int Rollfrom { get; set; }
        public int Rollto { get; set; }
        public int SubId { get; set; }
        public string Venue { get; set; }
    }
}
