using EnrollmentManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentManagementSystem.BLL.Interfaces;
using StudentManagementSystem.WEB.ViewModels;

namespace StudentManagementSystem.WEB.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentsController(IEnrollmentRepository enrollmentRepository, IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }


        // GET: EnrollmentController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IList<Enrollment> enrollments = await _enrollmentRepository.GetAllEnrollments();
            return View(enrollments);
        }


        // GET: EnrollmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



        // GET: EnrollmentController/Details/5
        [HttpGet]
        public async Task<ActionResult> AddGrade(int id)
        {
            Enrollment enrollment = await _enrollmentRepository.GetEnrollment(id);
            AddGradeViewModel addGradeVM = new AddGradeViewModel()
            {
                Id = enrollment.ID,
                CourseId = enrollment.CourseID,
                StudentId = enrollment.StudentID,
                CourseTitle = enrollment.Course.Title,
                StudentName = $"{enrollment.Student.FirstName} {enrollment.Student.LastName}",
                Grade = enrollment.Grade,
            };
            return View(addGradeVM);
        }


        [HttpPost]
        public async Task<ActionResult> AddGrade(AddGradeViewModel addGradeVM)
        {
            Enrollment enrollment = new Enrollment()
            {
                ID = addGradeVM.Id,
                CourseID = addGradeVM.CourseId,
                StudentID = addGradeVM.StudentId,
                Grade = addGradeVM.Grade
            };

            await _enrollmentRepository.UpdateEnrollment(enrollment);

            return RedirectToAction("Index", "Enrollments");
        }


        // GET: EnrollmentController/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["Students"] = (await _studentRepository.GetAllStudents())
                .Select(s => new SelectListItem { Text = $"{s.FirstName} {s.LastName}", Value = s.Id.ToString()});

            ViewData["Courses"] = (await _courseRepository.GetAllCourses())
                .Select(c => new SelectListItem { Text = c.Title, Value = c.Id.ToString()});
            
            return View();
        }


        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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


        // GET: EnrollmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: EnrollmentController/Edit/5
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


        // GET: EnrollmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: EnrollmentController/Delete/5
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
