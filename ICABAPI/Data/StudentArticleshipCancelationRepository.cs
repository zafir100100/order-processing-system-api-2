using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ICABAPI.Controllers;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class OutputForGetStudentArticleshipCancelationStatusAsync
    {
        public int? CwFlag { get; set; }
        public DateTime? CancellationDate { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public string CwReason { get; set; }
        public int? Id { get; set; }
        public int? ExamLevel { get; set; }
        public int? MonthId { get; set; }
        public int? SessionYear { get; set; }
        public DateTime? Periodfrom { get; set; }
        public DateTime? Periodto { get; set; }
        public int? RegNo { get; set; }
        public DateTime? RegDate { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Mobile { get; set; }
        public string FirmName { get; set; }
        public string PrincipalName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Imagepath { get; set; }
    }
    public class StudentArticleshipCancelationRepository : IStudentArticleshipCancelationService
    {
        private readonly ModelContext _context;
        public StudentArticleshipCancelationRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto3> GetListOfArticleshipCanceledstudentAsync()
        {
            int rowCount = await _context.StuCancels.Where(i => i.CwFlag == 1).CountAsync();

            if (rowCount == 0)
            {
                return new ResponseDto3
                {
                    Message = "No articleship canceled student found",
                    Success = false,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return new ResponseDto3
            {
                Message = "List of " + rowCount + " articleship canceled students",
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Payload = new
                {
                    RowCount = rowCount,
                    Output = await _context.StuCancels.Where(i => i.CwFlag == 1).OrderBy(i => i.RegNo).ToListAsync()
                }
            };
        }

        public async Task<ResponseDto3> GetStudentArticleshipCancelationStatusAsync(InputForGetStudentByRegNo input)
        {
            if (input.RegNo < 1)
            {
                return new ResponseDto3
                {
                    Message = "RegNo cannot be 0 or null",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Success = false,
                    Payload = null
                };
            }

            var studentInfo = // Ensure `query` is `IQueryable<T>` instead of using `IEnumerable<T>`. But this code has to use `var` because its type-argument is an anonymous-type.
                await (
                from sr1 in _context.StuReg1s.Where(sr1 => sr1.RegNo == input.RegNo)
                from m in _context.Members.Where(m => sr1.PrinEnrNo == m.Enrno).DefaultIfEmpty()
                from firm in _context.FirmMas1s.Where(firm => sr1.FId == firm.FId).DefaultIfEmpty()
                from sc in _context.StuCancels.Where(sc => sr1.RegNo == sc.RegNo).DefaultIfEmpty()
                select new OutputForGetStudentArticleshipCancelationStatusAsync
                {
                    CwFlag = sc.CwFlag,
                    CancellationDate = sc.CancellationDate,
                    WithdrawnDate = sc.WithdrawnDate,
                    CwReason = sc.CwReason,
                    Id = sc.Id,
                    ExamLevel = sc.ExamLevel,
                    MonthId = sc.MonthId,
                    SessionYear = sc.SessionYear,
                    Periodfrom = sc.Periodfrom,
                    Periodto = sc.Periodto,
                    RegNo = sr1.RegNo,
                    RegDate = sr1.RegDate,
                    Name = sr1.Name,
                    FatherName = sr1.FName,
                    MotherName = sr1.MName,
                    PresentAddress = sr1.PreAdd,
                    PermanentAddress = sr1.PerAdd,
                    Mobile = sr1.Cell,
                    FirmName = firm.FName,
                    PrincipalName = m.Name,
                    DateofBirth = sr1.Dob.Value,
                    Imagepath = sr1.Imagepath
                }).FirstOrDefaultAsync().ConfigureAwait(false);

            if (studentInfo == null)
            {
                return new ResponseDto3
                {
                    Message = "No student articleship canceled with registration number: " + input.RegNo,
                    StatusCode = StatusCodes.Status404NotFound,
                    Success = false,
                    Payload = null
                };
            }
            return new ResponseDto3
            {
                Message = "Student articleship cancelation details of student with registration number: " + input.RegNo,
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Payload = new
                {
                    Output = studentInfo
                }
            };
        }

        public async Task<ResponseDto3> CreateStudentArticleshipCancelationAsync(StuCancel input)
        {
            if (input.RegNo < 1)
            {
                return new ResponseDto3
                {
                    Message = "RegNo cannot be 0 or null",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Success = false
                };
            }

            StuCancel stuCancel = await _context.StuCancels.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

            if (stuCancel != null)
            {
                return new ResponseDto3
                {
                    Message = "The student has already articleship cacelation status. You can edit it",
                    StatusCode = StatusCodes.Status409Conflict,
                    Success = false,
                    Payload = new
                    {
                        Output = stuCancel
                    }
                };
            }

            input.CancellationDate ??= DateTime.Now;
            input.CwFlag = 1;

            _context.StuCancels.Add(input);
            int isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0)
            {
                return new ResponseDto3
                {
                    Message = "Articleship of the student has been canceled successfully",
                    StatusCode = StatusCodes.Status200OK,
                    Success = true
                };
            }
            return new ResponseDto3
            {
                Message = "Student articleship cancelation failed. Somethign went wrong. Please try again later ",
                StatusCode = StatusCodes.Status500InternalServerError,
                Success = false
            };
        }

        public async Task<ResponseDto3> UpdateStudentArticleshipCancelationAsync(StuCancel input)
        {
            if (input.RegNo < 1)
            {
                return new ResponseDto3
                {
                    Message = "RegNo cannot be 0 or null",
                    StatusCode = StatusCodes.Status400BadRequest,
                    Success = false
                };
            }

            StuCancel stuCancel = await _context.StuCancels.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

            if (stuCancel == null)
            {
                return new ResponseDto3
                {
                    Message = "The student has no articleship cancelaion status",
                    StatusCode = StatusCodes.Status404NotFound,
                    Success = false
                };
            }

            stuCancel.CwFlag = stuCancel.CwFlag == 1 ? 0 : 1;
            stuCancel.CwReason = input.CwReason;
            stuCancel.CancellationDate = stuCancel.CwFlag == 1 ? input.CancellationDate : stuCancel.CancellationDate;
            stuCancel.WithdrawnDate = stuCancel.CwFlag == 0 ? input.WithdrawnDate : stuCancel.WithdrawnDate;

            _context.StuCancels.Update(stuCancel);
            int isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0)
            {
                return new ResponseDto3
                {
                    Message = "Student articleship cancelation status updated successfully",
                    StatusCode = StatusCodes.Status200OK,
                    Success = true
                };
            }
            return new ResponseDto3
            {
                Message = "Student articleship cancelation status update failed. Somethign went wrong. Please try again later ",
                StatusCode = StatusCodes.Status500InternalServerError,
                Success = false
            };
        }
    }
}