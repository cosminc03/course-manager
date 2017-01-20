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

        void AddAssociate(Employee employee, Course course);

        void DeleteAssociate(Employee employee, Course course);

        IEnumerable<Course> FindOwnedCourses(Employee employee);

        IEnumerable<Course> FindAssociatedCourses(Employee employee);

        IEnumerable<Post> FindAllPosts(Employee employee);
    }
}
