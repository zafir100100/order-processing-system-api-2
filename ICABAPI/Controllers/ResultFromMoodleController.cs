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
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ICABAPI.Interfaces;
using System.Xml;
using System.Globalization;

namespace ICABAPI.Controllers
{
    public class InputForGetResultFromMoodle
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public string UserId { get; set; }
    }
    public class ResultFromMoodleController : CustomType1ApiController
    {
        private readonly IGetResultFromMoodleService _getResultFromMoodleService;
        private readonly ModelContext _context;

        public ResultFromMoodleController(IGetResultFromMoodleService resultFromMoodleService, ModelContext context)
        {
            _getResultFromMoodleService = resultFromMoodleService;
            _context = context;
        }

        [HttpPost("ConsumeResult2TestPurpose")]
        public async Task<ActionResult<ResponseDto2>> GetResultFromMoodle1()
        {
            //SingleUserFromMoodle user = await _getResultFromMoodleService.GetSingleUserFromMoodle(205);

            List<CourseGrades> grades = await _getResultFromMoodleService.GetCourseGrades(199);

            if (grades.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Grades not found",
                    Success = false,
                    Payload = grades
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Moodle",
                Success = false,
                Payload = grades
            });
        }

        [HttpPut("IsDataExistsInBarcodeAllotForCurrentExam")]
        public async Task<ActionResult<ResponseDto2>> IsDataExistsInBarcodeAllotForCurrentExam([FromBody] InputForGetResultFromMoodle input)
        {
            //bool isExists = await _context.gr
            if (input.ExamLevel != 61)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("here is el " + input.ExamLevel);
            //System.Diagnostics.Debug.WriteLine("here is elname " + examLevelName);
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level does not exists",
                    Success = false,
                    Payload = null
                });
            }
            string monthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id does not exists",
                    Success = false,
                    Payload = null
                });
            }

            bool isEx = await _context.BarcodeAllots.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).AnyAsync();

            return StatusCode(isEx == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isEx == true ? "Data already exists" : "No data found",
                Success = isEx,
                Payload = isEx == true ? null : null
            });
        }

        [HttpPut("ConsumeResult")]
        public async Task<ActionResult<ResponseDto2>> GetResultFromMoodle([FromBody] InputForGetResultFromMoodle input)
        {
            //bool isExists = await _context.gr
            if (input.ExamLevel != 61)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("here is el " + input.ExamLevel);
            //System.Diagnostics.Debug.WriteLine("here is elname " + examLevelName);
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level does not exists",
                    Success = false,
                    Payload = null
                });
            }
            string monthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id does not exists",
                    Success = false,
                    Payload = null
                });
            }
            bool isBarcodeSequenceExists = await _context.Barseqs.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);

            if (isBarcodeSequenceExists == false)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "No barcode sequence exists for " + examLevelName + ", " + monthName + ", " + input.SessionYear + ". Please enter sequency and try again",
                    Success = false,
                    Payload = null
                });
            }

            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToListAsync();

            foreach (var item in subjects)
            {
                bool gradeSy = await _context.GradeSys.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == item.SubId);

                if (gradeSy == false)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Grade system select for  " + examLevelName + ", " + monthName + ", " + input.SessionYear + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync() + ". Please add grade system and try again",
                        Success = false,
                        Payload = null
                    });
                }

            }

            int MaxBarcodeFromBarseqTable = await _context.Barseqs.MaxAsync(i => i.Barto) ?? 0;
            int MaxBarcodeFromMarksAllot = await _context.MarksAllots.MaxAsync(i => i.BarCode) ?? 0;


            if (MaxBarcodeFromMarksAllot > MaxBarcodeFromBarseqTable)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Marks alloted barcode limit crossed! Please raise the limit and try again for" + examLevelName + ", " + monthName + ", " + input.SessionYear + ". Please raise the limit and try again",
                    Success = false,
                    Payload = null
                });
            }

            //get all moodle cohort
            //List<MoodleCohort> moodleCohort = await _context.MoodleCohorts.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).ToListAsync();
            List<string> UserList = await _context.MoodleCohorts.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(x => x.Username).Distinct().ToListAsync();
            //get all moodle to ICAB subject mapping
            List<CourseListFromMoodle> courseList = await _getResultFromMoodleService.GetCourseListFromMoodles();
            if (courseList.Count < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Moodle to ICAB subject mapping not found",
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                List<SingleUserFromMoodle> users = new();
                if (UserList.Count > 0)
                {
                    //Barseq barsq = 
                    int maxBarcode = (await _context.Barseqs.Where(x => x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear).MaxAsync(i => i.Barfrom) ?? 0) + 1;
                    int limitBarcode = await _context.Barseqs.Where(x => x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear).Select(i => i.Barto).FirstOrDefaultAsync() ?? 0;


                    //List<int> gg = new();

                    foreach (var item in UserList)
                    {
                        bool isUsed = await _context.BarcodeAllots.AnyAsync(i => i.BarCode == maxBarcode && i.ExamLevel != input.ExamLevel && i.MonthId != input.MonthId && i.SessionYear != input.SessionYear);
                        if (isUsed == true)
                        {
                            return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                            {
                                Message = "Duplicate barcode found, Please use new series of barcode",
                                Success = false,
                                Payload = new
                                {
                                    BarCode = maxBarcode
                                }
                            });
                        }
                        if (item != null)
                        {
                            int regNo = Convert.ToInt32(item);
                            //if (gg.Contains(regNo))
                            //{
                            //    continue;
                            //}
                            //else
                            //{
                            //    gg.Add(regNo);
                            //}
                            if (regNo != 0)
                            {
                                //get moodle user id for each regNo
                                SingleUserFromMoodle user = await _getResultFromMoodleService.GetSingleUserFromMoodle(regNo);
                                if (user != null)
                                {
                                    users.Add(user);
                                    //for each moodle user id (regNo) get their grade
                                    List<CourseGrades> grades = await _getResultFromMoodleService.GetCourseGrades(Convert.ToInt32(user.MoodleUserId));
                                    if (grades.Count > 0)
                                    {
                                        foreach (var element in grades)
                                        {
                                            if (maxBarcode > limitBarcode)
                                            {
                                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                                {
                                                    Message = "Assigned barcode limit crossed for " + examLevelName + ", " + monthName + ", " + input.SessionYear + ". Please raise the limit and try again",
                                                    Success = false,
                                                    Payload = null
                                                });
                                            }
                                            int? j = Convert.ToInt32(courseList.Where(i => i.CourseIdFromMoodle == element.Courseid).Select(j => j.CourseIdNumber).FirstOrDefault());
                                            if (j == null)
                                            {
                                                continue;
                                            }
                                            BarcodeAllot isExists = _context.BarcodeAllots.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == j && i.RegNo == regNo).FirstOrDefault();
                                            if (isExists != null)
                                            {
                                                MarksAllot isExists2 = _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == j && i.Examiner == j && i.BarCode == isExists.BarCode).FirstOrDefault();
                                                if (isExists2 != null)
                                                {
                                                    _context.BarcodeAllots.Remove(isExists);
                                                    int ok1 = await _context.SaveChangesAsync();
                                                    _context.MarksAllots.Remove(isExists2);
                                                    int ok2 = await _context.SaveChangesAsync();
                                                }
                                            }
                                            //Save the moodle user id (regNo) to barcode allot
                                            BarcodeAllot barcodeAllot = new();
                                            barcodeAllot.BarCode = maxBarcode;//(await _context.Barseqs.MaxAsync(i => i.Barto) ?? 0) + 1;
                                            barcodeAllot.ExamLevel = input.ExamLevel;
                                            barcodeAllot.MonthId = input.MonthId;
                                            barcodeAllot.SessionYear = input.SessionYear;
                                            barcodeAllot.RegNo = regNo;
                                            barcodeAllot.SubId = Convert.ToInt32(courseList.Where(i => i.CourseIdFromMoodle == element.Courseid).Select(j => j.CourseIdNumber).FirstOrDefault());//from sub mapping
                                            barcodeAllot.UdSlno = 0;
                                            barcodeAllot.ExamRollno = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RegNo == regNo).Select(j => j.ExamRollno).FirstOrDefaultAsync();
                                            if (barcodeAllot.ExamRollno == 0 || barcodeAllot.ExamRollno == null)
                                            {
                                                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                                                {
                                                    Message = "Roll number not assigned . Please add roll number and try again",
                                                    Success = false,
                                                    Payload = null
                                                });
                                            }
                                            barcodeAllot.UserId = input.UserId;
                                            if (barcodeAllot.SubId == 0)
                                            {
                                                continue;
                                            }
                                            else if (element.Grade == "" || element.Grade == "-" || element.Grade == null)
                                            {
                                                continue;
                                            }
                                            else
                                            {

                                                GradeSy gradeSy = await _context.GradeSys.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == barcodeAllot.SubId).FirstOrDefaultAsync();
                                                //if (gradeSy != null)
                                                //{
                                                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(i => i.RefNo == gradeSy.RefNo).ToListAsync();
                                                if (gradeDetails.Count > 0)
                                                {
                                                    MarksAllot marksAllot = new();
                                                    marksAllot.BarCode = barcodeAllot.BarCode;
                                                    marksAllot.Entryuser = input.UserId;
                                                    marksAllot.Examiner = barcodeAllot.SubId;
                                                    marksAllot.MonthId = input.MonthId;
                                                    marksAllot.SessionYear = input.SessionYear;
                                                    marksAllot.SubId = barcodeAllot.SubId;
                                                    int sub = marksAllot.SubId ?? 0;
                                                    //list.Add(barcodeAllot.SubId ?? 0);
                                                    marksAllot.Scriptsl = (_context.VwMarksfinals.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == barcodeAllot.SubId).Max(j => j.Scriptsl) ?? 0) + 1;
                                                    marksAllot.Outmarks = await _context.Subjects.Where(i => i.SubId == marksAllot.SubId).Select(o => o.Outofmarks).FirstOrDefaultAsync();
                                                    marksAllot.Grace = null;
                                                    decimal k = 0;
                                                    if (element.Grade == "" || element.Grade == "-" || element.Grade == null)
                                                    {

                                                    }
                                                    else
                                                    {
                                                        decimal.TryParse(element.Grade, out k);
                                                    }

                                                    //System.Diagnostics.Debug.WriteLine("trace 4: " + decimal.Parse(element.Grade));
                                                    marksAllot.Marks = CustomRoundUpForPositiveDecimal(k);//Convert.ToDecimal(element.Grade);
                                                    //System.Diagnostics.Debug.WriteLine("trace 5: " + marksAllot.Marks);
                                                    if (await _context.GradeSys.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear) == false)
                                                    {
                                                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                                                        {
                                                            Message = "No Grade system select for  " + examLevelName + ", " + monthName + ", " + input.SessionYear + await _context.Subjects.Where(i => i.SubId == barcodeAllot.SubId).Select(o => o.SubName).FirstOrDefaultAsync() + ". Please add grade system and try again",
                                                            Success = false,
                                                            Payload = null
                                                        });
                                                    }
                                                    decimal? dj = marksAllot.Outmarks == 50 ? (marksAllot.Marks * 2) : marksAllot.Marks;
                                                    marksAllot.Grade = gradeDetails.Where(i => i.RefNo == gradeSy.RefNo && dj >= i.StartingMarks && dj <= i.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();

                                                    _context.BarcodeAllots.Add(barcodeAllot);
                                                    await _context.SaveChangesAsync();

                                                    _context.MarksAllots.Add(marksAllot);
                                                    await _context.SaveChangesAsync();

                                                    maxBarcode++;
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Insertion failed. Something went wrong, Please try again later.",
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
                Message = "Data Inserted from moodle",
                Success = true,
                Payload = null
            });
        }

        private static decimal CustomRoundUpForPositiveDecimal(decimal myNumber)
        {
            double convertMyNumberToDouble = Convert.ToDouble(myNumber);
            double integerMyNumberToDouble = Math.Truncate(convertMyNumberToDouble);

            double finalMyNumberToDouble;

            if ((convertMyNumberToDouble - integerMyNumberToDouble) >= 0.5)
            {
                finalMyNumberToDouble = integerMyNumberToDouble + 1;
            }
            else
            {
                finalMyNumberToDouble = integerMyNumberToDouble;
            }

            decimal myRoundUpNumber = Convert.ToDecimal(finalMyNumberToDouble);

            return myRoundUpNumber;
        }
    }
}
