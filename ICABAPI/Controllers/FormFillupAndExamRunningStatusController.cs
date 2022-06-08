using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class FormFillupAndExamRunningStatusController : CustomType1ApiController
    {
        public class FormFillupAndExamRunningStatusControllerModel1
        {
            public decimal SessionId { get; set; }
            public string SessionName { get; set; }
            public decimal SessionYear { get; set; }
        }

        public class FormFillupAndExamRunningStatusControllerModel2
        {
            public decimal ExamLevel { get; set; }
        }

        private readonly ModelContext _context;
        public FormFillupAndExamRunningStatusController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Form Fillup And Exam Registration Status
        /// </summary>
        [HttpGet("GetAllFormFillupAndExamRegistrationStatus")]
        public async Task<ActionResult<ResponseDto2>> GetAllFormFillupAndExamRegistrationStatus()
        {
            List<FormFillupAndExamRunningStatus> formFillupAndExamRunningStatuses = await _context.FormFillupAndExamRunningStatuses.OrderByDescending(i => i.SessionYear).ToListAsync();
            bool isRowCountValid = formFillupAndExamRunningStatuses != null && formFillupAndExamRunningStatuses.Count > 0;
            return StatusCode(isRowCountValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid == true ? "List of " + formFillupAndExamRunningStatuses.Count + " form fillup status and exam running status" : "No record found",
                Success = isRowCountValid,
                Payload = isRowCountValid == true ? formFillupAndExamRunningStatuses : null
            });
        }

        /// <summary>
        /// Create Form Fillup And Exam Registration Status
        /// </summary>
        [HttpPost("CreateFormFillupAndExamRegistrationStatus")]
        public async Task<ActionResult<ResponseDto2>> CreateFormFillupAndExamRegistrationStatus([FromBody] FormFillupAndExamRunningStatus input)
        {

            //bool isExamAlreadyRunning = await _context.FormFillupAndExamRunningStatuses.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.ExamRunningStatus == 1);
            //if (isExamAlreadyRunning == true)
            //{
            //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            //    {
            //        Message = "Exam already running for the exam level: " + input.ExamLevel + " Please turn off running exam",
            //        Success = false,
            //        Payload = null
            //    });
            //}
            bool isRowCountValid = false;
            bool isAlreadyExists = await _context.FormFillupAndExamRunningStatuses.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
            if (isAlreadyExists == true)
            {
                _context.FormFillupAndExamRunningStatuses.Update(input);
                isRowCountValid = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.FormFillupAndExamRunningStatuses.Add(input);
                isRowCountValid = await _context.SaveChangesAsync() > 0;
            }

            return StatusCode(isRowCountValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid == true ? "Status created successfully" : "Insert failed",
                Success = isRowCountValid,
                Payload = isRowCountValid == true ? null : null
            });
        }

        /// <summary>
        /// Update Form Fillup And Exam Registration Status
        /// </summary>
        [HttpPost("UpdateFormFillupAndExamRegistrationStatus")]
        public async Task<ActionResult<ResponseDto2>> UpdateFormFillupAndExamRegistrationStatus([FromBody] FormFillupAndExamRunningStatus input)
        {
            FormFillupAndExamRunningStatus getFormFillupAndExamRunningStatus = await _context.FormFillupAndExamRunningStatuses.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();
            FormFillupAndExamRunningStatus backup = new();
            if (getFormFillupAndExamRunningStatus != null)
            {
                backup = getFormFillupAndExamRunningStatus;
                backup.FormFillupStatus = input.FormFillupStatus;
                backup.ExamRunningStatus = input.ExamRunningStatus;
            }
            _context.FormFillupAndExamRunningStatuses.Remove(getFormFillupAndExamRunningStatus);
            await _context.SaveChangesAsync();
            _context.FormFillupAndExamRunningStatuses.Add(backup);
            bool isRowCountValid = await _context.SaveChangesAsync() > 0;
            return StatusCode(isRowCountValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid == true ? "Status updated successfully" : "Update failed",
                Success = isRowCountValid,
                Payload = isRowCountValid == true ? null : null
            });
        }

        /// <summary>
        /// Get Exam Running MonthId And SessionYear By ExamLevel
        /// </summary>
        [HttpPost("GetExamRunningMonthIdAndSessionYearByExamLevel")]
        public async Task<ActionResult<ResponseDto2>> GetExamRunningMonthIdAndSessionYearByExamLevel([FromBody] FormFillupAndExamRunningStatusControllerModel2 input)
        {
            FormFillupAndExamRunningStatus formFillupAndExam = await _context.FormFillupAndExamRunningStatuses.Where(i => i.ExamLevel == input.ExamLevel && i.ExamRunningStatus == 1).FirstOrDefaultAsync();
            if (formFillupAndExam == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam running for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            bool isRowCountValid = formFillupAndExam != null;
            FormFillupAndExamRunningStatusControllerModel1 output = new();

            string monthName = await _context.SessionInfos.Where(i => i.SessionId == formFillupAndExam.MonthId).Select(o => o.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id does not exists",
                    Success = false,
                    Payload = null
                });
            }

            if (isRowCountValid == true)
            {
                output.SessionId = formFillupAndExam.MonthId;
                output.SessionName = monthName;
                output.SessionYear = formFillupAndExam.SessionYear;
            }

            return StatusCode(isRowCountValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid == true ? "Status found successfully" : "Find failed",
                Success = isRowCountValid,
                Payload = isRowCountValid == true ? output : null
            });
        }
    }
}