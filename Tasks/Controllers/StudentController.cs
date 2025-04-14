using Microsoft.AspNetCore.Mvc;
using Tasks.DataAccess;
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
    }
}
