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
    public class SignaturesControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }
    //[Authorize]
    public class SignaturesController : BaseApiController
    {
        private readonly ModelContext _context;

        public SignaturesController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Signature
        /// </summary>
        [HttpGet("GetAllSignature")]
        public async Task<ActionResult<ResponseDto2>> GetAllSignature()
        {
            List<Signature> signature = await _context.Signatures.ToListAsync();

            if (signature == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No signature info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<Subject> subjects = await _context.Subjects.Where(i => i.SubId == 61 || i.SubId == 62 || i.SubId == 63).ToListAsync();
            List<SessionInfo> sessionInfos = await _context.SessionInfos.ToListAsync();

            var x = (from r in signature
                     select new
                     {
                         Id = r.Id,
                         Controller = r.Controller,
                         FilepathControllerSign = r.FilepathControllerSign,
                         SecretaryCeo = r.SecretaryCeo,
                         FilepathSecretaryCeoSign = r.FilepathSecretaryCeoSign,
                         ExamLevel = r.ExamLevel,
                         MonthId = r.MonthId,
                         SessionYear = r.SessionYear,
                         ExamLevelName = subjects.Where(i => i.SubId == r.ExamLevel).Select(j => j.SubName).FirstOrDefault(),
                         MonthName = sessionInfos.Where(i => i.SessionId == r.MonthId).Select(o => o.SessionName).FirstOrDefault()
                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Signature info",
                Success = true,
                Payload = x
            });


        }

        /// <summary>
        /// Get Single Signature
        /// </summary>
        [HttpPost("GetSignature")]
        public async Task<ActionResult<ResponseDto2>> GetSignature([FromBody] SignaturesControllerModel1 input)
        {
            var signature = await _context.Signatures.Where(s => s.ExamLevel == input.ExamLevel && s.MonthId == input.MonthId && s.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (signature == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No signature info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Signature info",
                Success = true,
                Payload = signature
            });
        }

        /// <summary>
        /// Create Signature
        /// </summary>
        [HttpPost("CreateSignature")]
        public async Task<ActionResult<Signature>> CreateSignature([FromBody] Signature signature)
        {
            var getMaxID = await _context.Signatures.MaxAsync(j => j.Id);
            if (int.TryParse(getMaxID.ToString(), out _) == false)
            {
                getMaxID = 1;
            }
            else
            {
                getMaxID++;
            }
            _context.Signatures.Add(signature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SignatureExists(signature.Id))
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Signature info already exists",
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
                Message = "Signature info successfully created",
                Success = true,
                Payload = new { id = signature.Id }
            });
        }

        /// <summary>
        /// Update Signature
        /// </summary>
        [HttpPost("UpdateSignature")]
        public async Task<ActionResult<ResponseDto2>> UpdateSignature([FromBody] Signature input)
        {

            _context.Entry(input).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignatureExists(input.Id))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No signature info found for given criteria",
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
                Message = "Signature info successfully updated",
                Success = true,
                Payload = new { id = input.Id }
            });
        }

        private bool SignatureExists(decimal id)
        {
            return _context.Signatures.Any(e => e.Id == id);
        }
    }
}
