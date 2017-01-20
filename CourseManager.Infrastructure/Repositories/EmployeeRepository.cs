using System;
using System.Collections.Generic;
using System.Linq;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseManager.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbManager platformManagement) : base(platformManagement)
        {
        }

        public Employee FindByBaseId(Guid baseId)
        {
            return DbManager.Employees
                .FirstOrDefault(elem => elem.BaseId == baseId);
        }

        public IEnumerable<Course> FindOwnedCourses(Employee employee)
        {
            return DbManager.Employees
                .Where(emp => emp.Id == employee.Id)
                .Include(emp => emp.Courses)
                .FirstOrDefault()
                .Courses;
        }

        public void AddAssociate(Employee employee, Course course)
        {
            var rel = new CourseEmployee()
            {
                CourseId = course.Id,
                Course = course,
                EmployeeId = employee.Id,
                Employee = employee
            };

            DbManager.CourseEmployees.Add(rel);
            DbManager.SaveChanges();
        }

        public void DeleteAssociate(Employee employee, Course course)
        {
            var rel = new CourseEmployee()
            {
                CourseId = course.Id,
                Course = course,
                EmployeeId = employee.Id,
                Employee = employee
            };

            DbManager.CourseEmployees.Remove(rel);
            DbManager.SaveChanges();
        }

        public IEnumerable<Course> FindAssociatedCourses(Employee employee)
        {
            var rels = DbManager.CourseEmployees
                .Where(r => employee.Id == r.EmployeeId)
                .Include(r => r.Course);

            var courses = new HashSet<Course>();

            foreach (var rel in rels)
                courses.Add(rel.Course);

            return courses;
        }

        public IEnumerable<Post> FindAllPosts(Employee employee)
        {
            return DbManager.Employees
               .Where(emp => employee.Id == emp.Id)
               .Include(emp => emp.Posts)
               .FirstOrDefault()
               .Posts;
        }
    }
}
