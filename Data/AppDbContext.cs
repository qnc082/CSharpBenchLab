using CSharpBenchLab.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpBenchLab.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public static AppDbContext CreateWithSeedData()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("EmployeeDb")
                .Options;

            var context = new AppDbContext(options);

            // Ensure database is created and seed data if empty
            context.Database.EnsureCreated();
            if (!context.Employees.Any())
            {
                var employees = MockDataGenerator.GenerateEmployees(10_000);
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }

            return context;
        }
    }
}