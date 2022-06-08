using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Models
{
    public partial class MoodleCohort
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Cohort { get; set; }
        public int? SubId { get; set; }
        public string MoodleUserId { get; set; }
    }
}
