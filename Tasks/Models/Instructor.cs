using Microsoft.EntityFrameworkCore;
using Tasks.DataAccess;
namespace Tasks.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public float Salary { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public DateTime HiringDate { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}