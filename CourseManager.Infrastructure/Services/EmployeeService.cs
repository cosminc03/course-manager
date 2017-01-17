using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Services
{
    public class EmployeeService : IEmpoyeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository; 
        }

        public void CreateEmployee(Employee employee)
        {
            _employeeRepository.Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.FindAll();
        }

        public IEnumerable<string> GetAllEmployeesNames()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid guid)
        {
            return _employeeRepository.FindById(guid);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
