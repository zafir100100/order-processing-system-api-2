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
    //[Authorize]
    public class FileCreateInputs
    {
        public int RegNo { get; set; }
        public string InputDirectory { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileExtension { get; set; }
    }
    public class FileTest : CustomType1ApiController
    {
        private readonly ModelContext _context;

        public FileTest(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get Decoder Status
        /// </summary>
        [HttpPost("TestRoute")]
        public async Task<ActionResult<ResponseDto2>> FileUploadToOnline([FromBody] FileCreateInputs input)
        {
            if (Directory.Exists(input.InputDirectory))
            {
                // Create a sub directory
                if (!Directory.Exists(input.InputDirectory + "/" + "amar"))
                {
                    Directory.CreateDirectory(input.InputDirectory + "/" + "amar");

                    if (Directory.Exists(input.InputDirectory + "/" + "amar"))
                    {
                        await System.IO.File.WriteAllBytesAsync(input.InputDirectory + "/amar/amarfile" + input.FileExtension, input.FileBytes);
                    }
                }

                //if (!Directory.Exists(input.InputDirectory+"/"))
                //{
                //    Directory.CreateDirectory(root);
                //}

                // This path is a directory
                return StatusCode(StatusCodes.Status200OK, new ResponseDto2
                {
                    Message = "Directory exists",
                    Success = true,
                    Payload = new
                    {
                        CurrentDirectory = Directory.GetCurrentDirectory(),
                        PathRoot = Path.GetPathRoot(Environment.SystemDirectory),
                        SubDirectories = Directory.GetDirectories(input.InputDirectory)
                    }
                });
            }
            return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            {
                Message = "Code not working",
                Success = false,
                Payload = new
                {
                    CurrentDirectory = Directory.GetCurrentDirectory(),
                    PathRoot = Path.GetPathRoot(Environment.SystemDirectory)
                }
            });
        }
    }
}