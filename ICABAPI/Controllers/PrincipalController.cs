
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    //[Authorize]

    public class PrincipalControllerModel1
    {
        public int Fid { get; set; }
    }

    public class PrincipalControllerModel2
    {
        public int EnrNo { get; set; }
    }

    public class PrincipalControllerModel3
    {
        public int MemId { get; set; }
    }

    public class PrincipalControllerModel4
    {
        public int EnrNo { get; set; }
        public string Name { get; set; }
        public int FId { get; set; }
        public string FName { get; set; }
        public string PreStatus { get; set; }
    }

    public class PrincipalControllerModel5 : Principal
    {
        public string PrinName { get; set; }
        public string FirmName { get; set; }
    }

    public class PrincipalControllerModel6 : Principal
    {
        public string PrinName { get; set; }
    }
 [Authorize]
    public class PrincipalController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        private readonly IPrincipalEntry _principalEntry;
        private readonly IMemberRepository _memberRepository;

        private readonly IMapper _mapper;

        public PrincipalController(ModelContext context, IMapper mapper, IPrincipalEntry principalEntry, IMemberRepository memberRepository)
        {
            _context = context;
            _memberRepository = memberRepository;
            _principalEntry = principalEntry;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Principal
        /// </summary>
        [HttpGet("{FId}")]
        public async Task<ActionResult<Principal>> GetPrincipal(int FId)
        {
            var principleNameList = new List<PrincipleNameList>();
            var principal = await _principalEntry.GetPrincipleByFirmId(FId);
            if (principal == null) return NotFound(new { Message = "no data found" });
            var result = principal.Select(x => new
            {
                x.FId,
                x.MemId,
                x.PrinId
            });
            if (result == null) return NotFound(new { Message = "no data found" });
            foreach (var p in result)
            {

                //var members  = await _memberRepository.GetMemberBymemberIdAsync(p.MemId);
                var member = await _memberRepository.GetMemberByIdAsync(p.MemId);

                var m = new PrincipleNameList()
                {
                    MemId = member.MemId,
                    PrincipleName = member.Name

                };
                principleNameList.Add(m);

            }
            return Ok(principleNameList);
        }

        /// <summary>
        /// Get Max Prin Id
        /// </summary>
        [HttpGet("GetMaxPrinId")]
        public async Task<ActionResult<ResponseDto2>> GetMaxPrinId()
        {
            int PrinId = (await _context.Principals.MaxAsync(k => k.PrinId) ?? 0) + 1;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Max principal id",
                Success = true,
                Payload = new { PrinId }
            });
        }

        /// <summary>
        /// Get Principal by Id
        /// </summary>
        [HttpPost("GetPrincipalById")]
        public async Task<ActionResult<Principal>> GetPrincipal([FromBody] PrincipalControllerModel1 input)
        {
            var principleNameList = new List<PrincipleNameList>();
            var principal = await _principalEntry.GetPrincipleByFirmId(input.Fid);
            if (principal == null) return NotFound(new { Message = "no data found" });
            var result = principal.Select(x => new
            {
                x.FId,
                x.MemId,
                x.PrinId
            });
            if (result == null) return NotFound(new { Message = "no data found" });
            foreach (var p in result)
            {

                //var members  = await _memberRepository.GetMemberBymemberIdAsync(p.MemId);
                var member = await _memberRepository.GetMemberByIdAsync(p.MemId);

                var m = new PrincipleNameList()
                {
                    MemId = member.MemId,
                    PrincipleName = member.Name

                };
                principleNameList.Add(m);

            }
            return Ok(principleNameList);
        }

        /// <summary>
        /// Get Principal list by Firm Id
        /// </summary>
        [HttpPost("GetPrincipalListByFirmId")]
        public async Task<ActionResult<ResponseDto2>> GetPrincipalByPrinId([FromBody] PrincipalControllerModel1 input)
        {
            List<Principal> principals = await _context.Principals.Where(i => i.FId == input.Fid).ToListAsync();

            if (principals == null || principals.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No principal found under firm id " + input.Fid,
                    Success = false,
                    Payload = null
                });
            }

            List<PrincipalControllerModel6> output = new();

            foreach (var item in principals)
            {
                PrincipalControllerModel6 j = new();

                j.PrinName = await _context.Members.Where(x => x.MemId == item.MemId).Select(x1 => x1.Name).FirstOrDefaultAsync();
                j.MemId = item.MemId;
                j.EnrNo = item.EnrNo;
                j.FId = item.FId;
                output.Add(j);
            }

            var s = (from ss in output
                     select new
                     {
                         MemId = ss.MemId,
                         //EnrNo = ss.EnrNo,
                         FId = ss.FId,
                         PrinEnrNo = ss.EnrNo,
                         PrinName = ss.PrinName
                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + s.Count + " principals under firm id " + input.Fid,
                Success = true,
                Payload = s
            });
        }


        /// <summary>
        /// Get all Principal list report
        /// </summary>
        [HttpGet("GetAllPrincipalReport")]
        public async Task<ActionResult<ResponseDto2>> GetAllPrincipalReport()
        {
            List<PrincipalControllerModel4> output = await (from p in _context.Set<Principal>()
                                                            from m in _context.Set<Member>().Where(m => m.MemId == p.MemId).DefaultIfEmpty()
                                                            from fm in _context.Set<FirmMas1>().Where(fm => p.FId == fm.FId).DefaultIfEmpty()
                                                            select new PrincipalControllerModel4
                                                            {
                                                                EnrNo = p.EnrNo ?? 0,
                                                                Name = m.Name,
                                                                FId = p.FId ?? 0,
                                                                FName = fm.FName,
                                                                PreStatus = p.PreStatus
                                                            }).OrderBy(k => k.EnrNo).ToListAsync();

            bool isRowCountValid = output != null && output.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Principal Report" : "No principal info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Get Firm Name By Principal Name
        /// </summary>
        [HttpPost("GetFirmNameByPrincipalName")]
        public async Task<ActionResult<ResponseDto2>> GetFirmNameByPrincipalName([FromBody] PrincipalControllerModel3 input)
        {
            if (input.MemId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Member id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Member member = await _context.Members.Where(k => k.MemId == input.MemId).FirstOrDefaultAsync();

            if (member == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No member found for member id : " + input.MemId,
                    Success = false,
                    Payload = null
                });
            }

            Principal principal = await _context.Principals.Where(i => i.MemId == member.MemId).FirstOrDefaultAsync();

            if (principal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No principal found for member id : " + member.MemId,
                    Success = false,
                    Payload = null
                });
            }

            FirmMas1 firmMas1 = await _context.FirmMas1s.Where(i => i.FId == principal.FId).FirstOrDefaultAsync();

            if (firmMas1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No firm info found for firm id : " + principal.FId,
                    Success = false,
                    Payload = null
                });
            }

            if (firmMas1.FName == null || firmMas1.FName == "")
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Firm name is null for firm id : " + firmMas1.FId,
                    Success = false,
                    Payload = null
                });
            }

            bool isFirmValid = firmMas1 != null;

            return StatusCode(isFirmValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isFirmValid ? "Firm id and name" : "Firm name get failed. Something went wrong, please try again later.",
                Success = isFirmValid,
                Payload = isFirmValid ? new { firmMas1.FId, firmMas1.FName } : null
            });
        }

        /// <summary>
        /// Get Principal By EnrNo
        /// </summary>
        [HttpPost("GetPrincipalByEnrNo")]
        public async Task<ActionResult<ResponseDto2>> GetPrincipalByEnrNo([FromBody] PrincipalControllerModel2 input)
        {
            if (input.EnrNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Enrollment number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<Principal> principals = await _context.Principals.Where(e => e.EnrNo == input.EnrNo).ToListAsync();

            if (principals.Count == 0 || principals == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No principal found with enrno: " + input.EnrNo,
                    Success = false,
                    Payload = null
                });
            }

            if (principals.Count > 1)
            {


                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Multiple principal exists with enrno: " + input.EnrNo,
                    Success = false,
                    Payload = null
                });
            }

            int getRowCount = principals.Count;

            bool isRowCountValid = getRowCount > 0 && getRowCount == 1;

            Principal fo = principals.FirstOrDefault();

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isRowCountValid ? "Principal info for enr no: " + input.EnrNo : "Principal get failed. Something went wrong, please try again later.",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new PrincipalControllerModel5
                {
                    EnrNo = fo.EnrNo,
                    MemId = fo.MemId,
                    PrinName = await _context.Members.Where(i => i.MemId == fo.MemId).Select(o => o.Name).FirstOrDefaultAsync(),
                    FId = fo.FId,
                    FirmName = await _context.FirmMas1s.Where(i => i.FId == fo.FId).Select(o => o.FName).FirstOrDefaultAsync(),
                    PreStatus = fo.PreStatus,
                    PrinId = fo.PrinId,
                    DECEASEDDATE = fo.DECEASEDDATE
                } : null
            });
        }
        //

        /// <summary>
        /// Create Principal
        /// </summary>
        [HttpPost("CreatePrincipal")]
        public async Task<ActionResult<ResponseDto2>> CreatePrincipal([FromBody] Principal input)
        {
            if (input.EnrNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Enrollment number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<Member> members = await _context.Members.Where(e => e.Enrno == input.EnrNo).ToListAsync();

            if (members.Count < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Member Not Found with this Enrollment number: " + input.EnrNo + ". Please Entry as a member first",
                    Success = false,
                    Payload = null
                });
            }

            if (members.Count > 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "More than One Member found with this Enrollment number: " + input.EnrNo + ". Please contact with ICAB",
                    Success = false,
                    Payload = null
                });
            }

            if (input.FId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Firm id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.PreStatus == null || input.PreStatus == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Present status can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<Principal> principals = await _context.Principals.Where(e => e.EnrNo == input.EnrNo).ToListAsync();

            if (principals.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Principle already exists with enrno: " + input.EnrNo,
                    Success = false,
                    Payload = null
                });
            }

            input.PrinId = await _context.Principals.MaxAsync(i => i.PrinId ?? 0) + 1;
            input.MemId = members.Where(x => x.Enrno == input.EnrNo).Select(i => i.MemId).FirstOrDefault();

            int createdRowCount = 0;
            _context.Principals.Add(input);
            createdRowCount += await _context.SaveChangesAsync();
            bool isCreated = createdRowCount > 0;

            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isCreated ? "Principal successfully created" : "Principal creation failed. Something went wrong, please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { input.EnrNo } : null
            });
        }

        /// <summary>
        /// Delete Principal
        /// </summary>
        [HttpPost("DeletePrincipal")]
        public async Task<ActionResult<ResponseDto2>> DeletePrincipal([FromBody] PrincipalControllerModel2 input)
        {
            if (input.EnrNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Enrollment number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Principal principal = await _context.Principals.Where(e => e.EnrNo == input.EnrNo).FirstOrDefaultAsync();

            if (principal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Pricipal info not found for enrno: " + input.EnrNo,
                    Success = false,
                    Payload = null
                });
            }

            int deletedRowCount = 0;

            _context.Principals.Remove(principal);
            deletedRowCount += await _context.SaveChangesAsync();
            bool isDeleted = deletedRowCount > 0;

            return StatusCode(isDeleted ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isDeleted ? "Principal successfully deleted" : "Principal deletion failed. Something went wrong, please try again later.",
                Success = isDeleted,
                Payload = isDeleted ? new { input.EnrNo } : null
            });
        }

        /// <summary>
        /// Update Principal
        /// </summary>
        [HttpPost("UpdatePrincipal")]
        public async Task<ActionResult<ResponseDto2>> UpdatePrincipal([FromBody] Principal input)
        {
            if (input.EnrNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Enrollment number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MemId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Member id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.FId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Firm id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.PreStatus == null || input.PreStatus == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Present status can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Principal principal = await _context.Principals.Where(e => e.EnrNo == input.EnrNo).FirstOrDefaultAsync();

            if (principal == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Pricipal info not found for enrno: " + input.EnrNo,
                    Success = false,
                    Payload = null
                });
            }

            principal.FId = input.FId;
            principal.PreStatus = input.PreStatus;
            principal.DECEASEDDATE = input.DECEASEDDATE;

            int updatedRowCount = 0;
            _context.Principals.Update(principal);
            updatedRowCount += await _context.SaveChangesAsync();
            bool isUpdated = updatedRowCount > 0;

            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isUpdated ? "Principal successfully updated" : "Principal update failed. Something went wrong, please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { input.EnrNo } : null
            });
        }
    }
}