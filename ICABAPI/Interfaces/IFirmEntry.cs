using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IFirmEntry
    {
        Task<bool> CreateFirmAsync(FirmMas1 firmMas1);
        Task<IEnumerable<FirmMas1>> GetFirms();
        Task<FirmMas1> GetFirm(int FId); 
        Task<bool> UpdateFirmAsync(int FId, FirmMas1 firmMas1);    
    }
}