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
        public IActionResult Create(CreateViewModel model, string returnUrl = null)
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

                //
                return View(model);
            }

            return View(model);
        }

        //
        // POST: /Course/{id}/Edit
        public IActionResult Edit()
        {
            // return View(model);
            return View();  
        }

        //
        // DELETE: /Course/Delete/{id}
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Course course = _courseService.GetCourseById(id);
            CreateViewModel model = new CreateViewModel
            {
                Description = course.Description,
                Title = course.Title,
                Semester = course.Semester,
                Year = course.Year
            };

            return View(model);
        }


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