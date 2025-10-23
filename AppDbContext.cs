using Microsoft.EntityFrameworkCore;
using LMS.Models;

namespace LMS
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Introduction to C#",
                    Description = "Basics of C# and .NET",
                    CreatedDate = DateTime.UtcNow.AddDays(-10)
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Advanced ASP.NET Core",
                    Description = "Building Web APIs and middleware",
                    CreatedDate = DateTime.UtcNow.AddDays(-5)
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Entity Framework Core Deep Dive",
                    Description = "EF Core techniques and performance",
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                },
                 new Course
                 {
                     Id = Guid.NewGuid(),
                     Title = "Introduction to C# b",
                     Description = "Basics of C# and .NET",
                     CreatedDate = DateTime.UtcNow.AddDays(-10)
                 },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Advanced ASP.NET Core b",
                    Description = "Building Web APIs and middleware",
                    CreatedDate = DateTime.UtcNow.AddDays(-5)
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    Title = "Entity Framework Core Deep Dive b",
                    Description = "EF Core techniques and performance",
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                }
            );

        }
    }
}
