using Microsoft.EntityFrameworkCore;
using Tasks.Models;
namespace Tasks.DataAccess
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(
                options =>
                {
                    options.HasKey(s => s.Id);
                });
        }
    }
}
