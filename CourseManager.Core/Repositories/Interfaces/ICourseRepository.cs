using System;
using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Employee FindOwnerById(Guid id);
    }
}
