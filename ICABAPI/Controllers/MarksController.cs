using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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
    //[Authorize]
    public class MarksController : CustomType1ApiController
    {
        private readonly ModelContext _context;
        private readonly IMarks _marks;

        public MarksController(ModelContext context, IMarks marks)
        {
            _context = context;
            _marks = marks;
        }

        /// <summary>
        /// Get Candidate Search With Bar code Report
        /// </summary>
        [HttpPost("GetCandidateSearchWithBarcodeReport")]
        public async Task<ActionResult<ResponseDto2>> GetCandidateSearchWithBarcodeReport([FromBody] MarksModel18 input)
        {
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

            string GetSubjectName = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(l => l.SubName).FirstOrDefaultAsync();
            if (GetSubjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            MarksAllot marksAllot = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId && i.BarCode == input.BarCode).FirstOrDefaultAsync();

            if (marksAllot == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks info found in marks allot for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            BarcodeAllot barcodeAllot = await _context.BarcodeAllots.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear && o.SubId == input.SubId && o.BarCode == marksAllot.BarCode).FirstOrDefaultAsync();

            if (barcodeAllot == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No info found in barcode allot for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            StuReg1 stuReg1 = await _context.StuReg1s.Where(o => o.RegNo == barcodeAllot.RegNo).FirstOrDefaultAsync();

            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No info found in student registration for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isRowCountValid = marksAllot != null;

            MarksModel21 marksModel21 = new();

            if (isRowCountValid == true)
            {
                marksModel21.RegNo = stuReg1.RegNo;
                marksModel21.ExamRollno = barcodeAllot.ExamRollno;
                marksModel21.Name = stuReg1.Name;
                marksModel21.FName = stuReg1.FName;
                marksModel21.MName = stuReg1.MName;
                marksModel21.PrincipalName = stuReg1.PrinName;
                marksModel21.FirmName = stuReg1.FirmName;
            }

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Candidate search with barcode result" : "No marks info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? marksModel21 : null
            });
        }

        /// <summary>
        /// Get check out of marks Report
        /// </summary>
        [HttpPost("GetCheckOutOfMarksReport")]
        public async Task<ActionResult<ResponseDto2>> GetCheckOutOfMarksReport([FromBody] MarksModel5 input)
        {
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

            string GetSubjectName = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(l => l.SubName).FirstOrDefaultAsync();
            if (GetSubjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }
            List<MarksAllot> marksAllots = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId).ToListAsync();
            List<MarksModel20> marksModel20s = new();

            int rowCount = marksAllots.Count;

            bool isRowCountValid = rowCount > 0;

            if (isRowCountValid == true)
            {
                marksModel20s = (from ma in marksAllots
                                 select new MarksModel20
                                 {
                                     ExamLevelName = GetExamLevelName,
                                     MonthName = GetMonthName,
                                     SubjectName = GetSubjectName,
                                     Examiner = ma.Examiner,
                                     Scriptsl = ma.Scriptsl,
                                     BarCode = ma.BarCode,
                                     Marks = ma.Marks ?? 0,
                                     Outmarks = ma.Outmarks
                                 }
                               ).OrderBy(i => i.Examiner).ThenBy(x => x.Scriptsl).ToList();
            }

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "List of subject wise marks for check out of marks report" : "No marks info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? marksModel20s : null
            });
        }

        // 5.6 + 5.7
        /// <summary>
        /// Get Grace Report
        /// </summary>
        [HttpPost("GetGraceReport")]
        public async Task<ActionResult<ResponseDto2>> GetGraceReport([FromBody] MarksModel5 input)
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
                    Message = "Session Year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Subject elsubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (elsubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level info found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month info found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId == 0)
            {
                List<MarksModel25> outputs = new();
                List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(o => o.SubId).ToListAsync();
                if (subjects != null && subjects.Count > 0)
                {
                    foreach (var item in subjects)
                    {
                        MarksModel25 op1 = new();
                        op1.SubId = item.SubId;
                        op1.SubName = item.SubName;
                        List<MarksAllot> marksAllotss = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == item.SubId && i.Grace != null && i.Grace > 0).OrderBy(p => p.Examiner).ThenBy(l => l.Scriptsl).ToListAsync();
                        //System.Diagnostics.Debug.WriteLine("here is count " + marksAllotss.Count + " for subject " + item.SubId + " " + item.SubName);
                        int rowCounts = marksAllotss.Count;
                        bool isRowFoundss = rowCounts > 0;

                        List<MarksModel17> outputss = new();

                        if (isRowFoundss == true)
                        {
                            foreach (var items in marksAllotss)
                            {
                                MarksModel17 marksModel17 = new();
                                marksModel17.ExamLevelName = elsubject.SubName;
                                marksModel17.MonthName = sessionInfo.SessionName;
                                marksModel17.SubjectName = item.SubName;
                                marksModel17.Examiner = items.Examiner;
                                marksModel17.Scriptsl = items.Scriptsl;
                                marksModel17.BarCode = items.BarCode;
                                marksModel17.Marks = items.Marks;
                                marksModel17.Grace = items.Grace;
                                marksModel17.TotalMarks = (items.Marks ?? 0) + (items.Grace ?? 0);
                                outputss.Add(marksModel17);
                            }
                        }
                        op1.MarksDetails = outputss;
                        outputs.Add(op1);
                    }
                }
                bool isRowFounds = outputs.Count > 0;
                return StatusCode(isRowFounds ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = isRowFounds ? "List of " + outputs.Count + " Subject wise Marks info for subject wise grace report" : "No marks info found for given criteria",
                    Success = isRowFounds,
                    Payload = isRowFounds ? new
                    {
                        ExamLevelName = elsubject.SubName,
                        MonthName = sessionInfo.SessionName,
                        Output = outputs
                    } : null
                });
            }

            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject info found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            List<MarksAllot> marksAllots = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId && (i.Grace != null && i.Grace > 0)).OrderBy(p => p.Examiner).ThenBy(l => l.Scriptsl).ToListAsync();
            int rowCount = marksAllots.Count;
            bool isRowFound = rowCount > 0;

            List<MarksModel17> output = new();

            if (isRowFound == true)
            {
                foreach (var item in marksAllots)
                {
                    MarksModel17 marksModel17 = new();
                    marksModel17.ExamLevelName = elsubject.SubName;
                    marksModel17.MonthName = sessionInfo.SessionName;
                    marksModel17.SubjectName = subject.SubName;
                    marksModel17.Examiner = item.Examiner;
                    marksModel17.Scriptsl = item.Scriptsl;
                    marksModel17.BarCode = item.BarCode;
                    marksModel17.Marks = item.Marks;
                    marksModel17.Grace = item.Grace;
                    marksModel17.TotalMarks = (item.Marks ?? 0) + (item.Grace ?? 0);
                    output.Add(marksModel17);
                }
            }

            return StatusCode(isRowFound ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowFound ? "List of " + output.Count + " Marks info for subject wise grace report" : "No marks info found for given criteria",
                Success = isRowFound,
                Payload = isRowFound ? new
                {
                    ExamLevelName = elsubject.SubName,
                    MonthName = sessionInfo.SessionName,
                    Output = output
                } : null
            });
        }

        /// <summary>
        /// Get null check Report
        /// </summary>
        [HttpPost("GetNullCheckReport")]
        public async Task<ActionResult<ResponseDto2>> GetNullCheckReport([FromBody] MarksModel5 input)
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
                    Message = "Session Year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Subject elsubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (elsubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level info found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month info found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject info found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            List<MarksAllot> marksAllots = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId && (i.Marks == null || i.Marks <= 0)).ToListAsync();
            int rowCount = marksAllots.Count;
            bool isRowFound = rowCount > 0;

            List<MarksModel15> output = new();

            if (isRowFound == true)
            {
                int slNoCount = 1;
                foreach (var item in marksAllots)
                {
                    MarksModel15 marksModel15 = new();
                    marksModel15.ExamLevelName = elsubject.SubName;
                    marksModel15.MonthName = sessionInfo.SessionName;
                    marksModel15.SubjectName = subject.SubName;
                    marksModel15.SlNo = slNoCount;
                    BarcodeAllot barcodeAllot = await _context.BarcodeAllots.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear && o.SubId == input.SubId && o.BarCode == item.BarCode).FirstOrDefaultAsync();
                    marksModel15.RollNo = barcodeAllot.ExamRollno ?? 0;
                    marksModel15.RegNo = barcodeAllot.RegNo ?? 0;
                    marksModel15.BarCode = item.BarCode ?? 0;
                    output.Add(marksModel15);
                    slNoCount++;
                }
            }

            return StatusCode(isRowFound ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowFound ? "List of Marks info for null check report" : "No marks info found for given criteria",
                Success = isRowFound,
                Payload = isRowFound ? output : null
            });
        }

        /// <summary>
        /// Update Single marks edit
        /// </summary>
        [HttpPost("UpdateSingleMarksEdit")]
        public async Task<ActionResult<ResponseDto2>> UpdateSingleMarksEdit([FromBody] MarksModel22 input)
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
                    Message = "Session Year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Marks == null || input.Marks < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Marks can not be null or negative",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Grace < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Grace can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            Subject elsubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (elsubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level info found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month info found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject info found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            if (input.Grace < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Grace can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            ResultLock resultLock = await _context.ResultLocks.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.RLock == 1).FirstOrDefaultAsync();
            if (resultLock != null && resultLock.RLock == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result cannot be updated because result is locked for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            MarksAllot ma = await _context.MarksAllots.Where(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId && k.BarCode == input.BarCode).FirstOrDefaultAsync();
            if (ma == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //bool isMarksIncreased = (input.Marks ?? 0) >= (ma.Marks ?? 0);
            ma.Scriptsl = (input.Scriptsl ?? 0);
            ma.Marks = (input.Marks ?? 0);
            ma.Grace = input.Grace ?? 0;
            ma.Entryuser = input.Entryuser;

            decimal outmarks = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(g => g.Outofmarks).FirstOrDefaultAsync();

            decimal multiplier = 1;

            if (outmarks < 100 && outmarks != 0)
            {
                multiplier = 100 / outmarks;

                double convertTotalMarks = Convert.ToDouble((ma.Marks ?? 0));
                double integerTotalMarks = Math.Truncate(convertTotalMarks);
                double finalTotalMarks = 0;
                if ((convertTotalMarks - integerTotalMarks) >= 0.5)
                {
                    finalTotalMarks = integerTotalMarks + 1;
                }
                else
                {
                    finalTotalMarks = integerTotalMarks;
                }
                decimal totalMarks = Convert.ToDecimal(finalTotalMarks);
                int? refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();

                if (refNo == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No grade reference number found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

                if (gradeDetails == null || gradeDetails.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No grade details found for grade reference number: " + refNo,
                        Success = false,
                        Payload = null
                    });
                }

                ma.Grade = gradeDetails.Where(g => (totalMarks * multiplier) >= g.StartingMarks && (totalMarks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            }
            else
            {
                double convertTotalMarks = Convert.ToDouble(ma.Marks ?? 0);
                double integerTotalMarks = Math.Truncate(convertTotalMarks);
                double finalTotalMarks = 0;
                if ((convertTotalMarks - integerTotalMarks) >= 0.5)
                {
                    finalTotalMarks = integerTotalMarks + 1;
                }
                else
                {
                    finalTotalMarks = integerTotalMarks;
                }
                decimal totalMarks = Convert.ToDecimal(finalTotalMarks);
                int? refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();

                if (refNo == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No grade reference number found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

                if (gradeDetails == null || gradeDetails.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No grade details found for grade reference number: " + refNo,
                        Success = false,
                        Payload = null
                    });
                }

                ma.Grade = gradeDetails.Where(g => totalMarks >= g.StartingMarks && totalMarks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            }

            int rowCount = 0;
            _context.MarksAllots.Update(ma);
            rowCount = +await _context.SaveChangesAsync();

            MarksAllotEdit marksAllotEdit = new();
            marksAllotEdit.SessionYear = ma.SessionYear;
            marksAllotEdit.MonthId = ma.MonthId;
            marksAllotEdit.SubId = ma.SubId;
            marksAllotEdit.BarCode = ma.BarCode;
            marksAllotEdit.Examiner = ma.Examiner;
            marksAllotEdit.Scriptsl = ma.Scriptsl;
            marksAllotEdit.Outmarks = ma.Outmarks;
            marksAllotEdit.Marks = ma.Marks;
            marksAllotEdit.Grade = ma.Grade;
            marksAllotEdit.Grace = ma.Grace;
            marksAllotEdit.Entryuser = ma.Entryuser;
            marksAllotEdit.ChangeMood = 1;
            marksAllotEdit.TrackId = (await _context.MarksAllotEdits.MaxAsync(i => i.TrackId) ?? 0) + 1;
            marksAllotEdit.ChangeDate = DateTime.Now;
            marksAllotEdit.ChangeTime = DateTime.Now.ToString(@"hh:mm tt", new CultureInfo("en-US"));
            marksAllotEdit.EditDelete = "EDIT";
            marksAllotEdit.ChangeUser = ma.Entryuser;
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            string ip = addr[addr.Length - 1].ToString();
            marksAllotEdit.PcInfo = ip;
            _context.MarksAllotEdits.Add(marksAllotEdit);
            await _context.SaveChangesAsync();

            bool isRowCountValid = rowCount > 0;
            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "Subject wise single marks update completed successfully" : "Subject wise single marks update failed. Something went wrong. Please try again later",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new { rowCount } : null
            });
        }

        /// <summary>
        /// Update Multiple Marks Edit
        /// </summary>
        [HttpPost("UpdateMultipleMarksEdit")]
        public async Task<ActionResult<ResponseDto2>> UpdateMultipleMarksEdit([FromBody] MarksModel12 input)
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
                    Message = "Session Year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Subject elsubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (elsubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level info found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month info found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject info found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            ResultLock resultLock = await _context.ResultLocks.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.RLock == 1).FirstOrDefaultAsync();
            if (resultLock != null && resultLock.RLock == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result cannot be updated because result is locked for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            if (input.ChangeType == 3)
            {
                if (input.RefNo == null || input.RefNo < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Reference number can not be null",
                        Success = false,
                        Payload = null
                    });
                }

                GradeDetail gradeDetail = await _context.GradeDetails.Where(o => o.RefNo == input.RefNo).FirstOrDefaultAsync();

                if (gradeDetail == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "No grade detail info found for reference number: " + input.RefNo,
                        Success = false,
                        Payload = null
                    });
                }
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (input.ChangeType == 3)
                {
                    GradeSysChanged gradeSysChanged = new();
                    gradeSysChanged.ExamLevel = input.ExamLevel;
                    gradeSysChanged.SessionYear = input.SessionYear;
                    gradeSysChanged.MonthId = input.MonthId;
                    gradeSysChanged.RefNo = input.RefNo;
                    gradeSysChanged.SubId = input.SubId;
                    gradeSysChanged.ChangeReason = input.ChangeReason;
                    gradeSysChanged.ChangeUser = input.Entryuser;
                    gradeSysChanged.TrackId = (await _context.MarksAllotEdits.MaxAsync(l => l.TrackId) ?? 0) + 1;
                    gradeSysChanged.ChangeDate = DateTime.Today;
                    gradeSysChanged.Time = DateTime.Now.ToString("HH") + "_" + DateTime.Now.ToString("mm") + "_" + DateTime.Now.ToString("ss");
                    _context.GradeSysChangeds.Add(gradeSysChanged);
                    await _context.SaveChangesAsync();

                    GradeSy gradeSy = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).FirstOrDefaultAsync();
                    gradeSy.RefNo = input.RefNo ?? 0;
                    _context.GradeSys.Update(gradeSy);
                    await _context.SaveChangesAsync();
                }

                List<MarksAllot> marksAllotsDelete = await _context.MarksAllots.Where(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).ToListAsync();
                List<MarksAllot> marksAllotsDeleteBackup = marksAllotsDelete;

                foreach (var item in marksAllotsDeleteBackup)
                {
                    MarksAllotEdit marksAllotEdit = new();
                    marksAllotEdit.SessionYear = input.SessionYear;
                    marksAllotEdit.MonthId = input.MonthId;
                    marksAllotEdit.SubId = input.SubId;
                    marksAllotEdit.BarCode = item.BarCode;
                    marksAllotEdit.Examiner = item.Examiner;
                    marksAllotEdit.Scriptsl = item.Scriptsl;
                    marksAllotEdit.Outmarks = item.Outmarks;
                    marksAllotEdit.Marks = item.Marks;
                    marksAllotEdit.Grade = item.Grade;
                    marksAllotEdit.Grace = item.Grace;
                    marksAllotEdit.Entryuser = input.Entryuser;
                    marksAllotEdit.ChangeMood = 1;
                    marksAllotEdit.TrackId = (await _context.MarksAllotEdits.MaxAsync(l => l.TrackId) ?? 0) + 1;
                    marksAllotEdit.ChangeDate = DateTime.Today;
                    marksAllotEdit.ChangeTime = DateTime.Now.ToString("HH:mm:ss");
                    marksAllotEdit.EditDelete = "EDIT";
                    marksAllotEdit.ChangeUser = input.Entryuser;
                    marksAllotEdit.PcInfo = Request.Headers.ContainsKey("X-Forwarded-For") ? Request.Headers["X-Forwarded-For"] : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    _context.MarksAllotEdits.Add(marksAllotEdit);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in marksAllotsDelete)
                {
                    _context.MarksAllots.Remove(item);
                    await _context.SaveChangesAsync();
                }

                int rowCount = 0;

                if (input.Input == null || input.Input.Count == 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "No mark details is given to be updated",
                        Success = false,
                        Payload = null
                    });
                }

                foreach (var item in input.Input)
                {
                    if (item.NewMarks < 0)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                        {
                            Message = "Marks can not be zero for barcode: " + item.BarCode,
                            Success = false,
                            Payload = new { item.BarCode }
                        });
                    }

                    MarksAllot marksAllot = new();
                    marksAllot.SessionYear = input.SessionYear;
                    marksAllot.MonthId = input.MonthId;
                    marksAllot.SubId = input.SubId;
                    marksAllot.BarCode = item.BarCode;
                    marksAllot.Examiner = item.Examiner;
                    marksAllot.Scriptsl = item.Scriptsl;
                    marksAllot.Outmarks = item.Outmarks;
                    marksAllot.Marks = item.NewMarks;
                    marksAllot.Grade = item.NewGrade;
                    marksAllot.Grace = ((item.NewMarks ?? 0) - (item.OldMarks ?? 0)) >= 0 ? (item.NewGrace ?? 0) : 0;
                    marksAllot.Entryuser = input.Entryuser;
                    _context.MarksAllots.Add(marksAllot);
                    rowCount = +await _context.SaveChangesAsync();
                }

                transaction.Commit();

                bool isRowCountValid = rowCount > 0;

                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = isRowCountValid ? "Subject wise overall marks updated successfully" : "Subject wise muliple marks update failed. Something went wrong. Please try again later",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new { rowCount } : null
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Subject wise overall marks update failed. Something went wrong. Please try again later",
                    Success = false,
                    Payload = e.Message + Environment.NewLine + e.InnerException
                });
            }
        }

        /// <summary>
        /// Get Preview For Multiple Marks Edit
        /// </summary>
        [HttpPost("GetPreviewForMultipleMarksEdit")]
        public async Task<ActionResult<ResponseDto2>> GetPreviewForMultipleMarksEdit([FromBody] MarksModel10 input)
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
                    Message = "Year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            Subject elsubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (elsubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level info found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (sessionInfo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month info found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject info found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            int? refNo;

            if (input.ChangeType == 3)
            {
                refNo = input.RefNo ?? 0;

                if (refNo != 0 && refNo != null)
                {
                    GradeSy gradeSy = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).FirstOrDefaultAsync();

                    if (gradeSy == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No grade reference info found in grade system for given reference no: " + refNo,
                            Success = false,
                            Payload = null
                        });
                    }
                }
            }
            else
            {
                refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();
            }

            if (refNo < 1 || refNo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No grade reference info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            MarksModel5 marksModel5 = new();

            marksModel5.ExamLevel = input.ExamLevel;
            marksModel5.MonthId = input.MonthId;
            marksModel5.SessionYear = input.SessionYear;
            marksModel5.SubId = input.SubId;

            List<MarksAllot> marksAllots = await _marks.GetSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(marksModel5);

            if (marksAllots == null || marksAllots.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks allot info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            MarksModel11 output = await _marks.GetPreviewOfSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(marksAllots, input.TargetNumberBelow, input.ChangeType, input.GraceAmount, refNo);

            if (output.Output == null || output.Output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks allot update preview info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rowCount = output.Output.Count;

            bool isRowCountValid = rowCount > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isRowCountValid ? "Marks preview info for multiple marks edit" : "Marks preview info for multiple marks edit failed. Something went wrong. Please try again later.",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Get Marks For Multiple Marks Edit
        /// </summary>
        [HttpPost("GetMarksForMultipleMarksEdit")]
        public async Task<ActionResult<ResponseDto2>> GetMarksForMultipleMarksEdit([FromBody] MarksModel5 input)
        {

            List<MarksAllot> marksAllots = await _marks.GetSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(input);

            int rowCount = marksAllots.Count;

            bool isRowCountValid = rowCount > 0;

            var query = isRowCountValid ? (from ma in marksAllots
                                           select new
                                           {
                                               ma.SessionYear,
                                               ma.MonthId,
                                               ma.SubId,
                                               ma.BarCode,
                                               ma.Examiner,
                                               ma.Scriptsl,
                                               ma.Outmarks,
                                               OldMarks = ma.Marks,
                                               OldGrade = ma.Grade,
                                               OldGrace = ma.Grace,
                                               ma.Entryuser
                                           }).ToList() : null;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Marks info for multiple marks edit" : "No marks info found for given criteria",
                Success = isRowCountValid,
                Payload = isRowCountValid ? query : null
            });
        }

        /// <summary>
        /// Get Marks For Single Marks Edit
        /// </summary>
        [HttpPost("GetMarksForSingleMarksEdit")]
        public async Task<ActionResult<ResponseDto2>> GetMarksForSingleMarksEdit([FromBody] MarksModel7 input)
        {

            List<MarksAllot> marksAllots = await _marks.GetSubjectWiseMarksForSingleMarksEditFromMarksAllotAsync(input);

            int rowCount = marksAllots.Count;

            if (rowCount > 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Multiple barcode found in marks allot for the given criteria:",
                    Success = false,
                    Payload = null
                });
            }

            bool isSingleRowFound = rowCount > 0 && rowCount == 1;

            return StatusCode(isSingleRowFound ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isSingleRowFound ? "Marks info for single marks edit" : "No marks info found for given criteria",
                Success = isSingleRowFound,
                Payload = isSingleRowFound ? marksAllots.FirstOrDefault() : null
            });
        }

        /// <summary>
        /// Get All Subject Wise Marks
        /// </summary>
        [HttpPost("GetAllSubjectWiseMarks")]
        public async Task<ActionResult<ResponseDto2>> GetAllSubjectWiseMarksAllot2([FromBody] MarksModel5 input)
        {
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

            string GetSubjectName = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(l => l.SubName).FirstOrDefaultAsync();
            if (GetSubjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            List<MarksModel4> marksModel4s = await _marks.GetAllSubjectWiseMarksFromMarksAllotAsync(input);
            MarksModel14 output = new();
            output.ExamLevelName = GetExamLevelName;
            output.MonthName = GetMonthName;
            output.SubjectName = GetSubjectName;
            output.MarksInfo = marksModel4s;

            int rowCount = marksModel4s.Count;

            bool isResultNull = rowCount > 0;

            return StatusCode(isResultNull ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isResultNull ? "List of subject wise marks" : "No marks info found for given criteria",
                Success = isResultNull,
                Payload = isResultNull ? output : null
            });
        }

        /// <summary>
        /// Get Subject Wise Marks Assign status
        /// </summary>
        [HttpPost("GetMarksStatusForGetSubjectWiseMarks")]
        public async Task<ActionResult<ResponseDto2>> GetMarksStatusForGetSubjectWiseMarks([FromBody] InputForGetMarksStatusForGetSubjectWiseMarks input)
        {
            BarcodeAllot barcodeAllot = await _context.BarcodeAllots.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId && i.BarCode == input.BarCode).FirstOrDefaultAsync();
            if (barcodeAllot == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The given barcode was not alloted for the exam",
                    Success = false,
                    Payload = null
                });
            }
            MarksAllot marksAllot = await _context.MarksAllots.Where(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId && i.BarCode == input.BarCode && i.Marks != null && i.Marks >= 0).FirstOrDefaultAsync();
            if (marksAllot != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Marks was already assign for the student with given barcode",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Marks was not assigned for the student with given barcode",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Get Subject Wise Marks
        /// </summary>
        [HttpPost("GetSubjectWiseMarks")]
        public async Task<ActionResult<ResponseDto2>> GetSubjectWiseMarksAllot([FromBody] InputForGetSubjectWiseMarks input)
        {
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

            string GetSubjectName = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(l => l.SubName).FirstOrDefaultAsync();
            if (GetSubjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            MarksModel2 marksModel2 = new();
            marksModel2.ExamLevel = input.ExamLevel;
            marksModel2.MonthId = input.MonthId;
            marksModel2.SessionYear = input.SessionYear;
            marksModel2.SubId = input.SubId;
            marksModel2.Examiner = input.Examiner;

            bool isResultLocked = await _context.ResultLocks.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RLock == 1);
            Subject subject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();

            List<MarksModel4> marksModel4s = await _marks.GetSubjectWiseMarksFromMarksAllotAsync(marksModel2);
            if (marksModel4s == null || marksModel4s.Count == 0)
            {
                marksModel4s = await _marks.GetSubjectWiseMarksFromBarcodeAllotAsync(marksModel2);
                if (marksModel4s == null || marksModel4s.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No marks info found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (isResultLocked == false)
            {
                marksModel4s.Clear();
                if (input.NoOfScript > 0)
                {
                    for (int i = 1; i <= input.NoOfScript; i++)
                    {
                        MarksModel4 marksModel4 = new();
                        marksModel4.Examiner = input.Examiner;
                        marksModel4.Outmarks = subject?.Outofmarks;
                        marksModel4s.Add(marksModel4);
                    }
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of subject wise marks for " + marksModel4s.Count + " students",
                Success = true,
                Payload = new
                {
                    Output = marksModel4s,
                    IsResultLocked = isResultLocked,
                    Count = marksModel4s.Count
                }
            });
        }

        /// <summary>
        /// Create Subject Wise Marks
        /// </summary>
        [HttpPost("CreateSubjectWiseMarks")]
        public async Task<ActionResult<ResponseDto2>> CreateMarksAllot([FromBody] MarksModel3 input)
        {
            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Examiner < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Examiner code can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.NoOfScript < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Number of scripts can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MarksAllots.Count == 0 || input.MarksAllots == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks given for entry",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MarksAllots.Count > input.NoOfScript)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Number of marks entry row can not be greater than number of scripts",
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

            Subject GetSubject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (GetSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            foreach (var item in input.MarksAllots)
            {
                if (item.Marks < 0 || item.Marks > GetSubject.Outofmarks)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Marks can not be less than 0 or greater than out of marks " + GetSubject.Outofmarks + " for subject id: " + input.SubId,
                        Success = false,
                        Payload = null
                    });
                }

                if (item.BarCode < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Barcode can not be null",
                        Success = false,
                        Payload = null
                    });
                }

                if (item.Scriptsl < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Script serial can not be null",
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (input.MarksAllots.Select(o => o.BarCode).Distinct().ToList().Count < input.MarksAllots.Count)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Duplicate barcode found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            var resultLocks = await _context.ResultLocks.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.RLock == 1).ToListAsync();

            if (resultLocks != null && resultLocks.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is locked for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();

            if (refNo <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No grade reference info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isMarksCreationSuccessful = await _marks.CreateMarksAsync(input);

            if (isMarksCreationSuccessful == true)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Subject wise marks created successfully",
                    Success = true,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Subject wise marks creation failed. Something went wrong, please try again later",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Update Subject Wise Marks
        /// </summary>
        [HttpPost("UpdateSubjectWiseMarks")]
        public async Task<ActionResult<ResponseDto2>> UpdateMarksAllot([FromBody] MarksModel3 input)
        {
            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Examiner < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Examiner code can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.NoOfScript < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Number of scripts can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MarksAllots.Count == 0 || input.MarksAllots == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No marks given for entry",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MarksAllots.Count > input.NoOfScript)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Number of marks entry row can not be greater than number of scripts",
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

            Subject GetSubject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (GetSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            foreach (var item in input.MarksAllots)
            {
                if (item.Marks < 0 || item.Marks > GetSubject.Outofmarks)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Marks can not be less than 0 or greater than out of marks " + GetSubject.Outofmarks + " for subject id: " + input.SubId,
                        Success = false,
                        Payload = null
                    });
                }

                if (item.BarCode < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Barcode can not be null",
                        Success = false,
                        Payload = null
                    });
                }

                if (item.Scriptsl < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Script serial can not be null",
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (input.MarksAllots.Select(o => o.BarCode).Distinct().ToList().Count < input.MarksAllots.Count)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Duplicate barcode found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            var resultLocks = await _context.ResultLocks.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.RLock == 1).ToListAsync();

            if (resultLocks != null && resultLocks.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is locked for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();

            if (refNo == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No grade reference info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isMarksUpdateSuccessful = await _marks.UpdateMarksAsync(input);

            if (isMarksUpdateSuccessful == true)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Subject wise marks updated successfully",
                    Success = true,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Subject wise marks update failed. Something went wrong, please try again later",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Create Subject Wise Marks with Grace
        /// </summary>
        [HttpPost("UpdateSubjectWiseMarksWithGrace")]
        public async Task<ActionResult<ResponseDto2>> UpdateMarksAllotWithGrace([FromBody] MarksModel8 input)
        {
            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Examiner < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Examiner code can not be null",
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

            Subject GetSubject = await _context.Subjects.Where(i => i.SubId == input.SubId).FirstOrDefaultAsync();
            if (GetSubject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            //foreach (var item in input.MarksAllots)
            //{
            if (input.Marks < 0 || input.Marks > GetSubject.Outofmarks)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Marks can not be less than 0 or greater than out of marks " + GetSubject.Outofmarks + " for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            if (input.BarCode < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Barcode can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Scriptsl < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Script serial can not be null",
                    Success = false,
                    Payload = null
                });
            }
            //}

            //if (input.MarksAllots.Select(o => o.BarCode).Distinct().ToList().Count < input.MarksAllots.Count)
            //{
            //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            //    {
            //        Message = "Duplicate barcode found for given criteria",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            var resultLocks = await _context.ResultLocks.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.RLock == 1).ToListAsync();

            if (resultLocks != null && resultLocks.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is locked for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();

            if (refNo == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No grade reference info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isMarksUpdateSuccessful = await _marks.UpdateSingleMarksWithGraceAsync(input);

            if (isMarksUpdateSuccessful == true)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Subject wise marks updated successfully",
                    Success = true,
                    Payload = new { input.BarCode }
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Subject wise single marks update with grace failed. Something went wrong, please try again later",
                Success = false,
                Payload = null
            });
        }
    }
}