using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Create(Employee employee, Course course);
    }
}
