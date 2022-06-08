using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IMemberRepository
    {
        Task<bool> CreateMemberAsync (Member member);
        Task<IEnumerable<Member>> GetMemberAsync();
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<bool> UpdateMemberAsync(int id, Member member);

        Task<IEnumerable<Member>> GetMemberBymemberIdAsync(int memberId);
        
        //void Update (Member member);
        
    }
}