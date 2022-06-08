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
    public class BranchControllerModel1
    {
        public decimal Chequebankcode { get; set; }
    }

    public class BranchControllerModel2
    {
        public decimal Branchcode { get; set; }
    }

    //[Authorize]

    public class BranchController : BaseApiController
    {
        private readonly ModelContext _context;

        public BranchController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all branches
        /// </summary>
        [HttpPost("GetBranches")]
        public async Task<ActionResult<ResponseDto2>> GetBanks([FromBody] BranchControllerModel1 input)
        {
            List<Bankbranch> bankbranches = await _context.Bankbranches.Where(o => o.Chequebankcode == input.Chequebankcode).OrderBy(o => o.Branchname).ToListAsync();

            if (bankbranches == null || bankbranches.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No branch info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + bankbranches.Count + " branches",
                Success = true,
                Payload = bankbranches
            });
        }

        /// <summary>
        /// Get a branch
        /// </summary>
        [HttpPost("GetABranch")]
        public async Task<ActionResult<ResponseDto2>> GetABank([FromBody] BranchControllerModel2 input)
        {
            Bankbranch bankbranch = await _context.Bankbranches.Where(i => i.Branchcode == input.Branchcode).FirstOrDefaultAsync();

            if (bankbranch == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No branch info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Branch information details",
                Success = true,
                Payload = bankbranch
            });
        }

        /// <summary>
        /// Create branch
        /// </summary>
        [HttpPost("CreateBranch")]
        public async Task<ActionResult<ResponseDto2>> CreateBranch([FromBody] Bankbranch input)
        {
            input.Branchcode = (await _context.Bankbranches.MaxAsync(o => o.Branchcode) ?? 0) + 1;
            _context.Bankbranches.Add(input);
            bool isCreated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isCreated ? "Branch created successfully" : "Branch creation failed. Something went wrong. Please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { input.Branchcode } : null
            });
        }

        /// <summary>
        /// Update branch
        /// </summary>
        [HttpPost("UpdateBranch")]
        public async Task<ActionResult<ResponseDto2>> UpdateBranch([FromBody] Bankbranch input)
        {
            bool isExists = await _context.Bankbranches.AnyAsync(i => i.Branchcode == input.Branchcode);
            if (isExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A branch with code: " + input.Branchcode + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.Bankbranches.Update(input);
            bool isUpdated = await _context.SaveChangesAsync() > 0;
            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isUpdated ? "Branch updated successfully" : "Branch update failed. Something went wrong. Please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { input.Branchcode } : null
            });
        }

        /// <summary>
        /// Delete branch
        /// </summary>
        [HttpPost("DeleteBranch")]
        public async Task<ActionResult<ResponseDto2>> DeleteBranch([FromBody] BranchControllerModel2 input)
        {
            Bankbranch bankbranch = await _context.Bankbranches.Where(i => i.Branchcode == input.Branchcode).FirstOrDefaultAsync();
            if (bankbranch == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "A branch with code: " + input.Branchcode + " does not exist",
                    Success = false,
                    Payload = null
                });
            }
            _context.Bankbranches.Remove(bankbranch);
            bool isDeleted = await _context.SaveChangesAsync() > 0;
            return StatusCode(isDeleted ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isDeleted ? "Branch deleted successfully" : "Branch deletion failed. Something went wrong. Please try again later.",
                Success = isDeleted,
                Payload = isDeleted ? new { input.Branchcode } : null
            });
        }
    }
}
