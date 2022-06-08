using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplSubmission
    {
        public CplSubmission()
        {
            CplSubmissionAcademicDetails = new HashSet<CplSubmissionAcademicDetail>();
        }

        public decimal Id { get; set; }
        public decimal SubmissionId { get; set; }
        public decimal IsCplApproved { get; set; }
        public decimal RegNo { get; set; }
        public decimal ExamLevel { get; set; }
        public decimal ObtainedCgpa { get; set; }
        public decimal MonthId { get; set; }
        public decimal SessionYear { get; set; }
        public DateTime? SubmissionDate { get; set; }

        public virtual CplSubmissionFilesCommon CplSubmissionFilesCommon { get; set; }
        public virtual ICollection<CplSubmissionAcademicDetail> CplSubmissionAcademicDetails { get; set; }
    }
}