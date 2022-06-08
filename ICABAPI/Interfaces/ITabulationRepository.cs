using System.Collections.Generic;
using System.Threading.Tasks;
using ICABAPI.Controllers;
using ICABAPI.Data;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface ITabulationRepository
    {
        ////GET
        // Task<IEnumerable<StudentType>> GetStudentTypesAsync();
        // Task<int> GetMaxStudentTypeIdAsync();

        // //CREATE
        // Task<bool> CreateStudentTypeAsync(StudentType studentType);

        // GET - Tabulation Sheet
        Task<IEnumerable<TabulationsControllerModel1>> GetTabulationSheet(TabulationsControllerModel7 input);

        Task<TabulationsControllerModel1> GetTabulationSheetForOnePerson(TabulationsControllerModel88 input);

        // GET - Congratulation letter 
        Task<IEnumerable<CLopModel1222>> GetCongratulationLetters(TabulationsControllerModel7 input);
        Task<CLopModel1222> GetSingleCongratulationLetters(TabulationsControllerModel88 input);
        string GetHtml(CLopModel1222 input);
        //Task<TabulationsControllerModel1> GetTabulationSheetForOnePerson(TabulationsControllerModel88 input);
    }
}