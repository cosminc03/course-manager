using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using NuGet.Packaging;

namespace CourseManager.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbManager dbManager) : base(dbManager)
        {

        }

        public Student FindByBaseId(Guid baseId)
        {
            var queryResult = from elem in DbManager.Set<Student>()
                              where elem.BaseId == baseId
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public ICollection<Course> FindSubscribedCourses()
        {
            throw new NotImplementedException();
        }

        public void AddCourse(Student student, Course course)
        {
            var sc = new StudentCourse() { Course = course, Student = student };

            student.StudentCourses.Add(sc);

            DbManager.Update(student);
            DbManager.SaveChanges();
        }
    }
}