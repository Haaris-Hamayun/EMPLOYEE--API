using EMPLOYEE_API.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace EMPLOYEE_API.Data
{
    public class ApplicationDBContext : DbContext
        {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
         {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
