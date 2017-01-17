using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.CourseViewModels;
using CourseManager.Core.Models;
using CourseManager.Core.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CourseManager.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            ViewBag.ListOfCourses = _courseService.GetAllCourses();
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Id = new System.Guid(),
                    Title = model.Title,
                    Description = model.Description,
                    Semester = model.Semester,
                };
                _courseService.CreateCourse(course);

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Course course = _courseService.GetCourseById(id);
            CourseCreateViewModel model = new CourseCreateViewModel
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
