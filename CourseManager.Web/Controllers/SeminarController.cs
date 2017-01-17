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
            ViewBag.ListOfSeminaries = _seminarService.GetAllSeminaries();
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
        public IActionResult Create(SeminarCreateViewModel model, string returnUrl = null)
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


                // return View(model);
            }

            return View(model);
        }

        //
        // POST: /Seminar/Edit/{id}
        public IActionResult Edit(Guid id)
        {
            Seminar seminar = _seminarService.GetSeminarById(id);
            SeminarCreateViewModel model = new SeminarCreateViewModel
            {
                Id = id,
                Description = seminar.Description,
                Title = seminar.Title,
                Content = seminar.Content
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeminarCreateViewModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                var x = model;
                Seminar seminar = new Seminar
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content
                };
                _seminarService.UpdateSeminar(seminar);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // DELETE: /Course/Delete/{id}
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Seminar seminar = _seminarService.GetSeminarById(id);
            SeminarCreateViewModel model = new SeminarCreateViewModel
            {
                Description = seminar.Description,
                Title = seminar.Title,
                Content = seminar.Content
            };

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            Seminar seminar = _seminarService.GetSeminarById(id);
            _seminarService.DeleteSeminar(seminar);
            return RedirectToAction("Index");
        }

    }
}