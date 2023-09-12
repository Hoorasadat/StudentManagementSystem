using InstructorManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.Lib.Models;
using StudentManagementSystem.WEB.ViewModels;

namespace StudentManagementSystem.WEB.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IInstructorRepository _instructorRepository;

        public CoursesController(ICourseRepository courseRepository, IInstructorRepository instructorRepository)
        {
            _courseRepository = courseRepository;
            _instructorRepository = instructorRepository;
        }



        // GET: CoursesController
        public async Task<ActionResult> Index()
        {
            IList<Course> courses = await _courseRepository.GetAllCourses();
            return View(courses);
        }


        // GET: CoursesController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Course course = await _courseRepository.GetCourse(id);

            return View(course);
        }


        // GET: CoursesController/Create
        public async Task<ActionResult> Create()
        {
            await LoadInstructors();

            return View();
        }

        
        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCourseViewModel createCourseVM)
        {
            try
            {
                Course existingCourse = await _courseRepository.GetCourse(createCourseVM.Id);

                if(existingCourse != null)
                {
                    ModelState.AddModelError(string.Empty, $"Course with Id = {createCourseVM.Id} already exists!");
                }
                
                if (!ModelState.IsValid)
                {
                    //await LoadInstructors();
                    return View();
                }

                Course course = new Course()
                {
                    Id = createCourseVM.Id,
                    Title = createCourseVM.Title,
                    Credits = createCourseVM.Credits,
                    Instructor = createCourseVM.Instructor
                };

                await _courseRepository.AddCourse(course);

                return RedirectToAction("Index", "Courses");
            }
            catch
            {
                return View();
            }
        }


        // GET: CoursesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: CoursesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: CoursesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        private async Task LoadInstructors()
        {
            IList<Instructor> instructors = await _instructorRepository.GetAllInstructors();

            ViewData["Instructors"] = instructors.Select(i =>
                new SelectListItem { Text = $"{i.FirstName} {i.LastName}", Value = $"{i.FirstName} {i.LastName}" });
        }
    }
}
