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
    public class GroupSubjectControllerModel1
    {
        public decimal GroupSubId { get; set; }
    }

    //[Authorize]

    public class GroupSubjectController : BaseApiController
    {
        private readonly ModelContext _context;

        public GroupSubjectController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get A Group Subject
        /// </summary>
        [HttpPost("GetAGroupSubject")]
        public async Task<ActionResult<ResponseDto2>> GetAGroupSubject(GroupSubjectControllerModel1 input)
        {
            GroupSubject groupSubject = await _context.GroupSubjects.Where(i => i.GroupSubId == input.GroupSubId).FirstOrDefaultAsync();

            if (groupSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No group subject info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Group Subject information details",
                Success = true,
                Payload = groupSubject
            });
        }

        /// <summary>
        /// Create Group Subject
        /// </summary>
        [HttpPost("CreateGroupSubject")]
        public async Task<ActionResult<ResponseDto2>> CreateGroupSubject([FromBody] GroupSubject input)
        {
            input.Id = (await _context.GroupSubjects.MaxAsync(o => o.Id) ?? 0) + 1;
            input.GroupSubId = (await _context.GroupSubjects.MaxAsync(o => o.GroupSubId) ?? 0) + 1;
            _context.GroupSubjects.Add(input);
            bool isCreated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isCreated ? "Group Subject created successfully" : "Group Subject creation failed. Something went wrong. Please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { input.GroupSubId } : null
            });
        }

        /// <summary>
        /// Update Group Subject
        /// </summary>
        [HttpPost("UpdateGroupSubject")]
        public async Task<ActionResult<ResponseDto2>> UpdateGroupSubject([FromBody] GroupSubject input)
        {
            bool isExists = await _context.GroupSubjects.AnyAsync(i => i.GroupSubId == input.GroupSubId);
            if (isExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A group subject with code: " + input.GroupSubId + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.GroupSubjects.Update(input);
            bool isUpdated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isUpdated ? "Group Subject updated successfully" : "Group Subject update failed. Something went wrong. Please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { input.GroupSubId } : null
            });
        }

        /// <summary>
        /// Delete Group Subject
        /// </summary>
        [HttpPost("DeleteGroupSubject")]
        public async Task<ActionResult<ResponseDto2>> DeleteGroupSubject([FromBody] GroupSubjectControllerModel1 input)
        {
            GroupSubject groupSubject = await _context.GroupSubjects.Where(i => i.GroupSubId == input.GroupSubId).FirstOrDefaultAsync();
            if (groupSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A group subject with code: " + input.GroupSubId + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.GroupSubjects.Remove(groupSubject);
            bool isDeleted = await _context.SaveChangesAsync() > 0;
            return StatusCode(isDeleted ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isDeleted ? "Group Subject deleted successfully" : "Group Subject deletion failed. Something went wrong. Please try again later.",
                Success = isDeleted,
                Payload = isDeleted ? new { input.GroupSubId } : null
            });
        }
    }
}
