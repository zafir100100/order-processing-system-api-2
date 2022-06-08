using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class PrincipalRepository : IPrincipalEntry
    {
        private readonly ModelContext _context;
        public PrincipalRepository(ModelContext context)
        {
             _context = context;
        }

        public async Task<IEnumerable<Principal>> GetPrincipleByFirmId(int FId)
        {

            return await _context.Principals.Where(x =>x.FId==FId).ToListAsync();
            
        }
    }
}