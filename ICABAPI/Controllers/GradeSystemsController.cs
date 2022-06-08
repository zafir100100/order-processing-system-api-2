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

    public class GradeSystemsControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int SubId { get; set; }
    }

    public class GradeSystemsControllerModel2
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RefNo { get; set; }
    }

    public class GradeSystemsControllerModel3
    {
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
        public List<GradeDetail> Children { get; set; }
    }

    [Authorize]
    public class GradeSystemsController : BaseApiController
    {
        private readonly ModelContext _context;

        public GradeSystemsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Grade System
        /// </summary>
        [HttpGet("GetAllGradeSystems")]
        public async Task<ActionResult<ResponseDto2>> GetAllGradeSystems()
        {
            var gradeSystemsList = await _context.GradeSys.OrderBy(a => a.ExamLevel).ThenBy(b => b.MonthId).ThenBy(c => c.SessionYear).ThenBy(d => d.SubId).ToListAsync();

            if (gradeSystemsList == null || gradeSystemsList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade system info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of grade systems",
                Success = true,
                Payload = gradeSystemsList
            });

            //int[] validExamLevels = { 61, 62, 63 };

            //var op = await (from gs in _context.GradeSys.Where(o => validExamLevels.Contains(o.SubId)).OrderBy(a => a.ExamLevel).ThenBy(b => b.MonthId).ThenBy(c => c.SessionYear).ThenBy(d => d.SubId)
            //                join sub in _context.Subjects
            //                    on gs.SubId equals sub.SubId
            //                select new
            //                {

            //                }).ToListAsync();
        }

        /// <summary>
        /// Get Grade Systems By Examlevel, Monthid, Sessionyear and Refno
        /// </summary>
        [HttpPost("GetGradeSystemsByExamlevelMonthidSessionyearRefno")]
        public async Task<ActionResult<ResponseDto2>> GetGradeSystemsByExamlevelMonthidSessionyearRefno([FromBody] GradeSystemsControllerModel2 input2)
        {
            //var gradeSy = await _context.GradeSys.Where(x => x.ExamLevel == input2.ExamLevel && x.MonthId == input2.MonthId && x.SessionYear == input2.SessionYear && x.RefNo == input2.RefNo).OrderBy(a => a.SubId).ToListAsync();

            //if (gradeSy == null || gradeSy.Count == 0)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            //    {
            //        Message = "No grade system info found for given criteria",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            //return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            //{
            //    Message = "Grade systems info for given criteria",
            //    Success = true,
            //    Payload = gradeSy
            //});

            var input = input2;

            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.RefNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Grade Reference number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<int> subIdCollection = await _context.GradeSys.Where(x => x.ExamLevel == input2.ExamLevel && x.MonthId == input2.MonthId && x.SessionYear == input2.SessionYear && x.RefNo == input2.RefNo).OrderBy(a => a.SubId).Select(p => p.SubId).ToListAsync();

            if (subIdCollection == null || subIdCollection.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade system info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<GradeDetail> gradeDetail = await _context.GradeDetails.Where(d => d.RefNo == input2.RefNo).OrderBy(o => o.GradeSl).ToListAsync();

            if (gradeDetail == null || gradeDetail.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade detail info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            List<GradeSystemsControllerModel3> output = new();

            foreach (var item in subIdCollection)
            {
                GradeSystemsControllerModel3 tempop = new();

                tempop.SubId = item;
                tempop.SubName = await _context.Subjects.Where(i => i.SubId == item).Select(o => o.SubName).FirstOrDefaultAsync();
                tempop.ExamLevelName = GetExamLevelName;
                tempop.MonthName = GetMonthName;
                tempop.Children = gradeDetail;

                output.Add(tempop);
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade systems info for given criteria",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get Grade Systems By Examlevel, Monthid, Sessionyear and Subid
        /// </summary>
        [HttpPost("GetGradeSystemByExamlevelMonthidSessionyearSubid")]
        public async Task<ActionResult<ResponseDto2>> GetGradeSystemByExamlevelMonthidSessionyearSubid([FromBody] GradeSystemsControllerModel1 input1)
        {
            var gradeSy = await _context.GradeSys.Where(p => p.ExamLevel == input1.ExamLevel && p.MonthId == input1.MonthId && p.SessionYear == input1.SessionYear && p.SubId == input1.SubId).FirstOrDefaultAsync();

            if (gradeSy == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade system info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade systems info for given criteria",
                Success = true,
                Payload = gradeSy
            });
        }

        //[HttpPost("UpdateGradeSystem")]
        //public async Task<ActionResult<ResponseDto2>> UpdateGradeSystem([FromBody] GradeSy gradeSy)
        //{
        //    var marksAllots = await _context.MarksAllots.Where(x => x.SessionYear == gradeSy.SessionYear && x.MonthId == gradeSy.MonthId && x.SubId == gradeSy.SubId).ToListAsync();

        //    if (marksAllots != null || marksAllots.Count != 0)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //        {
        //            Message = "Grade system info already exists in marks allotment",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    _context.Entry(gradeSy).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GradeSyExists(gradeSy.ExamLevel, gradeSy.MonthId, gradeSy.SessionYear, gradeSy.SubId))
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //            {
        //                Message = "No grade system info found for given criteria",
        //                Success = false,
        //                Payload = null
        //            });
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "Grade systems info successfully updated for given criteria",
        //        Success = true,
        //        Payload = new { id = gradeSy.RefNo }
        //    });
        //}

        /// <summary>
        /// Create Grade Systems 
        /// </summary>
        [HttpPost("CreateGradeSystem")]
        public async Task<ActionResult<ResponseDto2>> CreateGradeSystem([FromBody] GradeSy gradeSy)
        {
            _context.GradeSys.Add(gradeSy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GradeSyExists(gradeSy.ExamLevel, gradeSy.MonthId, gradeSy.SessionYear, gradeSy.SubId))
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Grade system info already exists",
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
                Message = "Grade systems info successfully created for given criteria",
                Success = true,
                Payload = new { id = gradeSy.RefNo }
            });
        }

        /// <summary>
        /// Delete Grade Systems
        /// </summary>
        [HttpPost("DeleteGradeSystem")]
        public async Task<ActionResult<ResponseDto2>> DeleteGradeSystem([FromBody] GradeSy gradeSy)
        {
            if (!GradeSyExists(gradeSy.ExamLevel, gradeSy.MonthId, gradeSy.SessionYear, gradeSy.SubId))
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Grade system info not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }

            var marksAllots = await _context.MarksAllots.Where(x => x.MonthId == gradeSy.MonthId && x.SessionYear == gradeSy.SessionYear && x.SubId == gradeSy.SubId).ToListAsync();

            if (marksAllots.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Grade system info already exists in marks allotment",
                    Success = false,
                    Payload = marksAllots
                });
            }

            _context.GradeSys.Remove(gradeSy);
            await _context.SaveChangesAsync();


            //_context.GradeSys.Add(gradeSy);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (GradeSyExists(gradeSy.ExamLevel, gradeSy.MonthId, gradeSy.SessionYear, gradeSy.SubId))
            //    {
            //        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            //        {
            //            Message = "Grade system info already exists",
            //            Success = false,
            //            Payload = null
            //        });
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade systems info successfully deleted for given criteria",
                Success = true,
                Payload = new { id = gradeSy.RefNo }
            });
        }

        private bool GradeSyExists(int exam_level, int month_id, int session_year, int sub_id)
        {
            return _context.GradeSys.Any(e => e.ExamLevel == exam_level && e.SessionYear == session_year && e.MonthId == month_id && e.SubId == sub_id);
        }
    }
}
