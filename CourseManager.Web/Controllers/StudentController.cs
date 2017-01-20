using System;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CourseManager.Core.Models;

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
            var studentId = _userManager.GetUserId(User);

            var listOfCourses = new HashSet<Tuple<Course, bool>>();

            ViewBag.IsStudent = _userManager.GetRolesAsync(
                    _userManager.GetUserAsync(User).Result
                ).Result.Contains("Student");

            foreach (var course in _studentService.GetSubscribedCourses(new Guid(_userManager.GetUserId(User))))
            {
                course.Owner = _courseService.GetOwner(course.Id);

                if (!ViewBag.IsStudent)
                {
                    var tpl = new Tuple<Course, bool>(
                        course,
                        false
                    );
                    listOfCourses.Add(tpl);
                }
                else
                {
                    var tpl = new Tuple<Course, bool>(
                        course,
                        _studentService.IsSubscribedToCourse(new Guid(studentId), course)
                    );
                    listOfCourses.Add(tpl);
                }
            }

            ViewBag.Courses = listOfCourses;

            return View();
        }
    }
}