using System;
using System.Collections.Generic;
//using ICABAPI.Models.Cpl_Models;
//using ICABAPI.Models.Cpls_Student_Models;


#nullable disable

namespace ICABAPI.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
           
            RefreshTokens = new List<RefreshToken>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int RegistrationNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public int Otp { get; set; }
        public bool IsVerified { get; set; }
        public bool CplVerification { get; set; }
        
        // public ExUniversity EXUNIVERSITY { get; set; }
        // public ExDepartment DEPARTMENT { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
      //  public List<StudentExamLevel> ExamLevels { get; set; }

       
       
    }
}
