using Microsoft.AspNetCore.Mvc;
using ICABAPI.Data;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using System.IO;
using Microsoft.AspNetCore.Http;
using ICABAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace ICABAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCustomController : BaseApiController
    {
        private readonly ModelContext _context;
        private readonly AwsS3CompatibleStorageRepository _awsS3CompatibleStorageRepository = new();
        private readonly ResponseDto2 _responseDto2 = new();
        public TestCustomController(ModelContext context)
        {
            _context = context;
        }

        //[HttpGet("UploadDefaultImageToS3")]
        //public async Task<ActionResult<ResponseDto2>> UploadDefaultImageToS3()
        //{
        //    List<StuReg1> stuReg1s = await Task.Run(() => _context.StuReg1s.Where(i => i.Defaultimage != null).OrderBy(l => l.RegNo).ToList());
        //    if (stuReg1s == null)
        //    {
        //        _responseDto2.Message = "No data found";
        //        _responseDto2.Success = false;
        //        _responseDto2.Payload = null;
        //        return StatusCode(StatusCodes.Status404NotFound, _responseDto2);
        //    }
        //    foreach (var sr1 in stuReg1s)
        //    {
        //        if (sr1.Defaultimage != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument/" + sr1.RegNo.ToString(), sr1.RegNo.ToString() + ".jpeg", sr1.Defaultimage);
        //            if (dto2.Success == true)
        //            {
        //                sr1.Imagepath = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + sr1.RegNo.ToString() + "/" + sr1.RegNo.ToString() + ".jpeg";
        //            }
        //        }
        //        _context.StuReg1s.Update(sr1);
        //        await _context.SaveChangesAsync();
        //    }
        //    _responseDto2.Message = "Default images uploaded";
        //    _responseDto2.Success = true;
        //    _responseDto2.Payload = null;
        //    return StatusCode(StatusCodes.Status200OK, _responseDto2);
        //}
        //[HttpGet("UploadRequestedImageToS3")]
        //public async Task<ActionResult<ResponseDto2>> UploadRequestedImageToS3()
        //{
        //    List<StuReg1> stuReg1s = await Task.Run(() => _context.StuReg1s.Where(i => i.Requestednewimage != null && i.Imageapprovalpending == 0).OrderBy(l => l.RegNo).ToList());
        //    if (stuReg1s == null)
        //    {
        //        _responseDto2.Message = "No data found";
        //        _responseDto2.Success = false;
        //        _responseDto2.Payload = null;
        //        return StatusCode(StatusCodes.Status404NotFound, _responseDto2);
        //    }
        //    foreach (var sr1 in stuReg1s)
        //    {
        //        if (sr1.Requestednewimage != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument/" + sr1.RegNo.ToString(), "r" + sr1.RegNo.ToString() + ".jpeg", sr1.Requestednewimage);
        //        }
        //        _context.StuReg1s.Update(sr1);
        //        await _context.SaveChangesAsync();
        //    }
        //    _responseDto2.Message = "Unapproved requested image uploaded";
        //    _responseDto2.Success = true;
        //    _responseDto2.Payload = null;
        //    return StatusCode(StatusCodes.Status200OK, _responseDto2);
        //}
        //[HttpGet("UploadTempExamRegToS3")]
        //public async Task<ActionResult<ResponseDto2>> UploadTempExamRegToS3()
        //{
        //    List<TempExamReg> tempExamRegs = await Task.Run(() => _context.TempExamRegs.ToList());
        //    if (tempExamRegs == null)
        //    {
        //        _responseDto2.Message = "No data found";
        //        _responseDto2.Success = false;
        //        _responseDto2.Payload = null;
        //        return StatusCode(StatusCodes.Status404NotFound, _responseDto2);
        //    }
        //    foreach (var ter in tempExamRegs)
        //    {
        //        if (ter.FilepathAttenAttached != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "coachingClassAttendance", "ATC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg", ter.FileAttenAttached);
        //            if (dto2.Success == true)
        //            {
        //                ter.FilepathAttenAttached = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "coachingClassAttendance" + "/" + "ATC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg";
        //            }
        //        }
        //        if (ter.FileFitnessAttached != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "fitnessCertificate", "FC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg", ter.FileFitnessAttached);
        //            if (dto2.Success == true)
        //            {
        //                ter.FilepathFitnessAttached = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "fitnessCertificate" + "/" + "FC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg";
        //            }
        //        }
        //        if (ter.FileTrainingAttached != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "trainingCertificate", "TRC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg", ter.FileTrainingAttached);
        //            if (dto2.Success == true)
        //            {
        //                ter.FilepathTrainingAttached = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "trainingCertificate" + "/" + "TRC" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg";
        //            }
        //        }
        //        if (ter.ExfeeuploadPayslip != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "examFeePayslip", "EPS" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg", ter.ExfeeuploadPayslip);
        //            if (dto2.Success == true)
        //            {
        //                ter.FilepathExfeeuploadPayslip = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "examFeePayslip" + "/" + "EPS" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg";
        //            }
        //        }
        //        if (ter.AnnfeeuploadPayslip != null)
        //        {
        //            ResponseDto2 dto2 = await _awsS3CompatibleStorageRepository.UploadBytesInAFolderAsync("studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "annualFeePayslip", "APS" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg", ter.AnnfeeuploadPayslip);
        //            if (dto2.Success == true)
        //            {
        //                ter.FilepathAnnfeeuploadPayslip = "https://s3.brilliant.com.bd" + "/" + "icab-exam" + "/" + "studentDocument" + "/" + ter.RegNo.ToString() + "/" + "formFillup" + "/" + ter.SessionYear.ToString() + "/" + ter.MonthId.ToString() + "/" + ter.ExamLevel.ToString() + "/" + "annualFeePayslip" + "/" + "APS" + "_" + ter.RegNo.ToString() + "_" + ter.ExamLevel.ToString() + "_" + ter.MonthId.ToString() + "_" + ter.SessionYear.ToString() + ".jpeg";
        //            }
        //        }
        //        _context.TempExamRegs.Update(ter);
        //        await _context.SaveChangesAsync();
        //    }
        //    _responseDto2.Message = "Form fillup images uploaded";
        //    _responseDto2.Success = true;
        //    _responseDto2.Payload = null;
        //    return StatusCode(StatusCodes.Status200OK, _responseDto2);
        //}
    }
}