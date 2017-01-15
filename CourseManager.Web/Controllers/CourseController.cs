using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Services;

namespace CourseManager.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _service;


        public CourseController(ICourseService service)
        {
            _service = service;
        }
        public IActionResult Index(String title)
        {
            ViewBag.Message = "Course " + _service.GetCourseByTitle(title).Id;
            return View();
        }

    }
}