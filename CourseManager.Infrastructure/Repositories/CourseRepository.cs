using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbManager platformManagement) : base(platformManagement)
        {
        }

        public void Create(Employee employee, Course course)
        {
            this.Create(course);

            employee.Courses.Add(course);

            DbManager.Update(employee);
            DbManager.SaveChanges();
        }
    }
}