using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICABAPI.Controllers
{
    //[Authorize]
    // [ApiController]
    // [Route("api/v1/[controller]")]
    public class StudentArticleShipCancelationController : CustomType1ApiController
    {
        private readonly IStudentArticleshipCancelationService _studentArticleshipCancelationService;

        public StudentArticleShipCancelationController(IStudentArticleshipCancelationService studentArticleshipCancelationService)
        {
            _studentArticleshipCancelationService = studentArticleshipCancelationService;
        }

        /// <summary>
        /// All Cancel Student
        /// </summary>
        [HttpGet("articleship-canceled-student-report")]
        public async Task<ActionResult<ResponseDto3>> GetAllCancelStudent()
        {
            ResponseDto3 responseDto3 = await _studentArticleshipCancelationService.GetListOfArticleshipCanceledstudentAsync();
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Student Info by Regno
        /// </summary>
        [HttpPost("student-articleship-cancelation-status")]
        public async Task<ActionResult<ResponseDto3>> GetStudentInfoByRegNo([FromBody] InputForGetStudentByRegNo input)
        {
            ResponseDto3 responseDto3 = await _studentArticleshipCancelationService.GetStudentArticleshipCancelationStatusAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Insert article student cancelation info
        /// </summary>
        [HttpPost("create-articleship-canceled-student")]
        public async Task<ActionResult<ResponseDto3>> InsertCancelStudent([FromBody] StuCancel input)
        {
            ResponseDto3 responseDto3 = await _studentArticleshipCancelationService.CreateStudentArticleshipCancelationAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Withdraw article student cancelation info
        /// </summary>
        [HttpPatch("update-articleship-canceled-student")] // Probably "WITHDRAWN" API
        public async Task<ActionResult<ResponseDto3>> UpdateCancelStudent([FromBody] StuCancel input)
        {
            ResponseDto3 responseDto3 = await _studentArticleshipCancelationService.UpdateStudentArticleshipCancelationAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }
    }
}