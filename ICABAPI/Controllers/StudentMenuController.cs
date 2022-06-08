using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    public class UpdateStudentMainMenuVisibilityInput
    {
        public int ID { get; set; }
        public int Visibility { get; set; }
    }
    public class GetStudentMainMenuVisibilityInput
    {
        public string Menuurl { get; set; }
    }
    public class StudentMenuController : BaseApiController
    {
        private readonly ModelContext _context;

        public StudentMenuController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("get-all-student-menus")]
        public async Task<ActionResult<ResponseDto2>> GetAllStudentMenu()
        {
            var studentMenus = await _context.StudentMainMenus.OrderBy(s => s.ID).ToListAsync();

            if (studentMenus == null || studentMenus.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student menu found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of " + studentMenus.Count + " Menus",
                Success = true,
                Payload = new
                {
                    Output = studentMenus
                }
            });
        }
        [HttpPatch("update-student-mainmenu-visibility")]
        public async Task<ActionResult<ResponseDto2>> UpdateStudentMainMenuVisibility([FromBody] UpdateStudentMainMenuVisibilityInput input)
        {
            StudentMainMenu studentMainMenu = await _context.StudentMainMenus.Where(s => s.ID == input.ID).FirstOrDefaultAsync();

            if (studentMainMenu == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student sub menu found",
                    Success = false,
                    Payload = null
                });
            }

            studentMainMenu.VISIBILITY = input.Visibility;
            _context.StudentMainMenus.Update(studentMainMenu);
            int isVisibilityUpdated = await _context.SaveChangesAsync();

            if (isVisibilityUpdated == 1)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Mainmenu visibility updated",
                    Success = true,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "Mainmenu visibility update failed",
                Success = false,
                Payload = null
            });
        }
        [HttpPost("get-student-mainmenu-visibility")]
        public async Task<ActionResult<ResponseDto2>> GetStudentMainMenuVisibility([FromBody] GetStudentMainMenuVisibilityInput input)
        {
            StudentMainMenu studentMainMenu = await _context.StudentMainMenus.Where(s => s.MENUURL == input.Menuurl).FirstOrDefaultAsync();

            if (studentMainMenu == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No student menu found",
                    Success = false,
                    Payload = null
                });
            }

            if (studentMainMenu.VISIBILITY == 1)
            {
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "This menu is visible",
                    Success = true,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
            {
                Message = "This menu is invisible",
                Success = false,
                Payload = null
            });
        }
    }
}