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
    public class BankControllerModel1
    {
        public int Cbcode { get; set; }
    }

    //[Authorize]

    public class BankController : BaseApiController
    {
        private readonly ModelContext _context;

        public BankController(ModelContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get bank list
        /// </summary>
        [HttpGet("GetBanks")]
        public async Task<ActionResult<ResponseDto2>> GetBanks()
        {
            List<Chequebank> banks = await _context.Chequebanks.OrderBy(o => o.Cbname).ToListAsync();

            if (banks == null || banks.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No bank info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + banks.Count + " banks",
                Success = true,
                Payload = banks
            });
        }

        /// <summary>
        /// Get single bank
        /// </summary>
        [HttpPost("GetABank")]
        public async Task<ActionResult<ResponseDto2>> GetABank(BankControllerModel1 input)
        {
            Chequebank chequebank = await _context.Chequebanks.Where(i => i.Cbcode == input.Cbcode).FirstOrDefaultAsync();

            if (chequebank == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No bank info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Bank information details",
                Success = true,
                Payload = chequebank
            });
        }

        /// <summary>
        /// Create bank
        /// </summary>
        [HttpPost("CreateBank")]
        public async Task<ActionResult<ResponseDto2>> CreateBank([FromBody] Chequebank input)
        {
            input.Cbcode = (await _context.Chequebanks.MaxAsync(o => o.Cbcode) ?? 0) + 1;
            _context.Chequebanks.Add(input);
            bool isCreated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isCreated ? "Bank created successfully" : "Bank creation failed. Something went wrong. Please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { input.Cbcode } : null
            });
        }

        /// <summary>
        /// Update existing bank
        /// </summary>
        [HttpPost("UpdateBank")]
        public async Task<ActionResult<ResponseDto2>> UpdateBank([FromBody] Chequebank input)
        {
            bool isExists = await _context.Chequebanks.AnyAsync(i => i.Cbcode == input.Cbcode);
            if (isExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A bank with code: " + input.Cbcode + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.Chequebanks.Update(input);
            bool isUpdated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isUpdated ? "Bank updated successfully" : "Bank update failed. Something went wrong. Please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { input.Cbcode } : null
            });
        }

        /// <summary>
        /// Delete existing bank
        /// </summary>
        [HttpPost("DeleteBank")]
        public async Task<ActionResult<ResponseDto2>> DeleteBank([FromBody] BankControllerModel1 input)
        {
            Chequebank chequebank = await _context.Chequebanks.Where(i => i.Cbcode == input.Cbcode).FirstOrDefaultAsync();
            if (chequebank == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A bank with code: " + input.Cbcode + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.Chequebanks.Remove(chequebank);
            bool isDeleted = await _context.SaveChangesAsync() > 0;
            return StatusCode(isDeleted ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isDeleted ? "Bank deleted successfully" : "Bank deletion failed. Something went wrong. Please try again later.",
                Success = isDeleted,
                Payload = isDeleted ? new { input.Cbcode } : null
            });
        }
    }
}
