using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICABAPI.Models
{
    [ Table("DECODERUSER")]
    public class DecoderUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESIGNATION { get; set; }
        public string EMAIL { get; set; }
        public byte[] PASSWORDHASH { get; set; }
        public byte[] PASSWORDSALT { get; set; }
        public bool EMAILVERIFIED{get;set;}
        public string TOKENVALUE { get; set; }
    }
}