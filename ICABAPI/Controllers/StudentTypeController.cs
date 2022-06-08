using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    [Authorize]
    // [ApiController]
    // [Route("api/v1/[controller]")]
    public class StudentTypeController : CustomType1ApiController
    {
        private readonly IStudentTypeRepository _studentTypeRepository;
        private readonly ModelContext _context;

        public class TypesToGet
        {
            public int types { get; set; }
        }
        public class StudIdToGet
        {
            public int studid { get; set; }
        }

        public class StudentTypeForInsert
        {
            public string StudType { get; set; }
        }

        public StudentTypeController(IStudentTypeRepository studentTypeRepository, ModelContext context)
        { //ModelContext context
            _studentTypeRepository = studentTypeRepository;
            _context = context;
        }


        /// <summary>
        /// All Type Student List
        /// </summary>
        [HttpGet("allstudentType")] // API: api/v1/StudentType/allstudentType
        public async Task<ActionResult<IEnumerable<StudentType>>> GetStudentType()
        {
            var studentTypes = await _studentTypeRepository.GetStudentTypesAsync();
            if (studentTypes == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student List found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "All Student Type",
                Success = true,
                Payload = studentTypes
            });

            // return await _context.StudentTypes.ToListAsync();
        }


        /// <summary>
        /// Single Student Type
        /// </summary>
        [HttpPost("studentType")]
        public async Task<ActionResult<StudentType>> StudentTypes([FromBody] StudentTypeRequestDto studentTypeRequestDto)
        {
            var result = await _context.StudentTypes.FirstOrDefaultAsync(x => x.StudId == studentTypeRequestDto.StudenTypeId);
            var studentType = new StudentTypeForDropDownResponseDto()
            {
                StudId = result.StudId,
                StudType = result.StudType
            };

            if (studentType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student Type found for: " + studentType.StudId,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student Type for:" + studentType.StudId,
                Success = true,
                Payload = studentType
            });
        }

        /// <summary>
        /// Max Student type id
        /// </summary>
        [HttpGet("maxStudentTypeId")] // API: api/v1/StudentType/maxStudentTypeId
        public async Task<ActionResult> GetStudentTypeMaxId()
        {
            var studentTypesmaxid = await _studentTypeRepository.GetMaxStudentTypeIdAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student Type Maxid",
                Success = true,
                Payload = new { MaxId = studentTypesmaxid }
            });
            //return Ok(studentTypesmaxid);
        }
        // public IActionResult GetMaxid(){
        //     var maxid = _context.StudentTypes.Max(x=> (byte?)x.StudId+1) ?? 1;
        //     return Ok(maxid);
        // }

        /// <summary>
        /// Insert Student type
        /// </summary>
        [HttpPost("insertTypes")] // API: api/v1/StudentType/insertTypes
        public IActionResult InsertStudentTypes([FromBody] StudentTypeForInsert typeins)
        {

            StudentType types = new StudentType();
            // var isFound = _context.StudentTypes.SingleOrDefault(x => x.StudId == types.StudId);

            // if (isFound == null)
            // {
            var maxId = _context.StudentTypes.Max(x => (byte?)x.StudId + 1) ?? 1;
            types.StudId = (byte?)maxId;

            types.StudType = typeins.StudType;

            _context.StudentTypes.Add(types);
            var result = _context.SaveChanges() > 0;
            //var save = //await _studentTypeRepository.CreateStudentTypeAsync(types);

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student Type Inserted",
                Success = true,
                Payload = new { StudentTypeId = types.StudId }
            });
            //}

            // return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            // {
            //     Message = "Student Type Exist",
            //     Success = false,
            //     Payload = new { StudentTypeId = types.StudId }
            // });

        }

        /// <summary>
        /// Update Student type
        /// </summary>
        [HttpPost("updateTypes")] // API: api/v1/StudentType/updateTypes
        public IActionResult UpdateStudentTypes([FromBody] StudentType types)
        {
            var account = _context.StudentTypes.SingleOrDefault(x => x.StudId == types.StudId);

            if (account == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student Type Found",
                    Success = false,
                    Payload = new { StudentTypeId = types.StudId }
                });
            }
            else
            {
                account.StudType = types.StudType;

                _context.StudentTypes.Update(account);
                var result = _context.SaveChanges() > 0;
                //var save = //await _studentTypeRepository.CreateStudentTypeAsync(types);
                //return Ok(new { StatusCode = 200, status = result, responseText = "data updated" });
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Student Type Updated",
                    Success = true,
                    Payload = new { StudentTypeId = types.StudId }
                });
            }

        }

        /// <summary>
        /// Delete Student type
        /// </summary>
        [HttpPost("deleteTypes")] // API: api/v1/StudentType/deleteTypes?studid
        public IActionResult DeleteStudentTypes(StudIdToGet toGet)
        {

            var findType = _context.StudentTypes.SingleOrDefault(x => x.StudId == toGet.studid);

            if (findType == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student Type Found",
                    Success = false,
                    Payload = new { StudentTypeId = toGet.studid }
                });
            }
            else
            {
                _context.Remove(findType);
                var result = _context.SaveChanges() > 0;

                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Student Type Deleted",
                    Success = true,
                    Payload = new { StudentTypeId = toGet.studid }
                });
            }

        }

        /// <summary>
        /// Student type Report
        /// </summary>
        [HttpPost("getTypesReport")] // API: api/v1/StudentType/getTypesReport?types
        public IActionResult StudentTypesReport(TypesToGet toGet)
        {

            var report = (from sr in _context.StuReg1s
                          join st in _context.StudentTypes on sr.StudType equals (byte)st.StudId
                          where (sr.StudType == toGet.types)
                          orderby sr.RegNo
                          select new { sr.RegNo, sr.Name, st.StudType }).ToList();


            var TypeName = _context.StudentTypes.Where(x => x.StudId == toGet.types).FirstOrDefault();

            if (report.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No Student Type Found for Type: " + toGet.types,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Student Type List for Type: " + TypeName.StudType,
                Success = true,
                Payload = report
            });
        }


    }
}
