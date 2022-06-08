using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICABAPI.Controllers;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{

    public class CLopModel1222 : TabulationsControllerModel122
    {
        public string SecretaryCeoName { get; set; }
        public string SecretaryCeoSign { get; set; }
    }


    public class TabulationsControllerModel88 : TabulationsControllerModel7
    {
        public int RegNo { get; set; }
    }

    public class TabulationRepository : ITabulationRepository
    {
        private readonly ModelContext _context;
        public List<TabListData> TabList { get; set; } = new List<TabListData>();
        public TabulationRepository(ModelContext context)
        {
            _context = context;
        }
        public TabulationRepository()
        {
            TabList = new List<TabListData>();
        }

        public async Task<IEnumerable<TabulationsControllerModel1>> GetTabulationSheet(TabulationsControllerModel7 input)
        {
            if (input.ExamLevel < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Exam level can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            if (input.MonthId < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Month id can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            if (input.SessionYear < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Session year can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (decodelog == null)
            {
                //return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                //{
                //    Message = "Decoding of result of this session has not yet been done. Please decode first for decoding option",
                //    Success = false,
                //    Payload = null
                //});
            }

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                //    Success = false,
                //    Payload = null
                //});
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "Month name not found for month id: " + input.MonthId,
                //    Success = false,
                //    Payload = null
                //});
            }

            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToListAsync();

            List<TabulationsControllerModel3> subjectDetails = new();

            foreach (var item in subjects)
            {
                TabulationsControllerModel3 newSubject = new();

                newSubject.SubId = item.SubId;
                newSubject.SubName = item.SubName;
                newSubject.NumberOfStudentPresent = 0;
                newSubject.NumberOfStudentPassed = 0;
                newSubject.PercentageOfStudentPassed = 0;

                subjectDetails.Add(newSubject);
            }

            var query = await (from ba in _context.Set<BarcodeAllot>()
                               from s in _context.Set<Subject>().Where(s => ba.SubId == s.SubId)
                               from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode && ba.ExamLevel == input.ExamLevel && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)

                               select new
                               {
                                   ba.ExamRollno,
                                   ba.RegNo,
                                   ba.SubId,
                                   s.SubName,
                                   ba.BarCode,
                                   ma.Marks,
                                   ma.Grade
                               }).OrderBy(j => j.RegNo).ThenBy(i => i.SubId).ToListAsync();

            if (query == null || query.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No tabulation sheet details found for given criteria",
                //    Success = false,
                //    Payload = null
                //});
            }

            // initialize subject info

            List<int?> regNoCollection = query.Select(k => k.RegNo).Distinct().ToList();

            List<TabulationsControllerModel1> output = new();
            foreach (var item in regNoCollection)
            {
                TabulationsControllerModel1 tempop1 = new();
                tempop1.RegNo = item;

                List<TabulationsControllerModel2> tempop2 = new();

                foreach (var element in subjects)
                {
                    TabulationsControllerModel2 tempop3 = new();

                    tempop3.SubId = element.SubId;
                    tempop3.SubName = element.SubName;
                    tempop3.BarCode = null;
                    tempop3.Marks = null;
                    tempop3.Grade = "F";

                    tempop2.Add(tempop3);
                }

                output.Add(tempop1);

                tempop1.ResultDetails = tempop2;
            }

            //assign marks and grades

            foreach (var item in output)
            {
                decimal totalMarksAchieved = 0;
                int totalNumberOfPass = 0;

                foreach (var element in item.ResultDetails)
                {
                    var tempop4 = query.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        item.ExamRollNo = tempop4.ExamRollno;
                        element.BarCode = tempop4.BarCode;
                        element.Marks = tempop4.Marks;
                        element.Grade = tempop4.Grade;

                        totalMarksAchieved = totalMarksAchieved + (element.Marks ?? 0);

                        if (element.Grade == "A" || element.Grade == "B")
                        {
                            totalNumberOfPass++;
                        }
                    }
                }

                item.TotalMarksAchieved = totalMarksAchieved;
                item.TotalNoOfPass = totalNumberOfPass;
            }

            // ep, ex calculation

            if (input.ExamLevel == 61)
            {
                // ex

                var exdata = await (from er in _context.ExamRegs
                                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                    orderby er.RegNo, es.SubId

                                    select new
                                    {
                                        RegNo = er.RegNo,
                                        //ExamRollno = x.ExamRollno,
                                        //SubId = b.SubId,
                                        //BarCode = b.BarCode,
                                        ExempSub = es.SubId
                                    }).ToListAsync();

                List<FormFillupModel6> exdata2 = await (from ba in _context.BarcodeAllots
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = exdata.Where(i => i.RegNo == item.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            if (element.SubId != 612)
                            {
                                element.Grade = "ex";
                                continue;
                            }

                            if (tempop4.ExempSub == 612)
                            {
                                bool isInSetExmpMous = await _context.SetExmpMous.AnyAsync(i => i.RegNo == item.RegNo);

                                if (isInSetExmpMous == true)
                                {
                                    element.Grade = "ex";
                                    continue;
                                }

                                bool isInConversionCourseMarks = await _context.ConversionCourseMarks.AnyAsync(i => i.RegNo == item.RegNo && i.ExamLevel == 41 && i.SubId == 412);

                                if (isInConversionCourseMarks == true)
                                {
                                    element.Grade = "ex";
                                    continue;
                                }
                            }
                        }

                        if (element.SubId == 612)
                        {
                            bool isInExData2 = exdata2.Any(i => i.RegNo == item.RegNo);

                            if (isInExData2 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }

                        if (element.SubId == 617)
                        {
                            bool isInExData3 = exdata3.Any(i => i.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }
                    }
                }

                // ep

                var abc = await (from b in _context.BarcodeAllots
                                 join m in _context.MarksAllots
                                 on b.SessionYear equals m.SessionYear
                                 where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.SessionYear || (b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)) && (b.ExamLevel == 41 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B")
                                 orderby b.RegNo, b.SubId
                                 select new
                                 {
                                     RegNo = b.RegNo,
                                     //ExamRollno = b.ExamRollno,
                                     //Examlevel = b.ExamLevel,
                                     //BarCode = b.BarCode,
                                     //Grade = m.Grade,
                                     //SessionYear = b.SessionYear,
                                     EPSubId = b.SubId == 411 ? 611 :
                                               b.SubId == 412 ? 612 :
                                               b.SubId == 413 ? 613 :
                                               b.SubId == 414 ? 614 :
                                               b.SubId == 415 ? 615 :
                                               b.SubId == 416 ? 616 :
                                               b.SubId == 417 ? 617 :
                                               b.SubId == 418 ? 618 : b.SubId
                                 }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else if (input.ExamLevel == 62)
            {
                // ex

                var exdata = await (from er in _context.ExamRegs
                                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                    orderby er.RegNo, es.SubId

                                    select new
                                    {
                                        RegNo = er.RegNo,
                                        //ExamRollno = x.ExamRollno,
                                        //SubId = b.SubId,
                                        //BarCode = b.BarCode,
                                        ExempSub = es.SubId
                                    }).ToListAsync();

                List<int?> validRegNoCollection = await _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToListAsync();
                var exresult = await (from ba in _context.BarcodeAllots
                                      join ma in _context.MarksAllots on
                                      new { ba.MonthId, ba.SessionYear, ba.SubId, ba.BarCode } equals
                                      new { ma.MonthId, ma.SessionYear, ma.SubId, ma.BarCode }
                                      where ((ma.Grade == "A" || ma.Grade == "B") && validRegNoCollection.Contains(ba.RegNo) && ba.ExamLevel == 2 && ba.SubId == 21)
                                      select new
                                      {
                                          RegNo = ba.RegNo,
                                          ExamLevel = ba.ExamLevel,
                                          SubId = ma.SubId
                                      }).ToListAsync();

                List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = exdata.Where(i => i.RegNo == item.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ex";
                            continue;
                        }

                        if (element.SubId == 622)
                        {
                            var tempop5 = exresult.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();

                            if (tempop5 != null)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }

                        if (element.SubId == 627)
                        {
                            bool isInExData3 = exdata3.Any(i => i.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }
                    }
                }

                // ep

                var abc = (from b in _context.BarcodeAllots
                           join m in _context.MarksAllots
                           on b.SessionYear equals m.SessionYear
                           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode
                           && (b.SessionYear < input.SessionYear || b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)
                           && (b.ExamLevel == 42 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B")
                           orderby b.RegNo, b.SubId
                           select new
                           {
                               RegNo = b.RegNo,
                               //ExamRollno = b.ExamRollno,
                               //Examlevel = b.ExamLevel,
                               //BarCode = b.BarCode,
                               //Grade = m.Grade,
                               //SessionYear = b.SessionYear,
                               EPSubId = b.SubId == 421 ? 621 :
                                         b.SubId == 422 ? 622 :
                                         b.SubId == 423 ? 623 :
                                         b.SubId == 424 ? 624 :
                                         b.SubId == 425 ? 625 :
                                         b.SubId == 426 ? 626 :
                                         b.SubId == 427 ? 627 :
                                         b.SubId == 428 ? 628 : b.SubId
                           }).ToList();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else if (input.ExamLevel == 63)
            {
                // ep
                var abc = (from b in _context.BarcodeAllots
                           join m in _context.MarksAllots
                           on b.SessionYear equals m.SessionYear
                           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.SessionYear || b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)
                           && (b.ExamLevel == 51 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B") && (b.SubId != 512 || m.SubId != 512)
                           orderby b.RegNo, b.SubId
                           select new
                           {
                               RegNo = b.RegNo,
                               //ExamRollno = b.ExamRollno,
                               //Examlevel = b.ExamLevel,
                               //BarCode = b.BarCode,
                               //Grade = m.Grade,
                               //SessionYear = b.SessionYear,
                               EPSubId = b.SubId == 511 ? 631 :
                                         b.SubId == 513 ? 632 :
                                         b.SubId == 514 ? 633 : b.SubId
                           }).ToList();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "This exam level is not allowed",
                //    Success = false,
                //    Payload = null
                //});
            }

            foreach (var item in output)
            {
                foreach (var element in item.ResultDetails)
                {
                    foreach (var subject in subjectDetails)
                    {
                        if (subject.SubId == element.SubId)
                        {
                            if (element.BarCode != null)
                            {
                                subject.NumberOfStudentPresent = subject.NumberOfStudentPresent + 1;
                            }

                            if (element.Grade == "A" || element.Grade == "B")
                            {
                                subject.NumberOfStudentPassed = subject.NumberOfStudentPassed + 1;
                            }
                        }
                    }
                }
            }

            foreach (var item in subjectDetails)
            {
                if (item.NumberOfStudentPresent != 0 && item.NumberOfStudentPassed != 0)
                {
                    //System.Diagnostics.Debug.WriteLine("den: " + item.NumberOfStudentPassed);
                    //System.Diagnostics.Debug.WriteLine("div: " + item.NumberOfStudentPresent);
                    item.PercentageOfStudentPassed = (((double)item.NumberOfStudentPassed * 100) / (double)item.NumberOfStudentPresent);
                    item.PercentageOfStudentPassed = Math.Round(item.PercentageOfStudentPassed, 2);
                    //System.Diagnostics.Debug.WriteLine("Percentage: " + item.PercentageOfStudentPassed);
                }
            }

            //foreach (var item in output)
            //{
            //    foreach (var element in item.ResultDetails)
            //    {
            //        foreach (var subject in subjectDetails)
            //        {
            //            if (subject.SubId == element.SubId)
            //            {
            //                if (element.BarCode != null)
            //                {
            //                    subject.NumberOfStudentPresent = subject.NumberOfStudentPresent + 1;
            //                }

            //                if (element.Grade == "A" || element.Grade == "B")
            //                {
            //                    subject.NumberOfStudentPassed = subject.NumberOfStudentPassed + 1;
            //                }
            //            }
            //        }
            //    }
            //}

            return output.Count > 0 ? output : null;
        }

        public async Task<TabulationsControllerModel1> GetTabulationSheetForOnePerson(TabulationsControllerModel88 input)
        {
            if (input.ExamLevel < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Exam level can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            if (input.MonthId < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Month id can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            if (input.SessionYear < 1)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "Session year can not be null",
                //    Success = false,
                //    Payload = null
                //});
            }

            Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (decodelog == null)
            {
                //return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                //{
                //    Message = "Decoding of result of this session has not yet been done. Please decode first for decoding option",
                //    Success = false,
                //    Payload = null
                //});
            }

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                //    Success = false,
                //    Payload = null
                //});
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {


                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "Month name not found for month id: " + input.MonthId,
                //    Success = false,
                //    Payload = null
                //});
            }

            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToListAsync();

            List<TabulationsControllerModel3> subjectDetails = new();

            foreach (var item in subjects)
            {
                TabulationsControllerModel3 newSubject = new();

                newSubject.SubId = item.SubId;
                newSubject.SubName = item.SubName;
                newSubject.NumberOfStudentPresent = 0;
                newSubject.NumberOfStudentPassed = 0;
                newSubject.PercentageOfStudentPassed = 0;

                subjectDetails.Add(newSubject);
            }

            var query = await (from ba in _context.Set<BarcodeAllot>().Where(i => i.RegNo == input.RegNo)
                               from s in _context.Set<Subject>().Where(s => ba.SubId == s.SubId)
                               from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode && ba.ExamLevel == input.ExamLevel && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)

                               select new
                               {
                                   ba.ExamRollno,
                                   ba.RegNo,
                                   ba.SubId,
                                   s.SubName,
                                   ba.BarCode,
                                   ma.Marks,
                                   ma.Grade
                               }).OrderBy(j => j.RegNo).ThenBy(i => i.SubId).ToListAsync();

            if (query == null || query.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No tabulation sheet details found for given criteria",
                //    Success = false,
                //    Payload = null
                //});
            }

            // initialize subject info

            List<int?> regNoCollection = query.Select(k => k.RegNo).Distinct().ToList();

            List<TabulationsControllerModel1> output = new();
            foreach (var item in regNoCollection)
            {
                TabulationsControllerModel1 tempop1 = new();
                tempop1.RegNo = item;

                List<TabulationsControllerModel2> tempop2 = new();

                foreach (var element in subjects)
                {
                    TabulationsControllerModel2 tempop3 = new();

                    tempop3.SubId = element.SubId;
                    tempop3.SubName = element.SubName;
                    tempop3.BarCode = null;
                    tempop3.Marks = null;
                    tempop3.Grade = "F";

                    tempop2.Add(tempop3);
                }

                output.Add(tempop1);

                tempop1.ResultDetails = tempop2;
            }

            //assign marks and grades

            foreach (var item in output)
            {
                decimal totalMarksAchieved = 0;
                int totalNumberOfPass = 0;

                foreach (var element in item.ResultDetails)
                {
                    var tempop4 = query.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        item.ExamRollNo = tempop4.ExamRollno;
                        element.BarCode = tempop4.BarCode;
                        element.Marks = tempop4.Marks;
                        element.Grade = tempop4.Grade;

                        totalMarksAchieved = totalMarksAchieved + (element.Marks ?? 0);

                        if (element.Grade == "A" || element.Grade == "B")
                        {
                            totalNumberOfPass++;
                        }
                    }
                }

                item.TotalMarksAchieved = totalMarksAchieved;
                item.TotalNoOfPass = totalNumberOfPass;
            }

            // ep, ex calculation

            if (input.ExamLevel == 61)
            {
                // ex

                var exdata = await (from er in _context.ExamRegs.Where(er => er.RegNo == input.RegNo)
                                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                    orderby er.RegNo, es.SubId

                                    select new
                                    {
                                        RegNo = er.RegNo,
                                        //ExamRollno = x.ExamRollno,
                                        //SubId = b.SubId,
                                        //BarCode = b.BarCode,
                                        ExempSub = es.SubId
                                    }).ToListAsync();

                List<FormFillupModel6> exdata2 = await (from ba in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = exdata.Where(i => i.RegNo == item.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            if (element.SubId != 612)
                            {
                                element.Grade = "ex";
                                continue;
                            }

                            if (tempop4.ExempSub == 612)
                            {
                                bool isInSetExmpMous = await _context.SetExmpMous.AnyAsync(i => i.RegNo == item.RegNo);

                                if (isInSetExmpMous == true)
                                {
                                    element.Grade = "ex";
                                    continue;
                                }

                                bool isInConversionCourseMarks = await _context.ConversionCourseMarks.AnyAsync(i => i.RegNo == item.RegNo && i.ExamLevel == 41 && i.SubId == 412);

                                if (isInConversionCourseMarks == true)
                                {
                                    element.Grade = "ex";
                                    continue;
                                }
                            }
                        }

                        if (element.SubId == 612)
                        {
                            bool isInExData2 = exdata2.Any(i => i.RegNo == item.RegNo);

                            if (isInExData2 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }

                        if (element.SubId == 617)
                        {
                            bool isInExData3 = exdata3.Any(i => i.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }
                    }
                }

                // ep

                var abc = await (from b in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                                 join m in _context.MarksAllots
                                 on b.SessionYear equals m.SessionYear
                                 where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.SessionYear || (b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)) && (b.ExamLevel == 41 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B")
                                 orderby b.RegNo, b.SubId
                                 select new
                                 {
                                     RegNo = b.RegNo,
                                     //ExamRollno = b.ExamRollno,
                                     //Examlevel = b.ExamLevel,
                                     //BarCode = b.BarCode,
                                     //Grade = m.Grade,
                                     //SessionYear = b.SessionYear,
                                     EPSubId = b.SubId == 411 ? 611 :
                                               b.SubId == 412 ? 612 :
                                               b.SubId == 413 ? 613 :
                                               b.SubId == 414 ? 614 :
                                               b.SubId == 415 ? 615 :
                                               b.SubId == 416 ? 616 :
                                               b.SubId == 417 ? 617 :
                                               b.SubId == 418 ? 618 : b.SubId
                                 }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else if (input.ExamLevel == 62)
            {
                // ex

                var exdata = await (from er in _context.ExamRegs.Where(er => er.RegNo == input.RegNo)
                                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                    orderby er.RegNo, es.SubId

                                    select new
                                    {
                                        RegNo = er.RegNo,
                                        //ExamRollno = x.ExamRollno,
                                        //SubId = b.SubId,
                                        //BarCode = b.BarCode,
                                        ExempSub = es.SubId
                                    }).ToListAsync();

                List<int?> validRegNoCollection = await _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToListAsync();
                var exresult = await (from ba in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                                      join ma in _context.MarksAllots on
                                      new { ba.MonthId, ba.SessionYear, ba.SubId, ba.BarCode } equals
                                      new { ma.MonthId, ma.SessionYear, ma.SubId, ma.BarCode }
                                      where ((ma.Grade == "A" || ma.Grade == "B") && validRegNoCollection.Contains(ba.RegNo) && ba.ExamLevel == 2 && ba.SubId == 21)
                                      select new
                                      {
                                          RegNo = ba.RegNo,
                                          ExamLevel = ba.ExamLevel,
                                          SubId = ma.SubId
                                      }).ToListAsync();

                List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = exdata.Where(i => i.RegNo == item.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ex";
                            continue;
                        }

                        if (element.SubId == 622)
                        {
                            var tempop5 = exresult.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();

                            if (tempop5 != null)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }

                        if (element.SubId == 627)
                        {
                            bool isInExData3 = exdata3.Any(i => i.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }
                    }
                }

                // ep

                var abc = (from b in _context.BarcodeAllots.Where(b => b.RegNo == input.RegNo)
                           join m in _context.MarksAllots
                           on b.SessionYear equals m.SessionYear
                           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode
                           && (b.SessionYear < input.SessionYear || b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)
                           && (b.ExamLevel == 42 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B")
                           orderby b.RegNo, b.SubId
                           select new
                           {
                               RegNo = b.RegNo,
                               //ExamRollno = b.ExamRollno,
                               //Examlevel = b.ExamLevel,
                               //BarCode = b.BarCode,
                               //Grade = m.Grade,
                               //SessionYear = b.SessionYear,
                               EPSubId = b.SubId == 421 ? 621 :
                                         b.SubId == 422 ? 622 :
                                         b.SubId == 423 ? 623 :
                                         b.SubId == 424 ? 624 :
                                         b.SubId == 425 ? 625 :
                                         b.SubId == 426 ? 626 :
                                         b.SubId == 427 ? 627 :
                                         b.SubId == 428 ? 628 : b.SubId
                           }).ToList();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else if (input.ExamLevel == 63)
            {
                // ep
                var abc = (from b in _context.BarcodeAllots.Where(ba => ba.RegNo == input.RegNo)
                           join m in _context.MarksAllots
                           on b.SessionYear equals m.SessionYear
                           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.SessionYear || b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)
                           && (b.ExamLevel == 51 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B") && (b.SubId != 512 || m.SubId != 512)
                           orderby b.RegNo, b.SubId
                           select new
                           {
                               RegNo = b.RegNo,
                               //ExamRollno = b.ExamRollno,
                               //Examlevel = b.ExamLevel,
                               //BarCode = b.BarCode,
                               //Grade = m.Grade,
                               //SessionYear = b.SessionYear,
                               EPSubId = b.SubId == 511 ? 631 :
                                         b.SubId == 513 ? 632 :
                                         b.SubId == 514 ? 633 : b.SubId
                           }).ToList();

                foreach (var item in output)
                {
                    foreach (var element in item.ResultDetails)
                    {
                        var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ep";
                        }
                    }
                }
            }

            else
            {
                //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //{
                //    Message = "This exam level is not allowed",
                //    Success = false,
                //    Payload = null
                //});
            }

            foreach (var item in output)
            {
                foreach (var element in item.ResultDetails)
                {
                    foreach (var subject in subjectDetails)
                    {
                        if (subject.SubId == element.SubId)
                        {
                            if (element.BarCode != null)
                            {
                                subject.NumberOfStudentPresent = subject.NumberOfStudentPresent + 1;
                            }

                            if (element.Grade == "A" || element.Grade == "B")
                            {
                                subject.NumberOfStudentPassed = subject.NumberOfStudentPassed + 1;
                            }
                        }
                    }
                }
            }

            foreach (var item in subjectDetails)
            {
                if (item.NumberOfStudentPresent != 0 && item.NumberOfStudentPassed != 0)
                {
                    //System.Diagnostics.Debug.WriteLine("den: " + item.NumberOfStudentPassed);
                    //System.Diagnostics.Debug.WriteLine("div: " + item.NumberOfStudentPresent);
                    item.PercentageOfStudentPassed = (((double)item.NumberOfStudentPassed * 100) / (double)item.NumberOfStudentPresent);
                    item.PercentageOfStudentPassed = Math.Round(item.PercentageOfStudentPassed, 2);
                    //System.Diagnostics.Debug.WriteLine("Percentage: " + item.PercentageOfStudentPassed);
                }
            }

            //foreach (var item in output)
            //{
            //    foreach (var element in item.ResultDetails)
            //    {
            //        foreach (var subject in subjectDetails)
            //        {
            //            if (subject.SubId == element.SubId)
            //            {
            //                if (element.BarCode != null)
            //                {
            //                    subject.NumberOfStudentPresent = subject.NumberOfStudentPresent + 1;
            //                }

            //                if (element.Grade == "A" || element.Grade == "B")
            //                {
            //                    subject.NumberOfStudentPassed = subject.NumberOfStudentPassed + 1;
            //                }
            //            }
            //        }
            //    }
            //}

            return output.Count > 0 ? output.FirstOrDefault() : null;
        }

        //public async Task<IEnumerable<Principal>> GetPrincipleByFirmId(int FId)
        //{

        //    return await _context.Principals.Where(x =>x.FId==FId).ToListAsync();

        //}
        public async Task<IEnumerable<CLopModel1222>> GetCongratulationLetters(TabulationsControllerModel7 input)
        {
            var output = await GetTabulationSheet(input);

            List<int> rc = new();
            Dictionary<int, int> rvr = new();
            Dictionary<int, int> ecc = new();

            //List<TabulationsControllerModel1> zz = new();

            List<TabulationsControllerModel122> newOutput = new();

            string getDetailsMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync();

            foreach (var item in output)
            {
                bool isLevelPassed = true;

                foreach (var element in item.ResultDetails)
                {
                    if (element.Grade != "A" && element.Grade != "B" && element.Grade != "ep" && element.Grade != "ex")
                    {
                        isLevelPassed = false;
                        break;
                    }
                }

                if (isLevelPassed == true)
                {
                    //zz.Add(item);
                    rc.Add(item.RegNo ?? 0);
                    rvr.Add(item.RegNo ?? 0, item.ExamRollNo ?? 0);
                    //TabulationsControllerModel122 tempop = new();

                    //tempop.ExamLevelName = GetExamLevelName;
                    //tempop.MonthName = getDetailsMonthName;
                    //tempop.Name = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.Name).FirstOrDefault();
                    //tempop.FName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.FName).FirstOrDefault();
                    //tempop.MName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.MName).FirstOrDefault();
                    //tempop.ExamRollNo = item.ExamRollNo;
                    //tempop.RegNo = item.RegNo;

                    int? maxRef = await _context.ExamRegs.Where(i => i.RegNo == item.RegNo && i.ExamLevel == input.ExamLevel).MaxAsync(l => l.Ref);

                    if (maxRef != null)
                    {
                        int? ecid = await _context.ExamRegs.Where(i => i.Ref == (maxRef ?? 0)).Select(s => s.ExamcenId).FirstOrDefaultAsync();
                        if (ecid != null)
                        {
                            ecc.Add(item.RegNo ?? 0, ecid ?? 0);
                            //tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == (ecid ?? 0)).Select(l => l.Name).FirstOrDefault();
                        }
                    }
                    //newOutput.Add(tempop);
                }
            }

            int minx = rc.Min();
            int maxx = rc.Max();

            int miny = ecc.Values.Min();
            int maxy = ecc.Values.Max();

            var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                            select new
                                            {
                                                sr1.RegNo,
                                                sr1.Name,
                                                sr1.FName,
                                                sr1.MName
                                            }).OrderBy(o => o.RegNo).ToListAsync();

            if (tempNameCollection == null || tempNameCollection.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No result found for congratulation letter report for given criteria",
                //    Success = false,
                //    Payload = null
                //});
                //return null;
            }

            var tempExamCenterNameCollection = await (from ec in _context.Set<ExamCentre>().Select(op => new { op.CenId, op.Name }).Where(o => o.CenId >= miny && o.CenId <= maxy)
                                                      select new
                                                      {
                                                          ec.CenId,
                                                          ec.Name,
                                                      }).OrderBy(o => o.CenId).ToListAsync();
            string SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync();
            string SecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync();
            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(j => j.SubName).FirstOrDefaultAsync();
            foreach (var item in rc)
            {
                TabulationsControllerModel122 tempop = new();

                tempop.ExamLevelName = GetExamLevelName;
                tempop.MonthName = getDetailsMonthName;
                tempop.Name = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.Name).FirstOrDefault();
                tempop.FName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.FName).FirstOrDefault();
                tempop.MName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.MName).FirstOrDefault();
                tempop.ExamRollNo = rvr[item];
                tempop.RegNo = item;
                tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == ecc[item]).Select(l => l.Name).FirstOrDefault();

                newOutput.Add(tempop);
            }

            if (newOutput == null || newOutput.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No student passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                //    Success = false,
                //    Payload = null
                //});
            }

            //return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            //{
            //    Message = "List of " + newOutput.Count + " students passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
            //    Success = true,
            //    //Payload = newOutput
            //    Payload = new
            //    {
            //        //ControllerName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.Controller).FirstOrDefaultAsync(),
            //        //ControllerSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.ControllerSign).FirstOrDefaultAsync(),
            //        SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync(),
            //        SecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeoSign).FirstOrDefaultAsync(),
            //        Output = newOutput
            //        //J = zz
            //    }
            //});

            var j = (from s in newOutput
                     select new CLopModel1222
                     {
                         ExamCenterName = s.ExamCenterName,
                         ExamLevelName = s.ExamLevelName,
                         ExamRollNo = s.ExamRollNo,
                         FName = s.FName,
                         MName = s.MName,
                         MonthName = s.MonthName,
                         Name = s.Name,
                         RegNo = s.RegNo,
                         SecretaryCeoName = SecretaryCeoName,
                         SecretaryCeoSign = SecretaryCeoSign
                     }).ToList();


            return j;
        }




        public async Task<CLopModel1222> GetSingleCongratulationLetters(TabulationsControllerModel88 input)
        {
            var output = await GetTabulationSheet(input);

            List<int> rc = new();
            Dictionary<int, int> rvr = new();
            Dictionary<int, int> ecc = new();

            //List<TabulationsControllerModel1> zz = new();

            List<TabulationsControllerModel122> newOutput = new();

            string getDetailsMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync();

            foreach (var item in output)
            {
                bool isLevelPassed = true;

                foreach (var element in item.ResultDetails)
                {
                    if (element.Grade != "A" && element.Grade != "B" && element.Grade != "ep" && element.Grade != "ex")
                    {
                        isLevelPassed = false;
                        break;
                    }
                }

                if (isLevelPassed == true)
                {
                    //zz.Add(item);
                    rc.Add(item.RegNo ?? 0);
                    rvr.Add(item.RegNo ?? 0, item.ExamRollNo ?? 0);
                    //TabulationsControllerModel122 tempop = new();

                    //tempop.ExamLevelName = GetExamLevelName;
                    //tempop.MonthName = getDetailsMonthName;
                    //tempop.Name = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.Name).FirstOrDefault();
                    //tempop.FName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.FName).FirstOrDefault();
                    //tempop.MName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.MName).FirstOrDefault();
                    //tempop.ExamRollNo = item.ExamRollNo;
                    //tempop.RegNo = item.RegNo;

                    int? maxRef = await _context.ExamRegs.Where(i => i.RegNo == item.RegNo && i.ExamLevel == input.ExamLevel).MaxAsync(l => l.Ref);

                    if (maxRef != null)
                    {
                        int? ecid = await _context.ExamRegs.Where(i => i.Ref == (maxRef ?? 0)).Select(s => s.ExamcenId).FirstOrDefaultAsync();
                        if (ecid != null)
                        {
                            ecc.Add(item.RegNo ?? 0, ecid ?? 0);
                            //tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == (ecid ?? 0)).Select(l => l.Name).FirstOrDefault();
                        }
                    }
                    //newOutput.Add(tempop);
                }
            }

            int minx = rc.Min();
            int maxx = rc.Max();

            int miny = ecc.Values.Min();
            int maxy = ecc.Values.Max();

            var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                            select new
                                            {
                                                sr1.RegNo,
                                                sr1.Name,
                                                sr1.FName,
                                                sr1.MName
                                            }).OrderBy(o => o.RegNo).ToListAsync();

            if (tempNameCollection == null || tempNameCollection.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No result found for congratulation letter report for given criteria",
                //    Success = false,
                //    Payload = null
                //});
                //return null;
            }

            var tempExamCenterNameCollection = await (from ec in _context.Set<ExamCentre>().Select(op => new { op.CenId, op.Name }).Where(o => o.CenId >= miny && o.CenId <= maxy)
                                                      select new
                                                      {
                                                          ec.CenId,
                                                          ec.Name,
                                                      }).OrderBy(o => o.CenId).ToListAsync();
            string SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync();
            string SecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync();
            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(j => j.SubName).FirstOrDefaultAsync();
            foreach (var item in rc)
            {
                TabulationsControllerModel122 tempop = new();

                tempop.ExamLevelName = GetExamLevelName;
                tempop.MonthName = getDetailsMonthName;
                tempop.Name = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.Name).FirstOrDefault();
                tempop.FName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.FName).FirstOrDefault();
                tempop.MName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.MName).FirstOrDefault();
                tempop.ExamRollNo = rvr[item];
                tempop.RegNo = item;
                tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == ecc[item]).Select(l => l.Name).FirstOrDefault();

                newOutput.Add(tempop);
            }

            if (newOutput == null || newOutput.Count == 0)
            {

            }


            var j = (from s in newOutput
                     select new CLopModel1222
                     {
                         ExamCenterName = s.ExamCenterName,
                         ExamLevelName = s.ExamLevelName,
                         ExamRollNo = s.ExamRollNo,
                         FName = s.FName,
                         MName = s.MName,
                         MonthName = s.MonthName,
                         Name = s.Name,
                         RegNo = s.RegNo,
                         SecretaryCeoName = SecretaryCeoName,
                         SecretaryCeoSign = SecretaryCeoSign
                     }).ToList();

            return j.Where(i => i.RegNo == input.RegNo).FirstOrDefault();
        }
        public async Task<CLopModel1222> GetSingleCongratulationLetters2(TabulationsControllerModel88 input)
        {
            var output = await GetTabulationSheet(input);

            List<int> rc = new();
            Dictionary<int, int> rvr = new();
            Dictionary<int, int> ecc = new();

            //List<TabulationsControllerModel1> zz = new();

            List<TabulationsControllerModel122> newOutput = new();

            string getDetailsMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync();

            foreach (var item in output)
            {
                bool isLevelPassed = true;

                foreach (var element in item.ResultDetails)
                {
                    if (element.Grade != "A" && element.Grade != "B" && element.Grade != "ep" && element.Grade != "ex")
                    {
                        isLevelPassed = false;
                        break;
                    }
                }

                if (isLevelPassed == true)
                {
                    //zz.Add(item);
                    rc.Add(item.RegNo ?? 0);
                    rvr.Add(item.RegNo ?? 0, item.ExamRollNo ?? 0);
                    //TabulationsControllerModel122 tempop = new();

                    //tempop.ExamLevelName = GetExamLevelName;
                    //tempop.MonthName = getDetailsMonthName;
                    //tempop.Name = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.Name).FirstOrDefault();
                    //tempop.FName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.FName).FirstOrDefault();
                    //tempop.MName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.MName).FirstOrDefault();
                    //tempop.ExamRollNo = item.ExamRollNo;
                    //tempop.RegNo = item.RegNo;

                    int? maxRef = await _context.ExamRegs.Where(i => i.RegNo == item.RegNo && i.ExamLevel == input.ExamLevel).MaxAsync(l => l.Ref);

                    if (maxRef != null)
                    {
                        int? ecid = await _context.ExamRegs.Where(i => i.Ref == (maxRef ?? 0)).Select(s => s.ExamcenId).FirstOrDefaultAsync();
                        if (ecid != null)
                        {
                            ecc.Add(item.RegNo ?? 0, ecid ?? 0);
                            //tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == (ecid ?? 0)).Select(l => l.Name).FirstOrDefault();
                        }
                    }
                    //newOutput.Add(tempop);
                }
            }

            int minx = rc.Min();
            int maxx = rc.Max();

            int miny = ecc.Values.Min();
            int maxy = ecc.Values.Max();

            var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                            select new
                                            {
                                                sr1.RegNo,
                                                sr1.Name,
                                                sr1.FName,
                                                sr1.MName
                                            }).OrderBy(o => o.RegNo).ToListAsync();

            if (tempNameCollection == null || tempNameCollection.Count == 0)
            {
                //return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //{
                //    Message = "No result found for congratulation letter report for given criteria",
                //    Success = false,
                //    Payload = null
                //});
                //return null;
            }

            var tempExamCenterNameCollection = await (from ec in _context.Set<ExamCentre>().Select(op => new { op.CenId, op.Name }).Where(o => o.CenId >= miny && o.CenId <= maxy)
                                                      select new
                                                      {
                                                          ec.CenId,
                                                          ec.Name,
                                                      }).OrderBy(o => o.CenId).ToListAsync();
            string SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync();
            string SecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync();
            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(j => j.SubName).FirstOrDefaultAsync();
            foreach (var item in rc)
            {
                TabulationsControllerModel122 tempop = new();

                tempop.ExamLevelName = GetExamLevelName;
                tempop.MonthName = getDetailsMonthName;
                tempop.Name = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.Name).FirstOrDefault();
                tempop.FName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.FName).FirstOrDefault();
                tempop.MName = tempNameCollection.Where(i => i.RegNo == item).Select(o => o.MName).FirstOrDefault();
                tempop.ExamRollNo = rvr[item];
                tempop.RegNo = item;
                tempop.ExamCenterName = tempExamCenterNameCollection.Where(i => i.CenId == ecc[item]).Select(l => l.Name).FirstOrDefault();

                newOutput.Add(tempop);
            }

            if (newOutput == null || newOutput.Count == 0)
            {

            }


            var j = (from s in newOutput
                     select new CLopModel1222
                     {
                         ExamCenterName = s.ExamCenterName,
                         ExamLevelName = s.ExamLevelName,
                         ExamRollNo = s.ExamRollNo,
                         FName = s.FName,
                         MName = s.MName,
                         MonthName = s.MonthName,
                         Name = s.Name,
                         RegNo = s.RegNo,
                         SecretaryCeoName = SecretaryCeoName,
                         SecretaryCeoSign = SecretaryCeoSign
                     }).ToList();

            return j.Where(i => i.RegNo == input.RegNo).FirstOrDefault();
        }

        public string GetHtml(CLopModel1222 input)

        {
            //  CLopModel1222 mem = await  GetSingleCongratulationLetters(input);

            // var mem = await GetTabulationSheetForOnePerson(input);

            //  https://localhost:5001/api/admin/v1/MemberPdf

            var sb = new StringBuilder();



            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Member Report </h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>MemID</th>
                                        <th>Cell</th>
                                        <th>Enrno</th>
                                    </tr>");
            
            // foreach (var mem in members)
            // {
            sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td> <img src=data:image/png;base64'/>{3} </td>
                                  </tr>", input.ExamCenterName, input.RegNo, input.ExamRollNo, input.Name);
            //  }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();


        }

    }





}