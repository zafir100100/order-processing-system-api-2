using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ICABAPI.Controllers
{
    public class InputForTabulationSheet
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }
    public class PerSubjectResult
    {
        public int SubId { get; set; }
        [DefaultValue(null)]
        public int? Barcode { get; set; }
        [DefaultValue(null)]
        public decimal? Marks { get; set; }
        [DefaultValue("F")]
        public string Grade { get; set; }
    }
    public class PerStudentResult
    {
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public List<PerSubjectResult> ResultDetails { get; set; }
        [DefaultValue(null)]
        public decimal? TotalMarksAchieved { get; set; }
        [DefaultValue(0)]
        public int TotalNoOfPass { get; set; }
    }
    public class RegisteredStudent
    {
        public int RollNo { get; set; }
        public int RegNo { get; set; }
    }
    public class TabulationsController2 : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public TabulationsController2(ModelContext context)
        {
            _context = context;
        }

        [HttpPost("GetTabulationSheetNew")]
        public async Task<ActionResult<ResponseDto2>> GetTabulationSheetNew([FromBody] InputForTabulationSheet input)
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
            //Get Exam level name
            string examLevelName =
                await _context.Subjects
                .Where(i => i.SubId == input.ExamLevel)
                .Select(i => i.SubName)
                .FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found",
                    Success = false,
                    Payload = null
                });
            }
            //Get List of subjects under exam level
            List<Subject> subjects =
                await _context.Subjects
                .Where(i => i.Parent == input.ExamLevel)
                .OrderBy(i => i.SubId)
                .ToListAsync();
            if (subjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under " + examLevelName,
                    Success = false,
                    Payload = null
                });
            }
            //Get Month name
            string monthName =
                await _context.SessionInfos
                .Where(i => i.SessionId == input.MonthId)
                .Select(i => i.SessionName)
                .FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found",
                    Success = false,
                    Payload = null
                });
            }
            //Get list of students who registered for the exam
            List<RegisteredStudent> registeredStudents =
                await _context.BarcodeAllots
                .Where(i => i.ExamLevel == input.ExamLevel &&
                            i.MonthId == input.MonthId &&
                            i.SessionYear == input.SessionYear)
                .Select(i => new RegisteredStudent
                {
                    RollNo = i.ExamRollno ?? 0,
                    RegNo = i.RegNo ?? 0
                })
                .OrderBy(i => i.RollNo)
                .Distinct()
                .ToListAsync();
            //List of reg no
            List<int> registerdReg = registeredStudents.Select(i => i.RegNo).Distinct().ToList();
            if (registeredStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student registered for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                    Success = false,
                    Payload = null
                });
            }
            //Build result matrix
            List<PerStudentResult> perStudentResults = new();
            foreach (var item in registeredStudents)
            {
                PerStudentResult perStudentResult = new();
                perStudentResult.ExamRollNo = item.RollNo;
                perStudentResult.RegNo = item.RegNo;
                List<PerSubjectResult> perSubjectResults = new();
                foreach (var element in subjects)
                {
                    PerSubjectResult perSubjectResult = new();
                    perSubjectResult.SubId = element.SubId;
                    perSubjectResults.Add(perSubjectResult);
                }
                perStudentResult.ResultDetails = perSubjectResults;
                perStudentResults.Add(perStudentResult);
            }
            //Get result from db
            perStudentResults = await GetTabulationForSelectedStudents(input.ExamLevel, input.MonthId, input.SessionYear, registerdReg, perStudentResults);
            //Finally return result
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Tabulation Sheet of " + perStudentResults.Count + " for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                Success = true,
                Payload = new
                {
                    Output = perStudentResults.OrderBy(i => i.ExamRollNo).ToList(),
                    OutputC = perStudentResults.Count
                }
            });
        }

        private async Task<List<PerStudentResult>> GetTabulationForSelectedStudents(int examLevel, int monthId, int sessionYear, List<int> registeredStudents, List<PerStudentResult> input)
        {
            if (examLevel == 61)
            {
                List<Task> tasks = new();
                //Download
                //Get all from vwMarksFinals for exam level 61 for only current exam
                Task<List<VwMarksfinal>> taskVwMarksFinalsCurrent = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) && i.ExamLevel == examLevel && i.MonthId == monthId && i.SessionYear == sessionYear
                                  )
                                  .ToListAsync();
                //Get all from vwMarksFinals for exam level 61
                Task<List<VwMarksfinal>> taskVwMarksFinals = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) &&
                                    (
                                            i.ExamLevel == 1 || i.ExamLevel == 2 || i.ExamLevel == 3 ||
                                            i.ExamLevel == 41 || i.ExamLevel == 61
                                    ) &&
                                   (i.Grade == "A" || i.Grade == "B") &&
                                   (i.SessionYear < sessionYear || (i.SessionYear == sessionYear && i.MonthId != monthId))
                                  )
                                  .ToListAsync();
                //get all form exemptedSubs for exam level 61
                Task<List<ExemptedSub>> taskExemptedSubs = _context.ExemptedSubs
                                                           .Where(i => registeredStudents.Contains(i.RegNo ?? 0) &&
                                                               (
                                                                   i.ExamLevel == 41 ||
                                                                   i.ExamLevel == 61
                                                               )
                                                           )
                                                           .ToListAsync();
                //get all form student of icmab acca for exam level 61
                Task<List<StudentOfIcmabAcca>> taskStudentOfIcmabAccas = _context.StudentOfIcmabAccas
                                                                             .Where
                                                                             (i => registeredStudents.Contains(i.RegNo ?? 0) &&
                                                                                (i.ExamLevel == 61)
                                                                             )
                                                                             .ToListAsync();
                //get all from set exmp mou for exam level 61
                Task<List<SetExmpMou>> taskSetExmpMous = _context.SetExmpMous
                                                             .Where(i => registeredStudents.Contains(i.RegNo ?? 0))
                                                             .ToListAsync();
                //get all from conversion course marks for exam level 61
                Task<List<ConversionCourseMark>> taskConversionCourseMarks = _context.ConversionCourseMarks
                                                                                 .Where
                                                                                 (i =>
                                                                                    registeredStudents.Contains(i.RegNo ?? 0) &&
                                                                                    (i.ExamLevel == 41) &&
                                                                                    (i.SubId == 412)
                                                                                 )
                                                                                 .ToListAsync();
                tasks.Add(taskVwMarksFinals);
                tasks.Add(taskExemptedSubs);
                tasks.Add(taskStudentOfIcmabAccas);
                tasks.Add(taskSetExmpMous);
                tasks.Add(taskConversionCourseMarks);
                tasks.Add(taskVwMarksFinalsCurrent);
                await Task.WhenAll(tasks);
                //get all from view marks finals
                List<VwMarksfinal> vwMarksfinals = taskVwMarksFinals.Result;
                //get all form exemptedSubs
                List<ExemptedSub> exemptedSubs = taskExemptedSubs.Result;
                //get all form student of icmab acca
                List<StudentOfIcmabAcca> studentOfIcmabAccas = taskStudentOfIcmabAccas.Result;
                //get all from set exmp mou
                List<SetExmpMou> setExmpMous = taskSetExmpMous.Result;
                //get all from conversion course marks
                List<ConversionCourseMark> conversionCourseMarks = taskConversionCourseMarks.Result;
                //get all from conversion course marks
                List<VwMarksfinal> vwMarksfinalsCurrent = taskVwMarksFinalsCurrent.Result;
                //assign all result
                input = AssignResultForExamLevel61(examLevel, monthId, sessionYear, input, vwMarksfinals, setExmpMous, conversionCourseMarks, exemptedSubs, studentOfIcmabAccas, vwMarksfinalsCurrent);
                return input;
            }
            else if (examLevel == 62)
            {
                List<Task> tasks = new();
                //Download
                //Get all from vwMarksFinals for exam level 62 for only current exam
                Task<List<VwMarksfinal>> taskVwMarksFinalsCurrent = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) && i.ExamLevel == examLevel && i.MonthId == monthId && i.SessionYear == sessionYear
                                  )
                                  .ToListAsync();
                //Get all from vwMarksFinals for exam level 62
                Task<List<VwMarksfinal>> taskVwMarksFinals = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) &&
                                    (
                                            i.ExamLevel == 1 || i.ExamLevel == 3 ||
                                            i.ExamLevel == 42 || i.ExamLevel == 62
                                    ) &&
                                   (i.Grade == "A" || i.Grade == "B") &&
                                   (i.SessionYear < sessionYear || (i.SessionYear == sessionYear && i.MonthId != monthId))
                                  )
                                  .ToListAsync();
                //get all form exemptedSubs for exam level 62
                Task<List<ExemptedSub>> taskExemptedSubs = _context.ExemptedSubs
                                                           .Where(i => registeredStudents.Contains(i.RegNo ?? 0) &&
                                                               (
                                                                   i.ExamLevel == 42 ||
                                                                   i.ExamLevel == 62
                                                               )
                                                           )
                                                           .ToListAsync();
                //get all form student of icmab acca for exam level 62
                Task<List<StudentOfIcmabAcca>> taskStudentOfIcmabAccas = _context.StudentOfIcmabAccas
                                                                             .Where
                                                                             (i => registeredStudents.Contains(i.RegNo ?? 0) &&
                                                                                (i.ExamLevel == 62)
                                                                             )
                                                                             .ToListAsync();
                ////get all from set exmp mou for exam level 62
                //Task<List<SetExmpMou>> taskSetExmpMous = _context.SetExmpMous
                //                                             .Where(i => registeredStudents.Contains(i.RegNo ?? 0))
                //                                             .ToListAsync();
                ////get all from conversion course marks for exam level 62
                //Task<List<ConversionCourseMark>> taskConversionCourseMarks = _context.ConversionCourseMarks
                //                                                                 .Where
                //                                                                 (i =>
                //                                                                    registeredStudents.Contains(i.RegNo ?? 0) &&
                //                                                                    (i.ExamLevel == 42) &&
                //                                                                    (i.SubId == 422)
                //                                                                 )
                //                                                                 .ToListAsync();
                tasks.Add(taskVwMarksFinals);
                tasks.Add(taskExemptedSubs);
                tasks.Add(taskStudentOfIcmabAccas);
                //tasks.Add(taskSetExmpMous);
                //tasks.Add(taskConversionCourseMarks);
                tasks.Add(taskVwMarksFinalsCurrent);
                await Task.WhenAll(tasks);
                //get all from view marks finals
                List<VwMarksfinal> vwMarksfinals = taskVwMarksFinals.Result;
                //get all form exemptedSubs
                List<ExemptedSub> exemptedSubs = taskExemptedSubs.Result;
                //get all form student of icmab acca
                List<StudentOfIcmabAcca> studentOfIcmabAccas = taskStudentOfIcmabAccas.Result;
                ////get all from set exmp mou
                //List<SetExmpMou> setExmpMous = taskSetExmpMous.Result;
                ////get all from conversion course marks
                //List<ConversionCourseMark> conversionCourseMarks = taskConversionCourseMarks.Result;
                //get all from conversion course marks
                List<VwMarksfinal> vwMarksfinalsCurrent = taskVwMarksFinalsCurrent.Result;
                //assign all result
                input = AssignResultForExamLevel62(examLevel, monthId, sessionYear, input, vwMarksfinals, exemptedSubs, studentOfIcmabAccas, vwMarksfinalsCurrent);
                return input;
            }
            else if (examLevel == 63)
            {
                List<Task> tasks = new();
                //Download
                //Get all from vwMarksFinals for exam level 63 for only current exam
                Task<List<VwMarksfinal>> taskVwMarksFinalsCurrent = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) && i.ExamLevel == examLevel && i.MonthId == monthId && i.SessionYear == sessionYear
                                  )
                                  .ToListAsync();
                //Get all from vwMarksFinals for exam level 63
                Task<List<VwMarksfinal>> taskVwMarksFinals = _context.VwMarksfinals
                                  .Where
                                  (i =>
                                    registeredStudents.Contains(i.RegNo ?? 0) &&
                                    (
                                            i.ExamLevel == 51 || i.ExamLevel == 63
                                    ) &&
                                   (i.Grade == "A" || i.Grade == "B") &&
                                   (i.SessionYear < sessionYear || (i.SessionYear == sessionYear && i.MonthId != monthId))
                                  )
                                  .ToListAsync();
                tasks.Add(taskVwMarksFinals);
                tasks.Add(taskVwMarksFinalsCurrent);
                await Task.WhenAll(tasks);
                //get all from view marks finals
                List<VwMarksfinal> vwMarksfinals = taskVwMarksFinals.Result;
                //get all from conversion course marks
                List<VwMarksfinal> vwMarksfinalsCurrent = taskVwMarksFinalsCurrent.Result;
                //assign all result
                input = AssignResultForExamLevel63(examLevel, monthId, sessionYear, input, vwMarksfinals, vwMarksfinalsCurrent);
                return input;
            }
            else
            {
                return null;
            }
        }
        private List<PerStudentResult> AssignResultForExamLevel61(int examLevel, int monthId, int sessionYear, List<PerStudentResult> input, List<VwMarksfinal> vwMarksfinals, List<SetExmpMou> setExmpMous, List<ConversionCourseMark> conversionCourseMarks, List<ExemptedSub> exemptedSubs, List<StudentOfIcmabAcca> studentOfIcmabAccas, List<VwMarksfinal> vwMarksfinalsCurrent)
        {
            //data for exemption
            List<VwMarksfinal> vwMarksfinalsExamLevel1 = vwMarksfinals.Where(i => i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalsExamLevel2 = vwMarksfinals.Where(i => i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalExamLevel3 = vwMarksfinals.Where(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<ExemptedSub> exemptedSubsExamLevel41 = exemptedSubs.Where(i => i.ExamLevel == 41).ToList();
            List<ExemptedSub> exemptedSubsExamLevel61 = exemptedSubs.Where(i => i.ExamLevel == 61).ToList();
            //data for earlier pass
            List<VwMarksfinal> vwMarksfinalsExamLevel41 = vwMarksfinals.Where(i => i.ExamLevel == 41 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalsExamLevel61 = vwMarksfinals.Where(i => i.ExamLevel == 61 && (i.Grade == "A" || i.Grade == "B")).ToList();
            Parallel.ForEach(input, item =>
            {
                Parallel.ForEach(item.ResultDetails, element =>
                {
                    //calculate exemptions
                    //--------------------
                    //get grade: ex for level 1 for vwmarksfina1
                    //level 1 er 16 te pass korle
                    //617 te ex dibo
                    bool isInVwMarksfinalLevel1 = vwMarksfinalsExamLevel1.Any(i => element.SubId == 617 && i.RegNo == item.RegNo && i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B"));
                    if (isInVwMarksfinalLevel1 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //get grade: ex for level 2 from vw marks final
                    //level 2 er 22 te pass korle
                    //612 te ex dibo
                    bool isInVwMarksfinalLevel2 = vwMarksfinalsExamLevel2.Any(i => element.SubId == 612 && i.RegNo == item.RegNo && i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B"));
                    if (isInVwMarksfinalLevel2 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //get grade: ex for level 3 from vw marks final
                    // level 3 er minimum 1 subject e pass korle 41 er
                    // 411, 412, 414, 415, 416, 417 e ex pabe
                    // 411->611, 412->612, 414->614, 415->615, 416->616, 417->617
                    //
                    // level 3 er moddhey
                    // jodi 34 pass kore, then 413->613 ex
                    bool isInVwMarksfinalLevel3part2 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && i.SubId == 34 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part2 == true)
                    {
                        if (element.SubId == 611 || element.SubId == 612 || element.SubId == 613 || element.SubId == 614 || element.SubId == 615 || element.SubId == 616 || element.SubId == 617)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    bool isInVwMarksfinalLevel3part1 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part1 == true)
                    {
                        if (element.SubId == 611 || element.SubId == 612 || element.SubId == 614 || element.SubId == 615 || element.SubId == 616 || element.SubId == 617)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    //get grade: ex for level 41 from exempted sub
                    bool isInExemptedSub41 = exemptedSubsExamLevel41.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId - 200);
                    if (isInExemptedSub41 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //get grade: ex for level 61 from exempted sub
                    bool isInExemptedSub61 = exemptedSubsExamLevel61.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInExemptedSub61 == true)
                    {
                        if (element.SubId != 612)
                        {
                            element.Grade = "ex";
                            return;
                        }
                        else if (element.SubId == 612 && exemptedSubsExamLevel61.Any(i => i.RegNo == item.RegNo && i.ExamLevel == 61 && i.SubId == 612))
                        {
                            bool isInSetExmpMous = setExmpMous.Any(i => i.RegNo == item.RegNo);

                            if (isInSetExmpMous == true)
                            {
                                element.Grade = "ex";
                                return;
                            }

                            bool isInConversionCourseMarks = conversionCourseMarks.Any(i => i.RegNo == item.RegNo && i.ExamLevel == 41 && i.SubId == 412);

                            if (isInConversionCourseMarks == true)
                            {
                                element.Grade = "ex";
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    //get grade: ex for 61 from icmab
                    bool isInstudentOfIcmabAccas61 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInstudentOfIcmabAccas61 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //calculate earlier pass
                    //----------------------
                    bool isInVwMarksFinal41 = vwMarksfinalsExamLevel41.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId - 200);
                    if (isInVwMarksFinal41 == true)
                    {
                        element.Grade = "ep";
                        return;
                    }
                    bool isInVwMarksFinal61 = vwMarksfinalsExamLevel61.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInVwMarksFinal61 == true)
                    {
                        element.Grade = "ep";
                        return;
                    }
                    //calculate current Grade
                    //----------------------
                    VwMarksfinal isInVwMarksFinalCurrent = vwMarksfinalsCurrent.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();
                    if (isInVwMarksFinalCurrent != null)
                    {
                        element.Grade = isInVwMarksFinalCurrent.Grade;
                        element.Marks = isInVwMarksFinalCurrent.Marks;
                        element.Barcode = isInVwMarksFinalCurrent.BarCode;
                        return;
                    }
                });
                item.TotalNoOfPass = item.ResultDetails.Count(i => i.Grade == "A" || i.Grade == "B");
                item.TotalMarksAchieved = item.ResultDetails.Sum(i => i.Marks ?? 0);
            });
            return input;
        }
        private List<PerStudentResult> AssignResultForExamLevel62(int examLevel, int monthId, int sessionYear, List<PerStudentResult> input, List<VwMarksfinal> vwMarksfinals, List<ExemptedSub> exemptedSubs, List<StudentOfIcmabAcca> studentOfIcmabAccas, List<VwMarksfinal> vwMarksfinalsCurrent)
        {
            //data for exemption
            List<VwMarksfinal> vwMarksfinalsExamLevel1 = vwMarksfinals.Where(i => i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalsExamLevel2 = vwMarksfinals.Where(i => i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalExamLevel3 = vwMarksfinals.Where(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<ExemptedSub> exemptedSubsExamLevel42 = exemptedSubs.Where(i => i.ExamLevel == 42).ToList();
            List<ExemptedSub> exemptedSubsExamLevel62 = exemptedSubs.Where(i => i.ExamLevel == 62).ToList();
            //data for earlier pass
            List<VwMarksfinal> vwMarksfinalsExamLevel42 = vwMarksfinals.Where(i => i.ExamLevel == 41 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalsExamLevel62 = vwMarksfinals.Where(i => i.ExamLevel == 61 && (i.Grade == "A" || i.Grade == "B")).ToList();
            Parallel.ForEach(input, item =>
            {
                Parallel.ForEach(item.ResultDetails, element =>
                {
                    //calculate exemptions
                    //--------------------
                    //get grade: ex for level 1 for vwmarksfina1
                    //level 1 er 16 te pass korle
                    //627 te ex dibo
                    bool isInVwMarksfinalLevel1 = vwMarksfinalsExamLevel1.Any(i => element.SubId == 627 && i.RegNo == item.RegNo && i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B"));
                    if (isInVwMarksfinalLevel1 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //get grade: ex for level 3 from vw marks final
                    // level 3 er minimum 1 subject e pass korle 42 er 
                    // 421, 422, 426, 427 e ex pabe
                    // 421->621, 422->622, 426->626, 427->627
                    //
                    // level 3 er moddhey
                    // jodi 33 pass kore, then 423->623 ex
                    // jodi 34 pass kore, then 424->624 ex
                    // jodi 35 pass kore, then 425->625 ex
                    bool isInVwMarksfinalLevel3part1 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part1 == true)
                    {
                        if (element.SubId == 621 || element.SubId == 622 || element.SubId == 626 || element.SubId == 627)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    bool isInVwMarksfinalLevel3part2 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && i.SubId == 33 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part2 == true)
                    {
                        if (element.SubId == 623)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    bool isInVwMarksfinalLevel3part3 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && i.SubId == 34 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part2 == true)
                    {
                        if (element.SubId == 624)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    bool isInVwMarksfinalLevel3part4 = vwMarksfinalExamLevel3.Any(i => i.ExamLevel == 3 && i.SubId == 35 && (i.Grade == "A" || i.Grade == "B") && i.RegNo == item.RegNo);
                    if (isInVwMarksfinalLevel3part2 == true)
                    {
                        if (element.SubId == 625)
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    //get grade: ex for level 42 from exempted sub
                    bool isInExemptedSub42 = exemptedSubsExamLevel42.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId - 200);
                    if (isInExemptedSub42 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //get grade: ex for level 62 from exempted sub
                    bool isInExemptedSub62 = exemptedSubsExamLevel62.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInExemptedSub62 == true)
                    {
                        if (element.SubId != 622)
                        {
                            element.Grade = "ex";
                            return;
                        }
                        else if (element.SubId == 622 && vwMarksfinalsExamLevel2.Any(i => i.RegNo == item.RegNo && i.ExamLevel == 2 && i.SubId == 21))
                        {
                            element.Grade = "ex";
                            return;
                        }
                    }
                    //get grade: ex for 62 from icmab
                    bool isInstudentOfIcmabAccas62 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInstudentOfIcmabAccas62 == true)
                    {
                        element.Grade = "ex";
                        return;
                    }
                    //calculate earlier pass
                    //----------------------
                    bool isInVwMarksFinal42 = vwMarksfinalsExamLevel42.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId - 200);
                    if (isInVwMarksFinal42 == true)
                    {
                        element.Grade = "ep";
                        return;
                    }
                    bool isInVwMarksFinal62 = vwMarksfinalsExamLevel62.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInVwMarksFinal62 == true)
                    {
                        element.Grade = "ep";
                        return;
                    }
                    //calculate current Grade
                    //----------------------
                    VwMarksfinal isInVwMarksFinalCurrent = vwMarksfinalsCurrent.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();
                    if (isInVwMarksFinalCurrent != null)
                    {
                        element.Grade = isInVwMarksFinalCurrent.Grade;
                        element.Marks = isInVwMarksFinalCurrent.Marks;
                        element.Barcode = isInVwMarksFinalCurrent.BarCode;
                        return;
                    }
                });
                item.TotalNoOfPass = item.ResultDetails.Count(i => i.Grade == "A" || i.Grade == "B");
                item.TotalMarksAchieved = item.ResultDetails.Sum(i => i.Marks ?? 0);
            });
            return input;
        }
        private List<PerStudentResult> AssignResultForExamLevel63(int examLevel, int monthId, int sessionYear, List<PerStudentResult> input, List<VwMarksfinal> vwMarksfinals, List<VwMarksfinal> vwMarksfinalsCurrent)
        {
            //data for earlier pass
            List<VwMarksfinal> vwMarksfinalsExamLevel51 = vwMarksfinals.Where(i => i.ExamLevel == 51 && (i.Grade == "A" || i.Grade == "B")).ToList();
            List<VwMarksfinal> vwMarksfinalsExamLevel63 = vwMarksfinals.Where(i => i.ExamLevel == 63 && (i.Grade == "A" || i.Grade == "B")).ToList();
            Parallel.ForEach(input, item =>
            {
                Parallel.ForEach(item.ResultDetails, element =>
                {
                    //calculate earlier pass
                    //----------------------
                    //ep error needs to map with 5 series to 6 series
                    bool isInVwMarksFinal51 = false;
                    if (element.SubId == 631)
                    {
                        isInVwMarksFinal51 = vwMarksfinalsExamLevel51.Any(i => i.RegNo == item.RegNo && i.SubId == 511);
                        if (isInVwMarksFinal51 == true)
                        {
                            element.Grade = "ep";
                            return;
                        }
                    }
                    else if (element.SubId == 632)
                    {
                        isInVwMarksFinal51 = vwMarksfinalsExamLevel51.Any(i => i.RegNo == item.RegNo && i.SubId == 513);
                        if (isInVwMarksFinal51 == true)
                        {
                            element.Grade = "ep";
                            return;
                        }
                    }
                    else if (element.SubId == 633)
                    {
                        isInVwMarksFinal51 = vwMarksfinalsExamLevel51.Any(i => i.RegNo == item.RegNo && i.SubId == 514);
                        if (isInVwMarksFinal51 == true)
                        {
                            element.Grade = "ep";
                            return;
                        }
                    }
                    bool isInVwMarksFinal63 = vwMarksfinalsExamLevel63.Any(i => i.RegNo == item.RegNo && i.SubId == element.SubId);
                    if (isInVwMarksFinal63 == true)
                    {
                        element.Grade = "ep";
                        return;
                    }
                    //calculate current Grade
                    //----------------------
                    VwMarksfinal isInVwMarksFinalCurrent = vwMarksfinalsCurrent.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();
                    if (isInVwMarksFinalCurrent != null)
                    {
                        element.Grade = isInVwMarksFinalCurrent.Grade;
                        element.Marks = isInVwMarksFinalCurrent.Marks;
                        element.Barcode = isInVwMarksFinalCurrent.BarCode;
                        return;
                    }
                });
                item.TotalNoOfPass = item.ResultDetails.Count(i => i.Grade == "A" || i.Grade == "B");
                item.TotalMarksAchieved = item.ResultDetails.Sum(i => i.Marks ?? 0);
            });
            return input;
        }
    }
}