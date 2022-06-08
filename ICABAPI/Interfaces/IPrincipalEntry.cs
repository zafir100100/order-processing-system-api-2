using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IPrincipalEntry
    {
        Task<IEnumerable<Principal>> GetPrincipleByFirmId(int FId);
    }
}