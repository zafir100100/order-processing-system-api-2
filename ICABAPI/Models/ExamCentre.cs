using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ICABAPI.Models
{
    public partial class ExamCentre
    {
        public int CenId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Buildings { get; set; }

        // [Key]
        //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    }
}
