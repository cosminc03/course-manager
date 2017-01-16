using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(Course course)
        {
            _courseRepository.Create(course);
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.Delete(course);
        }

        public IEnumerable<string> GetAllCourseNames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.FindAll();
        }

        public Course GetCourseById(Guid guid)
        {
            return _courseRepository.FindById(guid);
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
