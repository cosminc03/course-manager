using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;

namespace CourseManager.Core.Services.Interfaces
{
    public interface IStudentService
    {

        IEnumerable<Student> GetAllStudents();

        IEnumerable<string> GetAllStudentsNames();

        Student GetStudentById(Guid guid);

        Student GetStudentByBaseId(Guid baseId);

        void CreateStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        void SubscribeCourse(Guid guid, Course course);

        IEnumerable<Course> GetSubscribedCourses(Guid guid); 
    }
}
