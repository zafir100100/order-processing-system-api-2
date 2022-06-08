using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplSubmissionAcademicDetail
    {
        public decimal Id { get; set; }
        public decimal SubmissionId { get; set; }
        public decimal CplUniversityId { get; set; }
        public decimal CplDepartmentId { get; set; }
        public decimal CplCourseId { get; set; }
        public decimal CplIcabSubjectId { get; set; }
        public decimal ObtainedGpa { get; set; }

        public virtual CplSubjectMapping Cpl { get; set; }
        public virtual CplSubmission Submission { get; set; }
    }
}