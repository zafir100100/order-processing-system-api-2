using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Entities;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IStudentArticleshipCancelationService
    {
        public Task<ResponseDto3> GetListOfArticleshipCanceledstudentAsync();
        public Task<ResponseDto3> GetStudentArticleshipCancelationStatusAsync(InputForGetStudentByRegNo input);
        public Task<ResponseDto3> CreateStudentArticleshipCancelationAsync(StuCancel input);
        public Task<ResponseDto3> UpdateStudentArticleshipCancelationAsync(StuCancel input);
    }
}