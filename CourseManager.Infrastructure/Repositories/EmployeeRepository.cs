using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbManager platformManagement) : base(platformManagement)
        {
        }
    }
}
