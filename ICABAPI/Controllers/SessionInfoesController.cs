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
    
    public class SessionInfoesControllerModel1
    {
        public int SessionId { get; set; }
    }
    [Authorize]
    public class SessionInfoesController : BaseApiController
    {
        private readonly ModelContext _context;

        public SessionInfoesController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Session Information
        /// </summary>
        [HttpGet("GetAllSessionInfos")]
        public async Task<ActionResult<ResponseDto2>> GetAllSessionInfos()
        {
            var sessionInfoList = await _context.SessionInfos.OrderBy(s => s.SessionId).ToListAsync();

            if (sessionInfoList == null || sessionInfoList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No session info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of session info",
                Success = true,
                Payload = sessionInfoList
            });
        }

        /// <summary>
        /// Get single Session Information
        /// </summary>
        [HttpPost("GetSessionInfo")]
        public async Task<ActionResult<ResponseDto2>> GetSessionInfo([FromBody] SessionInfoesControllerModel1 input1)
        {
            var sessionInfo = await _context.SessionInfos.Where(k => k.SessionId == input1.SessionId).FirstOrDefaultAsync();

            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No session info found for session id: " + input1.SessionId,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Session info for session id: " + input1.SessionId,
                Success = true,
                Payload = sessionInfo
            });
        }

        /// <summary>
        /// Update Session Information
        /// </summary>
        [HttpPost("UpdateSessionInfo")]
        public async Task<ActionResult<ResponseDto2>> UpdateSessionInfo([FromBody] SessionInfo sessionInfo)
        {
            _context.Entry(sessionInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionInfoExists(sessionInfo.SessionId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No session info found for session id: " + sessionInfo.SessionId,
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
                Message = "Session info updated successfully for session id: " + sessionInfo.SessionId,
                Success = true,
                Payload = sessionInfo.SessionId
            });
        }

        /// <summary>
        /// Create Session Information
        /// </summary>
        [HttpPost("CreateSessionInfo")]
        public async Task<ActionResult<ResponseDto2>> CreateSessionInfo([FromBody] SessionInfo sessionInfo)
        {
            _context.SessionInfos.Add(sessionInfo);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Session info created successfully for session id: " + sessionInfo.SessionId,
                Success = true,
                Payload = sessionInfo.SessionId
            });
        }

        /// <summary>
        /// Delete Session Information
        /// </summary>
        [HttpPost("DeleteSessionInfo")]
        public async Task<ActionResult<ResponseDto2>> DeleteSessionInfo([FromBody] SessionInfoesControllerModel1 input1)
        {
            var sessionInfo = await _context.SessionInfos.Where(k => k.SessionId == input1.SessionId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No session info found for session id: " + input1.SessionId,
                    Success = false,
                    Payload = null
                });
            }

            _context.SessionInfos.Remove(sessionInfo);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Session info deleted successfully for session id: " + sessionInfo.SessionId,
                Success = true,
                Payload = sessionInfo.SessionId
            });
        }

        private bool SessionInfoExists(int? id)
        {
            return _context.SessionInfos.Any(e => e.SessionId == id);
        }
    }
}
