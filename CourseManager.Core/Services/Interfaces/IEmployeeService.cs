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

        IEnumerable<Course> Teaching(Employee employee);

        void AddAssociateToCourse(Employee employee, Course course);

        void DeleteAssociateFromCourse(Employee employee, Course course);

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);   
    }
}
