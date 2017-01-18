using CourseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Core.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        IEnumerable<string> GetAllEmployeesNames();

        Employee GetEmployeeById(Guid guid);

        Employee GetEmployeeByBaseId(Guid baseId);

        IEnumerable<Course> GetAllCourses(Employee employee);

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

    }
}
