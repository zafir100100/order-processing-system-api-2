using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class FirmRepository : IFirmEntry
    {
        private readonly ModelContext _context;
        public FirmRepository(ModelContext context)
        {
            _context = context;

        }
        public async Task<bool> CreateFirmAsync(FirmMas1 firmMas1)
        {
           
            await _context.FirmMas1s.AddAsync(firmMas1);
            var createdRowCount =await _context.SaveChangesAsync();
            return createdRowCount >0;

        }

        public async Task<FirmMas1> GetFirm(int FId)
        {
            var firm = await _context.FirmMas1s.Include(x =>x.FirmMas2s).Include(p =>p.ProPartners).SingleOrDefaultAsync(s =>s.FId==FId);
            return firm;
        }

        public async Task<IEnumerable<FirmMas1>> GetFirms()
        {
            return await _context.FirmMas1s.Include(x =>x.FirmMas2s) .Include(s =>s.ProPartners).ToListAsync();
            
        }

        public async Task<bool> UpdateFirmAsync(int FId, FirmMas1 firmMas1)
        {
            
            var selectedFirm = await GetFirm(FId);

            if(selectedFirm.FirmMas2s.Any())
            {
                _context.FirmMas2s.RemoveRange(selectedFirm.FirmMas2s);

            }
            if(selectedFirm.ProPartners.Any())
            {
                _context.ProPartners.RemoveRange(selectedFirm.ProPartners);
            }
            foreach( var f in firmMas1.FirmMas2s)
            {
                selectedFirm.FirmMas2s.Add( new FirmMas2()
                {
                    BrType = f.BrType,LocId=f.LocId,FId=f.FId
                });
            }
            foreach(var p in firmMas1.ProPartners)
            {
                selectedFirm.ProPartners.Add( new ProPartner()
                {
                    FId =p.FId,MemId=p.MemId
                });
            }
            selectedFirm.FName =firmMas1.FName;
            selectedFirm.FType=firmMas1.FType;
            selectedFirm.NumPartner=firmMas1.NumPartner;
            selectedFirm.DoDeed=firmMas1.DoDeed;
            selectedFirm.Entryuser=firmMas1.Entryuser;
            selectedFirm.FId=firmMas1.FId;
            selectedFirm.FIRMREGNO=firmMas1.FIRMREGNO;
            var rowAffected = await _context.SaveChangesAsync() > 0;
           
            return rowAffected;
            
        }
    }
}