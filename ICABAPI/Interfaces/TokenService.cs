using System.Threading.Tasks;
using ICABAPI.Entities;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        Task<string> CreateTokenAdmin(ApplicationUser user);

        string CreateTokenDecoder(DecoderUser user);
    }
}