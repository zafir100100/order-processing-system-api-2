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
    public class GetExamFeeByIdInput
    {
        public int Id { get; set; }
    }
    public class DeleteExamFeebyIdInput
    {
        public int Id { get; set; }
    }
    public class GetExamFeeBySubjectInput
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int SubId { get; set; }
    }

    // [Authorize]
    public class ExamFeeController : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamFeeController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("GetExamFees")]
        public async Task<ActionResult<ResponseDto2>> Get()
        {
            var abcd = await _context.ExamFees.ToListAsync();

            if (abcd.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No data found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data found",
                    Success = true,
                    Payload = new
                    {
                        Output = abcd
                    }

                });

            }
            //return Ok(await _context.ExamFees.ToListAsync());
        }
        [HttpPost("GetExamFeeById")]
        public async Task<ActionResult<ResponseDto2>> Get([FromBody] GetExamFeeByIdInput input)
        {
            if (input.Id < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Id cant be blank",
                    Success = false,
                    Payload = null
                });
            }
            var abcd = await _context.ExamFees.Where(i => i.Id == input.Id).FirstOrDefaultAsync();

            if (abcd == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No data found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data found",
                    Success = true,
                    Payload = new
                    {
                        Output = abcd
                    }

                });

            }
            //return Ok(await _context.ExamFees.ToListAsync());
        }
        [HttpPost("GetExamFeeBySubject")]
        public async Task<ActionResult<ResponseDto2>> Get([FromBody] GetExamFeeBySubjectInput input)
        {
            var abcd = await _context.ExamFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId).FirstOrDefaultAsync();

            if (abcd == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No data found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data found",
                    Success = true,
                    Payload = new
                    {
                        Output = abcd
                    }

                });

            }
            //return Ok(await _context.ExamFees.ToListAsync());
        }
        [HttpPost("AddExamFees")]
        public async Task<ActionResult<ResponseDto2>> AddExamFees([FromBody] ExamFee fee)
        {


            if (fee.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level is blank",
                    Success = false,
                    Payload = null
                });
            }

            if (fee.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Sub ID can't be blank or zero",
                    Success = false,
                    Payload = null
                });
            }

            if (fee.MonthId < 1 || fee.MonthId > 12)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month Id can't be blank or wrong input",
                    Success = false,
                    Payload = null
                });
            }
            //
            if (fee.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can't be blank",
                    Success = false,
                    Payload = null
                });
            }

            if (fee.Amount < 1 || fee.Amount == null)
            {
                //if(fee.Amount < 0)
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Amount can't be blank or not appropriate amount",
                    Success = false,
                    Payload = null
                });
            }


            _context.ExamFees.Add(fee);
            int x = await _context.SaveChangesAsync();
            if (x > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data update complete",
                    Success = true,
                    Payload = new
                    {
                        Output = fee
                    }
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Data update failed",
                Success = false,
                Payload = null
            });

            /* _context.ExamFees.Add(fee);
             await _context.SaveChangesAsync();

             return Ok(await _context.ExamFees.ToListAsync());*/
        }
        [HttpPut("UpdateExamFees")]
        public async Task<ActionResult<ResponseDto2>> UpdateExamFees([FromBody] ExamFee request)
        {
            if (request.Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Id 0 silo",
                    Success = false,
                    Payload = null
                });
            }
            var dbExamFee = await _context.ExamFees.Where(i => i.Id == request.Id).FirstOrDefaultAsync();
            if (dbExamFee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam Fee not found",
                    Success = false,
                    Payload = null
                });
            }
            if (request.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year is blank",
                    Success = false,
                    Payload = null
                });
            }
            if (request.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level is blank",
                    Success = false,
                    Payload = null
                });
            }
            //return BadRequest("Exam Fee not found.");

            dbExamFee.ExamLevel = request.ExamLevel;
            dbExamFee.SubId = request.SubId;
            dbExamFee.MonthId = request.MonthId;
            dbExamFee.SessionYear = request.SessionYear;
            dbExamFee.Amount = request.Amount;

            int x = await _context.SaveChangesAsync();

            if (x > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data update complete",
                    Success = true,
                    Payload = new
                    {
                        Output = request
                    }
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Data update failed",
                Success = false,
                Payload = null
            });
        }
        [HttpDelete("DeleteExamFeebyIdInput")]
        public async Task<ActionResult<ResponseDto2>> Delete([FromBody] DeleteExamFeebyIdInput input)
        {


            var dbExamFee = await _context.ExamFees.Where(i => i.Id == input.Id).FirstOrDefaultAsync();
            //var dbExamFee = await _context.ExamFees.FindAsync(id);
            if (dbExamFee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam Fee ID not found",
                    Success = false,
                    Payload = null
                });
            }


            _context.ExamFees.Remove(dbExamFee);
            int x = await _context.SaveChangesAsync();

            if (x > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data Delete complete",
                    Success = true,
                    Payload = new
                    {
                        Output = ("Deleted")
                    }
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Data Delete failed",
                Success = false,
                Payload = null
            });

        }
    }
}
