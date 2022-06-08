using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICABAPI.Models;

namespace ICABAPI.Data
{
    public class PdfService
    {
        private readonly ModelContext _context;
        public PdfService(ModelContext context)
        {
            _context = context;

        }
         private  List<Member> GetAllmembers ()
        {
            var data = _context.Members.ToList();
            return data;
        }
        private Member GetMember(int memberId)
        {
            var data = _context.Members.FirstOrDefault(x => x.MemId == memberId);
            return data;
        }
         public string GetHtml(int memberId)
        {
            var mem = GetMember(memberId);
            
          //  https://localhost:5001/api/admin/v1/MemberPdf
           
            var sb = new StringBuilder();
             

             
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Member Report </h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>MemID</th>
                                        <th>Cell</th>
                                        <th>Enrno</th>
                                    </tr>");
             
            // foreach (var mem in members)
            // {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", mem.Name,mem.MemId,mem.Cell,mem.Enrno);
          //  }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();


        }

        
        
   
    }
}