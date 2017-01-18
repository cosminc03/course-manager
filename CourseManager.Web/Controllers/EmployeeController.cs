using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IEmployeeService employeeService
            )
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            ViewBag.EmployeesList = _employeeService.GetAllEmployees();

            return View();
        }

        public IActionResult Profile(Guid id)
        {
            ViewBag.Employee = _employeeService.GetEmployeeByBaseId(id);

            ViewBag.EmployeeCourses = _employeeService.GetAllCourses(ViewBag.Employee);

            return View();
        }

    }
}