using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.CourseViewModels;
using CourseManager.Core.Models;
using CourseManager.Core.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CourseManager.Web.Models;

namespace CourseManager.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IEmployeeService _employeeService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public CourseController(
            ICourseService courseService, 
            IStudentService studentService, 
            IEmployeeService employeeService,
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager
            )
        {
            _employeeService = employeeService;
            _courseService = courseService;
            _studentService = studentService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.ListOfCourses = _courseService.GetAllCourses();

            return View();
        }

        [HttpGet]
        public IActionResult Show(Guid id)
        {
            ViewBag.Course = _courseService.GetCourseById(id);

            ViewBag.Course.Owner = _courseService.GetOwner(id);

            return View();
        }

        //
        // GET: /Course/Create
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Course/Create
        [HttpPost]
        [Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetEmployeeByBaseId(
                new Guid(_userManager.GetUserId(User))
                );
                var course = new Course
                {
                    Title = model.Title,
                    Description = model.Description,
                    Semester = model.Semester,
                    Owner = _employeeService.GetEmployeeByBaseId(
                        new Guid(_userManager.GetUserId(User))
                        )
                };

                _courseService.CreateCourse(course);
                
                return View(model);
            }

            return View(model);
        }

        //
        // GET: /Course/Edit/{id}
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            if (course == null) return RedirectToAction("Index");

            var model = new CourseCreateViewModel
            {
                Id = id,
                Description = course.Description,
                Title = course.Title,
                Semester = course.Semester,
                Year = course.Year
            };

            return View(model);
        }

        //
        // POST: /Course/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Semester = model.Semester,
                };
                _courseService.UpdateCourse(course);
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Course/Delete/{id}
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Course course = _courseService.GetCourseById(id);
            CourseCreateViewModel model = new CourseCreateViewModel
            {
                Description = course.Description,
                Title = course.Title,
                Semester = course.Semester,
                Year = course.Year
            };

            return View(model);
        }

        //
        // POST: /Course/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            Course course = _courseService.GetCourseById(id);
            _courseService.DeleteCourse(course);

            return RedirectToAction("Index");
        }
    }
}
