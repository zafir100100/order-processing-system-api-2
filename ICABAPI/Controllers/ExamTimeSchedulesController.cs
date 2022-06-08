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
    public class ExamTimeSchedulesControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class ExamTimeSchedulesControllerModel2
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int SubId { get; set; }
    }

    public class ExamTimeSchedulesControllerModel3
    {
        public int OrderNo { get; set; }
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int ExamLevel { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamTime1 { get; set; }
        public string ExamTime2 { get; set; }
        public string ExamTime3 { get; set; }
        public string ExamTime4 { get; set; }
        public int Slot { get; set; }
        public int? RollFrom { get; set; }
        public int? RollTo { get; set; }
    }

    public class ExamTimeSchedulesControllerModel4
    {
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
    }

    public class ExamTimeSchedulesControllerModel5
    {
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public List<ExamTimeSchedulesControllerModel3> Output { get; set; }
    }

    public class ExamTimeSchedulesControllerModel6
    {
        public int ExamLevel { get; set; }
        public int SessionYear { get; set; }
        public int MonthId { get; set; }
        public int SubId { get; set; }
    }

    //[Authorize]

    public class ExamTimeSchedulesController : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamTimeSchedulesController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get ExamTime Schedules By Examlevel Monthid and Sessionyear
        /// </summary>
        [HttpPost("GetExamTimeSchedulesByExamlevelMonthidSessionyear")]
        public async Task<ActionResult<ResponseDto2>> GetExamTimeSches2([FromBody] ExamTimeSchedulesControllerModel1 input)
        {
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

            List<ExamTimeSchedulesControllerModel3> query = await (from ets in _context.Set<ExamTimeSch>().Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear)
                                                                   join sub in _context.Set<Subject>()
                                                                       on ets.SubId equals sub.SubId
                                                                   select new ExamTimeSchedulesControllerModel3
                                                                   {
                                                                       OrderNo = ets.OrderNo,
                                                                       SessionYear = ets.SessionYear,
                                                                       MonthId = ets.MonthId,
                                                                       ExamLevel = ets.ExamLevel,
                                                                       SubId = ets.SubId,
                                                                       SubName = sub.SubName,
                                                                       ExamDate = ets.ExamDate,
                                                                       ExamTime1 = ets.ExamTime1,
                                                                       ExamTime2 = ets.ExamTime2,
                                                                       ExamTime3 = ets.ExamTime3,
                                                                       ExamTime4 = ets.ExamTime4,
                                                                       RollFrom = ets.RollFrom,
                                                                       RollTo = ets.RollTo,
                                                                       Slot = ets.Slot ?? 0
                                                                   }).OrderBy(l => l.OrderNo).ToListAsync();

            if (query == null || query.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam time schedule found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            ExamTimeSchedulesControllerModel5 output = new();

            output.ExamLevelName = examLevelSubject.SubName;
            output.MonthName = sessionInfo.SessionName;
            output.Output = query;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam time schedule",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get ExamTime Schedules By Examlevel, Monthid, Sessionyear and Subjectid
        /// </summary>
        [HttpPost("GetExamTimeSchedulesByExamlevelMonthidSessionyearSubjectid")]
        public async Task<ActionResult<ResponseDto2>> GetExamTimeSch([FromBody] ExamTimeSchedulesControllerModel2 input2)
        {
            var examTimeSch = await _context.ExamTimeSches.Where(i => i.ExamLevel == input2.ExamLevel && i.MonthId == input2.MonthId && i.SessionYear == input2.SessionYear && i.SubId == input2.SubId).FirstOrDefaultAsync();

            if (examTimeSch == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam time schedule found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam time schedule info",
                Success = true,
                Payload = examTimeSch
            });
        }

        /// <summary>
        /// Update ExamTime Schedule
        /// </summary>
        [HttpPost("UpdateExamTimeSchedule")]
        public async Task<ActionResult<ResponseDto2>> PutExamTimeSch([FromBody] ExamTimeSch input)
        {
            _context.ChangeTracker.Clear();
            ExamTimeSch examTimeSch1 = await _context.ExamTimeSches.Where(x => x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId && x.Slot == input.Slot && x.OrderNo == input.OrderNo).FirstOrDefaultAsync();

            if (examTimeSch1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam schedule found",
                    Success = false,
                    Payload = null
                });
            }

            examTimeSch1.MonthId = input.MonthId;
            examTimeSch1.OrderNo = input.OrderNo;
            examTimeSch1.RollFrom = input.RollFrom;
            examTimeSch1.RollTo = input.RollTo;
            examTimeSch1.SessionYear = input.SessionYear;
            examTimeSch1.Slot = input.Slot;
            examTimeSch1.SubId = input.SubId;
            examTimeSch1.ExamLevel = input.ExamLevel;
            examTimeSch1.ExamTime1 = input.ExamTime1;
            examTimeSch1.ExamTime2 = input.ExamTime2;
            examTimeSch1.ExamTime3 = input.ExamTime3;
            examTimeSch1.ExamTime4 = input.ExamTime4;

            _context.ExamTimeSches.Update(examTimeSch1);
            int isUpdated = await _context.SaveChangesAsync();

            if (isUpdated > 0)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Exam time schedule info updated successfully",
                    Success = true,
                    Payload = new
                    {
                        Output = examTimeSch1
                    }
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Exam time schedule info updated failed",
                Success = true,
                Payload = new
                {
                    Output = examTimeSch1
                }
            });
        }

        /// <summary>
        /// Create Multiple ExamTime Schedules
        /// </summary>
        [HttpPost("CreateMultipleExamTimeSchedules")]
        public async Task<ActionResult<ResponseDto2>> PostExamTimeSch([FromBody] List<ExamTimeSch> examTimeSches)
        {
            if (examTimeSches == null || examTimeSches.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam time schedule info given for creation",
                    Success = false,
                    Payload = null
                });
            }

            int firstRowExamLevel = examTimeSches.FirstOrDefault().ExamLevel;
            int firstRowMonthId = examTimeSches.FirstOrDefault().MonthId;
            int firstRowSessionYear = examTimeSches.FirstOrDefault().SessionYear;
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in examTimeSches)
                {
                    //if (item.ExamLevel != firstRowExamLevel || item.MonthId != firstRowMonthId || item.SessionYear != firstRowSessionYear || item.ExamDate < DateTime.Today)
                    //{
                    //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    //    {
                    //        Message = "The list of given exam time schedule's common parameters doesn't match",
                    //        Success = false,
                    //        Payload = null
                    //    });
                    //}

                    bool isOrderExists = await _context.ExamTimeSches.AnyAsync(i => i.ExamLevel == item.ExamLevel && i.MonthId == item.MonthId && i.SessionYear == item.SessionYear && i.OrderNo == item.OrderNo);
                    if (isOrderExists == true)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Order number: " + item.OrderNo + " already exists for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    int isOrderExistsInInput = examTimeSches.Count(i => i.ExamLevel == item.ExamLevel && i.MonthId == item.MonthId && i.SessionYear == item.SessionYear && i.OrderNo == item.OrderNo);
                    if (isOrderExistsInInput > 1)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Order number: " + item.OrderNo + " already exists in input for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    //var examTimeSch = await _context.ExamTimeSches.Where(x => x.ExamLevel == item.ExamLevel && x.MonthId == item.MonthId && x.SessionYear == item.SessionYear && x.ExamDate == item.ExamDate).FirstOrDefaultAsync();
                    //if (examTimeSch != null)
                    //{
                    //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    //    {
                    //        Message = "Exam time schedule info already exists for given criteria",
                    //        Success = false,
                    //        Payload = null
                    //    });
                    //}
                }

                foreach (var item in examTimeSches)
                {
                    _context.ExamTimeSches.Add(item);
                    await _context.SaveChangesAsync();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Exam schedule creation failed. Something went wrong, Please try again later.",
                    Success = false,
                    Payload = new
                    {
                        e.StackTrace,
                        e.Message,
                        e.InnerException,
                        e.Source,
                        e.Data
                    }
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam time schedule info created successfully",
                Success = true,
                Payload = new
                {
                    exam_level = firstRowExamLevel,
                    month_id = firstRowMonthId,
                    session_year = firstRowSessionYear
                }
            });
        }

        [HttpDelete("DeleteExamTimeSchedules")]
        public async Task<ActionResult<ResponseDto2>> DeleteExamTimeSch([FromBody] ExamTimeSchedulesControllerModel6 input)
        {
            ExamTimeSch examTimeSch = await _context.ExamTimeSches.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId).FirstOrDefaultAsync();
            if (examTimeSch == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam time schedule info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }
            _context.ExamTimeSches.Remove(examTimeSch);
            bool isRowCountValid = await _context.SaveChangesAsync() > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Exam time schedule info deleted successfully" : "Exam time schedule deletion failed. Something went wrong. Please try again later",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new { input.ExamLevel, input.MonthId, input.SessionYear, input.SubId } : null
            });
        }

        private bool ExamTimeSchExists(int exam_level, int month_id, int session_year, int sub_id)
        {
            return _context.ExamTimeSches.Any(e => e.ExamLevel == exam_level && e.MonthId == month_id && e.SessionYear == session_year && e.SubId == sub_id);
        }
    }
}