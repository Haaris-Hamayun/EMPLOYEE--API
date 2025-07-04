using EMPLOYEE_API.Data;
using EMPLOYEE_API.Models;
using EMPLOYEE_API.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public EmployeesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetALLEmployees()
        {
            // This is a placeholder for the actual implementation.
            // In a real application, you would retrieve employees from a database or other data source.
              var allEmployess =         dBContext.Employees.ToList();
            return Ok(allEmployess);

        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployessDto addEmployessDto)
        {
            var employeeentity = new Employee()
            {
                Name = addEmployessDto.Name,
                Email = addEmployessDto.Email,
                Salary = addEmployessDto.Salary,
                Phone = addEmployessDto.Phone,
            };

            dBContext.Employees.Add(employeeentity);
            dBContext.SaveChanges();

            return Ok(employeeentity);
        
        }



    }
}
