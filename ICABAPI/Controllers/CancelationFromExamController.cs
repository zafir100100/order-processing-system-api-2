using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ICABAPI.Data.MarksRepository;

namespace ICABAPI.Controllers
{
    public class CancelationFromExamModel1
    {
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
    }

    public class CancelationFromExamModel2
    {
        public int RegNo { get; set; }
        public int? ExamRollno { get; set; }
        public string Name { get; set; }
    }

    public class CancelationFromExamModel3
    {
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
    }

    public class CancelationFromExamModel4: StuCancel
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string FirmName { get; set; }
        public string PrinName { get; set; }
    }
    [Authorize]
    public class CancelationFromExamController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public CancelationFromExamController(ModelContext context)
        {
            _context = context;
        }

        //[HttpPost("GetStudentInfo")]
        //public async Task<ActionResult<ResponseDto2>> GetStudent([FromBody] CancelationFromExamModel1 input)
        //{
        //    if (input.ExamLevel == null || input.ExamLevel < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Exam level can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    if (input.MonthId == null || input.MonthId < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Month id can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    if (input.SessionYear == null || input.SessionYear < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Session year can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    if (input.RegNo == null && input.ExamRollno == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Either registration number or roll number must be provided",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
        //    if (GetExamLevelName == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "Exam level name not found for exam level: " + input.ExamLevel,
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
        //    if (GetMonthName == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "Month name not found for month id: " + input.MonthId,
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    ExamReg examReg = new();

        //    if (input.RegNo != null && input.ExamRollno == null)
        //    {
        //        examReg = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RegNo == input.ExamRollno).FirstOrDefaultAsync();
        //    }

        //    if (input.RegNo == null && input.ExamRollno != null)
        //    {
        //        examReg = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RegNo == input.RegNo).FirstOrDefaultAsync();
        //    }

        //    if (examReg == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "No info found in exam registration for given criteria",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    StuReg1 stuReg1 = new();

        //    if (examReg != null)
        //    {
        //        stuReg1 = await _context.StuReg1s.Where(u => u.RegNo == examReg.RegNo).FirstOrDefaultAsync();
        //    }

        //    if (stuReg1 == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "No info found in student registration for given criteria",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    CancelationFromExamModel2 output = new();

        //    output.RegNo = stuReg1.RegNo;

        //    output.ExamRollno = examReg.ExamRollno;

        //    output.Name = stuReg1.Name;


        //    bool isRowCountValid = (examReg != null) && (stuReg1 != null);

        //    return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
        //    {
        //        Message = isRowCountValid ? "Student info for cancelation from exam" : "No marks info found for given criteria",
        //        Success = isRowCountValid,
        //        Payload = isRowCountValid ? output : null
        //    });
        //}

        /// <summary>
        /// Get Student Cancelation Info
        /// </summary>
        [HttpPost("GetStudentCancelationInfo")]
        public async Task<ActionResult<ResponseDto2>> GetStudentCancelationInfo([FromBody] CancelationFromExamModel3 input)
        {
            if (input.ExamLevel == null || input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MonthId == null || input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear == null || input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null",
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

            List<StuCancel> stuCancels = await _context.StuCancels.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).ToListAsync();

            if(stuCancels == null || stuCancels.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found in cancelation from exam for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<CancelationFromExamModel4> output = new();

            foreach (var item in stuCancels)
            {
                CancelationFromExamModel4 outp = new();

                outp.Id = item.Id;
                outp.RegNo = item.RegNo;
                //outp.ExamRollno = item.ExamRollno;
                outp.ExamLevel = item.ExamLevel;
                outp.SessionYear = item.SessionYear;
                outp.MonthId = item.MonthId;
                outp.Periodfrom = item.Periodfrom;
                outp.Periodto = item.Periodto;
                outp.CancellationDate = item.CancellationDate;
                outp.WithdrawnDate = item.WithdrawnDate;
                outp.CwReason = item.CwReason;
                outp.CwFlag = item.CwFlag;

                outp.Name = await _context.StuReg1s.Where(i => i.RegNo == item.RegNo).Select(l => l.Name).FirstOrDefaultAsync();
                outp.FName = await _context.StuReg1s.Where(i => i.RegNo == item.RegNo).Select(l => l.FName).FirstOrDefaultAsync();
                outp.PrinName = await _context.StuReg1s.Where(i => i.RegNo == item.RegNo).Select(l => l.PrinName).FirstOrDefaultAsync();
                outp.FirmName = await _context.StuReg1s.Where(i => i.RegNo == item.RegNo).Select(l => l.FirmName).FirstOrDefaultAsync();

                output.Add(outp);
            }

            bool isRowCountValid = stuCancels.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "List of student info for cancelation from exam" : "No info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Create Student for Cancelation
        /// </summary>
        [HttpPost("CreateStudent")]
        public async Task<ActionResult<ResponseDto2>> CreateStudent([FromBody] StuCancel input)
        {
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

            if (input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            //if (input.ExamRollno < 1)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Roll number can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

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

            input.Id = (await _context.StuCancels.MaxAsync(j => j.Id)) + 1;

            int rowCount = 0;

            _context.StuCancels.Add(input);
            rowCount = +await _context.SaveChangesAsync();

            bool isRowCountValid = rowCount > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "Student info created for cancelation from exam" : "Student info creation failed for cancelation from exam. Something went wrong. Please try again later.",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new { input.RegNo } : null
            });
        }

        /// <summary>
        /// Update Existing Student for Cancelation
        /// </summary>
        [HttpPost("UpdateStudent")]
        public async Task<ActionResult<ResponseDto2>> UpdateStudent([FromBody] StuCancel input)
        {
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

            if (input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            //if (input.ExamRollno < 1)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Roll number can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

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

            int rowCount = 0;

            _context.StuCancels.Update(input);
            rowCount = +await _context.SaveChangesAsync();

            bool isRowCountValid = rowCount > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "Student info updated for cancelation from exam" : "Student info update failed for cancelation from exam. Something went wrong. Please try again later.",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new { input.RegNo } : null
            });
        }
    }
}