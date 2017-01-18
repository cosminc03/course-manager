using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CourseManager.Core.Models;

namespace CourseManager.Core.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student FindByBaseId(Guid baseId);

        void AddCourse(Course course, Student student);

        IEnumerable<StudentCourse> FindCourses(Student student);
    }
}
