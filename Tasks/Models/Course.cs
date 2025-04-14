namespace Tasks.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
