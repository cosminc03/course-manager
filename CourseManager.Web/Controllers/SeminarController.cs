using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseManager.Web.Controllers
{
    public class SeminarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}