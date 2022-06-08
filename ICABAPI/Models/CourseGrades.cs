using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Models
{
    public class CourseGrades
    {
        public string Courseid { get; set; }
        public string Grade { get; set; }
        public string Rawgrade { get; set; }
        public string Rank { get; set; }
    }
}
