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
    public class InputForGetStudentByRegNo
    {
        public int RegNo { get; set; }
    }
    public class StudentExpelledRepository : IStudentExpelledService
    {
        private readonly ModelContext _context;
        public StudentExpelledRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto3> GetListOfExpelledstudentAsync()
        {
            List<StudentExpelled> expelledStudents = await _context.StudentExpelleds.Where(i => i.Status.ToLower() == "active").OrderBy(i => i.RegNo).ToListAsync();

            if (expelledStudents.Count == 0 || expelledStudents == null)
            {
                return new ResponseDto3
                {
                    Message = "No expelled student found",
                    Success = false,
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            return new ResponseDto3
            {
                Message = "List of " + expelledStudents.Count + " expelled students",
                Success = true,
                StatusCode = StatusCodes.Status200OK,
                Payload = new
                {
                    Output = expelledStudents,
                    RowCount = expelledStudents.Count
                }
            };
        }

        public async Task<ResponseDto3> GetStudentExpulsionStatusAsync(InputForGetStudentByRegNo input)
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

            var studentInfo = await
            (from sr in _context.StuReg1s.Select(b => new { b.RegDate, b.Name, b.FName, b.MName, b.PreAdd, b.PerAdd, b.Cell, b.Imagepath, b.PrinEnrNo, b.RegNo, b.FId, b.Dob })
             from m in _context.Set<Member>().Where(m => sr.PrinEnrNo == m.Enrno).DefaultIfEmpty().Select(b => new { b.Enrno, b.Name })
             from src in _context.Set<StudentExpelled>().Where(src => sr.RegNo == src.RegNo).DefaultIfEmpty()
             from firm in _context.Set<FirmMas1>().Where(firm => sr.FId == firm.FId).DefaultIfEmpty().Select(b => new { b.FId, b.FName })
             where (sr.RegNo == input.RegNo)
             select new
             {
                 RegNo = sr.RegNo,
                 RegDate = sr.RegDate,
                 Name = sr.Name,
                 FatherName = sr.FName,
                 MotherName = sr.MName,
                 PresentAddress = sr.PreAdd,
                 PermanentAddress = sr.PerAdd,
                 Mobile = sr.Cell,
                 FirmName = firm.FName,
                 PrincipalName = m.Name,
                 DateofBirth = sr.Dob,
                 Imagepath = sr.Imagepath,
                 Status = src.Status,
                 SessionTo = src.SessionTo,
                 YearTo = src.YearTo,
                 SessionFrom = src.SessionFrom,
                 YearFrom = src.YearFrom,
                 Entryuser = src.Entryuser,
                 ExamLevel = src.ExamLevel,
                 Reason = src.Reason,
                 ExpulsionDate = src.ExpulsionDate,
                 WithdrawnDate = src.WithdrawnDate
             }).FirstOrDefaultAsync();

            if (studentInfo == null)
            {
                return new ResponseDto3
                {
                    Message = "No student is expelled with registration number: " + input.RegNo,
                    StatusCode = StatusCodes.Status404NotFound,
                    Success = false,
                    Payload = null
                };
            }
            return new ResponseDto3
            {
                Message = "Expelled details of student with registration number: " + input.RegNo,
                StatusCode = StatusCodes.Status200OK,
                Success = true,
                Payload = new
                {
                    Output = studentInfo
                }
            };
        }

        public async Task<ResponseDto3> CreateExpelledStudentAsync(StudentExpelled input)
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

            StudentExpelled studentExpelled = await _context.StudentExpelleds.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

            if (studentExpelled != null)
            {
                return new ResponseDto3
                {
                    Message = "The student has already expulsion status. You can edit it",
                    StatusCode = StatusCodes.Status409Conflict,
                    Success = false,
                    Payload = new
                    {
                        Output = studentExpelled
                    }
                };
            }

            input.ExpulsionDate ??= DateTime.Now;
            input.Status = "Active";

            _context.StudentExpelleds.Add(input);
            int isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0)
            {
                return new ResponseDto3
                {
                    Message = "The student is expelled successfully",
                    StatusCode = StatusCodes.Status200OK,
                    Success = true
                };
            }
            return new ResponseDto3
            {
                Message = "Student expulsion failed. Somethign went wrong. Please try again later ",
                StatusCode = StatusCodes.Status500InternalServerError,
                Success = false
            };
        }

        public async Task<ResponseDto3> UpdateExpelledStudentAsync(StudentExpelled input)
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

            StudentExpelled studentExpelled = await _context.StudentExpelleds.Where(i => i.RegNo == input.RegNo).FirstOrDefaultAsync();

            if (studentExpelled == null)
            {
                return new ResponseDto3
                {
                    Message = "The student has no expelled status",
                    StatusCode = StatusCodes.Status404NotFound,
                    Success = false
                };
            }

            studentExpelled.Status = input.Status == "Active" ? "Withdrawn" : "Active";
            studentExpelled.Reason = input.Reason;
            studentExpelled.ExpulsionDate = input.Status == "Active" ? input.ExpulsionDate : studentExpelled.ExpulsionDate;
            studentExpelled.WithdrawnDate = input.Status == "Withdrawn" ? input.WithdrawnDate : studentExpelled.WithdrawnDate;
            _context.StudentExpelleds.Update(studentExpelled);
            int isSaved = await _context.SaveChangesAsync();

            if (isSaved > 0)
            {
                return new ResponseDto3
                {
                    Message = "Expelled status updated successfully",
                    StatusCode = StatusCodes.Status200OK,
                    Success = true
                };
            }
            return new ResponseDto3
            {
                Message = "Student expulsion status update failed. Somethign went wrong. Please try again later ",
                StatusCode = StatusCodes.Status500InternalServerError,
                Success = false
            };
        }
    }
}