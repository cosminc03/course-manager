using System;
using System.Collections.Generic;
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

        public IEnumerable<Student> FindStudents(Course course)
        {
            var rels = DbManager.StudentCourses
                .Where(st => st.CourseId == course.Id)
                .Include(sc => sc.Student);

            var students = new HashSet<Student>();

            foreach (var rel in rels)
                students.Add(rel.Student);

            return students;
        }

        public IEnumerable<Employee> FindAssociates(Course course)
        {
            var rels = DbManager.CourseEmployees
                .Where(cr => cr.CourseId == course.Id)
                .Include(sc => sc.Employee);

            var employees = new HashSet<Employee>();

            foreach (var rel in rels)
                employees.Add(rel.Employee);

            return employees;
        }
    }
}