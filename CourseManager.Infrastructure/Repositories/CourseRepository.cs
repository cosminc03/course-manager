using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
namespace CourseManager.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbManager platformManagement) : base(platformManagement)
        {
        }

        public Course FindByTitle(String title)
        {
            var queryResult = from elem in Context.Set<Course>()
                              where elem.Title == title
                              select elem;
            return queryResult.FirstOrDefault();
        }
    }
}