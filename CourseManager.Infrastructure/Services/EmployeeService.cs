using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using CourseManager.Core.Models;
using CourseManager.Core.Repositories.Interfaces;

namespace CourseManager.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository
            )
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Course> GetOwnedCourses(Employee employee)
        {
            return _employeeRepository.FindOwnedCourses(employee);
        }

        public IEnumerable<Course> Teaching(Employee employee)
        {
            return _employeeRepository.FindAssociatedCourses(employee);
        }

        public IEnumerable<Post> GetPosts(Employee employee)
        {
            return _employeeRepository.FindAllPosts(employee);
        }

        public void AddAssociateToCourse(Employee employee, Course course)
        {
             _employeeRepository.AddAssociate(employee, course);
        }

        public void DeleteAssociateFromCourse(Employee employee, Course course)
        {
            _employeeRepository.DeleteAssociate(employee, course);
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

        public Employee GetEmployeeByBaseId(Guid baseId)
        {
            return _employeeRepository.FindByBaseId(baseId);
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);
        }
    }
}
