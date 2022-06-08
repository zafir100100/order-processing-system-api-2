using System.Linq;
using ICABAPI.DTOs;
using ICABAPI.Models;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace ICABAPI.Controllers
{
    public class GetRegAndRoll
    {
        public int? RegNo { get; set; }
        public int? ExamRollno { get; set; }
    }

    [Authorize]
    public class BarcodeCorrectionController : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public BarcodeCorrectionController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get single reg no or exam roll for corrrection
        /// </summary>
        [HttpPost("GetRegOrRollForCorrection")]
        public IActionResult GetSingleBarcodeForCorrrection(InputObject inputObject)
        {

            if (inputObject.Examlevel == 0 || inputObject.Monthid == 0 || inputObject.Subid == 0
            || inputObject.Sessionyear == 0 || ((inputObject.Regno == 0 || inputObject.Regno == null) && (inputObject.Examroll == 0 || inputObject.Examroll == null)))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Examlevel, Monthid, Subid, Session Year can not be 0, Also Regno and ExamRoll both cannot be 0",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                string elName = _context.Subjects.Where(g => g.SubId == inputObject.Examlevel).Select(i => i.SubName).FirstOrDefault();
                string sName = _context.Subjects.Where(g => g.SubId == inputObject.Subid).Select(i => i.SubName).FirstOrDefault();
                string sessName = _context.SessionInfos.Where(g => g.SessionId == inputObject.Monthid).Select(i => i.SessionName).FirstOrDefault();

                if (inputObject.Regno == 0 || inputObject.Regno == null)
                {

                    List<GetRegAndRoll> fetchedReg = (from er in _context.ExamRegs
                                                      from rs in _context.RegSubjects.Where(x => x.RefNo == er.Ref)
                                                      where (er.ExamLevel == inputObject.Examlevel && er.MonthId == inputObject.Monthid
                                                      && er.SessionYear == inputObject.Sessionyear && er.ExamRollno == inputObject.Examroll
                                                      && rs.SubId == inputObject.Subid)
                                                      select new GetRegAndRoll
                                                      {
                                                          RegNo = er.RegNo,
                                                          ExamRollno = er.ExamRollno
                                                      }).ToList();


                    if (fetchedReg.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "This Roll didnot register for Subject: " + sName + ", " + elName + ", " + sessName + ", " + inputObject.Sessionyear,
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "This Roll registered for Subject: " + sName + ", " + elName + ", " + sessName + ", " + inputObject.Sessionyear,
                        Success = true,
                        Payload = fetchedReg.FirstOrDefault()
                    });
                }
                else
                {
                    List<GetRegAndRoll> fetchedRoll = (from er in _context.ExamRegs
                                                       from rs in _context.RegSubjects.Where(x => x.RefNo == er.Ref)
                                                       where (er.ExamLevel == inputObject.Examlevel && er.MonthId == inputObject.Monthid
                                                       && er.SessionYear == inputObject.Sessionyear && er.RegNo == inputObject.Regno
                                                       && rs.SubId == inputObject.Subid)
                                                       select new GetRegAndRoll
                                                       {
                                                           RegNo = er.RegNo,
                                                           ExamRollno = er.ExamRollno
                                                       }).ToList();


                    //int examROll = (int)GetRoll.FirstOrDefault().ExamRollno;

                    if (fetchedRoll.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "This Roll didnot register for Subject: " + sName + ", " + elName + ", " + sessName + ", " + inputObject.Sessionyear,
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "This Roll registered for Subject: " + sName + ", " + elName + ", " + sessName + ", " + inputObject.Sessionyear,
                        Success = true,
                        Payload = fetchedRoll.FirstOrDefault()
                    });
                }
            }

        }

        /// <summary>
        /// Update single bar code 
        /// </summary>
        [HttpPost("UpdateSingleBarCodeForCorrection")]
        public IActionResult GetSingleBarcodeForCorrrection(InputObject2 inputObject)
        {

            int? resultLockStatus = _context.ResultLocks.Where(rl => rl.ExamLevel == inputObject.examlevel
            && rl.SessionYear == inputObject.sessionyear && rl.MonthId == inputObject.monthid).Select(g => g.RLock).FirstOrDefault();
            if (resultLockStatus == 1)
            {

                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Result is Locked",
                    Success = false,
                    Payload = null
                });
            }

            if (inputObject.examlevel == 0 || inputObject.monthid == 0 || inputObject.subid == 0
            || inputObject.sessionyear == 0 || (inputObject.regno == 0 && inputObject.examroll == 0))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Examlevel, Monthid, Subid, Session Year can not be 0, Also Regno and ExamRoll both cannot be 0",
                    Success = false,
                    Payload = null
                });
            }

            if (inputObject.Barcode == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Barcode cannot be null",
                    Success = false,
                    Payload = null
                });
            }
            else
            {
                var elName = _context.Subjects.Where(g => g.SubId == inputObject.examlevel).FirstOrDefault().SubName;
                var sName = _context.Subjects.Where(g => g.SubId == inputObject.subid).FirstOrDefault().SubName;
                var sessName = _context.SessionInfos.Where(g => g.SessionId == inputObject.monthid).FirstOrDefault().SessionName;

                var ToBeUpdateBarcode = _context.BarcodeAllots.Where(x => x.ExamLevel == inputObject.examlevel && x.MonthId == inputObject.monthid &&
                x.SessionYear == inputObject.sessionyear && x.SubId == inputObject.subid && (x.ExamRollno == inputObject.examroll || x.RegNo == inputObject.regno)).FirstOrDefault();

                StringBuilder sb = new StringBuilder();
                String strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] address = ipHostEntry.AddressList;
                sb.Append(address[4].ToString());
                sb.AppendLine();

                if (ToBeUpdateBarcode == null)
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
                    var toSendBarcodeEdit = new BarcodeEdit();

                    toSendBarcodeEdit.RegNo = ToBeUpdateBarcode.RegNo;
                    toSendBarcodeEdit.ExamRollno = ToBeUpdateBarcode.ExamRollno;
                    toSendBarcodeEdit.ExamLevel = ToBeUpdateBarcode.ExamLevel;
                    toSendBarcodeEdit.SessionYear = ToBeUpdateBarcode.SessionYear;
                    toSendBarcodeEdit.SubId = ToBeUpdateBarcode.SubId;
                    toSendBarcodeEdit.MonthId = ToBeUpdateBarcode.MonthId;
                    toSendBarcodeEdit.UdSlno = ToBeUpdateBarcode.UdSlno;
                    toSendBarcodeEdit.UserId = ToBeUpdateBarcode.UserId;

                    toSendBarcodeEdit.Editdate = DateTime.Today;
                    toSendBarcodeEdit.Edittime = DateTime.Now.ToString("HH:mm:ss");
                    toSendBarcodeEdit.PcInfo = sb.ToString();
                    toSendBarcodeEdit.Userid1 = inputObject.changeuser;
                    toSendBarcodeEdit.Editpart = 1; // Barcode Upper //
                    toSendBarcodeEdit.EditDelete = "Edit";

                    toSendBarcodeEdit.BarCode = ToBeUpdateBarcode.BarCode;

                    _context.BarcodeEdits.Add(toSendBarcodeEdit);
                    _context.SaveChanges();


                    ToBeUpdateBarcode.BarCode = inputObject.Barcode;
                    ToBeUpdateBarcode.UserId = inputObject.changeuser;

                    _context.BarcodeAllots.Update(ToBeUpdateBarcode);
                    _context.SaveChanges();

                    transaction.Commit();

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                    {
                        Message = "Update failed. Something went wrong, Please try again later.",
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Barcode Updated for: " + inputObject.regno,
                    Success = true,
                    Payload = new { RegNo = inputObject.regno }
                });


            }
        }

    }
}