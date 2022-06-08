using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    public class UploadProfilePicture1Input
    {
        public string directoryPath { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel1
    {
        public int RegNo { get; set; }
    }

    //public class StudentRegistrationAndUpdateControllerModel2
    //{
    //    public int FromRegNo { get; set; }
    //    public int ToRegNo { get; set; }
    //}

    //public class StudentRegistrationAndUpdateControllerModel3
    //{
    //    public int RegNo { get; set; }
    //    public string ChangeUser { get; set; }
    //    public StuReg1 StuReg1 { get; set; }
    //}

    public class StudentRegistrationAndUpdateControllerModel4
    {
        public int RegNo { get; set; }
        public string ChangeUser { get; set; }
    }

    //public class StudentRegistrationAndUpdateControllerModel5
    //{
    //    public int RegNo { get; set; }
    //    public string ExamName { get; set; }
    //}

    //public class StudentRegistrationAndUpdateControllerModel6
    //{
    //    public int RegNo { get; set; }
    //    public string ExamName { get; set; }
    //    public StuReg2 StuReg2 { get; set; }
    //}

    public class StudentRegistrationAndUpdateControllerModel7
    {
        public int RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public int? RegYear { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
        public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int? FId { get; set; }
        public int? PrinEnrNo { get; set; }
        public string Religion { get; set; }
        public string Fax { get; set; }
        public string Imagepath { get; set; }
        public string RequestedImagepath { get; set; }
        public string BloodGr { get; set; }
        public string Entryuser { get; set; }
        public int? StudType { get; set; }
        public int? Imageapprovalpending { get; set; }
        public string Salutation { get; set; }
        public string AltMobNo { get; set; }
        public string FirmName { get; set; }
        public string PrinName { get; set; }
        public decimal? PrinID { get; set; }
        public string ArticleSname { get; set; }
        public decimal? GenStuType { get; set; }
        public List<StuReg2> StuReg2s { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel8
    {
        public int RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public int? RegYear { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
        public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int? FId { get; set; }
        public int? PrinEnrNo { get; set; }
        public string Religion { get; set; }
        public string Fax { get; set; }
        public string Imagepath { get; set; }
        public string RequestedImagepath { get; set; }
        public string BloodGr { get; set; }
        public string Entryuser { get; set; }
        public int? StudType { get; set; }
        public int? Imageapprovalpending { get; set; }
        public string ChangeUser { get; set; }
        public string Salutation { get; set; }
        public string AltMobNo { get; set; }
        public string FirmName { get; set; }
        public string PrinName { get; set; }
        public decimal? PrinID { get; set; }
        public string ArticleSname { get; set; }
        public decimal? GenStuType { get; set; }
        public List<StuReg2> StuReg2s { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel9 : StudentRegistrationAndUpdateControllerModel14
    {
        public DateTime? RegDate { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel10
    {
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel12
    {
        public int TotalMatchedData { get; set; }
        public List<StudentRegistrationAndUpdateControllerModel10> Output { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel13 : StudentRegistrationAndUpdateControllerModel14
    {
        public string Gender { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel14
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel15 : StudentRegistrationAndUpdateControllerModel14
    {
        public DateTime RegDateFrom { get; set; }
        public DateTime RegDateTo { get; set; }
        // 1 for pending image approval report
        public int? PendingImageApprovalReport { get; set; }
    }

    public class StudentRegistrationAndUpdateControllerModel16
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }

    public class InputForListOfRegisteredStudent
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int? CandidatesSortByRegistrationNumber { get; set; }
        public int? CandidatesSortByRollNumber { get; set; }
        public int? CandidatesOfGivenSession { get; set; }
        public int? CandidatesInDateRange { get; set; }
        public DateTime? CandidatesOfGivenSessionDateFrom { get; set; }
        public DateTime? CandidatesOfGivenSessionDateTo { get; set; }
        public int? CandidateWithRegistrationNumber { get; set; }
        public int? CandidateRegistrationNumber { get; set; }
        public int? CandidatesWhoAreFemale { get; set; }
        public int? CandidatesInChittagong { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }

    public class OutputForListOfRegisteredStudent
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public int RegNo { get; set; }
        public int RollNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string PresentAddress { get; set; }
        public string Cell { get; set; }
        public string Phone { get; set; }
        public int CenId { get; set; }
        public string CenName { get; set; }
        public int SubId { get; set; }
        public string SubName { get; set; }
    }

    public class OutputForSubjectDetails
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
    }

    public class FormattedOutputForListOfRegisteredStudent
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public int RegNo { get; set; }
        public int RollNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string PresentAddress { get; set; }
        public string Cell { get; set; }
        public string Phone { get; set; }
        public int CenId { get; set; }
        public string CenName { get; set; }
        public List<OutputForSubjectDetails> Subjects { get; set; }
    }

    public class InputForAllStudentImageUpload
    {
        public string SourceDirectory { get; set; }
        public int? RegNoFrom { get; set; }
        public int? RegNoTo { get; set; }
    }

    public class InputForAllStudentImageDownload
    {
        public string DestinationDirectory { get; set; }
        public int? RegNoFrom { get; set; }
        public int? RegNoTo { get; set; }
    }

    public class InputForStudentCustomFieldUpdate
    {
        public int? RegNo { get; set; }
        public string Ph { get; set; }
        public DateTime? Dob { get; set; }
        public string Name { get; set; }
        public string Cell { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
    }

    public class StudentRegistrationAndUpdateController : BaseApiController
    {
        private readonly ModelContext _context;

        public StudentRegistrationAndUpdateController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Update Student Custom fields
        /// </summary>
        [HttpPatch("UpdateStudentCustomField")]
        public async Task<ActionResult<ResponseDto2>> UpdateStudentCustomField([FromBody] InputForStudentCustomFieldUpdate input)
        {
            if (input.RegNo == null || input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number can not be null",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();
                if (stuReg1 == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student found with registration number: " + input.RegNo,
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    if (input.Ph != null)
                    {
                        stuReg1.Ph = input.Ph;
                    }
                    if (input.Dob != null)
                    {
                        stuReg1.Dob = input.Dob;
                    }
                    if (input.Name != null)
                    {
                        stuReg1.Name = input.Name;
                    }
                    if (input.Cell != null)
                    {
                        stuReg1.Cell = input.Cell;
                    }
                    if (input.PreAdd != null)
                    {
                        stuReg1.PreAdd = input.PreAdd;
                    }
                    if (input.PerAdd != null)
                    {
                        stuReg1.PerAdd = input.PerAdd;
                    }
                    _context.StuReg1s.Update(stuReg1);
                    bool isSaved = await _context.SaveChangesAsync() > 0;
                    if (isSaved == true)
                    {
                        return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                        {
                            Message = "Data Updated successfully",
                            Success = true,
                            Payload = null
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                        {
                            Message = "Data Update failed",
                            Success = false,
                            Payload = null
                        });
                    }
                }
            }
        }

        // 3.15
        /// <summary>
        /// Get List Of Registered Student For Exam
        /// </summary>
        [HttpPost("GetListOfRegisteredStudentForExam")]
        public async Task<ActionResult<ResponseDto2>> GetListOfRegisteredStudentForExam([FromBody] InputForListOfRegisteredStudent input)
        {
            List<OutputForListOfRegisteredStudent> query = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                  join rs in _context.Set<RegSubject>()
                                                                    on er.Ref equals rs.RefNo
                                                                  join sr1 in _context.Set<StuReg1>()
                                                                    on er.RegNo equals sr1.RegNo
                                                                  join sub in _context.Set<Subject>()
                                                                    on rs.SubId equals sub.SubId
                                                                  join ec in _context.Set<ExamCentre>()
                                                                    on er.ExamcenId equals ec.CenId
                                                                  select new OutputForListOfRegisteredStudent
                                                                  {
                                                                      SlNo = 0,
                                                                      FormNo = er.FormNo,
                                                                      RegNo = er.RegNo,
                                                                      RollNo = er.ExamRollno,
                                                                      FillupDate = er.FillupDate,
                                                                      Name = sr1.Name,
                                                                      FName = sr1.FName,
                                                                      MName = sr1.MName,
                                                                      Gender = sr1.Gender,
                                                                      Dob = sr1.Dob,
                                                                      PresentAddress = sr1.PreAdd,
                                                                      Cell = sr1.Cell,
                                                                      Phone = sr1.Ph,
                                                                      CenId = er.ExamcenId,
                                                                      CenName = ec.Name,
                                                                      SubId = rs.SubId,
                                                                      SubName = sub.SubName
                                                                  }).OrderBy(o => o.RegNo).ThenBy(o => o.SubId).ToListAsync();

            query = input.CandidatesSortByRegistrationNumber == 1 ? query.OrderBy(o => o.RegNo).ThenBy(p => p.SubId).ToList() :
                    input.CandidatesSortByRegistrationNumber == 2 ? query.OrderByDescending(o => o.RegNo).ThenBy(p => p.SubId).ToList() :
                    input.CandidatesSortByRollNumber == 1 ? query.OrderBy(o => o.RollNo).ThenBy(p => p.SubId).ToList() :
                    input.CandidatesSortByRollNumber == 2 ? query.OrderByDescending(o => o.RollNo).ThenBy(p => p.SubId).ToList() : query;

            int initialCount = query.Count;

            List<int> rc = query.Select(i => i.RegNo).Distinct().ToList();

            int inis = 1;

            foreach (var item in query)
            {
                item.SlNo = inis;
                inis++;
            }

            bool isRowCountValid = query.Count > 0;

            Subject examLevelSubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();

            List<FormattedOutputForListOfRegisteredStudent> fop = new();
            int nrc = 1;
            foreach (var item in rc)
            {
                FormattedOutputForListOfRegisteredStudent top = new();
                var tquery = query.Where(i => i.RegNo == item).FirstOrDefault();
                if (tquery != null)
                {
                    top.SlNo = nrc;
                    top.FormNo = tquery.FormNo;
                    top.RegNo = tquery.RegNo;
                    top.RollNo = tquery.RollNo;
                    top.FillupDate = tquery.FillupDate;
                    top.Name = tquery.Name;
                    top.FName = tquery.FName;
                    top.MName = tquery.MName;
                    top.Gender = tquery.Gender;
                    top.Dob = tquery.Dob;
                    top.PresentAddress = tquery.PresentAddress;
                    top.Cell = tquery.Cell;
                    top.Phone = tquery.Phone;
                    top.CenId = tquery.CenId;
                    top.CenName = tquery.CenName;

                    List<OutputForSubjectDetails> subjects = new();
                    foreach (var element in query.Where(i => i.RegNo == item).ToList())
                    {
                        OutputForSubjectDetails subjectDetails = new();
                        subjectDetails.SubId = element.SubId;
                        subjectDetails.SubName = element.SubName;
                        subjects.Add(subjectDetails);
                    }

                    top.Subjects = subjects;
                    fop.Add(top);
                    nrc++;
                }
            }

            // selection 1 - all under session
            if (input.CandidatesOfGivenSession == 1)
            {
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates of given session" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName, // sessionInfo != null ? sessionInfo.SessionDetailsName : null,
                        ResultMatched = initialCount,
                        Output = (input.Skip >= 0 && input.Take > 0) ? fop.Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() : fop
                    } : null
                });
            }

            // selection 2 - date range
            else if (input.CandidatesInDateRange == 1 && input.CandidatesOfGivenSessionDateFrom != null && input.CandidatesOfGivenSessionDateTo != null)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo).ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo).ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }
                isRowCountValid = fop.Any(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates in date range from " + input.CandidatesOfGivenSessionDateFrom + " to " + input.CandidatesOfGivenSessionDateTo : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo),
                        Output = q
                    } : null
                });
            }

            // selection 3 - registration number
            else if (input.CandidateWithRegistrationNumber == 1 && input.CandidateRegistrationNumber != null)
            {
                isRowCountValid = fop.Any(k => k.RegNo == input.CandidateRegistrationNumber);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "Candidate with registration number: " + input.CandidateRegistrationNumber : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = 1,
                        Output = fop.Where(k => k.RegNo == input.CandidateRegistrationNumber).FirstOrDefault()
                    } : null
                });
            }

            // selection 4 - gender = "F"
            else if (input.CandidatesWhoAreFemale == 1)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(i => i.Gender == "F").ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(i => i.Gender == "F").ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }
                isRowCountValid = fop.Any(k => k.Gender == "F");
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "Female candidates" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(i => i.Gender == "F"),
                        Output = q
                    } : null
                });
            }

            // selection 5 - centerid = 2 for chittagong
            else if (input.CandidatesInChittagong == 1)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(k => k.CenId == 2).ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(k => k.CenId == 2).ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }

                isRowCountValid = fop.Any(k => k.CenId == 2);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates in Chittagong" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(k => k.CenId == 2),
                        Output = q
                    } : null
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "No selection made",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Get List Of Student For Exam Before Approve
        /// </summary>
        [HttpPost("GetListOfStudentForExamBeforeApprove")]
        public async Task<ActionResult<ResponseDto2>> GetListOfStudentForExamBeforeApprove([FromBody] InputForListOfRegisteredStudent input)
        {
            List<OutputForListOfRegisteredStudent> query = await (from er in _context.Set<TempExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.Formsubmitstatus != -1 && er.Fapprove == 0)
                                                                  join rs in _context.Set<TempRegSubject>()
                                                                    on er.Ref equals rs.RefNo
                                                                  join sr1 in _context.Set<StuReg1>()
                                                                    on er.RegNo equals sr1.RegNo
                                                                  join sub in _context.Set<Subject>()
                                                                    on rs.SubId equals sub.SubId
                                                                  join ec in _context.Set<ExamCentre>()
                                                                    on er.ExamcenId equals ec.CenId
                                                                  select new OutputForListOfRegisteredStudent
                                                                  {
                                                                      SlNo = 0,
                                                                      FormNo = er.FormNo,
                                                                      RegNo = er.RegNo,
                                                                      RollNo = er.ExamRollno,
                                                                      FillupDate = er.FillupDate,
                                                                      Name = sr1.Name,
                                                                      FName = sr1.FName,
                                                                      MName = sr1.MName,
                                                                      Gender = sr1.Gender,
                                                                      Dob = sr1.Dob,
                                                                      PresentAddress = sr1.PreAdd,
                                                                      Cell = sr1.Cell,
                                                                      Phone = sr1.Ph,
                                                                      CenId = er.ExamcenId,
                                                                      CenName = ec.Name,
                                                                      SubId = rs.SubId,
                                                                      SubName = sub.SubName
                                                                  }).OrderBy(o => o.RegNo).ThenBy(o => o.SubId).ToListAsync();

            int initialCount = query.Count;

            List<int> rc = query.Select(i => i.RegNo).Distinct().ToList();

            int inis = 1;

            foreach (var item in query)
            {
                item.SlNo = inis;
                inis++;
            }

            bool isRowCountValid = query.Count > 0;

            Subject examLevelSubject = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).FirstOrDefaultAsync();

            SessionInfo sessionInfo = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).FirstOrDefaultAsync();

            List<FormattedOutputForListOfRegisteredStudent> fop = new();
            int nrc = 1;
            foreach (var item in rc)
            {
                FormattedOutputForListOfRegisteredStudent top = new();
                var tquery = query.Where(i => i.RegNo == item).FirstOrDefault();
                if (tquery != null)
                {
                    top.SlNo = nrc;
                    top.FormNo = tquery.FormNo;
                    top.RegNo = tquery.RegNo;
                    top.RollNo = tquery.RollNo;
                    top.FillupDate = tquery.FillupDate;
                    top.Name = tquery.Name;
                    top.FName = tquery.FName;
                    top.MName = tquery.MName;
                    top.Gender = tquery.Gender;
                    top.Dob = tquery.Dob;
                    top.PresentAddress = tquery.PresentAddress;
                    top.Cell = tquery.Cell;
                    top.Phone = tquery.Phone;
                    top.CenId = tquery.CenId;
                    top.CenName = tquery.CenName;

                    List<OutputForSubjectDetails> subjects = new();
                    foreach (var element in query.Where(i => i.RegNo == item).ToList())
                    {
                        OutputForSubjectDetails subjectDetails = new();
                        subjectDetails.SubId = element.SubId;
                        subjectDetails.SubName = element.SubName;
                        subjects.Add(subjectDetails);
                    }

                    top.Subjects = subjects;
                    fop.Add(top);
                    nrc++;
                }
            }

            // selection 1 - all under session
            if (input.CandidatesOfGivenSession == 1)
            {
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates of given session" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName, // sessionInfo != null ? sessionInfo.SessionDetailsName : null,
                        ResultMatched = initialCount,
                        Output = (input.Skip >= 0 && input.Take > 0) ? fop.Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() : fop
                    } : null
                });
            }

            // selection 2 - date range
            else if (input.CandidatesInDateRange == 1 && input.CandidatesOfGivenSessionDateFrom != null && input.CandidatesOfGivenSessionDateTo != null)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo).ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo).ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }
                isRowCountValid = fop.Any(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates in date range from " + input.CandidatesOfGivenSessionDateFrom + " to " + input.CandidatesOfGivenSessionDateTo : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(k => k.FillupDate >= input.CandidatesOfGivenSessionDateFrom && k.FillupDate <= input.CandidatesOfGivenSessionDateTo),
                        Output = q
                    } : null
                });
            }

            // selection 3 - registration number
            else if (input.CandidateWithRegistrationNumber == 1 && input.CandidateRegistrationNumber != null)
            {
                isRowCountValid = fop.Any(k => k.RegNo == input.CandidateRegistrationNumber);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "Candidate with registration number: " + input.CandidateRegistrationNumber : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = 1,
                        Output = fop.Where(k => k.RegNo == input.CandidateRegistrationNumber).FirstOrDefault()
                    } : null
                });
            }

            // selection 4 - gender = "F"
            else if (input.CandidatesWhoAreFemale == 1)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(i => i.Gender == "F").ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(i => i.Gender == "F").ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }
                isRowCountValid = fop.Any(k => k.Gender == "F");
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "Female candidates" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(i => i.Gender == "F"),
                        Output = q
                    } : null
                });
            }

            // selection 5 - centerid = 2 for chittagong
            else if (input.CandidatesInChittagong == 1)
            {
                var q = (input.Skip >= 0 && input.Take > 0) ? fop.Where(k => k.CenId == 2).ToList().Skip(input.Skip ?? 0).Take(input.Take ?? 0).ToList() :
                                                              fop.Where(k => k.CenId == 2).ToList();

                int nrctr = 1;

                foreach (var item in q)
                {
                    item.SlNo = nrctr;
                    nrctr++;
                }

                isRowCountValid = fop.Any(k => k.CenId == 2);
                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of candidates in Chittagong" : "No candidate found for given criteria",
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ExamLevelName = examLevelSubject?.SubName,
                        MonthName = sessionInfo?.SessionDetailsName,
                        ResultMatched = fop.Count(k => k.CenId == 2),
                        Output = q
                    } : null
                });
            }

            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "No selection made",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Get Students By Gender
        /// </summary>
        [HttpPost("GetStudentsByGender")]
        public async Task<ActionResult<ResponseDto2>> GetStudentsByGender([FromBody] StudentRegistrationAndUpdateControllerModel13 input)
        {
            if (input.Gender == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Gender is null",
                    Success = false,
                    Payload = null
                });
            }

            int studentCount = (from sr1 in _context.StuReg1s.Where(s => s.Gender == input.Gender) select sr1.RegNo).Count();

            if (studentCount == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for gender: " + input.Gender,
                    Success = false,
                    Payload = null
                });
            }

            List<StudentRegistrationAndUpdateControllerModel10> tempOutput = new();

            if (input.Offset == 0 && input.Limit == 0)
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.Gender == input.Gender)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).ToListAsync();
            }

            else
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.Gender == input.Gender)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).Skip(input.Offset).Take(input.Limit).ToListAsync();
            }

            StudentRegistrationAndUpdateControllerModel12 output = new();

            output.TotalMatchedData = studentCount;
            output.Output = tempOutput;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students with gender: " + input.Gender,
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get Students By Registration Date Range
        /// </summary>
        [HttpPost("GetStudentsByRegistrationDateRange")]
        public async Task<ActionResult<ResponseDto2>> GetStudentsByRegistrationDateRange([FromBody] StudentRegistrationAndUpdateControllerModel15 input)
        {
            if (input.RegDateFrom > input.RegDateTo)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration date From can not be greater than registration date to",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Offset < 0 || input.Limit < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Offset or Limit can not be negative ",
                    Success = false,
                    Payload = null
                });
            }

            if (input.PendingImageApprovalReport == 1)
            {
                int studentCount2 = (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo && s.Imageapprovalpending == 1 && s.RequestedImagepath != null) select sr1.RegNo).Count();

                if (studentCount2 == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Student registration data not found for registration date between: " + input.RegDateFrom + " and " + input.RegDateTo,
                        Success = false,
                        Payload = null
                    });
                }

                List<StudentRegistrationAndUpdateControllerModel10> tempOutput2 = new();

                if (input.Offset == 0 && input.Limit == 0)
                {
                    tempOutput2 = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo && s.Imageapprovalpending == 1 && s.RequestedImagepath != null)
                                         select new StudentRegistrationAndUpdateControllerModel10
                                         {
                                             RegNo = sr1.RegNo,
                                             Name = sr1.Name,
                                             FName = sr1.FName,
                                             MName = sr1.MName
                                         }
                                       ).OrderBy(o => o.RegNo).ToListAsync();
                }

                else
                {
                    tempOutput2 = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo && s.Imageapprovalpending == 1 && s.RequestedImagepath != null)
                                         select new StudentRegistrationAndUpdateControllerModel10
                                         {
                                             RegNo = sr1.RegNo,
                                             Name = sr1.Name,
                                             FName = sr1.FName,
                                             MName = sr1.MName
                                         }
                                       ).OrderBy(o => o.RegNo).Skip(input.Offset).Take(input.Limit).ToListAsync();
                }

                StudentRegistrationAndUpdateControllerModel12 output2 = new();

                output2.TotalMatchedData = studentCount2;
                output2.Output = tempOutput2;

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students with registration date between: " + input.RegDateFrom + " and " + input.RegDateTo,
                    Success = true,
                    Payload = output2
                });
            }

            int studentCount = (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo) select sr1.RegNo).Count();

            if (studentCount == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration date between: " + input.RegDateFrom + " and " + input.RegDateTo,
                    Success = false,
                    Payload = null
                });
            }

            List<StudentRegistrationAndUpdateControllerModel10> tempOutput = new();

            if (input.Offset == 0 && input.Limit == 0)
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).ToListAsync();
            }

            else
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate >= input.RegDateFrom && s.RegDate <= input.RegDateTo)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).Skip(input.Offset).Take(input.Limit).ToListAsync();
            }

            StudentRegistrationAndUpdateControllerModel12 output = new();

            output.TotalMatchedData = studentCount;
            output.Output = tempOutput;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students with registration date between: " + input.RegDateFrom + " and " + input.RegDateTo,
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get Students By Registration Date
        /// </summary>
        [HttpPost("GetStudentsByRegistrationDate")]
        public async Task<ActionResult<ResponseDto2>> GetStudentsByRegistrationDate([FromBody] StudentRegistrationAndUpdateControllerModel9 input)
        {
            if (input.RegDate == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Date is null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Offset < 0 || input.Limit < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Offset or Limit can not be negative ",
                    Success = false,
                    Payload = null
                });
            }

            int studentCount = (from sr1 in _context.StuReg1s.Where(s => s.RegDate == input.RegDate) select sr1.RegNo).Count();

            if (studentCount == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration date: " + input.RegDate,
                    Success = false,
                    Payload = null
                });
            }

            List<StudentRegistrationAndUpdateControllerModel10> tempOutput = new();

            if (input.Offset == 0 && input.Limit == 0)
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate == input.RegDate)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).ToListAsync();
            }

            else
            {
                tempOutput = await (from sr1 in _context.StuReg1s.Where(s => s.RegDate == input.RegDate)
                                    select new StudentRegistrationAndUpdateControllerModel10
                                    {
                                        RegNo = sr1.RegNo,
                                        Name = sr1.Name,
                                        FName = sr1.FName,
                                        MName = sr1.MName
                                    }
                                   ).OrderBy(o => o.RegNo).Skip(input.Offset).Take(input.Limit).ToListAsync();
            }

            StudentRegistrationAndUpdateControllerModel12 output = new();

            output.TotalMatchedData = studentCount;
            output.Output = tempOutput;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students with registration date: " + input.RegDate,
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get All Board University
        /// </summary>
        [HttpGet("GetAllBoardUniversity")]
        public async Task<ActionResult<ResponseDto2>> GetAllBoardUniversity()
        {
            List<BoardUniversity> boardUniversities = await _context.BoardUniversities.OrderBy(i => i.BoardUniName).ToListAsync();

            if (boardUniversities == null || boardUniversities.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Board University info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of Board University",
                Success = true,
                Payload = boardUniversities
            });
        }

        /// <summary>
        /// Get All Group Subject
        /// </summary>
        [HttpGet("GetAllGroupSubject")]
        public async Task<ActionResult<ResponseDto2>> GetAllGroupSubject()
        {
            List<GroupSubject> groupSubjects = await _context.GroupSubjects.OrderBy(i => i.Id).ToListAsync();

            if (groupSubjects == null || groupSubjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Group Subject info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of group subjects",
                Success = true,
                Payload = groupSubjects
            });
        }

        /// <summary>
        /// Get Student
        /// </summary>
        [HttpPost("GetStudent")]
        public async Task<ActionResult<ResponseDto2>> GetStudent([FromBody] StudentRegistrationAndUpdateControllerModel1 inputModel1)
        {
            int reg_no = inputModel1.RegNo;
            StuReg1 stuReg1 = await _context.StuReg1s.Where(s => s.RegNo == reg_no).FirstOrDefaultAsync();
            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration number: " + inputModel1.RegNo,
                    Success = false,
                    Payload = null
                });
            }
            List<StuReg2> stuReg2s = await _context.StuReg2s.Where(s => s.RegNo == reg_no).ToListAsync();
            StudentRegistrationAndUpdateControllerModel7 outputModel1 = new()
            {
                RegNo = stuReg1.RegNo,
                RegDate = stuReg1.RegDate,
                RegYear = stuReg1.RegYear,
                PeriodFrom = stuReg1.PeriodFrom,
                PeriodTo = stuReg1.PeriodTo,
                NationalId = stuReg1.NationalId,
                Name = stuReg1.Name,
                FName = stuReg1.FName,
                MName = stuReg1.MName,
                PreAdd = stuReg1.PreAdd,
                PerAdd = stuReg1.PerAdd,
                Ph = stuReg1.Ph,
                Cell = stuReg1.Cell,
                Email = stuReg1.Email,
                Dob = stuReg1.Dob,
                Gender = stuReg1.Gender,
                Nationality = stuReg1.Nationality,
                FId = stuReg1.FId,
                PrinEnrNo = stuReg1.PrinEnrNo,
                Religion = stuReg1.Religion,
                Fax = stuReg1.Fax,
                Imagepath = stuReg1.Imagepath,
                RequestedImagepath = stuReg1.RequestedImagepath,
                BloodGr = stuReg1.BloodGr,
                Entryuser = stuReg1.Entryuser,
                StudType = stuReg1.StudType,
                Imageapprovalpending = stuReg1.Imageapprovalpending,
                Salutation = stuReg1.Salutation,
                AltMobNo = stuReg1.AltMobNo,
                FirmName = stuReg1.FirmName,
                PrinName = stuReg1.PrinName,
                PrinID = stuReg1.PrinID,
                ArticleSname = stuReg1.ArticleSname,
                GenStuType = stuReg1.GenStuType,
                StuReg2s = stuReg2s
            };

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student registration data for " + outputModel1.Name + " (Registration Number: " + outputModel1.RegNo + ")",
                Success = true,
                Payload = outputModel1
            });
        }

        /// <summary>
        /// Create Student
        /// </summary>
        [HttpPost("CreateStudent")]
        public async Task<ActionResult<ResponseDto2>> CreateStudent([FromBody] StudentRegistrationAndUpdateControllerModel7 input7)
        {
            StuReg1 oldStudent = await _context.StuReg1s.Where(k => k.RegNo == input7.RegNo).FirstOrDefaultAsync();

            if (oldStudent != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The student " + oldStudent.Name + " with registration number: " + input7.RegNo + " already exists",
                    Success = false,
                    Payload = null
                });
            }
            //string directoryName = "\\\\192.168.1.114";
            //string folderName = "Temp_RegImages";

            //string directoryName = "C:\\Users\\I\\Desktop";
            //string folderName = "i";

            //var pathToSave = Path.Combine(directoryName, folderName);

            //string fileName = stuReg1.RegNo.ToString() + ".jpg";

            //stuReg1.Imagepath = Path.Combine(pathToSave, fileName);

            //if (profilePicture.Length > 0)
            //{
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        await profilePicture.CopyToAsync(memoryStream);
            //        stuReg1.Defaultimage = memoryStream.ToArray();
            //    }
            //}

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                StuReg1 stuReg1 = new()
                {
                    RegNo = input7.RegNo,
                    RegDate = input7.RegDate,
                    RegYear = input7.RegYear,
                    PeriodFrom = input7.PeriodFrom,
                    PeriodTo = input7.PeriodTo,
                    NationalId = input7.NationalId,
                    Name = input7.Name,
                    FName = input7.FName,
                    MName = input7.MName,
                    PreAdd = input7.PreAdd,
                    PerAdd = input7.PerAdd,
                    Ph = input7.Ph,
                    Cell = input7.Cell,
                    Email = input7.Email,
                    Dob = input7.Dob,
                    Gender = input7.Gender,
                    Nationality = input7.Nationality,
                    FId = input7.FId,
                    PrinEnrNo = input7.PrinEnrNo,
                    Religion = input7.Religion,
                    Fax = input7.Fax,
                    Imagepath = input7.Imagepath,
                    RequestedImagepath = input7.RequestedImagepath,
                    BloodGr = input7.BloodGr,
                    Entryuser = input7.Entryuser,
                    StudType = input7.StudType,
                    Imageapprovalpending = input7.Imageapprovalpending,
                    Salutation = input7.Salutation,
                    AltMobNo = input7.AltMobNo,
                    FirmName = input7.FirmName,
                    PrinName = input7.PrinName,
                    PrinID = input7.PrinID,
                    ArticleSname = input7.ArticleSname,
                    GenStuType = input7.GenStuType
                };

                _context.StuReg1s.Add(stuReg1);
                await _context.SaveChangesAsync();

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.AddRange(input7.StuReg2s);
                //    await context.SaveChangesAsync();
                //}

                foreach (var item in input7.StuReg2s)
                {
                    _context.StuReg2s.Add(item);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student creation failed for registration number: " + input7.RegNo + ". Something went wrong, Please try again later.",
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
                Message = "The student " + input7.Name + " with registration number: " + input7.RegNo + " is created",
                Success = true,
                Payload = new { id = input7.RegNo }
            });
        }

        /// <summary>
        /// Update Student
        /// </summary>
        [HttpPost("UpdateStudent")]
        public async Task<ActionResult<ResponseDto2>> UpdateStudentForAdmin([FromBody] StudentRegistrationAndUpdateControllerModel8 input8)
        {
            StuReg1 stuReg1old = await _context.StuReg1s.Where(l => l.RegNo == input8.RegNo).FirstOrDefaultAsync();

            if (stuReg1old == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student found with registration number: " + input8.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                List<StuReg2> stuReg2sold = await _context.StuReg2s.Where(l => l.RegNo == input8.RegNo).ToListAsync();

                StuReg1Arch stuReg1Arch = new()
                {
                    RegNo = stuReg1old.RegNo,
                    RegDate = stuReg1old.RegDate,
                    RegYear = stuReg1old.RegYear,
                    PeriodFrom = stuReg1old.PeriodFrom,
                    PeriodTo = stuReg1old.PeriodTo,
                    NationalId = stuReg1old.NationalId,
                    Name = stuReg1old.Name,
                    FName = stuReg1old.FName,
                    MName = stuReg1old.MName,
                    PreAdd = stuReg1old.PreAdd,
                    PerAdd = stuReg1old.PerAdd,
                    Ph = stuReg1old.Ph,
                    Cell = stuReg1old.Cell,
                    Email = stuReg1old.Email,
                    Dob = stuReg1old.Dob,
                    Gender = stuReg1old.Gender,
                    Nationality = stuReg1old.Nationality,
                    FId = stuReg1old.FId,
                    PrinEnrNo = stuReg1old.PrinEnrNo,
                    Religion = stuReg1old.Religion,
                    Fax = stuReg1old.Fax,
                    Imagepath = stuReg1old.Imagepath,
                    BloodGr = stuReg1old.BloodGr,
                    Entryuser = stuReg1old.Entryuser,
                    ChangeId = (await _context.StuReg1Arches.MaxAsync(x => x.ChangeId) ?? 0) + 1,
                    ChangeDate = DateTime.Today,
                    ChangeTime = DateTime.Now.ToString("HH:mm:ss"),
                    EditDelete = "EDIT",
                    ChangeUser = input8.ChangeUser,
                    StudType = stuReg1old.StudType
                };

                _context.StuReg1Arches.Add(stuReg1Arch);
                await _context.SaveChangesAsync();

                foreach (var item in stuReg2sold)
                {
                    StuReg2Arch stuReg2Arch = new()
                    {
                        RegNo = item.RegNo,
                        ExamName = item.ExamName,
                        BoardUni = item.BoardUni,
                        PassYear = item.PassYear,
                        ResultDiv = item.ResultDiv,
                        ResultGpa = item.ResultGpa,
                        ResultProf = item.ResultProf,
                        ResultOutOfGpa = item.ResultOutOfGpa,
                        AcademicLevel = item.AcademicLevel,
                        Group = item.Group,
                        ChangeId = (await _context.StuReg2Arches.MaxAsync(x => x.ChangeId) ?? 0) + 1
                    };

                    _context.StuReg2Arches.Add(stuReg2Arch);
                    await _context.SaveChangesAsync();
                }

                _context.StuReg1s.Remove(stuReg1old);
                await _context.SaveChangesAsync();

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.RemoveRange(stuReg2sold);
                //    await context.SaveChangesAsync();
                //}

                foreach (var item in stuReg2sold)
                {
                    _context.StuReg2s.Remove(item);
                    await _context.SaveChangesAsync();
                }

                StuReg1 stuReg1 = new()
                {
                    RegNo = input8.RegNo,
                    RegDate = input8.RegDate,
                    RegYear = input8.RegYear,
                    PeriodFrom = input8.PeriodFrom,
                    PeriodTo = input8.PeriodTo,
                    NationalId = input8.NationalId,
                    Name = input8.Name,
                    FName = input8.FName,
                    MName = input8.MName,
                    PreAdd = input8.PreAdd,
                    PerAdd = input8.PerAdd,
                    Ph = input8.Ph,
                    Cell = input8.Cell,
                    Email = input8.Email,
                    Dob = input8.Dob,
                    Gender = input8.Gender,
                    Nationality = input8.Nationality,
                    FId = input8.FId,
                    PrinEnrNo = input8.PrinEnrNo,
                    Religion = input8.Religion,
                    Fax = input8.Fax,
                    Imagepath = input8.Imagepath,
                    RequestedImagepath = input8.RequestedImagepath,
                    BloodGr = input8.BloodGr,
                    Entryuser = input8.Entryuser,
                    StudType = input8.StudType,
                    Imageapprovalpending = input8.Imageapprovalpending,
                    Salutation = input8.Salutation,
                    AltMobNo = input8.AltMobNo,
                    FirmName = input8.FirmName,
                    PrinName = input8.PrinName,
                    PrinID = input8.PrinID,
                    ArticleSname = input8.ArticleSname,
                    GenStuType = input8.GenStuType
                };

                _context.StuReg1s.Add(stuReg1);
                await _context.SaveChangesAsync();

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.AddRange(input8.StuReg2s);
                //    await context.SaveChangesAsync();
                //}

                foreach (var item in input8.StuReg2s)
                {
                    _context.StuReg2s.Add(item);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student update failed for registration number: " + input8.RegNo + ". Something went wrong, Please try again later.",
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
                Message = "Values for the student " + input8.Name + " with registration number: " + input8.RegNo + " are updated successfully",
                Success = true,
                Payload = new { id = input8.RegNo }
            });
        }

        /// <summary>
        /// Update Student for Student
        /// </summary>
        [HttpPost("UpdateStudentForStudent")]
        public async Task<ActionResult<ResponseDto2>> UpdateStudentForStudent([FromBody] StudentRegistrationAndUpdateControllerModel8 input8)
        {
            StuReg1 stuReg1old = await _context.StuReg1s.Where(l => l.RegNo == input8.RegNo).FirstOrDefaultAsync();

            if (stuReg1old == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student found with registration number: " + input8.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                StuReg1 stuReg1old2 = stuReg1old;

                List<StuReg2> stuReg2sold = await _context.StuReg2s.Where(l => l.RegNo == input8.RegNo).ToListAsync();

                List<StuReg2> stuReg2sold2 = stuReg2sold;

                StuReg1Arch stuReg1Arch = new()
                {
                    RegNo = stuReg1old.RegNo,
                    RegDate = stuReg1old.RegDate,
                    RegYear = stuReg1old.RegYear,
                    PeriodFrom = stuReg1old.PeriodFrom,
                    PeriodTo = stuReg1old.PeriodTo,
                    NationalId = stuReg1old.NationalId,
                    Name = stuReg1old.Name,
                    FName = stuReg1old.FName,
                    MName = stuReg1old.MName,
                    PreAdd = stuReg1old.PreAdd,
                    PerAdd = stuReg1old.PerAdd,
                    Ph = stuReg1old.Ph,
                    Cell = stuReg1old.Cell,
                    Email = stuReg1old.Email,
                    Dob = stuReg1old.Dob,
                    Gender = stuReg1old.Gender,
                    Nationality = stuReg1old.Nationality,
                    FId = stuReg1old.FId,
                    PrinEnrNo = stuReg1old.PrinEnrNo,
                    Religion = stuReg1old.Religion,
                    Fax = stuReg1old.Fax,
                    Imagepath = stuReg1old.Imagepath,
                    BloodGr = stuReg1old.BloodGr,
                    Entryuser = stuReg1old.Entryuser,
                    ChangeId = (await _context.StuReg1Arches.MaxAsync(x => x.ChangeId) ?? 0) + 1,
                    ChangeDate = DateTime.Today,
                    ChangeTime = DateTime.Now.ToString("HH:mm:ss"),
                    EditDelete = "EDIT",
                    ChangeUser = input8.ChangeUser,
                    StudType = stuReg1old.StudType
                };

                _context.StuReg1Arches.Add(stuReg1Arch);
                await _context.SaveChangesAsync();

                foreach (var item in stuReg2sold)
                {
                    StuReg2Arch stuReg2Arch = new()
                    {
                        RegNo = item.RegNo,
                        ExamName = item.ExamName,
                        BoardUni = item.BoardUni,
                        PassYear = item.PassYear,
                        ResultDiv = item.ResultDiv,
                        ResultGpa = item.ResultGpa,
                        ResultProf = item.ResultProf,
                        ResultOutOfGpa = item.ResultOutOfGpa,
                        AcademicLevel = item.AcademicLevel,
                        Group = item.Group,
                        ChangeId = (await _context.StuReg2Arches.MaxAsync(x => x.ChangeId) ?? 0) + 1
                    };

                    _context.StuReg2Arches.Add(stuReg2Arch);
                    await _context.SaveChangesAsync();
                }

                _context.StuReg1s.Remove(stuReg1old);
                await _context.SaveChangesAsync();

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.RemoveRange(stuReg2sold);
                //    await context.SaveChangesAsync();
                //}

                foreach (var item in stuReg2sold)
                {
                    _context.StuReg2s.Remove(item);
                    await _context.SaveChangesAsync();
                }

                StuReg1 stuReg1 = new()
                {
                    RegNo = stuReg1old2.RegNo,
                    RegDate = stuReg1old2.RegDate,
                    RegYear = stuReg1old2.RegYear,
                    PeriodFrom = stuReg1old2.PeriodFrom,
                    PeriodTo = stuReg1old2.PeriodTo,
                    NationalId = stuReg1old2.NationalId,
                    Name = stuReg1old2.Name,
                    FName = stuReg1old2.FName,
                    MName = stuReg1old2.MName,
                    PreAdd = input8.PreAdd,
                    PerAdd = stuReg1old2.PerAdd,
                    Ph = stuReg1old2.Ph,
                    Cell = stuReg1old2.Cell,
                    Email = input8.Email,
                    Dob = stuReg1old2.Dob,
                    Gender = stuReg1old2.Gender,
                    Nationality = stuReg1old2.Nationality,
                    FId = stuReg1old2.FId,
                    PrinEnrNo = stuReg1old2.PrinEnrNo,
                    Religion = stuReg1old2.Religion,
                    Fax = stuReg1old2.Fax,
                    Imagepath = stuReg1old2.Imagepath,
                    BloodGr = stuReg1old2.BloodGr,
                    Entryuser = stuReg1old2.Entryuser,
                    StudType = stuReg1old2.StudType,
                    RequestedImagepath = stuReg1old2.RequestedImagepath,
                    Imageapprovalpending = stuReg1old2.Imageapprovalpending,
                    Salutation = stuReg1old2.Salutation,
                    AltMobNo = stuReg1old2.AltMobNo,
                    FirmName = stuReg1old2.FirmName,
                    PrinName = stuReg1old2.PrinName,
                    PrinID = stuReg1old2.PrinID,
                    ArticleSname = stuReg1old2.ArticleSname,
                    GenStuType = stuReg1old2.GenStuType
                };

                _context.StuReg1s.Add(stuReg1);
                await _context.SaveChangesAsync();

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.AddRange(input8.StuReg2s);
                //    await context.SaveChangesAsync();
                //}

                foreach (var item in stuReg2sold2)
                {
                    _context.StuReg2s.Add(item);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student update failed for registration number: " + input8.RegNo + ". Something went wrong, Please try again later.",
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
                Message = "Values for the student " + input8.Name + " with registration number: " + input8.RegNo + " are updated successfully",
                Success = true,
                Payload = new { id = input8.RegNo }
            });
        }

        /// <summary>
        /// Delete Student
        /// </summary>
        [HttpPost("DeleteStudent")]
        public async Task<ActionResult<ResponseDto2>> DeleteStudent([FromBody] StudentRegistrationAndUpdateControllerModel4 inputModel4)
        {
            int reg_no = inputModel4.RegNo;
            string changeuser = inputModel4.ChangeUser;

            var stuReg1 = await _context.StuReg1s.Where(k => k.RegNo == reg_no).FirstOrDefaultAsync();
            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration number: " + reg_no,
                    Success = false,
                    Payload = null
                });
            }

            var examReg = await _context.ExamRegs.Where(k => k.RegNo == reg_no).FirstOrDefaultAsync();
            if (examReg != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Student registration data already exists in exam registration: " + reg_no,
                    Success = false,
                    Payload = null
                });
            }

            var stuRegOld = await _context.StuReg1s.Where(k => k.RegNo == reg_no).FirstOrDefaultAsync();

            if (stuRegOld == null)
            {
                if (stuReg1 == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Student registration data not found in archieve for registration number: " + reg_no,
                        Success = false,
                        Payload = null
                    });
                }
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {

                StuReg1Arch stuReg1Arch = new()
                {
                    RegNo = stuRegOld.RegNo,
                    RegDate = stuRegOld.RegDate,
                    RegYear = stuRegOld.RegYear,
                    PeriodFrom = stuRegOld.PeriodFrom,
                    PeriodTo = stuRegOld.PeriodTo,
                    NationalId = stuRegOld.NationalId,
                    Name = stuRegOld.Name,
                    FName = stuRegOld.FName,
                    MName = stuRegOld.MName,
                    PreAdd = stuRegOld.PreAdd,
                    PerAdd = stuRegOld.PerAdd,
                    Ph = stuRegOld.Ph,
                    Cell = stuRegOld.Cell,
                    Email = stuRegOld.Email,
                    Dob = stuRegOld.Dob,
                    Gender = stuRegOld.Gender,
                    Nationality = stuRegOld.Nationality,
                    FId = stuRegOld.FId,
                    PrinEnrNo = stuRegOld.PrinEnrNo,
                    Religion = stuRegOld.Religion,
                    Fax = stuRegOld.Fax,
                    Imagepath = stuRegOld.Imagepath,
                    BloodGr = stuRegOld.BloodGr,
                    Entryuser = stuRegOld.Entryuser,
                    ChangeId = (await _context.StuReg1Arches.MaxAsync(x => x.ChangeId) ?? 0) + 1,
                    ChangeDate = DateTime.Today,
                    ChangeTime = DateTime.Now.ToString("HH:mm:ss"),
                    EditDelete = "DELETE",
                    ChangeUser = changeuser,
                    StudType = stuRegOld.StudType
                };

                _context.StuReg1Arches.Add(stuReg1Arch);
                await _context.SaveChangesAsync();

                _context.ChangeTracker.Clear();

                _context.StuReg1s.Remove(stuReg1);
                await _context.SaveChangesAsync();

                List<StuReg2> stuReg2s = await _context.StuReg2s.Where(l => l.RegNo == reg_no).ToListAsync();

                foreach (var item in stuReg2s)
                {
                    StuReg2Arch stuReg2Arch = new()
                    {
                        RegNo = item.RegNo,
                        ExamName = item.ExamName,
                        BoardUni = item.BoardUni,
                        PassYear = item.PassYear,
                        ResultDiv = item.ResultDiv,
                        ResultGpa = item.ResultGpa,
                        ResultProf = item.ResultProf,
                        ResultOutOfGpa = item.ResultOutOfGpa,
                        AcademicLevel = item.AcademicLevel,
                        Group = item.Group,
                        ChangeId = (await _context.StuReg1Arches.Where(x => x.RegNo == item.RegNo).MaxAsync(x => x.ChangeId) ?? 0) + 1
                    };

                    _context.StuReg2Arches.Add(stuReg2Arch);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in stuReg2s)
                {
                    _context.StuReg2s.Remove(item);
                    await _context.SaveChangesAsync();
                }

                //using (var context = new ModelContext())
                //{
                //    context.StuReg2s.RemoveRange(stuReg2s);
                //    await context.SaveChangesAsync();
                //}

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student deletion failed for registration number: " + inputModel4.RegNo + ". Something went wrong, Please try again later.",
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
                Message = "The student " + stuReg1.Name + " with registration number: " + inputModel4.RegNo + " is deleted successfully",
                Success = true,
                Payload = new { id = inputModel4.RegNo }
            });
        }

        /// <summary>
        /// Get Pending Image Approvals
        /// </summary>
        [HttpPost("GetPendingImageApprovals")]
        public async Task<ActionResult<ResponseDto2>> GetPendingImageApprovals([FromBody] StudentRegistrationAndUpdateControllerModel16 input)
        {
            List<int> total = await _context.StuReg1s.Where(k => k.Imageapprovalpending == 1 && k.RequestedImagepath != null).Select(o => o.RegNo).ToListAsync();
            var studentsForPendingImageApproval = await _context.StuReg1s
                                                                .Where(k => k.Imageapprovalpending == 1)
                                                                .Select
                                                                    (l =>
                                                                        new
                                                                        {
                                                                            l.RegNo,
                                                                            l.Name,
                                                                            l.FName,
                                                                            l.MName,
                                                                            l.Imagepath,
                                                                            l.RequestedImagepath
                                                                        }
                                                                    )
                                                                .OrderBy(h => h.RegNo)
                                                                .Skip(input.Skip)
                                                                .Take(input.Take)
                                                                .ToListAsync();

            if (studentsForPendingImageApproval == null || studentsForPendingImageApproval.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Image approval not pending for any student",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + studentsForPendingImageApproval.Count + " students for pending image approval",
                Success = true,
                Payload = new
                {
                    ResultMatched = total.Count,
                    Output = studentsForPendingImageApproval
                }
            });
        }

        //[HttpPost("TempStudentProfilePictureUpload")]
        //public async void TempStudentProfilePictureUpload()
        //{
        //    List<StuReg1> sr1s = await _context.StuReg1s.Where(i => i.Imagepath != null).OrderBy(j => j.RegNo).Take(102).ToListAsync();
        //    //AwsS3BucketRepository bucketRepository = new AwsS3BucketRepository();
        //    AwsS3CompatibleStorageRepository bucketRepository = new AwsS3CompatibleStorageRepository();
        //    foreach (var s in sr1s)
        //    {
        //        await bucketRepository.UploadBytesInAFolderAsync("test/studentDocument/" + s.RegNo.ToString(), s.RegNo.ToString() + ".jpeg", s.Defaultimage);
        //    }
        //    //AwsS3BucketRepository bucketRepository = new AwsS3BucketRepository();
        //    //bucketRepository.CopyBytesInAFolder(input.FolderPath, input.FileName, input.Bytes);

        //}

        /// <summary>
        /// Accept Image Approval
        /// </summary>
        [HttpPost("AcceptImageApproval")]
        public async Task<ActionResult<ResponseDto2>> AcceptImageApproval([FromBody] StudentRegistrationAndUpdateControllerModel1 input7)
        {
            StuReg1 studentForAcceptedImageApproval = await _context.StuReg1s.Where(k => k.RegNo == input7.RegNo).FirstOrDefaultAsync();

            if (studentForAcceptedImageApproval == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "The student with registration number: " + input7.RegNo + " not found",
                    Success = false,
                    Payload = null
                });
            }

            studentForAcceptedImageApproval.Imagepath = studentForAcceptedImageApproval.RequestedImagepath;
            studentForAcceptedImageApproval.RequestedImagepath = null;
            studentForAcceptedImageApproval.Imageapprovalpending = 0;

            _context.Entry(studentForAcceptedImageApproval).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Image approval for the student " + studentForAcceptedImageApproval.Name + " with registration number: " + input7.RegNo + " accepted successfully",
                Success = true,
                Payload = new { id = input7.RegNo }
            });
        }

        //[HttpPost("UploadAllStudentImage"), DisableRequestSizeLimit]
        //public async Task<ActionResult<ResponseDto2>> UploadAllStudentImage([FromBody] InputForAllStudentImageUpload input)
        //{
        //    DateTime dateTimeStart = DateTime.Now;
        //    int imageCount = 0;
        //    List<int> regNoCollection = new();
        //    if (input.SourceDirectory == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Source directory can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (Directory.Exists(input.SourceDirectory) == false)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Source directory does not exists",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoFrom == null || input.RegNoFrom < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number from can't be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoTo == null || input.RegNoTo < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number to can't be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoFrom > input.RegNoTo)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number from can't be greater than registration number to",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else
        //    {
        //        for (int i = (input.RegNoFrom ?? 0); i <= (input.RegNoTo ?? 0); i++)
        //        {
        //            string fileName = i + ".jpg";
        //            string pathToReadWithFileName = Path.Combine(input.SourceDirectory, fileName);
        //            if (System.IO.File.Exists(pathToReadWithFileName))
        //            {
        //                byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(pathToReadWithFileName);
        //                if (imageBytes != null)
        //                {
        //                    bool isStuReg1Exists = await _context.StuReg1s.AnyAsync(k => k.RegNo == i);
        //                    if (isStuReg1Exists == true)
        //                    {
        //                        StuReg1 stuReg1 = await _context.StuReg1s.Where(j => j.RegNo == i).FirstOrDefaultAsync();
        //                        stuReg1.Defaultimage = imageBytes;
        //                        _context.StuReg1s.Update(stuReg1);
        //                        imageCount += await _context.SaveChangesAsync();
        //                        regNoCollection.Add(stuReg1.RegNo);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "Images uploaded successfully",
        //        Success = true,
        //        Payload = new
        //        {
        //            TimePassed = (DateTime.Now - dateTimeStart).ToString(@"hh\:mm\:ss\.ffff"),
        //            NumberOfStudent = regNoCollection.Count,
        //            Students = regNoCollection
        //        }
        //    });
        //}

        //[HttpPost("DownloadAllStudentImage"), DisableRequestSizeLimit]
        //public async Task<ActionResult<ResponseDto2>> DownloadAllStudentImage([FromBody] InputForAllStudentImageDownload input)
        //{
        //    DateTime dateTimeStart = DateTime.Now;
        //    int imageCount = 0;
        //    List<int> regNoCollection = new();
        //    if (input.DestinationDirectory == null)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Source directory can not be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (Directory.Exists(input.DestinationDirectory) == false)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Source directory does not exists",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoFrom == null || input.RegNoFrom < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number from can't be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoTo == null || input.RegNoTo < 1)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number to can't be null",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else if (input.RegNoFrom > input.RegNoTo)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //        {
        //            Message = "Registration number from can't be greater than registration number to",
        //            Success = false,
        //            Payload = null
        //        });
        //    }
        //    else
        //    {
        //        List<StuReg1> stuReg1s = await _context.StuReg1s.Where(i => i.Imagepath != null && i.RegNo >= input.RegNoFrom && i.RegNo <= input.RegNoTo).OrderBy(i => i.RegNo).ToListAsync();
        //        if (stuReg1s.Count > 0)
        //        {
        //            foreach (StuReg1 item in stuReg1s)
        //            {
        //                await System.IO.File.WriteAllBytesAsync(Path.Combine(input.DestinationDirectory, item.RegNo.ToString() + ".jpg"), item.Defaultimage);
        //                regNoCollection.Add(item.RegNo);
        //                imageCount++;
        //            }
        //        }
        //    }
        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "Images downloaded successfully",
        //        Success = true,
        //        Payload = new
        //        {
        //            TimePassed = (DateTime.Now - dateTimeStart).ToString(@"hh\:mm\:ss\.ffff"),
        //            NumberOfStudent = regNoCollection.Count,
        //            Students = regNoCollection
        //        }
        //    });
        //}

        //[HttpGet("UploadAllImage"), DisableRequestSizeLimit]
        //public async Task<IActionResult> UploadAllImage()
        //{
        //    int regNoFrom = 11;
        //    int regNoTo = 186261;

        //    for (int i = regNoFrom; i <= regNoTo; i++)
        //    {
        //        string directoryName = "C:\\Users\\I\\Desktop";
        //        string folderName = "RegImages";
        //        string pathToRead = Path.Combine(directoryName, folderName);
        //        string fileName = i + ".jpg";
        //        string pathToReadWithFileName = Path.Combine(pathToRead, fileName);
        //        if (System.IO.File.Exists(pathToReadWithFileName))
        //        {
        //            byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(pathToReadWithFileName);

        //            if (imageBytes != null)
        //            {
        //                StuReg1 stuReg1 = await _context.StuReg1s.Where(k => k.RegNo == i).FirstOrDefaultAsync();

        //                if (stuReg1 != null)
        //                {
        //                    stuReg1.Defaultimage = imageBytes;
        //                    _context.StuReg1s.Update(stuReg1);
        //                    await _context.SaveChangesAsync();
        //                }
        //            }
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpPost("DownloadProfilePicture"), DisableRequestSizeLimit]
        //public async Task<IActionResult> ByteArrayToFile([FromBody] StudentRegistrationAndUpdateControllerModel1 input)
        //{
        //    bool doesRegNoExists = await _context.StuReg1s.AnyAsync(k => k.RegNo == input.RegNo);

        //    if (doesRegNoExists == false)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "The student with registration number: " + input.RegNo + " not found",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    byte[] myimage = await _context.StuReg1s.Where(k => k.RegNo == input.RegNo).Select(l => l.Defaultimage).FirstOrDefaultAsync();

        //    if (myimage == null)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "The student with registration number: " + input.RegNo + " does not have image",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    string fileName = input.RegNo.ToString();

        //    System.IO.File.WriteAllBytes("C:\\Users\\I\\Desktop\\k\\" + input.RegNo + ".jpg", myimage);

        //    return NoContent();
        //}

        //[HttpPost("CopyProfilePictureForSelectedStudents"), DisableRequestSizeLimit]
        //public async Task<IActionResult> GetWriteFiles1([FromBody] StudentRegistrationAndUpdateControllerModel2 inputModel2)
        //{
        //    int from_reg_no = inputModel2.FromRegNo;
        //    int to_reg_no = inputModel2.ToRegNo;
        //    try
        //    {
        //        if (from_reg_no <= 0 || to_reg_no <= 0 || from_reg_no > to_reg_no)
        //        {
        //            return BadRequest();
        //        }

        //        //string readDirectoryName = "\\\\192.168.1.114";
        //        //string readFolderName = "Temp_RegImages";

        //        string readDirectoryName = "C:\\Users\\I\\Desktop";
        //        string readFolderName = "i";

        //        var pathToRead = Path.Combine(readDirectoryName, readFolderName);

        //        //string writeDirectoryName = "\\\\192.168.1.114";
        //        //string writeFolderName = "Temp_RegImages";

        //        string writeDirectoryName = "C:\\Users\\I\\Desktop";
        //        string writeFolderName = "k";

        //        var pathToWrite = Path.Combine(writeDirectoryName, writeFolderName);

        //        for (int i = from_reg_no; i <= to_reg_no; i++)
        //        {
        //            string writeFileName = i.ToString() + ".jpg";
        //            var pathToWriteWithFileName = Path.Combine(pathToWrite, writeFileName);

        //            string readFileName = i.ToString() + ".jpg";
        //            string pathToReadWithFileName = Path.Combine(pathToRead, readFileName);

        //            if (System.IO.File.Exists(pathToReadWithFileName))
        //            {
        //                using FileStream readFileStream = new(pathToReadWithFileName, FileMode.Open);
        //                using (FileStream writeFileStream = new(pathToWriteWithFileName, FileMode.Create))
        //                {
        //                    await readFileStream.CopyToAsync(writeFileStream);
        //                    writeFileStream.Close();
        //                }
        //                readFileStream.Close();
        //            }
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        [HttpPost("UploadProfilePictureByRegNo"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadProfilePictureByRegNo([FromBody] UploadProfilePicture1Input input)
        {
            // string helplink = "https://code-maze.com/upload-files-dot-net-core-angular/"
            //string uploadDirectoryName = "\\\\192.168.1.114";
            //string folderName = "Temp_RegImages";
            //string directoryName = "C:\\Users\\I\\Desktop";
            //string folderName = "i";
            List<StuReg1> stuReg1s = await _context.StuReg1s.Where(i => i.Imagepath == null).OrderBy(o => o.RegNo).ToListAsync();
            AwsS3CompatibleStorageRepository awsS3CompatibleStorageRepository = new();
            try
            {
                foreach (var item in stuReg1s)
                {
                    //System.Diagnostics.Debug.WriteLine("hello alvi 0 : " + item);
                    string finalDirectoryWithFileName = "";
                    string estimatedFileName1 = item.RegNo.ToString() + ".jpg";
                    string estimatedFileName2 = item.RegNo.ToString() + ".jpeg";
                    string estimatedFileName3 = item.RegNo.ToString() + ".png";
                    string estimatedDirectoryWithFileName1 = Path.Combine(input.directoryPath, estimatedFileName1);
                    string estimatedDirectoryWithFileName2 = Path.Combine(input.directoryPath, estimatedFileName2);
                    string estimatedDirectoryWithFileName3 = Path.Combine(input.directoryPath, estimatedFileName3);
                    int selectedFileNameFlag = 0;
                    if (System.IO.File.Exists(estimatedDirectoryWithFileName1))
                    {
                        //System.Diagnostics.Debug.WriteLine("hello alvi:  " + item);
                        finalDirectoryWithFileName = estimatedDirectoryWithFileName1;
                        selectedFileNameFlag = 1;
                    }
                    else if (System.IO.File.Exists(estimatedDirectoryWithFileName2))
                    {
                        finalDirectoryWithFileName = estimatedDirectoryWithFileName2;
                        selectedFileNameFlag = 2;
                    }
                    else if (System.IO.File.Exists(estimatedDirectoryWithFileName3))
                    {
                        finalDirectoryWithFileName = estimatedDirectoryWithFileName3;
                        selectedFileNameFlag = 3;
                    }
                    else
                    {
                        continue;
                    }
                    byte[] result;
                    using (FileStream stream = System.IO.File.Open(finalDirectoryWithFileName, FileMode.Open))
                    {
                        result = new byte[stream.Length];
                        int isReadingFinished = await stream.ReadAsync(result, 0, (int)stream.Length);
                        //System.Diagnostics.Debug.WriteLine("hello alvi: " + item);
                        if (isReadingFinished > 0)
                        {
                            if (selectedFileNameFlag == 1)
                            {
                                await awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument/" + item.RegNo.ToString(), estimatedFileName1, result);
                                item.Imagepath = awsS3CompatibleStorageRepository._amazonS3Config.ServiceURL + "/" + awsS3CompatibleStorageRepository._bucketName + "/" + "studentDocument" + "/" + item.RegNo.ToString() + "/" + estimatedFileName1;
                                _context.StuReg1s.Update(item);
                                await _context.SaveChangesAsync();
                            }
                            else if (selectedFileNameFlag == 2)
                            {
                                await awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument/" + item.RegNo.ToString(), estimatedFileName2, result);
                                item.Imagepath = awsS3CompatibleStorageRepository._amazonS3Config.ServiceURL + "/" + awsS3CompatibleStorageRepository._bucketName + "/" + "studentDocument" + "/" + item.RegNo.ToString() + "/" + estimatedFileName2;
                                _context.StuReg1s.Update(item);
                                await _context.SaveChangesAsync();
                            }
                            else if (selectedFileNameFlag == 3)
                            {
                                await awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument/" + item.RegNo.ToString(), estimatedFileName3, result);
                                item.Imagepath = awsS3CompatibleStorageRepository._amazonS3Config.ServiceURL + "/" + awsS3CompatibleStorageRepository._bucketName + "/" + "studentDocument" + "/" + item.RegNo.ToString() + "/" + estimatedFileName3;
                                _context.StuReg1s.Update(item);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            return NoContent();
        }

        //private bool StuReg1Exists(int reg_no)
        //{
        //    return _context.StuReg1s.Any(e => e.RegNo == reg_no);
        //}

        //private bool FileValidation1(IFormFile formFile)
        //{
        //    if (formFile == null)
        //    {
        //        return false;
        //    }
        //    else if (formFile.Length == 0)
        //    {
        //        return false;
        //    }
        //    else if (formFile.Length > (10 * 1024 * 1024))
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //private bool StuReg2Exists(int reg_no, string exam_name)
        //{
        //    return _context.StuReg2s.Any(e => e.RegNo == reg_no && e.ExamName == exam_name);
        //}

    }
}
