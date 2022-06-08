using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    [Authorize]
    // [ApiController]
    // [Route("api/v1/[controller]")]
    public class MemberController : CustomType1ApiController
    {

        private readonly IMemberRepository _memberRepository;
        private readonly ModelContext _context;
        public MemberController(IMemberRepository memberRepository, ModelContext context)
        {
            _context = context;
            _memberRepository = memberRepository;
        }

        /// <summary>
        /// All members list
        /// </summary>
        [HttpGet("allMembers")]

        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            var members = await _memberRepository.GetMemberAsync();
            if (members == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Data Found",
                    Success = false,
                    Payload = null
                });
            } //return NotFound();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of All Members",
                Success = true,
                Payload = members
            });
        }

        /// <summary>
        /// Get Member By Id
        /// </summary>
        [HttpPost("GetMemberById")]
        public async Task<ActionResult<IEnumerable<Member>>> GetMemberById(MemberForPincipleDto members)
        {
            var member = await _memberRepository.GetMemberByIdAsync(members.MemId);
            if (member == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Data Found",
                    Success = false,
                    Payload = null
                });
            } //return NotFound("No Data Found");

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of All Members",
                Success = true,
                Payload = member
            });
        }

        /// <summary>
        /// Create Member
        /// </summary>
        [HttpPost("create")]
        public async Task<ActionResult> CreateMember([FromBody] Member member)
        {
            var existingMember = await _context.Members.SingleOrDefaultAsync(x => x.Enrno == member.Enrno);
            if (existingMember == null)
            {
                var isCreated = await _memberRepository.CreateMemberAsync(member);

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Member Created",
                    Success = true,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            {
                Message = "Member Already Exist with enrollment number: " + member.Enrno,
                Success = false,
                Payload = null
            });

        }

        /// <summary>
        /// Update Member
        /// </summary>
        [HttpPost("Update")]
        public async Task<ActionResult> UpdateMember([FromBody] Member member)
        {
            var existingMember = await _context.Members.SingleOrDefaultAsync(x => x.MemId == member.MemId);
            if (existingMember == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Data Found",
                    Success = false,
                    Payload = null
                });
            } //return BadRequest("member not found");
            else
            {
                existingMember.Name = member.Name;
                existingMember.Cell = member.Cell;
                existingMember.Email = member.Email;
                existingMember.Prof = member.Prof;
                existingMember.Enrno = member.Enrno;
                // existingMember.MemId = member.MemId;
                _context.Members.Update(existingMember);
                await _context.SaveChangesAsync();
                // await _memberRepository.UpdateMemberAsync(member.MemId, member);

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Member Updated",
                    Success = true,
                    Payload = null
                });
            }

        }

        // [HttpGet("allPrincipal")]
        // public async Task< ActionResult <IEnumerable<Principal>>> GetPrin()
        // {
        //     var principal =await _context.Principals.ToListAsync();
        //     if (principal == null) return NotFound();
        //     return Ok(principal);
        // } 

    }
}
