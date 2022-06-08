using ICABAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICABAPI.Interfaces
{
    public interface IGetResultFromMoodleService
    {
        Task<List<CourseGrades>> GetCourseGrades(int RegNo);
        Task<List<CourseListFromMoodle>> GetCourseListFromMoodles();
        Task<SingleUserFromMoodle> GetSingleUserFromMoodle(int RegNo);


    }
}
