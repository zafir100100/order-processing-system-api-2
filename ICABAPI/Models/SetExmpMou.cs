using System;
using System.Collections.Generic;

#nullable disable

namespace ICABAPI.Models
{
    public partial class SetExmpMou
    {
        //public SetExmpMou()
        //{
        //    Fies= new List<CplStudentFile>();
        //}
        public int Id { get; set; }
        public byte? StudType { get; set; }
        public int? ExamLevel { get; set; }
        public int? ExamSession { get; set; }
        public int? ExamYear { get; set; }
        public int? RegNo { get; set; }
        public int? ExmptSubid { get; set; }
        //public List<CplStudentFile> Fies { get; set; }
    }
}
