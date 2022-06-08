using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ModelContext _context;
        public MemberRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMemberAsync(Member member)

        {
            member.MemId = (await _context.Members.MaxAsync(x => x.MemId)) + 1;
            _context.Members.Add(member);
            var RowAffected = await _context.SaveChangesAsync() > 0;
            return RowAffected;
        }

        public async Task<IEnumerable<Member>> GetMemberAsync()
        {
            var data = await _context.Members.ToListAsync();
            return data.OrderBy(e => e.Enrno);
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {

            return await _context.Members.FirstOrDefaultAsync(x => x.MemId == memberId);
            //return await _context.Members.FindAsync(memberId);
        }

        public async Task<IEnumerable<Member>> GetMemberBymemberIdAsync(int memberId)
        {
            //throw new System.NotImplementedException();
            var members = await _context.Members.Where(m => m.MemId == memberId).ToListAsync();
            return members;
        }

        public void Update(Member member)
        {

            _context.Entry(member).State = EntityState.Modified;
        }

        public async Task<bool> UpdateMemberAsync(int id, Member member)
        {
            _context.Members.Update(member);
            var rowAffected = await _context.SaveChangesAsync() > 0;
            return rowAffected;


            //var existingMember = _context.Members.SingleOrDefaultAsync(x=>x.MemId==id);

        }
    }
}