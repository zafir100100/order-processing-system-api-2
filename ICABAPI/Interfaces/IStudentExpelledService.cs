using System.Threading.Tasks;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Entities;
using ICABAPI.Models;

namespace ICABAPI.Interfaces
{
    public interface IStudentExpelledService
    {
        public Task<ResponseDto3> GetListOfExpelledstudentAsync();
        public Task<ResponseDto3> GetStudentExpulsionStatusAsync(InputForGetStudentByRegNo input);
        public Task<ResponseDto3> CreateExpelledStudentAsync(StudentExpelled input);
        public Task<ResponseDto3> UpdateExpelledStudentAsync(StudentExpelled input);
    }
}