using System.Globalization;

namespace EMPLOYEE_API.Models
{
    public class AddEmployessDto
    {

        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }

        public String Address { get; set; } 
    }
}
