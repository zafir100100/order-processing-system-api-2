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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Controllers
{

    public class AllFirmData
    {
        public AllFirmData()
        {
            firm1VMs = new List<Firm1VM>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Firm1VM> firm1VMs { get; set; }
    }
    public class Firm1VM
    {
        public Firm1VM()
        {
            firm2VMs = new List<Firm2VM>();
            ProPartnerVMs = new List<ProPartnerVM>();
        }
        public int FirmId { get; set; }
        public string FirmName { get; set; }
        public int NumberOfPartners { get; set; }
        public int Partner { get; set; }
        public string Type { get; set; }
        public List<Firm2VM> firm2VMs { get; set; }
        public List<ProPartnerVM> ProPartnerVMs { get; set; }



    }
    public class Firm2VM
    {
        [JsonIgnore]
        // public int LocationId  { get; set; }
        public string LocationName { get; set; }



    }
    public class LocationVM
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
    public class MemberVM
    {
        public int MemId { get; set; }
        public string MemberName { get; set; }
    }
    public class ProPartnerVM
    {
        public int EnrollmentNo { get; set; }

        public int MemNo { get; set; }
        public string MemberName { get; set; }


    }
    public class Reportrequest
    {
        public int FirmId { get; set; } = 0;
        public int? Firm_Type { get; set; }
        public string Firm_Name { get; set; } = "";
        public int All_Firm { get; set; } = 0;

    }

    //[Authorize]
    public class FirmEntryController : BaseApiAdminController
    {
        private readonly IFirmEntry _firmEntry;
        private readonly IMapper _mapper;
        private readonly ModelContext _context;
        public FirmEntryController(IFirmEntry firmEntry, IMapper mapper, ModelContext context)
        {
            _context = context;
            _mapper = mapper;
            _firmEntry = firmEntry;

        }

        /// <summary>
        /// All firm report
        /// </summary>
        [HttpPost("report")]
        public async Task<ActionResult<IEnumerable<FirmMas1>>> AllFirmReport([FromBody] Reportrequest reportrequest)
        {

            if (reportrequest.FirmId != 0)
                return Ok(await GetFirmById(reportrequest));
            if (reportrequest.Firm_Type == 0 || reportrequest.Firm_Type == 1)
                return Ok(await GetFirmByType(reportrequest));
            if (reportrequest.Firm_Name != "")
                return Ok(await GetFirmByName(reportrequest));
            if (reportrequest.All_Firm != 0)
                return Ok(await GetFirmByAllData(reportrequest));

            if (reportrequest.FirmId == 0 && reportrequest.Firm_Name == "" && reportrequest.Firm_Type == 0 && reportrequest.All_Firm == 0)
                return Ok(new { Message = "please select an option" });
            return Ok(new { Message = "no data found" });


        }
        private async Task<IActionResult> GetFirmById(Reportrequest reportrequest)
        {
            var firmId = await _context.FirmMas1s.Where(f => f.FId == reportrequest.FirmId).Include(s => s.FirmMas2s).Include(p => p.ProPartners).ToListAsync();

            var result = firmId.Select(s => new Firm1VM()
            {
                FirmId = s.FId,
                FirmName = s.FName,
                Partner = s.FType,
                Type = s.FType == 0 ? "PartnerShip" : "PropritorShip",
                firm2VMs = s.FirmMas2s.Select(l => new Firm2VM()
                {

                    LocationName = _context.Locations.Where(n => n.LocId == l.LocId).Select(s => s.LName).FirstOrDefault(),


                }).ToList(),
                ProPartnerVMs = s.ProPartners.Select(p => new ProPartnerVM()
                {
                    MemberName = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Name).FirstOrDefault(),
                    EnrollmentNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Enrno).FirstOrDefault(),
                    MemNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.MemId).FirstOrDefault()
                }).ToList()
            }).ToList();

            if (firmId == null)
                return Ok(new { Message = "no data found" });
            return Ok(result);
        }
        private async Task<IActionResult> GetFirmByType(Reportrequest reportrequest)
        {
            var firmId = await _context.FirmMas1s.Where(f => f.FType == reportrequest.Firm_Type).Include(s => s.FirmMas2s).Include(d => d.ProPartners).ToListAsync();
            var result = firmId.Select(s => new Firm1VM()
            {
                FirmId = s.FId,
                FirmName = s.FName,
                Partner = s.FType,
                Type = s.FType == 0 ? "PartnerShip" : "PropritorShip",
                firm2VMs = s.FirmMas2s.Select(l => new Firm2VM()
                {

                    LocationName = _context.Locations.Where(n => n.LocId == l.LocId).Select(s => s.LName).FirstOrDefault(),


                }).ToList(),
                ProPartnerVMs = s.ProPartners.Select(p => new ProPartnerVM()
                {
                    MemberName = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Name).FirstOrDefault(),
                    EnrollmentNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Enrno).FirstOrDefault(),
                    MemNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.MemId).FirstOrDefault()
                }).ToList()
            }).ToList();

            if (firmId == null)
                return Ok(new { Message = "no data found" });
            return Ok(result);
        }
        private async Task<IActionResult> GetFirmByName(Reportrequest reportrequest)
        {

            var firmId = await _context.FirmMas1s.Where(f => f.FName.ToLower().Contains(reportrequest.Firm_Name.ToLower())).Include(s => s.FirmMas2s).Include(p => p.ProPartners).ToListAsync();
            var result = firmId.Select(s => new Firm1VM()
            {
                FirmId = s.FId,
                FirmName = s.FName,
                Partner = s.FType,
                Type = s.FType == 0 ? "PartnerShip" : "PropritorShip",
                firm2VMs = s.FirmMas2s.Select(l => new Firm2VM()
                {

                    LocationName = _context.Locations.Where(n => n.LocId == l.LocId).Select(s => s.LName).FirstOrDefault(),


                }).ToList(),
                ProPartnerVMs = s.ProPartners.Select(p => new ProPartnerVM()
                {
                    MemberName = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Name).FirstOrDefault(),
                    EnrollmentNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Enrno).FirstOrDefault(),
                    MemNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.MemId).FirstOrDefault()
                }).ToList()
            }).ToList();

            if (firmId == null)
                return Ok(new { Message = "no data found" });
            return Ok(result);
        }
        private async Task<IActionResult> GetFirmByAllData(Reportrequest reportrequest)
        {
            var firmId = await _context.FirmMas1s.Include(s => s.FirmMas2s).Include(p => p.ProPartners).ToListAsync();
            var result = firmId.Select(s => new Firm1VM()
            {
                FirmId = s.FId,
                FirmName = s.FName,
                Partner = s.FType,
                Type = s.FType == 0 ? "PartnerShip" : "PropritorShip",
                firm2VMs = s.FirmMas2s.Select(l => new Firm2VM()
                {

                    LocationName = _context.Locations.Where(n => n.LocId == l.LocId).Select(s => s.LName).FirstOrDefault(),


                }).ToList(),
                ProPartnerVMs = s.ProPartners.Select(p => new ProPartnerVM()
                {
                    MemberName = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Name).FirstOrDefault(),
                    EnrollmentNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.Enrno).FirstOrDefault(),
                    MemNo = _context.Members.Where(m => m.MemId == p.MemId).Select(m => m.MemId).FirstOrDefault()
                }).ToList()
            }).ToList();

            if (firmId == null)
                return Ok(new { Message = "no data found" });
            return Ok(result);
        }

        /// <summary>
        /// Get All firms
        /// </summary>
        [HttpGet("allFirms")]
        public async Task<ActionResult<IEnumerable<FirmMas1Dto>>> AllFirms()
        {
            //var firms = await _firmEntry.GetFirms();
            List<FirmMas1> firmMas1s = await _context.FirmMas1s.OrderBy(o => o.FName).ToListAsync();

            //if (firms == null) return NotFound();
            if (firmMas1s == null) return NotFound();
            //return Ok(firms);
            return Ok(firmMas1s);
        }

        /// <summary>
        /// Get All firms by name
        /// </summary>
        [HttpPost("fNamesearch")]
        public async Task<ActionResult<IEnumerable<FirmMas1Dto>>> AllFirmsByName(string fname)
        {

            var firms = await _context.FirmMas1s.Where(n => n.FName.Contains(fname)).Include(s => s.FirmMas2s).Include(d => d.ProPartners).ToListAsync();
            var members = await _context.Members.ToListAsync();
            var locations = await _context.Locations.ToListAsync();
            var proPartnerListMapped = new List<ProPartnerVM>();
            var locationListMapped = new List<Firm2VM>();
            var firm1 = new Firm1VM();
            foreach (var f in firms.ToList())
            {

                firm1.FirmName = f.FName;
                firm1.NumberOfPartners = f.NumPartner;
                firm1.FirmId = f.FId;
                foreach (var p in f.ProPartners.ToList())
                {
                    var memberName = await _context.Members.FirstOrDefaultAsync(m => m.MemId == p.MemId);
                    var proPartner = new ProPartnerVM()
                    {
                        MemberName = memberName.Name,
                        EnrollmentNo = memberName.Enrno
                    };

                    firm1.ProPartnerVMs.Add(proPartner);


                }
                foreach (var l in f.FirmMas2s.ToList())
                {
                    var locationName = await _context.Locations.FirstOrDefaultAsync(loc => loc.LocId == l.LocId);
                    var firmMas2 = new Firm2VM()
                    {
                        // LocationId =locationName.LocId,
                        LocationName = locationName.LName
                    };
                    firm1.firm2VMs.Add(firmMas2);

                }


            }
            if (firms == null) return NotFound();
            return Ok(firm1);
        }
        /// <summary>
        /// All firm names
        /// </summary>
        [HttpPost("firm-names")]
        public async Task<ActionResult<IEnumerable<FirmMas1Dto>>> AllFirmNames()
        {

            var firms = await _context.FirmMas1s.ToListAsync();
            var names = firms.Select(s => new
            {
                firmName = s.FName
            }).ToList();
            if (firms == null) return NotFound();
            return Ok(names);
        }

        /// <summary>
        /// Get All firms by type
        /// </summary>
        [HttpPost("firm-type")]
        public async Task<ActionResult<IEnumerable<FirmMas1Dto>>> AllFirmByType(int ftype)
        {

            var firms = await _context.FirmMas1s.Where(n => n.FType == ftype).Include(s => s.FirmMas2s).Include(d => d.ProPartners).ToListAsync();
            var names = firms.Select(s => new
            {
                firmName = s.FName
            }).ToList();
            if (firms == null) return NotFound();
            return Ok(names);
        }

        /// <summary>
        /// Get single firm 
        /// </summary>
        [HttpPost("single-firm")]
        public async Task<ActionResult<FirmMas1Dto>> GetFirm([FromBody] FirmRequestDto firmRequestDto)
        {
            var firm = await _firmEntry.GetFirm(firmRequestDto.FId);
            if (firm == null) return NotFound("No Data Found");
            return Ok(firm);
        }

        /// <summary>
        /// Get single firm name
        /// </summary>
        [HttpPost("fName")]
        public async Task<ActionResult<FirmMas1Dto>> Firm([FromBody] FirmRequestDto firmRequestDto)
        {
            var firm = await _firmEntry.GetFirm(firmRequestDto.FId);
            var firmNameDropDown = new FirmResponseDto()
            {
                FId = firm.FId,
                FirmName = firm.FName
            };
            if (firm == null) return NotFound("No Data Found");
            return Ok(firmNameDropDown);
        }



        /// <summary>
        /// Firm create
        /// </summary>
        [HttpPost("firmentry")]
        public async Task<IActionResult> CreateFirm([FromBody] FirmMas1Dto firmmas1Request)
        {
            var alreadyExisting = await _context.FirmMas1s.FirstOrDefaultAsync(x => x.FId == firmmas1Request.FId);
            if (alreadyExisting != null)
                return BadRequest(new { status = "error", Message = "FID already exist" });

            var firm = _mapper.Map<FirmMas1Dto, FirmMas1>(firmmas1Request);
            firm.DoDeed = DateTime.Now;
            await _firmEntry.CreateFirmAsync(firm);
            return Ok(firm);
        }

        /// <summary>
        /// Firm Update
        /// </summary>
        [HttpPut("{FId}")]
        public async Task<ActionResult> UpdateFirm(int FId, [FromBody] FirmMas1 firmMas1)
        {
            var firm = await _firmEntry.GetFirm(FId);
            if (firm == null) return BadRequest(new { Message = "firm not found" });
            var updatedFirm = await _firmEntry.UpdateFirmAsync(FId, firmMas1);
            return Ok(updatedFirm);


        }

        /// <summary>
        /// Firm delete
        /// </summary>
        [HttpDelete("{FId}")]
        public async Task<ActionResult> DeleteFirm(int FId)
        {
            var firm = await _firmEntry.GetFirm(FId);
            if (firm == null)
                return BadRequest(new { Message = "no firm found " });
            _context.Remove(firm);
            var deleted = await _context.SaveChangesAsync() > 0;
            return Ok(deleted);


        }

    }
}