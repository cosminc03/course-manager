﻿using System;
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
            var queryResult = from elem in DbManager.Set<Employee>()
                              where elem.BaseId == baseId
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public Employee FindByIdWithCourses(Guid id)
        {
            return DbManager.Employees
                .Where(emp => emp.Id == id)
                .Include(emp => emp.Courses)
                .FirstOrDefault();
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
    }
}
