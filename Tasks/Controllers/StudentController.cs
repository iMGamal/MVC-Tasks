using Microsoft.AspNetCore.Mvc;
using Tasks.DataAccess;
using Tasks.Models;
using Tasks.ViewModels;
namespace Tasks.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDB _context;
        public StudentController(ApplicationDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        public IActionResult Grades(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            var coursesNames = _context.StudentCourses
                    .Where(sc => sc.StudentId == student.Id)
                    .Select(sc => sc.Course.Name)
                    .ToList();
            var coursesGrades = _context.StudentCourses
                    .Where(sc => sc.StudentId == student.Id)
                    .Select(sc => sc.Degree)
                    .ToList();
            var viewModel = new StudentViewModel
            {
                FullName = student.Name,
                Image = student.Image,
                CoursesNames = coursesNames,
                Grades = coursesGrades
            };
            return View(viewModel);
        }
    }
}
