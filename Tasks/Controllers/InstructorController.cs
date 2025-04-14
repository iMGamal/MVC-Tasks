using Microsoft.AspNetCore.Mvc;
using Tasks.DataAccess;
using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class InstructorController : Controller
    {
        private readonly ApplicationDB _context;
        public InstructorController(ApplicationDB context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var instructors = _context.Instructors.ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = _context.Instructors.FirstOrDefault(i => i.Id == id);
            var courses = _context.Courses
                    .Where(c => c.InstructorId == instructor.Id)
                    .Select(c => c.Name)
                    .ToList();
            var viewModel = new InstructorViewModel
            {
                FullName = $"{instructor.FName} {instructor.LName}",
                Image = instructor.Image,
                HiringDate = instructor.HiringDate,
                CoursesNames = courses
            };
            return View(viewModel);
        }
    }
}
