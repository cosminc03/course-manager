using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public void AddCourse(Course course, Student student)
        {
            var rel = new StudentCourse()
            {
                CourseId = course.Id,
                Course = course,
                StudentId = student.Id,
                Student = student
            };

            DbManager.StudentCourses.Add(rel);
            DbManager.SaveChanges();
        }

        public IEnumerable<Course> FindCourses(Student student)
        {
            var rels = DbManager.StudentCourses
                .Where(st => st.StudentId == student.Id)
                .Include(sc => sc.Course);

            var courses = new HashSet<Course>();

            foreach (var rel in rels)
                courses.Add(rel.Course);

            return courses;
        }
    }
}