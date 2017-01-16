using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models.SeminarViewModels;
using CourseManager.Core.Models;

namespace CourseManager.Web.Controllers
{
    public class SeminarController : Controller
    {
        private readonly ISeminarService _seminarService;

        public SeminarController(ISeminarService seminarService)
        {
            _seminarService = seminarService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //
        // GET: /Seminar/Create
        [HttpGet]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Seminar/Create
        [HttpPost]
        public IActionResult Create(CreateSeminarViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Seminar seminar = new Seminar
                {
                    Id = new System.Guid(),
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content
                };
                _seminarService.CreateSeminar(seminar);

                //
                return View(model);
            }

            return View(model);
        }
    }
}