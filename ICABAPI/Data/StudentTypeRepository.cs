using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ICABAPI.Data
{
    public class StudentTypeRepository : IStudentTypeRepository
    {

         private readonly ModelContext _context;
        public StudentTypeRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentType>> GetStudentTypesAsync()
        {
            return await _context.StudentTypes.ToListAsync();
        }

        public async Task<int> GetMaxStudentTypeIdAsync()
        {
    
            var maxId =  await _context.StudentTypes.MaxAsync(x => (byte?) x.StudId + 1) ?? 1;
            var maxIdint = Convert.ToInt32(maxId);
            return maxIdint;
            
        }

        public async Task<bool> CreateStudentTypeAsync(StudentType studentType)
        {
            _context.StudentTypes.Add(studentType);
            var rowseffcted = await _context.SaveChangesAsync() > 0;
            return rowseffcted;
        }
        
    }
}