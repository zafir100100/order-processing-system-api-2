using System;

namespace ICABAPI.Entities
{
    public class Member
    {

        public int Id  {get;set;}  
        public int MEMID { get; set; }
        public string NAME { get; set; }
        public int ENRNO { get; set; }
        public int ADMINYEAR { get; set; }
        public string ACADEMIC { get; set; }
        public int PROF { get; set; }
        public string FNAME { get; set; }
        public string MNAME { get; set; }
        public string PREADD { get; set; }
        public string COUNTNAME { get; set; }
        public string PH { get; set; }
        public string CELL { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string WEB { get; set; }
        public DateTime DATEENR { get; set; }
        public string BADD { get; set; }
        public string BLOODGR { get; set; }
        public int STUREG { get; set; }
        public string NID { get; set; }
        public string PASSNO { get; set; }
        public int CHILDRENNO { get; set; }
        public string RES { get; set; }
        public int P { get; set; }
        public string ENTRYUSER { get; set; }
    }
}