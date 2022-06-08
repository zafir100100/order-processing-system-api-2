using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ICABAPI.Models
{
    [Table("STUDENT_SUBMENU")]
    public partial class StudentMainMenu
    {
        public decimal? ID { get; set; }
        public string MENUNAME { get; set; }
        public string MENUURL { get; set; }
        public decimal? VISIBILITY { get; set; }
    }
}