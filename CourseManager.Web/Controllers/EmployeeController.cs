using System;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(
            IEmployeeService employeeService,
            UserManager<ApplicationUser> userManager
            )
        {
            _employeeService = employeeService;
            _userManager = userManager;
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

            ViewBag.Teaching = _employeeService.Teaching(ViewBag.Employee);

            return View();
        }
    }
}