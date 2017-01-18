using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            ViewBag.Rels = _studentService.GetSubscribedCourses(
                new Guid(_userManager.GetUserId(User))
                );

            return View();
        }

        [Authorize(Roles = "Student")]
        public IActionResult Subscribe(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            _studentService.SubscribeCourse(
                new Guid(_userManager.GetUserId(User)),
                course
                );

            return RedirectToAction("Index");
        }

        /*[Authorize(Roles = "Student")]
        public IActionResult Subscribe(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            var student = _studentService.GetStudentByBaseId(
                new Guid(_userManager.GetUserId(User))
                );

           _studentService.SubscribeCourse(student, course);
            
            return View();
        }*/
    }
}