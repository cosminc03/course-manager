using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseManager.Core.Models;
using CourseManager.Core.Services.Interfaces;
using CourseManager.Web.Models;
using CourseManager.Web.Models.CourseViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.PostViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseManager.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IEmployeeService _employeeService;
        private readonly ICourseService _courseService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(
            IPostService postService,
            IEmployeeService employeeService,
            ICourseService courseService,
            UserManager<ApplicationUser> userManager
            )
        {
            _postService = postService;
            _employeeService = employeeService;
            _courseService = courseService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.ListOfPosts = _postService.GetAllPosts();

            return View();
        }

        public IActionResult Show(Guid id)
        {
            ViewBag.Post = _postService.GetPostById(id);

            ViewBag.Post.Owner = _postService.GetPostOwner(ViewBag.Post);

            ViewBag.Post.Course = _postService.GetPostCourse(ViewBag.Post);

            return View();
        }

        //
        // GET: /Post/Create
        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var employee = _employeeService.GetEmployeeByBaseId(
                new Guid(_userManager.GetUserId(User))
                );

            var model = new PostCreateViewModel()
            {
                CourseList = new SelectList(_employeeService.GetOwnedCourses(employee), "Id", "Title")
            };

            return View(model);
        }

        //
        // POST: /Post/Create
        [HttpPost]
        [Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var course = _courseService.GetCourseById(new Guid(model.Course));
            var employee = _employeeService.GetEmployeeByBaseId(
                new Guid(_userManager.GetUserId(User))
                );

            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Course = course,
                    Owner = employee
                };

                _postService.CreatePost(post);

                return RedirectToAction("Index");
            }

            model.CourseList = new SelectList(_employeeService.GetOwnedCourses(employee), "Id", "Title");

            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Edit(Guid id)
        {
            var post = _postService.GetPostById(id);

            var model = new PostCreateViewModel
            {
                Title = post.Title,
                Content = post.Content
            };

            return View(model);
        }

        //
        // POST: /Course/Edit/{id}
        [HttpPost]
        [Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostCreateViewModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                var post = _postService.GetPostById(id);

                post.Title = model.Title;
                post.Content = model.Content;
                post.UpdatedAt = DateTime.Now;

                _postService.UpdatePost(post);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult Delete(Guid id)
        {
            var post = _postService.GetPostById(id);

            var model = new PostCreateViewModel
            {
                Title = post.Title,
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

            var post = _postService.GetPostById(id);

            _postService.DeletePost(post);

            return RedirectToAction("Index");
        }

    }
}