using System.Collections.Generic;
using ICABAPI.Models;

namespace ICABAPI.DTOs
{
    public class StudentReport1
    {
        public StuReg1 StuReg1 { get; set; }
        public List<StuReg2> StuReg2s { get; set; }
    }
}