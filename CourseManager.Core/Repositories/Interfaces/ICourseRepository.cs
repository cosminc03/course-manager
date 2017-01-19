using System;
using System.Collections.Generic;
using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Employee FindOwnerById(Guid id);

        IEnumerable<Student> FindStudents(Course course);

        IEnumerable<Employee> FindAssociates(Course course);
    }
}
