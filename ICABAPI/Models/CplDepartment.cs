using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplDepartment
    {
        public CplDepartment()
        {
            CplCourses = new HashSet<CplCourse>();
        }

        public decimal Id { get; set; }
        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal UniversityId { get; set; }
        public decimal Cgpa { get; set; }

        public virtual CplUniversity University { get; set; }
        public virtual ICollection<CplCourse> CplCourses { get; set; }
    }
}
