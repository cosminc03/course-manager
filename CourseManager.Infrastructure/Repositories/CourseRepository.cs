using System;
using System.Linq;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbManager platformManagement) : base(platformManagement)
        {
        }

        public Employee FindOwnerById(Guid id)
        {
            var course = DbManager.Courses
                .Where(crs => crs.Id == id)
                .Include(emp => emp.Owner)
                .FirstOrDefault();

            return course.Owner;
        }
    }
}