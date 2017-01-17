using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models.CourseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.PostViewModels;

namespace CourseManager.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {   
            return View();
        }

        //
        // GET: /Post/Create
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    Id = new System.Guid(),
                    Title = model.Title,
                    Content = model.Content,
                    CreatedAt = model.CreatedAt,
                    UpdatedAt = model.UpdatedAt
                };
                _postService.CreatePost(post);

                return View(model);
            }

            return View(model);
        }
    }
}