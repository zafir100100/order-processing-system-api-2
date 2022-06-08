using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static ICABAPI.Data.MarksRepository;
using System.ComponentModel;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using DinkToPdf;
using ICABAPI.Data;
using System.IO;
using DinkToPdf.Contracts;

namespace ICABAPI.Controllers
{
    public class TabulationsControllerModel1
    {
        public int? ExamRollNo { get; set; }
        public int? RegNo { get; set; }
        public List<TabulationsControllerModel2> ResultDetails { get; set; }
        public decimal? TotalMarksAchieved { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel2
    {
        public int? SubId { get; set; }
        public string SubName { get; set; }
        public int? BarCode { get; set; }
        public decimal? Marks { get; set; }
        //[DefaultValue(null)]
        public string Grade { get; set; }
    }

    public class TabulationsControllerModel3
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        [DefaultValue(0)]
        public int NumberOfStudentPresent { get; set; }
        [DefaultValue(0)]
        public int NumberOfStudentPassed { get; set; }
        [DefaultValue(0)]
        public double PercentageOfStudentPassed { get; set; }
    }

    public class TabulationsControllerModel4
    {
        public int? SubId { get; set; }
        public string Status { get; set; }
    }

    public class TabulationsControllerModel5
    {
        public int? ExamRollNo { get; set; }
        public int? RegNo { get; set; }
        public List<TabulationsControllerModel4> ResultDetails { get; set; }
    }

    public class TabulationsControllerModel6
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        [DefaultValue(0)]
        public int NumberOfBarCode { get; set; }
        [DefaultValue(0)]
        public int NumberOfExempted { get; set; }
        [DefaultValue(0)]
        public int NumberOfEarlierPassed { get; set; }
        [DefaultValue(0)]
        public int NumberOfAbsent { get; set; }
    }

    public class TabulationsControllerModel7
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        // 1 for asc, 2 for desc
        [DefaultValue(null)]
        public int? SortByRollNumberOrder { get; set; }
        // 1 for asc, 2 for desc
        [DefaultValue(null)]
        public int? SortByRegistrationNumberOrder { get; set; }
        // 1 for asc, 2 for desc
        [DefaultValue(null)]
        public int? SortByTotalMarksAchievedOrder { get; set; }
        // 1 for encoded tabulation sheet
        [DefaultValue(null)]
        public int? EncodedTabulationSheetReport { get; set; }
        // 1 for tabulation sheet with name
        [DefaultValue(null)]
        public int? TabulationSheetWithNameReport { get; set; }
        // 1 for Grade Sheet All Subject Fail Report
        [DefaultValue(null)]
        public int? GradeSheetAllSubjectFailReport { get; set; }
        // 1 for Candidate Failed based on attempt Report
        [DefaultValue(null)]
        public int? CandidateFailedBasedOnAttemptReport { get; set; }
        // 1 for Candidate Failed based on attempt Report - number of subject choise
        [DefaultValue(null)]
        public int? CandidateFailedBasedOnAttempt { get; set; }
        // 1 for congratulation letter info Report
        [DefaultValue(null)]
        public int? CongratulationLetterInfoReport { get; set; }
        // 1 for Successful Examinee Address List Report Report
        [DefaultValue(null)]
        public int? SuccessfulExamineeAddressListReport { get; set; }
        // 1 for Candidate Failed With Partial Pass Report
        [DefaultValue(null)]
        public int? CandidateFailedWithPartialPassReport { get; set; }
        // 1 for Candidate with All Subject Fail Report
        [DefaultValue(null)]
        public int? CandidateFailedWithAllSubjectFailReport { get; set; }
        // 1 for Result Summary List Report
        [DefaultValue(null)]
        public int? SubjectPassedListReport { get; set; }
        // 1 for Result Summary List Report
        [DefaultValue(null)]
        public int? ResultSummaryListReport { get; set; }
        // 1 for Level wise result Summary list Report
        [DefaultValue(null)]
        public int? LevelWiseResultSummaryListReport { get; set; }
        // 1 for Rest of subject list Report
        [DefaultValue(null)]
        public int? RestOfSubjectListReport { get; set; }
        public int? RestOfSubjectListReportWithBarcode { get; set; }
        public int? AppearedPapers { get; set; }
        public int? PassedPapers { get; set; }
        // 1 for Number Of Completed Subject List Report
        [DefaultValue(null)]
        public int? NumberOfCompletedSubjectListReport { get; set; }
        public int? RegistrationNumberRange { get; set; }
        public int? RegistrationNumberFrom { get; set; }
        public int? RegistrationNumberTo { get; set; }
        public int? NumberOfCompletedSubjects { get; set; }
        // 1 for Number Of passed Subject List Report
        [DefaultValue(null)]
        public int? NumberOfPassedSubjectListReport { get; set; }
        public int? NumberOfPassedSubjects { get; set; }
        public int? NumberOfPassedSubjectListRegNoFrom { get; set; }
        public int? NumberOfPassedSubjectListRegNoTo { get; set; }
    }

    public class TabulationsControllerModel8
    {
        public string ExamRollNoHeading { get; set; }
        public string RegNoHeading { get; set; }
        public string Subject1Name { get; set; }
        public string Subject2Name { get; set; }
        public string Subject3Name { get; set; }
        public string Subject4Name { get; set; }
        public string Subject5Name { get; set; }
        public string Subject6Name { get; set; }
        public string Subject7Name { get; set; }
        public string TotalHeading { get; set; }
        public string Subject1ShortName { get; set; }
        public string Subject2ShortName { get; set; }
        public string Subject3ShortName { get; set; }
        public string Subject4ShortName { get; set; }
        public string Subject5ShortName { get; set; }
        public string Subject6ShortName { get; set; }
        public string Subject7ShortName { get; set; }
        public string SubPassedHeading { get; set; }
    }

    public class TabulationsControllerModel9
    {
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public int? Subject1Barcode { get; set; }
        public decimal? Subject1Marks { get; set; }
        public int? Subject2Barcode { get; set; }
        public decimal? Subject2Marks { get; set; }
        public int? Subject3Barcode { get; set; }
        public decimal? Subject3Marks { get; set; }
        public int? Subject4Barcode { get; set; }
        public decimal? Subject4Marks { get; set; }
        public int? Subject5Barcode { get; set; }
        public decimal? Subject5Marks { get; set; }
        public int? Subject6Barcode { get; set; }
        public decimal? Subject6Marks { get; set; }
        public int? Subject7Barcode { get; set; }
        public decimal? Subject7Marks { get; set; }
        public decimal? TotalMarksAchieved { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public string Subject4Grade { get; set; }
        public string Subject5Grade { get; set; }
        public string Subject6Grade { get; set; }
        public string Subject7Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel10
    {
        public string ExamRollNoHeading { get; set; }
        public string RegNoHeading { get; set; }
        public string Subject1Name { get; set; }
        public string Subject2Name { get; set; }
        public string Subject3Name { get; set; }
        public string TotalHeading { get; set; }
        public string Subject1ShortName { get; set; }
        public string Subject2ShortName { get; set; }
        public string Subject3ShortName { get; set; }
        public string SubPassedHeading { get; set; }
    }

    public class TabulationsControllerModel11
    {
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public int? Subject1Barcode { get; set; }
        public decimal? Subject1Marks { get; set; }
        public int? Subject2Barcode { get; set; }
        public decimal? Subject2Marks { get; set; }
        public int? Subject3Barcode { get; set; }
        public decimal? Subject3Marks { get; set; }
        public decimal? TotalMarksAchieved { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel12
    {
        public int Subject1Present { get; set; }
        public int Subject2Present { get; set; }
        public int Subject3Present { get; set; }
        public int Subject4Present { get; set; }
        public int Subject5Present { get; set; }
        public int Subject6Present { get; set; }
        public int Subject7Present { get; set; }
        public int Subject1Pass { get; set; }
        public int Subject2Pass { get; set; }
        public int Subject3Pass { get; set; }
        public int Subject4Pass { get; set; }
        public int Subject5Pass { get; set; }
        public int Subject6Pass { get; set; }
        public int Subject7Pass { get; set; }
        public double Subject1Percentage { get; set; }
        public double Subject2Percentage { get; set; }
        public double Subject3Percentage { get; set; }
        public double Subject4Percentage { get; set; }
        public double Subject5Percentage { get; set; }
        public double Subject6Percentage { get; set; }
        public double Subject7Percentage { get; set; }
    }

    public class TabulationsControllerModel13
    {
        public int Subject1Present { get; set; }
        public int Subject2Present { get; set; }
        public int Subject3Present { get; set; }
        public int Subject1Pass { get; set; }
        public int Subject2Pass { get; set; }
        public int Subject3Pass { get; set; }
        public double Subject1Percentage { get; set; }
        public double Subject2Percentage { get; set; }
        public double Subject3Percentage { get; set; }
    }

    public class TabulationsControllerModel14
    {
        public int SlNo { get; set; }
        public int? Subject1Barcode { get; set; }
        public decimal? Subject1Marks { get; set; }
        public int? Subject2Barcode { get; set; }
        public decimal? Subject2Marks { get; set; }
        public int? Subject3Barcode { get; set; }
        public decimal? Subject3Marks { get; set; }
        public int? Subject4Barcode { get; set; }
        public decimal? Subject4Marks { get; set; }
        public int? Subject5Barcode { get; set; }
        public decimal? Subject5Marks { get; set; }
        public int? Subject6Barcode { get; set; }
        public decimal? Subject6Marks { get; set; }
        public int? Subject7Barcode { get; set; }
        public decimal? Subject7Marks { get; set; }
        public decimal? TotalMarksAchieved { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public string Subject4Grade { get; set; }
        public string Subject5Grade { get; set; }
        public string Subject6Grade { get; set; }
        public string Subject7Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel15
    {
        public int SlNo { get; set; }
        public int? Subject1Barcode { get; set; }
        public decimal? Subject1Marks { get; set; }
        public int? Subject2Barcode { get; set; }
        public decimal? Subject2Marks { get; set; }
        public int? Subject3Barcode { get; set; }
        public decimal? Subject3Marks { get; set; }
        public decimal? TotalMarksAchieved { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel16
    {
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public string Subject4Grade { get; set; }
        public string Subject5Grade { get; set; }
        public string Subject6Grade { get; set; }
        public string Subject7Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel17
    {
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel18
    {
        public int? ExamRollNo { get; set; }
        public int? RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public List<TabulationsControllerModel2> ResultDetails { get; set; }
    }

    public class TabulationsControllerModel19
    {
        public int SlNo { get; set; }
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public int TotalNoOfPass { get; set; }

        //public string Subject1Grade { get; set; }
        //public string Subject2Grade { get; set; }
        //public string Subject3Grade { get; set; }
        //public string Subject4Grade { get; set; }
        //public string Subject5Grade { get; set; }
        //public string Subject6Grade { get; set; }
        //public string Subject7Grade { get; set; }
    }

    public class TabulationsControllerModel20
    {
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
    }

    public class TabulationsControllerModel21
    {
        public int RegNo { get; set; }
    }

    public class TabulationsControllerModel122
    {
        public string ExamLevelName { get; set; }
        public string MonthName { get; set; }
        public string ExamCenterName { get; set; }
        public int? ExamRollNo { get; set; }
        public int? RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
    }

    public class TabulationsControllerModel23
    {
        public int SlNo { get; set; }
        public int RegNo { get; set; }
        public int ExamRollNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string PreAddress { get; set; }
        public string Cell { get; set; }
    }

    public class TabulationsControllerModel24
    {
        public int SlNo { get; set; }
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public string Subject4Grade { get; set; }
        public string Subject5Grade { get; set; }
        public string Subject6Grade { get; set; }
        public string Subject7Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel25
    {
        public int SlNo { get; set; }
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Subject1Grade { get; set; }
        public string Subject2Grade { get; set; }
        public string Subject3Grade { get; set; }
        public int TotalNoOfPass { get; set; }
    }

    public class TabulationsControllerModel26
    {
        public int SlNo { get; set; }
        public int RegNo { get; set; }
        public int ExamRollNo { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public int NumberOfPassedSubjects { get; set; }
    }

    public class TabulationsControllerModel27
    {
        public string NumberOfPapers { get; set; }
        public int? Total7PapersPassed { get; set; }
        public int? Total6PapersPassed { get; set; }
        public int? Total5PapersPassed { get; set; }
        public int? Total4PapersPassed { get; set; }
        public int? Total3PapersPassed { get; set; }
        public int? Total2PapersPassed { get; set; }
        public int? Total1PapersPassed { get; set; }
        public int? Total0PapersPassed { get; set; }
        public int? TotalPassed { get; set; }
        public int? TotalStudent { get; set; }
    }

    public class TabulationsControllerModel28
    {
        public string NumberOfPapers { get; set; }
        public int? Total3PapersPassed { get; set; }
        public int? Total2PapersPassed { get; set; }
        public int? Total1PapersPassed { get; set; }
        public int? Total0PapersPassed { get; set; }
        public int? TotalPassed { get; set; }
        public int? TotalStudent { get; set; }
    }


    public class TabulationsControllerModel29
    {
        public int SlNo { get; set; }
        public int ExamRollNo { get; set; }
        public int RegNo { get; set; }
        //public string Name { get; set; }
        //public string FName { get; set; }
        public int DuePapers { get; set; }
        public int EpPapers { get; set; }
        public int ExPapers { get; set; }
        //public string Subject1Grade { get; set; }
        //public string Subject2Grade { get; set; }
        //public string Subject3Grade { get; set; }
        //public string Subject4Grade { get; set; }
        //public string Subject5Grade { get; set; }
        //public string Subject6Grade { get; set; }
        //public string Subject7Grade { get; set; }
    }

    public class TabulationsControllerModel30
    {
        public int SlNo { get; set; }
        public int RegNo { get; set; }
        public int ExamRollNo { get; set; }

    }


    public class TabulationsControllerModel31
    {
        public int CenId { get; set; }
        public int Total { get; set; }
    }

    public class TabulationsControllerModel32
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public List<TabulationsControllerModel31> CenterDetails { get; set; }
        public int Total { get; set; }
    }

    public class TabulationsControllerModel33
    {
        public int ExamLevel { get; set; }
        public string ExamLevelName { get; set; }
        public List<TabulationsControllerModel32> ExamLevelDetails { get; set; }
        public List<TabulationsControllerModel31> FirstRow { get; set; }
        public int FirstRowTotal { get; set; }
        public List<TabulationsControllerModel31> SecondRow { get; set; }
        public int SecondRowTotal { get; set; }
    }

    public class TabulationsControllerModel34
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
    }

    public class TabulationsControllerModel35
    {
        public int RegNo { get; set; }
        public int? ExempSub { get; set; }
    }

    public class InputForNumberOfCompletedSubjectsReport
    {
        public int ExamLevel { get; set; }
        public int MonthId { get; set; }
        public int SessionYear { get; set; }
        public int NumberOfCompletedSubjects { get; set; }
        public int? RegNoFrom { get; set; }
        public int? RegNoTo { get; set; }

    }

    public class OutputForNumberOfCompletedSubjectsReport
    {
        public int SlNo { get; set; }
        public int RegNo { get; set; }
        public int ExamRollno { get; set; }

    }

    //[Authorize]
    public class TabulationsController : CustomType1ApiController
    {
        private readonly ModelContext _context;
        private readonly ITabulationRepository _tabulationRepository;

        private readonly IConverter _converter;

        public TabulationsController(IConverter converter, ModelContext context, ITabulationRepository tabulationRepository)
        {
            _converter = converter;
            _context = context;
            _tabulationRepository = tabulationRepository;
        }

        /// <summary>
        /// Get Decoder Status
        /// </summary>
        [HttpPost("GetDecoderStatus")]
        public async Task<ActionResult<ResponseDto2>> GetDecoderStatus([FromBody] TabulationsControllerModel34 input)
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

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            bool isRowCountValid = decodelog != null;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status200OK, new ResponseDto2
            {
                Message = isRowCountValid ? "Decode has already been done for " + GetExamLevelName + ", " + GetMonthName + ", " + input.SessionYear : "Decoder log not found.",
                Success = isRowCountValid,
                Payload = null
            });
        }


        [HttpPost("GTSSingle")]
        public async Task<ActionResult<ResponseDto2>> GTSSingle([FromBody] TabulationsControllerModel88 input)
        {



            var Payload = await _tabulationRepository.GetSingleCongratulationLetters(input);
            return Ok(Payload);

        }


        [HttpPost("pdfCreate")]
        public async Task<IActionResult> CreatePdf([FromBody] TabulationsControllerModel7 input)
        {
            var data = await _tabulationRepository.GetCongratulationLetters(input);
            // var  data2 = await _context.BarcodeAllots.Where(a =>a.ExamLevel==61 && a.SessionYear==2019 && a.MonthId==1 && a.RegNo==input.RegNo).ToListAsync();
            //    var p = data2.Select(s => new TabulationsControllerModel88{
            //       RegNo =(int)s.RegNo,
            //       SessionYear=(int)s.SessionYear,
            //       MonthId=(int)s.MonthId,
            //       ExamLevel=(int)s.MonthId

            //    }).ToList();
            //var m = data2.Select(s =>s.RegNo);
            List<ObjectSettings> objects = new();
            foreach (var i in data)
            {
                objects.Add(new ObjectSettings()
                {
                    HtmlContent = _tabulationRepository.GetHtml(i),
                    // HtmlContent = _pdfGenerator.GetHtml(i.MemId),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    // Page = detailUrl,
                    PagesCount = true,
                    //  WebSettings = { DefaultEncoding = "utf-8"  },
                    FooterSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                });
            }
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    DocumentTitle = $"Report - {DateTime.Today.Year}",
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Landscape,
                    Out = @"D:\PDFCreator\Member_Report.pdf"
                }
            };
            foreach (var objectSetting in objects)
            {
                doc.Objects.Add(objectSetting);
            }

            //  byte[] pdf = _converter.Convert(doc);

            var file = _converter.Convert(doc);
            // return File(file, "application/pdf");
            //var file = _converter.Convert(pdf);
            return Ok("Successfully Downloaded PDF document.");

        }

        [HttpPost("GTS")]
        public async Task<ActionResult<ResponseDto2>> GTS([FromBody] TabulationsControllerModel7 input)
        {

            //var h = await _tabulationRepository.GetTabulationSheet(input);

            //if (input.ExamLevel < 1)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            //    {
            //        Message = "Exam level can not be null",
            //        Success = false,
            //        Payload = null
            //    });
            //}

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Just a test route",
                Success = true,
                Payload = await _tabulationRepository.GetCongratulationLetters(input)
            });
        }

        /// <summary>
        /// Create Decode Log
        /// </summary>
        [HttpPost("CreateDecodeLog")]
        public async Task<ActionResult<ResponseDto2>> CreateDecodeLog([FromBody] Decodelog input)
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

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
            }

            _context.Decodelogs.Add(input);
            int rowCount = await _context.SaveChangesAsync();

            bool isRowCountValid = rowCount > 0;

            return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isRowCountValid ? "Decoder log creation successful" : "Decoder log creation failed. Something went wrong. Please try again later.",
                Success = isRowCountValid,
                Payload = null
            });
        }

        /// <summary>
        /// Get Tabulation Sheet Report (All types depending on flag)
        /// </summary>
        [HttpPost("GetTabulationSheet")]

        public async Task<ActionResult<ResponseDto2>> GetTabulationSheet([FromBody] TabulationsControllerModel7 input)
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

            Signature signature = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            Decodelog decodelog = await _context.Decodelogs.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).FirstOrDefaultAsync();

            if (decodelog == null && input.EncodedTabulationSheetReport != 1 && input.ResultSummaryListReport != 1 && input.LevelWiseResultSummaryListReport != 1 && input.NumberOfPassedSubjectListReport != 1)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Decoding of result of this session has not yet been done. Please decode first for decoding option",
                    Success = false,
                    Payload = null
                });
            }

            string GetExamLevelName = await _context.Subjects.Where(i => i.SubId == input.ExamLevel).Select(o => o.SubName).FirstOrDefaultAsync();
            if (GetExamLevelName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Exam level name not found for exam level: " + input.ExamLevel,
                    Success = false,
                    Payload = null
                });
            }

            string GetMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(p => p.SessionName).FirstOrDefaultAsync();
            if (GetMonthName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "Month name not found for month id: " + input.MonthId,
                    Success = false,
                    Payload = null
                });
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
            //decimal valueZero = 0;
            //decimal valueOne = 1;
            List<int> sessionPriorityList = input.MonthId == 3 ? new List<int>() { 3 } : input.MonthId == 1 ? new List<int>() { 3, 1 } : input.MonthId == 2 ? new List<int>() { 3, 1, 2 } : new List<int>() { };
            List<int> sessionPriorityList2 = input.MonthId == 3 ? new List<int>() { 3 } : input.MonthId == 1 ? new List<int>() { 3, 1 } : input.MonthId == 2 ? new List<int>() { 3, 1, 2 } : new List<int>() { };
            List<int> expelledCase = await _context.StudentExpelleds.Where(i => i.Status == "Active" &&
                                                        ((i.ExamLevel == input.ExamLevel && i.YearFrom < input.SessionYear) ||
                                                          (i.ExamLevel == input.ExamLevel && i.YearFrom == input.SessionYear && sessionPriorityList.Contains(i.SessionFrom ?? 0)))).Select(i => i.RegNo ?? 0).OrderBy(i => i).ToListAsync();
            //List<int> canceledcase = await _context.StuCancels.Where(i => i.CwFlag == valueOne &&
            //                                ((i.ExamLevel == input.ExamLevel && i.SessionYear < input.SessionYear) ||
            //                                  (i.ExamLevel == input.ExamLevel && i.SessionYear == input.SessionYear && sessionPriorityList2.Contains(i.MonthId ?? 0)))).Select(i => i.RegNo).OrderBy(i => i).ToListAsync();
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
            if (expelledCase.Count > 0)
            {
                foreach (var item in expelledCase)
                {
                    var stuffToRemove = query.FirstOrDefault(s => s.RegNo == item);
                    if (stuffToRemove != null)
                    {
                        query.Remove(stuffToRemove);
                    }
                }
            }

            //if (canceledcase.Count > 0)
            //{
            //    foreach (var item in canceledcase)
            //    {
            //        var stuffToRemove = query.FirstOrDefault(s => s.RegNo == (int)item);
            //        if (stuffToRemove != null)
            //        {
            //            query.Remove(stuffToRemove);
            //        }
            //    }
            //}

            //didnt work
            //List<int> sc = await _context.StuCancels.Where(i => i.CwFlag == 0).Select(i => (int)i.RegNo).OrderBy(i => i).ToListAsync();
            //foreach (var item in query)
            //{
            //    if (sc.Contains(item.RegNo ?? 0))
            //    {
            //        query.Remove(item);
            //    }
            //}

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

            List<VwMarksfinal> ViewMarksfor61 = input.ExamLevel != 61 ? null : await _context.VwMarksfinals.Where(i => (i.ExamLevel == 61 || i.ExamLevel == 41) && (i.Grade == "A" || i.Grade == "B"))
                     .ToListAsync();
            List<VwMarksfinal> ViewMarksfor62 = input.ExamLevel != 62 ? null : await _context.VwMarksfinals.Where(i => (i.ExamLevel == 62 || i.ExamLevel == 42) && (i.Grade == "A" || i.Grade == "B"))
                                                             .ToListAsync();

            if (input.ExamLevel == 61)
            {
                // ex
                Task<List<TabulationsControllerModel35>> task1 =
                    (from er in _context.ExamRegs
                     from es in _context.ExemptedSubs.Where(es => er.RegNo == es.RegNo && er.ExamLevel == es.ExamLevel)
                     where (er.ExamLevel == input.ExamLevel && er.MonthId == input.MonthId && er.SessionYear == input.SessionYear)
                     orderby er.RegNo, es.SubId

                     select new TabulationsControllerModel35
                     {
                         RegNo = er.RegNo,
                         //ExamRollno = x.ExamRollno,
                         //SubId = b.SubId,
                         //BarCode = b.BarCode,
                         ExempSub = es.SubId
                     }).ToListAsync();

                Task<List<FormFillupModel6>> task2 =
                    (from ba in _context.BarcodeAllots
                     from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                     where (ba.ExamLevel == 2 && ba.SubId == 21 && (ma.Grade == "A" || ma.Grade == "B"))
                     select new FormFillupModel6
                     {
                         RegNo = ba.RegNo
                     }).ToListAsync();

                Task<List<FormFillupModel6>> task3 =
                    (from ba in _context.BarcodeAllots
                     from ma in _context.MarksAllots.Where(ma => ba.MonthId == ma.MonthId && ba.SessionYear == ma.SessionYear && ba.BarCode == ma.BarCode && ba.SubId == ma.SubId)
                     where (ba.ExamLevel == 1 && ba.SubId == 16 && (ma.Grade == "A" || ma.Grade == "B"))
                     select new FormFillupModel6
                     {
                         RegNo = ba.RegNo
                     }).ToListAsync();

                await Task.WhenAll(task1, task2, task3);

                List<TabulationsControllerModel35> exdata = task1.Result;

                List<FormFillupModel6> exdata2 = task2.Result;

                List<FormFillupModel6> exdata3 = task3.Result;

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

                //foreach (var item in output.Where(i => i.RegNo == 24111).Select(o => o.ResultDetails).FirstOrDefault())
                //{
                //    System.Diagnostics.Debug.WriteLine("Sub id : " + item.SubId + " " + "grade: " + item.Grade);
                //}
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

                Parallel.ForEach(output, item =>
                {
                    Parallel.ForEach(item.ResultDetails, element =>
                    {
                        var tempop4 = exdata.Where(i => i.RegNo == item.RegNo && i.ExempSub == element.SubId).FirstOrDefault();

                        if (tempop4 != null)
                        {
                            element.Grade = "ex";
                            return;
                        }

                        if (element.SubId == 622)
                        {
                            var tempop5 = exresult.Where(i => i.RegNo == item.RegNo && i.SubId == element.SubId).FirstOrDefault();

                            if (tempop5 != null)
                            {
                                element.Grade = "ex";
                                return;
                            }
                        }

                        if (element.SubId == 627)
                        {
                            bool isInExData3 = exdata3.Any(i => i.RegNo == item.RegNo);

                            if (isInExData3 == true)
                            {
                                element.Grade = "ex";
                                return;
                            }
                        }
                    });
                });

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

            foreach (var item in subjectDetails) //Parallel.ForEach(subjectDetails, item =>
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

            if (output == null || output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No tabulation sheet details found for given criteria",
                    Success = false,
                    Payload = null
                });
            }
            //7.9.3
            if (input.SortByRollNumberOrder == 1)
            {
                output = output.OrderBy(l => l.ExamRollNo).ToList();
            }
            //7.9.4
            else if (input.SortByRollNumberOrder == 2)
            {
                output = output.OrderByDescending(l => l.ExamRollNo).ToList();
            }

            //7.8.1
            if (input.SortByRegistrationNumberOrder == 1)
            {
                output = output.OrderBy(l => l.RegNo).ToList();
            }
            //7.8.1
            else if (input.SortByRegistrationNumberOrder == 2)
            {
                output = output.OrderByDescending(l => l.RegNo).ToList();
            }

            if (input.SortByTotalMarksAchievedOrder == 1)
            {
                output = output.OrderBy(l => l.TotalMarksAchieved).ToList();
            }
            else if (input.SortByTotalMarksAchievedOrder == 2)
            {
                output = output.OrderByDescending(l => l.TotalMarksAchieved).ToList();
            }

            Dictionary<int, string> subjectIdVsShortName = new();
            subjectIdVsShortName.Add(611, "As");
            subjectIdVsShortName.Add(612, "Ac");
            subjectIdVsShortName.Add(613, "BF");
            subjectIdVsShortName.Add(614, "MI");
            subjectIdVsShortName.Add(615, "PT");
            subjectIdVsShortName.Add(616, "BL");
            subjectIdVsShortName.Add(617, "IT");
            subjectIdVsShortName.Add(621, "AA");
            subjectIdVsShortName.Add(622, "FAR");
            subjectIdVsShortName.Add(623, "BS");
            subjectIdVsShortName.Add(624, "FM");
            subjectIdVsShortName.Add(625, "Tax");
            subjectIdVsShortName.Add(626, "CLP");
            subjectIdVsShortName.Add(627, "ITG");
            subjectIdVsShortName.Add(631, "CR");
            subjectIdVsShortName.Add(632, "SBM");
            subjectIdVsShortName.Add(633, "CS");

            TabulationsControllerModel8 heading = new();
            List<TabulationsControllerModel9> results = new();
            TabulationsControllerModel10 headingType2 = new();
            List<TabulationsControllerModel11> resultsType2 = new();
            TabulationsControllerModel12 statistics = new();
            TabulationsControllerModel13 statisticsType2 = new();

            if (input.ExamLevel == 61)
            {
                heading.ExamRollNoHeading = "Roll No.";
                heading.RegNoHeading = "Reg. No.";
                heading.Subject1Name = subjects.Where(i => i.SubId == 611).Select(o => o.SubName).FirstOrDefault();
                heading.Subject2Name = subjects.Where(i => i.SubId == 612).Select(o => o.SubName).FirstOrDefault();
                heading.Subject3Name = subjects.Where(i => i.SubId == 613).Select(o => o.SubName).FirstOrDefault();
                heading.Subject4Name = subjects.Where(i => i.SubId == 614).Select(o => o.SubName).FirstOrDefault();
                heading.Subject5Name = subjects.Where(i => i.SubId == 615).Select(o => o.SubName).FirstOrDefault();
                heading.Subject6Name = subjects.Where(i => i.SubId == 616).Select(o => o.SubName).FirstOrDefault();
                heading.Subject7Name = subjects.Where(i => i.SubId == 617).Select(o => o.SubName).FirstOrDefault();
                heading.TotalHeading = "Total";
                heading.Subject1ShortName = subjectIdVsShortName[611];
                heading.Subject2ShortName = subjectIdVsShortName[612];
                heading.Subject3ShortName = subjectIdVsShortName[613];
                heading.Subject4ShortName = subjectIdVsShortName[614];
                heading.Subject5ShortName = subjectIdVsShortName[615];
                heading.Subject6ShortName = subjectIdVsShortName[616];
                heading.Subject7ShortName = subjectIdVsShortName[617];
                heading.SubPassedHeading = "Sub Passed";

                foreach (var item in output)
                {
                    TabulationsControllerModel9 tempOutput1 = new();

                    tempOutput1.ExamRollNo = item.ExamRollNo ?? 0;
                    tempOutput1.RegNo = item.RegNo ?? 0;

                    tempOutput1.Subject1Barcode = item.ResultDetails.Where(o => o.SubId == 611).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject1Marks = item.ResultDetails.Where(o => o.SubId == 611).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject2Barcode = item.ResultDetails.Where(o => o.SubId == 612).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject2Marks = item.ResultDetails.Where(o => o.SubId == 612).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject3Barcode = item.ResultDetails.Where(o => o.SubId == 613).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject3Marks = item.ResultDetails.Where(o => o.SubId == 613).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject4Barcode = item.ResultDetails.Where(o => o.SubId == 614).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject4Marks = item.ResultDetails.Where(o => o.SubId == 614).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject5Barcode = item.ResultDetails.Where(o => o.SubId == 615).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject5Marks = item.ResultDetails.Where(o => o.SubId == 615).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject6Barcode = item.ResultDetails.Where(o => o.SubId == 616).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject6Marks = item.ResultDetails.Where(o => o.SubId == 616).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject7Barcode = item.ResultDetails.Where(o => o.SubId == 617).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject7Marks = item.ResultDetails.Where(o => o.SubId == 617).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.TotalMarksAchieved = item.TotalMarksAchieved;

                    tempOutput1.Subject1Grade = item.ResultDetails.Where(o => o.SubId == 611).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject2Grade = item.ResultDetails.Where(o => o.SubId == 612).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject3Grade = item.ResultDetails.Where(o => o.SubId == 613).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject4Grade = item.ResultDetails.Where(o => o.SubId == 614).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject5Grade = item.ResultDetails.Where(o => o.SubId == 615).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject6Grade = item.ResultDetails.Where(o => o.SubId == 616).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject7Grade = item.ResultDetails.Where(o => o.SubId == 617).Select(b => b.Grade).FirstOrDefault();

                    tempOutput1.TotalNoOfPass = item.TotalNoOfPass;

                    results.Add(tempOutput1);
                }

                statistics.Subject1Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 611 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject2Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 612 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject3Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 613 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject4Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 614 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject5Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 615 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject6Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 616 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject7Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 617 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);

                statistics.Subject1Pass = subjectDetails.Where(i => i.SubId == 611).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject2Pass = subjectDetails.Where(i => i.SubId == 612).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject3Pass = subjectDetails.Where(i => i.SubId == 613).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject4Pass = subjectDetails.Where(i => i.SubId == 614).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject5Pass = subjectDetails.Where(i => i.SubId == 615).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject6Pass = subjectDetails.Where(i => i.SubId == 616).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject7Pass = subjectDetails.Where(i => i.SubId == 617).Select(o => o.NumberOfStudentPassed).FirstOrDefault();

                statistics.Subject1Percentage = subjectDetails.Where(i => i.SubId == 611).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject2Percentage = subjectDetails.Where(i => i.SubId == 612).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject3Percentage = subjectDetails.Where(i => i.SubId == 613).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject4Percentage = subjectDetails.Where(i => i.SubId == 614).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject5Percentage = subjectDetails.Where(i => i.SubId == 615).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject6Percentage = subjectDetails.Where(i => i.SubId == 616).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject7Percentage = subjectDetails.Where(i => i.SubId == 617).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
            }

            else if (input.ExamLevel == 62)
            {
                heading.ExamRollNoHeading = "Roll No.";
                heading.RegNoHeading = "Reg. No.";
                heading.Subject1Name = subjects.Where(i => i.SubId == 621).Select(o => o.SubName).FirstOrDefault();
                heading.Subject2Name = subjects.Where(i => i.SubId == 622).Select(o => o.SubName).FirstOrDefault();
                heading.Subject3Name = subjects.Where(i => i.SubId == 623).Select(o => o.SubName).FirstOrDefault();
                heading.Subject4Name = subjects.Where(i => i.SubId == 624).Select(o => o.SubName).FirstOrDefault();
                heading.Subject5Name = subjects.Where(i => i.SubId == 625).Select(o => o.SubName).FirstOrDefault();
                heading.Subject6Name = subjects.Where(i => i.SubId == 626).Select(o => o.SubName).FirstOrDefault();
                heading.Subject7Name = subjects.Where(i => i.SubId == 627).Select(o => o.SubName).FirstOrDefault();
                heading.TotalHeading = "Total";
                heading.Subject1ShortName = subjectIdVsShortName[621];
                heading.Subject2ShortName = subjectIdVsShortName[622];
                heading.Subject3ShortName = subjectIdVsShortName[623];
                heading.Subject4ShortName = subjectIdVsShortName[624];
                heading.Subject5ShortName = subjectIdVsShortName[625];
                heading.Subject6ShortName = subjectIdVsShortName[626];
                heading.Subject7ShortName = subjectIdVsShortName[627];
                heading.SubPassedHeading = "Sub Passed";

                foreach (var item in output)
                {
                    TabulationsControllerModel9 tempOutput1 = new();

                    tempOutput1.ExamRollNo = item.ExamRollNo ?? 0;
                    tempOutput1.RegNo = item.RegNo ?? 0;

                    tempOutput1.Subject1Barcode = item.ResultDetails.Where(o => o.SubId == 621).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject1Marks = item.ResultDetails.Where(o => o.SubId == 621).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject2Barcode = item.ResultDetails.Where(o => o.SubId == 622).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject2Marks = item.ResultDetails.Where(o => o.SubId == 622).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject3Barcode = item.ResultDetails.Where(o => o.SubId == 623).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject3Marks = item.ResultDetails.Where(o => o.SubId == 623).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject4Barcode = item.ResultDetails.Where(o => o.SubId == 624).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject4Marks = item.ResultDetails.Where(o => o.SubId == 624).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject5Barcode = item.ResultDetails.Where(o => o.SubId == 625).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject5Marks = item.ResultDetails.Where(o => o.SubId == 625).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject6Barcode = item.ResultDetails.Where(o => o.SubId == 626).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject6Marks = item.ResultDetails.Where(o => o.SubId == 626).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject7Barcode = item.ResultDetails.Where(o => o.SubId == 627).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject7Marks = item.ResultDetails.Where(o => o.SubId == 627).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.TotalMarksAchieved = item.TotalMarksAchieved;

                    tempOutput1.Subject1Grade = item.ResultDetails.Where(o => o.SubId == 621).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject2Grade = item.ResultDetails.Where(o => o.SubId == 622).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject3Grade = item.ResultDetails.Where(o => o.SubId == 623).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject4Grade = item.ResultDetails.Where(o => o.SubId == 624).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject5Grade = item.ResultDetails.Where(o => o.SubId == 625).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject6Grade = item.ResultDetails.Where(o => o.SubId == 626).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject7Grade = item.ResultDetails.Where(o => o.SubId == 627).Select(b => b.Grade).FirstOrDefault();

                    tempOutput1.TotalNoOfPass = item.TotalNoOfPass;

                    results.Add(tempOutput1);
                }

                statistics.Subject1Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 621 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject2Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 622 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject3Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 623 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject4Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 624 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject5Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 625 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject6Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 626 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);
                statistics.Subject7Present = await _context.VwMarksfinals.CountAsync(i => i.SubId == 627 && i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear);

                statistics.Subject1Pass = subjectDetails.Where(i => i.SubId == 621).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject2Pass = subjectDetails.Where(i => i.SubId == 622).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject3Pass = subjectDetails.Where(i => i.SubId == 623).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject4Pass = subjectDetails.Where(i => i.SubId == 624).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject5Pass = subjectDetails.Where(i => i.SubId == 625).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject6Pass = subjectDetails.Where(i => i.SubId == 626).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statistics.Subject7Pass = subjectDetails.Where(i => i.SubId == 627).Select(o => o.NumberOfStudentPassed).FirstOrDefault();

                statistics.Subject1Percentage = subjectDetails.Where(i => i.SubId == 621).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject2Percentage = subjectDetails.Where(i => i.SubId == 622).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject3Percentage = subjectDetails.Where(i => i.SubId == 623).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject4Percentage = subjectDetails.Where(i => i.SubId == 624).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject5Percentage = subjectDetails.Where(i => i.SubId == 625).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject6Percentage = subjectDetails.Where(i => i.SubId == 626).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statistics.Subject7Percentage = subjectDetails.Where(i => i.SubId == 627).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
            }

            else if (input.ExamLevel == 63)
            {
                headingType2.ExamRollNoHeading = "Roll No.";
                headingType2.RegNoHeading = "Reg. No.";
                headingType2.Subject1Name = subjects.Where(i => i.SubId == 631).Select(o => o.SubName).FirstOrDefault();
                headingType2.Subject2Name = subjects.Where(i => i.SubId == 632).Select(o => o.SubName).FirstOrDefault();
                headingType2.Subject3Name = subjects.Where(i => i.SubId == 633).Select(o => o.SubName).FirstOrDefault();
                headingType2.TotalHeading = "Total";
                headingType2.Subject1ShortName = subjectIdVsShortName[631];
                headingType2.Subject2ShortName = subjectIdVsShortName[632];
                headingType2.Subject3ShortName = subjectIdVsShortName[633];
                headingType2.SubPassedHeading = "Sub Passed";

                foreach (var item in output)
                {
                    TabulationsControllerModel11 tempOutput1 = new();

                    tempOutput1.ExamRollNo = item.ExamRollNo ?? 0;
                    tempOutput1.RegNo = item.RegNo ?? 0;

                    tempOutput1.Subject1Barcode = item.ResultDetails.Where(o => o.SubId == 631).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject1Marks = item.ResultDetails.Where(o => o.SubId == 631).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject2Barcode = item.ResultDetails.Where(o => o.SubId == 632).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject2Marks = item.ResultDetails.Where(o => o.SubId == 632).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.Subject3Barcode = item.ResultDetails.Where(o => o.SubId == 633).Select(b => b.BarCode).FirstOrDefault();
                    tempOutput1.Subject3Marks = item.ResultDetails.Where(o => o.SubId == 633).Select(b => b.Marks).FirstOrDefault();

                    tempOutput1.TotalMarksAchieved = item.TotalMarksAchieved;

                    tempOutput1.Subject1Grade = item.ResultDetails.Where(o => o.SubId == 631).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject2Grade = item.ResultDetails.Where(o => o.SubId == 632).Select(b => b.Grade).FirstOrDefault();
                    tempOutput1.Subject3Grade = item.ResultDetails.Where(o => o.SubId == 633).Select(b => b.Grade).FirstOrDefault();

                    tempOutput1.TotalNoOfPass = item.TotalNoOfPass;

                    resultsType2.Add(tempOutput1);
                }

                statisticsType2.Subject1Present = subjectDetails.Where(i => i.SubId == 631).Select(o => o.NumberOfStudentPresent).FirstOrDefault();
                statisticsType2.Subject2Present = subjectDetails.Where(i => i.SubId == 632).Select(o => o.NumberOfStudentPresent).FirstOrDefault();
                statisticsType2.Subject3Present = subjectDetails.Where(i => i.SubId == 633).Select(o => o.NumberOfStudentPresent).FirstOrDefault();

                statisticsType2.Subject1Pass = subjectDetails.Where(i => i.SubId == 631).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statisticsType2.Subject2Pass = subjectDetails.Where(i => i.SubId == 632).Select(o => o.NumberOfStudentPassed).FirstOrDefault();
                statisticsType2.Subject3Pass = subjectDetails.Where(i => i.SubId == 633).Select(o => o.NumberOfStudentPassed).FirstOrDefault();

                statisticsType2.Subject1Percentage = subjectDetails.Where(i => i.SubId == 631).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statisticsType2.Subject2Percentage = subjectDetails.Where(i => i.SubId == 632).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
                statisticsType2.Subject3Percentage = subjectDetails.Where(i => i.SubId == 633).Select(o => o.PercentageOfStudentPassed).FirstOrDefault();
            }

            //7.12.1
            if (input.GradeSheetAllSubjectFailReport == 1)
            {
                List<int> newRegNoCollection = new();

                // for each student
                foreach (var element in output)
                {
                    bool isAllSubjectFailed = true;
                    // for each subject
                    foreach (var item in element.ResultDetails)
                    {
                        if (item.Grade == "A" || item.Grade == "B")
                        {
                            isAllSubjectFailed = false;
                            break;
                        }
                    }

                    if (isAllSubjectFailed == true)
                    {
                        newRegNoCollection.Add(element.RegNo ?? 0);
                    }
                }

                if (newRegNoCollection == null || newRegNoCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                int minx = newRegNoCollection.Min();
                int maxx = newRegNoCollection.Max();

                // download only necessary name, fname and mname
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
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for grade sheet all subject fail report for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                List<TabulationsControllerModel18> newOutput = new();

                foreach (var element in output.Where(o => newRegNoCollection.Contains(o.RegNo ?? 0)).ToList())
                {
                    TabulationsControllerModel18 tempOutput = new();

                    var getStuInfo = tempNameCollection.Where(o => o.RegNo == element.RegNo).FirstOrDefault();
                    if (getStuInfo != null)
                    {
                        tempOutput.ExamRollNo = element.ExamRollNo;
                        tempOutput.RegNo = element.RegNo;
                        tempOutput.Name = getStuInfo.Name;
                        tempOutput.FName = getStuInfo.FName;
                        tempOutput.MName = getStuInfo.MName;

                        tempOutput.ResultDetails = element.ResultDetails;

                        newOutput.Add(tempOutput);
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + newOutput.Count + " student details for grade sheet all subject fail report",
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        FilepathControllerSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync(),
                        ExamLevelName = GetExamLevelName,
                        MonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync(),
                        tabulationSheetData = newOutput,
                    }
                });
            }
            //7.2
            else if (input.EncodedTabulationSheetReport == 1)
            {
                if (input.ExamLevel == 61 || input.ExamLevel == 62)
                {
                    string startHeading = "SL#";
                    var newHeading = new
                    {
                        startHeading,
                        heading.Subject1Name,
                        heading.Subject2Name,
                        heading.Subject3Name,
                        heading.Subject4Name,
                        heading.Subject5Name,
                        heading.Subject6Name,
                        heading.Subject7Name,
                        heading.TotalHeading,
                        heading.Subject1ShortName,
                        heading.Subject2ShortName,
                        heading.Subject3ShortName,
                        heading.Subject4ShortName,
                        heading.Subject5ShortName,
                        heading.Subject6ShortName,
                        heading.Subject7ShortName,
                        heading.SubPassedHeading
                    };

                    var newOutput = (from r in results
                                     select new TabulationsControllerModel14
                                     {
                                         SlNo = 0,
                                         Subject1Barcode = r.Subject1Barcode,
                                         Subject1Marks = r.Subject1Marks,
                                         Subject2Barcode = r.Subject2Barcode,
                                         Subject2Marks = r.Subject2Marks,
                                         Subject3Barcode = r.Subject3Barcode,
                                         Subject3Marks = r.Subject3Marks,
                                         Subject4Barcode = r.Subject4Barcode,
                                         Subject4Marks = r.Subject4Marks,
                                         Subject5Barcode = r.Subject5Barcode,
                                         Subject5Marks = r.Subject5Marks,
                                         Subject6Barcode = r.Subject6Barcode,
                                         Subject6Marks = r.Subject6Marks,
                                         Subject7Barcode = r.Subject7Barcode,
                                         Subject7Marks = r.Subject7Marks,
                                         TotalMarksAchieved = r.TotalMarksAchieved,
                                         Subject1Grade = r.Subject1Grade,
                                         Subject2Grade = r.Subject2Grade,
                                         Subject3Grade = r.Subject3Grade,
                                         Subject4Grade = r.Subject4Grade,
                                         Subject5Grade = r.Subject5Grade,
                                         Subject6Grade = r.Subject6Grade,
                                         Subject7Grade = r.Subject7Grade,
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    int rowCount = 1;

                    foreach (var item in newOutput)
                    {
                        item.SlNo = rowCount;
                        rowCount++;
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details",
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                            Statistics = statistics
                        }
                    });
                }
                else if (input.ExamLevel == 63)
                {
                    string startHeading = "SL#";
                    var newHeading = new
                    {
                        startHeading,
                        headingType2.Subject1Name,
                        headingType2.Subject2Name,
                        headingType2.Subject3Name,
                        headingType2.TotalHeading,
                        headingType2.Subject1ShortName,
                        headingType2.Subject2ShortName,
                        headingType2.Subject3ShortName,
                        headingType2.SubPassedHeading
                    };

                    var newOutput = (from r in resultsType2
                                     select new TabulationsControllerModel15
                                     {
                                         SlNo = 0,
                                         Subject1Barcode = r.Subject1Barcode,
                                         Subject1Marks = r.Subject1Marks,
                                         Subject2Barcode = r.Subject2Barcode,
                                         Subject2Marks = r.Subject2Marks,
                                         Subject3Barcode = r.Subject3Barcode,
                                         Subject3Marks = r.Subject3Marks,
                                         TotalMarksAchieved = r.TotalMarksAchieved,
                                         Subject1Grade = r.Subject1Grade,
                                         Subject2Grade = r.Subject2Grade,
                                         Subject3Grade = r.Subject3Grade,
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    int rowCount = 1;

                    foreach (var item in newOutput)
                    {
                        item.SlNo = rowCount;
                        rowCount++;
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details",
                        Success = true,
                        Payload = new
                        {
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                            Statistics = statisticsType2
                        }
                    });
                }
            }
            //7.10.4.1
            else if (input.TabulationSheetWithNameReport == 1)
            {
                List<int?> newRegNoCollection = output.OrderBy(o => o.RegNo).Select(o => o.RegNo).ToList();

                if (newRegNoCollection == null || newRegNoCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                int minx = newRegNoCollection.Min() ?? 0;
                int maxx = newRegNoCollection.Max() ?? 0;

                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                if (input.ExamLevel == 61 || input.ExamLevel == 62)
                {
                    string customHeading1 = "Name";
                    string customHeading2 = "Father's Name";
                    var newHeading = new
                    {
                        heading.ExamRollNoHeading,
                        heading.RegNoHeading,
                        customHeading1,
                        customHeading2,
                        heading.Subject1ShortName,
                        heading.Subject2ShortName,
                        heading.Subject3ShortName,
                        heading.Subject4ShortName,
                        heading.Subject5ShortName,
                        heading.Subject6ShortName,
                        heading.Subject7ShortName,
                        heading.SubPassedHeading
                    };

                    var newOutput = (from r in results
                                     select new TabulationsControllerModel16
                                     {
                                         ExamRollNo = r.ExamRollNo,
                                         RegNo = r.RegNo,
                                         Name = null,
                                         FName = null,
                                         Subject1Grade = r.Subject1Grade,
                                         Subject2Grade = r.Subject2Grade,
                                         Subject3Grade = r.Subject3Grade,
                                         Subject4Grade = r.Subject4Grade,
                                         Subject5Grade = r.Subject5Grade,
                                         Subject6Grade = r.Subject6Grade,
                                         Subject7Grade = r.Subject7Grade,
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    foreach (var item in newOutput)
                    {
                        item.Name = tempNameCollection.Where(o => o.RegNo == item.RegNo).Select(i => i.Name).FirstOrDefault();
                        item.FName = tempNameCollection.Where(o => o.RegNo == item.RegNo).Select(i => i.FName).FirstOrDefault();
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details",
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                            Statistics = statistics
                        }
                    });
                }
                else if (input.ExamLevel == 63)
                {
                    string customHeading1 = "Name";
                    string customHeading2 = "Father's Name";
                    var newHeading = new
                    {
                        headingType2.ExamRollNoHeading,
                        headingType2.RegNoHeading,
                        customHeading1,
                        customHeading2,
                        headingType2.Subject1ShortName,
                        headingType2.Subject2ShortName,
                        headingType2.Subject3ShortName,
                        headingType2.SubPassedHeading
                    };

                    var newOutput = (from r in resultsType2
                                     select new TabulationsControllerModel17
                                     {
                                         ExamRollNo = r.ExamRollNo,
                                         RegNo = r.RegNo,
                                         Name = null,
                                         FName = null,
                                         Subject1Grade = r.Subject1Grade,
                                         Subject2Grade = r.Subject2Grade,
                                         Subject3Grade = r.Subject3Grade,
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    foreach (var item in newOutput)
                    {
                        item.Name = tempNameCollection.Where(o => o.RegNo == item.RegNo).Select(i => i.Name).FirstOrDefault();
                        item.FName = tempNameCollection.Where(o => o.RegNo == item.RegNo).Select(i => i.FName).FirstOrDefault();
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details",
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                            Statistics = statisticsType2
                        }
                    });
                }
            }
            //7.18.1 - at least one fail based on attempt
            else if (input.CandidateFailedBasedOnAttemptReport == 1)
            {
                //int numberOfAttemptedSubject = 0;
                if (input.CandidateFailedBasedOnAttempt == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Selection invalid for number of subject attempted in candidate failed report",
                        Success = false,
                        Payload = null
                    });
                }

                //if (input.CandidateFailedBasedOnAttempt == 0 && subjects.Count > 0)
                //{
                //    numberOfAttemptedSubject = subjects.Count;
                //}
                //else
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                //    {
                //        Message = "Selection invalid for number of subject attempted in candidate failed report",
                //        Success = false,
                //        Payload = null
                //    });
                //}

                List<TabulationsControllerModel1> customOutput = new();

                foreach (var item in output)
                {
                    int getNumberOfAttempt = item.ResultDetails.Where(gl => gl.Grade == "A" || gl.Grade == "B" || gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E").ToList().Count;

                    if (getNumberOfAttempt == input.CandidateFailedBasedOnAttempt)
                    {
                        bool isFailed = item.ResultDetails.Where(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E").ToList().Count > 0;
                        if (isFailed == true)
                        {
                            customOutput.Add(item);
                        }
                    }
                }

                //System.Diagnostics.Debug.WriteLine("here is subject choice: " + input.CandidateFailedBasedOnAttempt);
                //System.Diagnostics.Debug.WriteLine("here is subject choice row: " + customOutput.Count);


                ////var xop = output.Where(l => l.ResultDetails.Where(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E").ToList().Count > 0)
                ////                .ToList();
                List<int?> x = customOutput.Select(i => i.RegNo).ToList();

                ////List<TabulationsControllerModel1> onlyFailedOutput = output.Select(o => new { o.RegNo, o.ExamRollNo, o.ResultDetails })
                ////                                      .Where(l => l.ResultDetails.Where(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E").ToList().Count > 0)
                ////                                      .Select(i => i.RegNo)
                ////                                      .ToList();

                if (x == null || x.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No candidate details found for failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                int minx = x.Min() ?? 0;
                int maxx = x.Max() ?? 0;

                // download only necessary name, fname and mname
                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName,
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                //if (tempNameCollection == null || tempNameCollection.Count == 0)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //    {
                //        Message = "No result found for grade sheet all subject fail report for given criteria",
                //        Success = false,
                //        Payload = null
                //    });
                //}

                //List<TabulationsControllerModel21> newRegNoCollection = new();

                //foreach (var item in x)
                //{
                //    TabulationsControllerModel21 d = new();

                //    d.RegNo = (item ?? 0);

                //    newRegNoCollection.Add(d);
                //}


                //////if (newRegNoCollection == null || newRegNoCollection.Count == 0)
                //////{
                //////    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                //////    {
                //////        Message = "No candidate details found for failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                //////        Success = false,
                //////        Payload = null
                //////    });
                //////}

                string customHeading0 = "Sl #";
                string customHeading1 = "Roll No";
                string customHeading2 = "Reg. No";
                string customHeading3 = "Name of Candidate";
                string customHeading4 = "Father's Name";
                string customHeading5 = "No. of Passed Subjects";

                var newHeading = new
                {
                    customHeading0,
                    customHeading1,
                    customHeading2,
                    customHeading3,
                    customHeading4,
                    customHeading5,
                };

                List<TabulationsControllerModel19> newOutput = new();

                int rowCount = 1;

                foreach (var item in x)
                {
                    var r = customOutput.Where(i => i.RegNo == item).FirstOrDefault();

                    //var t = tempNameCollection.Where(i => i.RegNo == item).FirstOrDefault();
                    //var dd = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => new { o.Name, o.FName}).FirstOrDefault();

                    if (r != null)
                    {
                        TabulationsControllerModel19 s = new();

                        s.SlNo = rowCount;
                        s.ExamRollNo = r.ExamRollNo ?? 0;
                        s.RegNo = r.RegNo ?? 0;
                        s.Name = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.Name).FirstOrDefault();
                        s.FName = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.FName).FirstOrDefault();
                        s.TotalNoOfPass = r.TotalNoOfPass;

                        //s.Subject1Grade = r.Subject1Grade;
                        //s.Subject2Grade = r.Subject2Grade;
                        //s.Subject3Grade = r.Subject3Grade;
                        //s.Subject4Grade = r.Subject4Grade;
                        //s.Subject5Grade = r.Subject5Grade;
                        //s.Subject6Grade = r.Subject6Grade;
                        //s.Subject7Grade = r.Subject7Grade;

                        newOutput.Add(s);

                        rowCount++;
                    }
                }

                bool isRowCountValid = newOutput.Count > 0;

                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of " + newOutput.Count + " Candidates failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear : "No list of Candidate found failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = GetMonthName,
                        Subjects = newHeading,
                        tabulationSheetData = newOutput
                    } : null
                });

                //return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                //{
                //    Message = "that is it " + customOutput.Count,
                //    Success = true,
                //    Payload = customOutput
                //});
            }
            //7.14.1
            else if (input.CongratulationLetterInfoReport == 1)
            {
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
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for congratulation letter report for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                var tempExamCenterNameCollection = await (from ec in _context.Set<ExamCentre>().Select(op => new { op.CenId, op.Name }).Where(o => o.CenId >= miny && o.CenId <= maxy)
                                                          select new
                                                          {
                                                              ec.CenId,
                                                              ec.Name,
                                                          }).OrderBy(o => o.CenId).ToListAsync();

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
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + newOutput.Count + " students passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                    Success = true,
                    //Payload = newOutput
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        //ControllerName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.Controller).FirstOrDefaultAsync(),
                        //ControllerSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.ControllerSign).FirstOrDefaultAsync(),
                        //SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync(),
                        FilepathSecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync(),
                        Output = newOutput
                        //J = zz
                    }
                });
            }
            //7.15.1 + 7.17.1
            else if (input.SuccessfulExamineeAddressListReport == 1)
            {
                List<int> rc = new();
                Dictionary<int, int> rvr = new();


                //List<TabulationsControllerModel1> zz = new();

                List<TabulationsControllerModel23> newOutput = new();

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
                        //TabulationsControllerModel23 tempop = new();

                        //tempop.ExamRollNo = (item.ExamRollNo ?? 0);
                        //tempop.RegNo = (item.RegNo ?? 0);
                        //tempop.Name = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.Name).FirstOrDefault();
                        //tempop.FName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.FName).FirstOrDefault();
                        //tempop.MName = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.MName).FirstOrDefault();
                        //tempop.PreAddress = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.PerAdd).FirstOrDefault();
                        //tempop.Cell = tempNameCollection.Where(i => i.RegNo == item.RegNo).Select(o => o.Cell).FirstOrDefault();

                        //newOutput.Add(tempop);
                    }
                }

                int minx = rc.Min();
                int maxx = rc.Max();

                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName, op.PreAdd, op.Cell }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName,
                                                    sr1.MName,
                                                    sr1.PreAdd,
                                                    sr1.Cell
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                if (tempNameCollection == null || tempNameCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student passed the level for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                int rctr = 1;
                foreach (var s in rc)
                {
                    TabulationsControllerModel23 tempop = new();

                    tempop.SlNo = rctr;
                    tempop.ExamRollNo = rvr[s];
                    tempop.RegNo = s;
                    tempop.Name = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.Name).FirstOrDefault();
                    tempop.FName = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.FName).FirstOrDefault();
                    tempop.MName = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.MName).FirstOrDefault();
                    tempop.PreAddress = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.PreAdd).FirstOrDefault();
                    tempop.Cell = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.Cell).FirstOrDefault();

                    newOutput.Add(tempop);
                    rctr++;
                }

                if (newOutput == null || newOutput.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of address of " + newOutput.Count + " students passed the level " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        FilepathControllerSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync(),
                        FilepathSecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync(),
                        GetExamLevelName,
                        getDetailsMonthName,
                        Output = newOutput
                    }
                    //Payload = new
                    //{
                    //    newOutput,
                    //    J = zz
                    //}
                });
            }
            //7.16.1
            else if (input.CandidateFailedWithPartialPassReport == 1)
            {
                List<int?> x = new();

                //List<int> xxx = new();
                //List<int?> x = output.Where(k => k.TotalNoOfPass >= 1).ToList()
                //                     .Select(o => new { o.RegNo, o.ResultDetails })
                //                     .Where(l => l.ResultDetails.Where(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E" || gl.Grade == "F").ToList().Count > 0)
                //                     .Select(i => i.RegNo)
                //                     .ToList();

                x = output.Where(k => k.TotalNoOfPass >= 1).ToList()
                                    .Select(o => new { o.RegNo, o.ResultDetails })
                                    .Where(l => l.ResultDetails.Where(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E" || gl.Grade == "F").ToList().Count > 0)
                                    .Select(i => i.RegNo)
                                    .ToList();

                List<TabulationsControllerModel1> fgh = new();
                foreach (var item in x)
                {
                    TabulationsControllerModel1 g = output.Where(i => i.RegNo == item).FirstOrDefault();
                    if (g != null)
                    {
                        fgh.Add(g);
                    }
                }

                //var nr = output.Where(k => x.Contains(k.RegNo)).ToList();

                //foreach (var item in output)
                //{
                //    if (item.RegNo != null && item.ResultDetails.Any(gl => gl.Grade == "A" || gl.Grade == "B"))
                //    {
                //        if (item.ResultDetails.Any(gl => gl.Grade == "C" || gl.Grade == "D" || gl.Grade == "E" || gl.Grade == "F"))
                //        {
                //            x.Add(item.RegNo);
                //        }
                //    }
                //}

                System.Diagnostics.Debug.WriteLine("here is count: " + x.Count);
                //System.Diagnostics.Debug.WriteLine("here is count: " + nr.Count);

                int minx = x.Min() ?? 0;
                int maxx = x.Max() ?? 0;

                if (x == null || x.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No candidate details found for Failed With Partial Pass in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(i => i.RegNo >= minx && i.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName,
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                if (tempNameCollection == null || tempNameCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for grade sheet all subject fail report for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                if (input.ExamLevel == 61 || input.ExamLevel == 62)
                {
                    string startHeading = "SL#";
                    string startHeading2 = "Reg No.";
                    string startHeading3 = "Roll No.";
                    string startHeading4 = "Name of Candidates";
                    string startHeading5 = "Father's Name";
                    var newHeading = new
                    {
                        startHeading,
                        startHeading2,
                        startHeading3,
                        startHeading4,
                        startHeading5,
                        heading.Subject1ShortName,
                        heading.Subject2ShortName,
                        heading.Subject3ShortName,
                        heading.Subject4ShortName,
                        heading.Subject5ShortName,
                        heading.Subject6ShortName,
                        heading.Subject7ShortName,
                        heading.SubPassedHeading
                    };

                    List<TabulationsControllerModel9> newResult = new();

                    foreach (var aa in x)
                    {
                        var tempNewResult = results.Where(o => o.RegNo == aa).FirstOrDefault();
                        if (tempNewResult != null)
                        {
                            newResult.Add(tempNewResult);
                        }
                    }

                    var newOutput = (from r in newResult
                                     select new TabulationsControllerModel24
                                     {
                                         SlNo = 0,
                                         ExamRollNo = r.ExamRollNo,
                                         RegNo = r.RegNo,
                                         Name = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.Name).FirstOrDefault(),
                                         FName = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.FName).FirstOrDefault(),
                                         Subject1Grade = r.Subject1Grade,
                                         Subject2Grade = r.Subject2Grade,
                                         Subject3Grade = r.Subject3Grade,
                                         Subject4Grade = r.Subject4Grade,
                                         Subject5Grade = r.Subject5Grade,
                                         Subject6Grade = r.Subject6Grade,
                                         Subject7Grade = r.Subject7Grade,
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    int rowCount = 1;

                    foreach (var item in newOutput)
                    {
                        item.SlNo = rowCount;
                        rowCount++;
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No CANDIDATE FOUND WHO HAVE PASSED PARTLY",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "List of " + newOutput.Count + " CANDIDATES WHO HAVE PASSED PARTLY in " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                        }
                    });
                }
                else if (input.ExamLevel == 63)
                {
                    string startHeading = "SL#";
                    string startHeading2 = "Reg No.";
                    string startHeading3 = "Roll No.";
                    string startHeading4 = "Name of Candidates";
                    string startHeading5 = "Father's Name";
                    var newHeading = new
                    {
                        startHeading,
                        startHeading2,
                        startHeading3,
                        startHeading4,
                        startHeading5,
                        heading.Subject1ShortName,
                        heading.Subject2ShortName,
                        heading.Subject3ShortName,
                        heading.SubPassedHeading
                    };

                    //List<TabulationsControllerModel9> newResult = new();

                    //foreach (var aa in x)
                    //{
                    //    var tempNewResult = results.Where(o => o.RegNo == aa).FirstOrDefault();
                    //    if (tempNewResult != null)
                    //    {
                    //        newResult.Add(tempNewResult);
                    //    }
                    //}

                    var newOutput = (from r in fgh
                                     select new TabulationsControllerModel25
                                     {
                                         SlNo = 0,
                                         ExamRollNo = r.ExamRollNo ?? 0,
                                         RegNo = r.RegNo ?? 0,
                                         Name = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.Name).FirstOrDefault(),
                                         FName = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.FName).FirstOrDefault(),
                                         Subject1Grade = r.ResultDetails.Select(i => i.Grade).FirstOrDefault(),
                                         Subject2Grade = r.ResultDetails.Skip(1).Select(i => i.Grade).FirstOrDefault(),
                                         Subject3Grade = r.ResultDetails.Skip(2).Select(i => i.Grade).FirstOrDefault(),
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    int rowCount = 1;

                    foreach (var item in newOutput)
                    {
                        item.SlNo = rowCount;
                        rowCount++;
                    }

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No CANDIDATE FOUND WHO HAVE PASSED PARTLY",
                            Success = false,
                            Payload = null
                        });
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "List of " + newOutput.Count + " CANDIDATES WHO HAVE PASSED PARTLY in " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            //ControllerName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.Controller).FirstOrDefaultAsync(),
                            FilepathControllerSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathControllerSign).FirstOrDefaultAsync(),
                            //SecretaryCeoName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.SecretaryCeo).FirstOrDefaultAsync(),
                            FilepathSecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync(),
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                        }
                    });
                }
            }
            //7.19.1
            else if (input.CandidateFailedWithAllSubjectFailReport == 1)
            {
                List<int> newRegNoCollection = new();

                // for each student
                foreach (var element in output)
                {
                    bool isAllSubjectFailed = true;
                    bool isFailGradeFound = false;
                    // for each subject
                    foreach (var item in element.ResultDetails)
                    {
                        if (item.Grade == "A" || item.Grade == "B")
                        {
                            isAllSubjectFailed = false;
                            break;
                        }

                        if (item.Grade == "C" || item.Grade == "D" || item.Grade == "E")
                        {
                            isFailGradeFound = true;
                        }
                    }

                    if (isAllSubjectFailed == true && isFailGradeFound == true)
                    {
                        newRegNoCollection.Add(element.RegNo ?? 0);
                    }
                }

                if (newRegNoCollection == null || newRegNoCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                int minx = newRegNoCollection.Min();
                int maxx = newRegNoCollection.Max();

                // download only necessary name, fname and mname
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
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No result found for grade sheet all subject fail report for given criteria",
                        Success = false,
                        Payload = null
                    });
                }

                List<TabulationsControllerModel18> newOutput = new();

                foreach (var element in output.Where(o => newRegNoCollection.Contains(o.RegNo ?? 0)).ToList())
                {
                    TabulationsControllerModel18 tempOutput = new();

                    var getStuInfo = tempNameCollection.Where(o => o.RegNo == element.RegNo).FirstOrDefault();

                    if (getStuInfo != null)
                    {
                        tempOutput.ExamRollNo = element.ExamRollNo;
                        tempOutput.RegNo = element.RegNo;
                        tempOutput.Name = getStuInfo.Name;
                        tempOutput.FName = getStuInfo.FName;
                        tempOutput.MName = getStuInfo.MName;

                        tempOutput.ResultDetails = element.ResultDetails;

                        newOutput.Add(tempOutput);
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + newOutput.Count + " student details for grade sheet all subject fail report",
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync(),
                        tabulationSheetData = newOutput,
                    }
                });
            }
            //7.20.1 - who all subject passed - show their number of pass in current examlevel, month id and session year
            else if (input.SubjectPassedListReport == 1)
            {
                List<int> rc = new();
                Dictionary<int, int> rvr = new();
                Dictionary<int, int> rvtnop = new();

                //List<TabulationsControllerModel1> zz = new();

                List<TabulationsControllerModel26> newOutput = new();

                string getDetailsMonthName = await _context.SessionInfos.Where(i => i.SessionId == input.MonthId).Select(o => o.SessionDetailsName).FirstOrDefaultAsync();

                List<VwSessionPassCount> passCount = _context.VwSessionPassCounts.Where(x => x.ExamLevel == input.ExamLevel && x.MonthId == input.MonthId
                                                                                        && x.SessionYear == input.SessionYear && x.NoSubApp == x.NoPassSub).ToList();

                foreach (var item in passCount) //output.Where(o => o.TotalNoOfPass > 0 && IsAllSubjectPassed(o.ResultDetails) == true
                {
                    rc.Add(item.RegNo);
                    rvr.Add(item.RegNo, item.ExamRollno);
                    rvtnop.Add(item.RegNo, item.NoPassSub);
                }

                int minx = rc.Min();
                int maxx = rc.Max();

                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName, op.PreAdd, op.Cell }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName,
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                if (tempNameCollection == null || tempNameCollection.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student passed the level for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
                int trc = 1;
                foreach (var s in rc)
                {
                    TabulationsControllerModel26 tempop = new();

                    tempop.SlNo = trc;
                    tempop.ExamRollNo = rvr[s];
                    tempop.RegNo = s;
                    tempop.Name = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.Name).FirstOrDefault();
                    tempop.FName = tempNameCollection.Where(i => i.RegNo == s).Select(o => o.FName).FirstOrDefault();
                    tempop.NumberOfPassedSubjects = rvtnop[s];

                    newOutput.Add(tempop);

                    trc++;
                }

                if (newOutput == null || newOutput.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No student passed all subject in " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + newOutput.Count + " students who passed all subject in " + GetExamLevelName + " on " + getDetailsMonthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        GetExamLevelName,
                        getDetailsMonthName,
                        Output = newOutput.OrderBy(i => i.ExamRollNo)
                    }
                    //Payload = new
                    //{
                    //    newOutput,
                    //    J = zz
                    //}
                });
            }
            //7.21.1
            else if (input.ResultSummaryListReport == 1)
            {
                List<int> rc = new();

                List<TabulationsControllerModel26> newOutput = new();
                List<TabulationsControllerModel1> customOutput = new();

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
                        rc.Add(item.RegNo ?? 0);
                        customOutput.Add(item);
                    }
                }

                int TotalNumberOfStudentsPassedIn7Subjects = 0;
                int TotalNumberOfStudentsPassedIn6Subjects = 0;
                int TotalNumberOfStudentsPassedIn5Subjects = 0;
                int TotalNumberOfStudentsPassedIn4Subjects = 0;
                int TotalNumberOfStudentsPassedIn3Subjects = 0;
                int TotalNumberOfStudentsPassedIn2Subjects = 0;
                int TotalNumberOfStudentsPassedIn1Subjects = 0;
                int TotalNumberOfStudentsPassedIn0Subjects = 0;

                if (input.ExamLevel == 63)
                {
                    foreach (var item in output)
                    {
                        //for those who have pass but doesn't have level pass
                        if (!rc.Contains(item.RegNo ?? 0))
                        {
                            int passCount = item.ResultDetails.Where(i => i.Grade == "A" || i.Grade == "B").ToList().Count;
                            if (passCount == 0)
                            {
                                TotalNumberOfStudentsPassedIn0Subjects++;
                            }
                            else if (passCount == 1)
                            {
                                TotalNumberOfStudentsPassedIn1Subjects++;
                            }
                            else if (passCount == 2)
                            {
                                TotalNumberOfStudentsPassedIn2Subjects++;
                            }
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Result summary list for " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            GetExamLevelName,
                            GetMonthName,
                            NumberOfStudentsPassedTheLevel = rc.Count,
                            ByPassing3Subjects = customOutput.Where(i => i.TotalNoOfPass == 3).ToList().Count,
                            ByPassing2Subjects = customOutput.Where(i => i.TotalNoOfPass == 2).ToList().Count,
                            ByPassing1Subjects = customOutput.Where(i => i.TotalNoOfPass == 1).ToList().Count,
                            NumberOfStudentsPassedIn2Subjects = TotalNumberOfStudentsPassedIn2Subjects,
                            NumberOfStudentsPassedIn1Subjects = TotalNumberOfStudentsPassedIn1Subjects,
                            NumberOfStudentsPassedIn0Subjects = TotalNumberOfStudentsPassedIn0Subjects,
                            NumberOfStudentsAppearedInTheLevel = output.Count
                        }
                    });
                }

                foreach (var item in output)
                {
                    //for those who have pass but doesn't have level pass
                    if (!rc.Contains(item.RegNo ?? 0))
                    {
                        int passCount = item.ResultDetails.Where(i => i.Grade == "A" || i.Grade == "B").ToList().Count;
                        if (passCount == 0)
                        {
                            TotalNumberOfStudentsPassedIn0Subjects++;
                        }
                        else if (passCount == 1)
                        {
                            TotalNumberOfStudentsPassedIn1Subjects++;
                        }
                        else if (passCount == 2)
                        {
                            TotalNumberOfStudentsPassedIn2Subjects++;
                        }
                        else if (passCount == 3)
                        {
                            TotalNumberOfStudentsPassedIn3Subjects++;
                        }
                        else if (passCount == 4)
                        {
                            TotalNumberOfStudentsPassedIn4Subjects++;
                        }
                        else if (passCount == 5)
                        {
                            TotalNumberOfStudentsPassedIn5Subjects++;
                        }
                        else if (passCount == 6)
                        {
                            TotalNumberOfStudentsPassedIn6Subjects++;
                        }
                        else if (passCount == 7)
                        {
                            TotalNumberOfStudentsPassedIn7Subjects++;
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Result summary list for " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        //ControllerName = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.Controller).FirstOrDefaultAsync(),
                        FilepathSecretaryCeoSign = await _context.Signatures.Where(k => k.ExamLevel == input.ExamLevel && k.MonthId == input.MonthId && k.SessionYear == input.SessionYear).Select(o => o.FilepathSecretaryCeoSign).FirstOrDefaultAsync(),
                        GetExamLevelName,
                        GetMonthName,
                        NumberOfStudentsPassedTheLevel = rc.Count,
                        ByPassing7Subjects = customOutput.Where(i => i.TotalNoOfPass == 7).ToList().Count,
                        ByPassing6Subjects = customOutput.Where(i => i.TotalNoOfPass == 6).ToList().Count,
                        ByPassing5Subjects = customOutput.Where(i => i.TotalNoOfPass == 5).ToList().Count,
                        ByPassing4Subjects = customOutput.Where(i => i.TotalNoOfPass == 4).ToList().Count,
                        ByPassing3Subjects = customOutput.Where(i => i.TotalNoOfPass == 3).ToList().Count,
                        ByPassing2Subjects = customOutput.Where(i => i.TotalNoOfPass == 2).ToList().Count,
                        ByPassing1Subjects = customOutput.Where(i => i.TotalNoOfPass == 1).ToList().Count,
                        NumberOfStudentsPassedIn7Subjects = TotalNumberOfStudentsPassedIn7Subjects,
                        NumberOfStudentsPassedIn6Subjects = TotalNumberOfStudentsPassedIn6Subjects,
                        NumberOfStudentsPassedIn5Subjects = TotalNumberOfStudentsPassedIn5Subjects,
                        NumberOfStudentsPassedIn4Subjects = TotalNumberOfStudentsPassedIn4Subjects,
                        NumberOfStudentsPassedIn3Subjects = TotalNumberOfStudentsPassedIn3Subjects,
                        NumberOfStudentsPassedIn2Subjects = TotalNumberOfStudentsPassedIn2Subjects,
                        NumberOfStudentsPassedIn1Subjects = TotalNumberOfStudentsPassedIn1Subjects,
                        NumberOfStudentsPassedIn0Subjects = TotalNumberOfStudentsPassedIn0Subjects,
                        NumberOfStudentsAppearedInTheLevel = output.Count
                    }
                });
            }
            //7.22.1
            else if (input.LevelWiseResultSummaryListReport == 1)
            {
                List<TabulationsControllerModel27> finalOutput = new();

                List<TabulationsControllerModel28> finalOutput63 = new();

                string heading0 = "Analysing Passed";

                string cell0 = "No. of Papers";
                string cell1 = "7";
                string cell2 = "6";
                string cell3 = "5";
                string cell4 = "4";
                string cell5 = "3";
                string cell6 = "2";
                string cell7 = "1";
                string cell8 = "0";
                string cell9 = "Passed";
                string cell10 = "Total Student";

                if (input.ExamLevel == 63)
                {
                    List<VwMarksfinal> vwmfss = await _context.VwMarksfinals.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear).ToListAsync();
                    for (int i = subjects.Count; i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            TabulationsControllerModel28 tOutput = new();

                            tOutput.NumberOfPapers = i.ToString() + " papers";
                            tOutput.Total3PapersPassed = 0;
                            tOutput.Total2PapersPassed = 0;
                            tOutput.Total1PapersPassed = 0;
                            tOutput.Total0PapersPassed = 0;
                            tOutput.TotalPassed = 0;
                            tOutput.TotalStudent = 0;

                            finalOutput63.Add(tOutput);
                            break;
                        }

                        TabulationsControllerModel28 tempOutput = new();

                        tempOutput.NumberOfPapers = i.ToString() + " papers";

                        Task<int> task_7_22_1_3 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 3).CountAsync();
                        Task<int> task_7_22_1_2 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 2).CountAsync();
                        Task<int> task_7_22_1_1 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 1).CountAsync();
                        await Task.WhenAll(task_7_22_1_3, task_7_22_1_2, task_7_22_1_1);

                        tempOutput.Total3PapersPassed = task_7_22_1_3.Result;
                        tempOutput.Total2PapersPassed = task_7_22_1_2.Result;
                        tempOutput.Total1PapersPassed = task_7_22_1_1.Result;

                        List<int?> attendedStudents = vwmfss.Select(l => l.RegNo).Distinct().ToList();
                        int failCounter = 0;
                        Parallel.ForEach(attendedStudents, item =>
                        {
                            List<VwMarksfinal> vm1 = vwmfss.Where(l => l.RegNo == item).ToList();
                            if (vm1.Count == i)
                            {
                                if (vm1.Where(i => i.Grade == "C" || i.Grade == "D" || i.Grade == "E").ToList().Count == i)
                                {
                                    failCounter++;
                                }
                            }
                        });
                        tempOutput.Total0PapersPassed = failCounter;

                        tempOutput.TotalPassed = tempOutput.Total3PapersPassed + tempOutput.Total2PapersPassed +
                                                 tempOutput.Total1PapersPassed;
                        tempOutput.TotalStudent = tempOutput.TotalPassed + tempOutput.Total0PapersPassed;

                        finalOutput63.Add(tempOutput);
                    }

                    TabulationsControllerModel28 tOutputEnd63 = new();

                    tOutputEnd63.NumberOfPapers = "Total";
                    tOutputEnd63.Total3PapersPassed = finalOutput63.Sum(i => i.Total3PapersPassed);
                    tOutputEnd63.Total2PapersPassed = finalOutput63.Sum(i => i.Total2PapersPassed);
                    tOutputEnd63.Total1PapersPassed = finalOutput63.Sum(i => i.Total1PapersPassed);
                    tOutputEnd63.Total0PapersPassed = finalOutput63.Sum(i => i.Total0PapersPassed);
                    tOutputEnd63.TotalPassed = finalOutput63.Sum(i => i.TotalPassed);
                    tOutputEnd63.TotalStudent = finalOutput63.Sum(i => i.TotalStudent);

                    finalOutput63.Add(tOutputEnd63);

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Level wise Result summary list for " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                        Success = true,
                        Payload = new
                        {
                            GetExamLevelName,
                            GetMonthName,
                            HeadingRow1 = new
                            {
                                heading0
                            },
                            HeadingRow2 = new
                            {
                                cell0,
                                cell5,
                                cell6,
                                cell7,
                                cell8,
                                cell9,
                                cell10
                            },
                            Output = finalOutput63
                        }
                    });
                }

                List<VwMarksfinal> vwmfs = await _context.VwMarksfinals.Where(o => o.ExamLevel == input.ExamLevel && o.MonthId == input.MonthId && o.SessionYear == input.SessionYear).ToListAsync();
                for (int i = subjects.Count; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        TabulationsControllerModel27 tOutput = new();

                        tOutput.NumberOfPapers = i.ToString() + " papers";
                        tOutput.Total7PapersPassed = 0;
                        tOutput.Total6PapersPassed = 0;
                        tOutput.Total5PapersPassed = 0;
                        tOutput.Total4PapersPassed = 0;
                        tOutput.Total3PapersPassed = 0;
                        tOutput.Total2PapersPassed = 0;
                        tOutput.Total1PapersPassed = 0;
                        tOutput.Total0PapersPassed = 0;
                        tOutput.TotalPassed = 0;
                        tOutput.TotalStudent = 0;

                        finalOutput.Add(tOutput);
                        break;
                    }

                    TabulationsControllerModel27 tempOutput = new();

                    tempOutput.NumberOfPapers = i.ToString() + " papers";

                    Task<int> task_7_22_1_7 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 7).CountAsync();
                    Task<int> task_7_22_1_6 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 6).CountAsync();
                    Task<int> task_7_22_1_5 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 5).CountAsync();
                    Task<int> task_7_22_1_4 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 4).CountAsync();
                    Task<int> task_7_22_1_3 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 3).CountAsync();
                    Task<int> task_7_22_1_2 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 2).CountAsync();
                    Task<int> task_7_22_1_1 = _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i && j.NoPassSub == 1).CountAsync();

                    await Task.WhenAll(task_7_22_1_7, task_7_22_1_6, task_7_22_1_5, task_7_22_1_4, task_7_22_1_3, task_7_22_1_2, task_7_22_1_1);

                    tempOutput.Total7PapersPassed = task_7_22_1_7.Result;
                    tempOutput.Total6PapersPassed = task_7_22_1_6.Result;
                    tempOutput.Total5PapersPassed = task_7_22_1_5.Result;
                    tempOutput.Total4PapersPassed = task_7_22_1_4.Result;
                    tempOutput.Total3PapersPassed = task_7_22_1_3.Result;
                    tempOutput.Total2PapersPassed = task_7_22_1_2.Result;
                    tempOutput.Total1PapersPassed = task_7_22_1_1.Result;

                    List<int?> attendedStudents = vwmfs.Select(l => l.RegNo).Distinct().ToList();

                    //trial - 1
                    //--------
                    int failCounter = 0;
                    foreach (var item in attendedStudents)
                    {
                        List<VwMarksfinal> vm1 = vwmfs.Where(l => l.RegNo == item).ToList();
                        if (vm1.Count == i)
                        {
                            if (vm1.Where(i => i.Grade == "C" || i.Grade == "D" || i.Grade == "E").ToList().Count == i)
                            {
                                failCounter++;
                            }
                        }
                    }

                    ////trial-2
                    ////-------
                    //int failCounter = 0;
                    //List<int> passedReg = await _context.VwSessionPassCounts.Where(j => j.ExamLevel == input.ExamLevel && j.MonthId == input.MonthId && j.SessionYear == input.SessionYear && j.NoSubApp == i).Select(k => k.RegNo).ToListAsync();
                    //List<int> appearedReg = new();
                    //foreach(var item in attendedStudents)
                    //{
                    //    List<VwMarksfinal> vm1 = vwmfs.Where(l => l.RegNo == item).ToList();
                    //    //if appeared in i subjects
                    //    if (vm1.Count == i)
                    //    {
                    //        appearedReg.Add(item ?? 0);
                    //    }
                    //}
                    //failCounter = appearedReg.Count - passedReg.Count;




                    tempOutput.Total0PapersPassed = failCounter;

                    tempOutput.TotalPassed = tempOutput.Total7PapersPassed + tempOutput.Total6PapersPassed +
                                             tempOutput.Total5PapersPassed + tempOutput.Total4PapersPassed +
                                             tempOutput.Total3PapersPassed + tempOutput.Total2PapersPassed +
                                             tempOutput.Total1PapersPassed;
                    tempOutput.TotalStudent = tempOutput.TotalPassed + tempOutput.Total0PapersPassed;

                    finalOutput.Add(tempOutput);
                }

                TabulationsControllerModel27 tOutputEnd = new();

                tOutputEnd.NumberOfPapers = "Total";
                tOutputEnd.Total7PapersPassed = finalOutput.Sum(i => i.Total7PapersPassed);
                tOutputEnd.Total6PapersPassed = finalOutput.Sum(i => i.Total6PapersPassed);
                tOutputEnd.Total5PapersPassed = finalOutput.Sum(i => i.Total5PapersPassed);
                tOutputEnd.Total4PapersPassed = finalOutput.Sum(i => i.Total4PapersPassed);
                tOutputEnd.Total3PapersPassed = finalOutput.Sum(i => i.Total3PapersPassed);
                tOutputEnd.Total2PapersPassed = finalOutput.Sum(i => i.Total2PapersPassed);
                tOutputEnd.Total1PapersPassed = finalOutput.Sum(i => i.Total1PapersPassed);
                tOutputEnd.Total0PapersPassed = finalOutput.Sum(i => i.Total0PapersPassed);
                tOutputEnd.TotalPassed = finalOutput.Sum(i => i.TotalPassed);
                tOutputEnd.TotalStudent = finalOutput.Sum(i => i.TotalStudent);

                finalOutput.Add(tOutputEnd);

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Level wise Result summary list for " + GetExamLevelName + " on " + GetMonthName + ", " + input.SessionYear,
                    Success = true,
                    Payload = new
                    {
                        GetExamLevelName,
                        GetMonthName,
                        HeadingRow1 = new
                        {
                            heading0
                        },
                        HeadingRow2 = new
                        {
                            cell0,
                            cell1,
                            cell2,
                            cell3,
                            cell4,
                            cell5,
                            cell6,
                            cell7,
                            cell8,
                            cell9,
                            cell10
                        },
                        Output = finalOutput
                    }
                });
            }
            //7.25 - rest of subject report
            else if (input.RestOfSubjectListReport == 1 && input.AppearedPapers != null && input.PassedPapers != null)
            {
                List<int> s61 = await (from e in _context.Set<ExamReg>()
                                       where e.ExamLevel == input.ExamLevel && e.MonthId == input.MonthId && e.SessionYear == input.SessionYear
                                       join r in _context.Set<RegSubject>() on e.Ref equals r.RefNo
                                       group e by e.RegNo into g
                                       where g.Count() == input.AppearedPapers
                                       select g.Key).ToListAsync();

                if (input.AppearedPapers == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Selection invalid for number of subject attempted in candidate failed report",
                        Success = false,
                        Payload = null
                    });
                }

                List<TabulationsControllerModel1> customOutput = new();

                foreach (var item in s61)
                {
                    var z = output.Where(i => i.RegNo == item && i.TotalNoOfPass == input.PassedPapers && i.ResultDetails.Count(i => i.BarCode != null) == input.AppearedPapers).FirstOrDefault();

                    if (z != null)
                    {
                        customOutput.Add(z);
                    }
                }

                List<int?> x = customOutput.Select(i => i.RegNo).ToList();

                if (x == null || x.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No candidate details found for failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                int minx = x.Min() ?? 0;
                int maxx = x.Max() ?? 0;

                // download only necessary name, fname and mname
                var tempNameCollection = await (from sr1 in _context.Set<StuReg1>().Select(op => new { op.RegNo, op.Name, op.FName, op.MName }).Where(o => o.RegNo >= minx && o.RegNo <= maxx)
                                                select new
                                                {
                                                    sr1.RegNo,
                                                    sr1.Name,
                                                    sr1.FName,
                                                }).OrderBy(o => o.RegNo).ToListAsync();

                string customHeading0 = "Sl #";
                string customHeading1 = "Roll No";
                string customHeading2 = "Reg. No";
                string customHeading3 = "Due Papers";
                string customHeading4 = "Ep Papers";
                string customHeading5 = "Ex Papers";

                var newHeading = new
                {
                    customHeading0,
                    customHeading1,
                    customHeading2,
                    customHeading3,
                    customHeading4,
                    customHeading5,
                };

                List<TabulationsControllerModel29> newOutput = new();

                int rowCount = 1;

                foreach (var item in x)
                {
                    var r = customOutput.Where(i => i.RegNo == item).FirstOrDefault();

                    //var t = tempNameCollection.Where(i => i.RegNo == item).FirstOrDefault();
                    //var dd = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => new { o.Name, o.FName}).FirstOrDefault();

                    if (r != null)
                    {
                        TabulationsControllerModel29 s = new();

                        s.SlNo = rowCount;
                        s.ExamRollNo = r.ExamRollNo ?? 0;
                        s.RegNo = r.RegNo ?? 0;
                        //s.Name = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.Name).FirstOrDefault();
                        //s.FName = tempNameCollection.Where(i => i.RegNo == r.RegNo).Select(o => o.FName).FirstOrDefault();

                        var co = customOutput.Where(i => i.RegNo == r.RegNo).FirstOrDefault();
                        s.EpPapers = co.ResultDetails.Count(o => o.Grade == "ep");
                        s.ExPapers = co.ResultDetails.Count(o => o.Grade == "ex");
                        s.DuePapers = subjects.Count - r.TotalNoOfPass - co.ResultDetails.Count(o => o.Grade == "ep") - co.ResultDetails.Count(o => o.Grade == "ex");
                        //s.Subject1Grade = r.Subject1Grade;
                        //s.Subject2Grade = r.Subject2Grade;
                        //s.Subject3Grade = r.Subject3Grade;
                        //s.Subject4Grade = r.Subject4Grade;
                        //s.Subject5Grade = r.Subject5Grade;
                        //s.Subject6Grade = r.Subject6Grade;
                        //s.Subject7Grade = r.Subject7Grade;

                        newOutput.Add(s);

                        rowCount++;
                    }
                }

                bool isRowCountValid = newOutput.Count > 0;

                return StatusCode(isRowCountValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = isRowCountValid ? "List of " + newOutput.Count + " Candidates failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear : "No list of Candidate found failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                    Success = isRowCountValid,
                    Payload = isRowCountValid ? new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = GetMonthName,
                        Subjects = newHeading,
                        tabulationSheetData = newOutput.OrderBy(i => i.RegNo).ToList(),
                        RowCount = newOutput.Count
                    } : null
                });
            }
            //7.25.3 - rest of subject report with barcode - encoded 
            else if (input.RestOfSubjectListReportWithBarcode == 1 && input.AppearedPapers != null && input.PassedPapers != null)
            {
                List<int> s61 = await (from e in _context.Set<ExamReg>()
                                       where e.ExamLevel == input.ExamLevel && e.MonthId == input.MonthId && e.SessionYear == input.SessionYear
                                       join r in _context.Set<RegSubject>() on e.Ref equals r.RefNo
                                       group e by e.RegNo into g
                                       where g.Count() == input.AppearedPapers
                                       select g.Key).ToListAsync();

                //int numberOfAttemptedSubject = 0;
                if (input.AppearedPapers == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                    {
                        Message = "Selection invalid for number of subject attempted in candidate failed report",
                        Success = false,
                        Payload = null
                    });
                }

                List<TabulationsControllerModel1> customOutput = new();

                foreach (var item in s61)
                {
                    var z = output.Where(i => i.RegNo == item && i.TotalNoOfPass == input.PassedPapers && i.ResultDetails.Count(i => i.BarCode != null) == input.AppearedPapers).FirstOrDefault();

                    if (z != null)
                    {
                        customOutput.Add(z);
                    }
                }

                List<int?> x = customOutput.Select(i => i.RegNo).ToList();

                if (x == null || x.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No candidate details found for failed in " + GetExamLevelName + " of session " + GetMonthName + ", " + input.SessionYear,
                        Success = false,
                        Payload = null
                    });
                }

                int minx = x.Min() ?? 0;
                int maxx = x.Max() ?? 0;

                if (input.ExamLevel == 61 || input.ExamLevel == 62)
                {
                    List<TabulationsControllerModel14> gg = (from r in customOutput
                                                             select new TabulationsControllerModel14
                                                             {
                                                                 SlNo = 0,
                                                                 Subject1Barcode = r.ResultDetails.Skip(0).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject1Marks = r.ResultDetails.Skip(0).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject2Barcode = r.ResultDetails.Skip(1).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject2Marks = r.ResultDetails.Skip(1).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject3Barcode = r.ResultDetails.Skip(2).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject3Marks = r.ResultDetails.Skip(2).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject4Barcode = r.ResultDetails.Skip(3).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject4Marks = r.ResultDetails.Skip(3).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject5Barcode = r.ResultDetails.Skip(4).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject5Marks = r.ResultDetails.Skip(4).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject6Barcode = r.ResultDetails.Skip(5).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject6Marks = r.ResultDetails.Skip(5).Select(i => i.Marks).FirstOrDefault(),
                                                                 Subject7Barcode = r.ResultDetails.Skip(6).Select(i => i.BarCode).FirstOrDefault(),
                                                                 Subject7Marks = r.ResultDetails.Skip(6).Select(i => i.Marks).FirstOrDefault(),
                                                                 TotalMarksAchieved = r.TotalMarksAchieved,
                                                                 Subject1Grade = r.ResultDetails.Skip(0).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject2Grade = r.ResultDetails.Skip(1).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject3Grade = r.ResultDetails.Skip(2).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject4Grade = r.ResultDetails.Skip(3).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject5Grade = r.ResultDetails.Skip(4).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject6Grade = r.ResultDetails.Skip(5).Select(i => i.Grade).FirstOrDefault(),
                                                                 Subject7Grade = r.ResultDetails.Skip(6).Select(i => i.Grade).FirstOrDefault(),
                                                                 TotalNoOfPass = r.TotalNoOfPass
                                                             }).ToList();
                    int rr = 1;
                    foreach (var item in gg)
                    {
                        item.SlNo = rr;
                        rr++;
                    }
                    string startHeading = "SL#";
                    var newHeading = new
                    {
                        startHeading,
                        heading.Subject1Name,
                        heading.Subject2Name,
                        heading.Subject3Name,
                        heading.Subject4Name,
                        heading.Subject5Name,
                        heading.Subject6Name,
                        heading.Subject7Name,
                        heading.TotalHeading,
                        heading.Subject1ShortName,
                        heading.Subject2ShortName,
                        heading.Subject3ShortName,
                        heading.Subject4ShortName,
                        heading.Subject5ShortName,
                        heading.Subject6ShortName,
                        heading.Subject7ShortName,
                        heading.SubPassedHeading
                    };

                    if (gg == null || gg.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    statistics.Subject1Present = customOutput.Count(i => i.ResultDetails.Skip(0).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject2Present = customOutput.Count(i => i.ResultDetails.Skip(1).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject3Present = customOutput.Count(i => i.ResultDetails.Skip(2).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject4Present = customOutput.Count(i => i.ResultDetails.Skip(3).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject5Present = customOutput.Count(i => i.ResultDetails.Skip(4).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject6Present = customOutput.Count(i => i.ResultDetails.Skip(5).Select(j => j.BarCode).FirstOrDefault() != null);
                    statistics.Subject7Present = customOutput.Count(i => i.ResultDetails.Skip(6).Select(j => j.BarCode).FirstOrDefault() != null);

                    statistics.Subject1Pass = gg.Count(p => p.Subject1Grade == "A" || p.Subject1Grade == "B");
                    statistics.Subject2Pass = gg.Count(p => p.Subject2Grade == "A" || p.Subject2Grade == "B");
                    statistics.Subject3Pass = gg.Count(p => p.Subject3Grade == "A" || p.Subject3Grade == "B");
                    statistics.Subject4Pass = gg.Count(p => p.Subject4Grade == "A" || p.Subject4Grade == "B");
                    statistics.Subject5Pass = gg.Count(p => p.Subject5Grade == "A" || p.Subject5Grade == "B");
                    statistics.Subject6Pass = gg.Count(p => p.Subject6Grade == "A" || p.Subject6Grade == "B");
                    statistics.Subject7Pass = gg.Count(p => p.Subject7Grade == "A" || p.Subject7Grade == "B");

                    statistics.Subject1Percentage = statistics.Subject1Present > 0 ? ((double)statistics.Subject1Pass / (double)statistics.Subject1Present) * 100 : 0;
                    statistics.Subject2Percentage = statistics.Subject2Present > 0 ? ((double)statistics.Subject2Pass / (double)statistics.Subject2Present) * 100 : 0;
                    statistics.Subject3Percentage = statistics.Subject3Present > 0 ? ((double)statistics.Subject3Pass / (double)statistics.Subject3Present) * 100 : 0;
                    statistics.Subject4Percentage = statistics.Subject4Present > 0 ? ((double)statistics.Subject4Pass / (double)statistics.Subject4Present) * 100 : 0;
                    statistics.Subject5Percentage = statistics.Subject5Present > 0 ? ((double)statistics.Subject5Pass / (double)statistics.Subject5Present) * 100 : 0;
                    statistics.Subject6Percentage = statistics.Subject6Present > 0 ? ((double)statistics.Subject6Pass / (double)statistics.Subject6Present) * 100 : 0;
                    statistics.Subject7Percentage = statistics.Subject7Present > 0 ? ((double)statistics.Subject7Pass / (double)statistics.Subject7Present) * 100 : 0;

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details for " + gg.Count + " students",
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = gg,
                            Statistics = statistics,
                            RowCount = gg.Count
                        }
                    });
                }
                else if (input.ExamLevel == 63)
                {
                    var newOutput = (from r in customOutput
                                     select new TabulationsControllerModel15
                                     {
                                         SlNo = 0,
                                         Subject1Barcode = r.ResultDetails.Skip(0).Select(i => i.BarCode).FirstOrDefault(),
                                         Subject1Marks = r.ResultDetails.Skip(0).Select(i => i.Marks).FirstOrDefault(),
                                         Subject2Barcode = r.ResultDetails.Skip(1).Select(i => i.BarCode).FirstOrDefault(),
                                         Subject2Marks = r.ResultDetails.Skip(1).Select(i => i.Marks).FirstOrDefault(),
                                         Subject3Barcode = r.ResultDetails.Skip(2).Select(i => i.BarCode).FirstOrDefault(),
                                         Subject3Marks = r.ResultDetails.Skip(2).Select(i => i.Marks).FirstOrDefault(),
                                         TotalMarksAchieved = r.TotalMarksAchieved,
                                         Subject1Grade = r.ResultDetails.Skip(0).Select(i => i.Grade).FirstOrDefault(),
                                         Subject2Grade = r.ResultDetails.Skip(1).Select(i => i.Grade).FirstOrDefault(),
                                         Subject3Grade = r.ResultDetails.Skip(2).Select(i => i.Grade).FirstOrDefault(),
                                         TotalNoOfPass = r.TotalNoOfPass
                                     }).ToList();

                    int rowCount = 1;

                    foreach (var item in newOutput)
                    {
                        item.SlNo = rowCount;
                        rowCount++;
                    }

                    string startHeading = "SL#";
                    var newHeading = new
                    {
                        startHeading,
                        headingType2.Subject1Name,
                        headingType2.Subject2Name,
                        headingType2.Subject3Name,
                        headingType2.TotalHeading,
                        headingType2.Subject1ShortName,
                        headingType2.Subject2ShortName,
                        headingType2.Subject3ShortName,
                        headingType2.SubPassedHeading
                    };

                    if (newOutput == null || newOutput.Count == 0)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                        {
                            Message = "No tabulation sheet details found for given criteria",
                            Success = false,
                            Payload = null
                        });
                    }

                    statisticsType2.Subject1Present = customOutput.Count(i => i.ResultDetails.Skip(0).Select(j => j.BarCode).FirstOrDefault() != null);
                    statisticsType2.Subject2Present = customOutput.Count(i => i.ResultDetails.Skip(1).Select(j => j.BarCode).FirstOrDefault() != null);
                    statisticsType2.Subject3Present = customOutput.Count(i => i.ResultDetails.Skip(2).Select(j => j.BarCode).FirstOrDefault() != null);

                    statisticsType2.Subject1Pass = newOutput.Count(p => p.Subject1Grade == "A" || p.Subject1Grade == "B");
                    statisticsType2.Subject2Pass = newOutput.Count(p => p.Subject2Grade == "A" || p.Subject2Grade == "B");
                    statisticsType2.Subject3Pass = newOutput.Count(p => p.Subject3Grade == "A" || p.Subject3Grade == "B");

                    statisticsType2.Subject1Percentage = statisticsType2.Subject1Present > 0 ? ((double)statisticsType2.Subject1Pass / (double)statisticsType2.Subject1Present) * 100 : 0;
                    statisticsType2.Subject2Percentage = statisticsType2.Subject2Present > 0 ? ((double)statisticsType2.Subject2Pass / (double)statisticsType2.Subject2Present) * 100 : 0;
                    statisticsType2.Subject3Percentage = statisticsType2.Subject3Present > 0 ? ((double)statisticsType2.Subject3Pass / (double)statisticsType2.Subject3Present) * 100 : 0;

                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "Tabulation sheet details for " + newOutput.Count + " students",
                        Success = true,
                        Payload = new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            Subjects = newHeading,
                            tabulationSheetData = newOutput,
                            Statistics = statisticsType2,
                            RowCount = newOutput.Count
                        }
                    });
                }


            }
            //7.26 - number of completed subject report
            else if (input.NumberOfCompletedSubjectListReport == 1)
            {
                int rc = 1;
                if (input.RegistrationNumberRange == 1)
                {
                    var ff = output.Where(i => i.RegNo >= input.RegistrationNumberFrom && i.RegNo <= input.RegistrationNumberTo && (i.TotalNoOfPass + i.ResultDetails.Count(o => o.Grade == "ep") + i.ResultDetails.Count(o => o.Grade == "ex")) == input.NumberOfCompletedSubjects).ToList();
                    List<TabulationsControllerModel30> fff2 = (from f in ff
                                                               select new TabulationsControllerModel30
                                                               {
                                                                   SlNo = 0,
                                                                   RegNo = f.RegNo ?? 0,
                                                                   ExamRollNo = f.ExamRollNo ?? 0
                                                               }).ToList();
                    foreach (var g in fff2)
                    {
                        g.SlNo = rc;
                        rc++;
                    }

                    return StatusCode(ff.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = ff.Count > 0 ? "Tabulation sheet details for " + ff.Count + " students" : "No data found for given criteria",
                        Success = ff.Count > 0,
                        Payload = ff.Count > 0 ? new
                        {
                            ControllerName = signature?.Controller,
                            ControllerSign = signature?.FilepathControllerSign,
                            SecretaryCeoName = signature?.SecretaryCeo,
                            SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                            ExamLevelName = GetExamLevelName,
                            MonthName = GetMonthName,
                            //Subjects = heading,
                            Output = ff,
                        } : null
                    });

                }

                var ff2 = output.Where(i => (i.TotalNoOfPass + i.ResultDetails.Count(o => o.Grade == "ep") + i.ResultDetails.Count(o => o.Grade == "ex")) == input.NumberOfCompletedSubjects).ToList();
                List<TabulationsControllerModel30> fff = (from f in ff2
                                                          select new TabulationsControllerModel30
                                                          {
                                                              SlNo = 0,
                                                              RegNo = f.RegNo ?? 0,
                                                              ExamRollNo = f.ExamRollNo ?? 0
                                                          }).ToList();
                foreach (var g in fff)
                {
                    g.SlNo = rc;
                    rc++;
                }

                return StatusCode(ff2.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = ff2.Count > 0 ? "Tabulation sheet details for " + ff2.Count + " students" : "No data found for given criteria",
                    Success = ff2.Count > 0,
                    Payload = ff2.Count > 0 ? new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = GetMonthName,
                        //Subjects = heading,
                        Output = ff2,
                    } : null
                });
            }
            //number of passed subject report
            else if (input.NumberOfPassedSubjectListReport == 1)
            {
                List<string> validGrades = new() { "A", "B", "ep", "ex" };
                var ff = input.NumberOfPassedSubjectListRegNoFrom > 0 && input.NumberOfPassedSubjectListRegNoTo > 0 && input.NumberOfPassedSubjectListRegNoFrom <= input.NumberOfPassedSubjectListRegNoTo ?
                    output.Where(i => i.RegNo >= input.NumberOfPassedSubjectListRegNoFrom && i.RegNo <= input.NumberOfPassedSubjectListRegNoTo && i.ResultDetails.Count(i => validGrades.Contains(i.Grade)) == input.NumberOfPassedSubjects).OrderBy(i => i.RegNo).ToList() :
                    output.Where(i => i.ResultDetails.Count(i => validGrades.Contains(i.Grade)) == input.NumberOfPassedSubjects).OrderBy(i => i.RegNo).ToList();

                List<string> s = new();
                List<string> ss = new();

                if (ff.Count > 0)
                {
                    if (input.ExamLevel == 61)
                    {
                        s = new List<string> { "Assurance", "Accounting", "Business & Finance", "Management Information", "Principles of Taxation", "Business Law", "Information Technology" };
                        ss = new List<string> { "AS", "AC", "BF", "MI", "PT", "BL", "IT" };
                    }
                    else if (input.ExamLevel == 62)
                    {
                        s = new List<string> { "Audit & Assurance", "Financial Accounting & Reporting", "Business Strategy", "Financial Management", "Tax Planning & Compliance", "Corporate Laws & Practices", "IT Governanc" };
                        ss = new List<string> { "AA", "FAR", "BS", "FM", "TAX", "CLP", "ITG" };
                    }
                    else if (input.ExamLevel == 63)
                    {
                        s = new List<string> { "Corporate Reporting", "Strategic Business Management", "Case Study" };
                        ss = new List<string> { "CR", "SBM", "CS" };
                    }
                }

                return StatusCode(ff.Count > 0 ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = ff.Count > 0 ? "Tabulation sheet details for " + ff.Count + " students" : "No data found for given criteria",
                    Success = ff.Count > 0,
                    Payload = ff.Count > 0 ? new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = GetMonthName,
                        SubjectNames = s,
                        SubjectShortNames = ss,
                        Output = ff,
                        RowCount = ff.Count
                    } : null
                });
            }
            if (input.ExamLevel == 63)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Tabulation sheet details for " + resultsType2.Count + " students",
                    Success = true,
                    Payload = new
                    {
                        ControllerName = signature?.Controller,
                        ControllerSign = signature?.FilepathControllerSign,
                        SecretaryCeoName = signature?.SecretaryCeo,
                        SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                        ExamLevelName = GetExamLevelName,
                        MonthName = GetMonthName,
                        Subjects = headingType2,
                        tabulationSheetData = resultsType2,
                        Statistics = statisticsType2,
                        RowCount = resultsType2.Count
                    }
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Tabulation sheet details for " + results.Count + " students",
                Success = true,
                Payload = new
                {
                    ControllerName = signature?.Controller,
                    ControllerSign = signature?.FilepathControllerSign,
                    SecretaryCeoName = signature?.SecretaryCeo,
                    SecretaryCeoSign = signature?.FilepathSecretaryCeoSign,
                    ExamLevelName = GetExamLevelName,
                    MonthName = GetMonthName,
                    Subjects = heading,
                    tabulationSheetData = results,
                    Statistics = statistics,
                    RowCount = results.Count
                }
            });
        }

        private bool IsAllSubjectPassed(List<TabulationsControllerModel2> rd)
        {
            bool isFailFound = rd.Any(k => k.Grade == "C" || k.Grade == "D" || k.Grade == "E");

            if (isFailFound == true)
            {
                return false;
            }

            if (isFailFound == false)
            {
                return true;
            }
            return false;
        }


        //private bool IsAtLeastOneFail(List<TabulationsControllerModel2> rd)
        //{
        //    bool isFailFound = rd.Any(k => k.Grade == "C" || k.Grade == "D" || k.Grade == "E");

        //    if (isFailFound == true)
        //    {
        //        return false;
        //    }

        //    if (isFailFound == false)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}