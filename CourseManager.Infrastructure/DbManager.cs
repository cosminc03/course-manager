using Microsoft.EntityFrameworkCore;
using CourseManager.Core.Models;

namespace CourseManager.Infrastructure
{
    public class DbManager : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Seminar> Seminaries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=CourseManager;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student-Course Many-to-Many
            modelBuilder.Entity<StudentCourse>()
                .HasKey(t => new { t.StudentId, t.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Student)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(t => t.StudentCourses)
                .HasForeignKey(pt => pt.CourseId);

            //Course-Employee Many-to-Many
            modelBuilder.Entity<CourseEmployee>()
                .HasKey(t => new { t.CourseId, t.EmployeeId});

            modelBuilder.Entity<CourseEmployee>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseEmployees)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseEmployee>()
                .HasOne(pt => pt.Employee)
                .WithMany(t => t.CourseEmployees)
                .HasForeignKey(pt => pt.EmployeeId);
        }
    }
}
