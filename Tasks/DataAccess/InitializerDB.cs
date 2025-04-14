using Microsoft.EntityFrameworkCore;
using Tasks.Models;
namespace Tasks.DataAccess
{
    public static class InitializerDB
    {
        public static void Initialize(ApplicationDB _context)
        {
                if (_context.Students.Any())
                {
                    return;
                }

                var students = new Student[]
                {
                    new Student {
                        Name = "John Doe",
                        Age = 21,
                        Address = "123 University Ave, College Town",
                        Image = "/images/john.jpg"
                    },
                    new Student {
                        Name = "Jane Smith",
                        Age = 22,
                        Address = "456 Campus Road, College Town",
                        Image = "/images/jane.jpg"
                    },
                    new Student {
                        Name = "Michael Johnson",
                        Age = 20,
                        Address = "789 School Street, College Town",
                        Image = "/images/michael.jpg"
                    },
                    new Student {
                        Name = "Sarah Williams",
                        Age = 23,
                        Address = "101 Education Lane, College Town",
                        Image = "/images/sarah.jpg"
                    }
                };

                _context.Students.AddRange(students);
                _context.SaveChanges();
        }
    }
}
