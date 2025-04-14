using Microsoft.EntityFrameworkCore;
using Tasks.Models;
namespace Tasks.DataAccess
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(
                options =>
                {
                    options.HasKey(s => s.Id);
                    options.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentId);
                    options.HasMany(s => s.StudentCourses)
                    .WithOne(sc => sc.Student)
                    .HasForeignKey(sc => sc.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Course>(
                options =>
                {
                    options.HasKey(c => c.Id);
                    options.HasOne(c => c.Instructor)
                    .WithMany(i => i.Courses)
                    .HasForeignKey(c => c.InstructorId);
                    options.HasMany(c => c.StudentCourses)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Instructor>(
                optons =>
                {
                    optons.HasKey(i => i.Id);
                    optons.HasOne(i => i.Department)
                    .WithMany(d => d.Instructors)
                    .HasForeignKey(i => i.DepartmentId);
                    optons.HasMany(i => i.Courses)
                    .WithOne(c => c.Instructor)
                    .HasForeignKey(c => c.InstructorId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Department>(
                options =>
                {
                    options.HasKey(d => d.Id);
                    options.HasMany(d => d.Students)
                    .WithOne(s => s.Department)
                    .HasForeignKey(s => s.DepartmentId);
                    options.HasMany(d => d.Instructors)
                    .WithOne(i => i.Department)
                    .HasForeignKey(i => i.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<StudentCourse>(
                options =>
                {
                    options.HasKey(sc => new { sc.StudentId, sc.CourseId });
                    options.HasOne(sc => sc.Student)
                    .WithMany(s => s.StudentCourses)
                    .HasForeignKey(sc => sc.StudentId);
                    options.HasOne(sc => sc.Course)
                    .WithMany(c => c.StudentCourses)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
