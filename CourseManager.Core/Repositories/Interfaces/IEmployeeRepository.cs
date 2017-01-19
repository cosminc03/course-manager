using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee FindByBaseId(Guid baseId);

        Employee FindByIdWithCourses(Guid id);

        void AddAssociate(Employee employee, Course course);
    }
}
