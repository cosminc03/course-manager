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
            var queryResult = from elem in DbManager.Set<Employee>()
                              where elem.BaseId == baseId
                              select elem;
            return queryResult.FirstOrDefault();
        }

        public Employee FindByIdWithCourses(Guid id)
        {
            return DbManager.Employees
                .Where(emp => emp.Id == id)
                .Include("Courses")
                .FirstOrDefault();
        }

        /*
          public  void EagerLoadCategoriesAndProducts()
        {
            ProductManager manager = new ProductManager();
            var query = manager.Employees.Include("Courses");
            foreach (Category category in query)
            {
                Console.WriteLine("{0} are {1} produse asignate", category.Name, category.Products.Count);
            }
        }
         */
    }
}
