using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace ICABAPI.Models
{
    public partial class Signature
    {
        public decimal Id { get; set; }
        public string Controller { get; set; }
        [DefaultValue(null)]
        public string FilepathControllerSign { get; set; }
        public string SecretaryCeo { get; set; }
        [DefaultValue(null)]
        public string FilepathSecretaryCeoSign { get; set; }
        public decimal? ExamLevel { get; set; }
        public decimal? MonthId { get; set; }
        public decimal? SessionYear { get; set; }
    }
}
