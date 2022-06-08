using System;

namespace ICABAPI.DTOs
{
    public class UpdateDobEmailDto
    {
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int RegistrationNumber { get; set; }
    }
}