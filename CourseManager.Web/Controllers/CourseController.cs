using Microsoft.AspNetCore.Mvc;
using CourseManager.Web.Models.CourseViewModels;
using CourseManager.Core.Models;
using CourseManager.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CourseManager.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseManager.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IEmployeeService _employeeService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;


        public CourseController(
            ICourseService courseService,
            IStudentService studentService,
            IEmployeeService employeeService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager
            )
        {
            _employeeService = employeeService;
            _courseService = courseService;
            _studentService = studentService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //var anonymousTypeVar = new { x = 5, y = 10 };
            //ViewBag.ListOfCourses = _courseService.GetAllCourses();

            var studentId = _userManager.GetUserId(User);

            var listOfCourses = new HashSet<Tuple<Course, bool>>();

            ViewBag.IsStudent = _userManager.GetRolesAsync(
                    _userManager.GetUserAsync(User).Result
                ).Result.Contains("Student");

            foreach (var course in _courseService.GetAllCourses())
            {
                if (!ViewBag.IsStudent)
                {
                    var tpl = new Tuple<Course, bool>(
                        course,
                        false
                    );
                    listOfCourses.Add(tpl);
                }
                else
                {
                    var tpl = new Tuple<Course, bool>(
                        course,
                        _studentService.IsSubscribedToCourse(new Guid(studentId), course)
                    );
                    listOfCourses.Add(tpl);
                }
            }

            ViewBag.ListOfCourses = listOfCourses;

            return View();
        }

        [HttpGet]
        public IActionResult Show(Guid id)
        {
            ViewBag.Course = _courseService.GetCourseById(id);

            ViewBag.Course.Owner = _courseService.GetOwner(id);

            ViewBag.Associates = _courseService.GetAssociates(ViewBag.Course);

            ViewBag.IsStudent = _userManager.GetRolesAsync(
                _userManager.GetUserAsync(User).Result
            ).Result.Contains("Student");

            if (ViewBag.IsStudent)
            {
                ViewBag.IsSubscribed = _studentService.IsSubscribedToCourse(
               new Guid(_userManager.GetUserId(User)),
               ViewBag.Course
               );
            }

            return View();
        }

        [HttpGet]
        public IActionResult Students(Guid id)
        {
            ViewBag.Course = _courseService.GetCourseById(id);

            ViewBag.Students = _courseService.GetStudents(id);

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
        [Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetEmployeeByBaseId(
                new Guid(_userManager.GetUserId(User))
                );
                var course = new Course
                {
                    Title = model.Title,
                    Description = model.Description,
                    Semester = model.Semester,
                    Owner = _employeeService.GetEmployeeByBaseId(
                        new Guid(_userManager.GetUserId(User))
                        )
                };

                _courseService.CreateCourse(course);

                return View(model);
            }

            return View(model);
        }

        //
        // GET: /Course/Edit/{id}
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            if (course == null) return RedirectToAction("Index");

            var model = new CourseCreateViewModel
            {
                Id = id,
                Description = course.Description,
                Title = course.Title,
                Semester = course.Semester,
                Year = course.Year
            };

            return View(model);
        }

        //
        // POST: /Course/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = new Course
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Semester = model.Semester,
                };
                _courseService.UpdateCourse(course);
                //return RedirectToAction("Index");
            }
            return View(model);
        }

        //
        // GET: /Course/Delete/{id}
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var course = _courseService.GetCourseById(id);
            var model = new CourseCreateViewModel
            {
                Description = course.Description,
                Title = course.Title,
                Semester = course.Semester,
                Year = course.Year
            };

            return View(model);
        }

        //
        // POST: /Course/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            Course course = _courseService.GetCourseById(id);
            _courseService.DeleteCourse(course);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Student")]
        public IActionResult Subscribe(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            _studentService.SubscribeCourse(
                new Guid(_userManager.GetUserId(User)),
                course
                );

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Student")]
        public IActionResult Unsubscribe(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            _studentService.UnsubscribeCourse(
                new Guid(_userManager.GetUserId(User)),
                course
                );

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult AddAssociate(Guid id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var employee = _employeeService.GetEmployeeByBaseId(
               new Guid(_userManager.GetUserId(User))
               );
            var owner = _courseService.GetOwner(id);

            if (employee.Id != owner.Id) return RedirectToAction("Profile", "Employee", new { id = employee.BaseId });

            ViewBag.Course = _courseService.GetCourseById(id);

            var model = new CourseAddAssociateViewModel()
            {
                AssociateList = new SelectList(_courseService.GetPossibleAssociates(ViewBag.Course), "Id", "FirstName")
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult AddAssociate(CourseAddAssociateViewModel model, Guid id, string returnUrl = null)
        {
            var employee = _employeeService.GetEmployeeByBaseId(
               new Guid(_userManager.GetUserId(User))
               );
            var owner = _courseService.GetOwner(id);

            if (employee.Id != owner.Id) return RedirectToAction("Profile", "Employee", new { id = employee.BaseId });

            if (ModelState.IsValid)
            {
                var associate = _employeeService.GetEmployeeById(new Guid(model.Associate));
                var course = _courseService.GetCourseById(id);

                _employeeService.AddAssociateToCourse(associate, course);

                return RedirectToAction("Show", "Course", new { id = course.Id });
            }

            model.AssociateList = new SelectList(_courseService.GetPossibleAssociates(ViewBag.Course), "Id", "FirstName");

            return RedirectToAction("AddAssociate", new { id = id });
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        public IActionResult DeleteAssociate(Guid id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var employee = _employeeService.GetEmployeeByBaseId(
               new Guid(_userManager.GetUserId(User))
               );
            var owner = _courseService.GetOwner(id);

            if (employee.Id != owner.Id) return RedirectToAction("Profile", "Employee", new { id = employee.BaseId });

            ViewBag.Course = _courseService.GetCourseById(id);

            var model = new CourseAddAssociateViewModel()
            {
                AssociateList = new SelectList(_courseService.GetAssociates(ViewBag.Course), "Id", "FirstName")
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult DeleteAssociate(CourseAddAssociateViewModel model, Guid id, string returnUrl = null)
        {
            var employee = _employeeService.GetEmployeeByBaseId(
               new Guid(_userManager.GetUserId(User))
               );
            var owner = _courseService.GetOwner(id);

            if (employee.Id != owner.Id) return RedirectToAction("Profile", "Employee", new { id = employee.BaseId });

            if (ModelState.IsValid)
            {
                var associate = _employeeService.GetEmployeeById(new Guid(model.Associate));
                var course = _courseService.GetCourseById(id);

                _employeeService.DeleteAssociateFromCourse(associate, course);

                return RedirectToAction("Show", "Course", new { id = course.Id });
            }

            model.AssociateList = new SelectList(_courseService.GetAssociates(ViewBag.Course), "Id", "FirstName");

            return RedirectToAction("AddAssociate", new { id = id });
        }

        [Authorize(Roles = "Student")]
        public IActionResult News()
        {
            var student = _studentService.GetStudentByBaseId(
                new Guid(_userManager.GetUserId(User))
                );

            ViewBag.News = _studentService.GetRelevantPosts(student);

            return View();
        }

        public IActionResult Posts(Guid id)
        {
            var course = _courseService.GetCourseById(id);

            ViewBag.Posts = _courseService.GetCoursePosts(course);

            return View();
        }


    }
}
