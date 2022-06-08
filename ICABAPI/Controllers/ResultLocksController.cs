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
    
    public class ResultLocksControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }
     [Authorize]
    public class ResultLocksController : BaseApiController
    {
        private readonly ModelContext _context;

        public ResultLocksController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Result Lock
        /// </summary>
        [HttpGet("GetAllResultLock")]
        public async Task<ActionResult<ResponseDto2>> GetAllResultLock()
        {
            var resultLocksList = await _context.ResultLocks.OrderBy(s => s.ExamLevel).ThenBy(s => s.MonthId).ThenBy(s => s.SessionYear).ToListAsync();

            if (resultLocksList == null || resultLocksList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No result lock details info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of result locks",
                Success = true,
                Payload = resultLocksList
            });
        }

        /// <summary>
        /// Get Result Lock
        /// </summary>
        [HttpPost("GetResultLock")]
        public async Task<ActionResult<ResponseDto2>> GetResultLock([FromBody] ResultLocksControllerModel1 input1)
        {
            var resultLock = await _context.ResultLocks.Where(e => e.ExamLevel == input1.ExamLevel && e.MonthId == input1.MonthId && e.SessionYear == input1.SessionYear).FirstOrDefaultAsync();

            if (resultLock == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No result lock details info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Result lock details for given criteria",
                Success = true,
                Payload = resultLock
            });
        }


        /// <summary>
        /// Update Result Lock
        /// </summary>
        [HttpPost("UpdateResultLock")]
        public async Task<ActionResult<ResponseDto2>> UpdateResultLock([FromBody] ResultLock resultLock)
        {
            _context.Entry(resultLock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultLockExists(resultLock.ExamLevel, resultLock.MonthId, resultLock.SessionYear))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result lock details info found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Result lock details updated successfully for given criteria",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Create Result Lock
        /// </summary>
        [HttpPost("CreateResultLock")]
        public async Task<ActionResult<ResultLock>> CreateResultLock([FromBody] ResultLock resultLock)
        {
            _context.ResultLocks.Add(resultLock);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResultLockExists(resultLock.ExamLevel, resultLock.MonthId, resultLock.SessionYear))
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Result lock info already exists for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Result lock into created successfully",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Delete Result Lock
        /// </summary>
        [HttpPost("DeleteResultLock")]
        public async Task<ActionResult<ResponseDto2>> DeleteResultLock([FromBody] ResultLocksControllerModel1 input1)
        {
            var resultLock = await _context.ResultLocks.Where(e => e.ExamLevel == input1.ExamLevel && e.MonthId == input1.MonthId && e.SessionYear == input1.SessionYear).FirstOrDefaultAsync();

            if (resultLock == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No result lock details info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            _context.ResultLocks.Remove(resultLock);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Result lock into deleted successfully",
                Success = true,
                Payload = null
            });
        }

        private bool ResultLockExists(int exam_level, int month_id, int session_year)
        {
            return _context.ResultLocks.Any(e => e.ExamLevel == exam_level && e.SessionYear == session_year && e.MonthId == month_id);
        }
    }
}
