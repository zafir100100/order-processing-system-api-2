using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using ICABAPI.DTOs;
//using ICABAPI.DTOs.cpl_studentdtos;
//using ICABAPI.DTOs.CPLDtos;
using ICABAPI.Interfaces;
using ICABAPI.Models;
//using ICABAPI.Models.Cpl_Models;
//using ICABAPI.Models.Cpls_Student_Models;
using ICABAPI.Roles;
using ICABAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ICABAPI.Controllers
{
    public class GetCplPaymentReportInput
    {
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public string Status { get; set; }
    }
    public class GetCplPaymentReportOutput
    {
        public decimal? Amount { get; set; }
        public string CardType { get; set; }
        public int? ExamLevel { get; set; }
        public int? Id { get; set; }
        public int? SlNo { get; set; }
        public int? MonthId { get; set; }
        public string Name { get; set; }
        public string PaymentError { get; set; }
        public DateTime? PaymentTime { get; set; }
        public string RedirectUrl { get; set; }
        public int? RegNo { get; set; }
        public string SessionKey { get; set; }
        public int? SessionYear { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
    }
    public class CplSubjectMappingCustom
    {
        public decimal Id { get; set; }
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public decimal IcabSubjectId { get; set; }
        public decimal Gpa { get; set; }
        public int ExamLevel { get; set; }
        public string SubName { get; set; }
        public string CourseName { get; set; }
    }

    public class CplSubjectMappingCustom2
    {
        public decimal Id { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
        public List<IcabSubjects> AssignSubjects { get; set; }

    }

    public class IcabSubjects
    {
        public int SubId { get; set; }
        public string SubName { get; set; }
        public List<IcabSubjectsEqualCourse> Courses { get; set; }
    }

    public class IcabSubjectsEqualCourse
    {
        public int IcabSubjectId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal RequiredGpa { get; set; }
    }

    public class InputForCreateCplUnivertisity
    {
        public string UniversityName { get; set; }
    }
    public class InputForUpdateCplUnivertisity
    {
        public decimal UniversityId { get; set; }
        public string UniversityName { get; set; }
    }
    public class InputForDeleteCplUnivertisity
    {
        public decimal UniversityId { get; set; }
    }
    public class InputForCreateCplDepartment
    {
        public decimal UniversityId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Cgpa { get; set; }
    }
    public class OutputForCplSubjectMappingReport
    {
        public string UniversityName { get; set; }
        public string DepartmentName { get; set; }
        public string IcabSubjectName { get; set; }
        public string CourseName { get; set; }
        public decimal Gpa { get; set; }
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal IcabSubjectId { get; set; }
        public decimal ExamLevel { get; set; }
        public decimal CourseId { get; set; }
    }
    public class InputForUpdateCplDepartment
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Cgpa { get; set; }
    }
    public class InputForGeteCplByDepartmentwithLevel
    {
        public int ExamLevel { get; set; }
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
    }
    public class InputForDeleteCplDepartment
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
    }
    public class InputForCreateCplCourse
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public string CourseName { get; set; }
    }
    public class InputForUpdateCplCourse
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public string CourseName { get; set; }
    }
    public class InputForDeleteCplCourse
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
    }
    public class InputForCreateCplSubjectMapping
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public decimal IcabSubjectId { get; set; }
        public decimal Gpa { get; set; }
        public int ExamLevel { get; set; }
    }
    public class InputForUpdateCplSubjectMapping
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public decimal IcabSubjectId { get; set; }
        public decimal Gpa { get; set; }

    }
    public class InputForDeleteCplSubjectMapping
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal CourseId { get; set; }
        public decimal IcabSubjectId { get; set; }
    }
    public class InputForGetCplSubjectMappingByIcabSubject
    {
        public decimal UniversityId { get; set; }
        public decimal DepartmentId { get; set; }
        public decimal IcabSubjectId { get; set; }
    }
    public class InputForGetAllCplSubmission
    {
        public int ExamLevel { get; set; }
        //public int MonthId { get; set; }
        //public int SessionYear { get; set; }
    }
    public class InputForCreateCplSubmission3
    {
        public string PayslipNumber { get; set; }
        public string FileCplPayslip { get; set; }
        public string PaymentMode { get; set; }
    }

    public class InputForCreateCplSubmission2
    {
        public decimal CplUniversityId { get; set; }
        public decimal CplDepartmentId { get; set; }
        public decimal CplCourseId { get; set; }
        public decimal CplIcabSubjectId { get; set; }
        public decimal ObtainedGpa { get; set; }
    }

    public class InputForCreateCplSubmission
    {
        public decimal SubmissionId { get; set; }
        public decimal RegNo { get; set; }
        public decimal ExamLevel { get; set; }
        public decimal MonthId { get; set; }
        public decimal SessionYear { get; set; }
        public decimal ObtainedCgpa { get; set; }

        public List<InputForCreateCplSubmission2> AcademicDetails { get; set; }
        public string FileAcademicTranscript { get; set; }
        public string FileMembershipCertificate { get; set; }
        public string FileIcabIdCard { get; set; }
        public string FileCplPayslip { get; set; }
        public string PayslipNumber { get; set; }
        public string PaymentMode { get; set; }
    }
    public class InputForUpdateCplSubmission2
    {
        public decimal CplUniversityId { get; set; }
        public decimal CplDepartmentId { get; set; }
        public decimal CplCourseId { get; set; }
        public decimal CplIcabSubjectId { get; set; }
        public decimal ObtainedGpa { get; set; }
    }
    public class InputForUpdateCplSubmission
    {
        public decimal SubmissionId { get; set; }
        public decimal ObtainedCgpa { get; set; }

        public List<InputForUpdateCplSubmission2> AcademicDetails { get; set; }
        public string FileAcademicTranscript { get; set; }
        public string FileMembershipCertificate { get; set; }
        public string FileIcabIdCard { get; set; }
        public string FileCplPayslip { get; set; }
        public string PayslipNumber { get; set; }
        public string PaymentMode { get; set; }
    }

    public class InputForConfirmCplSubmission
    {
        public decimal SubmissionId { get; set; }
    }

    public class OutputForCplSubjectMappingCustom
    {
        public decimal SubId { get; set; }
        public string SubName { get; set; }
        public List<CplSubjectMappingCustom> CplSubjectMappings { get; set; }
    }

    //  [Authorize(Roles = "SuperAdmin")]
    // [Authorize]
    public class CPLController : BaseApiAdminController
    {
        private readonly ModelContext _context;
        private readonly IEmailService _emailService;
        public CPLController(ModelContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [HttpGet("GetAllCplUnivertisity")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplUnivertisity()
        {
            bool isValid = await _context.CplUniversities.AnyAsync();
            if (isValid == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No CPL University Found",
                    Success = isValid,
                    Payload = null
                });
            }
            List<CplUniversity> cplUniversities = await _context.CplUniversities
                                                                  .Include(cplUniversitiy => cplUniversitiy.CplDepartments.OrderBy(j => j.DepartmentName))
                                                                  .ThenInclude(cplDepartment => cplDepartment.CplCourses.OrderBy(j => j.CourseName))
                                                                  .ThenInclude(cplCourse => cplCourse.CplSubjectMappings.OrderBy(j => j.IcabSubjectId))
                                                                  .OrderBy(i => i.UniversityId)
                                                                  .ToListAsync();
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + cplUniversities.Count + " CPL University",
                Success = isValid,
                Payload = new
                {
                    Output = cplUniversities,
                    Count = cplUniversities.Count
                }
            });
        }
        [HttpPost("CreateMultipleCplUnivertisity")]
        public async Task<ActionResult<ResponseDto2>> CreateMultipleCplUnivertisity([FromBody] List<InputForCreateCplUnivertisity> input)
        {
            int createdRow = 0;
            foreach (var item in input)
            {
                CplUniversity cplUniversity = new();
                cplUniversity.UniversityId = await _context.CplUniversities.AnyAsync() == false ? 1 : await _context.CplUniversities.MaxAsync(i => i.UniversityId) + 1;
                cplUniversity.UniversityName = item.UniversityName;
                _context.CplUniversities.Add(cplUniversity);
                createdRow += await _context.SaveChangesAsync();
            }
            bool isValid = createdRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? createdRow + " CPL Universitiy Created" : "CPL University creation failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = isValid ? new
                {
                    Count = createdRow
                } : null
            });
        }
        //[HttpPatch("UpdateMultipleCplUnivertisity")]
        //public async Task<ActionResult<ResponseDto2>> UpdateMultipleCplUnivertisity([FromBody] List<InputForUpdateCplUnivertisity> input)
        //{
        //    int updatedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplUniversity cplUniversity = await _context.CplUniversities.Where(i => i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
        //        if (cplUniversity != null)
        //        {
        //            cplUniversity.UniversityName = item.UniversityName;
        //            _context.Entry(cplUniversity).Property(o => o.UniversityName).IsModified = true;
        //            updatedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = updatedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Universitiy Updated" : "CPL University update failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpPatch("UpdateCplUnivertisity")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplUnivertisity([FromBody] InputForUpdateCplUnivertisity input)
        {
            CplUniversity cplUniversity = await _context.CplUniversities.Where(i => i.UniversityId == input.UniversityId).FirstOrDefaultAsync();
            if (cplUniversity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL University not found",
                    Success = false,
                    Payload = null
                });
            }
            cplUniversity.UniversityName = input.UniversityName;
            _context.CplUniversities.Update(cplUniversity);
            _context.Entry(cplUniversity).Property(x => x.Id).IsModified = false;
            int updatedRow = await _context.SaveChangesAsync();
            bool isValid = updatedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? updatedRow + " CPL Universitiy Updated" : "CPL University update failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        //[HttpDelete("DeleteMultipleCplUnivertisity")]
        //public async Task<ActionResult<ResponseDto2>> DeleteMultipleCplUnivertisity([FromBody] List<InputForDeleteCplUnivertisity> input)
        //{
        //    int deletedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplUniversity cplUniversity = await _context.CplUniversities.Where(i => i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
        //        if (cplUniversity != null)
        //        {
        //            List<CplDepartment> cplDepartments = await _context.CplDepartments.Where(i => i.UniversityId == cplUniversity.UniversityId).ToListAsync();
        //            if (cplDepartments.Count > 0)
        //            {
        //                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //                {
        //                    Message = "The university has " + cplDepartments.Count + " department. Please delete them first",
        //                    Success = false,
        //                    Payload = null
        //                });
        //            }
        //            _context.CplUniversities.Remove(cplUniversity);
        //            deletedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = deletedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Universitiy Deleted" : "CPL University deletion failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpDelete("DeleteCplUnivertisity")]
        public async Task<ActionResult<ResponseDto2>> DeleteCplUnivertisity([FromBody] InputForDeleteCplUnivertisity input)
        {
            CplUniversity cplUniversity = await _context.CplUniversities.Where(i => i.UniversityId == input.UniversityId).FirstOrDefaultAsync();
            if (cplUniversity == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL University not found",
                    Success = false,
                    Payload = null
                });
            }
            List<CplDepartment> cplDepartments = await _context.CplDepartments.Where(i => i.UniversityId == cplUniversity.UniversityId).ToListAsync();
            if (cplDepartments.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The university has " + cplDepartments.Count + " department. Please delete them first",
                    Success = false,
                    Payload = null
                });
            }
            _context.CplUniversities.Remove(cplUniversity);
            int deletedRow = await _context.SaveChangesAsync();
            bool isValid = deletedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? deletedRow + " CPL Universitiy Deleted" : "CPL University deletion failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }

        [HttpGet("GetAllCplDepartment")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplDepartment()
        {
            bool isValid = await _context.CplDepartments.AnyAsync();
            if (isValid == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No CPL Department Found",
                    Success = isValid,
                    Payload = null
                });
            }
            List<CplDepartment> cplDepartments = await _context.CplDepartments
                                                               .Include(cplDepartment => cplDepartment.CplCourses.OrderBy(j => j.CourseName))
                                                               .ThenInclude(cplCourse => cplCourse.CplSubjectMappings.OrderBy(j => j.IcabSubjectId))
                                                               .OrderBy(i => i.UniversityId).ThenBy(j => j.DepartmentId)
                                                               .ToListAsync();

            //fixing parent properties
            foreach (var item in cplDepartments)
            {
                item.University = await _context.CplUniversities.Where(i => i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
                item.University.CplDepartments = null;
                item.CplCourses = null;
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + cplDepartments.Count + " CPL university with department",
                Success = isValid,
                Payload = new
                {
                    Output = cplDepartments,
                }
            });
        }
        [HttpPost("GetAllCplDepartmentByUniversity")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplDepartmentByUniversity([FromBody] InputForDeleteCplUnivertisity input)
        {
            List<CplDepartment> cplDepartments = await _context.CplDepartments
                                                               .Where(i => i.UniversityId == input.UniversityId)
                                                               .Include(cplDepartment => cplDepartment.CplCourses.OrderBy(j => j.CourseName))
                                                               .ThenInclude(cplCourse => cplCourse.CplSubjectMappings.OrderBy(j => j.IcabSubjectId))
                                                               .OrderBy(i => i.DepartmentName)
                                                               .ToListAsync();
            bool isValid = cplDepartments.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplDepartments.Count + " CPL Department" : "No CPL department info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = cplDepartments,
                    Count = cplDepartments.Count
                } : null
            });
        }
        [HttpPost("CreateMultipleCplDepartment")]
        public async Task<ActionResult<ResponseDto2>> CreateMultipleCplDepartment([FromBody] List<InputForCreateCplDepartment> input)
        {
            int createdRow = 0;
            foreach (var item in input)
            {
                CplDepartment cplDepartment = new();
                cplDepartment.UniversityId = item.UniversityId;
                cplDepartment.DepartmentId = await _context.CplDepartments.AnyAsync(i => i.UniversityId == item.UniversityId) == false ? 1 : await _context.CplDepartments.Where(k => k.UniversityId == item.UniversityId).MaxAsync(i => i.DepartmentId) + 1;
                cplDepartment.DepartmentName = item.DepartmentName;
                cplDepartment.Cgpa = item.Cgpa;
                _context.CplDepartments.Add(cplDepartment);
                createdRow += await _context.SaveChangesAsync();
            }
            bool isValid = createdRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? createdRow + " CPL Deparment Created" : "CPL Department creation failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = isValid ? new
                {
                    Count = createdRow
                } : null
            });
        }
        //[HttpPatch("UpdateMultipleCplDepartment")]
        //public async Task<ActionResult<ResponseDto2>> UpdateMultipleCplDepartment([FromBody] List<InputForUpdateCplDepartment> input)
        //{
        //    int updatedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplDepartment cplDepartment = await _context.CplDepartments.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId).FirstOrDefaultAsync();
        //        if (cplDepartment != null)
        //        {
        //            cplDepartment.DepartmentName = item.DepartmentName;
        //            _context.Entry(cplDepartment).Property(o => o.DepartmentName).IsModified = true;
        //            updatedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = updatedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Department Updated" : "CPL Department update failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpPatch("UpdateCplDepartment")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplDepartment([FromBody] InputForUpdateCplDepartment input)
        {
            CplDepartment cplDepartment = await _context.CplDepartments.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId).FirstOrDefaultAsync();
            if (cplDepartment == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Department not found",
                    Success = false,
                    Payload = null
                });
            }
            cplDepartment.DepartmentName = input.DepartmentName;
            cplDepartment.Cgpa = input.Cgpa;
            _context.CplDepartments.Update(cplDepartment);
            _context.Entry(cplDepartment).Property(x => x.Id).IsModified = false;
            int updatedRow = await _context.SaveChangesAsync();
            bool isValid = updatedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? updatedRow + " CPL Department Updated" : "CPL Department update failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        //[HttpDelete("DeleteMultipleCplDepartment")]
        //public async Task<ActionResult<ResponseDto2>> DeleteMultipleCplDepartment([FromBody] List<InputForDeleteCplDepartment> input)
        //{
        //    int deletedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplDepartment cplDepartment = await _context.CplDepartments.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId).FirstOrDefaultAsync();
        //        if (cplDepartment != null)
        //        {
        //            List<CplCourse> cplCourses = await _context.CplCourses.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId).ToListAsync();
        //            if (cplCourses.Count > 0)
        //            {
        //                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //                {
        //                    Message = "The deparment has " + cplCourses.Count + " courses. Please delete them first",
        //                    Success = false,
        //                    Payload = null
        //                });
        //            }
        //            _context.CplDepartments.Remove(cplDepartment);
        //            deletedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = deletedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Department Deleted" : "CPL department deletion failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpDelete("DeleteCplDepartment")]
        public async Task<ActionResult<ResponseDto2>> DeleteCplDepartment([FromBody] InputForDeleteCplDepartment input)
        {
            CplDepartment cplDepartment = await _context.CplDepartments.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId).FirstOrDefaultAsync();
            if (cplDepartment == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Department not found",
                    Success = false,
                    Payload = null
                });
            }
            List<CplCourse> cplCourses = await _context.CplCourses.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId).ToListAsync();
            if (cplCourses.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The department has " + cplCourses.Count + " courses. Please delete them first",
                    Success = false,
                    Payload = null
                });
            }
            _context.CplDepartments.Remove(cplDepartment);
            int deletedRow = await _context.SaveChangesAsync();
            bool isValid = deletedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? deletedRow + " CPL Department Deleted" : "CPL department deletion failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }

        [HttpGet("GetAllCplCourse")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplCourse()
        {
            bool isValid = await _context.CplSubjectMappings.AnyAsync();
            if (isValid == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No CPL Course Found",
                    Success = isValid,
                    Payload = null
                });
            }
            List<CplCourse> cplCourses = await _context.CplCourses
                                                               .Include(cplCourse => cplCourse.CplSubjectMappings.OrderBy(j => j.IcabSubjectId))
                                                               .OrderBy(i => i.UniversityId).ThenBy(j => j.DepartmentId).ThenBy(k => k.CourseId)
                                                               .ToListAsync();

            //fixing parent properties
            foreach (var item in cplCourses)
            {
                item.CplDepartment = await _context.CplDepartments.Where(i => i.DepartmentId == item.DepartmentId && i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
                item.CplDepartment.University = await _context.CplUniversities.Where(i => i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
                item.CplDepartment.University.CplDepartments = null;
                item.CplDepartment.CplCourses = null;

            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + cplCourses.Count + " CPL university with department and course",
                Success = isValid,
                Payload = new
                {
                    Output = cplCourses,
                }
            });
        }
        [HttpPost("GetAllCplCourseByDepartment")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplCourseByDepartment([FromBody] InputForDeleteCplDepartment input)
        {
            List<CplCourse> cplCourses = await _context.CplCourses.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId).OrderBy(l => l.CourseName).ToListAsync();
            bool isValid = cplCourses.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplCourses.Count + " CPL Course" : "No CPL Course info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = cplCourses,
                    Count = cplCourses.Count
                } : null
            });
        }
        [HttpPost("CreateMultipleCplCourse")]
        public async Task<ActionResult<ResponseDto2>> CreateMultipleCplCourse([FromBody] List<InputForCreateCplCourse> input)
        {
            int createdRow = 0;
            foreach (var item in input)
            {
                CplCourse cplCourse = new();
                cplCourse.UniversityId = item.UniversityId;
                cplCourse.DepartmentId = item.DepartmentId;
                cplCourse.CourseId = await _context.CplCourses.AnyAsync(k => k.UniversityId == item.UniversityId && k.DepartmentId == item.DepartmentId) == false ? 1 : await _context.CplCourses.Where(k => k.UniversityId == item.UniversityId && k.DepartmentId == item.DepartmentId).MaxAsync(i => i.CourseId) + 1;
                cplCourse.CourseName = item.CourseName;
                _context.CplCourses.Add(cplCourse);
                createdRow += await _context.SaveChangesAsync();
            }
            bool isValid = createdRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? createdRow + " CPL Deparment Created" : "CPL Department creation failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = isValid ? new
                {
                    Count = createdRow
                } : null
            });
        }
        //[HttpPatch("UpdateMultipleCplCourse")]
        //public async Task<ActionResult<ResponseDto2>> UpdateMultipleCplCourse([FromBody] List<InputForUpdateCplCourse> input)
        //{
        //    int updatedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplCourse cplCourse = await _context.CplCourses.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId).FirstOrDefaultAsync();
        //        if (cplCourse != null)
        //        {
        //            cplCourse.CourseName = item.CourseName;
        //            _context.Entry(cplCourse).Property(o => o.CourseName).IsModified = true;
        //            updatedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = updatedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Course Updated" : "CPL Course update failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpPatch("UpdateCplCourse")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplCourse([FromBody] InputForUpdateCplCourse input)
        {
            CplCourse cplCourse = await _context.CplCourses.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId).FirstOrDefaultAsync();
            if (cplCourse == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Course not found",
                    Success = false,
                    Payload = null
                });
            }
            cplCourse.CourseName = input.CourseName;
            _context.CplCourses.Update(cplCourse);
            _context.Entry(cplCourse).Property(x => x.Id).IsModified = false;
            int updatedRow = await _context.SaveChangesAsync();
            bool isValid = updatedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? updatedRow + " CPL Course Updated" : "CPL Course update failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        //[HttpDelete("DeleteMultipleCplCourse")]
        //public async Task<ActionResult<ResponseDto2>> DeleteMultipleCplCourse([FromBody] List<InputForDeleteCplCourse> input)
        //{
        //    int deletedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplCourse cplCourse = await _context.CplCourses.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId).FirstOrDefaultAsync();
        //        if (cplCourse != null)
        //        {
        //            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId).ToListAsync();
        //            if (cplSubjectMappings.Count > 0)
        //            {
        //                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
        //                {
        //                    Message = "The course has " + cplSubjectMappings.Count + " with icab subject. Please delete them first",
        //                    Success = false,
        //                    Payload = null
        //                });
        //            }
        //            _context.CplCourses.Remove(cplCourse);
        //            deletedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = deletedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Course Deleted" : "CPL Course deletion failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpDelete("DeleteCplCourse")]
        public async Task<ActionResult<ResponseDto2>> DeleteCplCourse([FromBody] InputForDeleteCplCourse input)
        {
            CplCourse cplCourse = await _context.CplCourses.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId).FirstOrDefaultAsync();
            if (cplCourse == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Course not found",
                    Success = false,
                    Payload = null
                });
            }
            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId).ToListAsync();
            if (cplSubjectMappings.Count > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "The course has " + cplSubjectMappings.Count + " subject mapping. Please delete them first",
                    Success = false,
                    Payload = null
                });
            }
            _context.CplCourses.Remove(cplCourse);
            int deletedRow = await _context.SaveChangesAsync();
            bool isValid = deletedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? deletedRow + " CPL Course Deleted" : "CPL Course deletion failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        [HttpGet("GetAllCplSubjectMapping")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplSubjectMapping()
        {
            bool isValid = await _context.CplSubjectMappings.AnyAsync();
            if (isValid == false)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No CPL Subject Mapping Info found",
                    Success = false,
                    Payload = null
                });
            }
            List<CplSubjectMapping> cplSubjectMappings =
                  await _context.CplSubjectMappings
                                .OrderBy(i => i.UniversityId)
                                .ToListAsync();

            //fixing parent properties
            foreach (var item in cplSubjectMappings)
            {
                item.CplCourse = await _context.CplCourses.Where(i => i.CourseId == item.CourseId).FirstOrDefaultAsync();
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + cplSubjectMappings.Count + " CPL university with department, course and subject mapping",
                Success = true,
                Payload = new
                {
                    Output = cplSubjectMappings,
                }
            });
        }
        [HttpPost("GetAllCplSubjectMappingByExamLevelAndDepartment")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplSubjectMappingByExamLevelAndDepartment([FromBody] InputForGeteCplByDepartmentwithLevel input)
        {
            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings
                .Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.ExamLevel == input.ExamLevel)
                .OrderBy(j => j.IcabSubjectId)
                .ToListAsync();

            // if not found then close it
            if (cplSubjectMappings.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No CPL Subject Mapping info found",
                    Success = false,
                    Payload = null
                });
            }
            List<Subject> subjects = await _context.Subjects.Where(i => i.Parent == input.ExamLevel).ToListAsync();
            List<CplSubjectMappingCustom> cplSubjects = new();
            foreach (var item in cplSubjectMappings)
            {
                CplSubjectMappingCustom cc = new CplSubjectMappingCustom();

                cc.UniversityId = item.UniversityId;
                cc.DepartmentId = item.DepartmentId;
                cc.CourseId = item.CourseId;
                cc.CourseName = _context.CplCourses.Where(x => x.UniversityId == item.UniversityId && x.DepartmentId == item.DepartmentId && x.CourseId == item.CourseId).Select(y => y.CourseName).FirstOrDefault();
                cc.IcabSubjectId = item.IcabSubjectId;
                cc.SubName = subjects.Where(g => g.SubId == item.IcabSubjectId).Select(x => x.SubName).FirstOrDefault();
                cc.Gpa = item.Gpa;
                cplSubjects.Add(cc);
            }
            List<int> foundSubjects = cplSubjectMappings.Select(i => (int)i.IcabSubjectId).OrderBy(j => j).Distinct().ToList();
            List<OutputForCplSubjectMappingCustom> output = new();
            foreach (var subjectId in foundSubjects)
            {
                OutputForCplSubjectMappingCustom outputForCplSubjectMappingCustom = new();
                outputForCplSubjectMappingCustom.SubId = subjectId;
                outputForCplSubjectMappingCustom.SubName = subjects.Where(i => i.SubId == subjectId).Select(o => o.SubName).FirstOrDefault();
                outputForCplSubjectMappingCustom.CplSubjectMappings = cplSubjects.Where(i => i.IcabSubjectId == subjectId).OrderBy(j => j.CourseId).ToList();
                output.Add(outputForCplSubjectMappingCustom);
            }
            bool isValid = cplSubjectMappings.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplSubjectMappings.Count + " CPL Subject Mapping" : "No CPL Subject Mapping info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = output
                } : null
            });
        }
        [HttpPost("GetAllCplSubjectMappingByDepartment")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplSubjectMappingByDepartment([FromBody] InputForGeteCplByDepartmentwithLevel input)
        {

            if (input.UniversityId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "University ID can not be null",
                    Success = false,
                    Payload = null
                });
            }

            if (input.DepartmentId < 1)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Deveplopment ID can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings
                .Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.ExamLevel == input.ExamLevel)
                .OrderBy(j => j.DepartmentId).ThenBy(k => k.CourseId)
                .ToListAsync();

            List<decimal> subjectCollection = cplSubjectMappings.Select(k => k.IcabSubjectId).Distinct().ToList();
            List<IcabSubjects> subs = new();
            CplSubjectMappingCustom2 SubjectMapping = new();

            foreach (var i in subjectCollection)
            {
                IcabSubjects sub = new();

                sub.SubId = Convert.ToInt32(i);
                sub.SubName = _context.Subjects.Where(g => g.SubId == i).Select(x => x.SubName).FirstOrDefault();

                subs.Add(sub);
            }

            SubjectMapping.AssignSubjects = subs;

            foreach (var item in SubjectMapping.AssignSubjects)
            {
                List<IcabSubjectsEqualCourse> icabSubjectsEquals = new();
                foreach (var items in cplSubjectMappings)
                {
                    if (items.IcabSubjectId == item.SubId)
                    {
                        IcabSubjectsEqualCourse iSub = new();

                        iSub.IcabSubjectId = Convert.ToInt32(items.IcabSubjectId);
                        iSub.CourseId = Convert.ToInt32(items.CourseId);
                        iSub.CourseName = _context.CplCourses.Where(x => x.UniversityId == items.UniversityId && x.DepartmentId == items.DepartmentId && x.CourseId == items.CourseId).Select(y => y.CourseName).FirstOrDefault();
                        iSub.RequiredGpa = items.Gpa;

                        icabSubjectsEquals.Add(iSub);
                    }
                }

                item.Courses = icabSubjectsEquals;
            }

            SubjectMapping.UniversityId = Convert.ToInt32(input.UniversityId);
            SubjectMapping.DepartmentId = Convert.ToInt32(input.DepartmentId);


            bool isValid = cplSubjectMappings.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplSubjectMappings.Count + " CPL Subject Mapping" : "No CPL Subject Mapping info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = SubjectMapping
                } : null
            });
        }
        [HttpPost("GetAllCplSubjectMappingByIcabSubject")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplSubjectMappingByIcabSubject([FromBody] InputForGetCplSubjectMappingByIcabSubject input)
        {
            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.IcabSubjectId == input.IcabSubjectId).OrderBy(j => j.IcabSubjectId).ToListAsync();
            bool isValid = cplSubjectMappings.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplSubjectMappings.Count + " CPL Subject Mapping" : "No CPL Subject Mapping info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = cplSubjectMappings,
                    Count = cplSubjectMappings.Count
                } : null
            });
        }
        [HttpPost("GetAllCplSubjectMappingByCourse")]
        public async Task<ActionResult<ResponseDto2>> GetAllCplSubjectMappingByCourse([FromBody] InputForDeleteCplCourse input)
        {
            List<CplSubjectMapping> cplSubjectMappings = await _context.CplSubjectMappings.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId).OrderBy(j => j.IcabSubjectId).ToListAsync();
            bool isValid = cplSubjectMappings.Count > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "List of " + cplSubjectMappings.Count + " CPL Subject Mapping" : "No CPL Subject Mapping info found",
                Success = isValid,
                Payload = isValid ? new
                {
                    Output = cplSubjectMappings,
                    Count = cplSubjectMappings.Count
                } : null
            });
        }
        [HttpPost("CreateMultipleCplSubjectMapping")]
        public async Task<ActionResult<ResponseDto2>> CreateMultipleCplSubjectMapping([FromBody] List<InputForCreateCplSubjectMapping> input)
        {
            int createdRow = 0;
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                foreach (var item in input)
                {
                    CplSubjectMapping cplSubjectMappingOld = await _context.CplSubjectMappings.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId && i.IcabSubjectId == item.IcabSubjectId).FirstOrDefaultAsync();
                    if (cplSubjectMappingOld != null)
                    {
                        CplUniversity cplUniversity = await _context.CplUniversities.Where(i => i.UniversityId == item.UniversityId).FirstOrDefaultAsync();
                        CplDepartment cplDepartment = await _context.CplDepartments.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId).FirstOrDefaultAsync();
                        CplCourse cplCourse = await _context.CplCourses.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId).FirstOrDefaultAsync();
                        Subject subject = await _context.Subjects.Where(i => i.SubId == item.IcabSubjectId).FirstOrDefaultAsync();
                        return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                        {
                            Message = "The course: " + cplCourse.CourseName + " offered by " + cplDepartment.DepartmentName + " of " + cplUniversity.UniversityName + " is already mapped with ICAB subject: " + subject.SubName + " with gpa: " + cplSubjectMappingOld.Gpa,
                            Success = false,
                            Payload = null
                        });
                    }
                    CplSubjectMapping cplSubjectMapping = new();
                    cplSubjectMapping.UniversityId = item.UniversityId;
                    cplSubjectMapping.DepartmentId = item.DepartmentId;
                    cplSubjectMapping.CourseId = item.CourseId;
                    cplSubjectMapping.IcabSubjectId = item.IcabSubjectId;
                    cplSubjectMapping.ExamLevel = item.ExamLevel;
                    cplSubjectMapping.Gpa = item.Gpa;

                    _context.CplSubjectMappings.Add(cplSubjectMapping);
                    createdRow += await _context.SaveChangesAsync();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "CPL Subject Mapping creation failed. Something went wrong. Please try again later..",
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
            bool isValid = createdRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? createdRow + " CPL Subject Mapping Created" : "CPL Subject Mapping creation failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = isValid ? new
                {
                    Count = createdRow
                } : null
            });
        }
        //[HttpPatch("UpdateMultipleCplSubjectMapping")]
        //public async Task<ActionResult<ResponseDto2>> UpdateMultipleCplSubjectMapping([FromBody] List<InputForUpdateCplSubjectMapping> input)
        //{
        //    int updatedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplSubjectMapping cplSubjectMapping = await _context.CplSubjectMappings.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId && i.IcabSubjectId == item.IcabSubjectId).FirstOrDefaultAsync();
        //        if (cplSubjectMapping != null)
        //        {
        //            cplSubjectMapping.Gpa = item.Gpa;
        //            _context.Entry(cplSubjectMapping).Property(o => o.Gpa).IsModified = true;
        //            updatedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = updatedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Subject Mapping Updated" : "CPL Subject mapping update failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpPatch("UpdateCplSubjectMapping")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplSubjectMapping([FromBody] InputForUpdateCplSubjectMapping input)
        {
            CplSubjectMapping cplSubjectMapping = await _context.CplSubjectMappings.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId && i.IcabSubjectId == input.IcabSubjectId).FirstOrDefaultAsync();
            if (cplSubjectMapping == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Subject mapping not found",
                    Success = false,
                    Payload = null
                });
            }
            cplSubjectMapping.Gpa = input.Gpa;
            _context.CplSubjectMappings.Update(cplSubjectMapping);
            _context.Entry(cplSubjectMapping).Property(o => o.Id).IsModified = false;
            int updatedRow = await _context.SaveChangesAsync();
            bool isValid = updatedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? updatedRow + " CPL Subject Mapping Updated" : "CPL Subject mapping update failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        //[HttpDelete("DeleteMultipleCplSubjectMapping")]
        //public async Task<ActionResult<ResponseDto2>> DeleteMultipleCplSubjectMapping([FromBody] List<InputForDeleteCplSubjectMapping> input)
        //{
        //    int deletedRow = 0;
        //    foreach (var item in input)
        //    {
        //        CplSubjectMapping cplSubjectMapping = await _context.CplSubjectMappings.Where(i => i.UniversityId == item.UniversityId && i.DepartmentId == item.DepartmentId && i.CourseId == item.CourseId && i.IcabSubjectId == item.IcabSubjectId).FirstOrDefaultAsync();
        //        if (cplSubjectMapping != null)
        //        {
        //            _context.CplSubjectMappings.Remove(cplSubjectMapping);
        //            deletedRow += await _context.SaveChangesAsync();
        //        }
        //    }
        //    bool isValid = deletedRow > 0;
        //    return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
        //    {
        //        Message = isValid ? input.Count + " CPL Subject Mapping Deleted" : "CPL Subject Mapping deletion failed. Something went wrong. Please try again later.",
        //        Success = isValid,
        //        Payload = isValid ? new
        //        {
        //            Count = input.Count
        //        } : null
        //    });
        //}
        [HttpDelete("DeleteCplSubjectMapping")]
        public async Task<ActionResult<ResponseDto2>> DeleteCplSubjectMapping([FromBody] InputForDeleteCplSubjectMapping input)
        {
            CplSubjectMapping cplSubjectMapping = await _context.CplSubjectMappings.Where(i => i.UniversityId == input.UniversityId && i.DepartmentId == input.DepartmentId && i.CourseId == input.CourseId && i.IcabSubjectId == input.IcabSubjectId).FirstOrDefaultAsync();
            if (cplSubjectMapping == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Subject mapping not found",
                    Success = false,
                    Payload = null
                });
            }
            int isInCplSubmission = await _context.CplSubmissionAcademicDetails.CountAsync(i => i.CplUniversityId == input.UniversityId && i.CplDepartmentId == input.DepartmentId && i.CplCourseId == input.CourseId && i.CplIcabSubjectId == input.IcabSubjectId);
            if (isInCplSubmission > 0)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = isInCplSubmission + " Cpl submission found for this Cpl subject mapping, please delete them first",
                    Success = false,
                    Payload = null
                });
            }
            _context.CplSubjectMappings.Remove(cplSubjectMapping);
            int deletedRow = await _context.SaveChangesAsync();
            bool isValid = deletedRow > 0;
            return StatusCode(isValid == true ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = isValid ? deletedRow + " CPL Subject Mapping Deleted" : "CPL Subject Mapping deletion failed. Something went wrong. Please try again later.",
                Success = isValid,
                Payload = null
            });
        }
        [HttpPost("GetAllUnapprovedCplSubmission")]
        public async Task<ActionResult<ResponseDto2>> GetAllUnapprovedCplSubmission([FromBody] InputForGetAllCplSubmission input)
        {
            List<CplSubmission> cplSubmissions = await _context.CplSubmissions
                .Where(i => i.ExamLevel == input.ExamLevel && i.IsCplApproved == 0)
                .OrderByDescending(o => o.SubmissionId)
                .ToListAsync();
            if (cplSubmissions.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Cpl Submission found for given criteria",
                    Success = false,
                    Payload = null
                });
            }
            var newOutput = (from x in cplSubmissions
                             select new
                             {
                                 x.SubmissionId,
                                 x.RegNo,
                                 Name = _context.StuReg1s.Where(i => i.RegNo == x.RegNo).Select(x => x.Name).FirstOrDefault()
                             }).ToList();
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of unapproved CPL submission",
                Success = true,
                Payload = new
                {
                    Output = newOutput
                }
            });
        }
        [HttpPost("GetCplSubmissionData")]
        public async Task<ActionResult<ResponseDto2>> GetCplSubmissionData([FromBody] InputForConfirmCplSubmission input)
        {
            CplSubmission cplSubmission = await _context.CplSubmissions.Where(i => i.SubmissionId == input.SubmissionId).FirstOrDefaultAsync();
            if (cplSubmission != null)
            {
                List<CplSubmissionAcademicDetail> cplSubmissionAcademicDetails = await _context.CplSubmissionAcademicDetails.Where(i => i.SubmissionId == input.SubmissionId).ToListAsync();
                CplSubmissionFilesCommon cplSubmissionFilesCommon = await _context.CplSubmissionFilesCommons.Where(i => i.SubmissionId == input.SubmissionId).FirstOrDefaultAsync();
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "CPL Submission Data found",
                    Success = true,
                    Payload = new
                    {
                        Output1 = cplSubmission,
                        Output2 = cplSubmissionAcademicDetails,
                        Output3 = cplSubmissionFilesCommon
                    }
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Submission Not found for given criterial",
                    Success = false,
                    Payload = null
                });
            }
        }
        [HttpPost("CreateCplSubmission")]
        public async Task<ActionResult<ResponseDto2>> CreateCplSubmission([FromBody] InputForCreateCplSubmission input)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //create basic data
                CplSubmission cplSubmissions = await _context.CplSubmissions.Where(i => i.ExamLevel == input.ExamLevel && i.RegNo == input.RegNo).FirstOrDefaultAsync();
                if (cplSubmissions != null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "This student has already claimed CPL for this exam level",
                        Success = false,
                        Payload = null
                    });
                }

                CplSubmission cplSubmission = new CplSubmission();

                cplSubmission.SubmissionId = await _context.CplSubmissions.AnyAsync() == false ? 1 : await _context.CplSubmissions.MaxAsync(o => o.SubmissionId) + 1;
                cplSubmission.IsCplApproved = input.PaymentMode.ToLower() == "online" ? -1 : 0;
                cplSubmission.RegNo = input.RegNo;
                cplSubmission.ExamLevel = input.ExamLevel;
                cplSubmission.MonthId = input.MonthId;
                cplSubmission.SessionYear = input.SessionYear;
                cplSubmission.ObtainedCgpa = input.ObtainedCgpa;
                cplSubmission.SubmissionDate = DateTime.Now;
                _context.CplSubmissions.Add(cplSubmission);
                int isCplSubmissionCreated = await _context.SaveChangesAsync();
                //create academic data
                int isCplAcademicDetailsCreated = 0;
                foreach (var item in input.AcademicDetails)
                {
                    CplSubmissionAcademicDetail cplSubmissionAcademicDetail = new();
                    cplSubmissionAcademicDetail.SubmissionId = cplSubmission.SubmissionId;
                    cplSubmissionAcademicDetail.CplUniversityId = item.CplUniversityId;
                    cplSubmissionAcademicDetail.CplDepartmentId = item.CplDepartmentId;
                    cplSubmissionAcademicDetail.CplCourseId = item.CplCourseId;
                    cplSubmissionAcademicDetail.CplIcabSubjectId = item.CplIcabSubjectId;
                    cplSubmissionAcademicDetail.ObtainedGpa = item.ObtainedGpa;

                    _context.CplSubmissionAcademicDetails.Add(cplSubmissionAcademicDetail);
                    isCplAcademicDetailsCreated += await _context.SaveChangesAsync();
                }
                //create common file data
                CplSubmissionFilesCommon cplSubmissionFilesCommon = new();
                cplSubmissionFilesCommon.SubmissionId = cplSubmission.SubmissionId;
                cplSubmissionFilesCommon.FileAcademicTranscript = input.FileAcademicTranscript;
                cplSubmissionFilesCommon.FileMembershipCertificate = input.FileMembershipCertificate;
                cplSubmissionFilesCommon.FileIcabIdCard = input.FileIcabIdCard;

                cplSubmissionFilesCommon.FileCplPayslip = input.FileCplPayslip;
                cplSubmissionFilesCommon.PayslipNumber = input.PayslipNumber;
                cplSubmissionFilesCommon.PaymentMode = input.PaymentMode;
                _context.CplSubmissionFilesCommons.Add(cplSubmissionFilesCommon);
                int isCplSubmissionFilesCommonCreated = await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "CPL submission creation failed. Something went wrong. Please try again later",
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
                Message = "CPL Submission Created Successfully",
                Success = true,
                Payload = null
            });
        }
        [HttpPut("UpdateCplSubmission")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplSubmission([FromBody] InputForUpdateCplSubmission input)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                CplSubmission cplSubmission = await _context.CplSubmissions.Where(o => o.SubmissionId == input.SubmissionId).FirstOrDefaultAsync();
                if (cplSubmission != null)
                {
                    //update basic data
                    cplSubmission.ObtainedCgpa = input.ObtainedCgpa;
                    _context.CplSubmissions.Update(cplSubmission);
                    int isCplSubmissionUpdated = await _context.SaveChangesAsync();
                    //update academic data
                    int isCplAcademicDetailsDeleted = 0;
                    List<CplSubmissionAcademicDetail> cplSubmissionAcademicDetails = await _context.CplSubmissionAcademicDetails.Where(i => i.SubmissionId == input.SubmissionId).ToListAsync();
                    if (cplSubmissionAcademicDetails.Count > 0)
                    {
                        foreach (var item in cplSubmissionAcademicDetails)
                        {
                            _context.CplSubmissionAcademicDetails.Remove(item);
                            isCplAcademicDetailsDeleted += await _context.SaveChangesAsync();
                        }
                    }
                    int isCplAcademicDetailsCreated = 0;
                    foreach (var item in input.AcademicDetails)
                    {
                        CplSubmissionAcademicDetail cplSubmissionAcademicDetail = new();
                        cplSubmissionAcademicDetail.SubmissionId = cplSubmission.SubmissionId;
                        cplSubmissionAcademicDetail.CplUniversityId = item.CplUniversityId;
                        cplSubmissionAcademicDetail.CplDepartmentId = item.CplDepartmentId;
                        cplSubmissionAcademicDetail.CplCourseId = item.CplCourseId;
                        cplSubmissionAcademicDetail.CplIcabSubjectId = item.CplIcabSubjectId;
                        cplSubmissionAcademicDetail.ObtainedGpa = item.ObtainedGpa;
                        _context.CplSubmissionAcademicDetails.Add(cplSubmissionAcademicDetail);
                        isCplAcademicDetailsCreated += await _context.SaveChangesAsync();
                    }
                    //update common file data
                    CplSubmissionFilesCommon cplSubmissionFilesCommon = await _context.CplSubmissionFilesCommons.Where(i => i.SubmissionId == input.SubmissionId).FirstOrDefaultAsync();
                    int isCplFilesCommonUpdated = 0;
                    if (cplSubmissionFilesCommon != null)
                    {
                        cplSubmissionFilesCommon.FileAcademicTranscript = input.FileAcademicTranscript;
                        cplSubmissionFilesCommon.FileMembershipCertificate = input.FileMembershipCertificate;
                        cplSubmissionFilesCommon.FileIcabIdCard = input.FileIcabIdCard;

                        cplSubmissionFilesCommon.FileCplPayslip = input.FileCplPayslip;
                        cplSubmissionFilesCommon.PayslipNumber = input.PayslipNumber;
                        cplSubmissionFilesCommon.PaymentMode = input.PaymentMode;
                        _context.CplSubmissionFilesCommons.Update(cplSubmissionFilesCommon);
                        isCplFilesCommonUpdated += await _context.SaveChangesAsync();
                    }
                    transaction.Commit();
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No CPL Submission found for given criteria",
                        Success = false,
                        Payload = null
                    });
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "CPL submission creation failed. Something went wrong. Please try again later",
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
                Message = "CPL Submission Updated Successfully",
                Success = true,
                Payload = null
            });
        }
        [HttpPatch("ConfirmCplSubmissions")]
        public async Task<ActionResult<ResponseDto2>> ConfirmCplSubmission([FromBody] InputForConfirmCplSubmission input)
        {
            CplSubmission cplSubmission = await _context.CplSubmissions.Where(i => i.SubmissionId == input.SubmissionId).FirstOrDefaultAsync();
            if (cplSubmission != null)
            {
                if (cplSubmission.IsCplApproved == 1)
                {
                    return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                    {
                        Message = "CPL Submission is already approved",
                        Success = false,
                        Payload = null
                    });
                }
                //update submission status
                cplSubmission.IsCplApproved = 1;
                _context.CplSubmissions.Update(cplSubmission);
                int iscplSubmissionUpdated = await _context.SaveChangesAsync();
                //send data to set exmp mou
                List<CplSubmissionAcademicDetail> cplSubmissionAcademicDetails = await _context.CplSubmissionAcademicDetails.Where(i => i.SubmissionId == input.SubmissionId).ToListAsync();
                if (cplSubmissionAcademicDetails.Count > 0)
                {

                    TempExamReg tempExamReg = await _context.TempExamRegs.Where(i => i.RegNo == cplSubmission.RegNo && i.ExamLevel == cplSubmission.ExamLevel && i.MonthId == cplSubmission.MonthId && i.SessionYear == cplSubmission.SessionYear).FirstOrDefaultAsync();
                    foreach (var item in cplSubmissionAcademicDetails)
                    {
                        bool isExistsInSetExmpMou = await _context.SetExmpMous.AnyAsync(i => i.RegNo == cplSubmission.RegNo && i.ExmptSubid == item.CplIcabSubjectId);
                        if (isExistsInSetExmpMou == false)
                        {
                            SetExmpMou setExmpMou = new();
                            setExmpMou.ExamLevel = (int?)cplSubmission.ExamLevel;
                            setExmpMou.ExamSession = (int?)cplSubmission.MonthId;
                            setExmpMou.ExamYear = (int?)cplSubmission.SessionYear;
                            setExmpMou.ExmptSubid = (int?)item.CplIcabSubjectId;
                            setExmpMou.RegNo = (int?)cplSubmission.RegNo;
                            setExmpMou.StudType = 1;
                            _context.SetExmpMous.Add(setExmpMou);
                            int isAddedToSetExmpMou = await _context.SaveChangesAsync();
                        }

                        if (tempExamReg != null)
                        {
                            bool isExistsInExemptedSub = await _context.ExemptedSubs.AnyAsync(i => i.RegNo == cplSubmission.RegNo && i.SubId == item.CplIcabSubjectId);
                            if (isExistsInSetExmpMou == false)
                            {
                                ExemptedSub exemptedSub = new();
                                exemptedSub.ExamLevel = (int?)cplSubmission.ExamLevel;
                                exemptedSub.Ref = tempExamReg.Ref;
                                exemptedSub.RegNo = (int?)cplSubmission.RegNo;
                                exemptedSub.SubId = (int?)item.CplIcabSubjectId;
                                _context.ExemptedSubs.Add(exemptedSub);
                                int isAddedToExemptedSub = await _context.SaveChangesAsync();
                            }
                        }

                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Submission Not found for given criterial",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "CPL Submission Approved Successfully",
                Success = true,
                Payload = null
            });
        }
        [HttpGet("GetCplSubjectMappingReport")]
        public async Task<ActionResult<ResponseDto2>> GetCplSubjectMappingReport()
        {
            List<OutputForCplSubjectMappingReport> o = await (from csm in _context.CplSubjectMappings.OrderBy(i => i.UniversityId).ThenBy(i => i.DepartmentId).ThenBy(i => i.IcabSubjectId).ThenBy(i => i.CourseId)
                                                              join cu in _context.CplUniversities
                                                              on csm.UniversityId equals cu.UniversityId
                                                              join cd in _context.CplDepartments
                                                              on new { csm.UniversityId, csm.DepartmentId } equals new { cd.UniversityId, cd.DepartmentId }
                                                              join cc in _context.CplCourses
                                                              on new { csm.UniversityId, csm.DepartmentId, csm.CourseId } equals new { cc.UniversityId, cc.DepartmentId, cc.CourseId }
                                                              join sub in _context.Subjects
                                                              on csm.IcabSubjectId equals sub.SubId
                                                              select new OutputForCplSubjectMappingReport
                                                              {
                                                                  CourseName = cc.CourseName,
                                                                  UniversityName = cu.UniversityName,
                                                                  DepartmentName = cd.DepartmentName,
                                                                  IcabSubjectName = sub.SubName,
                                                                  Gpa = csm.Gpa,
                                                                  UniversityId = csm.UniversityId,
                                                                  DepartmentId = csm.DepartmentId,
                                                                  CourseId = csm.CourseId,
                                                                  IcabSubjectId = csm.IcabSubjectId,
                                                                  ExamLevel = sub.Parent
                                                              }).ToListAsync();
            bool isValid = o.Count > 0;
            return StatusCode(isValid ? StatusCodes.Status200OK : StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = isValid ? "Cpl info found" : "No Cpl subject mapping found",
                Success = isValid,
                Payload = isValid ? new { Output = o } : null
            });
        }
        [HttpPost("GetCplPaymentReport")]
        public async Task<ActionResult<ResponseDto2>> GetCplPaymentReport([FromBody] GetCplPaymentReportInput input)
        {
            decimal totalSum = 0;
            if (input.Status.ToLower() == "offline")
            {
                List<CplSubmission> cplSubmissions = await _context.CplSubmissions.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear).OrderByDescending(i => i.SubmissionDate).ToListAsync();
                if (cplSubmissions == null || cplSubmissions.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No cpl payment data found for given exam level",
                        Success = false,
                        Payload = null
                    });
                }
                List<GetCplPaymentReportOutput> outputs = new();
                int counter = 0;
                foreach (var item in cplSubmissions)
                {
                    GetCplPaymentReportOutput getCplPaymentReportOutput = new();
                    counter++;
                    getCplPaymentReportOutput.SlNo = counter;
                    List<int> validSubs = await _context.CplSubmissionAcademicDetails.Where(i => i.SubmissionId == item.SubmissionId).OrderBy(i => i.CplIcabSubjectId).Select(o => ((int)o.CplIcabSubjectId)).Distinct().ToListAsync();
                    getCplPaymentReportOutput.Amount = await _context.ExamFees.Where(i => i.ExamLevel == input.ExamLevel && i.MonthId == input.MonthId && i.SessionYear == input.SessionYear && validSubs.Contains((int)i.SubId)).SumAsync(i => i.Amount) ?? 0;
                    getCplPaymentReportOutput.Name = await _context.StuReg1s.Where(i => i.RegNo == item.RegNo).Select(i => i.Name).FirstOrDefaultAsync();
                    getCplPaymentReportOutput.PaymentTime = item.SubmissionDate;
                    getCplPaymentReportOutput.RegNo = (int)item.RegNo;
                    getCplPaymentReportOutput.TransactionId = await _context.CplSubmissionFilesCommons.Where(i => i.SubmissionId == item.SubmissionId).Select(i => i.PayslipNumber).FirstOrDefaultAsync();
                    outputs.Add(getCplPaymentReportOutput);
                    totalSum += getCplPaymentReportOutput.Amount ?? 0;
                }
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "List of " + outputs.Count + " CPL OFFLINE payment details",
                    Success = true,
                    Payload = new
                    {
                        Output = outputs,
                        TotalSum = totalSum
                    }
                });
            }
            return null;
        }
        [HttpPatch("update-cpl-online-payment-data-before-approval")]
        public async Task<ActionResult<ResponseDto2>> UpdateCplPaymentBeforeApproval([FromBody] InputForConfirmCplSubmission input)
        {
            CplSubmission cplSubmission = await _context.CplSubmissions.Where(i => i.SubmissionId == input.SubmissionId && i.IsCplApproved == -1).FirstOrDefaultAsync();
            if (cplSubmission == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "CPL Submission not found",
                    Success = false,
                    Payload = null
                });
            }
            if (cplSubmission != null)
            {
                //update submission status
                cplSubmission.IsCplApproved = 0;
                _context.CplSubmissions.Update(cplSubmission);
                int iscplSubmissionUpdated = await _context.SaveChangesAsync();

                if (iscplSubmissionUpdated == 1)
                {
                    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                    {
                        Message = "CPL Submission Payment completed Successfully and is submitted",
                        Success = true,
                        Payload = null
                    });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
            {
                Message = "CPL Submission paymennt data update failed. Something went wrong.",
                Success = false,
                Payload = null
            });
        }
        /// <summary>
        /// Get Success Payment Data
        /// </summary>
        [HttpPost("GetSuccessPaymentDataForCpl")]
        [Consumes("application/x-www-form-urlencoded")]
        public async Task<ContentResult> GetOnlinePaymentDataForCpl([FromForm] Dictionary<string, string> input)
        {
            string card_type = input.ContainsKey("card_type") == false ? "n/a" : input["card_type"];
            string card_status = input.ContainsKey("status") == false ? "n/a" : input["status"];
            string amount = input.ContainsKey("amount") == false ? "n/a" : input["amount"];
            string currency_type = input.ContainsKey("currency_type") == false ? "n/a" : input["currency_type"];
            string error = input.ContainsKey("error") == false ? "n/a" : input["error"];
            string tran_date = input.ContainsKey("tran_date") == false ? "n/a" : input["tran_date"];
            string tran_id = input.ContainsKey("tran_id") == false ? "n/a" : input["tran_id"];
            string payment_err = input.ContainsKey("error") == false ? "n/a" : input["error"];
            CplOnlinePaymentDetail onlinePaymentDetail = await _context.CplOnlinePaymentDetails.Where(i => i.TransactionId == tran_id).FirstOrDefaultAsync();

            onlinePaymentDetail.CardType = card_type;
            onlinePaymentDetail.Status = card_status;
            onlinePaymentDetail.PaymentTime = DateTime.Parse(tran_date);
            onlinePaymentDetail.PaymentError = payment_err == null ? null : payment_err;

            if (onlinePaymentDetail != null)
            {
                _context.CplOnlinePaymentDetails.Update(onlinePaymentDetail);
                int isSaved = await _context.SaveChangesAsync();
            }

            string name = onlinePaymentDetail?.Name;
            decimal? Regno = onlinePaymentDetail?.RegNo;

            string getSingleStudentEmail = await _context.StuReg1s.Where(x => x.RegNo == Convert.ToInt32(Regno))
                                            .Select(y => y.Email).FirstOrDefaultAsync();


            string amountToWords = ConvertToWords(amount);

            string messageForEmail = $@"<p><h4>Dear <code>{name} (Registration No.: {Regno})</code></h4> <br>  We acknowledge the receipt of a sum of TK.<code>{amount}</code>/- (Taka {amountToWords}) via electronic fund transfer on <code>{tran_date}</code> <br><br>Thanks & Regards,<br>ICAB Exam Division<br><br>Note: In case of any clarification, you can contact @ Account Department of ICAB. PBX: +88 09612612100.<br><br>* This is an auto generated email.</p>";

            if (card_status == "VALID" && getSingleStudentEmail != null)
            {

                _emailService.Send(
                     to: getSingleStudentEmail,
                     subject: "Regarding intimation of fund transfer receipt",
                     html: $@"{messageForEmail}"
                 );
            }

            string redirect_url = onlinePaymentDetail?.RedirectUrl + "/" + card_status + "/" + tran_id + "/" + tran_date;


            string finalOutput = "<html><head><meta name=\"viewport\" content=\"width=device - width, initial - scale=1\"><link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\"></script><style>.paymentpage .backicon1{ cursor: pointer; color: #168DD8; font-size: 1vw; font-weight: bold;} .paymentpage .textfont{ font-weight: bold; font-size: 1vw;} .paymentpage .backBreadCrumb{ padding-bottom: 20px;} .paymentContainer.container-fluid{ width: 98%; padding-bottom: 3%; font-family: Helvetica; padding-top: 5%; margin-left: auto; box-shadow: -2px 2px 10px 2px #dedede; border: 1px solid #cccccc; margin-bottom: 2%; padding-left: 0%; padding-right: 0%;} .backicon{ font-size: 1.5vw; color: #168DD8; opacity: .6;} .backclr{ cursor: pointer; color: #168DD8; font-size: 1vw; } .pointer{ cursor: pointer;} .paymentDetails{ width: 30%; margin: 25px 0; font-size: 1.2em;} .blueColor{ color: #168DD8;} .backlinkPayment{ margin-top: 15px;} .col-6{ width: 20% !important; display: inline-block;} .hellocustomer{ margin-left: 5%; text-align: left; font: normal normal medium 0.8333vw/0.98vw Helvetica; letter-spacing: 0px; color: #030c58;} .mcsheader{ padding-top: 1%; position: fixed; z-index: 999; border-bottom: 4px solid #168dd8; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .mplheader{ padding-top: 1%; position: fixed; z-index: 999999; resize: both; border-bottom: 4px solid #1c57a4; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .img-fluid2{ height: 23px; width: 23px; margin-top: 1px; margin-left: 7px;} .heading2{ margin-right: 2%; color: #030c58; margin-top: 1%; float: right;} .logut{ margin-left: 16%; cursor: pointer;} .custome{ margin-left: -34%;} .cancelButton{ background-color: #333333;} .loginbutton{ background-color: #168dd8;} .threedot{ width: 21px; height: 5px;} button:focus{ outline: none;} .nobuttonalign{ float: right; text-align: center; font-size: 0.825vw;} .loginbutton{ font-size: 0.825vw; text-align: center;} .logoutheadingpopup{ font-size: 1vw; text-align: center; display: inline-block; font-weight: 400; line-height: 1.29; letter-spacing: 0.16px;} .headerstyle .marginleft{ margin-left: 3.5%;} .headerstyle .buttonsSec{ margin: 10px auto;} .headerstyle .buttonsSec .cancelButton{ margin-right: 10px; background-color: #999; text-align: center;} .headerstyle .mat-dialog-content{ margin: 31px -24px; padding: 0 24px; max-height: 65vh; font-size: 110%; overflow: visible;} .headerstyle .mat-dialog-container{ position: relative;} .headerstyle .image{ height: 202px; margin-left: -5%;} .headerstyle .col4background{ background-color: #ebf7ff;} .headerstyle .imagepadding{ padding-top: 44%;} .headerstyle .imagepadding1{ padding-top: 14%;} .headerstyle .marginrow{ margin-top: -1%;} .headerstyle .widhtmenu{ width: 100%;} .headerstyle .borderline{ outline: none; border: none;} .headerstyle .container{ width: 100%; max-width: 100%;} .headerstyle .heading{ color: white; margin-left: -3%;} .headerstyle .usermanelign{ margin-left: 3%; padding-left: 3%;} .headerstyle .blockname{ text-align: left; font: normal normal bold 1.04vw/ 1.3vw Helvetica; letter-spacing: 0px; margin-left: 1.5%; color: #030c58;} .headerstyle .mcsheader{ padding-top: 1%; position: fixed; z-index: 999; border-bottom: 4px solid #168dd8; padding-bottom: 1%; max-width: 100%; width: 100%; background-color: white;} .headerstyle .platform{ text-align: left; font: normal normal normal 1.04vw/1.3vw Helvetica; letter-spacing: 0px; margin-left: 0.4%; color: #030c58;} </style></head><body><div class=\"headerstyle\"><div class=\"mcsheader container-fluid \"><div class=\"row\"><div class=\"offset-7 col-4\"><h5 class=\"heading2\">Hello " + name + " </h5></div></div></div><div class=\"paymentpage\"><div class=\"container-fluid paymentContainer\"><div *ngIf=\"loading\"><app-loader></app-loader></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Tran id</div><div class=\"col-6\">" + tran_id + "</div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Card type</div><div class=\"col-6\">" + card_type + "</div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Status</div><div class=\"col-6\">" + card_status + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Amount</div><div class=\"col-6\">" + amount + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Currency</div><div class=\"col-6\">" + currency_type + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">Payment date</div><div class=\"col-6\">" + tran_date + " </div></div><div class=\"row paymentDetails\"><div class=\"col-6 blueColor\">error</div><div class=\"col-6\">" + error + " </div></div><div class=\"row paymentDetails\"><div class=\"col-10\"><button class=\"mr-4 backclr pointer ml-2\" style=\"border-radius: 10px; padding: 0px 15px;\" (click)=\"back()\"><a href=\"" + redirect_url + "\"><b>Close</b></a></button></div></div></div></div></body></html>";

            return base.Content(finalOutput, "text/html");
        }

        /// <summary>
        /// Get Online Payment Data
        /// </summary>
        [HttpPost("GetOnlinePaymentDataForCpl")]
        public async Task<ActionResult<ResponseDto2>> GetOnlinePaymentDataForCpl([FromBody] InputForOnlinePaymentResponse input)
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

            CplOnlinePaymentDetail onlinePaymentDetail = new();

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

            _context.CplOnlinePaymentDetails.Add(onlinePaymentDetail);
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
                    engOne = Ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
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

                            word = Ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range    
                            word = Tens(Number);
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
        private static String Ones(String Number)
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
        private static String Tens(String Number)
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
                        name = Tens(Number.Substring(0, 1) + "0") + " " + Ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

    }
}