using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplCourse
    {
        public CplCourse()
        {
            CplSubjectMappings = new HashSet<CplSubjectMapping>();
        }

        public decimal Id { get; set; }
        public decimal CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal UniversityId { get; set; }

        public virtual CplDepartment CplDepartment { get; set; }
        public virtual ICollection<CplSubjectMapping> CplSubjectMappings { get; set; }
    }
}
