using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ICABAPI.Data;

using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ICABAPI.DTOs;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    //[Authorize]
    // [ApiController]
    // [Route("api/v1/[controller]")]
    public class BarcodeAllocationController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public BarcodeAllocationController(ModelContext context)
        {
            _context = context;
        }

        public class TempObj
        {
            public int Examlevel { get; set; }
            public int Monthid { get; set; }
            public int Subid { get; set; }
            public int Sessionyear { get; set; }
            public string Changeuser { get; set; }
        }

        public class TempObj2
        {
            public int Examlevel { get; set; }
            public int Monthid { get; set; }
            public int Sessionyear { get; set; }
            public int RowsOffset { get; set; }
            public int RowsPerPage { get; set; }

        }
        public class TempObj4
        {
            public int? RegNo { get; set; }

        }

        public class TempObj3
        {
            public int Examlevel { get; set; }
            public int Monthid { get; set; }
            public int Subid { get; set; }
            public int Sessionyear { get; set; }
        }

        public class BarcodeSingleSubjectDetails
        {
            public int? ExamRollno { get; set; }
            public int? RegNo { get; set; }
            // [DefaultValue("Absent")]
            public string BarcodeOrStatus { get; set; } = "Absent";
        }

        public class BarcodeSingleSubject2
        {
            public string Examlevelname { get; set; }
            public string MonthName { get; set; }
            public string SubjectName { get; set; }
            public List<BarcodeSingleSubjectDetails> BarcodeSingleSubjectDetails { get; set; }

        }

        public class BarcodeSingleSubject
        {
            public int? ExamRollno { get; set; }
            public int? RegNo { get; set; }
            public string BarcodeOrStatus { get; set; }
            public string Examlevelname { get; set; }
            public string MonthName { get; set; }
            public string SubjectName { get; set; }
        }

        public class BarcodeSingleSubjectFirst
        {
            public int? RegNo { get; set; }
            public int? ExamRollno { get; set; }
            public int? SubId { get; set; }
            public int? Barcode { get; set; }

        }


        public class ResultFormatType1
        {
            public int SubId { get; set; }
            public string Status { get; set; }
        }

        public class StudentResultType1
        {
            public int? ExamRollno { get; set; }
            public int? RegNo { get; set; }
            public List<ResultFormatType1> SubjectWithStatus { get; set; }
        }

        public class StatisticsType1
        {
            public int SubId { get; set; }
            public string SubName { get; set; }
            [DefaultValue(0)]
            public int NumberOfBarcode { get; set; }
            [DefaultValue(0)]
            public int NumberOfExempted { get; set; }
            [DefaultValue(0)]
            public int NumberOfEarlierPassed { get; set; }
            [DefaultValue(0)]
            public int NumberOfAbsent { get; set; }
        }

        public class GetBarCodeToAssign
        {
            public int? RegNo { get; set; }
            public int? ExamRollno { get; set; }
            public int? ExamLevel { get; set; }
            public int? MonthId { get; set; }
            public int? SessionYear { get; set; }
            public int? SubId { get; set; }
            public int? BarCode { get; set; }
            public int? UdSlno { get; set; }
        }

        /// <summary>
        /// Create/Allocate Bar code
        /// </summary>
        [HttpPost("insertAllocatedBarcode")]
        public IActionResult InsertBarcodeAllot([FromBody] List<BarcodeAllot> barcodeAllot)
        {

            BarcodeAllot bAll = barcodeAllot.FirstOrDefault();

            if (bAll.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (bAll.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (bAll.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (bAll.SubId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "SubId can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            foreach (var item in barcodeAllot)
            {
                List<BarcodeAllot> bc = barcodeAllot.Where(i => i.BarCode == item.BarCode).ToList();
                List<BarcodeAllot> bc2 = _context.BarcodeAllots.Where(i => i.BarCode == item.BarCode).ToList();
                if (bc.Count > 1 || bc2.Count > 1)
                {
                    string getAllDuplicateBc = "";
                    if (bc2.Count > 1)
                    {
                        foreach (var element in bc2)
                        {
                            getAllDuplicateBc = getAllDuplicateBc + element.ExamRollno + ", ";
                        }
                    }
                    else
                    {
                        foreach (var element in bc)
                        {
                            getAllDuplicateBc = getAllDuplicateBc + element.ExamRollno + ", ";
                        }
                    }
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Roll number: " + getAllDuplicateBc + " have duplicate barcode.",
                        Success = false,
                        Payload = null
                    });
                }
                List<BarcodeAllot> bc3 = barcodeAllot.Where(i => i.RegNo == item.RegNo).ToList();
                //List<BarcodeAllot> bc4 = _context.BarcodeAllots.Where(i => i.RegNo == item.RegNo).ToList();
                if (bc3.Count > 1) // || bc4.Count > 1)
                {
                    string getAllDuplicateBc = "";
                    if (bc3.Count > 1)
                    {
                        foreach (var element in bc3)
                        {
                            getAllDuplicateBc = getAllDuplicateBc + element.ExamRollno + ", ";
                        }
                    }
                    //else
                    //{
                    //    foreach (var element in bc4)
                    //    {
                    //        getAllDuplicateBc = getAllDuplicateBc + element.ExamRollno + ", ";
                    //    }
                    //}
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Reg number: " + item.RegNo + " already exists.",
                        Success = false,
                        Payload = null
                    });
                }
            }

            var elName = _context.Subjects.Where(g => g.SubId == bAll.ExamLevel).FirstOrDefault().SubName;
            var sName = _context.Subjects.Where(g => g.SubId == bAll.SubId).FirstOrDefault().SubName;
            var sessName = _context.SessionInfos.Where(g => g.SessionId == bAll.MonthId).FirstOrDefault().SessionName;


            //bool isFound = false;

            foreach (var i in barcodeAllot)
            {

                bool isIn = _context.BarcodeAllots.Where(x => x.RegNo == i.RegNo && x.ExamLevel == bAll.ExamLevel
                && x.MonthId == bAll.MonthId && x.SessionYear == bAll.SessionYear && x.SubId == bAll.SubId).FirstOrDefault() != null;

                if (isIn == true)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Can not Insert. Please Use Update. Data Already Exist for " + elName + ", " + sessName + ", " + bAll.SessionYear + ", Subject: " + sName,
                        Success = false,
                        Payload = null
                    });
                }

                BarcodeAllot isIn2 = _context.BarcodeAllots.Where(x => x.ExamLevel == bAll.ExamLevel
                && x.MonthId == bAll.MonthId && x.SessionYear == bAll.SessionYear && x.SubId == bAll.SubId && x.BarCode == i.BarCode).FirstOrDefault();

                if (isIn2 != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Can not Insert. This barcode is already assign to registration number: " + isIn2.RegNo + " Data Already Exist for " + elName + ", " + sessName + ", " + bAll.SessionYear + ", Subject: " + sName,
                        Success = false,
                        Payload = null
                    });
                }
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in barcodeAllot)
                {
                    if (item.RegNo != null && item.RegNo != 0 && item.ExamRollno != null && item.ExamRollno != 0 && item.BarCode != null && item.BarCode != 0)
                    {
                        _context.BarcodeAllots.Add(item);
                        _context.SaveChanges();
                    }
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Insert failed. Something went wrong, Please try again later.",
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
                Message = "Barcode Allocation Inserted",
                Success = true,
                Payload = null//new { StudentTypeId = types.StudId }
            });

            //return Ok(new { StatusCode = 200, status = true, responseText = "Inserted" });
        }

        /// <summary>
        /// Update Allocated Bar code
        /// </summary>
        [HttpPost("UpdateBarcodeAllot")]
        public IActionResult UpdateBarcodeAllot([FromBody] List<BarCodeAllot_Archieve> barcodeAllot)//[FromBody] List<BarcodeAllot> barcodeAllot
        {
            var single = barcodeAllot.FirstOrDefault();

            int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == single.ExamLevel && rl.SessionYear == single.SessionYear && rl.MonthId == single.MonthId).Select(g => g.RLock).FirstOrDefault();
            if (resultLockStatus == 1)
            {
                // return Conflict(new { title = "Conflict", statuscode = 409, responseText = "Result is Locked" });

                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is Locked",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                foreach (var item in barcodeAllot)
                {
                    bool isDuplicateReg = barcodeAllot.Where(i => i.RegNo == item.RegNo && i.RegNo != 0).Select(o => o.RegNo).Count() > 1;
                    if (isDuplicateReg == true)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Reg number: " + item.RegNo + " (Roll number: " + item.ExamRollno + ")" + " already exists.",
                            Success = false,
                            Payload = null
                        });
                    }

                    List<BarCodeAllot_Archieve> bc = barcodeAllot.Where(i => i.BarCode == item.BarCode).ToList();
                    if (bc.Count > 1)
                    {
                        string getAllDuplicateBc = "";
                        foreach (var element in bc)
                        {
                            getAllDuplicateBc = getAllDuplicateBc + element.ExamRollno + ", ";
                        }
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Insert failed. Roll number: " + getAllDuplicateBc + "have duplicate barcode.",
                            Success = false,
                            Payload = null
                        });
                    }
                }
                List<int> getUniqueReg = barcodeAllot.Where(i => i.ExamRollno != null && i.ExamRollno != 0).Select(o => o.RegNo ?? 0).ToList();
                //foreach (var item in getUniqueReg)
                //{
                //    bool isDuplicateReg = barcodeAllot.Where(i => i.RegNo == item && i.RegNo != 0).Select(o => o.RegNo).Count() > 1;
                //}

                var updateBarcode = _context.BarcodeAllots.Where(x => x.ExamLevel == single.ExamLevel && x.MonthId == single.MonthId &&
                x.SubId == single.SubId && x.SessionYear == single.SessionYear).ToList();

                var trackId = _context.BarCodeAllot_Archieves.Max(x => (int?)x.TRACKID + 1) ?? 1;

                //StringBuilder sb = new StringBuilder();
                //String strHostName = string.Empty;
                //strHostName = Dns.GetHostName();
                //IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                //IPAddress[] address = ipHostEntry.AddressList;
                //sb.Append(address[4].ToString());
                //sb.AppendLine();
                // return Ok(sb.ToString());

                string strHostName = System.Net.Dns.GetHostName();
                IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;
                var ip = addr[addr.Length - 1].ToString();

                List<BarCodeAllot_Archieve> editList = new List<BarCodeAllot_Archieve>();

                if (updateBarcode == null)
                {
                    //return NotFound();
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Data Found",
                        Success = false,
                        Payload = null
                    });
                }


                using var transaction = _context.Database.BeginTransaction();

                try
                {

                    var lol = updateBarcode.Select(l => new BarCodeAllot_Archieve
                    {
                        RegNo = l.RegNo,
                        ExamRollno = l.ExamRollno,
                        ExamLevel = l.ExamLevel,
                        SessionYear = l.SessionYear,
                        SubId = l.SubId,
                        MonthId = l.MonthId,
                        BarCode = l.BarCode,
                        UdSlno = l.UdSlno,
                        UserId = l.UserId,
                        TRACKID = trackId,
                        PCINFO = ip,//sb.ToString(),
                        CHANGEDATE = DateTime.Today,
                        CHANGETIME = DateTime.Now.ToString("HH:mm:ss"),
                        CHANGEUSER = single.CHANGEUSER,
                        EVENT = "Edit"

                    }).ToList();

                    editList.AddRange(lol);

                    foreach (var item in editList)
                    {
                        _context.BarCodeAllot_Archieves.Add(item);
                        _context.SaveChanges();
                    }

                    foreach (var i in updateBarcode)
                    {
                        _context.BarcodeAllots.Remove(i);
                        _context.SaveChanges();
                    }


                    foreach (var j in barcodeAllot)
                    {
                        BarcodeAllot barcodeAllot1 = new();
                        barcodeAllot1.RegNo = j.RegNo;
                        barcodeAllot1.ExamRollno = j.ExamRollno;
                        barcodeAllot1.ExamLevel = j.ExamLevel;
                        barcodeAllot1.MonthId = j.MonthId;
                        barcodeAllot1.SessionYear = j.SessionYear;
                        barcodeAllot1.SubId = j.SubId;
                        barcodeAllot1.BarCode = j.BarCode;
                        barcodeAllot1.UdSlno = j.UdSlno;
                        barcodeAllot1.UserId = j.UserId;

                        if (j.RegNo != null && j.RegNo != 0 && j.ExamRollno != null && j.ExamRollno != 0 && j.BarCode != null && j.BarCode != 0)
                        {
                            _context.BarcodeAllots.Add(barcodeAllot1);
                            _context.SaveChanges();
                        }

                    }

                    transaction.Commit();

                }
                catch (Exception e)
                {
                    //return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                    //{
                    //    Message = "Update failed. Something went wrong, Please try again later.",
                    //    Success = false,
                    //    Payload = null
                    //});

                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                    {
                        Message = "Update failed. Something went wrong, Please try again later.",
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
                    Message = "Barcode Allocation Updated",
                    Success = true,
                    Payload = null//new { StudentTypeId = types.StudId }
                });

            }
        }

        /// <summary>
        /// Delete Allocated Bar Code
        /// </summary>
        [HttpPost("DeleteBarcodeAllot")]
        public IActionResult DeleteBarcodeAllot([FromBody] TempObj tempObj)
        {

            if (tempObj.Examlevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Monthid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Sessionyear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Subid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "SubId can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == tempObj.Examlevel && rl.SessionYear == tempObj.Sessionyear && rl.MonthId == tempObj.Monthid).Select(g => g.RLock).FirstOrDefault();
            if (resultLockStatus == 1)
            {
                //return Conflict(new { title = "Conflict", statuscode = 409, responseText = "Result is Locked" });
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is Locked",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                var deleteBarcode = _context.BarcodeAllots.Where(x => x.ExamLevel == tempObj.Examlevel && x.MonthId == tempObj.Monthid &&
                x.SubId == tempObj.Subid && x.SessionYear == tempObj.Sessionyear).ToList();

                var trackId = _context.BarCodeAllot_Archieves.Max(x => (int?)x.TRACKID + 1) ?? 1;

                //StringBuilder sb = new StringBuilder();
                //String strHostName = string.Empty;
                //strHostName = Dns.GetHostName();
                //IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                //IPAddress[] address = ipHostEntry.AddressList;
                //sb.Append(address[4].ToString());
                //sb.AppendLine();
                // return Ok(sb.ToString());

                string strHostName = System.Net.Dns.GetHostName();
                IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                IPAddress[] addr = ipEntry.AddressList;
                var ip = addr[addr.Length - 1].ToString();

                List<BarCodeAllot_Archieve> deleteList = new List<BarCodeAllot_Archieve>();

                if (deleteBarcode == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Data Found",
                        Success = false,
                        Payload = null
                    });
                }

                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    var lol = deleteBarcode.Select(l => new BarCodeAllot_Archieve
                    {
                        RegNo = l.RegNo,
                        ExamRollno = l.ExamRollno,
                        ExamLevel = l.ExamLevel,
                        SessionYear = l.SessionYear,
                        SubId = l.SubId,
                        MonthId = l.MonthId,
                        BarCode = l.BarCode,
                        UdSlno = l.UdSlno,
                        UserId = l.UserId,
                        TRACKID = trackId,
                        PCINFO = ip,//sb.ToString(),
                        CHANGEDATE = DateTime.Today,
                        CHANGETIME = DateTime.Now.ToString("HH:mm:ss"),
                        CHANGEUSER = tempObj.Changeuser,
                        EVENT = "Delete"

                    }).ToList();

                    deleteList.AddRange(lol);

                    foreach (var item in deleteList)
                    {
                        _context.BarCodeAllot_Archieves.Add(item);
                        _context.SaveChanges();
                    }


                    foreach (var item in deleteBarcode)
                    {
                        _context.BarcodeAllots.Remove(item);
                        _context.SaveChanges();
                    }

                    transaction.Commit();

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                    {
                        Message = "Delete failed. Something went wrong, Please try again later.",
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Allocation Deleted",
                    Success = true,
                    Payload = null//new { StudentTypeId = types.StudId }
                });
            }

        }

        /// <summary>
        /// Get List of Data to Allocate Bar Code
        /// </summary>
        [HttpPost("GetBarcodeToAllocateData")] //HttpGet("get/{examlevel}/{monthid}/{subject}/{year}")
        public IActionResult GetBarcodeToAllocate(TempObj3 tempObj) //int examlevel, int monthid, int subject, int year
        {
            if (tempObj.Examlevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Monthid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Sessionyear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Subid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "SubId can not be null or 0",
                    Success = false,
                    Payload = null
                });
            }

            var elName = _context.Subjects.Where(g => g.SubId == tempObj.Examlevel).Select(i => i.SubName).FirstOrDefault();
            var sName = _context.Subjects.Where(g => g.SubId == tempObj.Subid).Select(i => i.SubName).FirstOrDefault();
            var sessName = _context.SessionInfos.Where(g => g.SessionId == tempObj.Monthid).Select(i => i.SessionName).FirstOrDefault();

            int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == tempObj.Examlevel && rl.SessionYear == tempObj.Sessionyear && rl.MonthId == tempObj.Monthid).Select(g => g.RLock).FirstOrDefault();
            if (resultLockStatus == 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is Locked",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                List<VwBarAlloted> fromViewBarcodeAllot = _context.VwBarAlloteds.Where(x => x.ExamLevel == tempObj.Examlevel &&
                                                                                               x.MonthId == tempObj.Monthid &&
                                                                                               x.SessionYear == tempObj.Sessionyear &&
                                                                                               x.SubId == tempObj.Subid).OrderBy(y => y.ExamRollno).ToList();
                if (fromViewBarcodeAllot == null || fromViewBarcodeAllot.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Data Found",
                        Success = false,
                        Payload = null
                    });
                }

                List<GetBarCodeToAssign> barcodeToAllocate = new();

                foreach (var item in fromViewBarcodeAllot)
                {
                    GetBarCodeToAssign getBarCodeToAssign = new();
                    getBarCodeToAssign.RegNo = item.BarCode == null ? null : item.RegNo;
                    getBarCodeToAssign.ExamRollno = item.BarCode == null ? null : item.ExamRollno;
                    getBarCodeToAssign.ExamLevel = item.ExamLevel;
                    getBarCodeToAssign.MonthId = item.MonthId;
                    getBarCodeToAssign.SessionYear = item.SessionYear;
                    getBarCodeToAssign.SubId = item.SubId;
                    getBarCodeToAssign.BarCode = item.BarCode;
                    getBarCodeToAssign.UdSlno = item.UdSlno;
                    barcodeToAllocate.Add(getBarCodeToAssign);
                }

                // only sort by roll number for those who has barcode
                var barcodeToAllocate1 = barcodeToAllocate.Where(i => i.ExamRollno > 0 && i.ExamRollno != null).OrderBy(j => j.ExamRollno).ToList();
                var barcodeToAllocate2 = barcodeToAllocate.Where(i => i.ExamRollno == 0 || i.ExamRollno == null).ToList();
                var mergedList = barcodeToAllocate1.Union(barcodeToAllocate2).ToList();

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Allocation Data for: " + elName + ", " + sessName + ", " + tempObj.Sessionyear + ", Subject: " + sName,
                    Success = true,
                    Payload = mergedList
                });
            }
        }


        /// <summary>
        /// Bar Code report student wise
        /// </summary>
        [HttpPost("BarcodeReportStudentWise")] //async Task<ActionResult<ResponseDto2>>
        public IActionResult BarcodeReportStudentWise([FromBody] TabulationsControllerModel7 input)
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

            //Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();
            //Decodelog decodelog = _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefault();
            //if (decodelog == null)
            //{
            //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
            //    {
            //        Message = "Decoding of result of this session has not yet been done. Please decode first for decoding option",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            //string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            string GetExamLevelName = _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefault();
            if (GetExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            //string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            string GetMonthName = _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefault();
            if (GetMonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            //List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToListAsync();
            List<Subject> subjects = _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(l => l.SubOrder).ToList();
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
            // Put await after Test
            var query = (from er in _context.Set<ExamReg>().Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear)
                                                                .Select(a => new { a.RegNo, a.ExamRollno, a.ExamLevel, a.MonthId, a.SessionYear })
                         from ba in _context.Set<BarcodeAllot>().Where(ba => er.ExamRollno == ba.ExamRollno && er.RegNo == ba.RegNo
                                                                          && er.MonthId == ba.MonthId && er.SessionYear == ba.SessionYear && er.ExamLevel == ba.ExamLevel
                                                                          && ba.ExamLevel == input.ExamLevel && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)
                                                                .DefaultIfEmpty()
                         from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode
                                                                        && ma.MonthId == input.MonthId && ma.SessionYear == input.SessionYear)
                                                              .DefaultIfEmpty()

                         select new
                         {
                             er.ExamRollno,
                             er.RegNo,
                             ba.SubId,
                             ba.BarCode,
                             ma.Marks,
                             ma.Grade
                         }).OrderBy(j => j.ExamRollno).ThenBy(i => i.SubId).ToList();

            if (query == null || query.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No tabulation sheet details found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            // initialize subject info

            List<int> regNoCollection = query.Select(k => k.RegNo).Distinct().ToList();

            List<TabulationsControllerModel1> output = new();
            foreach (var item in regNoCollection)
            {
                TabulationsControllerModel1 tempop1 = new();
                tempop1.RegNo = item;
                tempop1.ExamRollNo = query.Where(i => i.RegNo == item).Select(j => j.ExamRollno).FirstOrDefault();

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
                        item.ExamRollNo = item.ExamRollNo == null ? tempop4.ExamRollno : item.ExamRollNo;
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

                var exdata = (from er in _context.ExamRegs
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
                              }).ToList();

                List<FormFillupModel6> exdata2 = (from ba in _context.BarcodeAllots
                                                  from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                  where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B"))
                                                  select new FormFillupModel6
                                                  {
                                                      RegNo = ba.RegNo
                                                  }).ToList();

                List<FormFillupModel6> exdata3 = (from ba in _context.BarcodeAllots
                                                  from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                  where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                  select new FormFillupModel6
                                                  {
                                                      RegNo = ba.RegNo
                                                  }).ToList();

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
                                bool isInSetExmpMous = _context.SetExmpMous.Any(i => i.RegNo == item.RegNo);

                                if (isInSetExmpMous == true)
                                {
                                    element.Grade = "ex";
                                    continue;
                                }

                                bool isInConversionCourseMarks = _context.ConversionCourseMarks.Any(i => i.RegNo == item.RegNo && i.ExamLevel == 41 && i.SubId == 412);

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


                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 41 || m.ExamLevel == 61) && (m.Grade == "A" || m.Grade == "B")
                           && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                             ((m.SessionYear < input.SessionYear) ||
                               (
                                 input.MonthId == 3 ? false :
                                 input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                 input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) ||
                                                        (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                               )
                             )


                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 411 ? 611 :
                                         m.SubId == 412 ? 612 :
                                         m.SubId == 413 ? 613 :
                                         m.SubId == 414 ? 614 :
                                         m.SubId == 415 ? 615 :
                                         m.SubId == 416 ? 616 :
                                         m.SubId == 417 ? 617 :
                                         m.SubId == 418 ? 618 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
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

            else if (input.ExamLevel == 62)
            {
                // ex

                var exdata = (from er in _context.ExamRegs
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
                              }).ToList();

                List<int?> validRegNoCollection = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToList();
                var exresult = (from ba in _context.BarcodeAllots
                                join ma in _context.MarksAllots on
                                new { ba.MonthId, ba.SessionYear, ba.SubId, ba.BarCode } equals
                                new { ma.MonthId, ma.SessionYear, ma.SubId, ma.BarCode }
                                where ((ma.Grade == "A" || ma.Grade == "B") && validRegNoCollection.Contains(ba.RegNo) && ba.ExamLevel == 2 && ba.SubId == 21)
                                select new
                                {
                                    RegNo = ba.RegNo,
                                    ExamLevel = ba.ExamLevel,
                                    SubId = ma.SubId
                                }).ToList();

                List<FormFillupModel6> exdata3 = (from ba in _context.BarcodeAllots
                                                  from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                  where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                                                  select new FormFillupModel6
                                                  {
                                                      RegNo = ba.RegNo
                                                  }).ToList();

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

                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 42 || m.ExamLevel == 62) && (m.Grade == "A" || m.Grade == "B")
                           && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                            ((m.SessionYear < input.SessionYear)||
                               (
                                 input.MonthId == 3 ? false :
                                 input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                 input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) || 
                                                        (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                               )
                             )

                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 421 ? 621 :
                                         m.SubId == 422 ? 622 :
                                         m.SubId == 423 ? 623 :
                                         m.SubId == 424 ? 624 :
                                         m.SubId == 425 ? 625 :
                                         m.SubId == 426 ? 626 :
                                         m.SubId == 427 ? 627 :
                                         m.SubId == 428 ? 628 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
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
                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 51 || m.ExamLevel == 63) && (m.Grade == "A" || m.Grade == "B")
                           && m.SubId != 512 && //(m.SessionYear < input.SessionYear || (m.SessionYear == input.SessionYear && m.MonthId != input.MonthId))

                             ((m.SessionYear < input.SessionYear) ||
                               (
                                 input.MonthId == 3 ? false :
                                 input.MonthId == 1 ? (m.SessionYear == input.SessionYear && m.MonthId == 3) :
                                 input.MonthId == 2 ? ((m.SessionYear == input.SessionYear && m.MonthId == 3) ||
                                                        (m.SessionYear == input.SessionYear && m.MonthId == 1)) : false
                               )
                             )

                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 511 ? 631 :
                                         m.SubId == 513 ? 632 :
                                         m.SubId == 514 ? 633 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
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
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
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

            List<StudentResultType1> results1 = new();
            List<StatisticsType1> stats1 = new();

            // stats initialization
            foreach (var item in subjectDetails)
            {
                StatisticsType1 statisticsType1 = new();
                statisticsType1.SubId = item.SubId;
                statisticsType1.SubName = item.SubName;
                statisticsType1.NumberOfBarcode = 0;
                statisticsType1.NumberOfExempted = 0;
                statisticsType1.NumberOfEarlierPassed = 0;
                statisticsType1.NumberOfAbsent = 0;
                stats1.Add(statisticsType1);
            }

            foreach (var item in output)
            {
                StudentResultType1 studentResultType1 = new();
                studentResultType1.ExamRollno = item.ExamRollNo;
                studentResultType1.RegNo = item.RegNo;

                List<ResultFormatType1> resultFormats = new();

                foreach (var element in item.ResultDetails)
                {

                    ResultFormatType1 resultFormatType1 = new();
                    resultFormatType1.SubId = element.SubId ?? 0;

                    // status assignment

                    if (element.Grade == "F")
                    {
                        resultFormatType1.Status = "Absent";
                    }
                    else if (element.Grade == "ep")
                    {
                        resultFormatType1.Status = "Earlier Passed";
                    }
                    else if (element.Grade == "ex")
                    {
                        resultFormatType1.Status = "Exempted";
                    }
                    else
                    {
                        resultFormatType1.Status = element.BarCode.ToString();
                    }

                    resultFormats.Add(resultFormatType1);

                    foreach (var subject in stats1)
                    {
                        if (subject.SubId == element.SubId)
                        {
                            if (element.Grade == "F")
                            {
                                subject.NumberOfAbsent = subject.NumberOfAbsent + 1;
                            }
                            else if (element.Grade == "ep")
                            {
                                subject.NumberOfEarlierPassed = subject.NumberOfEarlierPassed + 1;
                            }
                            else if (element.Grade == "ex")
                            {
                                subject.NumberOfExempted = subject.NumberOfExempted + 1;
                            }
                            else if (element.BarCode != null)
                            {
                                subject.NumberOfBarcode = subject.NumberOfBarcode + 1;
                            }
                        }
                    }
                }
                studentResultType1.SubjectWithStatus = resultFormats;
                results1.Add(studentResultType1);
            }


            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Tabulation sheet details for " + results1.Count + " students",
                Success = true,
                Payload = new
                {
                    ExamLevelName = GetExamLevelName,
                    MonthName = GetMonthName,
                    Subjects = stats1,
                    TabulationSheetData = results1
                }
            });
        }

        /// <summary>
        /// Bar Code report subject wise
        /// </summary>
        [HttpPost("BarcodeReportSubjectWise")]
        public IActionResult BarcodeAllocReportBySingleSubject(TempObj3 tempObj)
        {
            if (tempObj.Examlevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Monthid < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (tempObj.Sessionyear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year can not be null",
                    Success = false,
                    Payload = null
                });
            }

            var elName = _context.Subjects.Where(g => g.SubId == tempObj.Examlevel).Select(i => i.SubName).FirstOrDefault();
            var sName = _context.Subjects.Where(g => g.SubId == tempObj.Subid).Select(i => i.SubName).FirstOrDefault();
            var sessName = _context.SessionInfos.Where(g => g.SessionId == tempObj.Monthid).Select(i => i.SessionName).FirstOrDefault();

            //get all from set exmp mou
            List<SetExmpMou> setExmpMous = _context.SetExmpMous.ToList();

            List<BarcodeSingleSubjectFirst> subjectWiseBarcodeView = _context.VwBarAlloteds.Where(x => x.ExamLevel == tempObj.Examlevel
                                                        && x.MonthId == tempObj.Monthid && x.SessionYear == tempObj.Sessionyear && x.SubId == tempObj.Subid)
                                                        .Select(i => new BarcodeSingleSubjectFirst
                                                        {
                                                            RegNo = i.RegNo,
                                                            ExamRollno = i.ExamRollno,
                                                            SubId = i.SubId,
                                                            Barcode = i.BarCode
                                                        }).OrderBy(j => j.ExamRollno).ToList();

            if (tempObj.Examlevel == 61)
            {
                List<BarcodeSingleSubjectDetails> barcodeSingleSubject61 = new List<BarcodeSingleSubjectDetails>();

                BarcodeSingleSubject2 bS61 = new BarcodeSingleSubject2();

                bS61.Examlevelname = elName;
                bS61.MonthName = sessName;
                bS61.SubjectName = sName;

                //var exdata = (from er in _context.ExamRegs
                //              from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                //              where ((er.ExamLevel == 61 || er.ExamLevel == 41))
                //              orderby er.RegNo, es.SubId

                //              select new
                //              {
                //                  RegNo = er.RegNo,
                //                  //ExamRollno = x.ExamRollno,
                //                  //SubId = b.SubId,
                //                  //BarCode = b.BarCode,
                //                  ExempSub = es.SubId
                //              }).ToList();

                //get all form exemptedSubs
                List<ExemptedSub> exemptedSubs = _context.ExemptedSubs.Where(i => i.ExamLevel == 41 || i.ExamLevel == 61).ToList();

                List<VwMarksfinal> vwMarksfinalsExamLevel1 = _context.VwMarksfinals.Where(i => i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B")).ToList();

                List<VwMarksfinal> vwMarksfinalExamLevel3 = _context.VwMarksfinals.Where(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B")).ToList();

                //get all form student of icmab acca
                List<StudentOfIcmabAcca> studentOfIcmabAccas = _context.StudentOfIcmabAccas.Where(i => i.ExamLevel == 61).ToList();

                List<ConversionCourseMark> conversionCourseMarks = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 41 && i.SubId == 412).ToList();

                //get grade: ex for level 2 from vw marks final
                List<VwMarksfinal> vwMarksfinalsExamLevel2 = _context.VwMarksfinals.Where(i => i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).ToList();

                //get all from vwMarksFinals
                //List<VwMarksfinal> vwMarksfinals = _context.VwMarksfinals.Where(i => (i.ExamLevel == 41 || i.ExamLevel == 61) && (i.Grade == "A" || i.Grade == "B")).ToList();

                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 41 || m.ExamLevel == 61) && (m.Grade == "A" || m.Grade == "B") 
                           && //(m.SessionYear < tempObj.Sessionyear || (m.SessionYear == tempObj.Sessionyear && m.MonthId < tempObj.Monthid))


                            ((m.SessionYear < tempObj.Sessionyear) ||
                               (
                                 tempObj.Monthid == 3 ? false :
                                 tempObj.Monthid == 1 ? (m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) :
                                 tempObj.Monthid == 2 ? ((m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) ||
                                                        (m.SessionYear == tempObj.Sessionyear && m.MonthId == 1)) : false
                               )
                             )

                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 411 ? 611 :
                                         m.SubId == 412 ? 612 :
                                         m.SubId == 413 ? 613 :
                                         m.SubId == 414 ? 614 :
                                         m.SubId == 415 ? 615 :
                                         m.SubId == 416 ? 616 :
                                         m.SubId == 417 ? 617 :
                                         m.SubId == 418 ? 618 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                           }).ToList();


                //List<FormFillupModel6> exdata3 = (from ba in _context.BarcodeAllots
                //                                  from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                //                                  where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                //                                  select new FormFillupModel6
                //                                  {
                //                                      RegNo = ba.RegNo
                //                                  }).ToList();



                //var getFromExamReg = (from x in _context.ExamRegs.Select(a => new { a.RegNo, a.ExamRollno, a.ExamLevel, a.MonthId, a.SessionYear, a.Ref })
                //                      from b in _context.BarcodeAllots.Where(e => x.ExamRollno == e.ExamRollno && x.RegNo == e.RegNo && x.MonthId == e.MonthId && x.SessionYear == e.SessionYear && x.ExamLevel == e.ExamLevel).DefaultIfEmpty()
                //                      from ex in _context.ExemptedSubs.Where(c => x.RegNo == c.RegNo && x.ExamLevel == c.ExamLevel).DefaultIfEmpty()
                //                      where (x.ExamLevel == tempObj.Examlevel && x.MonthId == tempObj.Monthid && x.SessionYear == tempObj.Sessionyear)//&& (b.SubId == 621 || ex.SubId == 621))
                //                      orderby x.ExamRollno, b.SubId

                //                      select new
                //                      {
                //                          RegNo = x.RegNo,
                //                          ExamRollno = x.ExamRollno,
                //                          SubId = b.SubId,
                //                          BarCode = b.BarCode,
                //                          ExempSub = ex.SubId
                //                      }
                //    ).ToList();

                //var lol = getFromExamReg.Select(x => new { x.RegNo, x.ExamRollno }).Distinct().ToList();


                foreach (var i in subjectWiseBarcodeView)
                {
                    var b = new BarcodeSingleSubjectDetails();
                    b.RegNo = i.RegNo;
                    b.ExamRollno = i.ExamRollno;
                    b.BarcodeOrStatus = i.Barcode == null ? "Absent" : i.Barcode.ToString();

                    barcodeSingleSubject61.Add(b);
                }

                // +++++++++++ EX ++++++++++++
                if (tempObj.Subid != 612)
                {
                    if (tempObj.Subid == 611)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 611 || o.SubId == 411) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }

                    else if (tempObj.Subid == 613)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 613 || o.SubId == 413) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo && i.SubId == 34 && (i.Grade == "A" || i.Grade == "B"));

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }

                    else if (tempObj.Subid == 614)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 614 || o.SubId == 414) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }

                    else if (tempObj.Subid == 615)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 615 || o.SubId == 415) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }

                    else if (tempObj.Subid == 616)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 616 || o.SubId == 416) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }

                    else if (tempObj.Subid == 617)
                    {
                        foreach (var item in barcodeSingleSubject61)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 617 || o.SubId == 417) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                //continue;
                            }

                            bool isInExData3 = vwMarksfinalsExamLevel1.Any(ip => ip.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                //continue;
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }
                }

                if (tempObj.Subid == 612)
                {
                    foreach (var item in barcodeSingleSubject61)
                    {
                        bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 612 || o.SubId == 412) && o.RegNo == item.RegNo);

                        if (TrueOrFalse == true)
                        {
                            //item.BarcodeOrStatus = "ex";
                            bool isInSetExmpMous = setExmpMous.Any(i => i.RegNo == item.RegNo);

                            if (isInSetExmpMous == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                continue;
                            }

                            bool isInConversionCourseMarks = conversionCourseMarks.Any(i => i.RegNo == item.RegNo);

                            if (isInConversionCourseMarks == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                continue;
                            }
                        }

                        bool TrueOrFalse4 = vwMarksfinalsExamLevel2.Any(o => o.RegNo == item.RegNo);

                        if (TrueOrFalse4 == true)
                        {
                            item.BarcodeOrStatus = "ex";
                            //continue;
                        }

                        bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                        if (TrueOrFalse2 == true)
                        {
                            item.BarcodeOrStatus = "ex";
                        }

                        bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                        if (TrueOrFalse3 == true)
                        {
                            item.BarcodeOrStatus = "ex";
                        }
                    }
                }
                // +++++++++++ EX ++++++++++++


                // +++++++++++ EP ++++++++++++

                foreach (var item in barcodeSingleSubject61)
                {
                    bool TureOrFalse = abc.Any(o => o.RegNo == item.RegNo && o.EPSubId == tempObj.Subid);

                    if (TureOrFalse == true)
                    {
                        item.BarcodeOrStatus = "ep";
                    }
                }

                // +++++++++++ EP ++++++++++++


                //if (tempObj.Subid != 612)
                //{
                //    foreach (var i in barcodeSingleSubject61)
                //    {
                //        foreach (var j in getFromExamReg)
                //        {
                //            if (i.RegNo == j.RegNo)
                //            {
                //                if (j.SubId == tempObj.Subid) i.BarcodeOrStatus = j.BarCode.ToString();
                //                if (j.ExempSub == tempObj.Subid) i.BarcodeOrStatus = "ex";
                //            }
                //            else
                //            {
                //                continue;
                //            }
                //        }
                //    }
                //}

                //if (tempObj.Subid == 612)
                //{
                //    foreach (var i in barcodeSingleSubject61)
                //    {
                //        foreach (var j in getFromExamReg)
                //        {
                //            if (i.RegNo == j.RegNo)
                //            {
                //                if (j.SubId == tempObj.Subid) i.BarcodeOrStatus = j.BarCode.ToString();
                //                if (j.ExempSub == 612) i.BarcodeOrStatus = "Absent";
                //                //if (j.ExempSub != ) i.BarcodeOrStatus = "ex";
                //            }
                //            else
                //            {
                //                continue;
                //            }
                //        }
                //    }

                //    var regNoCollection = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 41 && i.SubId == 412).Select(j => j.RegNo).ToList();

                //    var regNoFromSetExempMOU = _context.SetExmpMous.Select(a => a.RegNo).ToList();

                //    List<int> lol2 = getFromExamReg.Where(
                //        g => g.ExempSub == 612 && (regNoCollection.Contains(g.RegNo) || regNoFromSetExempMOU.Contains(g.RegNo))
                //    ).Select(x => x.RegNo).Distinct().ToList();

                //    List<FormFillupModel6> exdata2 = (from ba in _context.BarcodeAllots
                //                                      from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                //                                      where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B"))
                //                                      select new FormFillupModel6
                //                                      {
                //                                          RegNo = ba.RegNo
                //                                      }).ToList();


                //    foreach (var i in barcodeSingleSubject61)
                //    {
                //        if (lol2.Contains((int)i.RegNo))
                //        {
                //            i.BarcodeOrStatus = "ex";
                //        }

                //        var isInExData2 = exdata2.Any(ip => ip.RegNo == i.RegNo);

                //        if (isInExData2 == true)
                //        {
                //            i.BarcodeOrStatus = "ex";
                //            continue;
                //        }
                //    }
                //}

                //if (tempObj.Subid == 617)
                //{
                //    List<FormFillupModel6> exdata3 = (from ba in _context.BarcodeAllots
                //                                      from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                //                                      where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                //                                      select new FormFillupModel6
                //                                      {
                //                                          RegNo = ba.RegNo
                //                                      }).ToList();

                //    foreach (var i in barcodeSingleSubject61)
                //    {
                //        bool isInExData3 = exdata3.Any(ip => ip.RegNo == i.RegNo);

                //        if (isInExData3 == true)
                //        {
                //            i.BarcodeOrStatus = "ex";
                //            continue;
                //        }
                //    }

                //}

                //var abc = (from b in _context.BarcodeAllots//.Where(x  =>x.ExamLevel==42)
                //           join m in _context.MarksAllots//.Where( x=>x.Grade=="A")
                //           on b.SessionYear equals m.SessionYear
                //           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < tempObj.Sessionyear || b.SessionYear == tempObj.Sessionyear && b.MonthId < tempObj.Monthid) && (b.ExamLevel == 41 || b.ExamLevel == tempObj.Examlevel) && (m.Grade == "A" || m.Grade == "B")
                //           orderby b.RegNo, b.SubId
                //           select new
                //           {
                //               RegNo = b.RegNo,
                //               ExamRollno = b.ExamRollno,
                //               Examlevel = b.ExamLevel,
                //               BarCode = b.BarCode,
                //               Grade = m.Grade,
                //               SessionYear = b.SessionYear,
                //               EPSubId = b.SubId == 411 ? 611 :
                //                                      b.SubId == 412 ? 612 :
                //                                      b.SubId == 413 ? 613 :
                //                                      b.SubId == 414 ? 614 :
                //                                      b.SubId == 415 ? 615 :
                //                                      b.SubId == 416 ? 616 :
                //                                      b.SubId == 417 ? 617 :
                //                                      b.SubId == 418 ? 618 : b.SubId
                //               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                //           }).ToList();


                //foreach (var i in barcodeSingleSubject61)
                //{
                //    foreach (var j in abc)
                //    {
                //        if (i.RegNo == j.RegNo)
                //        {
                //            if (j.EPSubId == tempObj.Subid) i.BarcodeOrStatus = "ep";
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}

                bS61.BarcodeSingleSubjectDetails = barcodeSingleSubject61;

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Allocation Data for: " + elName + ", " + sessName + ", " + tempObj.Sessionyear + ", Subject: " + sName,
                    Success = true,
                    Payload = bS61
                });

            }
            else if (tempObj.Examlevel == 62)
            {
                List<BarcodeSingleSubjectDetails> barcodeSingleSubject62 = new List<BarcodeSingleSubjectDetails>();

                BarcodeSingleSubject2 bS62 = new BarcodeSingleSubject2();

                bS62.Examlevelname = elName;
                bS62.MonthName = sessName;
                bS62.SubjectName = sName;

                //get all form exemptedSubs
                List<ExemptedSub> exemptedSubs = _context.ExemptedSubs.Where(i => i.ExamLevel == 42 || i.ExamLevel == 62).ToList();

                List<VwMarksfinal> vwMarksfinalsExamLevel1 = _context.VwMarksfinals.Where(i => i.ExamLevel == 1 && i.SubId == 16 && (i.Grade == "A" || i.Grade == "B")).ToList();

                List<VwMarksfinal> vwMarksfinalExamLevel3 = _context.VwMarksfinals.Where(i => i.ExamLevel == 3 && (i.Grade == "A" || i.Grade == "B")).ToList();

                //get all form student of icmab acca
                List<StudentOfIcmabAcca> studentOfIcmabAccas = _context.StudentOfIcmabAccas.Where(i => i.ExamLevel == 62).ToList();

                List<ConversionCourseMark> conversionCourseMarks = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).ToList();

                //get grade: ex for level 2 from vw marks final
                List<VwMarksfinal> vwMarksfinalsExamLevel2 = _context.VwMarksfinals.Where(i => i.ExamLevel == 2 && i.SubId == 21 && (i.Grade == "A" || i.Grade == "B")).ToList();

                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 42 || m.ExamLevel == 62) && (m.Grade == "A" || m.Grade == "B")
                           && //(m.SessionYear < tempObj.Sessionyear || (m.SessionYear == tempObj.Sessionyear && m.MonthId < tempObj.Monthid))

                             ((m.SessionYear < tempObj.Sessionyear) ||
                               (
                                 tempObj.Monthid == 3 ? false :
                                 tempObj.Monthid == 1 ? (m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) :
                                 tempObj.Monthid == 2 ? ((m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) ||
                                                        (m.SessionYear == tempObj.Sessionyear && m.MonthId == 1)) : false
                               )
                             )

                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 421 ? 621 :
                                         m.SubId == 422 ? 622 :
                                         m.SubId == 423 ? 623 :
                                         m.SubId == 424 ? 624 :
                                         m.SubId == 425 ? 625 :
                                         m.SubId == 426 ? 626 :
                                         m.SubId == 427 ? 627 :
                                         m.SubId == 428 ? 628 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                           }).ToList();

                //var getFromExamReg = (from x in _context.ExamRegs.Select(a => new { a.RegNo, a.ExamRollno, a.ExamLevel, a.MonthId, a.SessionYear, a.Ref })
                //                      from b in _context.BarcodeAllots.Where(e => x.ExamRollno == e.ExamRollno && x.RegNo == e.RegNo && x.MonthId == e.MonthId && x.SessionYear == e.SessionYear && x.ExamLevel == e.ExamLevel).DefaultIfEmpty()
                //                      from ex in _context.ExemptedSubs.Where(c => x.RegNo == c.RegNo && x.ExamLevel == c.ExamLevel).DefaultIfEmpty()
                //                      where (x.ExamLevel == tempObj.Examlevel && x.MonthId == tempObj.Monthid && x.SessionYear == tempObj.Sessionyear)//&& (b.SubId == 621 || ex.SubId == 621))
                //                      orderby x.ExamRollno, b.SubId

                //                      select new
                //                      {
                //                          RegNo = x.RegNo,
                //                          ExamRollno = x.ExamRollno,
                //                          SubId = b.SubId,
                //                          BarCode = b.BarCode,
                //                          ExempSub = ex.SubId
                //                      }
                //                    ).ToList();

                //var lol = getFromExamReg.Select(x => new { x.RegNo, x.ExamRollno }).Distinct().ToList();

                foreach (var i in subjectWiseBarcodeView)
                {
                    var b = new BarcodeSingleSubjectDetails();
                    b.RegNo = i.RegNo;
                    b.ExamRollno = i.ExamRollno;
                    b.BarcodeOrStatus = i.Barcode == null ? "Absent" : i.Barcode.ToString();

                    barcodeSingleSubject62.Add(b);
                }

                // +++++++++++ EX ++++++++++++
                
                if (tempObj.Subid != 622)
                {
                    if (tempObj.Subid == 621)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 621 || o.SubId == 421) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            //bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo);

                            //if (TrueOrFalse3 == true)
                            //{
                            //    item.BarcodeOrStatus = "ex";
                            //}
                        }
                    }

                    else if (tempObj.Subid == 623)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 623 || o.SubId == 423) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo && i.SubId == 35 && (i.Grade == "A" || i.Grade == "B"));

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            //bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo);

                            //if (TrueOrFalse3 == true)
                            //{
                            //    item.BarcodeOrStatus = "ex";
                            //}
                        }
                    }

                    else if (tempObj.Subid == 624)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 624 || o.SubId == 424) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo && i.SubId == 34 && (i.Grade == "A" || i.Grade == "B"));

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            //bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo);

                            //if (TrueOrFalse3 == true)
                            //{
                            //    item.BarcodeOrStatus = "ex";
                            //}
                        }
                    }

                    else if (tempObj.Subid == 625)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 625 || o.SubId == 425) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo && i.SubId == 33 && (i.Grade == "A" || i.Grade == "B"));

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            //bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo);

                            //if (TrueOrFalse3 == true)
                            //{
                            //    item.BarcodeOrStatus = "ex";
                            //}
                        }
                    }

                    else if (tempObj.Subid == 626)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 626 || o.SubId == 426) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            //bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo);

                            //if (TrueOrFalse3 == true)
                            //{
                            //    item.BarcodeOrStatus = "ex";
                            //}
                        }
                    }

                    else if (tempObj.Subid == 627)
                    {
                        foreach (var item in barcodeSingleSubject62)
                        {
                            bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 627 || o.SubId == 427) && o.RegNo == item.RegNo);

                            if (TrueOrFalse == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                //continue;
                            }

                            bool isInExData3 = vwMarksfinalsExamLevel1.Any(ip => ip.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                                //continue;
                            }

                            bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                            if (TrueOrFalse2 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }

                            bool TrueOrFalse3 = studentOfIcmabAccas.Any(i => i.RegNo == item.RegNo && i.SubId == tempObj.Subid);

                            if (TrueOrFalse3 == true)
                            {
                                item.BarcodeOrStatus = "ex";
                            }
                        }
                    }
                }

                if (tempObj.Subid == 622)
                {
                    foreach (var item in barcodeSingleSubject62)
                    {
                        bool TrueOrFalse = exemptedSubs.Any(o => (o.SubId == 622 || o.SubId == 422) && o.RegNo == item.RegNo);

                        if (TrueOrFalse == true)
                        {
                           item.BarcodeOrStatus = "ex";
                        }

                        bool TrueOrFalse2 = vwMarksfinalExamLevel3.Any(i => i.RegNo == item.RegNo);

                        if (TrueOrFalse2 == true)
                        {
                            item.BarcodeOrStatus = "ex";
                        }

                        var regNoCollection = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToList();
                        var result = (from ba in _context.BarcodeAllots
                                     join ma in _context.MarksAllots on
                                     new { ba.MonthId, ba.SessionYear, ba.SubId, ba.BarCode } equals
                                     new { ma.MonthId, ma.SessionYear, ma.SubId, ma.BarCode }
                                     where ((ma.Grade == "A" || ma.Grade == "B") && regNoCollection.Contains(ba.RegNo) && ba.ExamLevel == 2 && ba.SubId == 21)
                                     select new
                                     {
                                         RegNo = ba.RegNo,
                                         ExamLevel = ba.ExamLevel,
                                         SubId = ma.SubId
                                     }).ToList();

                        bool TrueOrFalse3 = result.Any(o => o.RegNo == item.RegNo);

                        if (TrueOrFalse3 == true)
                        {
                            item.BarcodeOrStatus = "ex";
                        }
                    }
                }

                // +++++++++++ EX ++++++++++++

                // +++++++++++ EP ++++++++++++

                foreach (var item in barcodeSingleSubject62)
                {
                    bool TureOrFalse = abc.Any(o => o.RegNo == item.RegNo && o.EPSubId == tempObj.Subid);

                    if (TureOrFalse == true)
                    {
                        item.BarcodeOrStatus = "ep";
                    }
                }

                // +++++++++++ EP ++++++++++++

                //foreach (var i in barcodeSingleSubject62)
                //{
                //    foreach (var j in getFromExamReg)
                //    {
                //        if (i.RegNo == j.RegNo)
                //        {
                //            if (j.SubId == tempObj.Subid) i.BarcodeOrStatus = j.BarCode.ToString();
                //            else if (j.ExempSub == tempObj.Subid) i.BarcodeOrStatus = "ex";
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}

                //if (tempObj.Subid == 622)
                //{
                //    // note: 2nd table er sobkisu subset theke asbe, ma. use kora jabena, cause left outer join
                //    var regNoCollection = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToList();
                //    var result = from ba in _context.BarcodeAllots
                //                 join ma in _context.MarksAllots on
                //                 new { ba.MonthId, ba.SessionYear, ba.SubId, ba.BarCode } equals
                //                 new { ma.MonthId, ma.SessionYear, ma.SubId, ma.BarCode }
                //                 where ((ma.Grade == "A" || ma.Grade == "B") && regNoCollection.Contains(ba.RegNo) && ba.ExamLevel == 2 && ba.SubId == 21)
                //                 select new
                //                 {
                //                     RegNo = ba.RegNo,
                //                     ExamLevel = ba.ExamLevel,
                //                     SubId = ma.SubId
                //                 };

                //    foreach (var i in result)
                //    {
                //        foreach (var j in barcodeSingleSubject62)
                //        {
                //            if (i.RegNo == j.RegNo) j.BarcodeOrStatus = "ex";
                //        }
                //    }
                //}

                //if (tempObj.Subid == 627)
                //{
                //    List<FormFillupModel6> exdata3 = (from ba in _context.BarcodeAllots
                //                                      from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                //                                      where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                //                                      select new FormFillupModel6
                //                                      {
                //                                          RegNo = ba.RegNo
                //                                      }).ToList();

                //    foreach (var i in barcodeSingleSubject62)
                //    {
                //        bool isInExData3 = exdata3.Any(ip => ip.RegNo == i.RegNo);

                //        if (isInExData3 == true)
                //        {
                //            i.BarcodeOrStatus = "ex";
                //            continue;
                //        }
                //    }

                //}

                //var abc = (from b in _context.BarcodeAllots//.Where(x  =>x.ExamLevel==42)
                //           join m in _context.MarksAllots//.Where( x=>x.Grade=="A")
                //           on b.SessionYear equals m.SessionYear
                //           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < tempObj.Sessionyear || b.SessionYear == tempObj.Sessionyear && b.MonthId < tempObj.Monthid) && (b.ExamLevel == 42 || b.ExamLevel == tempObj.Examlevel) && (m.Grade == "A" || m.Grade == "B")
                //           orderby b.RegNo, b.SubId
                //           select new
                //           {
                //               RegNo = b.RegNo,
                //               ExamRollno = b.ExamRollno,
                //               Examlevel = b.ExamLevel,
                //               BarCode = b.BarCode,
                //               Grade = m.Grade,
                //               SessionYear = b.SessionYear,
                //               EPSubId = b.SubId == 421 ? 621 :
                //                                      b.SubId == 422 ? 622 :
                //                                      b.SubId == 423 ? 623 :
                //                                      b.SubId == 424 ? 624 :
                //                                      b.SubId == 425 ? 625 :
                //                                      b.SubId == 426 ? 626 :
                //                                      b.SubId == 427 ? 627 :
                //                                      b.SubId == 428 ? 628 : b.SubId
                //               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                //           }).ToList();

                //foreach (var i in barcodeSingleSubject62)
                //{
                //    foreach (var j in abc)
                //    {
                //        if (i.RegNo == j.RegNo)
                //        {
                //            if (j.EPSubId == tempObj.Subid) i.BarcodeOrStatus = "ep";
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}

                bS62.BarcodeSingleSubjectDetails = barcodeSingleSubject62;

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Allocation Data for: " + elName + ", " + sessName + ", " + tempObj.Sessionyear + ", Subject: " + sName,
                    Success = true,
                    Payload = bS62
                });


            }
            else if (tempObj.Examlevel == 63)
            {
                List<BarcodeSingleSubjectDetails> barcodeSingleSubject63 = new List<BarcodeSingleSubjectDetails>();

                BarcodeSingleSubject2 bS63 = new BarcodeSingleSubject2();

                bS63.Examlevelname = elName;
                bS63.MonthName = sessName;
                bS63.SubjectName = sName;

                var abc = (from m in _context.VwMarksfinals
                           where (m.ExamLevel == 51 || m.ExamLevel == 63) && (m.Grade == "A" || m.Grade == "B")
                           && m.SubId != 512 && //(m.SessionYear < tempObj.Sessionyear || (m.SessionYear == tempObj.Sessionyear && m.MonthId < tempObj.Monthid))

                             ((m.SessionYear < tempObj.Sessionyear) ||
                               (
                                 tempObj.Monthid == 3 ? false :
                                 tempObj.Monthid == 1 ? (m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) :
                                 tempObj.Monthid == 2 ? ((m.SessionYear == tempObj.Sessionyear && m.MonthId == 3) ||
                                                        (m.SessionYear == tempObj.Sessionyear && m.MonthId == 1)) : false
                               )
                             )

                           orderby m.RegNo, m.SubId
                           select new
                           {
                               RegNo = m.RegNo,
                               ExamRollno = m.ExamRollno,
                               Examlevel = m.ExamLevel,
                               SessionYear = m.SessionYear,
                               EPSubId = m.SubId == 511 ? 631 :
                                         m.SubId == 513 ? 632 :
                                         m.SubId == 514 ? 633 : m.SubId
                               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                           }).ToList();

                //var getFromExamReg = (from x in _context.ExamRegs.Select(a => new { a.RegNo, a.ExamRollno, a.ExamLevel, a.MonthId, a.SessionYear, a.Ref })
                //                      from b in _context.BarcodeAllots.Where(e => x.ExamRollno == e.ExamRollno && x.RegNo == e.RegNo && x.MonthId == e.MonthId && x.SessionYear == e.SessionYear && x.ExamLevel == e.ExamLevel).DefaultIfEmpty()
                //                      from ex in _context.ExemptedSubs.Where(c => x.RegNo == c.RegNo && x.ExamLevel == c.ExamLevel).DefaultIfEmpty()
                //                      where (x.ExamLevel == tempObj.Examlevel && x.MonthId == tempObj.Monthid && x.SessionYear == tempObj.Sessionyear)//&& (b.SubId == 621 || ex.SubId == 621))
                //                      orderby x.ExamRollno, b.SubId

                //                      select new
                //                      {
                //                          RegNo = x.RegNo,
                //                          ExamRollno = x.ExamRollno,
                //                          SubId = b.SubId,
                //                          BarCode = b.BarCode,
                //                          ExempSub = ex.SubId
                //                      }
                //                    ).ToList();

                //var lol = getFromExamReg.Select(x => new { x.RegNo, x.ExamRollno }).Distinct().ToList();


                foreach (var i in subjectWiseBarcodeView)
                {
                    var b = new BarcodeSingleSubjectDetails();
                    b.RegNo = i.RegNo;
                    b.ExamRollno = i.ExamRollno;
                    b.BarcodeOrStatus = i.Barcode == null ? "Absent" : i.Barcode.ToString();

                    barcodeSingleSubject63.Add(b);
                }

                //foreach (var i in barcodeSingleSubject63)
                //{
                //    foreach (var j in getFromExamReg)
                //    {
                //        if (i.RegNo == j.RegNo)
                //        {
                //            if (j.SubId == tempObj.Subid) i.BarcodeOrStatus = j.BarCode.ToString();
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}

                //++++++++++ EP ++++++++++

                foreach (var item in barcodeSingleSubject63)
                {
                    bool TureOrFalse = abc.Any(o => o.RegNo == item.RegNo && o.EPSubId == tempObj.Subid);

                    if (TureOrFalse == true)
                    {
                        item.BarcodeOrStatus = "ep";
                    }
                }

                //++++++++++ EP ++++++++++

                //var abc = (from b in _context.BarcodeAllots//.Where(x  =>x.ExamLevel==42)
                //           join m in _context.MarksAllots//.Where( x=>x.Grade=="A")
                //           on b.SessionYear equals m.SessionYear
                //           where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < tempObj.Sessionyear || b.SessionYear == tempObj.Sessionyear && b.MonthId < tempObj.Monthid)
                //           && (b.ExamLevel == 51 || b.ExamLevel == tempObj.Examlevel) && (m.Grade == "A" || m.Grade == "B") && (b.SubId != 512 || m.SubId != 512)
                //           orderby b.RegNo, b.SubId // 
                //           select new
                //           {
                //               RegNo = b.RegNo,
                //               ExamRollno = b.ExamRollno,
                //               Examlevel = b.ExamLevel,
                //               BarCode = b.BarCode,
                //               Grade = m.Grade,
                //               SessionYear = b.SessionYear,
                //               EPSubId = b.SubId == 511 ? 631 :
                //                                      b.SubId == 513 ? 632 :
                //                                      b.SubId == 514 ? 633 : b.SubId
                //               //.ToString().Substring(0,1) == "4" ? String.Join("6", b.SubId.ToString().Substring(1,2)) : b.SubId.ToString() // String.Join("6",b.SubId.ToString().Substring(1,2)) a.ToString().Concat(b.SubId.ToString().Substring(1,2))
                //           }).ToList();

                //foreach (var i in barcodeSingleSubject63)
                //{
                //    foreach (var j in abc)
                //    {
                //        if (i.RegNo == j.RegNo)
                //        {
                //            if (j.EPSubId == tempObj.Subid) i.BarcodeOrStatus = "ep";
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //}

                bS63.BarcodeSingleSubjectDetails = barcodeSingleSubject63;

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Allocation Data for: " + elName + ", " + sessName + ", " + tempObj.Sessionyear + ", Subject: " + sName,
                    Success = true,
                    Payload = bS63
                    //payload2 = bS63.BarcodeSingleSubjectDetails.Count
                });

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam Level will be only 61, 62, 63",
                    Success = false,
                    Payload = new { ExamlevelId = tempObj.Examlevel }
                });
            }

        }
    }
}