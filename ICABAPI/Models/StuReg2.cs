using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ICABAPI.Models
{
    public partial class StuReg2
    {
        [Required]
        public int RegNo { get; set; }
        [Required]
        public string ExamName { get; set; }
        public string BoardUni { get; set; }
        public int? PassYear { get; set; }
        public int? ResultDiv { get; set; }
        public decimal? ResultGpa { get; set; }
        public string ResultProf { get; set; }
        public decimal? ResultOutOfGpa { get; set; }
        public string AcademicLevel { get; set; }
        public string Group { get; set; }
        public string CertificationLevel { get; set; }
        public string Institute { get; set; }

        // public int? RegNo { get; set; }
        // public string ExamName { get; set; }
        // public string BoardUni { get; set; }
        // public byte? PassYear { get; set; }
        // public bool? ResultDiv { get; set; }
        // public decimal? ResultGpa { get; set; }
        // public string ResultProf { get; set; }
        // public decimal? ResultOutOfGpa { get; set; }
        // public string AcademicLevel { get; set; }
        // public string Group { get; set; }
    }
}
