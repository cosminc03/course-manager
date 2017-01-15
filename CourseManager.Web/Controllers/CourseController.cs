using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.CourseViewModels;

namespace CourseManager.Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        //
        // GET: /Course/Create
        [HttpGet]
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
                model.Title = "OK, all good";

                return View(model);
            }

            return View(model);
        }
    }
}