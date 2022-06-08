using System.ComponentModel.DataAnnotations.Schema;

namespace ICABAPI.Models
{
    [ Table("FORMFILLUPTABLEMOODLE")]
    public class FormFillUptableForMoodle
    {
        public int? ID { get; set; }
        public int  REFNO  { get; set; }
        public int  EXAMROLL  { get; set; }
        public int  REGNO  { get; set; }
        public string  NAME  { get; set; }
        public string  FATHERSNAME  { get; set; }
        public int  EXAMLEVEL  { get; set; }
        public int  MONTHID  { get; set; }
        public int  SESSIONYEAR  { get; set; }
        public int  BARCODE  { get; set; }
        public int  APPEARINGFLAG  { get; set; }
    }
}