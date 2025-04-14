using Tasks.Models;
namespace Tasks.ViewModels
{
    public class InstructorViewModel
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public DateTime HiringDate { get; set; }
        public List<string> CoursesNames { get; set; }
    }
}
