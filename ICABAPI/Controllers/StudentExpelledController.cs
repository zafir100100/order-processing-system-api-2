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
    public class StudentExpelledController : CustomType1ApiController
    {
        private readonly IStudentExpelledService _expelledService;

        public StudentExpelledController(IStudentExpelledService expelledService)
        {
            _expelledService = expelledService;
        }

        /// <summary>
        /// All Cancel Student
        /// </summary>
        [HttpGet("expelled-student-report")]
        public async Task<ActionResult<ResponseDto3>> GetListOfExpelledstudentAsync()
        {
            ResponseDto3 responseDto3 = await _expelledService.GetListOfExpelledstudentAsync();
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Student Info by Regno
        /// </summary>
        [HttpPost("student-expulsion-status")]
        public async Task<ActionResult<ResponseDto3>> GetStudentExpulsionStatusAsync([FromBody] InputForGetStudentByRegNo input)
        {
            ResponseDto3 responseDto3 = await _expelledService.GetStudentExpulsionStatusAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Insert article student cancelation info
        /// </summary>
        [HttpPost("create-expelled-student")]
        public async Task<ActionResult<ResponseDto3>> CreateExpelledStudentAsync([FromBody] StudentExpelled input)
        {
            ResponseDto3 responseDto3 = await _expelledService.CreateExpelledStudentAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }

        /// <summary>
        /// Withdraw article student cancelation info
        /// </summary>
        [HttpPatch("update-expelled-student")] // Probably "WITHDRAWN" API
        public async Task<ActionResult<ResponseDto3>> UpdateExpelledStudentAsync([FromBody] StudentExpelled input)
        {
            ResponseDto3 responseDto3 = await _expelledService.UpdateExpelledStudentAsync(input);
            return StatusCode(responseDto3.StatusCode, responseDto3);
        }
    }
}