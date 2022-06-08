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
    public class SeatplansControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int CenId { get; set; }
        public int SubId { get; set; }
    }

    public class SeatplansControllerModel2
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int CenId { get; set; }
        public int SubId { get; set; }
        public string RoomNo { get; set; }
    }

    public class SeatplansControllerModel3
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int CenId { get; set; }
        public int SubId { get; set; }
        public int RollNo { get; set; }
    }

    public class SeatplansControllerModel4
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int SubId { get; set; }
        public int RollNofrom { get; set; }
        public int RollNoTo { get; set; }
    }

    public class SeatplansControllerModel5
    {
        public int RegNo { get; set; }
        public int ExamRollno { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int SubId { get; set; }
        public string MonthName { get; set; }
        public string ExamLevelName { get; set; }
        public string SubName { get; set; }
    }

    public class SeatplansControllerModel6
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class SeatplansControllerModel7 : SeatplansControllerModel6
    {
        public int SubId { get; set; }
        public int? CenId { get; set; }
    }

    public class SeatplansControllerModel8 : ExamTimeSchedulesControllerModel4
    {
        public string SubName { get; set; }
        public List<Seatplan> Output { get; set; }
        public string CentreName { get; set; }

        //public byte[] ControllerSign { get; set; }
    }

    //[Authorize]

    public class SeatplansController : BaseApiController
    {
        private readonly ModelContext _context;

        public SeatplansController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Seat Plan By Examlevel, Monthid, Sessionyear and SubjectId
        /// </summary>
        [HttpPost("GetSeatPlanByExamlevelMonthidSessionyearSubjectId")]
        public async Task<ActionResult<ResponseDto2>> GetSeatPlanByExamlevelMonthidSessionyearSubjectId([FromBody] SeatplansControllerModel7 input1)
        {
            var input = input1;

            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year " + input.SessionYear + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Subject id year " + input.SubId + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Subject examLevelSubject = await _context.Subjects.Where(k => k.SubId == input.ExamLevel).FirstOrDefaultAsync();

            if (examLevelSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(k => k.SessionId == input.MonthId).FirstOrDefaultAsync();

            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            Subject subject = await _context.Subjects.Where(k => k.SubId == input.SubId).FirstOrDefaultAsync();

            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id " + input.SubId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            List<Seatplan> seatplan =
                input.CenId != null && input.CenId >= 1 ?
                await _context.Seatplans.Where(x => x.ExamLevel == input1.ExamLevel && x.MonthId == input1.MonthId && x.SessionYear == input1.SessionYear && x.SubId == input1.SubId && x.CenId == input.CenId).OrderBy(d => d.Rollto).ToListAsync() :
                await _context.Seatplans.Where(x => x.ExamLevel == input1.ExamLevel && x.MonthId == input1.MonthId && x.SessionYear == input1.SessionYear && x.SubId == input1.SubId).OrderBy(d => d.Rollto).ToListAsync();

            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No seat plan info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //byte[] controllerSign = await _context.Signatures.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear).Select(o => o.ControllerSign).FirstOrDefaultAsync();

            //if (controllerSign == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            //    {
            //        Message = "No controller signature info found for given criteria",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            SeatplansControllerModel8 output = new();

            output.ExamLevelName = examLevelSubject.SubName;
            output.MonthName = sessionInfo.SessionName;
            output.SubName = subject.SubName;
            output.Output = seatplan;
            output.CentreName = await _context.ExamCentres.Where(i => i.CenId == input.CenId).Select(j => j.Name).FirstOrDefaultAsync();
            //output.ControllerSign = controllerSign;

            bool isRowCountValid = output.Output.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "List of seat plan info" : "No seat plan info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Get Seat Plan By Examlevel, Monthid, Sessionyear, Centerid and SubjectId
        /// </summary>
        [HttpPost("GetSeatPlanByExamlevelMonthidSessionyearCenterIdSubjectId")]
        public async Task<ActionResult<ResponseDto2>> GetSeatplans2([FromBody] SeatplansControllerModel1 input1)
        {
            var seatplan = await _context.Seatplans.OrderBy(d => d.RoomNo).Where(x => x.ExamLevel == input1.ExamLevel && x.MonthId == input1.MonthId && x.SessionYear == input1.SessionYear && x.CenId == input1.CenId && x.SubId == input1.SubId).ToListAsync();

            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No seat plan info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Seat plan info",
                Success = true,
                Payload = seatplan
            });
        }

        /// <summary>
        /// Get Seat Plan By Examlevel, Monthid, Sessionyear, Centerid, SubjectId and Room number
        /// </summary>
        [HttpPost("GetSeatPlanByExamlevelMonthidSessionyearCenterIdSubjectIdRoomnumber")]
        public async Task<ActionResult<ResponseDto2>> GetSeatplan([FromBody] SeatplansControllerModel2 input2)
        {
            var seatplan = await _context.Seatplans.Where(x => x.ExamLevel == input2.ExamLevel && x.MonthId == input2.MonthId && x.SessionYear == input2.SessionYear && x.CenId == input2.CenId && x.SubId == input2.SubId && x.RoomNo == input2.RoomNo).FirstOrDefaultAsync();

            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No seat plan info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Seat plan info",
                Success = true,
                Payload = seatplan
            });
        }

        /// <summary>
        /// Get Seat Plan By Examlevel, Monthid, Sessionyear, Centerid, SubjectId and roll number
        /// </summary>
        [HttpPost("GetSeatPlanByExamlevelMonthidSessionyearCenterIdSubjectIdRollnumber")]
        public async Task<ActionResult<ResponseDto2>> GetSeatplan2([FromBody] SeatplansControllerModel3 input3)
        {
            var seatplan = await _context.Seatplans.Where(x => x.ExamLevel == input3.ExamLevel && x.MonthId == input3.MonthId && x.SessionYear == input3.SessionYear && x.CenId == input3.CenId && x.SubId == input3.SubId && input3.RollNo >= x.Rollfrom && input3.RollNo <= x.Rollto).FirstOrDefaultAsync();

            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No seat plan info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Seat plan info",
                Success = true,
                Payload = seatplan
            });
        }

        /// <summary>
        /// Create Seat Plan
        /// </summary>
        [HttpPost("CreateSeatPlans")]
        public async Task<ActionResult<ResponseDto2>> PostSeatplan([FromBody] List<Seatplan> seatplans)
        {
            if (seatplans == null || seatplans.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No info found for creating new seat plans",
                    Success = false,
                    Payload = null
                });
            }
            foreach (var item in seatplans)
            {
                _context.Seatplans.Add(item);
                await _context.SaveChangesAsync();
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Seatplans are created",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Get Seat Label
        /// </summary>
        [HttpPost("GetSeatLabel")]
        public async Task<ActionResult<ResponseDto2>> GetSeatLabel([FromBody] SeatplansControllerModel4 input1)
        {
            if (input1.RollNoTo < input1.RollNofrom)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Roll number from can not be less than roll number to",
                    Success = false,
                    Payload = null
                });
            }

            var monthName = await _context.SessionInfos
                                          .Where(si => si.SessionId == input1.MonthId)
                                          .Select(s => s.SessionName)
                                          .FirstOrDefaultAsync();

            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month name found for month id: " + input1.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            var examLevelName = await _context.Subjects
                                              .Where(sub => sub.SubId == input1.ExamLevel)
                                              .Select(s => s.SubName)
                                              .FirstOrDefaultAsync();

            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level name found for exam level: " + input1.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            var subjectName = await _context.Subjects
                                            .Where(sub => sub.SubId == input1.SubId)
                                            .Select(s => s.SubName)
                                            .FirstOrDefaultAsync();

            if (subjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject name found for subject id: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }

            var seatLabels =

            await (from er in _context.Set<ExamReg>()
                   join rs in _context.Set<RegSubject>()
                        on er.Ref equals rs.RefNo into groupjoin1
                   from rs in groupjoin1.DefaultIfEmpty()
                   where er.ExamLevel == input1.ExamLevel && er.MonthId == input1.MonthId && er.SessionYear == input1.SessionYear && rs.SubId == input1.SubId && er.ExamRollno >= input1.RollNofrom && er.ExamRollno <= input1.RollNoTo
                   select new SeatplansControllerModel5
                   {
                       RegNo = er.RegNo,
                       ExamRollno = er.ExamRollno,
                       ExamLevel = er.ExamLevel,
                       MonthId = er.MonthId,
                       SessionYear = er.SessionYear,
                       ExamcenId = er.ExamcenId,
                       SubId = rs.SubId,
                       MonthName = monthName,
                       ExamLevelName = examLevelName,
                       SubName = subjectName
                   }).OrderBy(f => f.ExamRollno).ToListAsync();

            if (seatLabels == null || seatLabels.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No seat label found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of seat plans",
                Success = true,
                Payload = seatLabels
            });
        }

        /// <summary>
        /// Delete Seat Plan
        /// </summary>
        [HttpDelete("DeleteSeatPlan")]
        public async Task<ActionResult<ResponseDto2>> DeleteSeatPlan([FromBody] SeatplansControllerModel2 input)
        {
            Seatplan seatplan = await _context.Seatplans.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.CenId == input.CenId && i.SubId == input.SubId && i.RoomNo == input.RoomNo).FirstOrDefaultAsync();
            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Seatplans not found",
                    Success = false,
                    Payload = null
                });
            }
            _context.Seatplans.Remove(seatplan);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Seatplans deleted Successfully",
                Success = true,
                Payload = null
            });
        }
    }
}
