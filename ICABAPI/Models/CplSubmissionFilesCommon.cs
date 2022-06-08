using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class CplSubmissionFilesCommon
    {
        public decimal Id { get; set; }
        public decimal SubmissionId { get; set; }
        public string FileAcademicTranscript { get; set; }
        public string FileMembershipCertificate { get; set; }
        public string FileIcabIdCard { get; set; }
        public string FileCplPayslip { get; set; }
        public string PayslipNumber { get; set; }
        public string PaymentMode { get; set; }

        public virtual CplSubmission Submission { get; set; }
    }
}
