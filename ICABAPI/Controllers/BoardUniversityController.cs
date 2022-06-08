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
    public class BoardUniversityControllerModel1
    {
        public decimal BoardUniId { get; set; }
    }

    //[Authorize]

    public class BoardUniversityController : BaseApiController
    {
        private readonly ModelContext _context;

        public BoardUniversityController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a single board university
        /// </summary>
        [HttpPost("GetABoardUniversity")]
        public async Task<ActionResult<ResponseDto2>> GetABoardUniversity([FromBody] BoardUniversityControllerModel1 input)
        {
            BoardUniversity boardUniversity = await _context.BoardUniversities.Where(i=>i.BoardUniId==input.BoardUniId).FirstOrDefaultAsync();

            if (boardUniversity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No board university info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Board university details",
                Success = true,
                Payload = boardUniversity
            });
        }

        /// <summary>
        /// Create board university
        /// </summary>
        [HttpPost("CreateBoardUniversity")]
        public async Task<ActionResult<ResponseDto2>> CreateBoardUniversity([FromBody] BoardUniversity input)
        {
            input.Id = (await _context.BoardUniversities.MaxAsync(o => o.Id) ?? 0) + 1;
            input.BoardUniId = (await _context.BoardUniversities.MaxAsync(o => o.BoardUniId) ?? 0) + 1;
            _context.BoardUniversities.Add(input);
            bool isCreated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isCreated ? "Board university created successfully" : "Board university creation failed. Something went wrong. Please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { input.BoardUniId } : null
            });
        }

        /// <summary>
        /// Update board university
        /// </summary>
        [HttpPost("UpdateBoardUniversity")]
        public async Task<ActionResult<ResponseDto2>> UpdateBoardUniversity([FromBody] BoardUniversity input)
        {
            bool isExists = await _context.BoardUniversities.AnyAsync(i => i.BoardUniId == input.BoardUniId);
            if (isExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A board university with code: " + input.BoardUniId + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.BoardUniversities.Update(input);
            bool isUpdated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isUpdated ? "Board university updated successfully" : "Board university update failed. Something went wrong. Please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { input.BoardUniId } : null
            });
        }

        /// <summary>
        /// Delete board university
        /// </summary>
        [HttpPost("DeleteBoardUniversity")]
        public async Task<ActionResult<ResponseDto2>> DeleteBoardUniversity([FromBody] BoardUniversityControllerModel1 input)
        {
            BoardUniversity boardUniversity = await _context.BoardUniversities.Where(i => i.BoardUniId == input.BoardUniId).FirstOrDefaultAsync();
            if (boardUniversity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A board university with code: " + input.BoardUniId + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.BoardUniversities.Remove(boardUniversity);
            bool isDeleted = await _context.SaveChangesAsync() > 0;
            return StatusCode(isDeleted ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isDeleted ? "Board university deleted successfully" : "Board university deletion failed. Something went wrong. Please try again later.",
                Success = isDeleted,
                Payload = isDeleted ? new { input.BoardUniId } : null
            });
        }
    }
}
