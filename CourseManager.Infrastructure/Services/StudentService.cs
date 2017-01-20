using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using CourseManager.Core.Services.Interfaces;

namespace CourseManager.Infrastructure.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public void CreateStudent(Student student)
        {
            _studentRepository.Create(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentRepository.Delete(student);
        }

        public void SubscribeCourse(Guid guid, Course course)
        {
            var student = _studentRepository.FindByBaseId(guid);

            _studentRepository.AddCourse(course, student);
        }

        public void UnsubscribeCourse(Guid guid, Course course)
        {
            var student = _studentRepository.FindByBaseId(guid);

            _studentRepository.DeleteCourse(course, student);
        }

        public bool IsSubscribedToCourse(Guid guid, Course course)
        {
            var student = _studentRepository.FindByBaseId(guid);

            var courses = _studentRepository.FindCourses(student);

            return courses.Contains(course);
        }

        public IEnumerable<Course> GetSubscribedCourses(Guid guid)
        {
            var student = _studentRepository.FindByBaseId(guid);

            return _studentRepository.FindCourses(student);
        }

        public IEnumerable<Post> GetRelevantPosts(Student student)
        {
            var courses = _studentRepository.FindCourses(student);

            var relevantPosts = new List<Post>();

            foreach (var course in courses)
            {
                var temp = _courseRepository.FindAllPosts(course);
                relevantPosts = relevantPosts.Concat(temp).ToList();
            }

            return relevantPosts.OrderByDescending(p => p.CreatedAt);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.FindAll();
        }

        public IEnumerable<string> GetAllStudentsNames()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(Guid guid)
        {
            return _studentRepository.FindById(guid);
        }

        public Student GetStudentByBaseId(Guid baseId)
        {
            return _studentRepository.FindByBaseId(baseId);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }
    }
}
