using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#nullable disable

namespace ICABAPI.Models
{
    [DataContract]
    public partial class CplUniversity
    {
        public CplUniversity()
        {
            CplDepartments = new HashSet<CplDepartment>();
        }

        [DataMember(Order = 4)]
        public decimal Id { get; set; }
        [DataMember(Order = 0)]
        public decimal UniversityId { get; set; }
        [DataMember(Order = 1)]
        public string UniversityName { get; set; }

        [DataMember(Order = 2)]
        public virtual ICollection<CplDepartment> CplDepartments { get; set; }
    }
}
