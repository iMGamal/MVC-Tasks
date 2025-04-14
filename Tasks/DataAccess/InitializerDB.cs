using Microsoft.EntityFrameworkCore;
using Tasks.Models;
namespace Tasks.DataAccess
{
    public static class InitializerDB
    {
        public static void Initialize(ApplicationDB _context)
        {
            if (!_context.Departments.Any())
            {
                var departments = new Department[]
                {
                    new Department {
                        Name = "Computer Science",
                        Description = "Focuses on the study of computers and computational systems.",
                        Location = "Building A, Room 101"
                    },
                    new Department {
                        Name = "Information Systems",
                        Description = "Combines business and technology to manage information systems.",
                        Location = "Building B, Room 202"
                    }
                };
                _context.Departments.AddRange(departments);
                _context.SaveChanges();
            }

            if (!_context.Students.Any())
            {
                var students = new Student[]
                {
                    new Student
                    {
                        Name = "John Doe",
                        Age = 21,
                        Address = "123 University Ave, College Town",
                        Image = "/images/john.PNG",
                        DepartmentId = 1
                    },
                    new Student {
                        Name = "Jane Smith",
                        Age = 22,
                        Address = "456 Campus Road, College Town",
                        Image = "/images/jane.PNG",
                        DepartmentId = 2
                    }
                };
                _context.Students.AddRange(students);
                _context.SaveChanges();
            }

            if (!_context.Instructors.Any())
            {
                var instructors = new Instructor[]
                {
                    new Instructor {
                        FName = "Alice",
                        LName = "Brown",
                        Salary = 50000,
                        Image = "/images/alice.PNG",
                        Age = 35,
                        HiringDate = DateTime.Now.AddYears(-5),
                        DepartmentId = 1
                    },
                    new Instructor {
                        FName = "Bob",
                        LName = "Smith",
                        Salary = 60000,
                        Image = "/images/bob.PNG",
                        Age = 40,
                        HiringDate = DateTime.Now.AddYears(-3),
                        DepartmentId = 2
                    }
                };
                _context.Instructors.AddRange(instructors);
                _context.SaveChanges();
            }

            if (!_context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new Course {
                        Name = "Introduction to Programming",
                        Topic = "Learn the basics of programming using C#.",
                        InstructorId = 1
                    },
                    new Course {
                        Name = "Database Management Systems",
                        Topic = "Understand the principles of database design and management.",
                        InstructorId = 2
                    }
                };
                _context.Courses.AddRange(courses);
                _context.SaveChanges();
            }

            if (!_context.StudentCourses.Any())
            {
                var studentCourses = new StudentCourse[]
                {
                    new StudentCourse {
                        StudentId = 1,
                        CourseId = 1,
                        Degree = 50,
                    },
                    new StudentCourse {
                        StudentId = 2,
                        CourseId = 2,
                        Degree = 80,
                    }
                };
                _context.StudentCourses.AddRange(studentCourses);
                _context.SaveChanges();
            }
        }
    }
}
