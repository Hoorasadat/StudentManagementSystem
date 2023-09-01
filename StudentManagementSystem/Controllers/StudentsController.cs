using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.BLL.Repositories;
using StudentManagementSystem.Data.Data;
using StudentManagementSystem.Lib.Models;
//using StudentManagementSystem.ViewModels;
using StudentManagementSystem.WEB.ViewModels;

namespace StudentManagementSystem.WEB.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: StudentsController
        //[Route("/All")]
        //[Route("students/getallstudents")]
        //public async Task<JsonResult> Index()
        //{
        //    IList<Student> students = await _studentRepository.GetAllStudents();
        //    return Json(students);

        //    //return View(students);
        //}

        public async Task<ActionResult> Index()
        {
            IList<Student> students = await _studentRepository.GetAllStudents();
            return View(students);

            //return View(students);
        }

        // GET: StudentsController/Details/5
        
        public async Task<ActionResult> Details(int id)
        {
            //MemoryDbContext context = new MemoryDbContext();
            //MockStudentRepository studentRepository = new MockStudentRepository(context);
            
            Student student = await _studentRepository.GetStudent(id);

            //return Json(student);

            //ViewData["PageTitle"] = "Student Detailis";
            //ViewData["Student"] = student;
            //return View();

            //ViewBag.PageTitle = "Student Detailis";
            //ViewBag.Student = student;
            //return View(student);

            StudentViewModel stuentVM = new StudentViewModel()
            {
                Student = student,
                Title = "Student Details"
            };

            return View(stuentVM);
        }


        [Route("getstudent/courses/{id}")]
        //[Route("getstudent/{id}/courses/")]
        public async Task<ViewResult> GetStudentCourses(int id)
        {
            IList<string> courseList = await _studentRepository.GetStudentCourses(id);
            return View(courseList);
        }


        // GET: StudentsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStudentViewModel studentVM)
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


        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: StudentsController/Edit/5
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


        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: StudentsController/Delete/5
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
    }
}
