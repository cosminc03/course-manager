using CourseManager.Core.Models;
using CourseManager.Infrastructure.Repositories;
using System;

namespace CourseManager.Infrastructure
{
    public class EntryPoint
    {
        public static void Main(string[] argv)
        {
            DbManager platformManagement = new DbManager();
            CourseRepository repo = new CourseRepository(platformManagement);

            Course course = new Course();
            course.Id = Guid.NewGuid();
            course.BaseId = Guid.NewGuid();
            course.Title = "Franalamuci";

            repo.Create(course);
        }
    }
}
