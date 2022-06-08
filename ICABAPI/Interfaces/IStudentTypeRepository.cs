using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IStudentTypeRepository
    {
        //GET
         Task<IEnumerable<StudentType>> GetStudentTypesAsync();
         Task<int> GetMaxStudentTypeIdAsync();

         //CREATE
         Task<bool> CreateStudentTypeAsync(StudentType studentType);
    }
}