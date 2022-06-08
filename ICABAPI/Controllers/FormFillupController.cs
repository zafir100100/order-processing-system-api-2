using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Models;
using ICABAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ICABAPI.Controllers
{
    public class InputForUnapproveTabulationSheet
    {
        public int Ref { get; set; }
        public string ChangeUser { get; set; }
    }
    public class OutputForUpdateFormFillupOnlinePaymentBeforeApproval
    {
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public int? RegNo { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public string Exfeepayslipbank { get; set; }
        public string Exfeepayslipbr { get; set; }
        public DateTime? Exfeepayslipdate { get; set; }
        public string Exfeepayslipno { get; set; }

        public decimal? Annfeepayslipamt { get; set; }
        public string Annfeepayslipbank { get; set; }
        public string Annfeepayslipbr { get; set; }
        public DateTime? Annfeepayslipdate { get; set; }
        public string Annfeepayslipno { get; set; }

        public string FilepathExfeeuploadPayslip { get; set; }
        public string FilepathAnnfeeuploadPayslip { get; set; }
    }
    public class ExamFeeDetailsOutput
    {
        public int RegNo { get; set; }
        public string FormNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public DateTime? Exfeepayslipdate { get; set; }
        public string Exfeepayslipno { get; set; }
        public string Exfeepayslipbank { get; set; }
        public string Exfeepayslipbr { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
    }

    public class ExamFeeDetailsInput
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class FormFillupModel6
    {
        public int? RegNo { get; set; }
    }

    public class FormFillupModel1
    {
        public int RegNo { get; set; }
    }

    public class FormFillupModel2 : FormFillupModel1
    {
        public int ExamLevel { get; set; }
    }

    public class FormFillupModel4 : FormFillupModel1
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class GetIntegratedTabulationSheet
    {
        public int ExamLevel1 { get; set; }
        public int ExamLevel2 { get; set; }
        public int? ExamLevel3 { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int TabulationSheetType { get; set; }
    }

    public class OutputForIntegratedTabulationSheet
    {
        public int Root { get; set; }
        public OutputForIntegratedTabulationSheetType1 Children { get; set; }
    }

    public class OutputForIntegratedTabulationSheet2
    {
        public int Root { get; set; }
        public OutputForIntegratedTabulationSheetType2 Children { get; set; }
    }

    public class OutputForIntegratedTabulationSheetType1
    {
        public int Sl { get; set; }
        public int RegNo { get; set; }
        public int? ExamRollno1 { get; set; }
        public string Grade1 { get; set; }
        public string Grade2 { get; set; }
        public string Grade3 { get; set; }
        public string Grade4 { get; set; }
        public string Grade5 { get; set; }
        public string Grade6 { get; set; }
        public string Grade7 { get; set; }
        public int TotalNumberOfPass1 { get; set; }
        public int? ExamRollno2 { get; set; }
        public string Grade8 { get; set; }
        public string Grade9 { get; set; }
        public string Grade10 { get; set; }
        public string Grade11 { get; set; }
        public string Grade12 { get; set; }
        public string Grade13 { get; set; }
        public string Grade14 { get; set; }
        public int TotalNumberOfPass2 { get; set; }
    }

    public class OutputForIntegratedTabulationSheetType2
    {
        public int Sl { get; set; }
        public int RegNo { get; set; }
        public string Grade1 { get; set; }
        public string Grade2 { get; set; }
        public string Grade3 { get; set; }
        public string Grade4 { get; set; }
        public string Grade5 { get; set; }
        public string Grade6 { get; set; }
        public string Grade7 { get; set; }
        public int TotalNumberOfPass1 { get; set; }
        public int? ExamRollno2 { get; set; }
        public string Grade8 { get; set; }
        public string Grade9 { get; set; }
        public string Grade10 { get; set; }
        public string Grade11 { get; set; }
        public string Grade12 { get; set; }
        public string Grade13 { get; set; }
        public string Grade14 { get; set; }
        public int TotalNumberOfPass2 { get; set; }
        public int? ExamRollno3 { get; set; }
        public string Grade15 { get; set; }
        public string Grade16 { get; set; }
        public string Grade17 { get; set; }
        public int TotalNumberOfPass3 { get; set; }
    }

    public class FormFillupModel3
    {
        public int RegNo { get; set; }
        public string Salutation { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string BloodGr { get; set; }
        public string NationalId { get; set; }
        public string PreAdd { get; set; }
        public string PerAdd { get; set; }
        public string Ph { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string FirmName { get; set; }
        public string PrinName { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public int? StudType { get; set; }
        public string CcEnrno { get; set; }
        public string CcSession { get; set; }
        public int? CcYear { get; set; }
        public int? LastAppearedMonthid { get; set; }
        public int? LastAppearedYear { get; set; }
        public int? LastAppearedRollno { get; set; }
        public int? LastAppearedExamlevel { get; set; }
        public string LastAppearedMonthName { get; set; }
        public string LastAppearedExamlevelName { get; set; }
        public int? EarlierPassingExamLevel { get; set; }
        public string EarlierPassingExamLevelName { get; set; }
        public int? EarlierPassingMonthId { get; set; }
        public string EarlierPassingMonthName { get; set; }
        public int? EarlierPassingSessionYear { get; set; }
        public List<FormFillupModel5> AppearedIn { get; set; }
        [DefaultValue(null)]
        public string Imagepath { get; set; }
        public decimal? Formsubmitstatus { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
    }

    public class FormFillupModel5
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        [DefaultValue(null)]
        public string ToBeAppeared { get; set; }
        public decimal? Amount { get; set; }
    }

    public class FormFillupModel8
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        [DefaultValue(false)]
        public bool CoachingClassAttended { get; set; }
    }

    public class FormFillupModel7
    {
        public TempExamReg Input1 { get; set; }
        public List<FormFillupModel8> CoachingClassSubjects { get; set; }
        public List<FormFillupModel5> AppearingInSubjects { get; set; }
    }

    public class FormFillupModel122
    {
        public int Ref { get; set; }
        public string FormNo { get; set; }
        public DateTime? FillupDate { get; set; }
        public int ExamRollno { get; set; }
        public int RegNo { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int ExamcenId { get; set; }
        public DateTime? TrainingSt { get; set; }
        public DateTime? TrainingEnd { get; set; }
        public int? LastAppearedMonthid { get; set; }
        public int? LastAppearedYear { get; set; }
        public int? LastAppearedRollno { get; set; }
        public int? LastAppearedExamlevel { get; set; }
        public int? EntryType { get; set; }
        public string AttenAttached { get; set; }
        public string TrainingAttached { get; set; }
        public int? Validity { get; set; }
        public string ReasonInvalid { get; set; }
        public string Entryuser { get; set; }
        public string FitnessAttached { get; set; }
        public int? StudType { get; set; }
        public string CcEnrno { get; set; }
        public string CcSession { get; set; }
        public int? CcYear { get; set; }
        public string FilepathAttenAttached { get; set; }
        public string FilepathTrainingAttached { get; set; }
        public string FilepathFitnessAttached { get; set; }
        public string FilepathExfeeuploadPayslip { get; set; }
        public string FilepathAnnfeeuploadPayslip { get; set; }
    }

    public class FormFillupModel12
    {
        public FormFillupModel122 Input1 { get; set; }
        public List<FormFillupModel8> CoachingClassSubjects { get; set; }
        public List<FormFillupModel5> AppearingInSubjects { get; set; }
    }

    public class FormFillupModel9
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class FormFillupModel10
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public int RegNo { get; set; }
        public int RefNo { get; set; }
        public int? MaintbRef { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
    }

    public class FormFillupModel13
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public int RegNo { get; set; }
        public int RefNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
    }

    public class FormFillupModel11
    {
        public int Ref { get; set; }
    }

    public class FormFillupModel14
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public string Status { get; set; }
    }

    public class FormFillupModel15
    {
        public int ExamLevel { get; set; }
        public List<FormFillupModel14> SubjectsWithStatus { get; set; }

    }

    public class FormFillupModel16 : FormFillupModel15
    {
        public bool IsLevelPassed { get; set; }
        public int? EarlierPassingLevelExamLevel { get; set; }
        public int EarlierPassingLevelMonthId { get; set; }
    }

    public class FormFillupModel17
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RegNo { get; set; }
    }

    public class FormFillupModel24
    {
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RefNo { get; set; }
    }

    public class FormFillupModel25
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RegNo { get; set; }
    }

    public class FormFillupModel26
    {
        public int ExamLevel { get; set; }
        public int RegNo { get; set; }
    }

    public class FormFillupModel27
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class FormFillupModel28
    {
        public int? ExamRollno { get; set; }
        public int? RegNo { get; set; }
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public int? BarCode { get; set; }
        public decimal? Marks { get; set; }
        public string Grade { get; set; }
    }

    public class FormFillupModel29
    {
        public int ExamLevel { get; set; }
        public bool IsExamLevelPassed { get; set; }
        public List<TabulationsControllerModel2> ResultDetails { get; set; }
        public int? LastAppearedMonthid { get; set; }
        public int? LastAppearedYear { get; set; }
        public int? LastAppearedRollno { get; set; }
        public int? LastAppearedExamlevel { get; set; }
        public string LastAppearedMonthName { get; set; }
        public string LastAppearedExamlevelName { get; set; }
        public int? EarlierPassingExamLevel { get; set; }
        public string EarlierPassingExamLevelName { get; set; }
        public int? EarlierPassingMonthId { get; set; }
        public string EarlierPassingMonthName { get; set; }
        public int? EarlierPassingSessionYear { get; set; }
    }

    public class FormFillupModel30
    {
        public int? RegNo { get; set; }
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public string Status { get; set; } //Must -- For Student Always "VALID"
        public string CardType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string User { get; set; } //flag: Student / Admin
    }

    public class SubjectWithGrade
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public string Session { get; set; }
        public int? Year { get; set; }
        public string Grade { get; set; }
    }

    public class ExamLevelWithSubject
    {
        public int ExamLevel { get; set; }
        public string ExamLevelName { get; set; }
        public List<SubjectWithGrade> Subjects { get; set; }
        [DefaultValue(0)]
        public int TotalNumberOfSubjectPassed { get; set; }
    }

    public class GetStudentCurrentStatus
    {
        public int RegNo { get; set; }
        public string NameOfStudent { get; set; }
        public string NameOfFather { get; set; }
        public string NameOfMother { get; set; }
        public string NameOfFirm { get; set; }
        public string NameOfPrincipal { get; set; }
        public List<ExamLevelWithSubject> ExamLevelWithSubjects { get; set; }
    }

    public class GetString
    {
        public string MyString { get; set; }
    }

    public class InputForOnlinePaymentResponse
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int RegNo { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
        public string Name { get; set; }
        public string Success_url { get; set; }
        public string Fail_url { get; set; }
        public string Cancel_url { get; set; }
        public string Redirect_url { get; set; }
    }

    public class InputForUpdateOnlinePaymentResponse
    {
        public string TransactionId { get; set; }
        public string SessionKey { get; set; }
        public string Status { get; set; }
        public string CardType { get; set; }
        public DateTime? PaymentTime { get; set; }
    }

    public class InputForPayment
    {
        public string Store_id { get; set; }
        public string Store_passwd { get; set; }
        public string Total_amount { get; set; }
        public string Currency { get; set; }
        public string Tran_id { get; set; }
        public string Success_url { get; set; }
        public string Fail_url { get; set; }
        public string Cancel_url { get; set; }
        public string Cus_name { get; set; }
        public string Cus_email { get; set; }
        public string Cus_add1 { get; set; }
        public string Cus_add2 { get; set; }
        public string Cus_city { get; set; }
        public string Cus_state { get; set; }
        public string Cus_postcode { get; set; }
        public string Cus_country { get; set; }
        public string Cus_phone { get; set; }
        public string Cus_fax { get; set; }
        public string Ship_name { get; set; }
        public string Ship_add1 { get; set; }
        public string Ship_add2 { get; set; }
        public string Ship_city { get; set; }
        public string Ship_state { get; set; }
        public string Ship_postcode { get; set; }
        public string Ship_country { get; set; }
        public string Multi_card_name { get; set; }
        public string Value_a { get; set; }
        public string Value_b { get; set; }
        public string Value_c { get; set; }
        public string Value_d { get; set; }
        public string Shipping_method { get; set; }
        public string Product_name { get; set; }
        public string Product_category { get; set; }
        public string Product_profile { get; set; }
    }

    public class Desc
    {
        public string Gw { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string R_flag { get; set; }
        public string RedirectGatewayURL { get; set; }
        public string Type { get; set; }
    }

    public class Gw
    {
        public string Amex { get; set; }
        public string Internetbanking { get; set; }
        public string Master { get; set; }
        public string Mobilebanking { get; set; }
        public string Othercards { get; set; }
        public string Visa { get; set; }
    }

    public class Root
    {
        public List<Desc> Desc { get; set; }
        public string DirectPaymentURL { get; set; }
        public string DirectPaymentURLBank { get; set; }
        public string DirectPaymentURLCard { get; set; }
        public string Failedreason { get; set; }
        public string GatewayPageURL { get; set; }
        public Gw Gw { get; set; }
        public string Is_direct_pay_enable { get; set; }
        public string RedirectGatewayURL { get; set; }
        public string RedirectGatewayURLFailed { get; set; }
        public string Sessionkey { get; set; }
        public string Status { get; set; }
        public string Store_name { get; set; }
        public string StoreBanner { get; set; }
        public string StoreLogo { get; set; }
    }

    public class OfflinePaymentDataOutput
    {
        public int SlNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
        public DateTime? FillupDate { get; set; }
    }
    public class OfflinePaymentDataInput
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class OutputForGetListOfIncompletePaymentReport
    {
        public int SlNo { get; set; }
        public string FormNo { get; set; }
        public int RegNo { get; set; }
        public int RefNo { get; set; }
        public int? MaintbRef { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public decimal? Exfeepayslipamt { get; set; }
        public decimal? Annfeepayslipamt { get; set; }
    }


    //[Authorize]

    public class FormFillupController : CustomType1ApiController
    {
        private readonly ModelContext _context;
        private readonly IEmailService _emailService;
        public FormFillupController(ModelContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        /// <summary>
        /// Get Offline Payment Data 
        /// </summary>
        [HttpPost("GetOfflinePaymentData")]
        public async Task<ActionResult<ResponseDto2>> GetOfflinePaymentData([FromBody] OfflinePaymentDataInput input)
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
            bool isExamLevelExists = await _context.Subjects.AnyAsync(i => i.SubId == input.ExamLevel && (input.ExamLevel == 61 || input.ExamLevel == 62 || input.ExamLevel == 63));
            if (isExamLevelExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }
            bool isMonthExists = await _context.SessionInfos.AnyAsync(i => i.SessionId == input.MonthId);
            if (isMonthExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "This month id does not exists",
                    Success = false,
                    Payload = null
                });
            }
            List<OfflinePaymentDataOutput> paymentData = await (from ter in _context.TempExamRegs.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear)
                                                                join sr1 in _context.StuReg1s
                                                                on ter.RegNo equals sr1.RegNo
                                                                select new OfflinePaymentDataOutput
                                                                {
                                                                    SlNo = 1,
                                                                    RegNo = ter.RegNo,
                                                                    Name = sr1.Name,
                                                                    Exfeepayslipamt = ter.Exfeepayslipamt,
                                                                    Annfeepayslipamt = ter.Annfeepayslipamt,
                                                                    FillupDate = ter.FillupDate

                                                                }).OrderBy(i => i.RegNo).ToListAsync();

            bool isRowFoundValid = paymentData.Count > 0;

            if (isRowFoundValid == true)
            {
                int counter = 1;
                foreach (var item in paymentData)
                {
                    item.SlNo = counter++;
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of offline payment data",
                    Success = true,
                    Payload = new
                    {
                        PaymentData = paymentData,
                        totalExfeepayslipamt = paymentData.Sum(i => i.Exfeepayslipamt ?? 0),
                        Annfeepayslipamt = paymentData.Sum(o => o.Annfeepayslipamt ?? 0),
                        totalRow = paymentData.Count
                    }
                });
            }

            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = "No offline payment data found",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Get Success Payment Data
        /// </summary>
        [HttpPost("GetSuccessPaymentData")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<ContentResult> GetOnlinePaymentData([FromForm] Dictionary<string, string> input)
        {
            string card_type = input.ContainsKey("card_type") == false ? "n/a" : input["card_type"];
            string card_status = input.ContainsKey("status") == false ? "n/a" : input["status"];
            string amount = input.ContainsKey("amount") == false ? "n/a" : input["amount"];
            string currency_type = input.ContainsKey("currency_type") == false ? "n/a" : input["currency_type"];
            string error = input.ContainsKey("error") == false ? "n/a" : input["error"];
            string tran_date = input.ContainsKey("tran_date") == false ? "n/a" : input["tran_date"];
            string tran_id = input.ContainsKey("tran_id") == false ? "n/a" : input["tran_id"];
            string payment_err = input.ContainsKey("error") == false ? "n/a" : input["error"];
            OnlinePaymentDetail onlinePaymentDetail = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == tran_id).FirstOrDefaultAsync();

            onlinePaymentDetail.CardType = card_type;
            onlinePaymentDetail.Status = card_status;
            onlinePaymentDetail.PaymentTime = DateTime.Parse(tran_date);
            onlinePaymentDetail.PaymentError = payment_err == null ? null : payment_err;

            int isSaved = 0;
            if (onlinePaymentDetail != null)
            {
                _context.OnlinePaymentDetails.Update(onlinePaymentDetail);
                isSaved = await _context.SaveChangesAsync();
            }

            if (isSaved > 0 && onlinePaymentDetail.Status.ToLower() == "valid")
            {
                TempExamReg tempExamRg = await _context.TempExamRegs.Where(i => i.ExamLevel == onlinePaymentDetail.ExamLevel && i.MonthId == onlinePaymentDetail.MonthId && i.SessionYear == onlinePaymentDetail.SessionYear && i.RegNo == onlinePaymentDetail.RegNo && i.PaymentMode.ToLower() == "online" && i.Formsubmitstatus == -1).FirstOrDefaultAsync();
                if (tempExamRg != null)
                {
                    tempExamRg.Exfeepayslipamt = onlinePaymentDetail.Exfeepayslipamt;
                    tempExamRg.Exfeepayslipbank = "99";
                    tempExamRg.Exfeepayslipbr = "9999";
                    tempExamRg.Exfeepayslipdate = onlinePaymentDetail.PaymentTime;
                    tempExamRg.Exfeepayslipno = onlinePaymentDetail.TransactionId;

                    if(onlinePaymentDetail.Annfeepayslipamt!= null)
                    {
                        tempExamRg.Annfeepayslipamt = onlinePaymentDetail.Annfeepayslipamt;
                        tempExamRg.Annfeepayslipbank = "ONLINE";
                        tempExamRg.Annfeepayslipbr = "ONLINE";
                        tempExamRg.Annfeepayslipdate = onlinePaymentDetail.PaymentTime;
                        tempExamRg.Annfeepayslipno = onlinePaymentDetail.TransactionId;
                    }

                    tempExamRg.Formsubmitstatus = 1;

                    _context.TempExamRegs.Update(tempExamRg);
                    int x = await _context.SaveChangesAsync();

                    if (x > 0)
                    {
                        string allAppliedSubjectNames = "";
                        List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(i => i.RefNo == tempExamRg.Ref).OrderBy(i => i.SubId).ToListAsync();
                        if (tempRegSubjects.Count > 0)
                        {
                            foreach (var item in tempRegSubjects)
                            {
                                allAppliedSubjectNames += "<br>" + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync();
                            }
                            string examLevelName = await _context.Subjects.Where(i => i.SubId == tempExamRg.ExamLevel).Select(i => i.SubName).FirstOrDefaultAsync();
                            string monthName = await _context.SessionInfos.Where(i => i.SessionId == tempExamRg.MonthId).Select(i => i.SessionName).FirstOrDefaultAsync();
                            StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == tempExamRg.RegNo).FirstOrDefaultAsync();
                            decimal myamount = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == tempExamRg.Exfeepayslipno).Select(i => i.Amount).FirstOrDefaultAsync();
                            string amountToWords = ConvertToWords(myamount.ToString());
                            var paymentTime = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == tempExamRg.Exfeepayslipno).Select(i => i.PaymentTime).FirstOrDefaultAsync();
                            string messageForEmail = $@"
                            <p>
                            <h4>Dear <code>{stuReg1.Name} (Registration No.: {tempExamRg.RegNo}),</code></h4> 
                            <br>  
                            Your Examination Application Form has been received successfully for {examLevelName}, {monthName}, {tempExamRg.SessionYear} for the subjects:
                            <br>
                            {allAppliedSubjectNames}
                            <br>
                            <br>
                            We also acknowledge the receipt of a sum of TK.{myamount}/- ({amountToWords}) via electronic fund transfer on {paymentTime}.
                            <br>
                            Thanks & Regards,
                            <br>
                            ICAB Exam Division
                            <br>
                            <br>
                            * This is an auto generated email.
                            </p>
                            ";
                            if (stuReg1.Email != null)
                            {
                                _emailService.Send(
                                     to: stuReg1.Email,
                                     subject: "Submission of Examination Application Form",
                                     html: $@"{messageForEmail}"
                                );
                            }
                        }
                    }
                }
            }

            string name = onlinePaymentDetail?.Name;
            decimal? Regno = onlinePaymentDetail?.RegNo;

            string getSingleStudentEmail = await _context.StuReg1s.Where(x => x.RegNo == Convert.ToInt32(Regno))
                                            .Select(y => y.Email).FirstOrDefaultAsync();

            string redirect_url = onlinePaymentDetail?.RedirectUrl + "/" + card_status + "/" + tran_id + "/" + tran_date;


            string finalOutput = "<html><head><meta name=\"viewport\" content=\"width=device - width, initial - scale=1\"><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\"></script><style>.paymentpage .backicon1{ cursor: pointer; color: #168DD8; font-size: 1vw; font-weight: bold;} .paymentpage .textfont{ font-weight: bold; font-size: 1vw;} .paymentpage .backBreadCrumb{ padding-bottom: 20px;} .paymentContainer.container-fluid{ width: 98%; padding-bottom: 3%; font-family: Helvetica; padding-top: 5%; margin-left: auto; box-shadow: -2px 2px 10px 2px #dedede; border: 1px solid #cccccc; margin-bottom: 2%; padding-left: 0%; padding-right: 0%;} .backicon{ font-size: 1.5vw; color: #168DD8; opacity: .6;} .backclr{ cursor: pointer; color: #168DD8; font-size: 1vw; } .pointer{ cursor: pointer;} .paymentDetails{ width: 30%; margin: 25px 0; font-size: 1.2em;} .blueColor{ color: #168DD8;} .backlinkPayment{ margin-top: 15px;} .col-6{ width: 20% !important; display: inline-block;} .hellocustomer{ margin-left: 5%; text-align: left; font: normal normal medium 0.8333vw/0.98vw Helvetica; letter-spacing: 0px; color: #030c58;} .mcsheader{ padding-top: 1%; position: fixed; z-index: 999; border-bottom: 4px solid #168dd8; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .mplheader{ padding-top: 1%; position: fixed; z-index: 999999; resize: both; border-bottom: 4px solid #1c57a4; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .img-fluid2{ height: 23px; width: 23px; margin-top: 1px; margin-left: 7px;} .heading2{ margin-right: 2%; color: #030c58; margin-top: 1%; float: right;} .logut{ margin-left: 16%; cursor: pointer;} .custome{ margin-left: -34%;} .cancelButton{ background-color: #333333;} .loginbutton{ background-color: #168dd8;} .threedot{ width: 21px; height: 5px;} button:focus{ outline: none;} .nobuttonalign{ float: right; text-align: center; font-size: 0.825vw;} .loginbutton{ font-size: 0.825vw; text-align: center;} .logoutheadingpopup{ font-size: 1vw; text-align: center; display: inline-block; font-weight: 400; line-height: 1.29; letter-spacing: 0.16px;} .headerstyle .marginleft{ margin-left: 3.5%;} .headerstyle .buttonsSec{ margin: 10px auto;} .headerstyle .buttonsSec .cancelButton{ margin-right: 10px; background-color: #999; text-align: center;} .headerstyle .mat-dialog-content{ margin: 31px -24px; padding: 0 24px; max-height: 65vh; font-size: 110%; overflow: visible;} .headerstyle .mat-dialog-container{ position: relative;} .headerstyle .image{ height: 202px; margin-left: -5%;} .headerstyle .col4background{ background-color: #ebf7ff;} .headerstyle .imagepadding{ padding-top: 44%;} .headerstyle .imagepadding1{ padding-top: 14%;} .headerstyle .marginrow{ margin-top: -1%;} .headerstyle .widhtmenu{ width: 100%;} .headerstyle .borderline{ outline: none; border: none;} .headerstyle .container{ width: 100%; max-width: 100%;} .headerstyle .heading{ color: white; margin-left: -3%;} .headerstyle .usermanelign{ margin-left: 3%; padding-left: 3%;} .headerstyle .blockname{ text-align: left; font: normal normal bold 1.04vw/ 1.3vw Helvetica; letter-spacing: 0px; margin-left: 1.5%; color: #030c58;} .headerstyle .mcsheader{ padding-top: 1%; position: fixed; z-index: 999; border-bottom: 4px solid #168dd8; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .headerstyle .platform{ text-align: left; font: normal normal normal 1.04vw/1.3vw Helvetica; letter-spacing: 0px; margin-left: 0.4%; color: #030c58;} </style></head><body><div class=\"headerstyle\"><div class=\"mcsheader container-fluid \"><div class=\"row\"><div class=\"offset-7 col-4\"><h5 class=\"heading2\">Hello " + name + " </h5></div></div></div><div class=\"paymentpage\"><div class=\"container-fluid paymentContainer\"><div *ngIf=\"loading\"><app-loader></app-loader></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Tran id</div><div class=\"col-6\">" + tran_id + "</div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Card type</div><div class=\"col-6\">" + card_type + "</div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Status</div><div class=\"col-6\">" + card_status + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Amount</div><div class=\"col-6\">" + amount + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Currency</div><div class=\"col-6\">" + currency_type + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Payment date</div><div class=\"col-6\">" + tran_date + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">error</div><div class=\"col-6\">" + error + " </div></div><div class=\"row paymentDetails\"><div class=\"col-10\"><button class=\"mr-4 backclr pointer ml-2\" style=\"border-radius: 10px; padding: 0px 15px;\" (click)=\"back()\"><a href=\"" + redirect_url + "\"><b>Close</b></a></button></div></div></div></div></body></html>";

            return base.Content(finalOutput, "text/html");
        }

        /// <summary>
        /// Get Online Payment Data
        /// </summary>
        [HttpPost("GetOnlinePaymentData")]
        public async Task<ActionResult<ResponseDto2>> GetOnlinePaymentData([FromBody] InputForOnlinePaymentResponse input)
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
            if (input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Success_url == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Success url can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Fail_url == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Fail url can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Cancel_url == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Cancel url can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if (input.Name == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Name can not be null",
                    Success = false,
                    Payload = null
                });
            }
            if ((input.Exfeepayslipamt == null || input.Exfeepayslipamt < 1) && (input.Annfeepayslipamt == null || input.Annfeepayslipamt < 1))
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Either exam fee or annual fee must be a valid monetory amount",
                    Success = false,
                    Payload = null
                });
            }
            bool isExamLevelExists = await _context.Subjects.AnyAsync(i => i.SubId == input.ExamLevel && (input.ExamLevel == 61 || input.ExamLevel == 62 || input.ExamLevel == 63));
            if (isExamLevelExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }
            bool isMonthExists = await _context.SessionInfos.AnyAsync(i => i.SessionId == input.MonthId);
            if (isMonthExists == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "This month id does not exists",
                    Success = false,
                    Payload = null
                });
            }
            decimal amount = (input.Exfeepayslipamt ?? 0) + (input.Annfeepayslipamt ?? 0);
            Random random = new Random();
            Dictionary<string, string> keyValuePairs = new()
            {
                { "store_id", "satco616d1dc5029ff" },
                { "store_passwd", "satco616d1dc5029ff@ssl" },
                //{ "total_amount", "100" },
                { "total_amount", amount.ToString() },
                { "currency", "BDT" },
                //{ "tran_id", "SATICAB1" },
                { "tran_id", "SATICAB" + random.Next(99999999) },
                //{ "success_url", "http://yoursite.com/success.php" },
                { "success_url", input.Success_url },
                //{ "fail_url", "http://yoursite.com/fail.php" },
                { "fail_url", input.Fail_url },
                //{ "cancel_url", "http://yoursite.com/cancel.php" },
                { "cancel_url", input.Cancel_url },
                //{ "cus_name", "icab" },
                { "cus_name", input.Name },
                { "cus_email", "cust@yahoo.com" },
                { "cus_add1", "Dhaka" },
                { "cus_add2", "Dhaka" },
                { "cus_city", "Dhaka" },
                { "cus_state", "Dhaka" },
                { "cus_postcode", "1000" },
                { "cus_country", "Bangladesh" },
                { "cus_phone", "01711111111" },
                { "cus_fax", "01711111111" },
                { "ship_name", "Customer Name" },
                { "ship_add1", "Dhaka" },
                { "ship_add2", "Dhaka" },
                { "ship_city", "Dhaka" },
                { "ship_state", "Dhaka" },
                { "ship_postcode", "1000" },
                { "ship_country", "Bangladesh" },
                { "multi_card_name", "mastercard,visacard,amexcard" },
                { "value_a", "ref001_A" },
                { "value_b", "ref002_B" },
                { "value_c", "ref003_C" },
                { "value_d", "ref004_D" },
                { "shipping_method", "NO" },
                { "product_name", "Exam Fee" },
                { "product_category", "Exam Fee" },
                { "product_profile", "Exam Fee" }
            };

            List<KeyValuePair<string, string>> keyValuePairs1 = keyValuePairs.ToList();

            string url = "https://sandbox.sslcommerz.com/gwprocess/v4/api.php";
            string apiResponse;
            Root root = new();
            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(keyValuePairs1))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    apiResponse = await response.Content.ReadAsStringAsync();
                    root = JsonConvert.DeserializeObject<Root>(apiResponse);
                }
            }
            bool isSuccess = root.Status == "SUCCESS";
            string ssKey = root.Sessionkey;

            OnlinePaymentDetail onlinePaymentDetail = new();

            onlinePaymentDetail.ExamLevel = input.ExamLevel;
            onlinePaymentDetail.MonthId = input.MonthId;
            onlinePaymentDetail.SessionYear = input.SessionYear;
            onlinePaymentDetail.RegNo = input.RegNo;
            onlinePaymentDetail.Name = input.Name;
            onlinePaymentDetail.TransactionId = keyValuePairs["tran_id"];
            onlinePaymentDetail.Amount = amount;
            onlinePaymentDetail.Exfeepayslipamt = input.Exfeepayslipamt;
            onlinePaymentDetail.Annfeepayslipamt = input.Annfeepayslipamt;
            onlinePaymentDetail.RedirectUrl = input.Redirect_url;
            onlinePaymentDetail.SessionKey = ssKey;

            _context.OnlinePaymentDetails.Add(onlinePaymentDetail);
            int isSaved = await _context.SaveChangesAsync();

            return StatusCode(isSuccess ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isSuccess ? "API responded with successs" : "Failed reason: " + root.Failedreason,
                Success = isSuccess,
                Payload = new
                {
                    Output = root,
                }
            });
        }

        /// <summary>
        /// Update Online Payment Data
        /// </summary>
        [HttpPatch("UpdateOnlinePaymentData")]
        public async Task<ActionResult<ResponseDto2>> UpdateOnlinePaymentData([FromBody] InputForUpdateOnlinePaymentResponse input)
        {
            OnlinePaymentDetail onlinePaymentDetail = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == input.TransactionId).FirstOrDefaultAsync();
            if (onlinePaymentDetail == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "This transaction id does not exists",
                    Success = false,
                    Payload = null
                });
            }
            onlinePaymentDetail.SessionKey = input.SessionKey;
            onlinePaymentDetail.Status = input.Status;
            onlinePaymentDetail.CardType = input.CardType;
            onlinePaymentDetail.PaymentTime = input.PaymentTime;

            _context.OnlinePaymentDetails.Update(onlinePaymentDetail);
            bool isSaved = await _context.SaveChangesAsync() > 0;

            return StatusCode(isSaved ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = isSaved ? "API responded with successs" : "Data update failed. Something went wrong, please try again later",
                Success = isSaved,
                Payload = null
            });
        }

        /// <summary>
        /// Get Student Current Status
        /// </summary>
        [HttpPost("GetStudentCurrentStatus")]
        public async Task<ActionResult<ResponseDto2>> GetStudentCurrentStatus([FromBody] FormFillupModel6 input)
        {
            if (input.RegNo == null || input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number " + input.RegNo + " can not be null",
                    Success = false,
                    Payload = null
                });
            }
            GetStudentCurrentStatus output = new();
            //get personal info
            StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();
            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student found with registration number " + input.RegNo,
                    Success = false,
                    Payload = null
                });
            }
            output.RegNo = stuReg1.RegNo;
            output.NameOfStudent = stuReg1.Name;
            output.NameOfFather = stuReg1.FName;
            output.NameOfMother = stuReg1.MName;
            output.NameOfFirm = stuReg1.FId == null ? null : await _context.FirmMas1s.Where(i => i.FId == stuReg1.FId).Select(j => j.FName).FirstOrDefaultAsync();
            output.NameOfPrincipal = stuReg1.PrinID == null ? null
                                        : await (from m in _context.Members
                                                 from p in _context.Principals.Where(p => m.MemId == p.MemId && p.PrinId == stuReg1.PrinID)
                                                 select new GetString
                                                 {
                                                     MyString = m.Name
                                                 }
                                                ).Select(l => l.MyString).FirstOrDefaultAsync();
            //initialize subject
            List<Subject> subjects =
                await _context.Subjects
                              .Where(i => i.SubId == 41 || i.SubId == 42 || i.SubId == 51 ||
                                          i.SubId == 61 || i.SubId == 62 || i.SubId == 63 ||
                                          i.Parent == 41 || i.Parent == 42 || i.Parent == 51 ||
                                          i.Parent == 61 || i.Parent == 62 || i.Parent == 63
                                    ).OrderBy(i => i.SubId).ToListAsync();
            if (subjects == null || subjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found",
                    Success = false,
                    Payload = null
                });
            }
            Subject examLevel41 = subjects.Where(i => i.SubId == 41).FirstOrDefault();
            Subject examLevel42 = subjects.Where(i => i.SubId == 42).FirstOrDefault();
            Subject examLevel51 = subjects.Where(i => i.SubId == 51).FirstOrDefault();
            Subject examLevel61 = subjects.Where(i => i.SubId == 61).FirstOrDefault();
            Subject examLevel62 = subjects.Where(i => i.SubId == 62).FirstOrDefault();
            Subject examLevel63 = subjects.Where(i => i.SubId == 63).FirstOrDefault();
            List<Subject> subjectsForExamLevel41 = subjects.Where(i => i.Parent == 41).ToList();
            List<Subject> subjectsForExamLevel42 = subjects.Where(i => i.Parent == 42).ToList();
            List<Subject> subjectsForExamLevel51 = subjects.Where(i => i.Parent == 51).ToList();
            List<Subject> subjectsForExamLevel61 = subjects.Where(i => i.Parent == 61).ToList();
            List<Subject> subjectsForExamLevel62 = subjects.Where(i => i.Parent == 62).ToList();
            List<Subject> subjectsForExamLevel63 = subjects.Where(i => i.Parent == 63).ToList();
            ExamLevelWithSubject examLevelWithSubjectForExamLevel41 = new();
            if (examLevel41 != null)
            {
                examLevelWithSubjectForExamLevel41.ExamLevel = examLevel41.SubId;
                examLevelWithSubjectForExamLevel41.ExamLevelName = examLevel41.SubName;
                if (subjectsForExamLevel41.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel41)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel41.Subjects = subjectWithGrades;
                }
            }
            ExamLevelWithSubject examLevelWithSubjectForExamLevel42 = new();
            if (examLevel42 != null)
            {
                examLevelWithSubjectForExamLevel42.ExamLevel = examLevel42.SubId;
                examLevelWithSubjectForExamLevel42.ExamLevelName = examLevel42.SubName;
                if (subjectsForExamLevel42.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel42)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel42.Subjects = subjectWithGrades;
                }
            }
            ExamLevelWithSubject examLevelWithSubjectForExamLevel51 = new();
            if (examLevel51 != null)
            {
                examLevelWithSubjectForExamLevel51.ExamLevel = examLevel51.SubId;
                examLevelWithSubjectForExamLevel51.ExamLevelName = examLevel51.SubName;
                if (subjectsForExamLevel51.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel51)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel51.Subjects = subjectWithGrades;
                }
            }
            ExamLevelWithSubject examLevelWithSubjectForExamLevel61 = new();
            if (examLevel61 != null)
            {
                examLevelWithSubjectForExamLevel61.ExamLevel = examLevel61.SubId;
                examLevelWithSubjectForExamLevel61.ExamLevelName = examLevel61.SubName;
                if (subjectsForExamLevel61.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel61)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel61.Subjects = subjectWithGrades;
                }
            }
            ExamLevelWithSubject examLevelWithSubjectForExamLevel62 = new();
            if (examLevel62 != null)
            {
                examLevelWithSubjectForExamLevel62.ExamLevel = examLevel62.SubId;
                examLevelWithSubjectForExamLevel62.ExamLevelName = examLevel62.SubName;
                if (subjectsForExamLevel62.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel62)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel62.Subjects = subjectWithGrades;
                }
            }
            ExamLevelWithSubject examLevelWithSubjectForExamLevel63 = new();
            if (examLevel63 != null)
            {
                examLevelWithSubjectForExamLevel63.ExamLevel = examLevel63.SubId;
                examLevelWithSubjectForExamLevel63.ExamLevelName = examLevel63.SubName;
                if (subjectsForExamLevel63.Count > 0)
                {
                    List<SubjectWithGrade> subjectWithGrades = new();
                    foreach (Subject subject in subjectsForExamLevel63)
                    {
                        SubjectWithGrade subjectWithGrade = new();
                        subjectWithGrade.SubId = subject.SubId;
                        subjectWithGrade.SubName = subject.SubName;
                        subjectWithGrades.Add(subjectWithGrade);
                    }
                    examLevelWithSubjectForExamLevel63.Subjects = subjectWithGrades;
                }
            }
            List<ExamLevelWithSubject> examLevelWithSubjects = new();
            List<SessionInfo> sessionInfos = await _context.SessionInfos.ToListAsync();

            //get all from vwMarksFinals
            List<VwMarksfinal> vwMarksfinals = await _context.VwMarksfinals
                                                             .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 1 || i.ExamLevel == 2 || i.ExamLevel == 3 || i.ExamLevel == 41 || i.ExamLevel == 42 || i.ExamLevel == 51 || i.ExamLevel == 61 || i.ExamLevel == 62 || i.ExamLevel == 63) && (i.Grade == "A" || i.Grade == "B"))
                                                             .ToListAsync();
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
            foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
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

            foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel62.Subjects)
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
            foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
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
            //System.Diagnostics.Debug.WriteLine("Here is count of 3: " + vwMarksfinalExamLevel3.Count);
            if (vwMarksfinalExamLevel3 != null && vwMarksfinalExamLevel3.Count > 0)
            {
                // level 3 er minimum 1 subject e pass korle 41 er
                // 411, 412, 414, 415, 416, 417 e ex pabe
                //
                // level 3 er moddhey
                // jodi 34 pass kore, then 413->613 ex
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel41.Subjects)
                {
                    if (vwMarksfinalExamLevel3.Count > 0)
                    {
                        if (item.SubId == 411 || item.SubId == 412 || item.SubId == 414 || item.SubId == 415 || item.SubId == 416 || item.SubId == 417)
                        {
                            item.Grade = "ex";
                            continue;
                        }
                        else if (item.SubId == 413)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel42.Subjects)
                {
                    if (vwMarksfinalExamLevel3.Count > 0)
                    {
                        if (item.SubId == 421 || item.SubId == 422 || item.SubId == 426 || item.SubId == 427)
                        {
                            item.Grade = "ex";
                            continue;
                        }
                        else if (item.SubId == 423)
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
                        else if (item.SubId == 424)
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
                        else if (item.SubId == 425)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel41.Subjects)
                {
                    if (item.SubId == 411 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 411).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 412 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 412).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 413 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 413).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 414 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 414).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 415 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 415).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 416 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 416).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 417 && exemptedSubsExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == 417).FirstOrDefault() != null)
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

            //get grade: ep for level 41 from vw marks final
            List<VwMarksfinal> vwMarksfinalExamLevel41 = vwMarksfinals.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && (i.Grade == "A" || i.Grade == "B")).ToList();
            //System.Diagnostics.Debug.WriteLine("Here is count of 41: " + vwMarksfinalExamLevel41.Count);
            if (vwMarksfinalExamLevel41 != null && vwMarksfinalExamLevel41.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel41.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel41.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 41 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel42.Subjects)
                {
                    if (item.SubId == 421 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 421).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 422 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 422).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 423 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 423).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 424 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 424).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 425 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 425).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 425 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 426).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 427 && exemptedSubsExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == 427).FirstOrDefault() != null)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel42.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel42.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 42 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel51.Subjects)
                {
                    if (item.SubId == 511 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 511).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 513 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 513).FirstOrDefault() != null)
                    {
                        item.Grade = "ex";
                        continue;
                    }
                    else if (item.SubId == 514 && exemptedSubsExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == 514).FirstOrDefault() != null)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel51.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel51.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 51 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for 61 from icmab
            List<StudentOfIcmabAcca> studentOfIcmabAccasExamLevel61 = studentOfIcmabAccas.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61).ToList();
            if (studentOfIcmabAccasExamLevel61 != null && studentOfIcmabAccasExamLevel61.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
                {
                    if (studentOfIcmabAccasExamLevel61.Any(s => s.ExamLevel == 61 && s.SubId == item.SubId))
                    {
                        item.Grade = "ex";
                        continue;
                    }
                }
            }

            //get grade: ex for 61 from exemptedsubs
            List<ExemptedSub> exemptedSubsExamLevel61 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61).ToList();
            if (exemptedSubsExamLevel61 != null && exemptedSubsExamLevel61.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for 61 from setExmpMous
            List<SetExmpMou> setExmpMous61 = setExmpMous.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61).ToList();
            if (setExmpMous61 != null && setExmpMous61.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
                {
                    SetExmpMou exmpMou = setExmpMous61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.ExmptSubid == item.SubId).FirstOrDefault();
                    if (exmpMou != null)
                    {
                        item.Session = await _context.SessionInfos.Where(i => i.SessionId == exmpMou.ExamSession).Select(i => i.SessionName).FirstOrDefaultAsync();
                        item.Year = exmpMou.ExamYear;
                        item.Grade = "ex";
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
            if (studentOfIcmabAccasExamLevel62 != null && studentOfIcmabAccasExamLevel62.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel62.Subjects)
                {
                    if (studentOfIcmabAccasExamLevel62.Any(s => s.ExamLevel == 62 && s.SubId == item.SubId))
                    {
                        item.Grade = "ex";
                        continue;
                    }
                }
            }

            //get grade: ex for 62 from exempted sub
            List<ExemptedSub> exemptedSubsExamLevel62 = exemptedSubs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62).ToList();
            if (exemptedSubsExamLevel62 != null && exemptedSubsExamLevel62.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel62.Subjects)
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel62.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel62.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            //get grade: ex for 62 from setExmpMous
            List<SetExmpMou> setExmpMous62 = setExmpMous.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62).ToList();
            if (setExmpMous62 != null && setExmpMous62.Count > 0)
            {
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel61.Subjects)
                {
                    SetExmpMou exmpMou = setExmpMous62.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && i.ExmptSubid == item.SubId).FirstOrDefault();
                    if (exmpMou != null)
                    {
                        item.Session = await _context.SessionInfos.Where(i => i.SessionId == exmpMou.ExamSession).Select(i => i.SessionName).FirstOrDefaultAsync();
                        item.Year = exmpMou.ExamYear;
                        item.Grade = "ex";
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
                foreach (SubjectWithGrade item in examLevelWithSubjectForExamLevel63.Subjects)
                {
                    VwMarksfinal vwMarksfinal = vwMarksfinalExamLevel63.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 63 && i.SubId == item.SubId && (i.Grade == "A" || i.Grade == "B")).FirstOrDefault();
                    if (vwMarksfinal != null)
                    {
                        item.Session = sessionInfos.Where(i => i.SessionId == vwMarksfinal.MonthId).Select(j => j.SessionName).FirstOrDefault();
                        item.Year = vwMarksfinal.SessionYear;
                        item.Grade = vwMarksfinal.Grade;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (examLevelWithSubjectForExamLevel41 != null)
            {
                examLevelWithSubjectForExamLevel41.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel41.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel41);
            }
            if (examLevelWithSubjectForExamLevel42 != null)
            {
                examLevelWithSubjectForExamLevel42.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel42.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel42);
            }
            if (examLevelWithSubjectForExamLevel51 != null)
            {
                examLevelWithSubjectForExamLevel51.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel51.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel51);
            }
            if (examLevelWithSubjectForExamLevel61 != null)
            {
                examLevelWithSubjectForExamLevel61.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel61.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel61);
            }
            if (examLevelWithSubjectForExamLevel62 != null)
            {
                examLevelWithSubjectForExamLevel62.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel62.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel62);
            }
            if (examLevelWithSubjectForExamLevel63 != null)
            {
                examLevelWithSubjectForExamLevel63.TotalNumberOfSubjectPassed = examLevelWithSubjectForExamLevel63.Subjects.Count(o => o.Grade == "A" || o.Grade == "B");
                examLevelWithSubjects.Add(examLevelWithSubjectForExamLevel63);
            }
            output.ExamLevelWithSubjects = examLevelWithSubjects;
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student Current Status for",
                Success = true,
                Payload = output
            });
        }

        [HttpPost("UnapproveTabulationSheet")]
        public async Task<ActionResult<ResponseDto2>> UnapproveTabulationSheet([FromBody] InputForUnapproveTabulationSheet input)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                ExamReg examReg = await _context.ExamRegs.Where(i => i.Ref == input.Ref).FirstOrDefaultAsync();
                if (examReg != null)
                {
                    //insert backup
                    ExamRegArch examRegArch = new()
                    {
                        Ref = examReg.Ref,
                        FormNo = examReg.FormNo,
                        FillupDate = examReg.FillupDate,
                        ExamRollno = examReg.ExamRollno,
                        RegNo = examReg.RegNo,
                        ExamLevel = examReg.ExamLevel,
                        MonthId = examReg.MonthId,
                        SessionYear = examReg.SessionYear,
                        ExamcenId = examReg.ExamcenId,
                        TrainingSt = examReg.TrainingSt,
                        TrainingEnd = examReg.TrainingEnd,
                        LastAppearedMonthid = examReg.LastAppearedMonthid,
                        LastAppearedYear = examReg.LastAppearedYear,
                        LastAppearedRollno = examReg.LastAppearedRollno,
                        LastAppearedExamlevel = examReg.LastAppearedExamlevel,
                        EntryType = examReg.EntryType,
                        AttenAttached = examReg.AttenAttached,
                        TrainingAttached = examReg.TrainingAttached,
                        Validity = examReg.Validity,
                        ReasonInvalid = examReg.ReasonInvalid,
                        Entryuser = examReg.Entryuser,
                        StudType = examReg.StudType,
                        ChangeId = (await _context.ExamRegArches.MaxAsync(i => i.ChangeId) ?? 0) + 1,
                        ChangeUser = input.ChangeUser,
                        PcInfo = Request.Headers.ContainsKey("X-Forwarded-For") == true ?
                                    Request.Headers["X-Forwarded-For"] :
                                    HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()
                    };
                    _context.ExamRegArches.Add(examRegArch);
                    await _context.SaveChangesAsync();
                    List<ExemptedSub> exemptedSubs = await _context.ExemptedSubs.Where(i => i.Ref == input.Ref).ToListAsync();
                    foreach (var item in exemptedSubs)
                    {
                        ExemptedSubArch exemptedSubArch = new()
                        {
                            ChangeId = (await _context.ExemptedSubArches.MaxAsync(o => o.ChangeId) ?? 0) + 1,
                            ExamLevel = examReg.ExamLevel,
                            Ref = examReg.Ref,
                            RegNo = examReg.RegNo,
                            SubId = item.SubId
                        };
                        _context.ExemptedSubArches.Add(exemptedSubArch);
                        await _context.SaveChangesAsync();
                        //_context.ExemptedSubs.Remove(item);
                        //await _context.SaveChangesAsync();
                    }

                    _context.ExamRegs.Remove(examReg);
                    await _context.SaveChangesAsync();
                    List<RegSubject> regSubjects = await _context.RegSubjects.Where(i => i.RefNo == input.Ref).ToListAsync();
                    foreach (var item in regSubjects)
                    {
                        _context.RegSubjects.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "No info found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Form fillup unapprove failed",
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
                Message = "Form fillup unapproval successful",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Create Form Fill up data for Moodle
        /// </summary>
        [HttpPost("CreateMoodleData")]
        public async Task<ActionResult<ResponseDto2>> CreateMoodleData([FromBody] FormFillupModel27 input)
        {
            if (input.ExamLevel != 61)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "This exam level is not allowed",
                    Success = false,
                    Payload = null
                });
            }
            string examLevelName = await _context.Subjects.Where(i => i.SubId == 61).Select(o => o.SubName).FirstOrDefaultAsync();
            //System.Diagnostics.Debug.WriteLine("here is el " + input.ExamLevel);
            //System.Diagnostics.Debug.WriteLine("here is elname " + examLevelName);
            if (examLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level does not exists",
                    Success = false,
                    Payload = null
                });
            }
            string monthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id does not exists",
                    Success = false,
                    Payload = null
                });
            }
            bool isBarcodeSequenceExists = await _context.Barseqs.AnyAsync(i => i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);

            if (isBarcodeSequenceExists == false)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Month id: " + input.MonthId + " and Session Year: " + input.SessionYear + " doesn't exists in barcode sequence. Please enter",
                    Success = false,
                    Payload = null
                });
            }

            bool isMoodleDataExists = await _context.FormFillUptableForMoodles.AnyAsync(i => i.EXAMLEVEL == input.ExamLevel && i.MONTHID == input.MonthId && i.SESSIONYEAR == input.SessionYear);

            if (isMoodleDataExists == true)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Moodle data already exists for Exam level : Certificate level Month: " + monthName + " and Session Year: " + input.SessionYear + " .",
                    Success = false,
                    Payload = null
                });
            }

            int maxBarcode = (await _context.Barseqs.MaxAsync(i => i.Barto) ?? 0) + 1;

            List<ExamReg> examRegs = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).OrderBy(j => j.RegNo).ToListAsync();
            List<int> regNoList = examRegs.Count > 0 ? examRegs.Select(o => o.RegNo).ToList() : null;
            int minx = regNoList.Count > 0 ? regNoList.Min() : 0;
            int maxx = regNoList.Count > 0 ? regNoList.Max() : 0;
            var query1 = await (from sr1 in _context.StuReg1s.Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                select new
                                {
                                    sr1.RegNo,
                                    sr1.Name,
                                    sr1.FName
                                }).ToListAsync();

            // using var transaction = _context.Database.BeginTransaction();
            // try
            // {
            foreach (var item in examRegs)
            {
                if (item.ExamRollno == 0)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Not all roll number is allocated. Please allocate all",
                        Success = false,
                        Payload = null
                    });
                }

                FormFillUptableForMoodle formFillUptableForMoodle = new();
                formFillUptableForMoodle.ID = (await _context.FormFillUptableForMoodles.MaxAsync(i => i.ID) ?? 0) + 1;
                formFillUptableForMoodle.REFNO = item.Ref;
                formFillUptableForMoodle.EXAMROLL = item.ExamRollno;
                formFillUptableForMoodle.REGNO = item.RegNo;
                formFillUptableForMoodle.NAME = query1.Where(o => o.RegNo == item.RegNo).Select(k => k.Name).FirstOrDefault();
                formFillUptableForMoodle.FATHERSNAME = query1.Where(o => o.RegNo == item.RegNo).Select(k => k.FName).FirstOrDefault();
                formFillUptableForMoodle.EXAMLEVEL = item.ExamLevel;
                formFillUptableForMoodle.MONTHID = item.MonthId;
                formFillUptableForMoodle.SESSIONYEAR = item.SessionYear;
                formFillUptableForMoodle.BARCODE = maxBarcode;
                formFillUptableForMoodle.APPEARINGFLAG = 0;

                _context.FormFillUptableForMoodles.Add(formFillUptableForMoodle);
                await _context.SaveChangesAsync();

                maxBarcode++;


            }
            //     transaction.Commit();
            // }
            // catch (Exception e)
            // {

            //     return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
            //     {
            //         Message = "Moodle data insertion failed. Something went wrong. Please try again later",
            //         Success = false,
            //         Payload = new
            //         {
            //             e.StackTrace,
            //             e.InnerException,
            //             e.Message
            //         }
            //     });
            // }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Moodle data creation successful for " + examRegs.Count + " students",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Get Form Fillup Data
        /// </summary>
        [HttpPost("GetFormFillupData")]
        public async Task<ActionResult<ResponseDto2>> GetFormFillupData([FromBody] FormFillupModel4 input)
        {
            string ExamLevelName = await _context.Subjects.Where(k => k.SubId == input.ExamLevel).Select(i => i.SubName).FirstOrDefaultAsync();

            if (ExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            string MonthName = await _context.SessionInfos.Where(k => k.SessionId == input.MonthId).Select(i => i.SessionName).FirstOrDefaultAsync();

            if (MonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            FormFillupAndExamRunningStatus formFillupAndExamRunningStatus = await _context.FormFillupAndExamRunningStatuses.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.FormFillupStatus == 0).FirstOrDefaultAsync();

            if (formFillupAndExamRunningStatus != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Form fillup has been closed for " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear,
                    Success = false,
                    Payload = null
                });
            }

            if (input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number " + input.RegNo + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

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

            //subject info loading
            List<Subject> subjects2 = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(i => i.SubId).ToListAsync();
            if (subjects2.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under exam level: " + ExamLevelName,
                    Success = false,
                    Payload = null
                });
            }

            //get fees
            List<ExamFee> examFees = await _context.ExamFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Amount != null && i.Amount >= 1).OrderBy(j => j.SubId).ToListAsync();
            if (examFees.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam fee info found: " + ExamLevelName,
                    Success = false,
                    Payload = null
                });
            }

            //is payment amount null check
            foreach (var item in examFees)
            {
                if (item.Amount == null || item.Amount < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No valid exam fee amount found for: " + subjects2.Where(i => i.SubId == item.SubId).Select(l => l.SubName).FirstOrDefault() + " in " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }
            }

            bool regNoFoundInStuReg1 = await _context.StuReg1s.AnyAsync(i => i.RegNo == input.RegNo);

            if (regNoFoundInStuReg1 == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration number " + input.RegNo + " is not found",
                    Success = false,
                    Payload = null
                });
            }

            bool regNoFoundInExamReg = await _context.ExamRegs.AnyAsync(i => i.RegNo == input.RegNo);

            if (regNoFoundInExamReg == false)
            {
                FormFillupModel3 output1 = new();

                var stuinfo = await _context.StuReg1s.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

                if (stuinfo != null)
                {
                    output1.BloodGr = stuinfo.BloodGr;
                    output1.Cell = stuinfo.Cell;
                    output1.Imagepath = stuinfo.Imagepath;
                    output1.Dob = stuinfo.Dob;
                    output1.Email = stuinfo.Email;
                    output1.FirmName = stuinfo.FirmName;
                    output1.FName = stuinfo.FName;
                    output1.Gender = stuinfo.Gender;
                    output1.MName = stuinfo.MName;
                    output1.Name = stuinfo.Name;
                    output1.NationalId = stuinfo.NationalId;
                    output1.Nationality = stuinfo.Nationality;
                    output1.PerAdd = stuinfo.PerAdd;
                    output1.PeriodFrom = stuinfo.PeriodFrom;
                    output1.PeriodTo = stuinfo.PeriodTo;
                    output1.Ph = stuinfo.Ph;
                    output1.PrinName = stuinfo.PrinName;
                    output1.RegNo = stuinfo.RegNo;
                    output1.Religion = stuinfo.Religion;
                    output1.Salutation = stuinfo.Salutation;
                    output1.StudType = stuinfo.StudType;
                    output1.Formsubmitstatus = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(i => i.Formsubmitstatus).FirstOrDefaultAsync();
                    output1.Exfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Exfeepayslipamt).FirstOrDefaultAsync();
                    output1.Annfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Annfeepayslipamt).FirstOrDefaultAsync();
                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.Name);
                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.RegNo);
                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.StudType);

                    List<Subject> subs = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(k => k.SubId).ToListAsync();
                    List<FormFillupModel29> o = await GetLevelWiseDetailsResultForOneStudent(input);
                    FormFillupModel29 oo = o.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();
                    List<FormFillupModel5> opx = new();
                    if (subs != null)
                    {
                        foreach (var item in subs)
                        {
                            FormFillupModel5 tempop2 = new();

                            tempop2.SubId = item.SubId;
                            tempop2.SubName = item.SubName;
                            tempop2.ToBeAppeared = oo.ResultDetails.Where(i => i.SubId == item.SubId).Select(i => i.Grade).FirstOrDefault() ?? null;
                            tempop2.Amount = examFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == item.SubId).Select(j => j.Amount).FirstOrDefault();

                            opx.Add(tempop2);
                        }
                        output1.AppearedIn = opx;
                    }


                    TempExamReg tempExamReg22 = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();
                    List<TempRegSubject> tr22 = tempExamReg22 == null ? null : await _context.TempRegSubjects.Where(i => i.RefNo == tempExamReg22.Ref).OrderBy(i => i.RefNo).ToListAsync();
                    //extension
                    if (tempExamReg22?.Formsubmitstatus == -1)
                    {
                        foreach (var item in tr22)
                        {
                            var x = output1.AppearedIn.Where(i => i.SubId == item.SubId).FirstOrDefault();
                            if (x != null)
                            {
                                x.ToBeAppeared = "true";
                            }
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Form Fill up data for " + input.RegNo,
                        Success = true,
                        Payload = output1
                    });
                }
            }

            //max ref
            int? refNo = await _context.ExamRegs.Where(o => o.RegNo == input.RegNo).MaxAsync(k => k.Ref);
            if (refNo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No reference number found in exam registration for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //is in exam reg
            ExamReg examReg = await _context.ExamRegs.Where(k => k.RegNo == input.RegNo && k.Ref == refNo).FirstOrDefaultAsync();
            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam registration info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //is in stu reg
            StuReg1 stuReg1 = await _context.StuReg1s.Where(s => s.RegNo == input.RegNo).FirstOrDefaultAsync();
            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration number: " + input.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            //get ccenr+ccsession+ccyear
            ExamReg examReg2 = await _context.ExamRegs.Where(i => i.RegNo == input.RegNo && i.CcEnrno != null && i.CcSession != null && i.CcYear != null).FirstOrDefaultAsync();

            TempExamReg tempExamReg = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();
            List<TempRegSubject> tr = tempExamReg == null ? null : await _context.TempRegSubjects.Where(i => i.RefNo == tempExamReg.Ref).OrderBy(i => i.RefNo).ToListAsync();
            if (tempExamReg != null)
            {
                string allAppliedSubs = "";
                List<int?> allAppliedSubsId = new();
                List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(i => i.RefNo == tempExamReg.Ref).ToListAsync();
                if (tempRegSubjects.Count > 0 && tempRegSubjects != null)
                {
                    foreach (var item in tempRegSubjects)
                    {
                        allAppliedSubsId.Add(item.SubId);
                        allAppliedSubs += ". " + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync();
                    }
                }
                if (tempExamReg.Formsubmitstatus == 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Form is already submitted for registration number " + input.RegNo + " for given criteria: " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear + " .Subjects: " + allAppliedSubs,
                        Success = false,
                        Payload = null
                    });
                }
            }
            //assign personal info
            FormFillupModel3 outputNew = new()
            {
                RegNo = stuReg1.RegNo,
                Imagepath = stuReg1.Imagepath,
                Salutation = stuReg1.Salutation,
                Name = stuReg1.Name,
                FName = stuReg1.FName,
                MName = stuReg1.MName,
                Dob = stuReg1.Dob,
                Gender = stuReg1.Gender,
                Nationality = stuReg1.Nationality,
                Religion = stuReg1.Religion,
                BloodGr = stuReg1.BloodGr,
                NationalId = stuReg1.NationalId,
                PreAdd = stuReg1.PreAdd,
                PerAdd = stuReg1.PerAdd,
                Ph = stuReg1.Ph,
                Cell = stuReg1.Cell,
                Email = stuReg1.Email,
                FirmName = stuReg1.FirmName,
                PrinName = stuReg1.PrinName,
                PeriodFrom = stuReg1.PeriodFrom,
                PeriodTo = stuReg1.PeriodTo,
                StudType = stuReg1.StudType,
                LastAppearedExamlevel = null,
                LastAppearedExamlevelName = null,
                LastAppearedMonthid = null,
                LastAppearedMonthName = null,
                LastAppearedYear = null,
                LastAppearedRollno = null,
                EarlierPassingExamLevel = null,
                EarlierPassingMonthId = null,
                AppearedIn = null,
                CcEnrno = examReg2?.CcEnrno,
                CcSession = examReg2?.CcSession,
                CcYear = examReg2?.CcYear,
                Formsubmitstatus = tempExamReg?.Formsubmitstatus
            };

            //assign result grade
            List<FormFillupModel29> getResult = await GetLevelWiseDetailsResultForOneStudent(input);

            bool is61LevelPassed = false;
            bool is62LevelPassed = false;
            bool is63LevelPassed = false;

            if (input.ExamLevel == 61)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();
                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                //extension
                if (tempExamReg?.Formsubmitstatus == -1)
                {
                    foreach (var item in tr)
                    {
                        var x = outputNew.AppearedIn.Where(i => i.SubId == item.SubId).FirstOrDefault();
                        if (x != null)
                        {
                            x.ToBeAppeared = "true";
                        }
                    }
                }
                outputNew.Exfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Exfeepayslipamt).FirstOrDefaultAsync();
                outputNew.Annfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Annfeepayslipamt).FirstOrDefaultAsync();
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            else if (input.ExamLevel == 62)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();

                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                //extension
                if (tempExamReg?.Formsubmitstatus == -1)
                {
                    foreach (var item in tr)
                    {
                        var x = outputNew.AppearedIn.Where(i => i.SubId == item.SubId).FirstOrDefault();
                        if (x != null)
                        {
                            x.ToBeAppeared = "true";
                        }
                    }
                }
                outputNew.Exfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Exfeepayslipamt).FirstOrDefaultAsync();
                outputNew.Annfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Annfeepayslipamt).FirstOrDefaultAsync();

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            else if (input.ExamLevel == 63)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();

                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                //extension
                if (tempExamReg?.Formsubmitstatus == -1)
                {
                    foreach (var item in tr)
                    {
                        var x = outputNew.AppearedIn.Where(i => i.SubId == item.SubId).FirstOrDefault();
                        if (x != null)
                        {
                            x.ToBeAppeared = "true";
                        }
                    }
                }
                outputNew.Exfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Exfeepayslipamt).FirstOrDefaultAsync();
                outputNew.Annfeepayslipamt = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Formsubmitstatus == -1).Select(i => i.Annfeepayslipamt).FirstOrDefaultAsync();

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "This exam level is not allowed: " + input.ExamLevel,
                Success = false,
                Payload = null
            });
        }

        [HttpPatch("update-form-fillup-online-payment-data-before-approval")]
        public async Task<ActionResult<ResponseDto2>> UpdateFormFillupOnlinePaymentBeforeApproval([FromBody] OutputForUpdateFormFillupOnlinePaymentBeforeApproval input)
        {
            TempExamReg tempExamRg = await _context.TempExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RegNo == input.RegNo && i.PaymentMode.ToLower() == "online" && i.Formsubmitstatus == -1).FirstOrDefaultAsync();
            if (tempExamRg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Form fillup submission not found for given criteria",
                    Success = false,
                    Payload = null
                });
            }
            tempExamRg.Exfeepayslipamt = input.Exfeepayslipamt;
            tempExamRg.Exfeepayslipbank = input.Exfeepayslipbank;
            tempExamRg.Exfeepayslipbr = input.Exfeepayslipbr;
            tempExamRg.Exfeepayslipdate = input.Exfeepayslipdate;
            tempExamRg.Exfeepayslipno = input.Exfeepayslipno;

            tempExamRg.Annfeepayslipamt = input.Annfeepayslipamt;
            tempExamRg.Annfeepayslipbank = input.Annfeepayslipbank;
            tempExamRg.Annfeepayslipbr = input.Annfeepayslipbr;
            tempExamRg.Annfeepayslipdate = input.Annfeepayslipdate;
            tempExamRg.Annfeepayslipno = input.Annfeepayslipno;

            tempExamRg.FilepathExfeeuploadPayslip = input.FilepathExfeeuploadPayslip;
            tempExamRg.FilepathAnnfeeuploadPayslip = input.FilepathAnnfeeuploadPayslip;

            tempExamRg.Formsubmitstatus = 1;

            _context.TempExamRegs.Update(tempExamRg);
            int x = await _context.SaveChangesAsync();

            if (x > 0)
            {
                string allAppliedSubjectNames = "";
                List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(i => i.RefNo == tempExamRg.Ref).OrderBy(i => i.SubId).ToListAsync();
                if (tempRegSubjects.Count > 0)
                {
                    foreach (var item in tempRegSubjects)
                    {
                        allAppliedSubjectNames += "<br>" + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync();
                    }
                    string examLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(i => i.SubName).FirstOrDefaultAsync();
                    string monthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(i => i.SessionName).FirstOrDefaultAsync();
                    StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();
                    decimal myamount = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == tempExamRg.Exfeepayslipno).Select(i => i.Amount).FirstOrDefaultAsync();
                    string amountToWords = ConvertToWords(myamount.ToString());
                    var paymentTime = await _context.OnlinePaymentDetails.Where(i => i.TransactionId == tempExamRg.Exfeepayslipno).Select(i => i.PaymentTime).FirstOrDefaultAsync();
                    string messageForEmail = $@"
                    <p>
                    <h4>Dear <code>{stuReg1.Name} (Registration No.: {input.RegNo}),</code></h4> 
                    <br>  
                    Your Examination Application Form has been received successfully for {examLevelName}, {monthName}, {input.SessionYear} for the subjects:
                    <br>
                    {allAppliedSubjectNames}
                    <br>
                    <br>
                    We also acknowledge the receipt of a sum of TK.{myamount}/- ({amountToWords}) via electronic fund transfer on {paymentTime}.
                    <br>
                    Thanks & Regards,
                    <br>
                    ICAB Exam Division
                    <br>
                    <br>
                    * This is an auto generated email.
                    </p>
                    ";
                    if (stuReg1.Email != null)
                    {
                        _emailService.Send(
                             to: stuReg1.Email,
                             subject: "Submission of Examination Application Form",
                             html: $@"{messageForEmail}"
                        );
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Payment data updated successfully",
                        Success = true,
                        Payload = null
                    });
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = "Payment data updated failedd",
                Success = false,
                Payload = null
            });
        }
        /// <summary>
        /// Get Form Fillup Data For Admin
        /// </summary>
        [HttpPost("GetFormFillupDataForAdmin")]
        public async Task<ActionResult<ResponseDto2>> GetFormFillupDataForAdmin([FromBody] FormFillupModel4 input)
        {
            string ExamLevelName = await _context.Subjects.Where(k => k.SubId == input.ExamLevel).Select(i => i.SubName).FirstOrDefaultAsync();

            if (ExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            string MonthName = await _context.SessionInfos.Where(k => k.SessionId == input.MonthId).Select(i => i.SessionName).FirstOrDefaultAsync();

            if (MonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }
            //FormFillupAndExamRunningStatus formFillupAndExamRunningStatus = await _context.FormFillupAndExamRunningStatuses.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.FormFillupStatus == 0).FirstOrDefaultAsync();
            //if (formFillupAndExamRunningStatus != null)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Form fillup has been closed for " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear,
            //        Success = false,
            //        Payload = null
            //    });
            //}
            if (input.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number " + input.RegNo + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

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

            TempExamReg tempExamReg = await _context.TempExamRegs.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (tempExamReg != null)
            {
                string allAppliedSubs = "";
                List<int?> allAppliedSubsId = new();
                List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(i => i.RefNo == tempExamReg.Ref).ToListAsync();
                if (tempRegSubjects.Count > 0 && tempRegSubjects != null)
                {
                    foreach (var item in tempRegSubjects)
                    {
                        allAppliedSubsId.Add(item.SubId);
                        allAppliedSubs += ". " + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync();
                    }
                }
                if (tempExamReg.Formsubmitstatus == 1)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Form is already submitted for registration number " + input.RegNo + " for given criteria: " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear + " .Subjects: " + allAppliedSubs,
                        Success = false,
                        Payload = null
                    });
                }
            }

            //subject info loading
            List<Subject> subjects2 = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(i => i.SubId).ToListAsync();
            if (subjects2.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under exam level: " + ExamLevelName,
                    Success = false,
                    Payload = null
                });
            }

            //get fees
            List<ExamFee> examFees = await _context.ExamFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.Amount != null && i.Amount >= 1).OrderBy(j => j.SubId).ToListAsync();
            if (examFees.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam fee info found: " + ExamLevelName,
                    Success = false,
                    Payload = null
                });
            }

            //is payment amount null check
            foreach (var item in examFees)
            {
                if (item.Amount == null || item.Amount < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No valid exam fee amount found for: " + subjects2.Where(i => i.SubId == item.SubId).Select(l => l.SubName).FirstOrDefault() + " in " + ExamLevelName + ", " + MonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }
            }

            bool regNoFoundInStuReg1 = await _context.StuReg1s.AnyAsync(i => i.RegNo == input.RegNo);

            if (regNoFoundInStuReg1 == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration number " + input.RegNo + " is not found",
                    Success = false,
                    Payload = null
                });
            }

            bool regNoFoundInExamReg = await _context.ExamRegs.AnyAsync(i => i.RegNo == input.RegNo);

            if (regNoFoundInExamReg == false)
            {
                FormFillupModel3 output1 = new();

                var stuinfo = await _context.StuReg1s.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

                if (stuinfo != null)
                {
                    output1.BloodGr = stuinfo.BloodGr;
                    output1.Cell = stuinfo.Cell;
                    output1.Imagepath = stuinfo.Imagepath;
                    output1.Dob = stuinfo.Dob;
                    output1.Email = stuinfo.Email;
                    output1.FirmName = stuinfo.FirmName;
                    output1.FName = stuinfo.FName;
                    output1.Gender = stuinfo.Gender;
                    output1.MName = stuinfo.MName;
                    output1.Name = stuinfo.Name;
                    output1.NationalId = stuinfo.NationalId;
                    output1.Nationality = stuinfo.Nationality;
                    output1.PerAdd = stuinfo.PerAdd;
                    output1.PeriodFrom = stuinfo.PeriodFrom;
                    output1.PeriodTo = stuinfo.PeriodTo;
                    output1.Ph = stuinfo.Ph;
                    output1.PrinName = stuinfo.PrinName;
                    output1.RegNo = stuinfo.RegNo;
                    output1.Religion = stuinfo.Religion;
                    output1.Salutation = stuinfo.Salutation;
                    output1.StudType = stuinfo.StudType;
                    output1.Formsubmitstatus = tempExamReg?.Formsubmitstatus;

                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.Name);
                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.RegNo);
                    //System.Diagnostics.Debug.WriteLine("get it? " + stuinfo.StudType);

                    List<Subject> subs = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).OrderBy(k => k.SubId).ToListAsync();

                    List<FormFillupModel29> o = await GetLevelWiseDetailsResultForOneStudent(input);
                    FormFillupModel29 oo = o.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();

                    List<FormFillupModel5> opx = new();
                    if (subs != null)
                    {
                        foreach (var item in subs)
                        {
                            FormFillupModel5 tempop2 = new();

                            tempop2.SubId = item.SubId;
                            tempop2.SubName = item.SubName;
                            tempop2.ToBeAppeared = oo.ResultDetails.Where(i => i.SubId == item.SubId).Select(i => i.Grade).FirstOrDefault() ?? null;
                            tempop2.Amount = examFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.SubId == item.SubId).Select(j => j.Amount).FirstOrDefault();

                            opx.Add(tempop2);
                        }
                        output1.AppearedIn = opx;
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Form Fill up data for " + input.RegNo,
                        Success = true,
                        Payload = output1
                    });
                }
            }

            //max ref
            int? refNo = await _context.ExamRegs.Where(o => o.RegNo == input.RegNo).MaxAsync(k => k.Ref);
            if (refNo == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No reference number found in exam registration for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //is in exam reg
            ExamReg examReg = await _context.ExamRegs.Where(k => k.RegNo == input.RegNo && k.Ref == refNo).FirstOrDefaultAsync();
            if (examReg == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam registration info found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            //is in stu reg
            StuReg1 stuReg1 = await _context.StuReg1s.Where(s => s.RegNo == input.RegNo).FirstOrDefaultAsync();
            if (stuReg1 == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Student registration data not found for registration number: " + input.RegNo,
                    Success = false,
                    Payload = null
                });
            }

            //get ccenr+ccsession+ccyear
            ExamReg examReg2 = await _context.ExamRegs.Where(i => i.RegNo == input.RegNo && i.CcEnrno != null && i.CcSession != null && i.CcYear != null).FirstOrDefaultAsync();

            //assign personal info
            FormFillupModel3 outputNew = new()
            {
                RegNo = stuReg1.RegNo,
                Imagepath = stuReg1.Imagepath,
                Salutation = stuReg1.Salutation,
                Name = stuReg1.Name,
                FName = stuReg1.FName,
                MName = stuReg1.MName,
                Dob = stuReg1.Dob,
                Gender = stuReg1.Gender,
                Nationality = stuReg1.Nationality,
                Religion = stuReg1.Religion,
                BloodGr = stuReg1.BloodGr,
                NationalId = stuReg1.NationalId,
                PreAdd = stuReg1.PreAdd,
                PerAdd = stuReg1.PerAdd,
                Ph = stuReg1.Ph,
                Cell = stuReg1.Cell,
                Email = stuReg1.Email,
                FirmName = stuReg1.FirmName,
                PrinName = stuReg1.PrinName,
                PeriodFrom = stuReg1.PeriodFrom,
                PeriodTo = stuReg1.PeriodTo,
                StudType = stuReg1.StudType,
                LastAppearedExamlevel = null,
                LastAppearedExamlevelName = null,
                LastAppearedMonthid = null,
                LastAppearedMonthName = null,
                LastAppearedYear = null,
                LastAppearedRollno = null,
                EarlierPassingExamLevel = null,
                EarlierPassingMonthId = null,
                AppearedIn = null,
                CcEnrno = examReg2?.CcEnrno,
                CcSession = examReg2?.CcSession,
                CcYear = examReg2?.CcYear,
                Formsubmitstatus = tempExamReg?.Formsubmitstatus
            };

            //assign result grade
            List<FormFillupModel29> getResult = await GetLevelWiseDetailsResultForOneStudent(input);

            bool is61LevelPassed = false;
            bool is62LevelPassed = false;
            bool is63LevelPassed = false;

            if (input.ExamLevel == 61)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();
                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            else if (input.ExamLevel == 62)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();

                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            else if (input.ExamLevel == 63)
            {
                FormFillupModel29 getCurrentResult = getResult.Where(i => i.ExamLevel == input.ExamLevel).FirstOrDefault();

                List<FormFillupModel5> myCollectedAppearedIn = new();
                foreach (var item in getCurrentResult.ResultDetails)
                {
                    FormFillupModel5 formFillupModel5 = new();
                    formFillupModel5.SubId = item.SubId ?? 0;
                    formFillupModel5.SubName = item.SubName;
                    formFillupModel5.ToBeAppeared = item.Grade;
                    formFillupModel5.Amount = examFees.Where(i => i.SubId == item.SubId).Select(k => k.Amount).FirstOrDefault();
                    myCollectedAppearedIn.Add(formFillupModel5);
                }
                outputNew.AppearedIn = myCollectedAppearedIn;

                //last time appeared assignment
                int? maxRef = await _context.ExamRegs.Where(j => j.RegNo == input.RegNo).MaxAsync(i => i.Ref);
                if (maxRef != null)
                {
                    ExamReg examReg1 = await _context.ExamRegs.Where(i => i.Ref == maxRef).FirstOrDefaultAsync();
                    if (examReg1 != null)
                    {
                        outputNew.LastAppearedExamlevel = examReg1.ExamLevel;
                        outputNew.LastAppearedMonthid = examReg1.MonthId;
                        outputNew.LastAppearedYear = examReg1.SessionYear;
                        outputNew.LastAppearedRollno = examReg1.ExamRollno;
                        outputNew.LastAppearedExamlevelName = await _context.Subjects.Where(i => i.SubId == examReg1.ExamLevel).Select(k => k.SubName).FirstOrDefaultAsync();
                        outputNew.LastAppearedMonthName = await _context.SessionInfos.Where(i => i.SessionId == examReg1.MonthId).Select(k => k.SessionName).FirstOrDefaultAsync();
                    }
                }

                //earlier passing level assignment
                if (getResult != null)
                {
                    is61LevelPassed = getResult.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);
                    is62LevelPassed = getResult.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
                    is63LevelPassed = getResult.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);

                    if (is63LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel63 = getResult.Where(i => i.ExamLevel == 63).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 63)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is62LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel62 = getResult.Where(i => i.ExamLevel == 62).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 62)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else if (is61LevelPassed == true)
                    {
                        FormFillupModel29 getResultForLevel61 = getResult.Where(i => i.ExamLevel == 61).FirstOrDefault();
                        foreach (var item in getResult)
                        {
                            if (item.ExamLevel == 61)
                            {
                                outputNew.EarlierPassingExamLevel = item.EarlierPassingExamLevel;
                                outputNew.EarlierPassingMonthId = item.EarlierPassingMonthId;
                                outputNew.EarlierPassingSessionYear = item.EarlierPassingSessionYear;
                                outputNew.EarlierPassingExamLevelName = item.EarlierPassingExamLevelName;
                                outputNew.EarlierPassingMonthName = item.EarlierPassingMonthName;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data for student with registration number: " + input.RegNo,
                    Success = true,
                    Payload = outputNew
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "This exam level is not allowed: " + input.ExamLevel,
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Get List Of Exam Forms To Approve
        /// </summary>
        [HttpPost("GetListOfExamFormsToApprove")]
        public async Task<ActionResult<ResponseDto2>> GetListOfExamFormsToApprove([FromBody] FormFillupModel9 input)
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

            bool examLevelFound = await _context.Subjects.AnyAsync(k => k.SubId == input.ExamLevel);

            if (examLevelFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            bool monthFound = await _context.SessionInfos.AnyAsync(k => k.SessionId == input.MonthId);

            if (monthFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            List<FormFillupModel10> output = await (from ter in _context.TempExamRegs.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear && o.Formsubmitstatus == 1 && o.Fapprove == 0)
                                                    join sr1 in _context.StuReg1s
                                                        on ter.RegNo equals sr1.RegNo
                                                    select new FormFillupModel10
                                                    {
                                                        SlNo = 0,
                                                        FormNo = ter.FormNo,
                                                        RegNo = ter.RegNo,
                                                        RefNo = ter.Ref,
                                                        MaintbRef = ter.MaintbRef,
                                                        Name = sr1.Name,
                                                        FName = sr1.FName,
                                                        MName = sr1.MName
                                                    }).OrderBy(i => i.FormNo).ToListAsync();

            if (output == null || output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Form Fill up data found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rowCount = 1;
            foreach (var item in output)
            {
                item.SlNo = rowCount;
                rowCount++;
            }

            bool isRowCountValid = output.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "List of " + output.Count + " unapproved Form Fill up data" : "No unapproved form fillup data available. Something went wrong. Please try again later",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Get List Of Exam Forms Approved
        /// </summary>
        [HttpPost("GetListOfExamFormsApproved")]
        public async Task<ActionResult<ResponseDto2>> GetListOfExamFormsApproved([FromBody] FormFillupModel9 input)
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

            bool examLevelFound = await _context.Subjects.AnyAsync(k => k.SubId == input.ExamLevel);

            if (examLevelFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            bool monthFound = await _context.SessionInfos.AnyAsync(k => k.SessionId == input.MonthId);

            if (monthFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            List<FormFillupModel13> output = await (from er in _context.ExamRegs.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear)
                                                    join sr1 in _context.StuReg1s
                                                        on er.RegNo equals sr1.RegNo
                                                    select new FormFillupModel13
                                                    {
                                                        SlNo = 0,
                                                        FormNo = er.FormNo,
                                                        RegNo = er.RegNo,
                                                        RefNo = er.Ref,
                                                        Name = sr1.Name,
                                                        FName = sr1.FName,
                                                        MName = sr1.MName
                                                    }).OrderBy(i => i.FormNo).ToListAsync();

            if (output == null || output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Form Fill up data found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rowCount = 1;
            foreach (var item in output)
            {
                item.SlNo = rowCount;
                rowCount++;
            }

            bool isRowCountValid = output.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "List of " + output.Count + " approved Form Fill up data" : "No unapproved form fillup data available. Something went wrong. Please try again later",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }

        /// <summary>
        /// Get Online Payment Report 
        /// </summary>
        [HttpPost("GetOnlinePaymentReport")]
        public async Task<ActionResult<ResponseDto2>> GetOnlinePaymentReport([FromBody] FormFillupModel30 input)
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

            if (input.Status == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Payment Status can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.User == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "User can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.User == "Student" && input.RegNo == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "RegNo can not be null",
                    Success = false,
                    Payload = null
                });
            }


            bool examLevelFound = await _context.Subjects.AnyAsync(k => k.SubId == input.ExamLevel);

            if (examLevelFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();

            bool monthFound = await _context.SessionInfos.AnyAsync(k => k.SessionId == input.MonthId);

            if (monthFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();


            if (input.User == "Student")
            {
                List<OnlinePaymentDetail> onlinePaymentDetailsStudent = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                                                                                                    && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                                                                                                    && x.Status == "VALID" && x.RegNo == input.RegNo).ToListAsync();


                foreach (var item in onlinePaymentDetailsStudent)
                {
                    item.Exfeepayslipamt = item.Exfeepayslipamt == null ? 0 : item.Exfeepayslipamt;
                    item.Annfeepayslipamt = item.Annfeepayslipamt == null ? 0 : item.Annfeepayslipamt;
                }

                if (onlinePaymentDetailsStudent.Count < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No  data found for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }


                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Data Found",
                    Success = true,
                    Payload = new { Output = onlinePaymentDetailsStudent, RowCount = onlinePaymentDetailsStudent.Count, ExamLevelName = examLevelName, MonthName = monthName }
                });

            }

            //-- Admin --

            List<OnlinePaymentDetail> onlinePaymentDetails = new();

            // With Examlevel, Month, Session, Status, RegNo
            if (input.RegNo != null)
            {
                onlinePaymentDetails = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                                                                                 && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                                                                                 && x.Status == input.Status && x.RegNo == input.RegNo).ToListAsync();
                //await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                //              && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                //              && x.Status == input.Status && x.CardType == input.CardType).ToListAsync();

                foreach (var item in onlinePaymentDetails)
                {
                    item.Exfeepayslipamt = item.Exfeepayslipamt == null ? 0 : item.Exfeepayslipamt;
                    item.Annfeepayslipamt = item.Annfeepayslipamt == null ? 0 : item.Annfeepayslipamt;
                }

                if (onlinePaymentDetails.Count < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No  data found for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

            }

            // With Examlevel, Month, Session, Status, CardType
            if (input.CardType != null)
            {
                onlinePaymentDetails = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                                                                               && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                                                                               && x.Status == input.Status && x.CardType == input.CardType).ToListAsync();

                foreach (var item in onlinePaymentDetails)
                {
                    item.Exfeepayslipamt = item.Exfeepayslipamt == null ? 0 : item.Exfeepayslipamt;
                    item.Annfeepayslipamt = item.Annfeepayslipamt == null ? 0 : item.Annfeepayslipamt;
                }

                if (onlinePaymentDetails.Count < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No  data found for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

            }

            // With Examlevel, Month, Session, Status, Date Range
            if (input.FromDate != null && input.ToDate != null && input.FromDate <= input.ToDate)
            {
                onlinePaymentDetails = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                                                               && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                                                               && x.Status == input.Status && x.PaymentTime >= input.FromDate && x.PaymentTime <= input.ToDate).ToListAsync();

                foreach (var item in onlinePaymentDetails)
                {
                    item.Exfeepayslipamt = item.Exfeepayslipamt == null ? 0 : item.Exfeepayslipamt;
                    item.Annfeepayslipamt = item.Annfeepayslipamt == null ? 0 : item.Annfeepayslipamt;
                }

                if (onlinePaymentDetails.Count < 1)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No  data found for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }
            }

            // All Null
            onlinePaymentDetails = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.ExamLevel
                                                                                    && x.MonthId == input.MonthId && x.SessionYear == input.SessionYear
                                                                                    && x.Status == input.Status).ToListAsync();


            foreach (var item in onlinePaymentDetails)
            {
                item.Exfeepayslipamt = item.Exfeepayslipamt == null ? 0 : item.Exfeepayslipamt;
                item.Annfeepayslipamt = item.Annfeepayslipamt == null ? 0 : item.Annfeepayslipamt;
            }

            if (onlinePaymentDetails.Count < 1)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No  data found for " + examLevelName + ", " + monthName + ", " + input.SessionYear,
                    Success = false,
                    Payload = null
                });
            }


            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Data Found",
                Success = true,
                Payload = new
                {
                    Output = onlinePaymentDetails,
                    RowCount = onlinePaymentDetails.Count,
                    TotalSum = onlinePaymentDetails.Sum(i => i.Amount),
                    ExamLevelName = examLevelName,
                    MonthName = monthName
                }
            });


        }

        /// <summary>
        /// Create Form fill up 
        /// </summary>
        [HttpPost("CreateFormFillupData"), DisableRequestSizeLimit]
        public async Task<ActionResult<ResponseDto2>> CreateFormFillupData([FromBody] FormFillupModel7 input)
        {
            FormFillupModel4 newSystemInput = new();
            newSystemInput.ExamLevel = input.Input1.ExamLevel;
            newSystemInput.MonthId = input.Input1.MonthId;
            newSystemInput.SessionYear = input.Input1.SessionYear;
            newSystemInput.RegNo = input.Input1.RegNo;
            //hotfix for new System
            List<FormFillupModel29> newSystemLevelPassCheck = await GetLevelWiseDetailsResultForOneStudent(newSystemInput);
            bool is63LevelPassedNewSystem = newSystemLevelPassCheck.Any(i => i.ExamLevel == 63 && i.IsExamLevelPassed == true);
            bool is62LevelPassedNewSystem = newSystemLevelPassCheck.Any(i => i.ExamLevel == 62 && i.IsExamLevelPassed == true);
            bool is61LevelPassedNewSystem = newSystemLevelPassCheck.Any(i => i.ExamLevel == 61 && i.IsExamLevelPassed == true);

            if (input.Input1.PaymentMode == "online")
            {
                OnlinePaymentDetail onlinepaymentdetails = await _context.OnlinePaymentDetails.Where(x => x.ExamLevel == input.Input1.ExamLevel
                                                                                                    && x.MonthId == input.Input1.MonthId && x.SessionYear == input.Input1.SessionYear
                                                                                                    && x.RegNo == input.Input1.RegNo && x.TransactionId == input.Input1.Exfeepayslipno).FirstOrDefaultAsync();

                if (onlinepaymentdetails != null)
                {
                    if (onlinepaymentdetails.Exfeepayslipamt < input.Input1.Exfeepayslipamt)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Online exam payment amount cannot be less than exam fee", //"Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                            Success = false,
                            Payload = null
                        });
                    }

                    if (onlinepaymentdetails.Exfeepayslipamt > input.Input1.Exfeepayslipamt)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Online exam amount cannot be more than exam fee", //"Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                            Success = false,
                            Payload = null
                        });
                    }

                    if (onlinepaymentdetails.Annfeepayslipamt < input.Input1.Annfeepayslipamt)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Online annual payment amount cannot be less than annual fee", //"Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                            Success = false,
                            Payload = null
                        });
                    }

                    if (onlinepaymentdetails.Annfeepayslipamt > input.Input1.Annfeepayslipamt)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Online annual payment amount cannot be more than annual fee", //"Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                            Success = false,
                            Payload = null
                        });
                    }
                }

            }


            if (input.Input1.ExamLevel == 61)
            {
                if (is61LevelPassedNewSystem == true)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                        Success = false,
                        Payload = null
                    });
                }
            }

            else if (input.Input1.ExamLevel == 62)
            {
                if (is62LevelPassedNewSystem == true)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                        Success = false,
                        Payload = null
                    });
                }
            }

            else if (input.Input1.ExamLevel == 63)
            {
                if (is63LevelPassedNewSystem == true)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "Registration number " + input.Input1.RegNo + " has already passed in exam level: " + await _context.Subjects.Where(i => i.SubId == input.Input1.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync(),
                        Success = false,
                        Payload = null
                    });
                }
                //else if (is62LevelPassedNewSystem == false)
                //{
                //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                //    {
                //        Message = "Registration number " + input.Input1.RegNo + " did not pass in exam level: " + await _context.Subjects.Where(i => i.SubId == 62).Select(o => o.SubName).FirstOrDefaultAsync(),
                //        Success = false,
                //        Payload = null
                //    });
                //}
            }

            if (input.Input1.RegNo < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Registration number " + input.Input1.RegNo + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.ExamLevel < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam level " + input.Input1.ExamLevel + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.MonthId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Month id " + input.Input1.MonthId + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.SessionYear < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Session year " + input.Input1.SessionYear + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.ExamcenId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center " + input.Input1.ExamcenId + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            //if (input.Input1.ExamLevel == 61)
            //{
            //    input.Input1.MonthId = 4;
            //}

            //if (input.Input1.FileTrainingAttached == null)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Training certificate is not attached",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            //if (input.Input1.FileFitnessAttached == null)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Fitness certificate is not attached",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            if (input.Input1.FilepathTrainingAttached == null && input.Input1.FilepathFitnessAttached == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Training certificate or Fitness certificate is not attached",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.FilepathAttenAttached == null && input.Input1.AttenAttached != "1")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Attendance certificate is not attached",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.FilepathExfeeuploadPayslip == null && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam fee payment slip is not attached",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Annfeepayslipamt < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Annual fee payment amount can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Exfeepayslipamt == null && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam fee payment amount can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Exfeepayslipamt < 0 && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam fee payment amount can not be negative",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Exfeepayslipdate == null && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam fee payment date can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Exfeepayslipbank == null && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "For exam fee, bank can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Exfeepayslipbr == null && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "For exam fee, branch can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.Input1.Annfeepayslipdate == null)
            {
                input.Input1.Annfeepayslipdate = new DateTime(2012, 12, 12);
            }

            bool regNoFoundInStuReg1 = await _context.StuReg1s.AnyAsync(i => i.RegNo == input.Input1.RegNo);

            if (regNoFoundInStuReg1 == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Registration number " + input.Input1.RegNo + " is not found",
                    Success = false,
                    Payload = null
                });
            }

            bool regNoFoundInTempExamReg = await _context.TempExamRegs.AnyAsync(i => i.RegNo == input.Input1.RegNo && i.ExamLevel == input.Input1.ExamLevel && i.MonthId == input.Input1.MonthId && i.SessionYear == input.Input1.SessionYear && (i.Formsubmitstatus == 1 || i.Formsubmitstatus == -1));

            if (regNoFoundInTempExamReg == true)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Form is already submitted for registration number " + input.Input1.RegNo + " for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool examLevelFound = await _context.Subjects.AnyAsync(k => k.SubId == input.Input1.ExamLevel);

            if (examLevelFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.Input1.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            bool monthFound = await _context.SessionInfos.AnyAsync(k => k.SessionId == input.Input1.MonthId);

            if (monthFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.Input1.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            bool subjectsFound = await _context.Subjects.AnyAsync(k => k.Parent == input.Input1.ExamLevel);

            if (subjectsFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under exam level: " + input.Input1.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            bool examCenterFound = await _context.ExamCentres.AnyAsync(k => k.CenId == input.Input1.ExamcenId);

            if (examCenterFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center found with center id: " + input.Input1.ExamcenId,
                    Success = false,
                    Payload = null
                });
            }

            string examLevelName = await _context.Subjects.Where(b => b.SubId == input.Input1.ExamLevel).Select(g => g.SubName).FirstOrDefaultAsync();
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

            string monthName = await _context.SessionInfos.Where(b => b.SessionId == input.Input1.MonthId).Select(g => g.SessionName).FirstOrDefaultAsync();
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

            if (input.Input1.MonthId == 3)
            {
                monthNameSubstring = "A";
            }

            string sessionYearString = input.Input1.SessionYear.ToString();
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

            int countTempExamRegsForFormNumber = await _context.TempExamRegs.Where(o => o.ExamLevel == input.Input1.ExamLevel && o.MonthId == input.Input1.MonthId && o.SessionYear == input.Input1.SessionYear).CountAsync();
            int formNumberSerial = countTempExamRegsForFormNumber > 0 ? countTempExamRegsForFormNumber : 0;
            string generatedFormNumber = GenerateFormNumber(examLevelSubstring, monthNameSubstring, sessionYearSubstring, (formNumberSerial + 1)); // examLevelSubstring + monthNameSubstring + sessionYearSubstring + "-" + (formNumberSerial + 1).ToString();
            System.Diagnostics.Debug.WriteLine("Here is final form number: " + generatedFormNumber);
            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.Input1.ExamLevel).ToListAsync();
            List<int> subIdCollection = await _context.Subjects.Where(i => i.Parent == input.Input1.ExamLevel).Select(l => l.SubId).ToListAsync();

            decimal paymentCount = 0;

            foreach (var item in input.CoachingClassSubjects)
            {
                if (!subIdCollection.Contains(item.SubId))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Subject id " + item.SubId + " can not be found under exam level: " + input.Input1.ExamLevel,
                        Success = false,
                        Payload = null
                    });
                }
            }

            bool studentHasAppearingIn = input.AppearingInSubjects.Any(i => i.ToBeAppeared == "true");
            if (studentHasAppearingIn == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Student has not selected any appearing in",
                    Success = false,
                    Payload = null
                });
            }

            // ex

            var exdata = await (from er in _context.ExamRegs
                                from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                where ((er.ExamLevel == 61 || er.ExamLevel == 41) && er.RegNo == input.Input1.RegNo)
                                orderby er.RegNo, es.SubId

                                select new
                                {
                                    RegNo = er.RegNo,
                                    //ExamRollno = x.ExamRollno,
                                    //SubId = b.SubId,
                                    //BarCode = b.BarCode,
                                    ExempSub = es.SubId
                                }).ToListAsync();

            //var exdata = await (from er in _context.ExamRegs
            //                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
            //                    where (er.ExamLevel == 61 && er.MonthId == input.Input1.MonthId && er.SessionYear == input.Input1.SessionYear && er.RegNo == input.Input1.RegNo && es.RegNo == input.Input1.RegNo)
            //                    orderby er.RegNo, es.SubId

            //                    select new
            //                    {
            //                        RegNo = er.RegNo,
            //                        //ExamRollno = x.ExamRollno,
            //                        //SubId = b.SubId,
            //                        //BarCode = b.BarCode,
            //                        ExempSub = es.SubId
            //                    }).ToListAsync();

            var exdata62checkfor63 = await (from er in _context.ExamRegs
                                            from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                            where ((er.ExamLevel == 62 || er.ExamLevel == 42) && er.RegNo == input.Input1.RegNo)
                                            orderby er.RegNo, es.SubId

                                            select new
                                            {
                                                RegNo = er.RegNo,
                                                //ExamRollno = x.ExamRollno,
                                                //SubId = b.SubId,
                                                //BarCode = b.BarCode,
                                                ExempSub = es.SubId
                                            }).ToListAsync();

            //var exdata62checkfor63 = await (from er in _context.ExamRegs
            //                                from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
            //                                where (er.ExamLevel == 62 && er.MonthId == input.Input1.MonthId && er.SessionYear == input.Input1.SessionYear && er.RegNo == input.Input1.RegNo && es.RegNo == input.Input1.RegNo)
            //                                orderby er.RegNo, es.SubId

            //                                select new
            //                                {
            //                                    RegNo = er.RegNo,
            //                                    //ExamRollno = x.ExamRollno,
            //                                    //SubId = b.SubId,
            //                                    //BarCode = b.BarCode,
            //                                    ExempSub = es.SubId
            //                                }).ToListAsync();

            //get all from vwMarksFinals
            List<VwMarksfinal> vwMarksfinalsfor61_62 = await _context.VwMarksfinals
                                                             .Where(i => i.RegNo == input.Input1.RegNo && (i.ExamLevel == 1 || i.ExamLevel == 2 || i.ExamLevel == 3) && (i.Grade == "A" || i.Grade == "B"))
                                                             .ToListAsync();


            List<FormFillupModel6> exdata2 = await (from ba in _context.BarcodeAllots
                                                    from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                    where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B") && ba.RegNo == input.Input1.RegNo)
                                                    select new FormFillupModel6
                                                    {
                                                        RegNo = ba.RegNo
                                                    }).ToListAsync();

            List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots
                                                    from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                    where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B") && ba.RegNo == input.Input1.RegNo)
                                                    select new FormFillupModel6
                                                    {
                                                        RegNo = ba.RegNo
                                                    }).ToListAsync();

            List<int?> validRegNoCollection = _context.ConversionCourseMarks.Where(i => i.ExamLevel == 42 && i.SubId == 422).Select(j => j.RegNo).ToList();
            var exresultof62for63check = (from ba in _context.BarcodeAllots
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

            // ep

            var abc = await (from b in _context.BarcodeAllots
                             join m in _context.MarksAllots
                             on b.SessionYear equals m.SessionYear
                             where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.Input1.SessionYear || (b.SessionYear == input.Input1.SessionYear && b.MonthId < input.Input1.MonthId)) && (b.ExamLevel == 41 || b.ExamLevel == 61) && (m.Grade == "A" || m.Grade == "B") && b.RegNo == input.Input1.RegNo
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

            var abc2 = (from b in _context.BarcodeAllots
                        join m in _context.MarksAllots
                        on b.SessionYear equals m.SessionYear
                        where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.Input1.SessionYear || (b.SessionYear == input.Input1.SessionYear && b.MonthId < input.Input1.MonthId)) && (b.ExamLevel == 42 || b.ExamLevel == 62) && (m.Grade == "A" || m.Grade == "B") && b.RegNo == input.Input1.RegNo
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

            List<VwMarksfinal> ViewMarksfor61 = await _context.VwMarksfinals.Where(i => i.RegNo == input.Input1.RegNo && (i.ExamLevel == 61 || i.ExamLevel == 41) && (i.Grade == "A" || i.Grade == "B"))
                                                 .ToListAsync();
            List<VwMarksfinal> ViewMarksfor62 = await _context.VwMarksfinals.Where(i => i.RegNo == input.Input1.RegNo && (i.ExamLevel == 62 || i.ExamLevel == 42) && (i.Grade == "A" || i.Grade == "B"))
                                                             .ToListAsync();

            foreach (var item in input.AppearingInSubjects)
            {
                if (!subIdCollection.Contains(item.SubId))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Subject id " + item.SubId + " can not be found under exam level: " + input.Input1.ExamLevel,
                        Success = false,
                        Payload = null
                    });
                }

                bool isFoundInCoachingClassSubjects = input.CoachingClassSubjects.Any(o => o.SubId == item.SubId);

                if (!isFoundInCoachingClassSubjects)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "(" + subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefault() + ") Subject id " + item.SubId + " can not be found under coaching class subjects",
                        Success = false,
                        Payload = null
                    });
                }

                bool isCheckedInCoachingClassSubjects = input.CoachingClassSubjects.Any(o => o.SubId == item.SubId && o.CoachingClassAttended == true);
                bool isCheckedInAppearingInSubjects = input.AppearingInSubjects.Any(o => o.SubId == item.SubId && o.ToBeAppeared == "true");

                if (isCheckedInAppearingInSubjects && !isCheckedInCoachingClassSubjects)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "(" + subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefault() + ") Subject id " + item.SubId + " was not selected under coaching class subjects",
                        Success = false,
                        Payload = null
                    });
                }

                if (item.ToBeAppeared == "true")
                {
                    decimal? getAmountForSubject = await _context.ExamFees.Where(i => i.ExamLevel == input.Input1.ExamLevel && i.MonthId == input.Input1.MonthId && i.SessionYear == input.Input1.SessionYear && i.SubId == item.SubId).Select(o => o.Amount).FirstOrDefaultAsync();

                    paymentCount += (getAmountForSubject ?? 0);
                }

                if (input.Input1.ExamLevel == 62)
                {
                    if (item.ToBeAppeared == "true")
                    {
                        if (item.SubId == 621)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 611 || o.ExempSub == 411) || ViewMarksfor61.Any(o => (o.SubId == 611 || o.SubId == 411) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B"));

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 611).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 611)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 622)
                        {
                            bool test1 = exdata.Any(o => o.ExempSub == 612 || o.ExempSub == 412);
                            bool test2 = await _context.SetExmpMous.AnyAsync(i => i.RegNo == input.Input1.RegNo);
                            bool test3 = await _context.ConversionCourseMarks.AnyAsync(i => i.RegNo == input.Input1.RegNo);
                            bool test4 = ViewMarksfor61.Any(o => (o.SubId == 612 || o.SubId == 412) && o.RegNo == input.Input1.RegNo);
                            bool test5 = exdata2.Any(o => o.RegNo == input.Input1.RegNo);
                            bool test6 = vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B"));


                            bool isFound = ((test1 && (test2 || test3)) || test4 || test5 || test6);  //(exdata.Any(o => o.ExempSub == 612) && (await _context.SetExmpMous.AnyAsync(i => i.RegNo == input.Input1.RegNo) || await _context.ConversionCourseMarks.AnyAsync(i => i.RegNo == input.Input1.RegNo))) || abc.Any(o => o.EPSubId == 612) || exdata2.Any(o => o.RegNo == input.Input1.RegNo);



                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 612).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 612)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 623)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 613 || o.ExempSub == 413) || ViewMarksfor61.Any(o => (o.SubId == 613 || o.SubId == 413) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && o.SubId == 34 && (o.Grade == "A" || o.Grade == "B"));

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 613).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 613)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 624)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 613 || o.ExempSub == 413) || ViewMarksfor61.Any(o => (o.SubId == 613 || o.SubId == 413) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && o.SubId == 34 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 613).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 613)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 625)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 615 || o.ExempSub == 415) || ViewMarksfor61.Any(o => (o.SubId == 615 || o.SubId == 415) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 615).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 615)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 626)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 616 || o.ExempSub == 416) || ViewMarksfor61.Any(o => (o.SubId == 616 || o.SubId == 416) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 616).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 616)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                        else if (item.SubId == 627)
                        {
                            bool isFound = exdata.Any(o => o.ExempSub == 617 || o.ExempSub == 417) || ViewMarksfor61.Any(o => (o.SubId == 617 || o.SubId == 417) && o.RegNo == input.Input1.RegNo) || exdata3.Any(o => o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 617).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 617)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }
                    }
                }

                else if (input.Input1.ExamLevel == 63)
                {
                    if (item.ToBeAppeared == "true")
                    {
                        // 61 level pass block
                        FormFillupModel4 sys = new FormFillupModel4();

                        sys.RegNo = input.Input1.RegNo;
                        sys.MonthId = input.Input1.MonthId;
                        sys.SessionYear = input.Input1.SessionYear;
                        //sys.ExamLevel = 61;

                        var check61for63 = await GetLevelWiseDetailsResultForOneStudent(sys);

                        var quickIsPassed = false;
                        int? quickExamlevel = null;

                        foreach (var items in check61for63)
                        {

                            var elName = _context.Subjects.Where(g => g.SubId == items.ExamLevel).Select(x => x.SubName).FirstOrDefault();

                            quickExamlevel = items.ExamLevel;
                            quickIsPassed = items.IsExamLevelPassed;

                            if (items.IsExamLevelPassed == false && items.ExamLevel == 61)
                            {

                                //System.Diagnostics.Debug.WriteLine("Barua" + items.ExamLevel);

                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "RegNo: " + input.Input1.RegNo + " needs to pass Level: " + elName,
                                    Success = false,
                                    Payload = items
                                });
                            }


                        }
                        // 61 level pass block

                        if (item.SubId == 631)
                        {
                            bool isFound = exdata62checkfor63.Any(o => o.ExempSub == 621 || o.ExempSub == 421) || ViewMarksfor62.Any(o => (o.SubId == 621 || o.SubId == 421) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 621).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 621)",
                                    Success = false,
                                    Payload = null
                                });
                            }


                            bool isFound2 = exdata62checkfor63.Any(o => o.ExempSub == 622 || o.ExempSub == 422) || ViewMarksfor62.Any(o => (o.SubId == 622 || o.SubId == 422) && o.RegNo == input.Input1.RegNo) || exresultof62for63check.Any(o => o.RegNo == input.Input1.RegNo && o.SubId == 622) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound2 == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 622).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 622)",
                                    Success = false,
                                    Payload = null
                                });
                            }

                        }

                        if (item.SubId == 632)
                        {
                            bool isFound3 = exdata62checkfor63.Any(o => o.ExempSub == 623 || o.ExempSub == 423) || ViewMarksfor62.Any(o => (o.SubId == 623 || o.SubId == 423) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.SubId == 35 && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound3 == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 623).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 623)",
                                    Success = false,
                                    Payload = null
                                });
                            }

                            bool isFound4 = exdata62checkfor63.Any(o => o.ExempSub == 624 || o.ExempSub == 424) || ViewMarksfor62.Any(o => (o.SubId == 624 || o.SubId == 424) && o.RegNo == input.Input1.RegNo) || vwMarksfinalsfor61_62.Any(o => o.RegNo == input.Input1.RegNo && o.SubId == 34 && o.ExamLevel == 3 && (o.Grade == "A" || o.Grade == "B")); ;

                            if (isFound4 == false)
                            {
                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = "The student didn't pass in subject: " + await _context.Subjects.Where(l => l.SubId == 624).Select(o => o.SubName).FirstOrDefaultAsync(),// + " (subject id: 624)",
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }

                        if (item.SubId == 633)
                        {
                            //if ((item.SubId == 631 && item.ToBeAppeared == "true") || )
                            var checkSub631 = false;
                            var checkSub632 = false;

                            foreach (var check in input.AppearingInSubjects)
                            {
                                //System.Diagnostics.Debug.WriteLine("BARUALOOP");

                                if (check.SubId == 631 && check.ToBeAppeared == "false")
                                {
                                    checkSub631 = true;
                                }
                                if (check.SubId == 632 && check.ToBeAppeared == "false")
                                {
                                    checkSub632 = true;
                                }

                                //IF NEEDED TO STOP SOMEONE ATTAMPING 633 ALONE IF PL DIDNOT FULLY PASSED

                                //if ((item.SubId == 631 && item.ToBeAppeared == "true") && (item.SubId == 632 && item.ToBeAppeared == "true") && quickIsPassed == false && quickExamlevel == 62)
                                //{

                                //    var elName = _context.Subjects.Where(g => g.SubId == quickExamlevel).Select(x => x.SubName).FirstOrDefault();

                                //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                //    {
                                //        Message = "RegNo: " + input.Input1.RegNo + " needs to pass Level: " + elName,
                                //        Success = false,
                                //        Payload = null
                                //    });
                                //}

                                //IF NEEDED TO STOP SOMEONE ATTAMPING 633 ALONE IF PL DIDNOT FULLY PASSED
                            }

                            if (checkSub631 == true && checkSub632 == true)
                            {
                                var caseStudy = await _context.Subjects.Where(l => l.SubId == 633).Select(o => o.SubName).FirstOrDefaultAsync();
                                var corporateReporting = await _context.Subjects.Where(l => l.SubId == 631).Select(o => o.SubName).FirstOrDefaultAsync();
                                var strategicBusinessManagement = await _context.Subjects.Where(l => l.SubId == 632).Select(o => o.SubName).FirstOrDefaultAsync();

                                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                                {
                                    Message = caseStudy + " Can not be attempted alone. Please select " + corporateReporting + " or " + strategicBusinessManagement,
                                    Success = false,
                                    Payload = null
                                });
                            }
                        }


                        var checkPas62 = Check63Fully(input).Result;

                        if (checkPas62 == true)
                        {
                            var elName = _context.Subjects.Where(g => g.SubId == 62).Select(x => x.SubName).FirstOrDefault();

                            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                            {
                                Message = "RegNo: " + input.Input1.RegNo + " needs to pass Level: " + elName,
                                Success = false,
                                Payload = null
                            });
                        }

                    }
                }

            }

            if (input.Input1.Exfeepayslipamt < paymentCount && input.Input1.PaymentMode.ToLower() == "offline")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam fee payment amount can not be less than total payment amount " + paymentCount + " for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            bool isRowCount1Valid = false;

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                //System.Diagnostics.Debug.WriteLine("here is maxref: " + Environment.NewLine);
                int countTempExamRegs = await _context.TempExamRegs.CountAsync();
                //System.Diagnostics.Debug.WriteLine("here is count: " + countTempExamRegs);
                int maxRef = countTempExamRegs > 0 ? await _context.TempExamRegs.MaxAsync(k => k.Ref) : 0;
                //System.Diagnostics.Debug.WriteLine("here is maxref: " + maxRef);
                input.Input1.Ref = maxRef + 1;
                input.Input1.FormNo = generatedFormNumber;
                input.Input1.AttenAttached = (input.Input1.FilepathAttenAttached == null) ? "0" : "1";
                input.Input1.FitnessAttached = (input.Input1.FilepathFitnessAttached == null) ? "0" : "1";
                input.Input1.TrainingAttached = (input.Input1.FilepathTrainingAttached == null) ? "0" : "1";
                input.Input1.Formsubmitstatus = input.Input1.PaymentMode.ToLower() == "online" ? -1 : 1;
                //input.Input1.Exfeepayslipbank = input.Input1.Exfeepayslipbank;
                //input.Input1.Exfeepayslipbr = input.Input1.Exfeepayslipbr;
                input.Input1.Fapprove = 0;
                //System.Diagnostics.Debug.WriteLine("ok it it: " + input.Input1.LastAppearedExamlevel);
                //System.Diagnostics.Debug.WriteLine("ok it it: " + input.Input1.LastAppearedMonthid);
                //System.Diagnostics.Debug.WriteLine("ok it it: " + input.Input1.LastAppearedRollno);
                //System.Diagnostics.Debug.WriteLine("ok it it: " + input.Input1.LastAppearedYear);
                _context.TempExamRegs.Add(input.Input1);

                int rowCount1 = await _context.SaveChangesAsync();

                isRowCount1Valid = rowCount1 > 0;

                bool studentHasExemption = input.AppearingInSubjects.Any(i => i.ToBeAppeared == "ex");
                if (studentHasExemption)
                {
                    foreach (var item in input.AppearingInSubjects.Where(l => l.ToBeAppeared == "ex").ToList())
                    {
                        TempExemptedSub tempExemptedSub = new();
                        tempExemptedSub.RegNo = input.Input1.RegNo;
                        tempExemptedSub.ExamLevel = input.Input1.ExamLevel;
                        tempExemptedSub.SubId = item.SubId;
                        tempExemptedSub.Ref = input.Input1.Ref;

                        _context.TempExemptedSubs.Add(tempExemptedSub);
                        await _context.SaveChangesAsync();
                    }
                }

                bool studentHasEarlierPass = input.AppearingInSubjects.Any(i => i.ToBeAppeared == "ep");
                if (studentHasEarlierPass)
                {
                    if (input.Input1.ExamLevel == 61)
                    {
                        TempEarlierPassed61 tempEarlierPassed61 = new();
                        tempEarlierPassed61.RegNo = input.Input1.RegNo;
                        tempEarlierPassed61.Ref = input.Input1.Ref;

                        foreach (var item in input.AppearingInSubjects.Where(l => l.ToBeAppeared == "ep").ToList())
                        {
                            if (input.Input1.ExamLevel == 61)
                            {
                                if (item.SubId == 611)
                                {
                                    tempEarlierPassed61.Ep611 = 1;
                                }

                                else if (item.SubId == 612)
                                {
                                    tempEarlierPassed61.Ep612 = 1;
                                }

                                else if (item.SubId == 613)
                                {
                                    tempEarlierPassed61.Ep613 = 1;
                                }

                                else if (item.SubId == 614)
                                {
                                    tempEarlierPassed61.Ep614 = 1;
                                }

                                else if (item.SubId == 615)
                                {
                                    tempEarlierPassed61.Ep615 = 1;
                                }

                                else if (item.SubId == 616)
                                {
                                    tempEarlierPassed61.Ep616 = 1;
                                }

                                else if (item.SubId == 617)
                                {
                                    tempEarlierPassed61.Ep617 = 1;
                                }
                            }

                        }

                        _context.TempEarlierPassed61s.Add(tempEarlierPassed61);
                        await _context.SaveChangesAsync();
                    }

                    else if (input.Input1.ExamLevel == 62)
                    {
                        TempEarlierPassed62 tempEarlierPassed62 = new();
                        tempEarlierPassed62.RegNo = input.Input1.RegNo;
                        tempEarlierPassed62.Ref = input.Input1.Ref;

                        foreach (var item in input.AppearingInSubjects.Where(l => l.ToBeAppeared == "ep").ToList())
                        {
                            if (input.Input1.ExamLevel == 62)
                            {
                                if (item.SubId == 621)
                                {
                                    tempEarlierPassed62.Ep621 = 1;
                                }

                                else if (item.SubId == 622)
                                {
                                    tempEarlierPassed62.Ep622 = 1;
                                }

                                else if (item.SubId == 623)
                                {
                                    tempEarlierPassed62.Ep623 = 1;
                                }

                                else if (item.SubId == 624)
                                {
                                    tempEarlierPassed62.Ep624 = 1;
                                }

                                else if (item.SubId == 625)
                                {
                                    tempEarlierPassed62.Ep625 = 1;
                                }

                                else if (item.SubId == 626)
                                {
                                    tempEarlierPassed62.Ep626 = 1;
                                }

                                else if (item.SubId == 627)
                                {
                                    tempEarlierPassed62.Ep627 = 1;
                                }
                            }

                        }

                        _context.TempEarlierPassed62s.Add(tempEarlierPassed62);
                        await _context.SaveChangesAsync();
                    }

                    else if (input.Input1.ExamLevel == 63)
                    {
                        TempEarlierPassed63 tempEarlierPassed63 = new();
                        tempEarlierPassed63.RegNo = input.Input1.RegNo;
                        tempEarlierPassed63.Ref = input.Input1.Ref;

                        foreach (var item in input.AppearingInSubjects.Where(l => l.ToBeAppeared == "ep").ToList())
                        {
                            if (input.Input1.ExamLevel == 63)
                            {
                                if (item.SubId == 631)
                                {
                                    tempEarlierPassed63.Ep631 = 1;
                                }

                                else if (item.SubId == 632)
                                {
                                    tempEarlierPassed63.Ep632 = 1;
                                }

                                else if (item.SubId == 633)
                                {
                                    tempEarlierPassed63.Ep633 = 1;
                                }
                            }

                        }

                        _context.TempEarlierPassed63s.Add(tempEarlierPassed63);
                        await _context.SaveChangesAsync();
                    }
                }

                foreach (var item in input.AppearingInSubjects.Where(l => l.ToBeAppeared == "true").ToList())
                {
                    TempRegSubject tempRegSubject = new();
                    tempRegSubject.RefNo = input.Input1.Ref;
                    tempRegSubject.EntryType = 1;
                    tempRegSubject.SubId = item.SubId;

                    _context.TempRegSubjects.Add(tempRegSubject);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in input.CoachingClassSubjects.Where(l => l.CoachingClassAttended == true).ToList())
                {
                    TempClassAttendance tempClassAttendance = new();
                    tempClassAttendance.RefNo = input.Input1.Ref;
                    tempClassAttendance.ExamLevel = input.Input1.ExamLevel;
                    tempClassAttendance.RegNo = input.Input1.RegNo;
                    tempClassAttendance.SubId = item.SubId;

                    _context.TempClassAttendances.Add(tempClassAttendance);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student Form filup info creation failed for registration number: " + input.Input1.RegNo + ". Something went wrong, Please try again later.",
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
            string allAppliedSubjectNames = "";
            foreach (var item in input.AppearingInSubjects)
            {
                if (item.ToBeAppeared == "true")
                {
                    allAppliedSubjectNames += "<br>" + await _context.Subjects.Where(i => i.SubId == item.SubId).Select(o => o.SubName).FirstOrDefaultAsync();
                }
                else
                {
                    continue;
                }
            }

            if (isRowCount1Valid)
            {
                if (input.Input1.PaymentMode.ToLower() == "offline")
                {
                    StuReg1 stuReg1 = await _context.StuReg1s.Where(i => i.RegNo == input.Input1.RegNo).FirstOrDefaultAsync();
                    string messageForEmail = $@"
                        <p>
                        <h4>Dear <code>{stuReg1.Name} (Registration No.: {input.Input1.RegNo}),</code></h4> 
                        <br>  
                        Your Examination Application Form has been received successfully for {examLevelName}, {monthName}, {input.Input1.SessionYear} for the subjects:
                        <br>
                        {allAppliedSubjectNames}
                        <br>
                        <br>
                        Thanks & Regards,
                        <br>
                        ICAB Exam Division
                        <br>
                        <br>
                        * This is an auto generated email.
                        </p>
                        ";
                    if (stuReg1.Email != null)
                    {
                        _emailService.Send(
                             to: stuReg1.Email,
                             subject: "Submission of Examination Application Form",
                             html: $@"{messageForEmail}"
                        );
                    }
                }
            }

            return StatusCode(isRowCount1Valid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCount1Valid ? "Form filup info created for registration number: " + input.Input1.RegNo + " (ref no: " + input.Input1.Ref + ")" : "Form fillup info creation failed. Something went wrong. Please try again later",
                Success = isRowCount1Valid,
                Payload = null
            });
        }

        /// <summary>
        /// Get Form Fillup Data After Submission 
        /// </summary>
        [HttpPost("GetFormFillupDataAfterSubmission")]
        public async Task<ActionResult<ResponseDto2>> GetFormFillupDataAfterSubmission([FromBody] FormFillupModel11 input)
        {
            if (input.Ref < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            bool refNoFoundInTempExamReg = await _context.TempExamRegs.AnyAsync(i => i.Ref == input.Ref);

            if (refNoFoundInTempExamReg == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " does not exists in temporary exam registration",
                    Success = false,
                    Payload = null
                });
            }

            decimal? isFormFillupApproved = await _context.TempExamRegs.Where(i => i.Ref == input.Ref).Select(o => o.Fapprove).FirstOrDefaultAsync();

            if (isFormFillupApproved == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Approval status for reference number " + input.Ref + " is undefined in temporary exam registration",
                    Success = false,
                    Payload = null
                });
            }

            if ((int)isFormFillupApproved == 0)
            {
                FormFillupModel7 output = new();

                output.Input1 = await _context.TempExamRegs.Where(i => i.Ref == input.Ref).FirstOrDefaultAsync();

                if (output.Input1 == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Temporary exam registration info not found for reference number " + input.Ref,
                        Success = false,
                        Payload = null
                    });
                }

                if (output.Input1.Ref == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Reference number form temporary exam registration info is null",
                        Success = false,
                        Payload = null
                    });
                }

                output.CoachingClassSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                      select new FormFillupModel8
                                                      {
                                                          SubId = sub.SubId,
                                                          SubName = sub.SubName,
                                                          CoachingClassAttended = false
                                                      }).ToListAsync();

                if (output.CoachingClassSubjects == null || output.CoachingClassSubjects.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for coaching class subjects",
                        Success = false,
                        Payload = null
                    });
                }

                output.AppearingInSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                    select new FormFillupModel5
                                                    {
                                                        SubId = sub.SubId,
                                                        SubName = sub.SubName,
                                                        ToBeAppeared = "false"
                                                    }).ToListAsync();

                if (output.AppearingInSubjects == null || output.AppearingInSubjects.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for appearing in subjects",
                        Success = false,
                        Payload = null
                    });
                }

                List<int?> classAttendanceSubjectIdCollection = await _context.TempClassAttendances.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.CoachingClassSubjects.Where(k => classAttendanceSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.CoachingClassAttended = true;
                }

                List<int> regSubjectIdCollection = await _context.TempRegSubjects.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.AppearingInSubjects.Where(k => regSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.ToBeAppeared = "true";
                }

                if (output.Input1.ExamLevel == 61)
                {
                    TempEarlierPassed61 tempEarlierPassed61 = await _context.TempEarlierPassed61s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    if (tempEarlierPassed61 != null)
                    {
                        foreach (var item in output.AppearingInSubjects)
                        {
                            if (item.SubId == 611 && tempEarlierPassed61.Ep611 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 612 && tempEarlierPassed61.Ep612 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 613 && tempEarlierPassed61.Ep613 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 614 && tempEarlierPassed61.Ep614 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 615 && tempEarlierPassed61.Ep615 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 616 && tempEarlierPassed61.Ep616 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 617 && tempEarlierPassed61.Ep617 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                        }
                    }
                }
                else if (output.Input1.ExamLevel == 62)
                {
                    TempEarlierPassed62 tempEarlierPassed62 = await _context.TempEarlierPassed62s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    if (tempEarlierPassed62 != null)
                    {
                        foreach (var item in output.AppearingInSubjects)
                        {
                            if (item.SubId == 621 && tempEarlierPassed62.Ep621 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 622 && tempEarlierPassed62.Ep622 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 623 && tempEarlierPassed62.Ep623 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 624 && tempEarlierPassed62.Ep624 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 625 && tempEarlierPassed62.Ep625 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 626 && tempEarlierPassed62.Ep626 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 627 && tempEarlierPassed62.Ep627 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                        }
                    }
                }
                else if (output.Input1.ExamLevel == 63)
                {
                    TempEarlierPassed63 tempEarlierPassed63 = await _context.TempEarlierPassed63s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    if (tempEarlierPassed63 != null)
                    {
                        foreach (var item in output.AppearingInSubjects)
                        {
                            if (item.SubId == 631 && tempEarlierPassed63.Ep631 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 632 && tempEarlierPassed63.Ep632 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                            else if (item.SubId == 633 && tempEarlierPassed63.Ep633 == 1)
                            {
                                item.ToBeAppeared = "ep";
                            }
                        }
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "This exam level: " + output.Input1.ExamLevel + " is not allowed",
                        Success = false,
                        Payload = null
                    });
                }

                List<int?> exemptedSubjectIdCollection = await _context.TempExemptedSubs.Where(o => o.Ref == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.AppearingInSubjects.Where(k => exemptedSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.ToBeAppeared = "ex";
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data before approval for registration number : " + output.Input1.RegNo + " (ref: " + output.Input1.Ref + ")",
                    Success = true,
                    Payload = output
                });
            }

            else if ((int)isFormFillupApproved == 1)
            {
                FormFillupModel12 output = new();

                ExamReg examRegData = await _context.ExamRegs.Where(i => i.Ref == input.Ref).FirstOrDefaultAsync();

                if (examRegData == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Exam registration info not found for reference number " + input.Ref,
                        Success = false,
                        Payload = null
                    });
                }

                if (examRegData.Ref == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Reference number form exam registration info is null",
                        Success = false,
                        Payload = null
                    });
                }

                output.Input1.Ref = examRegData.Ref;
                output.Input1.FormNo = examRegData.FormNo;
                output.Input1.FillupDate = examRegData.FillupDate;
                output.Input1.ExamRollno = examRegData.ExamRollno;
                output.Input1.RegNo = examRegData.RegNo;
                output.Input1.ExamLevel = examRegData.ExamLevel;
                output.Input1.MonthId = examRegData.MonthId;
                output.Input1.SessionYear = examRegData.SessionYear;
                output.Input1.ExamcenId = examRegData.ExamcenId;
                output.Input1.TrainingSt = examRegData.TrainingSt;
                output.Input1.TrainingEnd = examRegData.TrainingEnd;
                output.Input1.LastAppearedMonthid = examRegData.LastAppearedMonthid;
                output.Input1.LastAppearedYear = examRegData.LastAppearedYear;
                output.Input1.LastAppearedRollno = examRegData.LastAppearedRollno;
                output.Input1.LastAppearedExamlevel = examRegData.LastAppearedExamlevel;
                output.Input1.EntryType = examRegData.EntryType;
                output.Input1.AttenAttached = examRegData.AttenAttached;
                output.Input1.TrainingAttached = examRegData.TrainingAttached;
                output.Input1.Validity = examRegData.Validity;
                output.Input1.ReasonInvalid = examRegData.ReasonInvalid;
                output.Input1.Entryuser = examRegData.Entryuser;
                output.Input1.FitnessAttached = examRegData.FitnessAttached;
                output.Input1.StudType = examRegData.StudType;
                output.Input1.FilepathAttenAttached = examRegData.FilepathAttenAttached;
                output.Input1.FilepathFitnessAttached = examRegData.FilepathFitnessAttached;
                output.Input1.FilepathTrainingAttached = examRegData.FilepathTrainingAttached;
                output.Input1.FilepathExfeeuploadPayslip = examRegData.FilepathExfeeuploadPayslip;
                output.Input1.FilepathAnnfeeuploadPayslip = examRegData.FilepathAnnfeeuploadPayslip;
                output.Input1.CcEnrno = examRegData.CcEnrno;
                output.Input1.CcSession = examRegData.CcSession;
                output.Input1.CcYear = examRegData.CcYear;


                output.CoachingClassSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                      select new FormFillupModel8
                                                      {
                                                          SubId = sub.SubId,
                                                          SubName = sub.SubName,
                                                          CoachingClassAttended = false
                                                      }).ToListAsync();

                if (output.CoachingClassSubjects == null || output.CoachingClassSubjects.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for coaching class subjects",
                        Success = false,
                        Payload = null
                    });
                }

                output.AppearingInSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                    select new FormFillupModel5
                                                    {
                                                        SubId = sub.SubId,
                                                        SubName = sub.SubName,
                                                        ToBeAppeared = "false"
                                                    }).ToListAsync();

                if (output.AppearingInSubjects == null || output.AppearingInSubjects.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for appearing in subjects",
                        Success = false,
                        Payload = null
                    });
                }

                List<int?> classAttendanceSubjectIdCollection = await _context.ClassAttendances.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.CoachingClassSubjects.Where(k => classAttendanceSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.CoachingClassAttended = true;
                }

                List<int> regSubjectIdCollection = await _context.RegSubjects.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.AppearingInSubjects.Where(k => regSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.ToBeAppeared = "true";
                }

                if (output.Input1.ExamLevel == 61)
                {
                    EarlierPassed61 tempEarlierPassed61 = await _context.EarlierPassed61s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 611 && tempEarlierPassed61.Ep611 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 612 && tempEarlierPassed61.Ep612 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 613 && tempEarlierPassed61.Ep613 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 614 && tempEarlierPassed61.Ep614 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 615 && tempEarlierPassed61.Ep615 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 616 && tempEarlierPassed61.Ep616 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 617 && tempEarlierPassed61.Ep617 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
                else if (output.Input1.ExamLevel == 62)
                {
                    EarlierPassed62 tempEarlierPassed62 = await _context.EarlierPassed62s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 621 && tempEarlierPassed62.Ep621 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 622 && tempEarlierPassed62.Ep622 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 623 && tempEarlierPassed62.Ep623 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 624 && tempEarlierPassed62.Ep624 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 625 && tempEarlierPassed62.Ep625 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 626 && tempEarlierPassed62.Ep626 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 627 && tempEarlierPassed62.Ep627 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
                else if (output.Input1.ExamLevel == 63)
                {
                    EarlierPassed63 tempEarlierPassed63 = await _context.EarlierPassed63s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();

                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 631 && tempEarlierPassed63.Ep631 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 632 && tempEarlierPassed63.Ep632 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 633 && tempEarlierPassed63.Ep633 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "This exam level: " + output.Input1.ExamLevel + " is not allowed",
                        Success = false,
                        Payload = null
                    });
                }

                List<int?> exemptedSubjectIdCollection = await _context.ExemptedSubs.Where(o => o.Ref == input.Ref).Select(l => l.SubId).ToListAsync();

                foreach (var item in output.AppearingInSubjects.Where(k => exemptedSubjectIdCollection.Contains(k.SubId)).ToList())
                {
                    item.ToBeAppeared = "ex";
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Form fillup data after approval for registration number : " + output.Input1.RegNo + " (ref: " + output.Input1.Ref + ")",
                    Success = true,
                    Payload = output
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = "Form fillup info fetch failed. Something went wrong. Please try again later",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Get Form Fillup Data After Approval 
        /// </summary>
        [HttpPost("GetFormFillupDataAfterApproval")]
        public async Task<ActionResult<ResponseDto2>> GetFormFillupDataAfterApproval([FromBody] FormFillupModel11 input)
        {
            if (input.Ref < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            bool refNoFoundInTempExamReg = await _context.ExamRegs.AnyAsync(i => i.Ref == input.Ref);

            if (refNoFoundInTempExamReg == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " does not exists in exam registration",
                    Success = false,
                    Payload = null
                });
            }

            FormFillupModel12 output = new();

            ExamReg examRegData = await _context.ExamRegs.Where(i => i.Ref == input.Ref).FirstOrDefaultAsync();

            if (examRegData == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam registration info not found for reference number " + input.Ref,
                    Success = false,
                    Payload = null
                });
            }

            if (examRegData.Ref == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number form exam registration info is null",
                    Success = false,
                    Payload = null
                });
            }

            output.Input1.Ref = examRegData.Ref;
            output.Input1.FormNo = examRegData.FormNo;
            output.Input1.FillupDate = examRegData.FillupDate;
            output.Input1.ExamRollno = examRegData.ExamRollno;
            output.Input1.RegNo = examRegData.RegNo;
            output.Input1.ExamLevel = examRegData.ExamLevel;
            output.Input1.MonthId = examRegData.MonthId;
            output.Input1.SessionYear = examRegData.SessionYear;
            output.Input1.ExamcenId = examRegData.ExamcenId;
            output.Input1.TrainingSt = examRegData.TrainingSt;
            output.Input1.TrainingEnd = examRegData.TrainingEnd;
            output.Input1.LastAppearedMonthid = examRegData.LastAppearedMonthid;
            output.Input1.LastAppearedYear = examRegData.LastAppearedYear;
            output.Input1.LastAppearedRollno = examRegData.LastAppearedRollno;
            output.Input1.LastAppearedExamlevel = examRegData.LastAppearedExamlevel;
            output.Input1.EntryType = examRegData.EntryType;
            output.Input1.AttenAttached = examRegData.AttenAttached;
            output.Input1.TrainingAttached = examRegData.TrainingAttached;
            output.Input1.Validity = examRegData.Validity;
            output.Input1.ReasonInvalid = examRegData.ReasonInvalid;
            output.Input1.Entryuser = examRegData.Entryuser;
            output.Input1.FitnessAttached = examRegData.FitnessAttached;
            output.Input1.StudType = examRegData.StudType;
            output.Input1.FilepathAttenAttached = examRegData.FilepathAttenAttached;
            output.Input1.FilepathFitnessAttached = examRegData.FilepathFitnessAttached;
            output.Input1.FilepathTrainingAttached = examRegData.FilepathTrainingAttached;
            output.Input1.FilepathExfeeuploadPayslip = examRegData.FilepathExfeeuploadPayslip;
            output.Input1.FilepathAnnfeeuploadPayslip = examRegData.FilepathAnnfeeuploadPayslip;
            output.Input1.CcEnrno = examRegData.CcEnrno;
            output.Input1.CcSession = examRegData.CcSession;
            output.Input1.CcYear = examRegData.CcYear;

            output.CoachingClassSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                  select new FormFillupModel8
                                                  {
                                                      SubId = sub.SubId,
                                                      SubName = sub.SubName,
                                                      CoachingClassAttended = false
                                                  }).ToListAsync();

            if (output.CoachingClassSubjects == null || output.CoachingClassSubjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for coaching class subjects",
                    Success = false,
                    Payload = null
                });
            }

            output.AppearingInSubjects = await (from sub in _context.Subjects.Where(l => l.Parent == output.Input1.ExamLevel).Select(i => new { i.SubId, i.SubName })
                                                select new FormFillupModel5
                                                {
                                                    SubId = sub.SubId,
                                                    SubName = sub.SubName,
                                                    ToBeAppeared = "false"
                                                }).ToListAsync();

            if (output.AppearingInSubjects == null || output.AppearingInSubjects.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found under exam level: " + output.Input1.ExamLevel + " for appearing in subjects",
                    Success = false,
                    Payload = null
                });
            }

            List<int?> classAttendanceSubjectIdCollection = await _context.ClassAttendances.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

            foreach (var item in output.CoachingClassSubjects.Where(k => classAttendanceSubjectIdCollection.Contains(k.SubId)).ToList())
            {
                item.CoachingClassAttended = true;
            }

            List<int> regSubjectIdCollection = await _context.RegSubjects.Where(o => o.RefNo == input.Ref).Select(l => l.SubId).ToListAsync();

            foreach (var item in output.AppearingInSubjects.Where(k => regSubjectIdCollection.Contains(k.SubId)).ToList())
            {
                item.ToBeAppeared = "true";
            }

            if (output.Input1.ExamLevel == 61)
            {
                EarlierPassed61 tempEarlierPassed61 = await _context.EarlierPassed61s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();
                if (tempEarlierPassed61 != null)
                {
                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 611 && tempEarlierPassed61.Ep611 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 612 && tempEarlierPassed61.Ep612 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 613 && tempEarlierPassed61.Ep613 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 614 && tempEarlierPassed61.Ep614 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 615 && tempEarlierPassed61.Ep615 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 616 && tempEarlierPassed61.Ep616 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 617 && tempEarlierPassed61.Ep617 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
            }
            else if (output.Input1.ExamLevel == 62)
            {
                EarlierPassed62 tempEarlierPassed62 = await _context.EarlierPassed62s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();
                if (tempEarlierPassed62 != null)
                {
                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 621 && tempEarlierPassed62.Ep621 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 622 && tempEarlierPassed62.Ep622 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 623 && tempEarlierPassed62.Ep623 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 624 && tempEarlierPassed62.Ep624 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 625 && tempEarlierPassed62.Ep625 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 626 && tempEarlierPassed62.Ep626 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 627 && tempEarlierPassed62.Ep627 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
            }
            else if (output.Input1.ExamLevel == 63)
            {
                EarlierPassed63 tempEarlierPassed63 = await _context.EarlierPassed63s.Where(o => o.RegNo == output.Input1.RegNo && o.Ref == output.Input1.Ref).FirstOrDefaultAsync();
                if (tempEarlierPassed63 != null)
                {
                    foreach (var item in output.AppearingInSubjects)
                    {
                        if (item.SubId == 631 && tempEarlierPassed63.Ep631 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 632 && tempEarlierPassed63.Ep632 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                        else if (item.SubId == 633 && tempEarlierPassed63.Ep633 == 1)
                        {
                            item.ToBeAppeared = "ep";
                        }
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "This exam level: " + output.Input1.ExamLevel + " is not allowed",
                    Success = false,
                    Payload = null
                });
            }

            List<int?> exemptedSubjectIdCollection = await _context.ExemptedSubs.Where(o => o.Ref == input.Ref).Select(l => l.SubId).ToListAsync();

            foreach (var item in output.AppearingInSubjects.Where(k => exemptedSubjectIdCollection.Contains(k.SubId)).ToList())
            {
                item.ToBeAppeared = "ex";
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Form fillup data after approval for registration number : " + output.Input1.RegNo + " (ref: " + output.Input1.Ref + ")",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Approve Form Fillup Data 
        /// </summary>
        [HttpPost("ApproveFormFillupData")]
        public async Task<ActionResult<ResponseDto2>> ApproveFormFillupData([FromBody] FormFillupModel11 input)
        {
            if (input.Ref < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            bool refNoFoundInTempExamReg = await _context.TempExamRegs.AnyAsync(i => i.Ref == input.Ref);

            if (refNoFoundInTempExamReg == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number " + input.Ref + " does not exists in temporary exam registration",
                    Success = false,
                    Payload = null
                });
            }

            decimal? isFormFillupApproved = await _context.TempExamRegs.Where(i => i.Ref == input.Ref).Select(o => o.Fapprove).FirstOrDefaultAsync();

            if (isFormFillupApproved == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Approval status for reference number " + input.Ref + " is undefined in temporary exam registration",
                    Success = false,
                    Payload = null
                });
            }

            if ((int)isFormFillupApproved == 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Form fillup data is already approved for ref no : " + input.Ref,
                    Success = false,
                    Payload = null
                });
            }

            else if ((int)isFormFillupApproved == 0)
            {
                // fetching old data

                TempExamReg tempExamReg = await _context.TempExamRegs.Where(i => i.Ref == input.Ref).FirstOrDefaultAsync();

                if (tempExamReg == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Form fillup info found in temporary exam registration for ref: " + input.Ref,
                        Success = false,
                        Payload = null
                    });
                }

                List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(i => i.RefNo == input.Ref).ToListAsync();

                if (tempRegSubjects == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No Form fillup info found in temporary registration subject for ref: " + input.Ref + " (registration number: " + tempExamReg.RegNo + ")",
                        Success = false,
                        Payload = null
                    });
                }

                List<TempExemptedSub> tempExemptedSubs = await _context.TempExemptedSubs.Where(i => i.Ref == input.Ref).ToListAsync();

                TempEarlierPassed61 tempEarlierPassed61 = new();
                TempEarlierPassed62 tempEarlierPassed62 = new();
                TempEarlierPassed63 tempEarlierPassed63 = new();

                if (tempExamReg.ExamLevel == 61)
                {
                    tempEarlierPassed61 = await _context.TempEarlierPassed61s.Where(o => o.RegNo == tempExamReg.RegNo && o.Ref == tempExamReg.Ref).FirstOrDefaultAsync();
                }
                else if (tempExamReg.ExamLevel == 62)
                {
                    tempEarlierPassed62 = await _context.TempEarlierPassed62s.Where(o => o.RegNo == tempExamReg.RegNo && o.Ref == tempExamReg.Ref).FirstOrDefaultAsync();
                }
                else if (tempExamReg.ExamLevel == 63)
                {
                    tempEarlierPassed63 = await _context.TempEarlierPassed63s.Where(o => o.RegNo == tempExamReg.RegNo && o.Ref == tempExamReg.Ref).FirstOrDefaultAsync();
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine("1: Here is temp exam level :" + tempExamReg.ExamLevel);
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "This exam level is not allowed",
                        Success = false,
                        Payload = null
                    });
                }

                // Inserting new data

                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    List<RegSubject> regSubjects = new();

                    //foreach (var item in tempRegSubjects)
                    //{
                    //    RegSubject regSubject = new();

                    //    regSubject.RefNo = item.RefNo;
                    //    regSubject.SubId = item.SubId;
                    //    regSubject.EntryType = 1;

                    //    _context.RegSubjects.Add(regSubject);
                    //    await _context.SaveChangesAsync();
                    //}

                    //foreach (var item in tempExemptedSubs)
                    //{
                    //    ExemptedSub exemptedSub = new();

                    //    exemptedSub.ExamLevel = item.ExamLevel;
                    //    exemptedSub.Ref = item.Ref;
                    //    exemptedSub.SubId = item.SubId;
                    //    exemptedSub.RegNo = item.RegNo;

                    //    _context.ExemptedSubs.Add(exemptedSub);
                    //    await _context.SaveChangesAsync();
                    //}



                    //System.Diagnostics.Debug.WriteLine("61 is null? :" + tempEarlierPassed61==null);
                    //System.Diagnostics.Debug.WriteLine("62 is null? :" + tempEarlierPassed62==null);
                    //System.Diagnostics.Debug.WriteLine("63 is null? :" + tempEarlierPassed63==null);



                    if (tempExamReg.ExamLevel == 61 && tempEarlierPassed61 != null)
                    {
                        EarlierPassed61 earlierPassed61 = new();
                        earlierPassed61.RegNo = tempExamReg.RegNo;
                        earlierPassed61.Ref = tempExamReg.Ref;

                        if (tempEarlierPassed61.Ep611 == 1)
                        {
                            earlierPassed61.Ep611 = 1;
                        }
                        if (tempEarlierPassed61.Ep612 == 1)
                        {
                            earlierPassed61.Ep612 = 1;
                        }
                        if (tempEarlierPassed61.Ep613 == 1)
                        {
                            earlierPassed61.Ep613 = 1;
                        }
                        if (tempEarlierPassed61.Ep614 == 1)
                        {
                            earlierPassed61.Ep614 = 1;
                        }
                        if (tempEarlierPassed61.Ep615 == 1)
                        {
                            earlierPassed61.Ep615 = 1;
                        }
                        if (tempEarlierPassed61.Ep616 == 1)
                        {
                            earlierPassed61.Ep616 = 1;
                        }
                        if (tempEarlierPassed61.Ep617 == 1)
                        {
                            earlierPassed61.Ep617 = 1;
                        }

                        _context.EarlierPassed61s.Add(earlierPassed61);
                        await _context.SaveChangesAsync();
                    }
                    else if (tempExamReg.ExamLevel == 62 && tempEarlierPassed62 != null)
                    {
                        EarlierPassed62 earlierPassed62 = new();
                        earlierPassed62.RegNo = tempExamReg.RegNo;
                        earlierPassed62.Ref = tempExamReg.Ref;

                        if (tempEarlierPassed62.Ep621 == 1)
                        {
                            earlierPassed62.Ep621 = 1;
                        }
                        if (tempEarlierPassed62.Ep622 == 1)
                        {
                            earlierPassed62.Ep622 = 1;
                        }
                        if (tempEarlierPassed62.Ep623 == 1)
                        {
                            earlierPassed62.Ep623 = 1;
                        }
                        if (tempEarlierPassed62.Ep624 == 1)
                        {
                            earlierPassed62.Ep624 = 1;
                        }
                        if (tempEarlierPassed62.Ep625 == 1)
                        {
                            earlierPassed62.Ep625 = 1;
                        }
                        if (tempEarlierPassed62.Ep626 == 1)
                        {
                            earlierPassed62.Ep626 = 1;
                        }
                        if (tempEarlierPassed62.Ep627 == 1)
                        {
                            earlierPassed62.Ep627 = 1;
                        }

                        _context.EarlierPassed62s.Add(earlierPassed62);
                        await _context.SaveChangesAsync();
                    }
                    else if (tempExamReg.ExamLevel == 63 && tempEarlierPassed63 != null)
                    {
                        EarlierPassed63 earlierPassed63 = new();
                        earlierPassed63.RegNo = tempExamReg.RegNo;
                        earlierPassed63.Ref = tempExamReg.Ref;

                        if (tempEarlierPassed63.Ep631 == 1)
                        {
                            earlierPassed63.Ep631 = 1;
                        }
                        if (tempEarlierPassed63.Ep632 == 1)
                        {
                            earlierPassed63.Ep632 = 1;
                        }
                        if (tempEarlierPassed63.Ep633 == 1)
                        {
                            earlierPassed63.Ep633 = 1;
                        }

                        _context.EarlierPassed63s.Add(earlierPassed63);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        //System.Diagnostics.Debug.WriteLine("2: Here is temp exam level :" + tempExamReg.ExamLevel);
                        //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                        //{
                        //    Message = "This exam level is not allowed",
                        //    Success = false,
                        //    Payload = null
                        //});
                    }

                    bool isInExamReg = await _context.ExamRegs.AnyAsync(i => i.ExamLevel == tempExamReg.ExamLevel && i.MonthId == tempExamReg.MonthId && i.SessionYear == tempExamReg.SessionYear && i.ExamcenId == tempExamReg.ExamcenId && i.RegNo == tempExamReg.RegNo);
                    if (isInExamReg == true)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "Form is already approved for given criteria",
                            Success = false,
                            Payload = new { tempExamReg.ExamLevel, tempExamReg.MonthId, tempExamReg.SessionYear, tempExamReg.ExamcenId, tempExamReg.RegNo }
                        });
                    }

                    ExamReg examReg = new();

                    examReg.RegNo = tempExamReg.RegNo;
                    examReg.ExamLevel = tempExamReg.ExamLevel;
                    examReg.MonthId = tempExamReg.MonthId;
                    examReg.SessionYear = tempExamReg.SessionYear;
                    examReg.ExamcenId = tempExamReg.ExamcenId;
                    examReg.Ref = (await _context.ExamRegs.AnyAsync() ? await _context.ExamRegs.MaxAsync(k => k.Ref) : 0) + 1;
                    examReg.FormNo = tempExamReg.FormNo;
                    examReg.FillupDate = tempExamReg.FillupDate;
                    examReg.ExamRollno = tempExamReg.ExamRollno;
                    examReg.TrainingSt = tempExamReg.TrainingSt;
                    examReg.TrainingEnd = tempExamReg.TrainingEnd;
                    examReg.LastAppearedMonthid = tempExamReg.LastAppearedMonthid;
                    examReg.LastAppearedYear = tempExamReg.LastAppearedYear;
                    examReg.LastAppearedRollno = tempExamReg.LastAppearedRollno;
                    examReg.LastAppearedExamlevel = tempExamReg.LastAppearedExamlevel;
                    examReg.EntryType = tempExamReg.EntryType;
                    examReg.AttenAttached = tempExamReg.AttenAttached;
                    examReg.TrainingAttached = tempExamReg.TrainingAttached;
                    examReg.Validity = tempExamReg.Validity;
                    examReg.ReasonInvalid = tempExamReg.ReasonInvalid;
                    examReg.Entryuser = tempExamReg.Entryuser;
                    examReg.FitnessAttached = tempExamReg.FitnessAttached;
                    examReg.StudType = tempExamReg.StudType;
                    examReg.FilepathAttenAttached = tempExamReg.FilepathAttenAttached;
                    examReg.FilepathFitnessAttached = tempExamReg.FilepathFitnessAttached;
                    examReg.FilepathTrainingAttached = tempExamReg.FilepathTrainingAttached;
                    examReg.FilepathExfeeuploadPayslip = tempExamReg.FilepathExfeeuploadPayslip;
                    examReg.FilepathAnnfeeuploadPayslip = tempExamReg.FilepathAnnfeeuploadPayslip;
                    examReg.CcEnrno = tempExamReg.CcEnrno;
                    examReg.CcSession = tempExamReg.CcSession;
                    examReg.CcYear = tempExamReg.CcYear;

                    //System.Diagnostics.Debug.WriteLine("here is maxref: " + Environment.NewLine);
                    //int countExamRegs = await _context.ExamRegs.CountAsync();
                    //System.Diagnostics.Debug.WriteLine("here is count: " + countTempExamRegs);

                    _context.ExamRegs.Add(examReg);
                    int isSaved = await _context.SaveChangesAsync();
                    bool isValid = isSaved > 0;

                    tempExamReg.Fapprove = 1;
                    tempExamReg.MaintbRef = examReg.Ref;

                    _context.TempExamRegs.Update(tempExamReg);
                    await _context.SaveChangesAsync();

                    foreach (var item in tempRegSubjects)
                    {
                        //bool isInRegSubject = await _context.RegSubjects.AnyAsync(i => i.RefNo == examReg.Ref && i.SubId == item.SubId);
                        //if (isInRegSubject == true)
                        //{
                        //    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        //    {
                        //        Message = "The given criteria already exists in registration subject. Ref: " + examReg.Ref + " subId: " + item.SubId,
                        //        Success = false,
                        //        Payload = new { tempExamReg.ExamLevel, tempExamReg.MonthId, tempExamReg.SessionYear, tempExamReg.ExamcenId, tempExamReg.RegNo }
                        //    });
                        //}

                        //System.Diagnostics.Debug.WriteLine("1st is count: " + item.RefNo);
                        //System.Diagnostics.Debug.WriteLine("1st is count: " + item.SubId);
                        //System.Diagnostics.Debug.WriteLine("1st is count: " + item.EntryType);

                        RegSubject regSubject = new();

                        regSubject.RefNo = examReg.Ref;
                        regSubject.SubId = item.SubId;
                        regSubject.EntryType = 1;

                        _context.RegSubjects.Add(regSubject);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var item in tempExemptedSubs)
                    {
                        ExemptedSub exemptedSub = new();

                        exemptedSub.ExamLevel = item.ExamLevel;
                        exemptedSub.Ref = examReg.Ref;
                        exemptedSub.SubId = item.SubId;
                        exemptedSub.RegNo = item.RegNo;

                        _context.ExemptedSubs.Add(exemptedSub);
                        await _context.SaveChangesAsync();
                    }

                    List<TempClassAttendance> tempClassAttendances = await _context.TempClassAttendances.Where(i => i.RefNo == input.Ref).ToListAsync();
                    System.Diagnostics.Debug.WriteLine("get count no: " + tempClassAttendances.Count);
                    System.Diagnostics.Debug.WriteLine("get ref no: " + input.Ref);
                    if (tempClassAttendances.Count > 0)
                    {
                        foreach (TempClassAttendance tempClass in tempClassAttendances)
                        {
                            ClassAttendance classAttendance = new();
                            classAttendance.RefNo = examReg.Ref;
                            classAttendance.ExamLevel = tempClass.ExamLevel;
                            classAttendance.RegNo = tempClass.RegNo;
                            classAttendance.SubId = tempClass.SubId;
                            _context.ClassAttendances.Add(classAttendance);
                            await _context.SaveChangesAsync();
                        }
                    }

                    transaction.Commit();

                    return StatusCode(isValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
                    {
                        Message = isValid ? "Form fillup approval successful" : "Form fillup approval failed . Something went wrong. Please try again later",
                        Success = isValid,
                        Payload = isValid ? new { input.Ref, tempExamReg.MaintbRef, tempExamReg.RegNo } : null
                    });
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                    {
                        Message = "Form fillup approval failed . Something went wrong. Please try again later",
                        Success = false,
                        Payload = new { e.Message, e.InnerException, e.StackTrace, e.Source, e.Data }
                    });
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = "Form fillup approval failed. Something went wrong. Please try again later",
                Success = false,
                Payload = null
            });
        }

        /// <summary>
        /// Update Form Fillup Data After Approval
        /// </summary>
        [HttpPut("UpdateFormFillupDataAfterApproval")]
        public async Task<ActionResult<ResponseDto2>> UpdateFormFillupDataAfterApproval([FromBody] FormFillupModel12 input)
        {
            if (input.Input1.Ref < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reference number " + input.Input1.Ref + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            bool refNoFoundInTempExamReg = await _context.ExamRegs.AnyAsync(i => i.Ref == input.Input1.Ref);

            if (refNoFoundInTempExamReg == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number " + input.Input1.Ref + " does not exists in exam registration",
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                ExamReg examReg = await _context.ExamRegs.Where(i => i.Ref == input.Input1.Ref).FirstOrDefaultAsync();

                _context.ExamRegs.Remove(examReg);
                await _context.SaveChangesAsync();

                List<RegSubject> regSubjects = await _context.RegSubjects.Where(o => o.RefNo == input.Input1.Ref).ToListAsync();
                foreach (var item in regSubjects)
                {
                    _context.RegSubjects.Remove(item);
                    await _context.SaveChangesAsync();
                }

                List<ExemptedSub> exemptedSubs = await _context.ExemptedSubs.Where(o => o.Ref == input.Input1.Ref).ToListAsync();
                foreach (var item in exemptedSubs)
                {
                    _context.ExemptedSubs.Remove(item);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in await _context.ClassAttendances.Where(i => i.RefNo == input.Input1.Ref).ToListAsync())
                {
                    _context.ClassAttendances.Remove(item);
                    await _context.SaveChangesAsync();
                }

                if (input.Input1.ExamLevel == 61)
                {
                    List<EarlierPassed61> earlierPassed61s = await _context.EarlierPassed61s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in earlierPassed61s)
                    {
                        _context.EarlierPassed61s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (input.Input1.ExamLevel == 62)
                {
                    List<EarlierPassed62> earlierPassed62s = await _context.EarlierPassed62s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in earlierPassed62s)
                    {
                        _context.EarlierPassed62s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (input.Input1.ExamLevel == 63)
                {
                    List<EarlierPassed63> earlierPassed63s = await _context.EarlierPassed63s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in earlierPassed63s)
                    {
                        _context.EarlierPassed63s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "This exam level " + input.Input1.ExamLevel + " is not allowed",
                        Success = false,
                        Payload = null
                    });
                }

                ExamReg examRegData = new();

                examRegData.Ref = input.Input1.Ref;
                examRegData.FormNo = input.Input1.FormNo;
                examRegData.FillupDate = input.Input1.FillupDate;
                examRegData.ExamRollno = input.Input1.ExamRollno;
                examRegData.RegNo = input.Input1.RegNo;
                examRegData.ExamLevel = input.Input1.ExamLevel;
                examRegData.MonthId = input.Input1.MonthId;
                examRegData.SessionYear = input.Input1.SessionYear;
                examRegData.ExamcenId = input.Input1.ExamcenId;
                examRegData.TrainingSt = input.Input1.TrainingSt;
                examRegData.TrainingEnd = input.Input1.TrainingEnd;
                examRegData.LastAppearedMonthid = input.Input1.LastAppearedMonthid;
                examRegData.LastAppearedYear = input.Input1.LastAppearedYear;
                examRegData.LastAppearedRollno = input.Input1.LastAppearedRollno;
                examRegData.LastAppearedExamlevel = input.Input1.LastAppearedExamlevel;
                examRegData.EntryType = input.Input1.EntryType;
                examRegData.AttenAttached = input.Input1.AttenAttached;
                examRegData.TrainingAttached = input.Input1.TrainingAttached;
                examRegData.Validity = input.Input1.Validity;
                examRegData.ReasonInvalid = input.Input1.ReasonInvalid;
                examRegData.Entryuser = input.Input1.Entryuser;
                examRegData.FitnessAttached = input.Input1.FitnessAttached;
                examRegData.StudType = input.Input1.StudType;
                examRegData.FilepathAttenAttached = input.Input1.FilepathAttenAttached;
                examRegData.FilepathFitnessAttached = input.Input1.FilepathFitnessAttached;
                examRegData.FilepathTrainingAttached = input.Input1.FilepathTrainingAttached;
                examRegData.FilepathExfeeuploadPayslip = input.Input1.FilepathExfeeuploadPayslip;
                examRegData.FilepathAnnfeeuploadPayslip = input.Input1.FilepathAnnfeeuploadPayslip;
                examRegData.CcEnrno = input.Input1.CcEnrno;
                examRegData.CcSession = input.Input1.CcSession;
                examRegData.CcYear = input.Input1.CcYear;

                _context.ExamRegs.Add(examRegData);
                await _context.SaveChangesAsync();

                foreach (var item in input.CoachingClassSubjects.Where(i => i.CoachingClassAttended == true).ToList())
                {
                    ClassAttendance classAttendance = new();
                    classAttendance.RefNo = input.Input1.Ref;
                    classAttendance.RegNo = input.Input1.RegNo;
                    classAttendance.SubId = item.SubId;
                    classAttendance.ExamLevel = input.Input1.ExamLevel;

                    _context.ClassAttendances.Add(classAttendance);
                    await _context.SaveChangesAsync();
                }

                EarlierPassed61 earlierPassed61 = new();
                EarlierPassed62 earlierPassed62 = new();
                EarlierPassed63 earlierPassed63 = new();

                foreach (var item in input.AppearingInSubjects.Where(i => i.ToBeAppeared != null || i.ToBeAppeared != "false").ToList())
                {
                    if (item.ToBeAppeared == "true")
                    {
                        RegSubject regSubject = new();
                        regSubject.EntryType = 1;
                        regSubject.RefNo = input.Input1.Ref;
                        regSubject.SubId = item.SubId;

                        _context.RegSubjects.Add(regSubject);
                        await _context.SaveChangesAsync();
                    }

                    else if (item.ToBeAppeared == "ex")
                    {
                        ExemptedSub exemptedSub = new();
                        exemptedSub.SubId = item.SubId;
                        exemptedSub.RegNo = input.Input1.RegNo;
                        exemptedSub.Ref = input.Input1.Ref;
                        exemptedSub.ExamLevel = input.Input1.ExamLevel;

                        _context.ExemptedSubs.Add(exemptedSub);
                        await _context.SaveChangesAsync();
                    }

                    else if (item.ToBeAppeared == "ep")
                    {
                        if (input.Input1.ExamLevel == 61)
                        {
                            earlierPassed61.RegNo = input.Input1.RegNo;
                            earlierPassed61.Ref = input.Input1.Ref;
                            if (item.SubId == 611)
                            {
                                earlierPassed61.Ep611 = 1;
                            }
                            else if (item.SubId == 612)
                            {
                                earlierPassed61.Ep612 = 1;
                            }
                            else if (item.SubId == 613)
                            {
                                earlierPassed61.Ep613 = 1;
                            }
                            else if (item.SubId == 614)
                            {
                                earlierPassed61.Ep614 = 1;
                            }
                            else if (item.SubId == 615)
                            {
                                earlierPassed61.Ep615 = 1;
                            }
                            else if (item.SubId == 616)
                            {
                                earlierPassed61.Ep616 = 1;
                            }
                            else if (item.SubId == 617)
                            {
                                earlierPassed61.Ep617 = 1;
                            }
                        }

                        else if (input.Input1.ExamLevel == 62)
                        {
                            earlierPassed62.RegNo = input.Input1.RegNo;
                            earlierPassed62.Ref = input.Input1.Ref;
                            if (item.SubId == 621)
                            {
                                earlierPassed62.Ep621 = 1;
                            }
                            else if (item.SubId == 622)
                            {
                                earlierPassed62.Ep622 = 1;
                            }
                            else if (item.SubId == 623)
                            {
                                earlierPassed62.Ep623 = 1;
                            }
                            else if (item.SubId == 624)
                            {
                                earlierPassed62.Ep624 = 1;
                            }
                            else if (item.SubId == 625)
                            {
                                earlierPassed62.Ep625 = 1;
                            }
                            else if (item.SubId == 626)
                            {
                                earlierPassed62.Ep626 = 1;
                            }
                            else if (item.SubId == 627)
                            {
                                earlierPassed62.Ep627 = 1;
                            }
                        }

                        else if (input.Input1.ExamLevel == 63)
                        {
                            earlierPassed63.RegNo = input.Input1.RegNo;
                            earlierPassed63.Ref = input.Input1.Ref;
                            if (item.SubId == 631)
                            {
                                earlierPassed63.Ep631 = 1;
                            }
                            else if (item.SubId == 632)
                            {
                                earlierPassed63.Ep632 = 1;
                            }
                            else if (item.SubId == 633)
                            {
                                earlierPassed63.Ep633 = 1;
                            }
                        }
                    }
                }

                if (input.Input1.ExamLevel == 61)
                {
                    _context.EarlierPassed61s.Add(earlierPassed61);
                    await _context.SaveChangesAsync();
                }
                else if (input.Input1.ExamLevel == 62)
                {
                    _context.EarlierPassed62s.Add(earlierPassed62);
                    await _context.SaveChangesAsync();
                }
                else if (input.Input1.ExamLevel == 63)
                {
                    _context.EarlierPassed63s.Add(earlierPassed63);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student Form filup info update failed for registration number: " + input.Input1.RegNo + ". Something went wrong, Please try again later.",
                    Success = false,
                    Payload = new { e.Message, e.InnerException, e.StackTrace, e.Source, e.Data }
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "The form with reference number: " + input.Input1.Ref + " (registration number: " + input.Input1.RegNo + ") is updated successfully",
                Success = true,
                Payload = null
            });
        }

        /// <summary>
        /// Update Form Fillup Data Before Approval
        /// </summary>
        [HttpPut("UpdateFormFillupDataBeforeApproval")]
        public async Task<ActionResult<ResponseDto2>> UpdateFormFillupDataBeforeApproval([FromBody] FormFillupModel7 input)
        {
            if (input.Input1.Ref < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Reference number " + input.Input1.Ref + " can not be null",
                    Success = false,
                    Payload = null
                });
            }

            bool refNoFoundInTempExamReg = await _context.TempExamRegs.AnyAsync(i => i.Ref == input.Input1.Ref);

            if (refNoFoundInTempExamReg == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Reference number " + input.Input1.Ref + " does not exists in temporary exam registration",
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                TempExamReg tempExamReg = await _context.TempExamRegs.Where(i => i.Ref == input.Input1.Ref).FirstOrDefaultAsync();

                _context.TempExamRegs.Remove(tempExamReg);
                await _context.SaveChangesAsync();

                List<TempRegSubject> tempRegSubjects = await _context.TempRegSubjects.Where(o => o.RefNo == input.Input1.Ref).ToListAsync();
                foreach (var item in tempRegSubjects)
                {
                    _context.TempRegSubjects.Remove(item);
                    await _context.SaveChangesAsync();
                }

                List<TempExemptedSub> tempExemptedSubs = await _context.TempExemptedSubs.Where(o => o.Ref == input.Input1.Ref).ToListAsync();
                foreach (var item in tempExemptedSubs)
                {
                    _context.TempExemptedSubs.Remove(item);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in await _context.TempClassAttendances.Where(i => i.RefNo == input.Input1.Ref).ToListAsync())
                {
                    _context.TempClassAttendances.Remove(item);
                    await _context.SaveChangesAsync();
                }

                if (input.Input1.ExamLevel == 61)
                {
                    List<TempEarlierPassed61> tempEarlierPassed61s = await _context.TempEarlierPassed61s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in tempEarlierPassed61s)
                    {
                        _context.TempEarlierPassed61s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (input.Input1.ExamLevel == 62)
                {
                    List<TempEarlierPassed62> tempEarlierPassed62s = await _context.TempEarlierPassed62s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in tempEarlierPassed62s)
                    {
                        _context.TempEarlierPassed62s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (input.Input1.ExamLevel == 63)
                {
                    List<TempEarlierPassed63> tempEarlierPassed63s = await _context.TempEarlierPassed63s.Where(o => o.RegNo == input.Input1.RegNo && o.Ref == input.Input1.Ref).ToListAsync();
                    foreach (var item in tempEarlierPassed63s)
                    {
                        _context.TempEarlierPassed63s.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "This exam level " + input.Input1.ExamLevel + " is not allowed",
                        Success = false,
                        Payload = null
                    });
                }

                _context.TempExamRegs.Add(input.Input1);
                await _context.SaveChangesAsync();

                foreach (var item in input.CoachingClassSubjects.Where(i => i.CoachingClassAttended == true).ToList())
                {
                    TempClassAttendance tempClassAttendance = new();
                    tempClassAttendance.RefNo = input.Input1.Ref;
                    tempClassAttendance.RegNo = input.Input1.RegNo;
                    tempClassAttendance.SubId = item.SubId;
                    tempClassAttendance.ExamLevel = input.Input1.ExamLevel;

                    _context.TempClassAttendances.Add(tempClassAttendance);
                    await _context.SaveChangesAsync();
                }

                TempEarlierPassed61 tempEarlierPassed61 = new();
                TempEarlierPassed62 tempEarlierPassed62 = new();
                TempEarlierPassed63 tempEarlierPassed63 = new();



                foreach (var item in input.AppearingInSubjects.Where(i => i.ToBeAppeared != null || i.ToBeAppeared != "false").ToList())
                {
                    if (item.ToBeAppeared == "true")
                    {
                        TempRegSubject tempRegSubject = new();
                        tempRegSubject.EntryType = 1;
                        tempRegSubject.RefNo = input.Input1.Ref;
                        tempRegSubject.SubId = item.SubId;

                        _context.TempRegSubjects.Add(tempRegSubject);
                        await _context.SaveChangesAsync();
                    }

                    else if (item.ToBeAppeared == "ex")
                    {
                        TempExemptedSub tempExemptedSub = new();
                        tempExemptedSub.SubId = item.SubId;
                        tempExemptedSub.RegNo = input.Input1.RegNo;
                        tempExemptedSub.Ref = input.Input1.Ref;
                        tempExemptedSub.ExamLevel = input.Input1.ExamLevel;

                        _context.TempExemptedSubs.Add(tempExemptedSub);
                        await _context.SaveChangesAsync();
                    }

                    else if (item.ToBeAppeared == "ep")
                    {
                        if (input.Input1.ExamLevel == 61)
                        {
                            tempEarlierPassed61.RegNo = input.Input1.RegNo;
                            tempEarlierPassed61.Ref = input.Input1.Ref;
                            if (item.SubId == 611)
                            {
                                tempEarlierPassed61.Ep611 = 1;
                            }
                            else if (item.SubId == 612)
                            {
                                tempEarlierPassed61.Ep612 = 1;
                            }
                            else if (item.SubId == 613)
                            {
                                tempEarlierPassed61.Ep613 = 1;
                            }
                            else if (item.SubId == 614)
                            {
                                tempEarlierPassed61.Ep614 = 1;
                            }
                            else if (item.SubId == 615)
                            {
                                tempEarlierPassed61.Ep615 = 1;
                            }
                            else if (item.SubId == 616)
                            {
                                tempEarlierPassed61.Ep616 = 1;
                            }
                            else if (item.SubId == 617)
                            {
                                tempEarlierPassed61.Ep617 = 1;
                            }
                        }

                        else if (input.Input1.ExamLevel == 62)
                        {
                            tempEarlierPassed62.RegNo = input.Input1.RegNo;
                            tempEarlierPassed62.Ref = input.Input1.Ref;
                            if (item.SubId == 621)
                            {
                                tempEarlierPassed62.Ep621 = 1;
                            }
                            else if (item.SubId == 622)
                            {
                                tempEarlierPassed62.Ep622 = 1;
                            }
                            else if (item.SubId == 623)
                            {
                                tempEarlierPassed62.Ep623 = 1;
                            }
                            else if (item.SubId == 624)
                            {
                                tempEarlierPassed62.Ep624 = 1;
                            }
                            else if (item.SubId == 625)
                            {
                                tempEarlierPassed62.Ep625 = 1;
                            }
                            else if (item.SubId == 626)
                            {
                                tempEarlierPassed62.Ep626 = 1;
                            }
                            else if (item.SubId == 627)
                            {
                                tempEarlierPassed62.Ep627 = 1;
                            }
                        }

                        else if (input.Input1.ExamLevel == 63)
                        {
                            tempEarlierPassed63.RegNo = input.Input1.RegNo;
                            tempEarlierPassed63.Ref = input.Input1.Ref;
                            if (item.SubId == 631)
                            {
                                tempEarlierPassed63.Ep631 = 1;
                            }
                            else if (item.SubId == 632)
                            {
                                tempEarlierPassed63.Ep632 = 1;
                            }
                            else if (item.SubId == 633)
                            {
                                tempEarlierPassed63.Ep633 = 1;
                            }
                        }
                    }
                }

                if (input.Input1.ExamLevel == 61)
                {
                    _context.TempEarlierPassed61s.Add(tempEarlierPassed61);
                    await _context.SaveChangesAsync();
                }
                else if (input.Input1.ExamLevel == 62)
                {
                    _context.TempEarlierPassed62s.Add(tempEarlierPassed62);
                    await _context.SaveChangesAsync();
                }
                else if (input.Input1.ExamLevel == 63)
                {
                    _context.TempEarlierPassed63s.Add(tempEarlierPassed63);
                    await _context.SaveChangesAsync();
                }

                transaction.Commit();
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Student Form filup info update failed for registration number: " + input.Input1.RegNo + ". Something went wrong, Please try again later.",
                    Success = false,
                    Payload = new { e.Message, e.InnerException, e.StackTrace, e.Source, e.Data }
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "The form with reference number: " + input.Input1.Ref + " (registration number: " + input.Input1.RegNo + ") is updated successfully",
                Success = true,
                Payload = null
            });
        }

        [HttpPost("GetExamFeeDetailsList")]
        public async Task<ActionResult<ResponseDto2>> GetExamFeeDetailsList([FromBody] ExamFeeDetailsInput input)
        {
            if (input.ExamLevel == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Please Input the ExamLevel Field!",
                    Success = false,
                    Payload = null
                });
            }
            if (input.MonthId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Please Input the MonthID Field!",
                    Success = false,
                    Payload = null
                });
            }
            if (input.SessionYear == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Please Input the SessionYear Field!",
                    Success = false,
                    Payload = null
                });
            }

            List<ExamFeeDetailsOutput> examFeeDetailsOutputs =
                await (from ter in _context.TempExamRegs
                                           .Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear)
                       from sr1 in _context.StuReg1s
                                           .Where(i => ter.RegNo == i.RegNo)
                       select new ExamFeeDetailsOutput
                       {
                           RegNo = ter.RegNo,
                           FormNo = ter.FormNo,
                           Name = sr1.Name,
                           FName = sr1.FName,
                           Exfeepayslipdate = ter.Exfeepayslipdate,
                           Exfeepayslipno = ter.Exfeepayslipno,
                           Exfeepayslipbank = ter.Exfeepayslipbank,
                           Exfeepayslipbr = ter.Exfeepayslipbr,
                           Exfeepayslipamt = ter.Exfeepayslipamt
                       }).OrderBy(i => i.RegNo).ToListAsync();


            if (examFeeDetailsOutputs.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam fee details found",
                    Success = false,
                    Payload = null
                });
            }

            decimal? fullamount = examFeeDetailsOutputs.Sum(i => i.Exfeepayslipamt);

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam fee details for " + examFeeDetailsOutputs.Count + " students",
                Success = true,
                Payload = new
                {
                    Output = examFeeDetailsOutputs,
                    Sum = fullamount
                }
            });
        }

        /// <summary>
        /// GetIntegratedTabulationSheet
        /// </summary>
        [HttpPost("GetIntegratedTabulationSheet")]
        public async Task<ActionResult<ResponseDto2>> GetIntegratedTabulationSheet([FromBody] GetIntegratedTabulationSheet input)
        {
            string examLevel1Name = await _context.Subjects.Where(i => i.SubId == input.ExamLevel1).Select(o => o.SubName).FirstOrDefaultAsync();
            string examLevel2Name = await _context.Subjects.Where(i => i.SubId == input.ExamLevel2).Select(o => o.SubName).FirstOrDefaultAsync();
            string examLevel3Name = input.ExamLevel3 == null ? null : await _context.Subjects.Where(i => i.SubId == input.ExamLevel3).Select(o => o.SubName).FirstOrDefaultAsync();
            if (examLevel1Name == null || examLevel2Name == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level is not valid",
                    Success = false,
                    Payload = null
                });
            }
            string monthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionName).FirstOrDefaultAsync();
            if (monthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id does not exists",
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
            // 61 + 62 // 62 + 63
            if (input.TabulationSheetType == 1)
            {
                List<int> examRegsFirst = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel1 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.RegNo).ToListAsync();
                List<int> examRegsSecond = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel2 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.RegNo).ToListAsync();
                List<int> selectedRegs = examRegsFirst.Join(examRegsSecond, o => o, id => id, (o, id) => o).Distinct().OrderBy(l => l).ToList();

                if (selectedRegs.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student found for given criteria for " + examLevel1Name + " and " + examLevel2Name + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                List<OutputForIntegratedTabulationSheet> outputs = new();
                int counter = 1;
                foreach (var item in selectedRegs)
                {
                    FormFillupModel4 ti = new();
                    ti.ExamLevel = input.ExamLevel1;
                    ti.MonthId = input.MonthId;
                    ti.SessionYear = input.SessionYear;
                    ti.RegNo = item;
                    List<FormFillupModel29> rows1 = await GetLevelWiseDetailsResultForOneStudent(ti);
                    FormFillupModel29 row1 = rows1.Where(i => i.ExamLevel == input.ExamLevel1).FirstOrDefault();
                    FormFillupModel4 ti2 = new();
                    ti2.ExamLevel = input.ExamLevel2;
                    ti2.MonthId = input.MonthId;
                    ti2.SessionYear = input.SessionYear;
                    ti2.RegNo = item;
                    List<FormFillupModel29> rows2 = await GetLevelWiseDetailsResultForOneStudent(ti2);
                    FormFillupModel29 row2 = rows2.Where(i => i.ExamLevel == input.ExamLevel2).FirstOrDefault();

                    OutputForIntegratedTabulationSheetType1 optemp = new();
                    optemp.Sl = counter;
                    optemp.RegNo = item;
                    optemp.ExamRollno1 = await _context.ExamRegs.Where(i => i.RegNo == item && i.ExamLevel == input.ExamLevel1 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.ExamRollno).FirstOrDefaultAsync();
                    optemp.Grade1 = row1.ResultDetails[0].Grade ?? "F";
                    optemp.Grade2 = row1.ResultDetails[1].Grade ?? "F";
                    optemp.Grade3 = row1.ResultDetails[2].Grade ?? "F";
                    optemp.Grade4 = row1.ResultDetails[3].Grade ?? "F";
                    optemp.Grade5 = row1.ResultDetails[4].Grade ?? "F";
                    optemp.Grade6 = row1.ResultDetails[5].Grade ?? "F";
                    optemp.Grade7 = row1.ResultDetails[6].Grade ?? "F";
                    optemp.TotalNumberOfPass1 = row1.ResultDetails.Count(i => i.Grade == "A" || i.Grade == "B");
                    optemp.ExamRollno2 = await _context.ExamRegs.Where(i => i.RegNo == item && i.ExamLevel == input.ExamLevel2 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.ExamRollno).FirstOrDefaultAsync();
                    optemp.Grade8 = row2.ResultDetails[0].Grade ?? "F";
                    optemp.Grade9 = row2.ResultDetails[1].Grade ?? "F";
                    optemp.Grade10 = row2.ResultDetails[2].Grade ?? "F";
                    optemp.Grade11 = row2.ResultDetails[3].Grade ?? "F";
                    optemp.Grade12 = row2.ResultDetails[4].Grade ?? "F";
                    optemp.Grade13 = row2.ResultDetails[5].Grade ?? "F";
                    optemp.Grade14 = row2.ResultDetails[6].Grade ?? "F";
                    optemp.TotalNumberOfPass2 = row2.ResultDetails.Count(i => i.Grade == "A" || i.Grade == "B");
                    OutputForIntegratedTabulationSheet optemp2 = new();
                    optemp2.Root = item;
                    optemp2.Children = optemp;
                    outputs.Add(optemp2);
                    counter++;
                }


                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students for " + examLevel1Name + " and " + examLevel2Name + ", " + monthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        Output = outputs
                    }
                });
            }
            //61 + 62 + 63
            if (input.TabulationSheetType == 2)
            {
                if (examLevel3Name == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "Exam level is not valid",
                        Success = false,
                        Payload = null
                    });
                }

                List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel3).OrderBy(l => l.SubOrder).ToListAsync();

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
                                   from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode && ba.ExamLevel == input.ExamLevel3 && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)

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

                if (query == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No tabulation sheet details found for given criteria",
                        Success = false,
                        Payload = null
                    });
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

                Parallel.ForEach(output, item =>
                {
                    decimal totalMarksAchieved = 0;
                    int totalNumberOfPass = 0;

                    Parallel.ForEach(item.ResultDetails, element =>
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
                        else
                        {
                            return;
                        }
                    });

                    item.TotalMarksAchieved = totalMarksAchieved;
                    item.TotalNoOfPass = totalNumberOfPass;
                });

                // ep, ex calculation

                //List<VwMarksfinal> ViewMarksfor61 = input.ExamLevel1 != 61 ? null : await _context.VwMarksfinals.Where(i => (i.ExamLevel == 61 || i.ExamLevel == 41) && (i.Grade == "A" || i.Grade == "B"))
                //.ToListAsync();
                //List<VwMarksfinal> ViewMarksfor62 = input.ExamLevel2 != 62 ? null : await _context.VwMarksfinals.Where(i => (i.ExamLevel == 62 || i.ExamLevel == 42) && (i.Grade == "A" || i.Grade == "B"))
                //.ToListAsync();

                if (input.ExamLevel3 == 63)
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


                    Parallel.ForEach(output, item =>
                    {
                        Parallel.ForEach(item.ResultDetails, element =>
                        {
                            var tempop4 = abc.Where(i => i.RegNo == item.RegNo && i.EPSubId == element.SubId).FirstOrDefault();

                            if (tempop4 != null)
                            {
                                element.Grade = "ep";
                            }
                        });
                    });
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

                //statistics

                //Parallel.ForEach(output, item =>
                //{
                //    Parallel.ForEach(item.ResultDetails, element =>
                //    {
                //        Parallel.ForEach(subjectDetails, subject =>
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
                //        });
                //    });
                //});

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


                //List<int> selectedRegs = _context.ExamRegs
                //                                 .FromSqlInterpolated($@"
                //                                    SELECT DISTINCT ter.REG_NO 
                //                                    FROM ICAB.EXAM_REG ter 
                //                                    WHERE ter.EXAM_LEVEL = {input.ExamLevel3} 
                //                                    AND ter.MONTH_ID = {input.MonthId} 
                //                                    AND ter.SESSION_YEAR = {input.SessionYear}
                //                                    AND ter.REG_NO IN (SELECT DISTINCT REG_NO FROM ICAB.VW_MARKSFINAL x WHERE EXAM_LEVEL = {input.ExamLevel3} and MONTH_ID = {input.MonthId} and SESSION_YEAR = {input.SessionYear} and grade in ('A' , 'B'))
                //                                    ORDER BY ter.REG_NO
                //                                             ")
                //                                 .Select(i => i.RegNo)
                //                                 .OrderBy(j => j)
                //                                 .ToList();

                List<int> selectedRegs = new();

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
                        selectedRegs.Add(item.RegNo ?? 0);
                    }
                }

                if (selectedRegs.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student found for given criteria for " + examLevel1Name + ", " + examLevel2Name + " and " + examLevel3Name + ", " + monthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                List<OutputForIntegratedTabulationSheet2> outputs = new();
                int counter = 1;
                foreach (var item in selectedRegs)
                {
                    FormFillupModel4 ti = new();
                    ti.ExamLevel = input.ExamLevel3 ?? 0;
                    ti.MonthId = input.MonthId;
                    ti.SessionYear = input.SessionYear;
                    ti.RegNo = item;
                    List<FormFillupModel29> doubleIntegrated = await GetLevelWiseDetailsResultForOneStudent(ti);
                    FormFillupModel29 row3 = doubleIntegrated.Where(i => i.ExamLevel == input.ExamLevel3).FirstOrDefault();
                    if (row3.IsExamLevelPassed == false)
                    {
                        continue;
                    }
                    FormFillupModel29 row1 = doubleIntegrated.Where(i => i.ExamLevel == input.ExamLevel1).FirstOrDefault();
                    FormFillupModel29 row2 = doubleIntegrated.Where(i => i.ExamLevel == input.ExamLevel2).FirstOrDefault();

                    OutputForIntegratedTabulationSheetType2 optemp = new();
                    optemp.Sl = counter;
                    optemp.RegNo = item;
                    optemp.Grade1 = row1.ResultDetails[0].Grade ?? "F";
                    optemp.Grade2 = row1.ResultDetails[1].Grade ?? "F";
                    optemp.Grade3 = row1.ResultDetails[2].Grade ?? "F";
                    optemp.Grade4 = row1.ResultDetails[3].Grade ?? "F";
                    optemp.Grade5 = row1.ResultDetails[4].Grade ?? "F";
                    optemp.Grade6 = row1.ResultDetails[5].Grade ?? "F";
                    optemp.Grade7 = row1.ResultDetails[6].Grade ?? "F";
                    optemp.Grade8 = row2.ResultDetails[0].Grade ?? "F";
                    optemp.Grade9 = row2.ResultDetails[1].Grade ?? "F";
                    optemp.Grade10 = row2.ResultDetails[2].Grade ?? "F";
                    optemp.Grade11 = row2.ResultDetails[3].Grade ?? "F";
                    optemp.Grade12 = row2.ResultDetails[4].Grade ?? "F";
                    optemp.Grade13 = row2.ResultDetails[5].Grade ?? "F";
                    optemp.Grade14 = row2.ResultDetails[6].Grade ?? "F";
                    optemp.ExamRollno2 = await _context.ExamRegs.Where(i => i.RegNo == item && i.ExamLevel == 62 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.ExamRollno).FirstOrDefaultAsync();
                    optemp.ExamRollno3 = await _context.ExamRegs.Where(i => i.RegNo == item && i.ExamLevel == 63 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).Select(o => o.ExamRollno).FirstOrDefaultAsync();
                    var vm = await _context.VwMarksfinals.Where(i => i.ExamLevel == 63 && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && i.RegNo == item).ToListAsync();
                    optemp.Grade15 = vm.Where(o => o.SubId == 631).Select(i => i.Grade).FirstOrDefault() ?? row3.ResultDetails[0].Grade ?? "F";
                    optemp.Grade16 = vm.Where(o => o.SubId == 632).Select(i => i.Grade).FirstOrDefault() ?? row3.ResultDetails[1].Grade ?? "F";
                    optemp.Grade17 = vm.Where(o => o.SubId == 633).Select(i => i.Grade).FirstOrDefault() ?? row3.ResultDetails[2].Grade ?? "F";
                    //optemp.Grade15 = row3.ResultDetails[0].Grade ?? "F";
                    //optemp.Grade16 = row3.ResultDetails[1].Grade ?? "F";
                    //optemp.Grade17 = row3.ResultDetails[2].Grade ?? "F";
                    optemp.TotalNumberOfPass3 = optemp.Grade15 == "A" || optemp.Grade15 == "B" ? optemp.TotalNumberOfPass3 + 1 : optemp.TotalNumberOfPass3;
                    optemp.TotalNumberOfPass3 = optemp.Grade16 == "A" || optemp.Grade16 == "B" ? optemp.TotalNumberOfPass3 + 1 : optemp.TotalNumberOfPass3;
                    optemp.TotalNumberOfPass3 = optemp.Grade17 == "A" || optemp.Grade17 == "B" ? optemp.TotalNumberOfPass3 + 1 : optemp.TotalNumberOfPass3;

                    OutputForIntegratedTabulationSheet2 optemp2 = new();
                    optemp2.Root = item;
                    optemp2.Children = optemp;
                    outputs.Add(optemp2);
                    counter++;
                }

                if (outputs.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student found for given criteria for tripple integrated tabulation sheet",
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of students for " + examLevel1Name + ", " + examLevel2Name + " and " + examLevel3Name + ", " + monthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        Output = outputs
                    }
                });
            }
            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = "No student found for given criteria",
                Success = false,
                Payload = null
            });
        }


        private async Task<FormFillupModel24> GetLastExamMonthIdAndSessionYearAndRefNo(FormFillupModel26 input)
        {
            //int? query12 = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.RegNo == input.RegNo).MaxAsync(j => j.Ref);
            int? query1 = await _context.ExamRegs.Where(i => i.ExamLevel == input.ExamLevel && i.RegNo == input.RegNo).OrderByDescending(o => o.Ref).Select(j => j.Ref).FirstOrDefaultAsync();
            if (query1 != null && query1 != 0)
            {
                ExamReg query2 = await _context.ExamRegs.Where(i => i.Ref == query1).FirstOrDefaultAsync();
                if (query2 != null)
                {
                    FormFillupModel24 output = new();
                    output.MonthId = query2.MonthId;
                    output.SessionYear = query2.SessionYear;
                    output.RefNo = query2.Ref;
                    return output;
                }
            }
            return null;
        }

        private async Task<TabulationsControllerModel1> GetTabulationSheetForOneStudent(FormFillupModel25 input)
        {
            //System.Diagnostics.Debug.WriteLine("ongoing");
            if (input.ExamLevel < 1)
            {
                return null;
            }

            if (input.MonthId < 1)
            {
                return null;
            }

            if (input.SessionYear < 1)
            {
                return null;
            }

            Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (decodelog == null)
            {
                return null;
            }
            //System.Diagnostics.Debug.WriteLine("ongoing 100");
            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                return null;
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                return null;
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
            //System.Diagnostics.Debug.WriteLine("ongoing 200");
            List<FormFillupModel28> query = await (from ba in _context.Set<BarcodeAllot>()//.Where(ba => ba.Regno)
                                                   from s in _context.Set<Subject>().Where(s => ba.SubId == s.SubId)
                                                   from ma in _context.Set<MarksAllot>().Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.SubId == ma.SubId && ba.BarCode == ma.BarCode && ba.ExamLevel == input.ExamLevel && ba.MonthId == input.MonthId && ba.SessionYear == input.SessionYear)
                                                   where ba.RegNo == input.RegNo
                                                   select new FormFillupModel28
                                                   {
                                                       ExamRollno = ba.ExamRollno,
                                                       RegNo = ba.RegNo,
                                                       SubId = ba.SubId,
                                                       SubName = s.SubName,
                                                       BarCode = ba.BarCode,
                                                       Marks = ma.Marks,
                                                       Grade = ma.Grade
                                                   }).OrderBy(j => j.RegNo).ThenBy(i => i.SubId).ToListAsync();

            List<int?> exdata4 = await _context.SetExmpMous.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel).Select(j => j.ExmptSubid).Distinct().ToListAsync();

            List<int?> exdata5 = await _context.StudentOfIcmabAccas.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel).Select(j => j.SubId).Distinct().ToListAsync();

            foreach (var item in exdata4)
            {
                FormFillupModel28 ff = new();
                ff.RegNo = input.RegNo;
                ff.SubId = item;
                ff.SubName = subjects.Where(i => i.SubId == ff.SubId).Select(o => o.SubName).FirstOrDefault();
                ff.Grade = "ex";
                bool isExists = query.Any(i => i.RegNo == input.RegNo && i.SubId == item);
                if (isExists == false)
                {
                    query.Add(ff);
                }
            }

            foreach (var item in exdata5)
            {
                FormFillupModel28 ff = new();
                ff.RegNo = input.RegNo;
                ff.SubId = item;
                ff.SubName = subjects.Where(i => i.SubId == ff.SubId).Select(o => o.SubName).FirstOrDefault();
                ff.Grade = "ex";
                bool isExists = query.Any(i => i.RegNo == input.RegNo && i.SubId == item);
                if (isExists == false)
                {
                    query.Add(ff);
                }
            }

            if (query == null || query.Count == 0)
            {
                return null;
            }
            //System.Diagnostics.Debug.WriteLine("ongoing 300");
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
            //System.Diagnostics.Debug.WriteLine("ongoing 2");
            // ep, ex calculation

            if (input.ExamLevel == 61)
            {
                // ex

                var exdata = await (from er in _context.ExamRegs
                                    from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.RegNo == input.RegNo)
                                    orderby er.RegNo, es.SubId

                                    select new
                                    {
                                        RegNo = er.RegNo,
                                        //ExamRollno = x.ExamRollno,
                                        //SubId = b.SubId,
                                        //BarCode = b.BarCode,
                                        ExempSub = es.SubId
                                    }).ToListAsync();
                //
                //System.Diagnostics.Debug.WriteLine("ongoing 3");
                List<FormFillupModel6> exdata2 = await (from ba in _context.BarcodeAllots
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B")) //&& ba.RegNo == input.RegNo
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                List<FormFillupModel6> exdata3 = await (from ba in _context.BarcodeAllots
                                                        from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                                                        where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B")) //&& ba.RegNo == input.RegNo
                                                        select new FormFillupModel6
                                                        {
                                                            RegNo = ba.RegNo
                                                        }).ToListAsync();

                //List<int?> exdata4 = await _context.SetExmpMous.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel).Select(j => j.ExmptSubid).Distinct().ToListAsync();

                //List<int?> exdata5 = await _context.StudentOfIcmabAccas.Where(i => i.RegNo == input.RegNo && i.ExamLevel == input.ExamLevel).Select(j => j.SubId).Distinct().ToListAsync();

                //System.Diagnostics.Debug.WriteLine("4 count is " + exdata4.Count);
                //System.Diagnostics.Debug.WriteLine("5 count is " + exdata5.Count);
                //foreach (var item in exdata4)
                //{
                //    System.Diagnostics.Debug.WriteLine("ok go on: " + item);
                //}

                //foreach (var item in exdata5)
                //{
                //    System.Diagnostics.Debug.WriteLine("ok go on 2: " + item);
                //}

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

                        //if (exdata4.Contains(element.SubId))
                        //{
                        //    element.Grade = "ex";
                        //    continue;
                        //}

                        //if (exdata5.Contains(element.SubId))
                        //{
                        //    element.Grade = "ex";
                        //    continue;
                        //}
                    }
                }

                // ep

                var abc = await (from b in _context.BarcodeAllots
                                 join m in _context.MarksAllots
                                 on b.SessionYear equals m.SessionYear
                                 where b.MonthId == m.MonthId && b.SubId == m.SubId && b.BarCode == m.BarCode && (b.SessionYear < input.SessionYear || (b.SessionYear == input.SessionYear && b.MonthId < input.MonthId)) && (b.ExamLevel == 41 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B") && b.RegNo == input.RegNo
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
                                    where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear && er.RegNo == input.RegNo)
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
                           && (b.ExamLevel == 42 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B") && b.RegNo == input.RegNo
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
                           && (b.ExamLevel == 51 || b.ExamLevel == input.ExamLevel) && (m.Grade == "A" || m.Grade == "B") && (b.SubId != 512 || m.SubId != 512) && b.RegNo == input.RegNo
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
                return null;
            }

            if (output == null || output.Count == 0)
            {
                return null;
            }

            return output.FirstOrDefault();
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
                                                             .Where(i => i.RegNo == input.RegNo && (i.ExamLevel == 1 || i.ExamLevel == 2 || i.ExamLevel == 3 || i.ExamLevel == 41 || i.ExamLevel == 42 || i.ExamLevel == 51 || i.ExamLevel == 61 || i.ExamLevel == 62 || i.ExamLevel == 63) && (i.Grade == "A" || i.Grade == "B"))
                                                             .ToListAsync();
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

            //get grade: ex for 61 from setExmpMous
            List<int> sessionPriorityList = input.MonthId == 3 ? new List<int>() { 3 } : input.MonthId == 1 ? new List<int>() { 3, 1 } : input.MonthId == 2 ? new List<int>() { 3, 1, 2 } : new List<int>() { };
            List<SetExmpMou> setExmpMous61 = setExmpMous.Where(i => (i.RegNo == input.RegNo && i.ExamLevel == 61 && i.ExamYear < input.SessionYear) ||
                                                                    (i.RegNo == input.RegNo && i.ExamLevel == 61 && i.ExamYear == input.SessionYear && sessionPriorityList.Contains(i.ExamSession ?? 0))).ToList();
            if (setExmpMous61 != null && setExmpMous61.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output61.ResultDetails)
                {
                    SetExmpMou exmpMou = setExmpMous61.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 61 && i.ExmptSubid == item.SubId).FirstOrDefault();
                    if (exmpMou != null)
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

            //get grade: ex for 62 from setExmpMous
            List<int> sessionPriorityList2 = input.MonthId == 3 ? new List<int>() { 3 } : input.MonthId == 1 ? new List<int>() { 3, 1 } : input.MonthId == 2 ? new List<int>() { 3, 1, 2 } : new List<int>() { };
            List<SetExmpMou> setExmpMous62 = setExmpMous.Where(i => (i.RegNo == input.RegNo && i.ExamLevel == 62 && i.ExamYear < input.SessionYear) ||
                                                                    (i.RegNo == input.RegNo && i.ExamLevel == 62 && i.ExamYear == input.SessionYear && sessionPriorityList2.Contains(i.ExamSession ?? 0))).ToList();
            if (setExmpMous62 != null && setExmpMous62.Count > 0)
            {
                foreach (TabulationsControllerModel2 item in output62.ResultDetails)
                {
                    SetExmpMou exmpMou = setExmpMous62.Where(i => i.RegNo == input.RegNo && i.ExamLevel == 62 && i.ExmptSubid == item.SubId).FirstOrDefault();
                    if (exmpMou != null)
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

        private async Task<bool> Check63Fully(FormFillupModel7 inputs)
        {
            var checkSub_631_TrueOrEP = false;
            var checkSub_632_TrueOrEP = false;
            var checkSub_633_TrueOrEP = false;

            var result = false;

            foreach (var ottoke in inputs.AppearingInSubjects)
            {
                if (ottoke.SubId == 631 && (ottoke.ToBeAppeared == "true" || ottoke.ToBeAppeared == "ep"))
                {
                    checkSub_631_TrueOrEP = true;
                }
                if (ottoke.SubId == 632 && (ottoke.ToBeAppeared == "true" || ottoke.ToBeAppeared == "ep"))
                {
                    checkSub_632_TrueOrEP = true;
                }
                if (ottoke.SubId == 633 && (ottoke.ToBeAppeared == "true" || ottoke.ToBeAppeared == "ep"))
                {
                    checkSub_633_TrueOrEP = true;
                }
            }

            if (checkSub_631_TrueOrEP = true && checkSub_632_TrueOrEP == true && checkSub_633_TrueOrEP == true)
            {
                // 62 level pass block
                FormFillupModel4 sys = new FormFillupModel4();

                sys.RegNo = inputs.Input1.RegNo;
                sys.MonthId = inputs.Input1.MonthId;
                sys.SessionYear = inputs.Input1.SessionYear;
                //sys.ExamLevel = 61;

                var check61for63 = await GetLevelWiseDetailsResultForOneStudent(sys);

                var quickIsPassed = false;
                int? quickExamlevel = null;

                foreach (var items in check61for63)
                {
                    var elName = _context.Subjects.Where(g => g.SubId == items.ExamLevel).Select(x => x.SubName).FirstOrDefault();

                    quickExamlevel = items.ExamLevel;
                    quickIsPassed = items.IsExamLevelPassed;

                    if (items.IsExamLevelPassed == false && items.ExamLevel == 62)
                    {
                        result = true;
                        //System.Diagnostics.Debug.WriteLine("Barua" + items.ExamLevel);

                        //return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                        //{
                        //    Message = "RegNo: " + inputs.Input1.RegNo + " needs to pass Level: " + elName,
                        //    Success = false,
                        //    Payload = items
                        //});
                    }

                }
            }

            return result;
        }

        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        /// <summary>
        /// Get List Of Exam Forms To Approve
        /// </summary>
        [HttpPost("get-list-of-incomplete-payment-report")]
        public async Task<ActionResult<ResponseDto2>> GetListOfIncompletePaymentReport([FromBody] FormFillupModel9 input)
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

            bool examLevelFound = await _context.Subjects.AnyAsync(k => k.SubId == input.ExamLevel);

            if (examLevelFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level " + input.ExamLevel + " not found",
                    Success = false,
                    Payload = null
                });
            }

            bool monthFound = await _context.SessionInfos.AnyAsync(k => k.SessionId == input.MonthId);

            if (monthFound == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month id " + input.MonthId + " not found",
                    Success = false,
                    Payload = null
                });
            }

            List<OutputForGetListOfIncompletePaymentReport> output = await (from ter in _context.TempExamRegs.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear && o.Formsubmitstatus == -1 && o.Fapprove == 0)
                                                                            join sr1 in _context.StuReg1s
                                                                                on ter.RegNo equals sr1.RegNo
                                                                            select new OutputForGetListOfIncompletePaymentReport
                                                                            {
                                                                                SlNo = 0,
                                                                                FormNo = ter.FormNo,
                                                                                RegNo = ter.RegNo,
                                                                                RefNo = ter.Ref,
                                                                                MaintbRef = ter.MaintbRef,
                                                                                Name = sr1.Name,
                                                                                FName = sr1.FName,
                                                                                MName = sr1.MName,
                                                                                Exfeepayslipamt = ter.Exfeepayslipamt,
                                                                                Annfeepayslipamt = ter.Annfeepayslipamt
                                                                            }).OrderBy(i => i.FormNo).ToListAsync();

            if (output == null || output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Form Fill up data found for given criteria",
                    Success = false,
                    Payload = null
                });
            }

            int rowCount = 1;
            foreach (var item in output)
            {
                item.SlNo = rowCount;
                rowCount++;
            }

            bool isRowCountValid = output.Count > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "List of " + output.Count + " incomplete payment Form Fill up data" : "No unapproved form fillup data available. Something went wrong. Please try again later",
                Success = isRowCountValid,
                Payload = isRowCountValid ? output : null
            });
        }


        private static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents    
                        endStr = "Paisa " + endStr;//Cents    
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }

        private string GenerateFormNumber(string examLevelName, string monthName, string sessionYearName, int formNumberSerial)
        {
            string generatedFormNumber = examLevelName + monthName + sessionYearName + "-" + formNumberSerial.ToString();
            System.Diagnostics.Debug.WriteLine("Here is form number: " + generatedFormNumber);
            bool isExists = _context.TempExamRegs.Any(i => i.FormNo == generatedFormNumber);
            if (isExists == false)
            {
                return generatedFormNumber;
            }
            return GenerateFormNumber(examLevelName, monthName, sessionYearName, (formNumberSerial + 1));
        }
    }
}