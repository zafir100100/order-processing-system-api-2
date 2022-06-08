using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Models
{
    public class SingleUserFromMoodle
    {
        public string MoodleUserId { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
