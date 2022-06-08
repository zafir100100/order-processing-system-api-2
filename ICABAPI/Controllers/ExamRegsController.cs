using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    public class ExamRegsControllerModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RollNo { get; set; }
    }


    public class ExamRegsControllerModel25
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int SubId { get; set; }
    }

    public class GetReg
    {
        public int? RegNo { get; set; }
    }

    public class ExamRegsControllerModel2
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RollNoFrom { get; set; }
        public int RollNoTo { get; set; }
    }

    public class ExamRegsControllerModel3
    {
        public string SubjectName { get; set; }
        public string ExamDate { get; set; }
        public string ExamDay { get; set; }
        public string ExamDuration { get; set; }
    }

    public class ExamRegsControllerModel4
    {
        public string ExamLevelName { get; set; }
        public string SessionName { get; set; }
        public string ExamCenterName { get; set; }
        public int RegNo { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string ExamCenterAddress { get; set; }
        public string Imagepath { get; set; }
        //public byte[] ProfilePicture { get; set; }
        public List<ExamRegsControllerModel3> Schedules { get; set; }
        public string ControllerSign { get; set; }
    }

    public class ExamRegsControllerModel5
    {
        public int RegNo { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
    }

    public class ExamRegsControllerModel6
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int FormNumberFrom { get; set; }
        public int FormNumberTo { get; set; }
        public int? RollNumberStartsFrom { get; set; }
    }

    public class ExamRegsControllerModel7
    {
        public string FormNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int RegNo { get; set; }
        public int ExamRollno { get; set; }
        public int SubId { get; set; }
        public string Venue { get; set; }
    }

    public class ExamRegsControllerModel77
    {
        public List<ExamRegsControllerModel7> List { get; set; }
        public string Venue { get; set; }
    }

    public class ExamRegsControllerModel8
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int SubId { get; set; }
        public int RoomNo { get; set; }
        public DateTime ExamDate { get; set; }
        public int RollNoFrom { get; set; }
        public int RollNoTo { get; set; }
    }

    public class ExamRegsControllerModel9
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int SubId { get; set; }
        public int RoomNo { get; set; }
        public DateTime ExamDate { get; set; }
        public int RowSkip { get; set; }
    }

    public class ExamRegsControllerModel10
    {
        public int SlNo { get; set; }
        public int ExamRollno { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Signature { get; set; }
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public string ExamCenterName { get; set; }
        public string SubName { get; set; }
        public int RoomNo { get; set; }
        public DateTime ExamDate { get; set; }
    }

    public class ExamRegsControllerModel11
    {
        public int SlNo { get; set; }
        public int ExamRollno { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Imagepath { get; set; }
        public string Signature { get; set; }
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public string ExamCenterName { get; set; }
        public string SubName { get; set; }
        //public int RoomNo { get; set; }
        //public DateTime ExamDate { get; set; }
    }

    public class ExamRegsControllerModel12
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int SubId { get; set; }
        public int RoomNo { get; set; }
        public DateTime ExamDate { get; set; }
        public int RollNoFrom { get; set; }
        public int RollNoTo { get; set; }
        public int? RowSkip { get; set; }
        public int? RowTake { get; set; }
    }

    public class ExamRegsControllerModel13
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RegNo { get; set; }
    }

    public class ExamRegsControllerModel14
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int? SubId { get; set; }
        public int? ExamcenId { get; set; }
    }
    //[Authorize]
    public class ExamRegsControllerModel15 : ExamRegsControllerModel16
    {
        public int SubId { get; set; }
    }

    public class ExamRegsControllerModel16
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int RegNo { get; set; }
        public int ExamRollno { get; set; }
    }

    public class ExamRegsControllerModel17
    {
        public Subject Root { get; set; }
        public List<ExamRegsControllerModel15> Children { get; set; }
    }

    public class ExamRegsControllerModel18
    {
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public bool LeveledPassInfo { get; set; }
        public List<ExamRegsControllerModel19> Output { get; set; }
        public string ControllerSign { get; set; }

    }

    public class ExamRegsControllerModel19
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        [DefaultValue("F")]
        public string Grade { get; set; }
    }

    public class ExamRegsControllerModel20
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public int SubId { get; set; }
    }

    public class ExamRegsControllerModel21
    {
        public int SlNo { get; set; }
        public int ExamRollno { get; set; }
    }

    public class ExamRegsControllerModel22
    {
        public DateTime ExamDate { get; set; }
        public int RoomNo { get; set; }
    }

    public class ExamRegsControllerModel23
    {
        public ExamRegsControllerModel22 HeadingData { get; set; }
        public List<ExamRegsControllerModel11> Output { get; set; }
    }

    public class ExamRegsControllerModel24
    {
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class CsvInput
    {
        public int RegNoTo { get; set; }
        public int RegNoFrom { get; set; }
        public string Password { get; set; }
        public string Cohort1 { get; set; }
        public DateTime? DownloadDateTime { get; set; }
        public int Subid { get; set; }
        public int SessionYear { get; set; }
        public int Monthid { get; set; }
        public int Examlevel { get; set; }
        public string Username { get; set; }
        public int FullCsv { get; set; } = 0;
    }

    public class DeleteCohortModal
    {
        public string Cohort1 { get; set; }
        public int SessionYear { get; set; }
        public int Monthid { get; set; }
        public int Examlevel { get; set; }
        public int Subid { get; set; }
    }

    public class CsvOutput
    {
        public int RegNo { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExamLevelName { get; set; }
        public string ExamCenterName { get; set; }
        public string Mobile { get; set; }
        public string Cohort { get; set; }
        public int ProfileRegNo { get; set; }
        public int ExamRollno { get; set; }
        public int ExamcenId { get; set; }
    }

    public class ExamRegsController : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamRegsController(ModelContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get Mixed RollNumber Allocation - from db, get current allocation
        /// </summary>
        [HttpPost("GetMixedRollNumberAllocation")]
        public async Task<ActionResult<ResponseDto2>> GetMixedRollNumberAllocation2([FromBody] ExamRegsControllerModel6 input)
        {
            int? resultLockStatus = await _context.ResultLocks.Where(rl => rl.ExamLevel == input.ExamLevel && rl.SessionYear == input.SessionYear && rl.MonthId == input.MonthId).Select(g => g.RLock).FirstOrDefaultAsync();
            if (resultLockStatus == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The given criteria aleardy exists in result lock",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelSubstring = examLevelName.Substring(0, 1);

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string monthNameSubstring = monthName.Substring(0, 1);

            if (input.MonthId == 3)
            {
                monthNameSubstring = "A";
            }

            string sessionYearString = input.SessionYear.ToString();
            if (sessionYearString == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }
            string sessionYearSubstring = sessionYearString.Substring(2, 2);

            List<string> formNumbers = new();

            for (int i = input.FormNumberFrom; i <= input.FormNumberTo; i++)
            {
                string generatedFormNumber = examLevelSubstring + monthNameSubstring + sessionYearSubstring + "-" + i.ToString();
                //System.Diagnostics.Debug.WriteLine(generatedFormNumber);
                formNumbers.Add(generatedFormNumber);
            }

            var queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && formNumbers.Contains(er.FormNo))
                                           // join rs in _context.Set<RegSubject>()
                                           //     on er.Ref equals rs.RefNo
                                       join sr1 in _context.Set<StuReg1>()
                                           on er.RegNo equals sr1.RegNo into grouping
                                       from subsr1 in grouping.DefaultIfEmpty()
                                       select new ExamRegsControllerModel7
                                       {
                                           FormNo = er.FormNo,
                                           Name = subsr1.Name,
                                           FName = subsr1.FName,
                                           MName = subsr1.MName,
                                           RegNo = er.RegNo,
                                           ExamRollno = er.ExamRollno,
                                           Venue = er.Venue
                                           //SubId = rs.SubId
                                       }).OrderBy(h => h.ExamRollno).ToListAsync();
            //}).OrderBy(h => h.SubId).ThenBy(d => d.FormNo).ToListAsync();

            if (queryStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rollnumbercount = input.RollNumberStartsFrom ?? 0; //await _context.ExamRegs.AnyAsync(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.ExamcenId == input.ExamcenId) == false ? input.RollNumberStartsFrom ?? 0 : await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.ExamcenId == input.ExamcenId).MaxAsync(o => o.ExamRollno) + 1;
            foreach (var item in queryStudents)
            {
                System.Diagnostics.Debug.WriteLine("here is roll: " + item.ExamRollno);
                if (item.ExamRollno != 0)
                {
                    if (item.ExamRollno >= input.RollNumberStartsFrom)
                    {
                        if (queryStudents.Count(i => i.ExamRollno == item.ExamRollno) > 1)
                        {
                            return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                            {
                                Message = "Roll number " + item.ExamRollno + " is duplicate. Please change it.",
                                Success = false,
                                Payload = null
                            });
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
                else if (item.ExamRollno == 0)
                {
                    item.ExamRollno = rollnumbercount; //Getroll(input.ExamLevel, input.MonthId, input.SessionYear, input.ExamcenId, queryStudents.Where(i => i.ExamRollno != 0).Select(o => o.ExamRollno).ToList(), input.RollNumberStartsFrom ?? 0, rollnumbercount);
                    rollnumbercount++;
                }

                //item.ExamRollno = rollnumbercount;

                //ExamReg examRegNew = await _context.ExamRegs.Where(er => er.RegNo == item.RegNo && er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && er.FormNo == item.FormNo).FirstOrDefaultAsync();

                //if (examRegNew == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //    {
                //        Message = "No info found in exam registration for registration number: " + item.RegNo,
                //        Success = false,
                //        Payload = null
                //    });
                //}
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students",
                Success = true,
                Payload = queryStudents.OrderBy(o => o.ExamRollno).ToList()
            });
        }


        /// <summary>
        /// Registered Regno Moodle CSV
        /// </summary>
        [HttpPost("FetchRegisteredRegNoForMoodle")]
        public async Task<ActionResult<ResponseDto2>> FetchRegisteredRegNoForMoodle([FromBody] ExamRegsControllerModel25 input)
        {
            if (input.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Examlevel can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month Id can not be null",
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
            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }

            string subjectName = await _context.Subjects.Where(b => b.SubId == input.SubId).Select(g => g.SubName).FirstOrDefaultAsync();

            int? uptoReg = await _context.SendMoodleCsvs.Where(x => x.Monthid == input.MonthId && x.SessionYear == input.SessionYear
                                                                                      && x.Subid == input.SubId).MaxAsync(o => o.RegNoTo);


            List<GetReg> ExistedReg = (from er in _context.ExamRegs
                                       from rs in _context.RegSubjects.Where(x => x.RefNo == er.Ref)
                                       where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId
                                       && er.SessionYear == input.SessionYear && rs.SubId == input.SubId)
                                       orderby er.RegNo
                                       select new GetReg
                                       {
                                           RegNo = er.RegNo,
                                       }).ToList();

            int? maxRegUsed = ExistedReg.Max(i => i.RegNo);

            if (maxRegUsed == uptoReg)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "All Reg No already downloaded for " + subjectName + " of " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                    Success = false,
                    Payload = null
                });
            }


            List<GetReg> fetchedReg = uptoReg == null ? (from er in _context.ExamRegs
                                                         from rs in _context.RegSubjects.Where(x => x.RefNo == er.Ref)
                                                         where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId
                                                         && er.SessionYear == input.SessionYear && rs.SubId == input.SubId && er.RegNo > 0)
                                                         orderby er.RegNo
                                                         select new GetReg
                                                         {

                                                             RegNo = er.RegNo,
                                                         }).ToList() :
                                      (from er in _context.ExamRegs
                                       from rs in _context.RegSubjects.Where(x => x.RefNo == er.Ref)
                                       where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId
                                       && er.SessionYear == input.SessionYear && rs.SubId == input.SubId && er.RegNo > uptoReg)
                                       orderby er.RegNo
                                       select new GetReg
                                       {
                                           RegNo = er.RegNo,
                                       }).ToList();

            List<SendMoodleCsv> sendMoodleCsvs = await _context.SendMoodleCsvs.Where(i => i.Monthid == input.MonthId && i.SessionYear == input.SessionYear && i.Subid == input.SubId).ToListAsync();
            var existingCohortList = (from h in sendMoodleCsvs
                                      select new
                                      {
                                          h.Cohort1,
                                          h.RegNoFrom,
                                          h.RegNoTo
                                      }).ToList();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of registered students",
                Success = true,
                Payload = new
                {
                    Output = fetchedReg,
                    Examlevel = examLevelName,
                    Month = monthName,
                    Session = input.SessionYear,
                    SubjectName = subjectName,
                    Count = fetchedReg.Count,
                    ExistingCohort = existingCohortList
                }
            });

        }

        /// <summary>
        /// CSV Download For Moodle
        /// </summary>
        [HttpPost("ExportCsvForMoodleByCohort")]
        public async Task<ActionResult<ResponseDto2>> ExportCsvForMoodleByCohort([FromBody] CsvInput input)
        {
            if (input.FullCsv < 1)
            {
                if (input.RegNoFrom < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "registration number from can not be null",
                        Success = false,
                        Payload = null
                    });
                }
                if (input.RegNoTo < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "registration number from can not be null",
                        Success = false,
                        Payload = null
                    });
                }
                if (input.RegNoFrom > input.RegNoTo)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Registration number from can not be greater than registration number to",
                        Success = false,
                        Payload = null
                    });
                }
                if (input.Subid < 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Subject id can not be null",
                        Success = false,
                        Payload = null
                    });
                }
            }


            if (input.Monthid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month Id can not be null",
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

            if (input.Cohort1 == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Cohort can not be null",
                    Success = false,
                    Payload = null
                });
            }

            string ExamLevelName = await _context.Subjects.Where(i => i.SubId == input.Examlevel).Select(k => k.SubName).FirstOrDefaultAsync();
            if (ExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level not found",
                    Success = false,
                    Payload = null
                });
            }
            string MonthName = await _context.SessionInfos.Where(i => i.SessionId == input.Monthid).Select(k => k.SessionName).FirstOrDefaultAsync();
            if (MonthName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month not found",
                    Success = false,
                    Payload = null
                });
            }
            bool isCohortExists = await _context.MoodleCohorts.AnyAsync(i => i.Cohort == input.Cohort1);
            if (isCohortExists == true)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The cohort: " + input.Cohort1 + " already exists.",
                    Success = false,
                    Payload = null
                });
            }




            Random random = new Random();
            SendMoodleCsv sendMoodleCsv = new();
            sendMoodleCsv.Cohort1 = input.Cohort1;
            sendMoodleCsv.DownloadDateTime = input.DownloadDateTime == null ? DateTime.Now : input.DownloadDateTime;
            sendMoodleCsv.Monthid = input.Monthid;
            sendMoodleCsv.Password = input.Password == null ? "icab" + random.Next(1000, 9999) : input.Password;
            sendMoodleCsv.RegNoFrom = input.RegNoFrom;
            sendMoodleCsv.RegNoTo = input.RegNoTo;
            sendMoodleCsv.SessionYear = input.SessionYear;
            sendMoodleCsv.Subid = input.Subid;
            sendMoodleCsv.Username = input.Username;
            _context.SendMoodleCsvs.Add(sendMoodleCsv);

            List<CsvOutput> csvOutputs = input.FullCsv == 1 ?
                                await (from er in _context.ExamRegs.Where(er => er.ExamLevel == input.Examlevel && er.MonthId == input.Monthid && er.SessionYear == input.SessionYear)
                                           //from rs in _context.RegSubjects.Where(rs => er.Ref == rs.RefNo && rs.SubId == input.Subid)
                                       from ec in _context.ExamCentres.Where(ec => ec.CenId == er.ExamcenId)
                                       from sr1 in _context.StuReg1s.Where(sr1 => er.RegNo == sr1.RegNo)
                                       select new CsvOutput
                                       {
                                           RegNo = er.RegNo,
                                           Password = sendMoodleCsv.Password,
                                           Email = sr1.Email,
                                           FirstName = sr1.Name,
                                           LastName = ".",
                                           ExamLevelName = ExamLevelName,
                                           ExamCenterName = ec.Name,
                                           Mobile = sr1.Cell,
                                           Cohort = sendMoodleCsv.Cohort1,
                                           ProfileRegNo = er.RegNo,
                                           ExamRollno = er.ExamRollno,
                                           ExamcenId = er.ExamcenId
                                       }).OrderByDescending(k => k.ExamcenId).ThenBy(l => l.ExamRollno).ToListAsync() :
                await (from er in _context.ExamRegs.Where(er => er.ExamLevel == input.Examlevel && er.MonthId == input.Monthid && er.SessionYear == input.SessionYear && er.RegNo >= input.RegNoFrom && er.RegNo <= input.RegNoTo)
                       from rs in _context.RegSubjects.Where(rs => er.Ref == rs.RefNo && rs.SubId == input.Subid)
                       from ec in _context.ExamCentres.Where(ec => ec.CenId == er.ExamcenId)
                       from sr1 in _context.StuReg1s.Where(sr1 => er.RegNo == sr1.RegNo)
                       select new CsvOutput
                       {
                           RegNo = er.RegNo,
                           Password = sendMoodleCsv.Password,
                           Email = sr1.Email,
                           FirstName = sr1.Name,
                           LastName = ".",
                           ExamLevelName = ExamLevelName,
                           ExamCenterName = ec.Name,
                           Mobile = sr1.Cell,
                           Cohort = sendMoodleCsv.Cohort1,
                           ProfileRegNo = er.RegNo,
                           ExamRollno = er.ExamRollno,
                           ExamcenId = er.ExamcenId
                       }).OrderByDescending(k => k.ExamcenId).ThenBy(l => l.ExamRollno).ToListAsync();
            foreach (var item in csvOutputs)
            {
                string k = "";
                string[] g = NameConv(item.FirstName);
                for (int i = 0; i < (g.Length - 1); i++)
                {
                    k += g[i] + " ";
                }
                item.FirstName = k;
                item.LastName = g.LastOrDefault();
            }
            DataTable dataTable = new DataTable("MOODLE DATA " + DateTime.Now);
            dataTable.Columns.AddRange(new DataColumn[11] { new DataColumn("username"),
                                            new DataColumn("password"),new DataColumn("email"),new DataColumn("firstname"),new DataColumn("lastname"),new DataColumn("pfofile_field_level"),new DataColumn("city"),new DataColumn("phone1"),new DataColumn("cohort1"),new DataColumn("profile_field_reg_no"),new DataColumn("exam_roll_no")});
            foreach (CsvOutput item in csvOutputs)
            {
                dataTable.Rows.Add(item.RegNo, item.Password, item.Email, item.FirstName, item.LastName, item.ExamLevelName, item.ExamCenterName, item.Mobile, item.Cohort, item.ProfileRegNo, item.ExamRollno);
            }
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in dataTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(sb.ToString());
            if (byteArray == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "CSV creation failed. Something went wrong, please try again later",
                    Success = false,
                    Payload = null
                });
            }
            bool isCreated = await _context.SaveChangesAsync() > 0;
            if (isCreated == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "CSV creation failed. Something went wrong, please try again later",
                    Success = false,
                    Payload = null
                });
            }

            foreach (var item in csvOutputs)
            {
                MoodleCohort moodleCohort = new();

                moodleCohort.City = item.ExamCenterName;
                moodleCohort.Cohort = item.Cohort;
                moodleCohort.Email = item.Cohort;
                moodleCohort.ExamLevel = input.Examlevel;
                moodleCohort.MonthId = input.Monthid;
                moodleCohort.MoodleUserId = null;
                moodleCohort.Name = item.FirstName;
                moodleCohort.Password = item.Password;
                moodleCohort.Phone = item.Mobile;
                moodleCohort.SessionYear = input.SessionYear;
                moodleCohort.SubId = input.Subid;
                moodleCohort.Username = item.RegNo.ToString();

                _context.MoodleCohorts.Add(moodleCohort);
                await _context.SaveChangesAsync();
            }



            //System.IO.File.WriteAllBytes("C:\\Users\\Satcom-IT\\Downloads\\mycsv.csv", byteArray);
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "CSV Downloaded for " + csvOutputs.Count + " students",
                Success = true,
                Payload = new
                {
                    Output = byteArray,
                    ExamlevelName = await _context.Subjects.Where(b => b.SubId == input.Examlevel).Select(g => g.SubName).FirstOrDefaultAsync(),
                    Month = await _context.SessionInfos.Where(i => i.SessionId == input.Monthid).Select(k => k.SessionName).FirstOrDefaultAsync(),
                    Sessionyear = input.SessionYear,
                    Subject = await _context.Subjects.Where(b => b.SubId == input.Subid).Select(g => g.SubName).FirstOrDefaultAsync(),
                    Cohort = input.Cohort1,
                    RegFrom = input.RegNoFrom,
                    RegTo = input.RegNoTo
                }
            });
        }

        /// <summary>
        /// delete moodle data by cohort For Moodle
        /// </summary>
        [HttpDelete("DeleteMoodleDataByCohort")]
        public async Task<ActionResult<ResponseDto2>> DeleteMoodleDataByCohort([FromBody] DeleteCohortModal input)
        {
            if (input.Examlevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Examlevel can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Monthid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month Id can not be null",
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

            if (input.Subid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Cohort1 == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Cohort can not be null",
                    Success = false,
                    Payload = null
                });
            }

            string ExamLevelName = await _context.Subjects.Where(i => i.SubId == input.Examlevel).Select(k => k.SubName).FirstOrDefaultAsync();
            if (ExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level not found",
                    Success = false,
                    Payload = null
                });
            }

            string MonthName = await _context.SessionInfos.Where(i => i.SessionId == input.Monthid).Select(k => k.SessionName).FirstOrDefaultAsync();
            if (MonthName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month not found",
                    Success = false,
                    Payload = null
                });
            }

            bool isCohortExist = await _context.SendMoodleCsvs.AnyAsync(i => i.Cohort1 == input.Cohort1 && i.Monthid == input.Monthid && i.SessionYear == input.SessionYear && i.Subid == input.Subid);
            if (isCohortExist == false)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The cohort: " + input.Cohort1 + " not found.",
                    Success = false,
                    Payload = null
                });
            }

            bool isCohortExists = await _context.MoodleCohorts.AnyAsync(i => i.Cohort == input.Cohort1 && i.MonthId == input.Monthid && i.SessionYear == input.SessionYear && i.ExamLevel == input.Examlevel);
            if (isCohortExists == false)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The cohort: " + input.Cohort1 + " not found.",
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();
            try
            {
                List<MoodleCohort> moodleCohorts = await _context.MoodleCohorts.Where(i => i.Cohort == input.Cohort1 && i.MonthId == input.Monthid && i.SessionYear == input.SessionYear && i.ExamLevel == input.Examlevel && i.SubId == input.Subid).ToListAsync();
                if (moodleCohorts.Count > 0)
                {
                    foreach (var item in moodleCohorts)
                    {
                        _context.MoodleCohorts.Remove(item);
                        int isDeleted = await _context.SaveChangesAsync();
                    }
                }
                List<SendMoodleCsv> moodleCsvs = await _context.SendMoodleCsvs.Where(i => i.Cohort1 == input.Cohort1 && i.Monthid == input.Monthid && i.SessionYear == input.SessionYear && i.Subid == input.Subid).ToListAsync();
                if (moodleCsvs.Count > 0)
                {
                    foreach (var item in moodleCsvs)
                    {
                        _context.SendMoodleCsvs.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Something went wrong. Please try again later",
                    Success = false,
                    Payload = new
                    {
                        e.Message,
                        e.StackTrace,
                        e.InnerException,
                        e.Source,
                        e.Data
                    }
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Data deleted",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Get Old RollNumber Allocation2 - from db, get current allocation
        /// </summary>
        [HttpPost("GetOldRollNumberAllocation2")]
        public async Task<ActionResult<ResponseDto2>> GetPreviewForRollNumberAllocation2([FromBody] ExamRegsControllerModel6 input)
        {
            int? resultLockStatus = await _context.ResultLocks.Where(rl => rl.ExamLevel == input.ExamLevel && rl.SessionYear == input.SessionYear && rl.MonthId == input.MonthId).Select(g => g.RLock).FirstOrDefaultAsync();
            if (resultLockStatus == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The given criteria aleardy exists in result lock",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelSubstring = examLevelName.Substring(0, 1);

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string monthNameSubstring = monthName.Substring(0, 1);

            if (input.MonthId == 3)
            {
                monthNameSubstring = "A";
            }

            string sessionYearString = input.SessionYear.ToString();
            if (sessionYearString == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }
            string sessionYearSubstring = sessionYearString.Substring(2, 2);

            List<string> formNumbers = new();

            for (int i = input.FormNumberFrom; i <= input.FormNumberTo; i++)
            {
                string generatedFormNumber = examLevelSubstring + monthNameSubstring + sessionYearSubstring + "-" + i.ToString();
                //System.Diagnostics.Debug.WriteLine(generatedFormNumber);
                formNumbers.Add(generatedFormNumber);
            }

            var queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && formNumbers.Contains(er.FormNo))
                                           // join rs in _context.Set<RegSubject>()
                                           //     on er.Ref equals rs.RefNo
                                       join sr1 in _context.Set<StuReg1>()
                                           on er.RegNo equals sr1.RegNo into grouping
                                       from subsr1 in grouping.DefaultIfEmpty()
                                       select new ExamRegsControllerModel7
                                       {
                                           FormNo = er.FormNo,
                                           Name = subsr1.Name,
                                           FName = subsr1.FName,
                                           MName = subsr1.MName,
                                           RegNo = er.RegNo,
                                           ExamRollno = er.ExamRollno,
                                           //SubId = rs.SubId
                                       }).OrderBy(h => h.ExamRollno).ToListAsync();
            //}).OrderBy(h => h.SubId).ThenBy(d => d.FormNo).ToListAsync();

            if (queryStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //int rollnumbercount = 1;
            //foreach (var item in queryStudents)
            //{
            //    item.ExamRollno = rollnumbercount;

            //    ExamReg examRegNew = await _context.ExamRegs.Where(er => er.RegNo == item.RegNo && er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && er.FormNo == item.FormNo).FirstOrDefaultAsync();

            //    if (examRegNew == null)
            //    {
            //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            //        {
            //            Message = "No info found in exam registration for registration number: " + item.RegNo,
            //            Success = false,
            //            Payload = null
            //        });
            //    }
            //}

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students after roll number allocation",
                Success = true,
                Payload = queryStudents
            });
        }

        /// <summary>
        /// Get Preview For RollNumber Allocation2 - auto generated from x to y
        /// </summary>
        [HttpPost("GetPreviewForRollNumberAllocation2")]
        public async Task<ActionResult<ResponseDto2>> GetPreviewForRollNumberAllocation([FromBody] ExamRegsControllerModel6 input)
        {
            int? resultLockStatus = await _context.ResultLocks.Where(rl => rl.ExamLevel == input.ExamLevel && rl.SessionYear == input.SessionYear && rl.MonthId == input.MonthId).Select(g => g.RLock).FirstOrDefaultAsync();
            if (resultLockStatus == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The given criteria aleardy exists in result lock",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelSubstring = examLevelName.Substring(0, 1);

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string monthNameSubstring = monthName.Substring(0, 1);

            if (input.MonthId == 3)
            {
                monthNameSubstring = "A";
            }

            string sessionYearString = input.SessionYear.ToString();
            if (sessionYearString == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }
            string sessionYearSubstring = sessionYearString.Substring(2, 2);

            List<string> formNumbers = new();

            for (int i = input.FormNumberFrom; i <= input.FormNumberTo; i++)
            {
                string generatedFormNumber = examLevelSubstring + monthNameSubstring + sessionYearSubstring + "-" + i.ToString();
                System.Diagnostics.Debug.WriteLine("fn is : " + generatedFormNumber);
                formNumbers.Add(generatedFormNumber);
            }

            var queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && formNumbers.Contains(er.FormNo))
                                           //join rs in _context.Set<RegSubject>()
                                           //    on er.Ref equals rs.RefNo
                                           //join sr1 in _context.Set<StuReg1>()
                                           //    on er.RegNo equals sr1.RegNo into grouping
                                           //from subsr1 in grouping.DefaultIfEmpty()

                                       join sr1 in _context.Set<StuReg1>()
                                        on er.RegNo equals sr1.RegNo into grouping
                                       from subsr1 in grouping.DefaultIfEmpty()

                                       select new ExamRegsControllerModel7
                                       {
                                           FormNo = er.FormNo,
                                           Name = subsr1.Name,
                                           FName = subsr1.FName,
                                           MName = subsr1.MName,
                                           RegNo = er.RegNo,
                                           ExamRollno = er.ExamRollno
                                           //SubId = rs.SubId
                                       }).ToListAsync();
            //}).OrderBy(h => h.SubId).ThenBy(d => d.FormNo).ToListAsync();

            if (queryStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rollnumbercount = input.RollNumberStartsFrom == null || input.RollNumberStartsFrom < 1 ? 1 : input.RollNumberStartsFrom ?? 0;
            foreach (var item in queryStudents)
            {
                item.ExamRollno = rollnumbercount;

                ExamReg examRegNew = await _context.ExamRegs.Where(er => er.RegNo == item.RegNo && er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && er.FormNo == item.FormNo).FirstOrDefaultAsync();

                if (examRegNew == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No info found in exam registration for registration number: " + item.RegNo,
                        Success = false,
                        Payload = null
                    });
                }

                examRegNew.ExamRollno = rollnumbercount;

                //_context.Entry(examRegNew).State = EntityState.Modified;

                //try
                //{
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ExamRegExists(examRegNew.RegNo, examRegNew.ExamLevel, examRegNew.MonthId, examRegNew.SessionYear, examRegNew.ExamcenId))
                //    {
                //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //        {
                //            Message = "No info exists in exam registration for given criteria with registration number: " + examRegNew.RegNo,
                //            Success = false,
                //            Payload = null
                //        });
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}

                rollnumbercount++;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students after roll number allocation",
                Success = true,
                Payload = queryStudents
            });
        }

        /// <summary>
        /// Create RollNumber Allocation2 - create after preview/fetch old
        /// </summary>
        [HttpPost("CreateRollNumberAllocation2")]
        public async Task<ActionResult<ResponseDto2>> CreateRollNumberAllocation2([FromBody] ExamRegsControllerModel77 input)
        {
            foreach (var item in input.List)
            {
                if (input.List.Count(i => i.ExamRollno == item.ExamRollno) > 1)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Roll number " + item.ExamRollno + " is duplicate. Please change it.",
                        Success = false,
                        Payload = null
                    });
                }
            }

            //ExamReg er = await _context.ExamRegs.Where(i => i.FormNo == input.FirstOrDefault().FormNo && i.RegNo == input.FirstOrDefault().RegNo).FirstOrDefaultAsync();
            //int? resultLockStatus = await _context.ResultLocks.Where(rl => rl.ExamLevel == er.ExamLevel && rl.SessionYear == er.SessionYear && rl.MonthId == er.MonthId).Select(g => g.RLock).FirstOrDefaultAsync();
            //if (resultLockStatus == 1)
            //{
            //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            //    {
            //        Message = "The given criteria aleardy exists in result lock",
            //        Success = false,
            //        Payload = null
            //    });
            //}
            int[] mytasks;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //int threadCount = Process.GetCurrentProcess().Threads.Count;
                //int inputCount = input.Count;
                //var batchSize = (int)Math.Ceiling((double)inputCount / threadCount); // 100;
                //int numberOfBatches = (int)Math.Ceiling((double)input.Count() / batchSize);
                var updateTasks = new List<Task<int>>();
                foreach (var item in input.List)
                {
                    ExamReg examReg = await _context.ExamRegs.Where(i => i.FormNo == item.FormNo && i.RegNo == item.RegNo).FirstOrDefaultAsync();
                    if (examReg != null)
                    {
                        examReg.ExamRollno = item.ExamRollno;
                        examReg.Venue = input.Venue;
                        _context.ExamRegs.Update(examReg);
                        updateTasks.Add(_context.SaveChangesAsync());
                    }
                }
                //ensure all queries are complete
                mytasks = await Task.WhenAll(updateTasks);


                ////old code
                //foreach (var item in input)
                //{
                //    ExamReg examReg = await _context.ExamRegs.Where(i => i.FormNo == item.FormNo && i.RegNo == item.RegNo).FirstOrDefaultAsync();
                //    //ExamReg examReg2 = examReg;
                //    if (examReg != null)
                //    {
                //        examReg.ExamRollno = item.ExamRollno;
                //        _context.ExamRegs.Update(examReg);
                //        await _context.SaveChangesAsync();
                //    }
                //}

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Something went wrong. Please try again later",
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
                Message = "Roll number allocation created successfully for " + input.List.Count + " students",
                Success = true,
                Payload = new
                {
                    InputCount = input.List.Count,
                    FinishedCount = mytasks.Length,
                    Threads = Process.GetCurrentProcess().Threads.Count
                    //FInishedTasks = mytasks
                }
            });
            ;
        }








        // old code

        // 3.16.2
        [HttpPost("GetSubjectWiseTotalCandidates")]
        public async Task<ActionResult<ResponseDto2>> GetSubjectWiseTotalCandidates([FromBody] ExamRegsControllerModel24 input)
        {
            List<TabulationsControllerModel33> op = new();
            List<ExamCentre> examCentres = await _context.ExamCentres.OrderBy(l => l.CenId).ToListAsync();
            if (examCentres.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center data found",
                    Success = false,
                    Payload = null
                });
            }
            List<Subject> elsubjects = await _context.Subjects.Where(i => i.SubId == 61 || i.SubId == 62 || i.SubId == 63).OrderBy(j => j.SubId).ToListAsync();
            if (elsubjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level data found",
                    Success = false,
                    Payload = null
                });
            }
            if (elsubjects != null && elsubjects.Count > 0 && examCentres != null && examCentres.Count > 0)
            {
                // foreach exam level
                foreach (var item in elsubjects)
                {
                    var query = (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == item.SubId && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                 join rs in _context.Set<RegSubject>()
                                 on er.Ref equals rs.RefNo
                                 select new
                                 {
                                     er.ExamLevel,
                                     er.ExamcenId,
                                     er.RegNo,
                                     rs.SubId
                                 }).OrderBy(i => i.SubId).ToList();
                    if (query.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No data found",
                            Success = false,
                            Payload = null
                        });
                    }
                    TabulationsControllerModel33 op1 = new();
                    op1.ExamLevel = item.SubId;
                    op1.ExamLevelName = item.SubName;
                    List<TabulationsControllerModel32> op2 = new();
                    List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == item.SubId).OrderBy(j => j.SubId).ToListAsync();
                    if (subjects != null && subjects.Count > 0)
                    {
                        // foreach subject in that exam level
                        foreach (var element in subjects)
                        {
                            TabulationsControllerModel32 op3 = new();
                            op3.SubId = element.SubId;
                            op3.SubName = element.SubName;
                            List<TabulationsControllerModel31> op4 = new();
                            // foreach exam center for that subject
                            foreach (var row in examCentres)
                            {
                                TabulationsControllerModel31 op5 = new();
                                op5.CenId = row.CenId;
                                op5.Total = query.Count(i => i.SubId == element.SubId && i.ExamcenId == row.CenId);
                                op4.Add(op5);
                            }
                            op3.CenterDetails = op4;
                            op3.Total = op3.CenterDetails.Sum(o => o.Total);
                            op2.Add(op3);
                        }
                    }
                    op1.ExamLevelDetails = op2;
                    List<TabulationsControllerModel31> top11 = new();
                    List<TabulationsControllerModel31> top22 = new();
                    foreach (var examCentre in examCentres)
                    {
                        TabulationsControllerModel31 top111 = new();
                        top111.CenId = examCentre.CenId;
                        top111.Total = query.Where(o => o.ExamLevel == item.SubId && o.ExamcenId == examCentre.CenId).Select(o => o.RegNo).Distinct().ToList().Count;
                        top11.Add(top111);

                        //    // equivalent query
                        //    //SELECT er.REG_NO ,COUNT(rs.SUB_ID) FROM EXAM_REG er
                        //    //LEFT OUTER JOIN REG_SUBJECT rs
                        //    //ON er."REF" = rs.REF_NO
                        //    //WHERE er.EXAM_LEVEL = 61
                        //    //AND er.MONTH_ID = 2
                        //    //AND er.SESSION_YEAR = 2019
                        //    //GROUP BY er.REG_NO
                        //    //HAVING COUNT(rs.SUB_ID) = 7

                        var q = await (from e in _context.Set<ExamReg>()
                                       where e.ExamLevel == item.SubId && e.MonthId == input.MonthId && e.SessionYear == input.SessionYear && e.ExamcenId == examCentre.CenId
                                       join r in _context.Set<RegSubject>() on e.Ref equals r.RefNo
                                       group e by e.RegNo into g
                                       where g.Count() == _context.Subjects.Count(i => i.Parent == item.SubId)
                                       select new
                                       {
                                           g.Key
                                       }).ToListAsync();

                        TabulationsControllerModel31 top222 = new();
                        top222.CenId = examCentre.CenId;
                        top222.Total = q.Count(l => l.Key != 0);
                        top22.Add(top222);
                    }

                    op1.FirstRow = top11;
                    op1.FirstRowTotal = op1.FirstRow.Sum(k => k.Total);
                    op1.SecondRow = top22;
                    op1.SecondRowTotal = op1.SecondRow.Sum(k => k.Total);
                    op.Add(op1);
                }
            }

            bool isRowCountValid = op.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Subject wise total candidates: " : "No data found",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new
                {
                    Output = op
                } : null
            });
        }

        /// <summary>
        /// Get Grade Sheet For Individual
        /// </summary>
        [HttpPost("GetGradeSheetForIndividual")]
        public async Task<ActionResult<ResponseDto2>> GetGradeSheetForIndividual([FromBody] ExamRegsControllerModel1 input)
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

            if (input.RollNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Roll number " + input.RollNo + " can not be null",
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

            ExamReg examReg = await _context.ExamRegs.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear && k.ExamRollno == input.RollNo).FirstOrDefaultAsync();

            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Roll number " + input.RollNo + " not found in exam registration for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == examReg.RegNo).FirstOrDefaultAsync();

            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration number " + examReg.RegNo + " not found in student registration for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isCanceled = await _context.StuCancels.AnyAsync(i => i.RegNo == stuReg1.RegNo && i.CwFlag == 0);
            if (isCanceled == true)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result held up",
                    Success = false,
                    Payload = null
                });
            }


            string controllerSign = await _context.Signatures.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync();

            if (controllerSign == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No controller signature info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToListAsync();

            List<ExamRegsControllerModel19> tempOutput = (from s in subjects

                                                          select new ExamRegsControllerModel19
                                                          {
                                                              SubId = s.SubId,
                                                              SubName = s.SubName,
                                                              Grade = "F"
                                                          }).OrderBy(i => i.SubId).ToList();

            List<ExamRegsControllerModel19> tempOutput2 = await (from ba in _context.Set<BarcodeAllot>().Where(o => o.RegNo == examReg.RegNo)
                                                                 from s in _context.Set<Subject>().Where(s => ba.SubId == s.SubId)
                                                                 from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode && ba.ExamLevel == input.ExamLevel && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)

                                                                 select new ExamRegsControllerModel19
                                                                 {
                                                                     SubId = ba.SubId ?? 0,
                                                                     SubName = s.SubName,
                                                                     Grade = ma.Grade
                                                                 }).OrderBy(i => i.SubId).ToListAsync();

            foreach (var item in tempOutput)
            {
                ExamRegsControllerModel19 temp = tempOutput2.Where(i => i.SubId == item.SubId).FirstOrDefault();

                if (temp != null)
                {
                    item.Grade = temp.Grade;
                    //System.Diagnostics.Debug.WriteLine("here is grade: " + temp.Grade);
                }
            }

            if (tempOutput == null || tempOutput.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Result not found for registration number " + examReg.RegNo + " for given criteria",
                    Success = false,
                    Payload = null
                });
            }

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


                foreach (var element in tempOutput)
                {
                    var tempop4 = exdata.Where(i => i.RegNo == stuReg1.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        if (tempop4.ExempSub == 612)
                        {
                            bool isInSetExmpMous = await _context.SetExmpMous.AnyAsync(i => i.RegNo == stuReg1.RegNo);

                            if (isInSetExmpMous == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }

                            bool isInConversionCourseMarks = await _context.ConversionCourseMarks.AnyAsync(i => i.RegNo == stuReg1.RegNo);

                            if (isInConversionCourseMarks == true)
                            {
                                element.Grade = "ex";
                                continue;
                            }
                        }

                        element.Grade = "ex";
                        continue;
                    }

                    if (element.SubId == 612)
                    {
                        bool isInExData2 = exdata2.Any(i => i.RegNo == stuReg1.RegNo);

                        if (isInExData2 == true)
                        {
                            element.Grade = "ex";
                            continue;
                        }
                    }

                    if (element.SubId == 617)
                    {
                        bool isInExData3 = exdata3.Any(i => i.RegNo == stuReg1.RegNo);

                        if (isInExData3 == true)
                        {
                            element.Grade = "ex";
                            continue;
                        }
                    }
                }

                // ep

                var abc = await (from m in _context.VwMarksfinals
                                 where (m.ExamLevel == 41 || m.ExamLevel == 61) && (m.Grade == "A" || m.Grade == "B")
                                 && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                                (
                                    (m.SessionYear < input.SessionYear)

                                    ||

                                    (
                                        input.MonthId == 3 ? false :
                                        input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                        input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) || (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                                    )
                                )

                                 orderby m.RegNo, m.SubId
                                 select new
                                 {
                                     RegNo = m.RegNo,
                                     //ExamRollno = b.ExamRollno,
                                     Examlevel = m.ExamLevel,
                                     //BarCode = b.BarCode,
                                     //Grade = m.Grade,
                                     SessionYear = m.SessionYear,
                                     MonthId = m.MonthId,
                                     EPSubId = m.SubId == 411 ? 611 :
                                               m.SubId == 412 ? 612 :
                                               m.SubId == 413 ? 613 :
                                               m.SubId == 414 ? 614 :
                                               m.SubId == 415 ? 615 :
                                               m.SubId == 416 ? 616 :
                                               m.SubId == 417 ? 617 :
                                               m.SubId == 418 ? 618 : m.SubId
                                 }).ToListAsync();


                foreach (var element in tempOutput)
                {
                    var tempop4 = abc.Where(i => i.RegNo == stuReg1.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        element.Grade = "ep";
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


                foreach (var element in tempOutput)
                {
                    var tempop4 = exdata.Where(i => i.RegNo == stuReg1.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        element.Grade = "ex";
                        continue;
                    }

                    if (element.SubId == 622)
                    {
                        var tempop5 = exresult.Where(i => i.RegNo == stuReg1.RegNo && i.SubId == element.SubId).FirstOrDefault();

                        if (tempop5 != null)
                        {
                            element.Grade = "ex";
                            continue;
                        }
                    }

                    if (element.SubId == 627)
                    {
                        bool isInExData3 = exdata3.Any(i => i.RegNo == stuReg1.RegNo);

                        if (isInExData3 == true)
                        {
                            element.Grade = "ex";
                            continue;
                        }
                    }
                }

                // ep

                var abc = await (from m in _context.VwMarksfinals
                                 where (m.ExamLevel == 42 || m.ExamLevel == 62) && (m.Grade == "A" || m.Grade == "B")
                                 && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                                (
                                    (m.SessionYear < input.SessionYear)

                                    ||

                                    (
                                        input.MonthId == 3 ? false :
                                        input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                        input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) || (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                                    )
                                )
                                 orderby m.RegNo, m.SubId
                                 select new
                                 {
                                     RegNo = m.RegNo,
                                     SessionYear = m.SessionYear,
                                     MonthId = m.MonthId,
                                     //ExamRollno = b.ExamRollno,
                                     Examlevel = m.ExamLevel,
                                     //BarCode = b.BarCode,
                                     //Grade = m.Grade,
                                     //SessionYear = b.SessionYear,
                                     EPSubId = m.SubId == 421 ? 621 :
                                                   m.SubId == 422 ? 622 :
                                                   m.SubId == 423 ? 623 :
                                                   m.SubId == 424 ? 624 :
                                                   m.SubId == 425 ? 625 :
                                                   m.SubId == 426 ? 626 :
                                                   m.SubId == 427 ? 627 :
                                                   m.SubId == 428 ? 628 : m.SubId
                                 }).ToListAsync();


                foreach (var element in tempOutput)
                {
                    var tempop4 = abc.Where(i => i.RegNo == stuReg1.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        element.Grade = "ep";
                    }
                }

            }

            else if (input.ExamLevel == 63)
            {
                // ep

                var abc = await (from m in _context.VwMarksfinals
                                 where (m.ExamLevel == 63 || m.ExamLevel == 51) && (m.Grade == "A" || m.Grade == "B") && m.SubId != 512
                                 && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                                (
                                    (m.SessionYear < input.SessionYear)

                                    ||

                                    (
                                        input.MonthId == 3 ? false :
                                        input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                        input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) || (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                                    )
                                )

                                 orderby m.RegNo, m.SubId
                                 select new
                                 {
                                     RegNo = m.RegNo,
                                     SessionYear = m.SessionYear,
                                     MonthId = m.MonthId,
                                     //ExamRollno = b.ExamRollno,
                                     Examlevel = m.ExamLevel,
                                     //BarCode = b.BarCode,
                                     //Grade = m.Grade,
                                     //SessionYear = b.SessionYear,
                                     EPSubId = m.SubId == 511 ? 631 :
                                         m.SubId == 513 ? 632 :
                                         m.SubId == 514 ? 633 : m.SubId
                                 }).ToListAsync();


                foreach (var element in tempOutput)
                {
                    var tempop4 = abc.Where(i => i.RegNo == stuReg1.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                    if (tempop4 != null)
                    {
                        element.Grade = "ep";
                    }
                }
            }

            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }

            bool LevelNotPassed = false;

            foreach (var element in tempOutput)
            {
                if (element.Grade == "ep" || element.Grade == "ex" || element.Grade == "A" || element.Grade == "B")
                {
                    continue;
                }
                else
                {
                    LevelNotPassed = true;
                }
                //System.Diagnostics.Debug.WriteLine(element.Grade + "" + " Shuvo ");
            }

            bool levelPassedStatus = false;

            if (input.ExamLevel == 63 && LevelNotPassed == false)
            {
                levelPassedStatus = true;
            }
            else if (input.ExamLevel == 62 && LevelNotPassed == false)
            {
                levelPassedStatus = true;
            }
            else if (input.ExamLevel == 61 && LevelNotPassed == false)
            {
                levelPassedStatus = true;
            }
            else
            {
                levelPassedStatus = false;
            }

            ExamRegsControllerModel18 output = new();

            output.ExamLevelName = examLevelSubject.SubName;
            output.MonthName = sessionInfo.SessionName;
            output.Name = stuReg1.Name;
            output.FName = stuReg1.FName;
            output.MName = stuReg1.MName;
            output.ExamRollNo = examReg.ExamRollno;
            output.RegNo = stuReg1.RegNo;
            output.Output = tempOutput;
            output.ControllerSign = controllerSign;
            output.LeveledPassInfo = levelPassedStatus;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Grade Sheet (Individual) details for roll number: " + input.RollNo,
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get ExamReg By Examlevel, Monthid, Sessionyear and Regno
        /// </summary>
        [HttpPost("GetExamRegByExamlevelMonthidSessionyearRegno")]
        public async Task<ActionResult<ResponseDto2>> GetExamRegByExamlevelMonthidSessionyearRegno([FromBody] ExamRegsControllerModel13 input)
        {
            var examReg = await _context.ExamRegs.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && l.RegNo == input.RegNo).FirstOrDefaultAsync();

            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration Number: " + input.RegNo + " was not found for the give criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam registration info for registration number: " + input.RegNo,
                Success = true,
                Payload = examReg
            });
        }

        /// <summary>
        /// Get all ExamReg list
        /// </summary>
        [HttpGet("GetAllExamRegs")]
        public async Task<ActionResult<ResponseDto2>> GetExamRegs()
        {
            var examReg = await _context.ExamRegs.OrderBy(a => a.ExamLevel).ThenBy(b => b.MonthId).ThenBy(c => c.SessionYear).ToListAsync();
            if (examReg == null || examReg.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam registration info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam registration info",
                Success = true,
                Payload = examReg
            });
        }

        /// <summary>
        /// Get ExamReg By Examlevel, Monthid, Sessionyear and Examcenid
        /// </summary>
        [HttpPost("GetExamRegByExamlevelMonthidSessionyearExamcenid")]
        public async Task<ActionResult<ResponseDto2>> GetExamReg([FromBody] ExamRegsControllerModel5 input5)
        {
            var examReg = await _context.ExamRegs.FindAsync(input5.RegNo, input5.ExamLevel, input5.MonthId, input5.SessionYear, input5.ExamcenId);

            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration Number: " + input5.RegNo + " was not found for the give criteria",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam registration info for registration number: " + input5.RegNo,
                Success = true,
                Payload = examReg
            });
        }

        /// <summary>
        /// Update Exam Reg
        /// </summary>
        [HttpPost("UpdateExamReg")]
        public async Task<ActionResult<ResponseDto2>> PutExamReg([FromBody] ExamReg examReg)
        {
            _context.Entry(examReg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamRegExists(examReg.RegNo, examReg.ExamLevel, examReg.MonthId, examReg.SessionYear, examReg.ExamcenId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No exam registration info found for registration number: " + examReg.RegNo,
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam registration info for registration number: " + examReg.RegNo + " updated successfully",
                Success = true,
                Payload = new { id = examReg.RegNo }
            });
        }

        /// <summary>
        /// Create Exam Reg
        /// </summary>
        [HttpPost("CreateExamReg")]
        public async Task<ActionResult<ResponseDto2>> PostExamReg([FromBody] ExamReg examReg)
        {
            _context.ExamRegs.Add(examReg);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamRegExists(examReg.RegNo, examReg.ExamLevel, examReg.MonthId, examReg.SessionYear, examReg.ExamcenId))
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Exam registration info for registration number: " + examReg.RegNo + " aleardy exists",
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam registration info created for registration number: " + examReg.RegNo,
                Success = true,
                Payload = new { id = examReg.RegNo }
            });
        }

        /// <summary>
        /// Delete Exam Reg
        /// </summary>
        [HttpPost("DeleteExamReg")]
        public async Task<ActionResult<ResponseDto2>> DeleteExamReg([FromBody] ExamRegsControllerModel5 input5)
        {
            var examReg = await _context.ExamRegs.FindAsync(input5.RegNo, input5.ExamLevel, input5.MonthId, input5.SessionYear, input5.ExamcenId);
            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam registration info found for registration number: " + examReg.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            _context.ExamRegs.Remove(examReg);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam registration info for registration number: " + examReg.RegNo + " deleted successfully",
                Success = true,
                Payload = new { id = examReg.RegNo }
            });
        }

        /// <summary>
        /// Create Roll Number Allocation
        /// </summary>
        [HttpPost("CreateRollNumberAllocation")]
        public async Task<ActionResult<ResponseDto2>> CreateRollNumberAllocation([FromBody] ExamRegsControllerModel6 input)
        {
            int? resultLockStatus = await _context.ResultLocks.Where(rl => rl.ExamLevel == input.ExamLevel && rl.SessionYear == input.SessionYear && rl.MonthId == input.MonthId).Select(g => g.RLock).FirstOrDefaultAsync();
            if (resultLockStatus == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The given criteria aleardy exists in result lock",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelSubstring = examLevelName.Substring(0, 1);

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for the given criteria",
                    Success = false,
                    Payload = null
                });
            }
            string monthNameSubstring = monthName.Substring(0, 1);

            string sessionYearString = input.SessionYear.ToString();
            if (sessionYearString == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }
            string sessionYearSubstring = sessionYearString.Substring(2, 2);

            List<string> formNumbers = new();

            for (int i = input.FormNumberFrom; i <= input.FormNumberTo; i++)
            {
                string generatedFormNumber = examLevelSubstring + monthNameSubstring + sessionYearSubstring + "-" + i.ToString();
                formNumbers.Add(generatedFormNumber);
            }

            var queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && formNumbers.Contains(er.FormNo))
                                       join rs in _context.Set<RegSubject>()
                                           on er.Ref equals rs.RefNo
                                       join sr1 in _context.Set<StuReg1>()
                                           on er.RegNo equals sr1.RegNo into grouping
                                       from subsr1 in grouping.DefaultIfEmpty()
                                       select new ExamRegsControllerModel7
                                       {
                                           FormNo = er.FormNo,
                                           Name = subsr1.Name,
                                           FName = subsr1.FName,
                                           MName = subsr1.MName,
                                           RegNo = er.RegNo,
                                           ExamRollno = er.ExamRollno,
                                           SubId = rs.SubId
                                       }).OrderBy(h => h.SubId).ThenBy(d => d.FormNo).ToListAsync();

            if (queryStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rollnumbercount = 1;
            foreach (var item in queryStudents)
            {
                item.ExamRollno = rollnumbercount;

                ExamReg examRegNew = await _context.ExamRegs.Where(er => er.RegNo == item.RegNo && er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId && er.FormNo == item.FormNo).FirstOrDefaultAsync();

                if (examRegNew == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No info found in exam registration for registration number: " + item.RegNo,
                        Success = false,
                        Payload = null
                    });
                }

                examRegNew.ExamRollno = rollnumbercount;

                _context.Entry(examRegNew).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamRegExists(examRegNew.RegNo, examRegNew.ExamLevel, examRegNew.MonthId, examRegNew.SessionYear, examRegNew.ExamcenId))
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No info exists in exam registration for given criteria with registration number: " + examRegNew.RegNo,
                            Success = false,
                            Payload = null
                        });
                    }
                    else
                    {
                        throw;
                    }
                }

                rollnumbercount++;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of students after roll number allocation",
                Success = true,
                Payload = queryStudents
            });
        }

        /// <summary>
        /// Get Roll Numbers For Roll Number Allocation
        /// </summary>
        [HttpPost("GetRollNumbersForRollNumberAllocation")]
        public async Task<ActionResult<ResponseDto2>> GetRollNumbersForRollNumberAllocation([FromBody] ExamRegsControllerModel20 input)
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

            if (input.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Subject id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.ExamcenId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }


            string subjectName = await _context.Subjects.Where(b => b.SubId == input.SubId).Select(g => g.SubName).FirstOrDefaultAsync();

            if (subjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Subject name not found for subject id: " + input.SubId,
                    Success = false,
                    Payload = null
                });
            }

            bool isExamCenterFound = await _context.ExamCentres.AnyAsync(b => b.CenId == input.ExamcenId);

            if (isExamCenterFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center found for center id: " + input.ExamcenId,
                    Success = false,
                    Payload = null
                });
            }

            List<ExamRegsControllerModel21> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId)
                                                                   from rs in _context.Set<RegSubject>().Where(rs => er.Ref == rs.RefNo && rs.SubId == input.SubId)
                                                                   select new ExamRegsControllerModel21
                                                                   {
                                                                       SlNo = 0,
                                                                       ExamRollno = er.ExamRollno
                                                                   }).OrderBy(d => d.ExamRollno).ToListAsync();

            if (queryStudents == null || queryStudents.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student info found",
                    Success = false,
                    Payload = null
                });
            }

            int rowCount = 1;

            foreach (var item in queryStudents)
            {
                item.SlNo = rowCount;
                rowCount++;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of student's roll number before allocation",
                Success = true,
                Payload = new
                {
                    ExamLevelName = examLevelName,
                    MonthName = monthName,
                    SubjectName = subjectName,
                    RollNumberAllocationDetails = queryStudents
                }
            });


        }

        /// <summary>
        /// Get Roll Number Allocation
        /// </summary>
        [HttpPost("GetRollNumberAllocation")]
        public async Task<ActionResult<ResponseDto2>> GetRollNumberAllocation([FromBody] ExamRegsControllerModel14 input)
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

            //if (input.SubId < 0)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Subject id can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            string subjectName = null;

            if (input.SubId != null && input.SubId != 0)
            {
                subjectName = await _context.Subjects.Where(b => b.SubId == input.SubId).Select(g => g.SubName).FirstOrDefaultAsync();

                if (subjectName == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Subject name not found for subject id: " + input.SubId,
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (input.SubId >= 1)
            {
                List<ExamRegsControllerModel16> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                       join rs in _context.Set<RegSubject>().Where(rs => rs.SubId == input.SubId)
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel16
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno
                                                                       }).OrderBy(d => d.ExamRollno).ToListAsync();

                //remove rolls who are in seatplan
                List<Seatplan> seatplans = await _context.Seatplans.Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear).ToListAsync();
                if (seatplans.Count > 0)
                {
                    foreach (var item in seatplans)
                    {
                        var rolls = queryStudents.Where(i => i.ExamRollno >= item.Rollfrom && i.ExamRollno <= item.Rollto).ToList();
                        if (rolls.Count > 0)
                        {
                            foreach (var element in rolls)
                            {
                                queryStudents.Remove(element);
                            }
                        }
                    }
                }
                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                int rowCount = 1;

                foreach (var item in queryStudents)
                {
                    item.SlNo = rowCount;
                    rowCount++;
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        SubjectName = subjectName,
                        RollNumberAllocationDetails = queryStudents
                    }
                });
            }

            else
            {
                List<ExamRegsControllerModel15> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                       join rs in _context.Set<RegSubject>()
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel15
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno,
                                                                           SubId = rs.SubId
                                                                       }).OrderBy(k => k.SubId).ThenBy(l => l.ExamRollno).ToListAsync();

                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                List<int> subjectIdCollection = queryStudents.Where(k => k.SubId != 0).Select(o => o.SubId).Distinct().ToList();

                //IDictionary<int, string> subjectsCollection = new Dictionary<int, string>();

                //foreach (var item in subjectIdCollection)
                //{
                //    subjectsCollection.Add(item, await _context.Subjects.Where(o => o.SubId == item).Select(k => k.SubName).FirstOrDefaultAsync());
                //}
                //List<Subject> subjects = _context.Subjects.Where(l => l.Parent == input.ExamLevel).ToListAsync();

                List<ExamRegsControllerModel17> output = new();

                //foreach (var item in queryStudents)
                //{
                //    item.SubName = subjectsCollection[item.SubId];
                //}

                foreach (var item in subjectIdCollection)
                {
                    ExamRegsControllerModel17 tempop = new();

                    tempop.Root = await _context.Subjects.Where(ii => ii.SubId == item).FirstOrDefaultAsync();
                    tempop.Children = queryStudents.Where(k => k.SubId == item).OrderBy(l => l.ExamRollno).ToList();

                    output.Add(tempop);
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        RollNumberAllocationDetails = output
                    }
                });
            }
        }

        /// <summary>
        /// Get Roll Number Allocation
        /// </summary>
        [HttpPost("GetRollNumberAllocationNew")]
        public async Task<ActionResult<ResponseDto2>> GetRollNumberAllocationNew([FromBody] ExamRegsControllerModel14 input)
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

            //if (input.SubId < 0)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Subject id can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            string subjectName = null;

            if (input.SubId != null && input.SubId != 0)
            {
                subjectName = await _context.Subjects.Where(b => b.SubId == input.SubId).Select(g => g.SubName).FirstOrDefaultAsync();

                if (subjectName == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Subject name not found for subject id: " + input.SubId,
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (input.SubId >= 1)
            {
                List<ExamRegsControllerModel16> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.ExamcenId == input.ExamcenId)
                                                                       join rs in _context.Set<RegSubject>().Where(rs => rs.SubId == input.SubId)
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel16
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno
                                                                       }).OrderBy(d => d.ExamRollno).ToListAsync();

                //remove rolls who are in seatplan
                List<Seatplan> seatplans = await _context.Seatplans.Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.SubId == input.SubId && er.CenId == input.ExamcenId).ToListAsync();
                if (seatplans.Count > 0)
                {
                    foreach (var item in seatplans)
                    {
                        var rolls = queryStudents.Where(i => i.ExamRollno >= item.Rollfrom && i.ExamRollno <= item.Rollto).ToList();
                        if (rolls.Count > 0)
                        {
                            foreach (var element in rolls)
                            {
                                queryStudents.Remove(element);
                            }
                        }
                    }
                }
                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                int rowCount = 1;

                foreach (var item in queryStudents)
                {
                    item.SlNo = rowCount;
                    rowCount++;
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        SubjectName = subjectName,
                        RollNumberAllocationDetails = queryStudents
                    }
                });
            }

            else
            {
                List<ExamRegsControllerModel15> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                       join rs in _context.Set<RegSubject>()
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel15
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno,
                                                                           SubId = rs.SubId
                                                                       }).OrderBy(k => k.SubId).ThenBy(l => l.ExamRollno).ToListAsync();

                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                List<int> subjectIdCollection = queryStudents.Where(k => k.SubId != 0).Select(o => o.SubId).Distinct().ToList();

                //IDictionary<int, string> subjectsCollection = new Dictionary<int, string>();

                //foreach (var item in subjectIdCollection)
                //{
                //    subjectsCollection.Add(item, await _context.Subjects.Where(o => o.SubId == item).Select(k => k.SubName).FirstOrDefaultAsync());
                //}
                //List<Subject> subjects = _context.Subjects.Where(l => l.Parent == input.ExamLevel).ToListAsync();

                List<ExamRegsControllerModel17> output = new();

                //foreach (var item in queryStudents)
                //{
                //    item.SubName = subjectsCollection[item.SubId];
                //}

                foreach (var item in subjectIdCollection)
                {
                    ExamRegsControllerModel17 tempop = new();

                    tempop.Root = await _context.Subjects.Where(ii => ii.SubId == item).FirstOrDefaultAsync();
                    tempop.Children = queryStudents.Where(k => k.SubId == item).OrderBy(l => l.ExamRollno).ToList();

                    output.Add(tempop);
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        RollNumberAllocationDetails = output
                    }
                });
            }
        }

        /// <summary>
        /// Get Roll Number Allocation
        /// </summary>
        [HttpPost("GetRollNumberAllocationNewForAllCenter")]
        public async Task<ActionResult<ResponseDto2>> GetRollNumberAllocationNewForAllCenter([FromBody] ExamRegsControllerModel14 input)
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

            //if (input.SubId < 0)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Subject id can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            string subjectName = null;

            if (input.SubId != null && input.SubId != 0)
            {
                subjectName = await _context.Subjects.Where(b => b.SubId == input.SubId).Select(g => g.SubName).FirstOrDefaultAsync();

                if (subjectName == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Subject name not found for subject id: " + input.SubId,
                        Success = false,
                        Payload = null
                    });
                }
            }

            if (input.SubId >= 1)
            {
                List<ExamRegsControllerModel16> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                       join rs in _context.Set<RegSubject>().Where(rs => rs.SubId == input.SubId)
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel16
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno
                                                                       }).OrderBy(d => d.ExamRollno).ToListAsync();

                List<ExamTimeSch> examTimes = await _context.ExamTimeSches.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == input.SubId).ToListAsync();
                if (examTimes.Count > 0)
                {
                    foreach (var item in examTimes)
                    {
                        var rolls = queryStudents.Where(i => i.ExamRollno >= item.RollFrom && i.ExamRollno <= item.RollTo).ToList();
                        if (rolls.Count > 0)
                        {
                            foreach (var element in rolls)
                            {
                                queryStudents.Remove(element);
                            }
                        }
                    }
                }
                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                int rowCount = 1;

                foreach (var item in queryStudents)
                {
                    item.SlNo = rowCount;
                    rowCount++;
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        SubjectName = subjectName,
                        RollNumberAllocationDetails = queryStudents
                    }
                });
            }

            else
            {
                List<ExamRegsControllerModel15> queryStudents = await (from er in _context.Set<ExamReg>().Where(er => er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                                                                       join rs in _context.Set<RegSubject>()
                                                                           on er.Ref equals rs.RefNo
                                                                       join sr1 in _context.Set<StuReg1>()
                                                                           on er.RegNo equals sr1.RegNo into grouping
                                                                       from subsr1 in grouping.DefaultIfEmpty()
                                                                       select new ExamRegsControllerModel15
                                                                       {
                                                                           FormNo = er.FormNo,
                                                                           Name = subsr1.Name,
                                                                           FName = subsr1.FName,
                                                                           MName = subsr1.MName,
                                                                           RegNo = er.RegNo,
                                                                           ExamRollno = er.ExamRollno,
                                                                           SubId = rs.SubId
                                                                       }).OrderBy(k => k.SubId).ThenBy(l => l.ExamRollno).ToListAsync();

                if (queryStudents == null || queryStudents.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student info found",
                        Success = false,
                        Payload = null
                    });
                }

                List<int> subjectIdCollection = queryStudents.Where(k => k.SubId != 0).Select(o => o.SubId).Distinct().ToList();

                //IDictionary<int, string> subjectsCollection = new Dictionary<int, string>();

                //foreach (var item in subjectIdCollection)
                //{
                //    subjectsCollection.Add(item, await _context.Subjects.Where(o => o.SubId == item).Select(k => k.SubName).FirstOrDefaultAsync());
                //}
                //List<Subject> subjects = _context.Subjects.Where(l => l.Parent == input.ExamLevel).ToListAsync();

                List<ExamRegsControllerModel17> output = new();

                //foreach (var item in queryStudents)
                //{
                //    item.SubName = subjectsCollection[item.SubId];
                //}

                foreach (var item in subjectIdCollection)
                {
                    ExamRegsControllerModel17 tempop = new();

                    tempop.Root = await _context.Subjects.Where(ii => ii.SubId == item).FirstOrDefaultAsync();
                    tempop.Children = queryStudents.Where(k => k.SubId == item).OrderBy(l => l.ExamRollno).ToList();

                    output.Add(tempop);
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + output.Count + " students after roll number allocation",
                    Success = true,
                    Payload = new
                    {
                        ExamLevelName = examLevelName,
                        MonthName = monthName,
                        RollNumberAllocationDetails = output
                    }
                });
            }
        }

        /// <summary>
        /// Get Admit Card For One Student
        /// </summary>
        [HttpPost("GetAdmitCardForOneStudent")]
        public async Task<ActionResult<ResponseDto2>> GetAdmitCardInfo1([FromBody] ExamRegsControllerModel1 input)
        {
            var examRegs = await _context.ExamRegs.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && l.ExamRollno == input.RollNo).FirstOrDefaultAsync();
            if (examRegs == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No info exists in exam registration",
                    Success = false,
                    Payload = null
                });
            }
            var subject_id_collection = await _context.RegSubjects.Where(l => l.RefNo == examRegs.Ref).Select(s => s.SubId).ToListAsync();
            if (subject_id_collection == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found in registration subject for reference number: " + string.Join(",", examRegs.Ref),
                    Success = false,
                    Payload = null
                });
            }
            var ets = input.ExamLevel == 61 ? await _context.ExamTimeSches.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && subject_id_collection.Contains(l.SubId) && examRegs.ExamRollno >= l.RollFrom && examRegs.ExamRollno <= l.RollTo).OrderBy(p => p.OrderNo).ToListAsync() : await _context.ExamTimeSches.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && subject_id_collection.Contains(l.SubId)).OrderBy(p => p.OrderNo).ToListAsync();
            if (ets == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject id data found in exam time schedule for subject id: " + string.Join(",", subject_id_collection),
                    Success = false,
                    Payload = null
                });
            }

            var sr1 = await _context.StuReg1s.Where(l => l.RegNo == examRegs.RegNo).FirstOrDefaultAsync();
            if (sr1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No data found in student registration for registration number: " + examRegs.RegNo,
                    Success = false,
                    Payload = null
                });
            }
            var si = await _context.SessionInfos.Where(l => l.SessionId == input.MonthId).FirstOrDefaultAsync();
            if (si == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No session info found for session id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }
            var sub = await _context.Subjects.Where(l => l.SubId == input.ExamLevel).FirstOrDefaultAsync();
            if (sub == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found for subject id: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }
            var ec = await _context.ExamCentres.Where(l => l.CenId == examRegs.ExamcenId).FirstOrDefaultAsync();
            if (ec == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center found for exam center id: " + examRegs.ExamcenId,
                    Success = false,
                    Payload = null
                });
            }

            var venue = await _context.ExamRegs.Where(x => x.ExamRollno == input.RollNo && x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear).Select(i => i.Venue).FirstOrDefaultAsync();

            string controllerSign = await _context.Signatures.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync();

            if (controllerSign == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No controller signature info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            List<ExamRegsControllerModel3> output1 = new();

            foreach (var item in ets)
            {
                ExamRegsControllerModel3 output = new();

                output.SubjectName = await _context.Subjects.Where(l => l.SubId == item.SubId).Select(x => x.SubName).FirstOrDefaultAsync();
                output.ExamDate = item.ExamDate.ToString("D");
                output.ExamDay = item.ExamDate.ToString("dddd");
                output.ExamDuration = item.ExamTime1 + "-" + item.ExamTime2;

                output1.Add(output);
            }

            ExamRegsControllerModel4 output2 = new();

            output2.ExamLevelName = sub.SubName;
            output2.SessionName = si.SessionName;
            output2.ExamCenterName = ec.Name;
            output2.ExamCenterAddress = venue;
            output2.RegNo = examRegs.RegNo;
            output2.RollNo = input.RollNo;
            output2.Name = sr1.Name;
            output2.FName = sr1.FName;
            output2.MName = sr1.MName;
            output2.ExamCenterAddress = venue;
            output2.Imagepath = sr1.Imagepath;
            output2.ControllerSign = controllerSign;

            output2.Schedules = output1;

            if (output2 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No admit card info for roll number: " + input.RollNo,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Admit card info for roll number: " + input.RollNo,
                Success = true,
                Payload = output2
            });
        }

        /// <summary>
        /// Get Admit Card For Selected Students
        /// </summary>
        [HttpPost("GetAdmitCardForSelectedStudents")]
        public async Task<ActionResult<ResponseDto2>> GetAdmitCardInfo2([FromBody] ExamRegsControllerModel2 input)
        {
            List<ExamRegsControllerModel4> op2 = new();
            if (input.RollNoFrom <= input.RollNoTo)
            {
                for (int i = input.RollNoFrom; i <= input.RollNoTo; i++)
                {
                    var examRegs = await _context.ExamRegs.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && l.ExamRollno == i).FirstOrDefaultAsync();
                    if (examRegs == null)
                    {
                        continue;
                    }
                    var subject_id_collection = await _context.RegSubjects.Where(l => l.RefNo == examRegs.Ref).Select(s => s.SubId).ToListAsync();
                    if (subject_id_collection == null)
                    {
                        continue;
                    }
                    var ets = input.ExamLevel == 61 ? await _context.ExamTimeSches.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && subject_id_collection.Contains(l.SubId) && examRegs.ExamRollno >= l.RollFrom && examRegs.ExamRollno <= l.RollTo).OrderBy(p => p.OrderNo).ToListAsync() : await _context.ExamTimeSches.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear && subject_id_collection.Contains(l.SubId)).OrderBy(p => p.OrderNo).ToListAsync();
                    if (ets == null)
                    {
                        continue;
                    }
                    var sr1 = await _context.StuReg1s.Where(l => l.RegNo == examRegs.RegNo).FirstOrDefaultAsync();
                    if (sr1 == null)
                    {
                        continue;
                    }
                    var si = await _context.SessionInfos.Where(l => l.SessionId == input.MonthId).FirstOrDefaultAsync();
                    if (si == null)
                    {
                        continue;
                    }
                    var sub = await _context.Subjects.Where(l => l.SubId == input.ExamLevel).FirstOrDefaultAsync();
                    if (sub == null)
                    {
                        continue;
                    }
                    var ec = await _context.ExamCentres.Where(l => l.CenId == examRegs.ExamcenId).FirstOrDefaultAsync();
                    if (ec == null)
                    {
                        continue;
                    }
                    string venue1 = await _context.ExamRegs.Where(x => x.ExamRollno >= input.RollNoFrom && x.ExamRollno <= input.RollNoTo && x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear).Select(i => i.Venue).FirstOrDefaultAsync();
                    // if venue not found in exam reg, take from seat plan
                    string venue2 = await _context.Seatplans.Where(x => input.RollNoFrom >= x.Rollfrom && input.RollNoTo <= x.Rollto && x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear).Select(i => i.Venue).FirstOrDefaultAsync();
                    string venue = venue1 ?? venue2 ?? null;
                    //if (venue == null)
                    //{
                    //    continue;
                    //}
                    string controllerSign = await _context.Signatures.Where(l => l.ExamLevel == input.ExamLevel && l.MonthId == input.MonthId && l.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync();

                    if (controllerSign == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No controller signature info found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    List<ExamRegsControllerModel3> output1 = new();

                    foreach (var item in ets)
                    {
                        ExamRegsControllerModel3 output = new();

                        output.SubjectName = await _context.Subjects.Where(l => l.SubId == item.SubId).Select(x => x.SubName).FirstOrDefaultAsync();
                        output.ExamDate = item.ExamDate.ToString("D");
                        output.ExamDay = item.ExamDate.ToString("dddd");
                        output.ExamDuration = item.ExamTime1 + "-" + item.ExamTime2;

                        output1.Add(output);
                    }

                    ExamRegsControllerModel4 output2 = new();

                    output2.ExamLevelName = sub.SubName;
                    output2.SessionName = si.SessionName;
                    output2.ExamCenterName = ec.Name;
                    output2.ExamCenterAddress = await _context.ExamRegs.Where(k => k.ExamRollno == i && k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(k => k.Venue).FirstOrDefaultAsync();
                    output2.RegNo = examRegs.RegNo;
                    output2.RollNo = i;
                    output2.Name = sr1.Name;
                    output2.FName = sr1.FName;
                    output2.MName = sr1.MName;
                    output2.Imagepath = sr1.Imagepath;
                    output2.ControllerSign = controllerSign;

                    output2.Schedules = output1;

                    op2.Add(output2);
                }
            }

            if (op2 == null || op2.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No admit card info for selected students roll number from: " + input.RollNoFrom + " to: " + input.RollNoTo,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Admit card info for selected students roll number from: " + input.RollNoFrom + " to: " + input.RollNoTo,
                Success = true,
                Payload = op2
            });
        }

        /// <summary>
        /// Get Exam Attendance Sheet Report
        /// </summary>
        [HttpPost("GetExamAttendanceSheetReport")]
        public async Task<ActionResult<ResponseDto2>> GetExamAttendenceSheetReport1([FromBody] ExamRegsControllerModel12 input1)
        {
            if (input1.RollNoTo < input1.RollNoFrom)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Roll number from can not be less than roll number to",
                    Success = false,
                    Payload = null
                });
            }

            var monthName = await _context.SessionInfos
                                          .Where(si => si.SessionId == input1.MonthId)
                                          .Select(s => s.SessionName)
                                          .FirstOrDefaultAsync();

            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month name found for month id: " + input1.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            var examLevelName = await _context.Subjects
                                              .Where(sub => sub.SubId == input1.ExamLevel)
                                              .Select(s => s.SubName)
                                              .FirstOrDefaultAsync();

            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level name found for exam level: " + input1.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            var examCenterName = await _context.ExamCentres
                                               .Where(ec => ec.CenId == input1.ExamcenId)
                                               .Select(s => s.Name)
                                               .FirstOrDefaultAsync();

            if (examCenterName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center name found for exam center id: " + input1.ExamcenId,
                    Success = false,
                    Payload = null
                });
            }

            var subjectName = await _context.Subjects
                                            .Where(sub => sub.SubId == input1.SubId)
                                            .Select(s => s.SubName)
                                            .FirstOrDefaultAsync();

            if (subjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject name found for subject id: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }

            if (input1.RowSkip < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Row skip number can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            if (input1.RowTake < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Row skip number can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            List<ExamRegsControllerModel11> examAttendenceSheet = new();

            if (input1.RowSkip >= 0 && input1.RowTake >= 1)
            {
                examAttendenceSheet = await (from er in _context.Set<ExamReg>()
                                             join rs in _context.Set<RegSubject>()
                                                  on er.Ref equals rs.RefNo // into groupjoin1
                                                                            //from rs in groupjoin1.DefaultIfEmpty()
                                             where er.ExamLevel == input1.ExamLevel && er.MonthId == input1.MonthId && er.SessionYear == input1.SessionYear && er.ExamcenId == input1.ExamcenId && rs.SubId == input1.SubId && er.ExamRollno >= input1.RollNoFrom && er.ExamRollno <= input1.RollNoTo
                                             select new ExamRegsControllerModel11
                                             {
                                                 SlNo = 0,
                                                 ExamRollno = er.ExamRollno,
                                                 RegNo = er.RegNo,
                                                 Name = _context.StuReg1s.Where(k => k.RegNo == er.RegNo).FirstOrDefault().Name,
                                                 FName = _context.StuReg1s.Where(k => k.RegNo == er.RegNo).FirstOrDefault().FName,
                                                 Imagepath = _context.StuReg1s.Where(k => k.RegNo == er.RegNo).Select(p => p.Imagepath).FirstOrDefault(),
                                                 Signature = null,
                                                 ExamLevelName = examLevelName,
                                                 MonthName = monthName,
                                                 ExamCenterName = examCenterName,
                                                 SubName = subjectName
                                             }).OrderBy(f => f.ExamRollno).Skip(input1.RowSkip ?? 0).Take(input1.RowTake ?? 0).ToListAsync();
            }

            if (examAttendenceSheet == null || examAttendenceSheet.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No attendance sheet found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int counter = 1 + (input1.RowSkip ?? 0);
            foreach (var item in examAttendenceSheet)
            {
                item.SlNo = counter;
                counter++;
            }

            ExamRegsControllerModel23 output = new();

            ExamRegsControllerModel22 tempop1 = new();

            tempop1.ExamDate = input1.ExamDate;
            tempop1.RoomNo = input1.RoomNo;

            output.HeadingData = tempop1;

            output.Output = examAttendenceSheet;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam attendance sheet info",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get Statement Of Additional Sheet
        /// </summary>
        [HttpPost("GetStatementOfAdditionalSheet")]
        public async Task<ActionResult<ResponseDto2>> GetStatementOfAdditionalSheet([FromBody] ExamRegsControllerModel9 input1)
        {
            var monthName = await _context.SessionInfos
                                          .Where(si => si.SessionId == input1.MonthId)
                                          .Select(s => s.SessionName)
                                          .FirstOrDefaultAsync();

            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No month name found for month id: " + input1.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            var examLevelName = await _context.Subjects
                                              .Where(sub => sub.SubId == input1.ExamLevel)
                                              .Select(s => s.SubName)
                                              .FirstOrDefaultAsync();

            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level name found for exam level: " + input1.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            var examCenterName = await _context.ExamCentres
                                               .Where(ec => ec.CenId == input1.ExamcenId)
                                               .Select(s => s.Name)
                                               .FirstOrDefaultAsync();

            if (examCenterName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center name found for exam center id: " + input1.ExamcenId,
                    Success = false,
                    Payload = null
                });
            }

            var subjectName = await _context.Subjects
                                            .Where(sub => sub.SubId == input1.SubId)
                                            .Select(s => s.SubName)
                                            .FirstOrDefaultAsync();

            if (subjectName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject name found for subject id: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }
            List<Seatplan> seatplans = await _context.Seatplans.Where(i => i.ExamLevel == input1.ExamLevel && i.MonthId == input1.MonthId && i.SessionYear == input1.SessionYear && i.SubId == input1.SubId && i.CenId == input1.ExamcenId && i.RoomNo == input1.RoomNo.ToString()).ToListAsync();
            Seatplan seatplan = seatplans.Skip(input1.RowSkip).FirstOrDefault();
            if (seatplan == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student found in this room",
                    Success = false,
                    Payload = null
                });
            }
            var statementOfAdditionalSheet =

            await (from er in _context.Set<ExamReg>()
                   join rs in _context.Set<RegSubject>()
                        on er.Ref equals rs.RefNo into groupjoin1
                   from rs in groupjoin1.DefaultIfEmpty()
                   where er.ExamLevel == input1.ExamLevel && er.MonthId == input1.MonthId && er.SessionYear == input1.SessionYear && er.ExamcenId == input1.ExamcenId && rs.SubId == input1.SubId && er.ExamRollno >= seatplan.Rollfrom && er.ExamRollno <= seatplan.Rollto
                   select new ExamRegsControllerModel10
                   {
                       SlNo = 0,
                       ExamRollno = er.ExamRollno,
                       RegNo = er.RegNo,
                       Name = _context.StuReg1s.Where(k => k.RegNo == er.RegNo).FirstOrDefault().Name,
                       Quantity = 0,
                       Signature = "",
                       ExamLevelName = examLevelName,
                       MonthName = monthName,
                       ExamCenterName = examCenterName,
                       SubName = subjectName,
                       RoomNo = input1.RoomNo,
                       ExamDate = input1.ExamDate
                   }).OrderBy(f => f.ExamRollno).ToListAsync();

            if (statementOfAdditionalSheet == null || statementOfAdditionalSheet.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No statement of additional sheet found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int counter = 1;
            foreach (var item in statementOfAdditionalSheet)
            {
                item.SlNo = counter;
                counter++;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Statement of additional sheet",
                Success = true,
                Payload = statementOfAdditionalSheet
            });
        }

        private bool ExamRegExists(int regNo, int examLevel, int monthId, int sessionYear, int examcenId)
        {
            return _context.ExamRegs.Any(e => e.RegNo == regNo && e.ExamLevel == examLevel && e.MonthId == monthId && e.SessionYear == sessionYear && e.ExamcenId == examcenId);
        }

        private string[] NameConv(string x)
        {
            string[] separatorPattern = new string[] { " " };
            string[] myArray = x.Split(separatorPattern, StringSplitOptions.RemoveEmptyEntries);
            return myArray;
        }

        private int Getroll(int el, int mid, int sy, int ec, List<int> ip, int start, int roll)
        {
            if (roll != 0 && ip.Any(i => i == roll))
            {
                return Getroll(el, mid, sy, ec, ip, start, roll + 1);
            }
            bool isExists = _context.ExamRegs.Any(i => i.ExamRollno != 0 && i.ExamcenId == ec && i.ExamLevel == el && i.MonthId == mid && i.SessionYear == sy);
            if (isExists)
            {
                return Getroll(el, mid, sy, ec, ip, start, roll + 1);
            }
            return roll;
        }

        private async Task<List<FormFillupModel29>> GetLevelWiseDetailsResultForOneStudent(FormFillupModel4 input)
        {
            List<FormFillupModel29> output = new();

            //get all subject for 61 and 62
            List<Subject> subjects = await _context.Subjects
                                                   .Where(i => (i.SubId == 61 || i.SubId == 62 || i.SubId == 63)
                                                            || (i.Parent == 61 || i.Parent == 62 || i.Parent == 63))
                                                   .ToListAsync();

            //initialize level 61
            FormFillupModel29 output61 = new();
            output61.ExamLevel = 61;
            output61.IsExamLevelPassed = false;
            List<TabulationsControllerModel2> collect61Subjects = new();
            foreach (Subject item in subjects.Where(i => i.Parent == 61).OrderBy(j => j.SubId).ToList())
            {
                TabulationsControllerModel2 eachSubjectResult = new();
                eachSubjectResult.SubId = item.SubId;
                eachSubjectResult.SubName = item.SubName;
                collect61Subjects.Add(eachSubjectResult);
            }
            output61.ResultDetails = collect61Subjects;

            //initialize level 62
            FormFillupModel29 output62 = new();
            output62.ExamLevel = 62;
            output62.IsExamLevelPassed = false;
            List<TabulationsControllerModel2> collect62Subjects = new();
            foreach (Subject item in subjects.Where(i => i.Parent == 62).OrderBy(j => j.SubId).ToList())
            {
                TabulationsControllerModel2 eachSubjectResult = new();
                eachSubjectResult.SubId = item.SubId;
                eachSubjectResult.SubName = item.SubName;
                collect62Subjects.Add(eachSubjectResult);
            }
            output62.ResultDetails = collect62Subjects;

            //initialize level 63
            FormFillupModel29 output63 = new();
            output63.ExamLevel = 63;
            output63.IsExamLevelPassed = false;
            List<TabulationsControllerModel2> collect63Subjects = new();
            foreach (Subject item in subjects.Where(i => i.Parent == 63).OrderBy(j => j.SubId).ToList())
            {
                TabulationsControllerModel2 eachSubjectResult = new();
                eachSubjectResult.SubId = item.SubId;
                eachSubjectResult.SubName = item.SubName;
                collect63Subjects.Add(eachSubjectResult);
            }
            output63.ResultDetails = collect63Subjects;

            //get all from vwMarksFinals
            List<VwMarksfinal> vwMarksfinals = await _context.VwMarksfinals
                                                             .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 1 || i.ExamLevel == 2 || i.ExamLevel == 3 || i.ExamLevel == 41 || i.ExamLevel == 42 || i.ExamLevel == 51 || i.ExamLevel == 61 || i.ExamLevel == 62 || i.ExamLevel == 63) && (i.Grade == "A" || i.Grade == "B")
                                                             ).ToListAsync();
            //get all form exemptedSubs
            List<ExemptedSub> exemptedSubs = await _context.ExemptedSubs
                                                           .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 41 || i.ExamLevel == 42 || i.ExamLevel == 51 || i.ExamLevel == 61 || i.ExamLevel == 62 || i.ExamLevel == 63))
                                                           .ToListAsync();

            //get all form student of icmab acca
            List<StudentOfIcmabAcca> studentOfIcmabAccas = await _context.StudentOfIcmabAccas
                                                                         .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 61 || i.ExamLevel == 62 || i.ExamLevel == 63))
                                                                         .ToListAsync();

            //get all from set exmp mou
            List<SetExmpMou> setExmpMous = await _context.SetExmpMous
                                                         .Where(i => i.RegNo == input.RegNo)
                                                         .ToListAsync();

            //get all from conversion course marks
            List<ConversionCourseMark> conversionCourseMarks = await _context.ConversionCourseMarks
                                                                             .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 41 || i.ExamLevel == 42) && (i.SubId == 412 || i.SubId == 422)).ToListAsync();


            //get grade: ex for level 1 for vwmarksfina1
            List<VwMarksfinal> vwMarksfinalsExamLevel1 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B")).ToList();
            foreach (TabulationsControllerModel2 item in output61.ResultDetails)
            {
                if (item.SubId == 617 && vwMarksfinalsExamLevel1.Any(s => s.ExamLevel == 61 && s.SubId == 617))
                {
                    item.Grade = "ex";
                    break;
                }
                else
                {
                    continue;
                }
            }

            foreach (TabulationsControllerModel2 item in output62.ResultDetails)
            {
                if (item.SubId == 627 && vwMarksfinalsExamLevel1.Any(s => s.ExamLevel == 62 && s.SubId == 627))
                {
                    item.Grade = "ex";
                    break;
                }
                else
                {
                    continue;
                }
            }

            //get grade: ex for level 2 from vw marks final
            List<VwMarksfinal> vwMarksfinalsExamLevel2 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).ToList();
            foreach (TabulationsControllerModel2 item in output61.ResultDetails)
            {
                if (item.SubId == 612 && vwMarksfinalsExamLevel2.Any(s => s.ExamLevel == 61 && s.SubId == 612))
                {
                    item.Grade = "ex";
                    break;
                }
                else
                {
                    continue;
                }
            }

            //get grade: ex for level 3 from vw marks final
            List<VwMarksfinal> vwMarksfinalExamLevel3 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel3 != null && vwMarksfinalExamLevel3.Count > 0)
            {
                // level 3 er minimum 1 subject e pass korle 41 er
                // 411, 412, 414, 415, 416, 417 e ex pabe
                //
                // level 3 er moddhey
                // jodi 34 pass kore, then 413->613 ex
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    if (vwMarksfinalExamLevel3.Count > 0)
                    {
                        if (item.SubId == 611 || item.SubId == 612 || item.SubId == 614 || item.SubId == 615 || item.SubId == 616 || item.SubId == 617)
                        {
                            item.Grade = "ex";
                            continue;
                        }
                        else if (item.SubId == 613)
                        {
                            if (vwMarksfinalExamLevel3.Where(i => i.SubId == 34 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                            {
                                item.Grade = "ex";
                                continue;
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
                    else
                    {
                        continue;
                    }
                }
                // level 3 er minimum 1 subject e pass korle 42 er 
                // 421, 422, 426, 427 e ex pabe
                //
                // level 3 er moddhey
                // jodi 33 pass kore, then 423->623 ex
                // jodi 34 pass kore, then 424->624 ex
                // jodi 35 pass kore, then 425->625 ex
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    if (vwMarksfinalExamLevel3.Count > 0)
                    {
                        if (item.SubId == 621 || item.SubId == 622 || item.SubId == 626 || item.SubId == 627)
                        {
                            item.Grade = "ex";
                            continue;
                        }
                        else if (item.SubId == 623)
                        {
                            if (vwMarksfinalExamLevel3.Where(i => i.SubId == 35 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                            {
                                item.Grade = "ex";
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (item.SubId == 624)
                        {
                            if (vwMarksfinalExamLevel3.Where(i => i.SubId == 34 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                            {
                                item.Grade = "ex";
                                continue;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (item.SubId == 625)
                        {
                            if (vwMarksfinalExamLevel3.Where(i => i.SubId == 33 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                            {
                                item.Grade = "ex";
                                continue;
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
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for level 41 from exempted sub
            List<ExemptedSub> exemptedSubsExamLevel41 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41).ToList();
            if (exemptedSubsExamLevel41 != null && exemptedSubsExamLevel41.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    if (item.SubId == 611 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 411).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 612 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 412).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 613 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 413).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 614 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 414).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 615 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 415).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 616 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 416).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 617 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 417).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for level 42 from vw marks final
            List<VwMarksfinal> vwMarksfinalExamLevel41 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel41 != null && vwMarksfinalExamLevel41.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    if (item.SubId == 611 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 411 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 612 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 412 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 613 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 413 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 614 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 414 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 615 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 415 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 616 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 416 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 617 && vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 417 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            List<ConversionCourseMark> conversionCourseMarksExamLevel41 = conversionCourseMarks.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41).ToList();

            //get grade: ex for level 42 from exempted subs
            List<ExemptedSub> exemptedSubsExamLevel42 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42).ToList();
            if (exemptedSubsExamLevel42 != null && exemptedSubsExamLevel42.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    if (item.SubId == 621 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 421).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 622 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 422).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 623 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 423).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 624 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 424).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 625 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 425).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 626 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 426).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 627 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 427).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for level 42 from vw marks final
            List<VwMarksfinal> vwMarksfinalExamLevel42 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel42 != null && vwMarksfinalExamLevel42.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    if (item.SubId == 621 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 421 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 622 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 422 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 623 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 423 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 624 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 424 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 625 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 425 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 626 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 426 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 627 && vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 427 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            List<ConversionCourseMark> conversionCourseMarksExamLevel42 = conversionCourseMarks.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42).ToList();

            //get grade: ex for level 51 from exempted sub
            List<ExemptedSub> exemptedSubsExamLevel51 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId != 512).ToList();
            if (exemptedSubsExamLevel51 != null && exemptedSubsExamLevel51.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output63.ResultDetails)
                {
                    if (item.SubId == 631 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 511).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 632 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 513).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 633 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 514).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for level 51 from vw marks final
            List<VwMarksfinal> vwMarksfinalExamLevel51 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel51 != null && vwMarksfinalExamLevel51.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output63.ResultDetails)
                {
                    if (item.SubId == 631 && vwMarksfinalExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 511 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 632 && vwMarksfinalExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 513 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else if (item.SubId == 633 && vwMarksfinalExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 514 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for 61 from icmab
            List<StudentOfIcmabAcca> studentOfIcmabAccasExamLevel61 = studentOfIcmabAccas.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61).ToList();
            foreach (TabulationsControllerModel2 item in output61.ResultDetails)
            {
                if (studentOfIcmabAccasExamLevel61.Any(s => s.ExamLevel == 61 && s.SubId == item.SubId))
                {
                    item.Grade = "ex";
                    continue;
                }
            }

            //get grade: ex for 61 from exemptedsubs
            List<ExemptedSub> exemptedSubsExamLevel61 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61).ToList();
            if (exemptedSubsExamLevel61 != null && exemptedSubsExamLevel61.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    if (item.SubId != 612 && exemptedSubsExamLevel61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.SubId == item.SubId && i.SubId != 612).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 612 && exemptedSubsExamLevel61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.SubId == item.SubId && i.SubId == 612).FirstOrDefault() != null)
                    {
                        bool isInSetExmpMous = setExmpMous.Any(i => i.RegNo == input.RegNo);

                        if (isInSetExmpMous == true)
                        {
                            item.Grade = "ex";
                            continue;
                        }

                        bool isInConversionCourseMarks = conversionCourseMarksExamLevel41.Any(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 412);

                        if (isInConversionCourseMarks == true)
                        {
                            item.Grade = "ex";
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for 61 from vwmarksfinal
            List<VwMarksfinal> vwMarksfinalExamLevel61 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel61 != null && vwMarksfinalExamLevel61.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    if (vwMarksfinalExamLevel61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for 62 from icmab
            List<StudentOfIcmabAcca> studentOfIcmabAccasExamLevel62 = studentOfIcmabAccas.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62).ToList();
            foreach (TabulationsControllerModel2 item in output62.ResultDetails)
            {
                if (studentOfIcmabAccasExamLevel62.Any(s => s.ExamLevel == 62 && s.SubId == item.SubId))
                {
                    item.Grade = "ex";
                    continue;
                }
            }

            //get grade: ex for 62 from exempted sub
            List<ExemptedSub> exemptedSubsExamLevel62 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62).ToList();
            if (exemptedSubsExamLevel62 != null && exemptedSubsExamLevel62.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    if (exemptedSubsExamLevel62.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && i.SubId == item.SubId).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    if (item.SubId == 622 && vwMarksfinalsExamLevel2.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for 62 from vwmarksfinal
            List<VwMarksfinal> vwMarksfinalExamLevel62 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel62 != null && vwMarksfinalExamLevel62.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    if (vwMarksfinalExamLevel62.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ep for 63 from vwmarksfinal
            List<VwMarksfinal> vwMarksfinalExamLevel63 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 63 && (i.Grade == "A" || i.Grade == "B")).ToList();
            if (vwMarksfinalExamLevel63 != null && vwMarksfinalExamLevel63.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output63.ResultDetails)
                {
                    if (vwMarksfinalExamLevel63.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 63 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault() != null)
                    {
                        item.Grade = "ep";
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            output.Add(output61);
            output.Add(output62);
            output.Add(output63);

            foreach (var item in output)
            {
                TabulationsControllerModel1 tabulationsControllerModel1 = new();
                tabulationsControllerModel1.ResultDetails = item.ResultDetails;
                if (item.ExamLevel == 61)
                {
                    int? maxRef = await _context.ExamRegs.Where(i => i.ExamLevel == 3 || i.ExamLevel == 41 || i.ExamLevel == 61).MaxAsync(j => j.Ref);
                    if (maxRef != null)
                    {
                        ExamReg examReg = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                        if (examReg != null)
                        {
                            item.LastAppearedExamlevel = examReg.ExamLevel;
                            item.LastAppearedMonthid = examReg.MonthId;
                            item.LastAppearedYear = examReg.SessionYear;
                            item.LastAppearedRollno = examReg.LastAppearedRollno;
                            item.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == item.LastAppearedExamlevel).Select(j => j.SubName).FirstOrDefaultAsync();
                            item.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == item.LastAppearedMonthid).Select(j => j.SessionName).FirstOrDefaultAsync();
                        }
                    }
                }
                else if (item.ExamLevel == 62)
                {
                    int? maxRef = await _context.ExamRegs.Where(i => i.ExamLevel == 3 || i.ExamLevel == 42 || i.ExamLevel == 62).MaxAsync(j => j.Ref);
                    if (maxRef != null)
                    {
                        ExamReg examReg = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                        if (examReg != null)
                        {
                            item.LastAppearedExamlevel = examReg.ExamLevel;
                            item.LastAppearedMonthid = examReg.MonthId;
                            item.LastAppearedYear = examReg.SessionYear;
                            item.LastAppearedRollno = examReg.LastAppearedRollno;
                            item.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == item.LastAppearedExamlevel).Select(j => j.SubName).FirstOrDefaultAsync();
                            item.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == item.LastAppearedMonthid).Select(j => j.SessionName).FirstOrDefaultAsync();
                        }
                    }
                }
                else if (item.ExamLevel == 63)
                {
                    int? maxRef = await _context.ExamRegs.Where(i => i.ExamLevel == 51 || i.ExamLevel == 63).MaxAsync(j => j.Ref);
                    if (maxRef != null)
                    {
                        ExamReg examReg = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                        if (examReg != null)
                        {
                            item.LastAppearedExamlevel = examReg.ExamLevel;
                            item.LastAppearedMonthid = examReg.MonthId;
                            item.LastAppearedYear = examReg.SessionYear;
                            item.LastAppearedRollno = examReg.LastAppearedRollno;
                            item.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == item.LastAppearedExamlevel).Select(j => j.SubName).FirstOrDefaultAsync();
                            item.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == item.LastAppearedMonthid).Select(j => j.SessionName).FirstOrDefaultAsync();
                        }
                    }
                }
                item.IsExamLevelPassed = IsExamLevelPassed(tabulationsControllerModel1);
                if (item.IsExamLevelPassed == true)
                {
                    ExamReg examRegTarget = new();
                    examRegTarget = input.ExamLevel == 62 ? await _context.ExamRegs.Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 41 || i.ExamLevel == 61)).OrderByDescending(p => p.Ref).FirstOrDefaultAsync()
                        : input.ExamLevel == 63 ? await _context.ExamRegs.Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 42 || i.ExamLevel == 62)).OrderByDescending(p => p.Ref).FirstOrDefaultAsync()
                        : null;
                    if (examRegTarget != null)
                    {
                        item.EarlierPassingExamLevel = examRegTarget.ExamLevel;
                        item.EarlierPassingExamLevelName = await _context.Subjects.Where(i => i.SubId == examRegTarget.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        item.EarlierPassingMonthId = examRegTarget.MonthId;
                        item.EarlierPassingMonthName = await _context.SessionInfos.Where(i => i.SessionId == examRegTarget.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                        item.EarlierPassingSessionYear = examRegTarget.SessionYear;
                    }
                }
            }
            return output;
        }

        private static bool IsExamLevelPassed(TabulationsControllerModel1 input)
        {
            foreach (var item in input.ResultDetails)
            {
                if (item.Grade != "A" && item.Grade != "B" && item.Grade != "ep" && item.Grade != "ex")
                {
                    return false;
                }
            }
            return true;
        }
    }

}


