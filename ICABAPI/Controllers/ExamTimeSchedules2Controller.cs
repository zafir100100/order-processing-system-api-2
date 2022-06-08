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
    public class InputForGetExamTimeTable
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }
    public class OutputForGetExamTimeTable
    {
        public string SubName { get; set; }
        public int SubId { get; set; }
        public int Slot { get; set; }
        public int OrderNo { get; set; }
        public string ExamTime1 { get; set; }
        public string ExamTime2 { get; set; }
        public string ExamTime3 { get; set; }
        public string ExamTime4 { get; set; }
    }
    public class OutputForGetExamTimeTableFinalResponse
    {
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public List<OutputForGetExamTimeTable> Output { get; set; }
    }

    //[Authorize]

    public class ExamTimeSchedules2Controller : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamTimeSchedules2Controller(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get ExamTime Schedules By Examlevel Monthid and Sessionyear
        /// </summary>
        [HttpPost("GetExamTimeTable")]
        public async Task<ActionResult<ResponseDto2>> GetExamTimeTable([FromBody] InputForGetExamTimeTable input)
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
                                                                       Slot = ets.Slot ?? 0
                                                                   }).OrderBy(l => l.ExamDate).ThenBy(O => O.Slot).ToListAsync();

            if (query == null || query.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam time schedule found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<OutputForGetExamTimeTableFinalResponse> output = new();
            bool isFound = query.Count > 0;
            if (isFound == true)
            {
                var dateList = query.Select(i => i.ExamDate).Distinct().ToList();
                if (dateList.Count > 0)
                {
                    foreach (var item in dateList)
                    {
                        OutputForGetExamTimeTableFinalResponse output1 = new();
                        output1.Date = item;
                        output1.Day = item.ToString("dddd");
                        var getQueryByDate = query.Where(i => i.ExamDate == item).ToList();
                        if (getQueryByDate.Count > 0)
                        {
                            List<OutputForGetExamTimeTable> output2 = new();
                            foreach (var element in getQueryByDate)
                            {
                                OutputForGetExamTimeTable output3 = new();
                                output3.ExamTime1 = element.ExamTime1;
                                output3.ExamTime2 = element.ExamTime2;
                                output3.ExamTime3 = element.ExamTime3;
                                output3.ExamTime4 = element.ExamTime4;
                                output3.SubName = element.SubName;
                                output3.SubId = element.SubId;
                                output3.Slot = element.Slot;
                                output3.OrderNo = element.OrderNo;
                                System.Diagnostics.Debug.WriteLine("This is my code: " + output3.SubName);
                                System.Diagnostics.Debug.WriteLine("This is my code: " + output3.ExamTime1);
                                System.Diagnostics.Debug.WriteLine("This is my code: " + output3.ExamTime2);
                                output2.Add(output3);
                            }
                            output1.Output = output2;
                        }
                        output.Add(output1);
                    }
                }
            }

            return StatusCode(isFound == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isFound == true ? "List of exam time schedule" : "No data found",
                Success = isFound,
                Payload = isFound == true ? output : null
            });
        }
    }
}