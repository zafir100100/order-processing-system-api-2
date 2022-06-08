using System.Threading.Tasks;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICABAPI.Controllers
{
    public class SampleController : BaseApiController
    {
        private readonly ModelContext _context;
        public SampleController(ModelContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok( new{
                status ="success" ,
                Message ="application is running"
            });
        }
       


    }
}