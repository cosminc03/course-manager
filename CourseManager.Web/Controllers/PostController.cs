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
            ViewBag.ListOfPosts = _postService.GetAllPosts();
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

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Post post = _postService.GetPostsById(id);
            PostCreateViewModel model = new PostCreateViewModel
            {
                Id = id,
                Content = post.Content,
                Title = post.Title,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };

            return View(model);
        }

        //
        // POST: /Course/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post= new Post
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content,
                    UpdatedAt = model.UpdatedAt,
                    
                };
                _postService.UpdatePost(post);
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            Post post = _postService.GetPostsById(id);
            PostCreateViewModel model = new PostCreateViewModel
            {
                CreatedAt = post.CreatedAt,
                Title = post.Title,
                UpdatedAt = post.UpdatedAt,
                Content = post.Content
            };

            return View(model);
        }


        //
        // POST: /Course/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            Post post = _postService.GetPostsById(id);
            _postService.DeletePost(post);

            return RedirectToAction("Index");
        }

    }
}