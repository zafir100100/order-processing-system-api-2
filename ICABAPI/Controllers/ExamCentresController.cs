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
    public class ExamCentresControllerModel1
    {
        public int CenId { get; set; }
    }

    public class InputForExamCenterDropDown2
    {
        public string Name { get; set; }
    }

    public class VenueBuildingModel
    {
        public int ID { get; set; }
        public int CenId { get; set; }
        public string AddressOld { get; set; }
        public string BuildingsOld { get; set; }
        public string AddressNew { get; set; }
        public string BuildingsNew { get; set; }
    }

    public class VenueBuildingModel2
    {
        public int ID { get; set; }
        public int CenId { get; set; }
        public string Address { get; set; }

    }

    public class VenueWithBuildings
    {
        public string Venue { get; set; }
        public string[] ArrayOfBuildings { get; set; }
    }


    //[Authorize]

    public class ExamCentresController : BaseApiController
    {
        private readonly ModelContext _context;

        public ExamCentresController(ModelContext context)
        {
            _context = context;
        }

        //[HttpGet("GetAllExamCentersDropDown")]
        //public async Task<ActionResult<ResponseDto2>> GetAllExamCentersDropDown1()
        //{
        //    List<ExamCentre> examCentres = await _context.ExamCentres.OrderBy(s => s.CenId).ToListAsync();
        //    if (examCentres == null || examCentres.Count == 0)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "No exam center info found",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    //foreach (var item in examCentres)
        //    //{
        //    //    item.Name = item.Name.ToUpper();
        //    //}

        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "List of exam centers",
        //        Success = true,
        //        Payload = examCentres//.Select(i => i.Name).Distinct().ToList()
        //    });
        //}


        //[HttpPost("GetAllExamCentersDropDown2")]
        //public async Task<ActionResult<ResponseDto2>> GetAllExamCentersDropDown2([FromBody] InputForExamCenterDropDown2 input)
        //{
        //    var examCentres = await _context.ExamCentres.Where(o => o.Name.ToLower() == input.Name.ToLower()).OrderBy(s => s.Address).ToListAsync();
        //    if (examCentres == null || examCentres.Count == 0)
        //    {
        //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
        //        {
        //            Message = "No exam center info found",
        //            Success = false,
        //            Payload = null
        //        });
        //    }

        //    return StatusCode(StatusCodes.Status200OK, new ResponseDto2
        //    {
        //        Message = "List of exam centers",
        //        Success = true,
        //        Payload = examCentres
        //    });
        //}

        /// <summary>
        /// Get all exam centers
        /// </summary>
        [HttpGet("GetAllExamCenters")]
        public async Task<ActionResult<ResponseDto2>> GetAllExamCenters()
        {
            var examCentres = await _context.ExamCentres.OrderBy(s => s.CenId).ToListAsync();
            if (examCentres == null || examCentres.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of exam centers",
                Success = true,
                Payload = examCentres
            });
        }

        /// <summary>
        /// Get buildings info by exam center And Venue
        /// </summary>
        [HttpPost("GetBuildingsByExamCenterAndVenue")]
        public async Task<ActionResult<ResponseDto2>> GetBuildingsByExamCenter([FromBody] VenueBuildingModel2 input1)
        {
            if (input1.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            else if (input1.Address == null || input1.Address == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Venue name can not be null",
                    Success = false,
                    Payload = null
                });
            }

            var examCentre = await _context.VenueBuildings.Where(x => x.CenId == input1.CenId && x.Address == input1.Address.ToUpper()).FirstOrDefaultAsync();

            if (examCentre == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center found with id: " + input1.CenId,
                    Success = false,
                    Payload = null
                });
            }

            var examCentreBuildings = examCentre.Buildings;
            if (examCentreBuildings == null || examCentreBuildings.Equals(""))
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No building was found in exam center:  " + examCentre.Buildings,
                    Success = false,
                    Payload = null
                });
            }

            string[] separatorPattern = new string[] { "|" };
            string[] buildingArray = examCentreBuildings.Split(separatorPattern, StringSplitOptions.RemoveEmptyEntries);

            if (buildingArray == null || buildingArray.Length == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No building was found in the building list for exam venue:  " + examCentre.Address,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of buildings for exam venue:  " + examCentre.Address,
                Success = true,
                Payload = buildingArray
            });
        }


        /// <summary>
        /// Get venue info by exam center 
        /// </summary>
        [HttpPost("GetVenueByExamCenter")]
        public async Task<ActionResult<ResponseDto2>> GetVenueByExamCenter([FromBody] ExamCentresControllerModel1 input1)
        {
            if (input1.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<VenueBuilding> examvenue = await _context.VenueBuildings.Where(x => x.CenId == input1.CenId).ToListAsync();

            if (examvenue.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam venue found with id: " + input1.CenId,
                    Success = false,
                    Payload = null
                });
            }

            List<VenueBuildingModel2> vb = new List<VenueBuildingModel2>();

            foreach(var item in examvenue)
            {
                VenueBuildingModel2 v = new VenueBuildingModel2();

                v.CenId = item.CenId;
                v.Address = item.Address;

                vb.Add(v);
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of Venue ",
                Success = true,
                Payload = vb
            });
        }

        /// <summary>
        /// Venue Building List in One
        /// </summary>
        [HttpPost("GetVenueListWithBuildingByExamCenter")]
        public async Task<ActionResult<ResponseDto2>> GetVenueListWithBuildingByExamCenter([FromBody] ExamCentresControllerModel1 input1)
        {
            if (input1.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            List<VenueBuilding> examvenue = await _context.VenueBuildings.Where(x => x.CenId == input1.CenId).ToListAsync();

            if (examvenue.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam venue found with id: " + input1.CenId,
                    Success = false,
                    Payload = null
                });
            }

            List<VenueWithBuildings> vbs = new List<VenueWithBuildings>();

            foreach (var item in examvenue)
            {
                VenueWithBuildings v2 = new VenueWithBuildings();

                var singleVenue = await _context.VenueBuildings.Where(x => x.CenId == item.CenId && x.Address == item.Address.ToUpper()).FirstOrDefaultAsync() ==  null ? null : await _context.VenueBuildings.Where(x => x.CenId == item.CenId && x.Address == item.Address.ToUpper()).FirstOrDefaultAsync();
                var examCentreBuildings = singleVenue.Buildings;
                
                string[] separatorPattern = new string[] { "|" };
                string[] buildingArray = examCentreBuildings.Split(separatorPattern, StringSplitOptions.RemoveEmptyEntries);

                v2.Venue = item.Address;
                v2.ArrayOfBuildings = buildingArray;

                vbs.Add(v2);

            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of Venue with buildings",
                Success = true,
                Payload = vbs
            });
        }


        /// <summary>
        /// Get exam center by center id
        /// </summary>
        [HttpPost("GetExamCenterByCenterId")]
        public async Task<ActionResult<ResponseDto2>> GetExamCenterByCenterId([FromBody] ExamCentresControllerModel1 input1)
        {
            if (input1.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            var examCentre = await _context.ExamCentres.Where(j => j.CenId == input1.CenId).FirstOrDefaultAsync();

            if (examCentre == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No exam center found with id: " + input1.CenId,
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam center found with id: " + input1.CenId,
                Success = true,
                Payload = examCentre
            });
        }

        /// <summary>
        /// Get exam center by center id
        /// </summary>
        [HttpGet("GetMaxExamCenterId")]
        public async Task<ActionResult<ResponseDto2>> GetMaxExamCenterId()
        {
            int? maxCenId = await _context.ExamCentres.MaxAsync(i => i.CenId);
            int CenId = (maxCenId == null ? 0 : maxCenId ?? 0) + 1;

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Max Exam center id: ",
                Success = true,
                Payload = new { CenId }
            });
        }




        /// <summary>
        /// Create exam center
        /// </summary>
        [HttpPost("CreateExamCenter")]
        public async Task<ActionResult<ResponseDto2>> CreateExamCenter([FromBody] ExamCentre examCentre)
        {

            ExamCentre check = await _context.ExamCentres.Where(x => x.Name == examCentre.Name.ToUpper()).FirstOrDefaultAsync();

            if(check != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Already Have one",
                    Success = false,
                    Payload = null
                });
            }


            examCentre.CenId = await _context.ExamCentres.AnyAsync() == false ? 1 : await _context.ExamCentres.MaxAsync(i => i.CenId) + 1;
            examCentre.Name = examCentre.Name.ToUpper();
            examCentre.Address = null;
            examCentre.Buildings = null;
            _context.ExamCentres.Add(examCentre);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam center " + examCentre.Name + " with id: " + examCentre.CenId + " created successfully",
                Success = true,
                Payload = new { id = examCentre.CenId }
            });
        }

        [HttpPost("UpdateExamCenter")]
        public async Task<ActionResult<ResponseDto2>> UpdateExamCenter([FromBody] ExamCentre examCentre)
        {
            if (examCentre.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            ExamCentre check = await _context.ExamCentres.Where(x => x.CenId == examCentre.CenId).FirstOrDefaultAsync();

            if (check == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No Data",
                    Success = false,
                    Payload = null
                });
            }

            check.Name = examCentre.Name.ToUpper();
            check.Address = null;
            check.Buildings = null;

            _context.ExamCentres.Update(check);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Exam center " + examCentre.Name + " with id: " + examCentre.CenId + " update successfully",
                Success = true,
                Payload = new { id = examCentre.CenId }
            });
        }

        [HttpPost("DeleteExamCenter")]
        public async Task<ActionResult<ResponseDto2>> DeleteExamCenter([FromBody] ExamCentresControllerModel1 examCentre)
        {
            if (examCentre.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            ExamCentre check = await _context.ExamCentres.Where(x => x.CenId == examCentre.CenId).FirstOrDefaultAsync();

            if (check == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No Data",
                    Success = false,
                    Payload = null
                });
            }

            _context.ExamCentres.Remove(check);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Delete successfully",
                Success = true,
                Payload = new { id = examCentre.CenId }
            });
        }

        /// <summary>
        /// Create VenueBuilding
        /// </summary>
        [HttpPost("CreateVenueBuilding")]
        public async Task<ActionResult<ResponseDto2>> CreateExamCenter([FromBody] VenueBuilding venueBuilding)
        {
            if (venueBuilding.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            VenueBuilding check = await _context.VenueBuildings.Where(x => x.Address == venueBuilding.Address.ToUpper()).FirstOrDefaultAsync();

            if (check != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Already Have one",
                    Success = false,
                    Payload = null
                });
            }

            venueBuilding.Address = venueBuilding.Address.ToUpper();

            _context.VenueBuildings.Add(venueBuilding);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Venue " + venueBuilding.Address + " with Buildings: " + venueBuilding.Buildings + " created successfully",
                Success = true,
                Payload = new { id = venueBuilding.CenId }
            });
        }

        /// <summary>
        /// Update Venue Building
        /// </summary>
        [HttpPost("UpdateVenueBuilding")]
        public async Task<ActionResult<ResponseDto2>> UpdateVenueBuilding([FromBody] VenueBuildingModel venueBuilding)
        {
            if (venueBuilding.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }
            else if (venueBuilding.AddressOld == null || venueBuilding.AddressOld == "" || venueBuilding.AddressNew == null || venueBuilding.AddressNew == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Venue name can not be null",
                    Success = false,
                    Payload = null
                });
            }
            else if (venueBuilding.BuildingsOld == null || venueBuilding.BuildingsOld == "" || venueBuilding.BuildingsNew == null || venueBuilding.BuildingsNew == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Buildings can not be null",
                    Success = false,
                    Payload = null
                });
            }


            VenueBuilding check = await _context.VenueBuildings.Where(x => x.Address == venueBuilding.AddressOld.ToUpper() && x.CenId == venueBuilding.CenId).FirstOrDefaultAsync();

            if (check == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No data found",
                    Success = false,
                    Payload = null
                });
            }

            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.VenueBuildings.Remove(check);
                await _context.SaveChangesAsync();


                VenueBuilding ven = new();

                ven.CenId = venueBuilding.CenId;
                ven.Address = venueBuilding.AddressNew.ToUpper();
                ven.Buildings = venueBuilding.BuildingsNew;

                _context.VenueBuildings.Add(ven);
                await _context.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto2
                {
                    Message = "Update failed. Something went wrong, Please try again later.",
                    Success = false,
                    Payload = null
                });
            }

            //_context.Entry(venueBuilding).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ExamCentreExists(venueBuilding.CenId))
            //    {
            //        return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
            //        {
            //            Message = "Exam center can not be found with id: " + venueBuilding.CenId,
            //            Success = false,
            //            Payload = null
            //        });
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Venue " + venueBuilding.AddressOld + " with Buildings: " + venueBuilding.BuildingsOld + " updated successfully",
                Success = true,
                Payload = new { id = venueBuilding.CenId }
            });
        }

        /// <summary>
        /// Delete VenueBuilding
        /// </summary>
        [HttpPost("DeleteVenueBuilding")]
        public async Task<ActionResult<ResponseDto2>> DeleteVenueBuilding([FromBody] VenueBuildingModel2 input1)
        {
            if (input1.CenId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Exam center id can not be null",
                    Success = false,
                    Payload = null
                });
            }

            else if (input1.Address == null || input1.Address == "")
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Venue name can not be null",
                    Success = false,
                    Payload = null
                });
            }

            VenueBuilding check = await _context.VenueBuildings.Where(x => x.Address == input1.Address.ToUpper() && x.CenId == input1.CenId).FirstOrDefaultAsync();

            if (check == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "No data found",
                    Success = false,
                    Payload = null
                });
            }

            _context.VenueBuildings.Remove(check);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Venue " + input1.Address + " deleted successfully",
                Success = true,
                Payload = new { id = input1.CenId }
            });
        }

        private bool ExamCentreExists(int id)
        {
            return _context.ExamCentres.Any(e => e.CenId == id);
        }
    }
}
