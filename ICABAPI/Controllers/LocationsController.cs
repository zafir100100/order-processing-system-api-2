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
    
    
    public class LocationsControllerModel1
    {
        public int LocId { get; set; }
    }
    [Authorize]
    public class LocationsController : BaseApiController
    {
        private readonly ModelContext _context;

        public LocationsController(ModelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All location list
        /// </summary>
        [HttpGet("GetAllLocation")]
        public async Task<ActionResult<ResponseDto2>> GetAllLocation()
        {
            var locations = await _context.Locations.OrderBy(s => s.LocId).ToListAsync();

            if (locations == null || locations.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No location info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "List of locations",
                Success = true,
                Payload = locations
            });
        }

        /// <summary>
        /// Get location
        /// </summary>
        [HttpPost("GetLocation")]
        public async Task<ActionResult<ResponseDto2>> GetLocation([FromBody] LocationsControllerModel1 input1)
        {
            var location = await _context.Locations.Where(s => s.LocId == input1.LocId).FirstOrDefaultAsync();

            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No location info found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Location info for location id: " + input1.LocId,
                Success = true,
                Payload = location
            });
        }

        /// <summary>
        /// Update Location
        /// </summary>
        [HttpPost("UpdateLocation")]
        public async Task<ActionResult<ResponseDto2>> UpdateLocation([FromBody] Location location)
        {
            if (location.LocId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto2
                {
                    Message = "Location id can not be null or zero",
                    Success = false,
                    Payload = null
                });
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(location.LocId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                    {
                        Message = "No location info found for " + location.LName + " (location id: " + location.LocId + ")",
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
                Message = "Location " + location.LName + " updated successfully",
                Success = true,
                Payload = new { id = location.LocId }
            });
        }

        /// <summary>
        /// Create Location
        /// </summary>
        [HttpPost("Createlocation")]
        public async Task<ActionResult<ResponseDto2>> Createlocation([FromBody] Location location)
        {
            int? currentMax = await _context.Locations.MaxAsync(x => x.LocId);
            if (currentMax == null)
            {
                currentMax = 0;
            }
            location.LocId = (currentMax ?? 0) + 1;
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Location " + location.LName + " created successfully",
                Success = true,
                Payload = new { id = location.LocId }
            });
        }

        /// <summary>
        /// Delete Location
        /// </summary>
        [HttpPost("DeleteLocation")]
        public async Task<ActionResult<ResponseDto2>> DeleteLocation([FromBody] LocationsControllerModel1 input1)
        {
            var location = await _context.Locations.Where(s => s.LocId == input1.LocId).FirstOrDefaultAsync();

            if (location == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto2
                {
                    Message = "No location info found",
                    Success = false,
                    Payload = null
                });
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, new ResponseDto2
            {
                Message = "Location " + location.LName + " deleted successfully",
                Success = true,
                Payload = new { id = location.LocId }
            });
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocId == id);
        }
    }
}
