using Tasks.DataAccess;
namespace Tasks.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        private readonly ApplicationDB _context;

        public IEnumerable<Student> Index()
        {
            return _context.Students.ToList();
        }

        public Student Details(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }
    }
}
