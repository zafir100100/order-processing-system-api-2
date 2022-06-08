using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.DTOs;
using ICABAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{
    public class SubjectsControllerModel1
    {
        public int SubId { get; set; }
    }

    public class SubjectsControllerModel2
    {
        public Subject Root { get; set; }
        public List<Subject> Children { get; set; }
    }

    [Authorize]

    public class SubjectsController : BaseApiController
    {
        private readonly ModelContext _context;

        public SubjectsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Subject List
        /// </summary>
        [HttpGet("GetAllSubject")]
        public async Task<ActionResult<ResponseDto2>> GetAllSubject()
        {
            var subjectList = await _context.Subjects.OrderBy(s => s.SubId).ToListAsync();

            if (subjectList == null || subjectList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of subjects",
                Success = true,
                Payload = subjectList
            });
        }

        /// <summary>
        /// Get All Subject List (Tree Format)
        /// </summary>
        [HttpGet("GetAllSubject/tree")]
        public async Task<ActionResult<ResponseDto2>> GetSubjectsTree()
        {
            var roots = await _context.Subjects.Where(x => x.Parent == 0 && (x.SubId == 61 || x.SubId == 62 || x.SubId == 63)).OrderBy(s => s.SubId).ToListAsync();

            if (roots == null || roots.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No parent subject info found",
                    Success = false,
                    Payload = null
                });
            }

            List<SubjectsControllerModel2> output = new();

            foreach (var root in roots)
            {
                SubjectsControllerModel2 tempoutput = new();
                tempoutput.Root = root;
                List<Subject> children = await _context.Subjects.Where(x => x.Parent == root.SubId).OrderBy(s => s.SubId).ToListAsync();
                if (children == null)
                {
                    tempoutput.Children = null;
                }
                else
                {
                    tempoutput.Children = children;
                }
                output.Add(tempoutput);
            }

            if (output == null || output.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of subjects",
                Success = true,
                Payload = output
            });
        }

        /// <summary>
        /// Get All Examlevel List
        /// </summary>
        [HttpGet("GetAllExamLevel")]
        public async Task<ActionResult<ResponseDto2>> GetExamLevels()
        {
            int[] examLevelSubjectIds = { 61, 62, 63 };
            var examLevelSubjectList = await _context.Subjects.Where(x => examLevelSubjectIds.Contains(x.SubId)).OrderBy(s => s.SubId).ToListAsync();

            if (examLevelSubjectList == null || examLevelSubjectList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam level found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam levels",
                Success = true,
                Payload = examLevelSubjectList
            });
        }

        /// <summary>
        /// Get Subject List
        /// </summary>
        [HttpPost("GetSubject")]
        public async Task<ActionResult<ResponseDto2>> GetSubject([FromBody] SubjectsControllerModel1 input1)
        {
            var subject = await _context.Subjects.Where(g => g.SubId == input1.SubId).FirstOrDefaultAsync();

            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found for subject id: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Subject info for subject id: " + input1.SubId,
                Success = true,
                Payload = subject
            });
        }

        /// <summary>
        /// Update Subject
        /// </summary>
        [HttpPost("UpdateSubject")]
        public async Task<ActionResult<ResponseDto2>> UpdateSubject([FromBody] Subject subject)
        {
            var subjectOld = await _context.Subjects.Where(g => g.SubId == subject.SubId).FirstOrDefaultAsync();

            if (subjectOld == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found for subject id: " + subject.SubId,
                    Success = false,
                    Payload = null
                });
            }

            //string newSubjectName = subject.SubName;

            //subject = oldSubject;

            //subject.SubName = newSubjectName;

            _context.ChangeTracker.Clear();

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(subject.SubId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No subject found for subject id: " + subject.SubId,
                        Success = false,
                        Payload = null
                    });
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Subject info updated successfully for subject id: " + subject.SubId,
                Success = true,
                Payload = new { id = subject.SubId }
            });
        }

        /// <summary>
        /// Create Subject
        /// </summary>
        [HttpPost("CreateSubject")]
        public async Task<ActionResult<ResponseDto2>> CreateSubject([FromBody] Subject subject)
        {
            string newSubjectCode = subject.SubId.ToString();
            if (newSubjectCode.Length == 1)
            {
                newSubjectCode = "000" + newSubjectCode;
            }
            else if (newSubjectCode.Length == 2)
            {
                newSubjectCode = "00" + newSubjectCode;
            }
            else if (newSubjectCode.Length == 3)
            {
                newSubjectCode = "0" + newSubjectCode;
            }
            subject.SubCode = newSubjectCode;
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Subject info created successfully for subject id: " + subject.SubId,
                Success = true,
                Payload = new { id = subject.SubId }
            });
        }

        /// <summary>
        /// Delete Subject
        /// </summary>
        [HttpPost("DeleteSubject")]
        public async Task<ActionResult<ResponseDto2>> DeleteSubject([FromBody] SubjectsControllerModel1 input1)
        {
            var subject = await _context.Subjects.Where(g => g.SubId == input1.SubId).FirstOrDefaultAsync();
            if (subject == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found for subject id: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }

            if (SubjectExistsInOtherTables(input1.SubId) == true)
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto2
                {
                    Message = "Subject " + subject.SubName + " already exists in other for subject id: " + subject.SubId,
                    Success = false,
                    Payload = null
                });
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Subject info deleted successfully for subject id: " + subject.SubId,
                Success = true,
                Payload = new { id = subject.SubId }
            });
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.SubId == id);
        }

        private bool SubjectExistsInOtherTables(int? id)
        {
            if (_context.ExemptedSubs.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.RegSubjects.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.BarcodeAllots.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.BarcodeAllotExpelledArchives.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.BarcodeEdits.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.ConversionCourseMarks.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.ExamTimeSches.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.ExamTimeSchAdmits.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.ExamTimeSchCurrs.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.MarksAllots.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.OddsessionMouExmpSubs.Any(e => e.SubId == id) == true)
            {
                return true;
            }
            else if (_context.PassedByExemptions.Any(e => e.ExmptSubid == id) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get Subjects By Parent
        /// </summary>
        [HttpPost("GetSubjectsByParent")]
        public async Task<ActionResult<ResponseDto2>> GetSubjectsByParent([FromBody] SubjectsControllerModel1 input1)
        {
            List<Subject> examLevelSubjectList = await _context.Subjects.Where(x => x.Parent == input1.SubId).OrderBy(l => l.SubId).ToListAsync();

            if (examLevelSubjectList == null || examLevelSubjectList.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No subject found for exam level: " + input1.SubId,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of subjects for exam level: " + input1.SubId,
                Success = true,
                Payload = examLevelSubjectList
            });
        }
    }
}
