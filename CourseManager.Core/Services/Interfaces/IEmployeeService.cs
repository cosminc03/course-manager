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

        void CreateEmployee(Employee course);

        void UpdateEmployee(Employee course);

        void DeleteEmployee(Employee course);

        Employee GetEmployeeByBaseId(Guid baseId);
    }
}
