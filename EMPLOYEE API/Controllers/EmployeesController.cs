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
            var allEmployess = dBContext.Employees.ToList();
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
                Address = addEmployessDto.Address,
            };

            dBContext.Employees.Add(employeeentity);
            dBContext.SaveChanges();

            return Ok(employeeentity);

        }
        [HttpGet]
        [Route("{id:guid}")]
       
        public IActionResult GetEmployeebyID(Guid id )
        {
            // This method retrieves an employee by their ID.
            var employee =  dBContext.Employees.Find(id);
            // check eployee find or not
            if (employee == null)


            {
                return NotFound();
            }
            return Ok(employee);

        }
        [HttpPut]

        public IActionResult UpdateEmployee(Guid id, AddEmployessDto addEmployessDto)
        {
            // This method updates an existing employee's details.
            var employee = dBContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = addEmployessDto.Name;
            employee.Email = addEmployessDto.Email;
            employee.Phone = addEmployessDto.Phone;
            employee.Salary = addEmployessDto.Salary;

            dBContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}") ]
        public IActionResult DeleteEmployee(Guid id)
        {
            // This method deletes an employee by their ID.
            var employee = dBContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            dBContext.Employees.Remove(employee);
            dBContext.SaveChanges();

            return Ok(employee);
        }




    }
}
