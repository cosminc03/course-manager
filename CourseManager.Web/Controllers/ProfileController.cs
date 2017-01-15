using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Core.Models;

namespace CourseManager.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Asadsa";
            return View();
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatedCourse(Course c)
        {
            ViewBag.Message = (c.Title);
            return View();
        }
    }
}