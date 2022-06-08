using System;
using System.Collections.Generic;
using System.Linq;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICABAPI.Controllers
{
    public class BarcodeSeqDetails
    {
        public string ExamLevel { get; set; }
        public int? Barfrom { get; set; }
        public int? Barto { get; set; }
        public int? Scriptqty { get; set; }
    }

    public class BarSeqAll
    {
        public int monthid { get; set; }
        public string Session { get; set; }
        public int Year { get; set; }
        public int totalScriptqty { get; set; }
        public List<BarcodeSeqDetails> barcodeSeqDetails { get; set; }
    }
    [Authorize]
    public class BarcodeSequenceController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public BarcodeSequenceController(ModelContext context)
        {
            _context = context;
        }

        public class ModelToUpdateandDeleteBarcodeSeq
        {
            //public int examlevel { get; set; }
            public int monthid { get; set; }
            public int sessionyear { get; set; }
        }

        public class BarseqForReport
        {
            public int? Year { get; set; }
            public string Session { get; set; }
            public string ExamLevel { get; set; }
            public int? Barfrom { get; set; }
            public int? Barto { get; set; }
            public int? Scriptqty { get; set; }
            public int totalScriptqty { get; set; }
        }

        /// <summary>
        /// Get max bar code 
        /// </summary>
        [HttpGet("MaxBarcodeToAssignFrom")]
        public IActionResult MaxBarcodeToAssign()
        {
            // var maxBarcode = _context.Barseqs.Max(x => x.Barto + 1) ?? 1;
            var maxBarcode = (_context.Barseqs.Max(x => x.Barto) ?? 0) + 1;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "MaxBarcode To be Assigned",
                Success = true,
                Payload = new { MaxBarcode = maxBarcode }
            });
        }

        /// <summary>
        /// Create bar code sequence
        /// </summary>
        [HttpPost("CreateBarcodeSequence")]
        public IActionResult CreateBarcodeSequence([FromBody] List<Barseq> barseq)
        {

            List<Barseq> newBarseq = barseq.Where(p => p.SessionYear == null || p.SessionYear == 0 || p.MonthId == null || p.MonthId == 0 || p.ExamLevel == null || p.ExamLevel == 0).ToList();

            if (newBarseq.Count > 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Examlevel, Monthid, Session Year can not be 0",
                    Success = false,
                    Payload = newBarseq
                });
            }

            // _context.Barseqs.AddRange(barseq);
            // var RofAf = _context.SaveChanges() > 0;

            int createdRowCount = 0;
            foreach (var i in barseq)
            {
                _context.Barseqs.Add(i);
                createdRowCount += _context.SaveChanges();
            }

            //createdRowCount +=  _context.SaveChanges();
            //bool isCreated = createdRowCount > 0;

            return StatusCode(barseq.Count == createdRowCount ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = barseq.Count == createdRowCount ? "Sequence Added" : "Error In Insert",
                Success = barseq.Count == createdRowCount ? true : false,
                Payload = barseq.Count == createdRowCount ? null : null
            });
            //return Ok(1);
        }



        // [HttpPost("GetBarcodeSeqByLevelMonthSession")]
        // public IActionResult GetBarcodeSeqByLevelMonthSession([FromBody] ModelToUpdateandDeleteBarcodeSeq barcodeSeq)
        // {
        //     // int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == barcodeSeq.examlevel && rl.SessionYear == barcodeSeq.sessionyear
        //     // && rl.MonthId == barcodeSeq.monthid).Select(g => g.RLock).FirstOrDefault();
        //     // if (resultLockStatus == 1)
        //     // {

        //     //     return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //     //     {
        //     //         Message = "Result is Locked",
        //     //         Success = false,
        //     //         Payload = null
        //     //     });
        //     // }

        //     List<Barseq> newBarseq = _context.Barseqs.Where(p => p.SessionYear == barcodeSeq.sessionyear && p.MonthId == barcodeSeq.monthid
        //     //&& p.ExamLevel == barcodeSeq.examlevel
        //     ).ToList();

        //     if (newBarseq.Count == 0)
        //     {
        //         return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //         {
        //             Message = "No Data Found",
        //             Success = false,
        //             Payload = null
        //         });
        //     }


        //     return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //     {
        //         Message = "BarCode Sequence Found",
        //         Success = true,
        //         Payload = newBarseq
        //     });

        // }

        // [HttpPost("DeleteBarcodeSeq")]
        // public IActionResult DeleteBarcodeSeq([FromBody] ModelToUpdateandDeleteBarcodeSeq barcodeSeq)
        // {
        //     // int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == barcodeSeq.examlevel && rl.SessionYear == barcodeSeq.sessionyear
        //     // && rl.MonthId == barcodeSeq.monthid).Select(g => g.RLock).FirstOrDefault();
        //     // if (resultLockStatus == 1)
        //     // {

        //     //     return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //     //     {
        //     //         Message = "Result is Locked",
        //     //         Success = false,
        //     //         Payload = null
        //     //     });
        //     // }

        //     List<Barseq> newBarseq = _context.Barseqs.Where(p => p.SessionYear == barcodeSeq.sessionyear && p.MonthId == barcodeSeq.monthid
        //     //&& p.ExamLevel == barcodeSeq.examlevel
        //     ).ToList();

        //     if (newBarseq.Count == 0)
        //     {
        //         return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
        //         {
        //             Message = "No Data Found",
        //             Success = false,
        //             Payload = null
        //         });
        //     }

        //     _context.Barseqs.RemoveRange(newBarseq);
        //     var RowAf = _context.SaveChanges() > 0;

        //     return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //     {
        //         Message = "BarCode Sequence Deleted",
        //         Success = true,
        //         Payload = null
        //     });

        // }

        /// <summary>
        /// Bar code sequence report for single session
        /// </summary>
        [HttpPost("BarcodeSeqReportForSingleSession")]
        public IActionResult BarcodeSeqReport([FromBody] ModelToUpdateandDeleteBarcodeSeq barcodeSeq)
        {

            // var newBarseq = _context.Barseqs.Where(p => p.SessionYear == barcodeSeq.sessionyear && p.MonthId == barcodeSeq.monthid
            // //&& p.ExamLevel == barcodeSeq.examlevel
            // ).ToList();

            List<BarSeqAll> bs = new List<BarSeqAll>();

            List<Barseq> newBarseq = _context.Barseqs.Where(p => p.SessionYear == barcodeSeq.sessionyear && p.MonthId == barcodeSeq.monthid).OrderBy(o => o.SessionYear).ThenBy(k => k.MonthId).ToList();


            if (newBarseq.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No Data Found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {

                var lol = newBarseq.Select(x => new { x.MonthId, x.SessionYear }).Distinct();

                foreach (var item in lol)
                {
                    var a = new BarSeqAll();

                    a.monthid = (int)item.MonthId;
                    a.Session = _context.SessionInfos.Where(g => g.SessionId == item.MonthId).FirstOrDefault().SessionName;
                    a.Year = (int)item.SessionYear;

                    bs.Add(a);

                }
                //         i.totalScriptqty = i.totalScriptqty + (int)item.Scriptqty;
                foreach (var i in bs)
                {
                    List<BarcodeSeqDetails> newbsdl = new();
                    foreach (var item in newBarseq)
                    {
                        // BarcodeSeqDetails newbsd = new();
                        if (i.monthid == item.MonthId && i.Year == item.SessionYear)
                        {
                            BarcodeSeqDetails newbsd = new();

                            newbsd.ExamLevel = _context.Subjects.Where(g => g.SubId == item.ExamLevel).FirstOrDefault().SubName;
                            newbsd.Barfrom = item.Barfrom;
                            newbsd.Barto = item.Barto;
                            newbsd.Scriptqty = item.Scriptqty;

                            newbsdl.Add(newbsd);

                            i.totalScriptqty = i.totalScriptqty + (int)item.Scriptqty;

                        }
                    }

                    i.barcodeSeqDetails = newbsdl;

                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "BarCode Sequence Report",
                    Success = true,
                    Payload = bs
                });



            }

        }

        /// <summary>
        /// Bar code sequence report for all session
        /// </summary>
        [HttpPost("BarcodeSeqReportForAll")]
        public IActionResult BarcodeSeqReportForAll()
        {

            List<BarSeqAll> bs = new List<BarSeqAll>();

            List<Barseq> newBarseq = _context.Barseqs.OrderBy(o => o.SessionYear).ThenBy(k => k.MonthId).ToList();


            if (newBarseq.Count == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No Data Found",
                    Success = false,
                    Payload = null
                });
            }
            else
            {

                var lol = newBarseq.Select(x => new { x.MonthId, x.SessionYear }).Distinct();

                foreach (var item in lol)
                {
                    var a = new BarSeqAll();

                    a.monthid = (int)item.MonthId;
                    a.Session = _context.SessionInfos.Where(g => g.SessionId == item.MonthId).FirstOrDefault().SessionName;
                    a.Year = (int)item.SessionYear;

                    bs.Add(a);

                }
                //         i.totalScriptqty = i.totalScriptqty + (int)item.Scriptqty;
                foreach (var i in bs)
                {
                    List<BarcodeSeqDetails> newbsdl = new();
                    foreach (var item in newBarseq)
                    {
                        // BarcodeSeqDetails newbsd = new();
                        if (i.monthid == item.MonthId && i.Year == item.SessionYear)
                        {
                            BarcodeSeqDetails newbsd = new();

                            newbsd.ExamLevel = _context.Subjects.Where(g => g.SubId == item.ExamLevel).FirstOrDefault().SubName;
                            newbsd.Barfrom = item.Barfrom;
                            newbsd.Barto = item.Barto;
                            newbsd.Scriptqty = item.Scriptqty;

                            newbsdl.Add(newbsd);

                            i.totalScriptqty = i.totalScriptqty + (int)item.Scriptqty;

                        }
                    }

                    i.barcodeSeqDetails = newbsdl;

                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "BarCode Sequence Report",
                    Success = true,
                    Payload = bs
                });

            }


        }
    }
}