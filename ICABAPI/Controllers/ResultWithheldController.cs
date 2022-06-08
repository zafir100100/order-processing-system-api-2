using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICABAPI.Controllers
{
     [Authorize]
    public class ResultWithheldController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public ResultWithheldController(ModelContext context)
        {
            _context = context;
        }
        public class StudentModel1
        {
            public int RegNo { get; set; }
        }

        public class StudentModel2
        {
            public int RegNo { get; set; }
            public DateTime? RegDate { get; set; }
            public DateTime? DateofBirth { get; set; }
            public string Name { get; set; }
            public string FathersName { get; set; }
            public string MothersName { get; set; }
            public string PresentAddress { get; set; }
            public string PermanentAddress { get; set; }
            public string Mobile { get; set; }
            public int? FId { get; set; }
            public string FirmName { get; set; }
            public int? PrinEnrNo { get; set; }
            public string PrinName { get; set; }
            public string WithheldStatus { get; set; }
            public string Imagepath { get; set; }
        }

        public class StudentModel3
        {
            public int? RegNo { get; set; }
            public int? RollNo { get; set; }
            public string Name { get; set; }
            public string FathersName { get; set; }
            public string FirmName { get; set; }
            public string PrinName { get; set; }
            public string Examlevel { get; set; }
            public string Monthid { get; set; }
            public int Sessionyear { get; set; }
            public DateTime? BlockDate { get; set; }
            public string Reason { get; set; }
            public string WithheldStatus { get; set; }

        }

        /// <summary>
        /// Get All Result Lock
        /// </summary>
        [HttpPost("GetStudentInfoByRegno")]
        public IActionResult GetStudentInfoByRegno([FromBody] StudentModel1 model1)
        {
            if (model1.RegNo == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "RegNo cannot be 0 or null",
                    Success = false,
                    Payload = null
                });
            }

            List<StuReg1> student = _context.StuReg1s.Where(x => x.RegNo == model1.RegNo).ToList();

            if (student.Count == 0 || student == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student found with RegNo: " + model1.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            if (student.Count > 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Multiple Student exists with RegNo: " + model1.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            int getRowCount = student.Count;

            bool isRowCountValid = getRowCount > 0 && getRowCount == 1;

            StuReg1 S1 = student.FirstOrDefault();

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isRowCountValid ? "Student info for RegNo: " + model1.RegNo : "Student get failed. Something went wrong, please try again later.",
                Success = isRowCountValid,
                Payload = isRowCountValid ? new StudentModel2
                {
                    RegNo = S1.RegNo,
                    RegDate = S1.RegDate,
                    DateofBirth = S1.Dob,
                    Name = S1.Name,
                    FathersName = S1.FName,
                    MothersName = S1.MName,
                    PresentAddress = S1.PreAdd,
                    PermanentAddress = S1.PerAdd,
                    Mobile = S1.Cell,
                    FId = S1.FId,
                    FirmName = S1.FirmName,
                    PrinEnrNo = S1.PrinEnrNo,
                    PrinName = S1.PrinName,
                    WithheldStatus = _context.ResultBlocks.Where(a => a.RegNo == S1.RegNo).FirstOrDefault() == null ? "Result never been blocked" : _context.ResultBlocks.Where(a => a.RegNo == S1.RegNo).FirstOrDefault().Status,
                    Imagepath = S1.Imagepath
                } : null
            });

        }

        /// <summary>
        /// Insert Result Withheld Info
        /// </summary>
        [HttpPost("InsertResultWithheldInfo")]
        public IActionResult InsertResultWithheldInfo([FromBody] ResultBlock blockStudent)
        {
            if (blockStudent.RegNo == 0 || blockStudent.RegNo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Regno number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (blockStudent.Reason == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reason number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<ResultBlock> rBlock = _context.ResultBlocks.Where(e => e.RegNo == blockStudent.RegNo).ToList();

            if (rBlock.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Student already exists with Regno: " + blockStudent.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            int createdRowCount = 0;
            _context.ResultBlocks.Add(blockStudent);
            createdRowCount += _context.SaveChanges();
            bool isCreated = createdRowCount > 0;

            return StatusCode(isCreated ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isCreated ? " Successfully Insert" : "Student insertion failed. Something went wrong, please try again later.",
                Success = isCreated,
                Payload = isCreated ? new { blockStudent.RegNo } : null
            });

        }

        /// <summary>
        /// Withheld Block Result
        /// </summary>
        [HttpPost("WithhelBlockResult")]
        public IActionResult WithhelBlockResult([FromBody] ResultBlock blockStudent)
        {
            if (blockStudent.RegNo == 0 || blockStudent.RegNo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Regno number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (blockStudent.Reason == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reason number can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<ResultBlock> rBlocks = _context.ResultBlocks.Where(e => e.RegNo == blockStudent.RegNo).ToList();

            if (rBlocks.Count == 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "No student found with Regno: " + blockStudent.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            ResultBlock rBlock = rBlocks.FirstOrDefault();

            ResultBlockArch rBlockarch = new ResultBlockArch();

            //Arch Insert
            rBlockarch.RegNo = rBlock.RegNo;
            rBlockarch.Rollno = rBlock.Rollno;
            rBlockarch.ExamLevel = rBlock.ExamLevel;
            rBlockarch.SessionYear = rBlock.SessionYear;
            rBlockarch.MonthId = rBlock.MonthId;
            rBlockarch.BlockDate = rBlock.BlockDate;
            rBlockarch.Reason = rBlock.Reason;
            rBlockarch.Entryuser = rBlock.Entryuser;
            rBlockarch.BackDate = DateTime.Today;
            rBlockarch.ChangeDate = DateTime.Today;
            rBlockarch.ChangeTime = DateTime.Now.ToString("HH:mm:ss");
            rBlockarch.BackReason = blockStudent.Reason;
            rBlockarch.Entryuserb = blockStudent.Entryuser;

            //Arch Insert
            int InsertArchRowCount = 0;
            _context.ResultBlockArches.Add(rBlockarch);
            InsertArchRowCount += _context.SaveChanges();
            bool iscreated = InsertArchRowCount > 0;

            if (iscreated == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Update failed. Something went wrong",
                    Success = false,
                    Payload = null
                });
            }

            //Update
            rBlock.BlockDate = blockStudent.BlockDate;
            rBlock.Reason = blockStudent.Reason;
            rBlock.Status = "Withdrawn";

            int updatedRowCount = 0;
            _context.ResultBlocks.Update(rBlock);
            updatedRowCount += _context.SaveChanges();
            bool isUpdated = updatedRowCount > 0;

            return StatusCode(isUpdated ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isUpdated ? "Blocked student info successfully updated" : " Update failed. Something went wrong, please try again later.",
                Success = isUpdated,
                Payload = isUpdated ? new { blockStudent.RegNo } : null
            });


        }

        /// <summary>
        /// Result Withheld Report
        /// </summary>
        [HttpGet("ResultWithheldReport")]
        public IActionResult ResultWithheldReport()
        {
            List<StudentModel3> studentInfo = (from rb in _context.ResultBlocks.Select(x => new { x.RegNo, x.Rollno, x.ExamLevel, x.MonthId, x.SessionYear, x.BlockDate, x.Reason, x.Status })
                                               from sr in _context.StuReg1s.Where(b => rb.RegNo == b.RegNo).Select(c => new { c.Name, c.FName, c.FirmName, c.PrinName })
                                               where (rb.Status == "Active")
                                               select new StudentModel3
                                               {
                                                   RegNo = rb.RegNo,
                                                   RollNo = rb.Rollno,
                                                   Name = sr.Name,
                                                   FathersName = sr.FName,
                                                   FirmName = sr.FirmName,
                                                   PrinName = sr.PrinName,
                                                   Examlevel = _context.Subjects.Where(g => g.SubId == rb.ExamLevel).FirstOrDefault().SubName == null ? null : _context.Subjects.Where(g => g.SubId == rb.ExamLevel).FirstOrDefault().SubName,
                                                   Monthid = _context.SessionInfos.Where(g => g.SessionId == rb.MonthId).FirstOrDefault().SessionName == null ? null : _context.SessionInfos.Where(g => g.SessionId == rb.MonthId).FirstOrDefault().SessionName,
                                                   Sessionyear = rb.SessionYear ?? 0,
                                                   BlockDate = rb.BlockDate == null ? null : rb.BlockDate,
                                                   Reason = rb.Reason,
                                                   WithheldStatus = rb.Status

                                               }).OrderBy(d => d.RegNo).ToList();

            bool isRowCountValid = studentInfo != null && studentInfo.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isRowCountValid ? "Result Withheld Report" : "No Data info found",
                Success = isRowCountValid,
                Payload = isRowCountValid ? studentInfo : null
            });
        }
    }
}