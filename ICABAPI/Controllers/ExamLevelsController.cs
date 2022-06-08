using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
   // [Authorize]
    public class ExamLevelsController : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamLevelsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all exam level
        /// </summary>
        [HttpGet("GetAllExamLevel")]
        public async Task<ActionResult<ResponseDto2>> GetAllExamLevel()
        {
            int[] examLevelSubjectIds = { 61, 62, 63 };
            var examLevelSubjectList = await _context.Subjects.Where(x => examLevelSubjectIds.Contains(x.SubId)).OrderBy(s => s.SubId).ToListAsync();

            if (examLevelSubjectList == null || examLevelSubjectList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam levels",
                Success = true,
                Payload = examLevelSubjectList
            });
        }
    }
}
