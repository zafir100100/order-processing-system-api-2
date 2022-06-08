using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplSubjectMapping
    {
        public CplSubjectMapping()
        {
            CplSubmissionAcademicDetails = new HashSet<CplSubmissionAcademicDetail>();
        }
        public decimal Id { get; set; }
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public decimal IcabSubjectId { get; set; }
        public decimal Gpa { get; set; }
        public int ExamLevel { get; set; }

        public virtual CplCourse CplCourse { get; set; }
        public virtual ICollection<CplSubmissionAcademicDetail> CplSubmissionAcademicDetails { get; set; }
    }
}
