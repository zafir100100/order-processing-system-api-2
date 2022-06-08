using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ICABAPI.Data
{

    public class MarksRepository : IMarks
    {
        public class MarksModel25
        {
            public int SubId { get; set; }
            public string SubName { get; set; }
            public List<MarksModel17> MarksDetails { get; set; }
        }

        public class MarksModel24
        {
            public int SubId { get; set; }
            public string SubName { get; set; }
            public int Barcode { get; set; }
            public decimal Marks { get; set; }
            public string Grade { get; set; }
        }

        public class MarksModel23
        {
            public string ExamLevelName { get; set; }
            public string MonthName { get; set; }
            public int? ExamRollno { get; set; }
            public int RegNo { get; set; }
            public List<MarksModel24> Result { get; set; }
            public decimal Total { get; set; }
            public int SubPassed { get; set; }
        }

        public class MarksModel22 : MarksAllot
        {
            public int? ExamLevel { get; set; }
            public string LoginSession { get; set; }
        }

        public class MarksModel21
        {
            public int RegNo { get; set; }
            public int? ExamRollno { get; set; }
            public string Name { get; set; }
            public string FName { get; set; }
            public string MName { get; set; }
            public string PrincipalName { get; set; }
            public string FirmName { get; set; }
        }

        public class MarksModel20 : MarksModel4
        {
            public string ExamLevelName { get; set; }
            public string MonthName { get; set; }
            public string SubjectName { get; set; }
        }

        public class MarksModel19 : MarksModel13
        {
            public int? SessionYear { get; set; }
            public int? MonthId { get; set; }
            public int? SubId { get; set; }
            public int? BarCode { get; set; }
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public decimal? Outmarks { get; set; }
            public decimal? Marks { get; set; }
            public string Grade { get; set; }
            public decimal? Grace { get; set; }
            public string Entryuser { get; set; }
        }

        public class MarksModel18 : MarksModel5
        {
            public int? BarCode { get; set; }
        }

        public class MarksModel17 : MarksModel13
        {
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public int? BarCode { get; set; }
            public decimal? Marks { get; set; }
            public decimal? Grace { get; set; }
            public decimal? TotalMarks { get; set; }
        }

        public class MarksModel16 : MarksModel13
        {
            public int? SessionYear { get; set; }
            public int? MonthId { get; set; }
            public int? SubId { get; set; }
            public int? BarCode { get; set; }
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public decimal? Outmarks { get; set; }
            public decimal? Marks { get; set; }
            public string Grade { get; set; }
            public decimal? Grace { get; set; }
            public string Entryuser { get; set; }
        }

        public class MarksModel15 : MarksModel13
        {
            public int SlNo { get; set; }
            public int RollNo { get; set; }
            public int RegNo { get; set; }
            public int BarCode { get; set; }
        }

        public class MarksModel14 : MarksModel13
        {
            public List<MarksModel4> MarksInfo { get; set; }
        }

        public class MarksModel13
        {
            public string ExamLevelName { get; set; }
            public string MonthName { get; set; }
            public string SubjectName { get; set; }
        }

        public class MarksModel12 : MarksModel5
        {
            public List<MarksModel9> Input { get; set; }
            public int? ChangeType { get; set; }
            public int? RefNo { get; set; }
            public string Entryuser { get; set; }
            public string ChangeReason { get; set; }
        }

        public class MarksModel11
        {
            public List<MarksModel9> Output { get; set; }
            public int NoOfPassBefore { get; set; }
            public int NoOfPassAfter { get; set; }
        }

        public class MarksModel10 : MarksModel5
        {
            public decimal? TargetNumberBelow { get; set; }
            public int ChangeType { get; set; }
            public decimal? GraceAmount { get; set; }
            public int? RefNo { get; set; }
        }

        public class MarksModel9
        {
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public int? BarCode { get; set; }
            public decimal? OldMarks { get; set; }
            public string OldGrade { get; set; }
            public decimal? OldGrace { get; set; }
            public decimal? NewMarks { get; set; }
            public string NewGrade { get; set; }
            public decimal? NewGrace { get; set; }
            public decimal? Outmarks { get; set; }
        }

        public class MarksModel8 : MarksModel7
        {
            public int? ExamLevel { get; set; }
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public decimal? Outmarks { get; set; }
            public decimal? Marks { get; set; }
            public string Grade { get; set; }
            public decimal? Grace { get; set; }
        }

        public class MarksModel7 : MarksModel6
        {
            public int SubId { get; set; }
            public int? BarCode { get; set; }
        }

        public class MarksModel6
        {
            public int MonthId { get; set; }
            public int SessionYear { get; set; }
        }

        public class MarksModel1 : MarksModel6
        {
            public int ExamLevel { get; set; }
        }

        public class MarksModel5 : MarksModel1
        {
            public int SubId { get; set; }
        }

        public class MarksModel2 : MarksModel5
        {
            public int Examiner { get; set; }
        }

        public class MarksModel3 : MarksModel2
        {
            public string EntryUser { get; set; }
            public int NoOfScript { get; set; }
            public List<MarksAllot> MarksAllots { get; set; }
        }

        public class MarksModel4
        {
            public int? Examiner { get; set; }
            public int? Scriptsl { get; set; }
            public int? BarCode { get; set; }
            public decimal? Marks { get; set; }
            public decimal? Outmarks { get; set; }
        }

        public class InputForGetSubjectWiseMarks
        {
            public int ExamLevel { get; set; }
            public int MonthId { get; set; }
            public int SessionYear { get; set; }
            public int SubId { get; set; }
            public int Examiner { get; set; }
            public int? NoOfScript { get; set; }
        }

        public class InputForGetMarksStatusForGetSubjectWiseMarks
        {
            public int ExamLevel { get; set; }
            public int MonthId { get; set; }
            public int SessionYear { get; set; }
            public int SubId { get; set; }
            public int BarCode { get; set; }
        }

        private readonly ModelContext _context;

        public MarksRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<MarksModel11> GetPreviewOfSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(List<MarksAllot> input, decimal? targetNumberBelow, int changeType, decimal? graceAmount, int? refNo)
        {
            MarksModel11 finalOutput = new();
            List<MarksModel9> output = (from ma in input
                                        select new MarksModel9
                                        {
                                            Examiner = ma.Examiner,
                                            Scriptsl = ma.Scriptsl,
                                            BarCode = ma.BarCode,
                                            OldMarks = ma.Marks ?? 0,
                                            OldGrade = ma.Grade,
                                            OldGrace = ma.Grace ?? 0,
                                            NewMarks = ma.Marks ?? 0,
                                            NewGrade = ma.Grade,
                                            NewGrace = ma.Grace ?? 0,
                                            Outmarks = ma.Outmarks
                                        }
                                       ).ToList();

            // grace by percentage
            if (changeType == 1 && graceAmount != null)
            {
                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

                foreach (var item in output)
                {
                    if (item.OldMarks < targetNumberBelow)
                    {
                        item.NewMarks = CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) + (((item.OldMarks ?? 0) * (graceAmount ?? 0)) / 100));
                        item.NewGrace = ((item.NewMarks ?? 0) - (item.OldMarks ?? 0)) >= 0 ? ((item.OldGrace ?? 0) + ((item.NewMarks ?? 0) - (item.OldMarks ?? 0))) : 0;
                        item.NewGrade = gradeDetails.Where(g => CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) + (((item.OldMarks ?? 0) * (graceAmount ?? 0)) / 100)) >= g.StartingMarks && CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) + (((item.OldMarks ?? 0) * (graceAmount ?? 0)) / 100)) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();

                    }
                }

                finalOutput.Output = output;
                finalOutput.NoOfPassBefore = output.Where(k => k.OldGrade == "A" || k.OldGrade == "B").Select(o => o.OldGrade).ToList().Count;
                finalOutput.NoOfPassAfter = output.Where(k => k.NewGrade == "A" || k.NewGrade == "B").Select(o => o.NewGrade).ToList().Count;
                return finalOutput;
            }

            // overall grace
            else if (changeType == 2 && graceAmount != null)
            {
                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

                foreach (var item in output)
                {
                    if (item.OldMarks < targetNumberBelow)
                    {
                        item.NewMarks = CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) + (graceAmount ?? 0));
                        item.NewGrace = ((item.NewMarks ?? 0) - (item.OldMarks ?? 0)) >= 0 ? ((item.OldGrace ?? 0) + ((item.NewMarks ?? 0) - (item.OldMarks ?? 0))) : 0;
                        //System.Diagnostics.Debug.WriteLine("Here is old marks: " + item.OldMarks);
                        //System.Diagnostics.Debug.WriteLine("Here is grace: " + graceAmount);
                        //System.Diagnostics.Debug.WriteLine("Here is summation: " + ((item.OldMarks ?? 0) + (graceAmount ?? 0)));
                        //System.Diagnostics.Debug.WriteLine("Here is new marks: " + item.NewMarks);
                        item.NewGrade = gradeDetails.Where(g => item.NewMarks >= g.StartingMarks && item.NewMarks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    }
                }

                finalOutput.Output = output;
                finalOutput.NoOfPassBefore = output.Where(k => k.OldGrade == "A" || k.OldGrade == "B").Select(o => o.OldGrade).ToList().Count;
                finalOutput.NoOfPassAfter = output.Where(k => k.NewGrade == "A" || k.NewGrade == "B").Select(o => o.NewGrade).ToList().Count;
                return finalOutput;
            }

            // grade system change
            else if (changeType == 3)
            {
                List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

                decimal outmarks = output.FirstOrDefault().Outmarks ?? 0;

                decimal multiplier = 1;

                if (outmarks > 0 && outmarks < 100 && outmarks != 0)
                {
                    multiplier = 100 / outmarks;

                    foreach (var item in output)
                    {
                        item.NewGrade = gradeDetails.Where(g => CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) * multiplier) >= g.StartingMarks && CustomRoundUpForPositiveDecimal((item.OldMarks ?? 0) * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    }

                    finalOutput.Output = output;
                    finalOutput.NoOfPassBefore = output.Where(k => k.OldGrade == "A" || k.OldGrade == "B").Select(o => o.OldGrade).ToList().Count;
                    finalOutput.NoOfPassAfter = output.Where(k => k.NewGrade == "A" || k.NewGrade == "B").Select(o => o.NewGrade).ToList().Count;
                    return finalOutput;
                }
                else
                {
                    foreach (var item in output)
                    {
                        item.NewGrade = gradeDetails.Where(g => item.OldMarks >= g.StartingMarks && item.OldMarks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    }

                    finalOutput.Output = output;
                    finalOutput.NoOfPassBefore = output.Where(k => k.OldGrade == "A" || k.OldGrade == "B").Select(o => o.OldGrade).ToList().Count;
                    finalOutput.NoOfPassAfter = output.Where(k => k.NewGrade == "A" || k.NewGrade == "B").Select(o => o.NewGrade).ToList().Count;
                    return finalOutput;
                }
            }

            return null;
        }

        public async Task<List<MarksAllot>> GetSubjectWiseMarksForMultipleMarksEditFromMarksAllotAsync(MarksModel5 input)
        {
            List<MarksAllot> marksAllots = await _context.MarksAllots.Where(x => x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId).OrderBy(j => j.Examiner).ThenBy(h => h.Scriptsl).ToListAsync();

            return marksAllots;
        }

        public async Task<List<MarksAllot>> GetSubjectWiseMarksForSingleMarksEditFromMarksAllotAsync(MarksModel7 input)
        {
            List<MarksAllot> marksAllots = await _context.MarksAllots.Where(x => x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId && x.BarCode == input.BarCode).ToListAsync();

            return marksAllots;
        }

        public async Task<List<MarksModel4>> GetAllSubjectWiseMarksFromMarksAllotAsync(MarksModel5 input)
        {
            List<MarksModel4> marksModel4s = await (from ma in _context.MarksAllots.Where(x => x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId).Select(ma => new { ma.Examiner, ma.Scriptsl, ma.BarCode, ma.Marks, ma.Outmarks })
                                                    select new MarksModel4
                                                    {
                                                        Examiner = ma.Examiner,
                                                        Scriptsl = ma.Scriptsl,
                                                        BarCode = ma.BarCode,
                                                        Marks = ma.Marks,
                                                        Outmarks = ma.Outmarks
                                                    }
                                                   ).OrderBy(j => j.Examiner).ThenBy(l => l.Scriptsl).ToListAsync();

            return marksModel4s;
        }

        public async Task<List<MarksModel4>> GetSubjectWiseMarksFromMarksAllotAsync(MarksModel2 input)
        {
            List<MarksModel4> marksModel4s = await (from ma in _context.MarksAllots.Where(x => x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId && x.Examiner == input.Examiner).Select(ma => new { ma.Examiner, ma.Scriptsl, ma.BarCode, ma.Marks, ma.Outmarks })
                                                    select new MarksModel4
                                                    {
                                                        Examiner = ma.Examiner,
                                                        Scriptsl = ma.Scriptsl,
                                                        BarCode = ma.BarCode,
                                                        Marks = ma.Marks,
                                                        Outmarks = ma.Outmarks
                                                    }
                                                   ).OrderBy(j => j.Scriptsl).ToListAsync();

            return marksModel4s;
        }

        public async Task<List<MarksModel4>> GetSubjectWiseMarksFromBarcodeAllotAsync(MarksModel2 input)
        {
            List<MarksModel4> marksModel4s = await (from ba in _context.BarcodeAllots.Where(x => x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear && x.SubId == input.SubId).Select(ba => new { ba.BarCode })
                                                    select new MarksModel4
                                                    {
                                                        Examiner = input.Examiner,
                                                        Scriptsl = 0,
                                                        BarCode = ba.BarCode,
                                                        Marks = 0,
                                                        Outmarks = 0
                                                    }
                                                   ).OrderBy(j => j.Scriptsl).ToListAsync();

            if (marksModel4s != null && marksModel4s.Count > 0)
            {
                int rowCount = 1;

                foreach (var item in marksModel4s)
                {
                    item.Scriptsl = rowCount;
                    rowCount++;
                }
            }

            return marksModel4s;
        }

        public async Task<bool> CreateMarksAsync(MarksModel3 input)
        {
            decimal outmarks = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(g => g.Outofmarks).FirstOrDefaultAsync();

            decimal multiplier = 1;

            if (outmarks < 100 && outmarks != 0)
            {
                multiplier = 100 / outmarks;
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("Here is refno: " + refNo);
            //System.Diagnostics.Debug.WriteLine("here is month id: " + input.MonthId);
            List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

            int createdRowCount = 0;

            if (outmarks < 100 && outmarks != 0)
            {
                foreach (var item in input.MarksAllots)
                {
                    item.Outmarks = outmarks;
                    double convertMarks = Convert.ToDouble(item.Marks ?? 0);
                    double integerMarks = Math.Truncate(convertMarks);
                    if ((convertMarks - integerMarks) >= 0.5)
                    {
                        item.Marks = Convert.ToDecimal(integerMarks + 1);
                    }
                    else
                    {
                        item.Marks = Convert.ToDecimal(integerMarks);
                    }
                    item.Grade = gradeDetails.Where(g => (item.Marks * multiplier) >= g.StartingMarks && (item.Marks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    _context.MarksAllots.Add(item);
                    createdRowCount += await _context.SaveChangesAsync();
                }
            }

            foreach (var item in input.MarksAllots)
            {
                //bool isDuplicateScriptSl = await _context.MarksAllots.AnyAsync(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId && k.Examiner == input.Examiner && k.BarCode == item.Scriptsl);
                bool isDuplicateScriptSl = await _context.MarksAllots.AnyAsync(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId && k.Examiner == input.Examiner && k.BarCode == item.BarCode);
                if (isDuplicateScriptSl == true)
                {
                    return false;
                }
                item.Outmarks = outmarks;
                item.MonthId = input.MonthId;
                item.SessionYear = input.SessionYear;
                item.SubId = input.SubId;
                item.Grace = 0;
                item.Entryuser = input.EntryUser;
                item.Examiner = input.Examiner;
                double convertMarks = Convert.ToDouble(item.Marks ?? 0);
                double integerMarks = Math.Truncate(convertMarks);
                if ((convertMarks - integerMarks) >= 0.5)
                {
                    item.Marks = Convert.ToDecimal(integerMarks + 1);
                }
                else
                {
                    item.Marks = Convert.ToDecimal(integerMarks);
                }
                item.Grade = gradeDetails.Where(g => item.Marks >= g.StartingMarks && item.Marks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                _context.MarksAllots.Add(item);
                createdRowCount += await _context.SaveChangesAsync();
            }

            return createdRowCount > 0;
        }

        public async Task<bool> UpdateMarksAsync(MarksModel3 input)
        {
            decimal outmarks = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(g => g.Outofmarks).FirstOrDefaultAsync();

            decimal multiplier = 1;

            if (outmarks < 100 && outmarks != 0)
            {
                multiplier = 100 / outmarks;
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("Here is refno: " + refNo);
            List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

            int updatedRowCount = 0;

            //using var transaction = _context.Database.BeginTransaction();

            //try
            //{
            if (outmarks < 100 && outmarks != 0)
            {
                foreach (var item in input.MarksAllots)
                {
                    MarksAllot marksAllot = await _context.MarksAllots.Where(p => p.MonthId == input.MonthId && p.SessionYear == input.SessionYear && p.SubId == input.SubId && p.Examiner == input.Examiner && p.BarCode == item.BarCode && p.Scriptsl == item.Scriptsl).FirstOrDefaultAsync();
                    marksAllot.Outmarks = outmarks;
                    marksAllot.Marks = item.Marks;
                    double convertMarks = Convert.ToDouble(marksAllot.Marks ?? 0);
                    double integerMarks = Math.Truncate(convertMarks);
                    if ((convertMarks - integerMarks) >= 0.5)
                    {
                        marksAllot.Marks = Convert.ToDecimal(integerMarks + 1);
                    }
                    else
                    {
                        marksAllot.Marks = Convert.ToDecimal(integerMarks);
                    }
                    marksAllot.Grade = gradeDetails.Where(g => (marksAllot.Marks * multiplier) >= g.StartingMarks && (marksAllot.Marks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    //_context.Entry(marksAllot).State = EntityState.Modified;
                    _context.MarksAllots.Update(marksAllot);
                    updatedRowCount += await _context.SaveChangesAsync();
                    //_context.ChangeTracker.Clear();
                }
            }
            else
            {

                foreach (var item in input.MarksAllots)
                {
                    // System.Diagnostics.Debug.WriteLine(...)
                    var marksAllot = await _context.MarksAllots.Where(p => p.MonthId == input.MonthId && p.SessionYear == input.SessionYear && p.SubId == input.SubId && p.Examiner == input.Examiner && p.BarCode == item.BarCode && p.Scriptsl == item.Scriptsl).FirstOrDefaultAsync();
                    marksAllot.Outmarks = outmarks;
                    marksAllot.Marks = item.Marks;
                    double convertMarks = Convert.ToDouble(marksAllot.Marks ?? 0);
                    double integerMarks = Math.Truncate(convertMarks);
                    if ((convertMarks - integerMarks) >= 0.5)
                    {
                        marksAllot.Marks = Convert.ToDecimal(integerMarks + 1);
                    }
                    else
                    {
                        marksAllot.Marks = Convert.ToDecimal(integerMarks);
                    }
                    marksAllot.Grade = gradeDetails.Where(g => marksAllot.Marks >= g.StartingMarks && marksAllot.Marks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                    //System.Diagnostics.Debug.WriteLine("Here is grade: " + marksAllot.Grade);
                    //_context.Entry(marksAllot).State = EntityState.Modified;
                    //System.Diagnostics.Debug.WriteLine("Here is grade: " + marksAllot);
                    _context.MarksAllots.Update(marksAllot);
                    updatedRowCount += await _context.SaveChangesAsync();
                    //_context.ChangeTracker.Clear();
                }
            }

            //List<int?> barCodeCollection = input.MarksAllots.Select(i => i.BarCode).Distinct().ToList();
            //System.Diagnostics.Debug.WriteLine("Here is barcodes: " + string.Join(",", barCodeCollection));
            //List<int?> scriptSlCollection = input.MarksAllots.Select(i => i.Scriptsl).Distinct().ToList();
            //System.Diagnostics.Debug.WriteLine("Here is script sl: " + string.Join(",", scriptSlCollection));
            //List<MarksAllot> marksAllots = await _context.MarksAllots.Where(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId && k.Examiner == input.Examiner && barCodeCollection.Contains(k.BarCode) && scriptSlCollection.Contains(k.Scriptsl)).ToListAsync();
            //foreach (var item in marksAllots)
            //{
            //    _context.MarksAllots.Remove(item);
            //    await _context.SaveChangesAsync();
            //}

            //if (outmarks < 100 && outmarks != 0)
            //{
            //    foreach (var item in input.MarksAllots)
            //    {
            //        item.Grade = gradeDetails.Where(g => (item.Marks * multiplier) >= g.StartingMarks && (item.Marks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            //        _context.MarksAllots.Add(item);
            //        await _context.SaveChangesAsync();
            //    }
            //}
            //else
            //{
            //    foreach (var item in input.MarksAllots)
            //    {
            //        item.Grade = gradeDetails.Where(g => item.Marks >= g.StartingMarks && item.Marks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            //        System.Diagnostics.Debug.WriteLine("Here is grade: " + item.Grade);
            //        _context.MarksAllots.Add(item);
            //        await _context.SaveChangesAsync();
            //    }
            //}

            //    transaction.Commit();

            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            return updatedRowCount > 0;
        }

        public async Task<bool> UpdateSingleMarksWithGraceAsync(MarksModel8 input)
        {
            decimal outmarks = await _context.Subjects.Where(i => i.SubId == input.SubId).Select(g => g.Outofmarks).FirstOrDefaultAsync();

            decimal multiplier = 1;

            if (outmarks < 100 && outmarks != 0)
            {
                multiplier = 100 / outmarks;
            }

            int refNo = await _context.GradeSys.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId).Select(h => h.RefNo).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("Here is refno: " + refNo);
            List<GradeDetail> gradeDetails = await _context.GradeDetails.Where(o => o.RefNo == refNo).ToListAsync();

            int updatedRowCount = 0;

            //using var transaction = _context.Database.BeginTransaction();

            //try
            //{
            if (outmarks < 100 && outmarks != 0)
            {
                MarksAllot marksAllot = await _context.MarksAllots.Where(p => p.MonthId == input.MonthId && p.SessionYear == input.SessionYear && p.SubId == input.SubId && p.Examiner == input.Examiner && p.BarCode == input.BarCode && p.Scriptsl == input.Scriptsl).FirstOrDefaultAsync();
                marksAllot.Grace = input.Grace;

                //double convertMarks = Convert.ToDouble(marksAllot.Marks ?? 0);
                //double integerMarks = Math.Truncate(convertMarks);
                //if ((convertMarks - integerMarks) >= 0.5)
                //{
                //    marksAllot.Marks = Convert.ToDecimal(integerMarks + 1);
                //}
                //else
                //{
                //    marksAllot.Marks = Convert.ToDecimal(integerMarks);
                //}

                double convertTotalMarks = Convert.ToDouble((marksAllot.Marks ?? 0) + (marksAllot.Grace ?? 0));
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

                marksAllot.Grade = gradeDetails.Where(g => (totalMarks * multiplier) >= g.StartingMarks && (totalMarks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                //_context.Entry(marksAllot).State = EntityState.Modified;
                _context.MarksAllots.Update(marksAllot);
                updatedRowCount += await _context.SaveChangesAsync();
                //_context.ChangeTracker.Clear();

            }
            else
            {
                // System.Diagnostics.Debug.WriteLine(...)
                var marksAllot = await _context.MarksAllots.Where(p => p.MonthId == input.MonthId && p.SessionYear == input.SessionYear && p.SubId == input.SubId && p.Examiner == input.Examiner && p.BarCode == input.BarCode && p.Scriptsl == input.Scriptsl).FirstOrDefaultAsync();
                marksAllot.Grace = input.Grace;
                double convertTotalMarks = Convert.ToDouble((marksAllot.Marks ?? 0) + (marksAllot.Grace ?? 0));
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
                marksAllot.Grade = gradeDetails.Where(g => totalMarks >= g.StartingMarks && totalMarks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
                //System.Diagnostics.Debug.WriteLine("Here is grade: " + marksAllot.Grade);
                //_context.Entry(marksAllot).State = EntityState.Modified;
                //System.Diagnostics.Debug.WriteLine("Here is grade: " + marksAllot);
                _context.MarksAllots.Update(marksAllot);
                updatedRowCount += await _context.SaveChangesAsync();
                //_context.ChangeTracker.Clear();
            }

            //List<int?> barCodeCollection = input.MarksAllots.Select(i => i.BarCode).Distinct().ToList();
            //System.Diagnostics.Debug.WriteLine("Here is barcodes: " + string.Join(",", barCodeCollection));
            //List<int?> scriptSlCollection = input.MarksAllots.Select(i => i.Scriptsl).Distinct().ToList();
            //System.Diagnostics.Debug.WriteLine("Here is script sl: " + string.Join(",", scriptSlCollection));
            //List<MarksAllot> marksAllots = await _context.MarksAllots.Where(k => k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.SubId == input.SubId && k.Examiner == input.Examiner && barCodeCollection.Contains(k.BarCode) && scriptSlCollection.Contains(k.Scriptsl)).ToListAsync();
            //foreach (var item in marksAllots)
            //{
            //    _context.MarksAllots.Remove(item);
            //    await _context.SaveChangesAsync();
            //}

            //if (outmarks < 100 && outmarks != 0)
            //{
            //    foreach (var item in input.MarksAllots)
            //    {
            //        item.Grade = gradeDetails.Where(g => (item.Marks * multiplier) >= g.StartingMarks && (item.Marks * multiplier) <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            //        _context.MarksAllots.Add(item);
            //        await _context.SaveChangesAsync();
            //    }
            //}
            //else
            //{
            //    foreach (var item in input.MarksAllots)
            //    {
            //        item.Grade = gradeDetails.Where(g => item.Marks >= g.StartingMarks && item.Marks <= g.EndingMarks).Select(o => o.LetterGrade).FirstOrDefault();
            //        System.Diagnostics.Debug.WriteLine("Here is grade: " + item.Grade);
            //        _context.MarksAllots.Add(item);
            //        await _context.SaveChangesAsync();
            //    }
            //}

            //    transaction.Commit();

            //}
            //catch (Exception)
            //{
            //    return false;
            //}

            return updatedRowCount > 0;
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