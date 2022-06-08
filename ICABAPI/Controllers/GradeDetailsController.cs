using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Controllers
{

    public class GradeDetailsControllerModel1
    {
        public int RefNo { get; set; }
    }

    public class GradeDetailsControllerModel2
    {
        public int RefNo { get; set; }
        public List<GradeDetail> Children { get; set; }
    }

    [Authorize]
    public class GradeDetailsController : BaseApiController
    {
        private readonly ModelContext _context;

        public GradeDetailsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Grade Details
        /// </summary>
        [HttpGet("GetAllGradeDetails")]
        public async Task<ActionResult<ResponseDto2>> GetAllGradeDetails()
        {
            List<int> refNoCollection = await _context.GradeDetails.OrderBy(l => l.RefNo).Select(dd => dd.RefNo).Distinct().ToListAsync();

            if (refNoCollection == null || refNoCollection.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade details reference info found",
                    Success = false,
                    Payload = null
                });
            }

            List<GradeDetailsControllerModel2> output = new();

            foreach (var item in refNoCollection)
            {
                GradeDetailsControllerModel2 tempop = new();
                tempop.RefNo = item;
                tempop.Children = await _context.GradeDetails.Where(k => k.RefNo == item).OrderBy(g => g.GradeSl).ToListAsync();
                output.Add(tempop);
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of grade details",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get Grade Details
        /// </summary>
        [HttpPost("GetGradeDetails")]
        public async Task<ActionResult<ResponseDto2>> GetGradeDetails([FromBody] GradeDetailsControllerModel1 input1)
        {
            if (!GradeDetailExists(input1.RefNo))
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade details info found for reference number : " + input1.RefNo,
                    Success = false,
                    Payload = null
                });
            }

            var gradeDetail = await _context.GradeDetails.Where(p => p.RefNo == input1.RefNo).OrderBy(g => g.GradeSl).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade details info for reference number: " + input1.RefNo,
                Success = true,
                Payload = gradeDetail
            });
        }

        //[HttpPost("UpdateGradeDetails")]
        //public async Task<ActionResult<ResponseDto2>> UpdateGradeDetails([FromBody] List<GradeDetail> gradeDetails)
        //{
        //    if (gradeDetails == null || gradeDetails.Count == 0)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Grade details info can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    int refno = gradeDetails.FirstOrDefault().RefNo;

        //    foreach (var item in gradeDetails)
        //    {
        //        if (refno != item.RefNo)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //            {
        //                Message = "Reference number does not match in given grade details info",
        //                Success = false,
        //                Payload = null
        //            });
        //        }
        //    }

        //    if (GradeDetailExistsInOtherTables(refno) == true)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //        {
        //            Message = "Grade details info for reference number: " + refno + " already exists",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    //using (var context = new ModelContext())
        //    //{
        //    //    context.UpdateRange(gradeDetails);
        //    //    await context.SaveChangesAsync();
        //    //}

        //    foreach (var item in gradeDetails)
        //    {
        //        _context.Entry(item).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //    }

        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "Grade details info for reference number: " + refno + " updated successfully",
        //        Success = true,
        //        Payload = new { id = refno }
        //    });
        //}

        /// <summary>
        /// Create Grade Details
        /// </summary>
        [HttpPost("CreateGradeDetails")]
        public async Task<ActionResult<ResponseDto2>> CreateGradeDetails([FromBody] List<GradeDetail> gradeDetails)
        {
            if (gradeDetails == null || gradeDetails.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Grade details info can not be null",
                    Success = false,
                    Payload = null
                });
            }

            int? maxRef = await _context.GradeDetails.MaxAsync(x => x.RefNo);
            if (maxRef == null)
            {
                maxRef = 0;
            }

            int maxRefNo = (maxRef ?? 0) + 1;

            foreach (var item in gradeDetails)
            {
                item.RefNo = maxRefNo;
            }

            //using (var context = new ModelContext())
            //{
            //    context.AddRange(gradeDetails);
            //    await context.SaveChangesAsync();
            //}

            foreach (var item in gradeDetails)
            {
                _context.GradeDetails.Add(item);
                await _context.SaveChangesAsync();
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade details info created successfully for reference number: " + maxRefNo,
                Success = true,
                Payload = new { id = maxRefNo }
            });
        }

        /// <summary>
        /// Delete Grade Details
        /// </summary>
        [HttpPost("DeleteGradeDetails")]
        public async Task<ActionResult<ResponseDto2>> DeleteGradeDetails([FromBody] GradeDetailsControllerModel1 input1)
        {
            List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(p => p.RefNo == input1.RefNo).ToListAsync();

            if (gradeDetails == null || gradeDetails.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade details info found for reference number : " + input1.RefNo,
                    Success = false,
                    Payload = null
                });
            }

            if (GradeDetailExistsInOtherTables(input1.RefNo) == true)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Grade details info for reference number: " + input1.RefNo + " already exists in grade system",
                    Success = false,
                    Payload = null
                });
            }

            //using (var context = new ModelContext())
            //{
            //    context.RemoveRange(gradeDetails);
            //    await context.SaveChangesAsync();
            //}

            foreach (var item in gradeDetails)
            {
                _context.GradeDetails.Remove(item);
                await _context.SaveChangesAsync();
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade details info deleted successfully for reference number: " + input1.RefNo,
                Success = true,
                Payload = new { id = input1.RefNo }
            });
        }

        private bool GradeDetailExists(int refno)
        {
            return _context.GradeDetails.Any(e => e.RefNo == refno);
        }

        private bool GradeDetailExistsInOtherTables(int refno)
        {
            if (_context.GradeSys.Any(e => e.RefNo == refno) == true)
            {
                return true;
            }
            return false;
        }
    }
}
