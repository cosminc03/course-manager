using System;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(
            IStudentService studentService,
            ICourseService courseService,
            UserManager<ApplicationUser> userManager
            )
        {
            _studentService = studentService;
            _courseService = courseService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Courses = _studentService.GetSubscribedCourses(
                new Guid(_userManager.GetUserId(User))
                );

            return View();
        }
    }
}