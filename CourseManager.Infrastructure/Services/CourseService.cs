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
        private readonly IEmployeeRepository _employeeRepository;

        public CourseService(
            ICourseRepository courseRepository,
            IEmployeeRepository employeeRepository
            )
        {
            _courseRepository = courseRepository;
            _employeeRepository = employeeRepository;
        }

        public void DeleteCourse(Course course)
        {
            _courseRepository.Delete(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.FindAll();
        }

        public Course GetCourseById(Guid guid)
        {
            return _courseRepository.FindById(guid);
        }

        public Employee GetOwner(Guid guid)
        {
            return _courseRepository.FindOwnerById(guid);
        }

        public IEnumerable<Student> GetStudents(Guid guid)
        {
            var course = _courseRepository.FindById(guid);

            return _courseRepository.FindStudents(course);
;        }

        public IEnumerable<Employee> GetAssociates(Course course)
        {
            return _courseRepository.FindAssociates(course);
        }

        public IEnumerable<Employee> GetPossibleAssociates(Course course)
        {
            var employees = _employeeRepository.FindAll();
            var associates = _courseRepository.FindAssociates(course);
            var owner = _courseRepository.FindOwnerById(course.Id);

            return employees.Where(
                emp => emp.BaseId != owner.BaseId && !associates.Contains(emp)
                );
        }

        public IEnumerable<Post> GetCoursePosts(Course course)
        {
            return _courseRepository.FindAllPosts(course);
        }


        public void CreateCourse(Course course)
        {
            _courseRepository.Create(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }


    }
}
