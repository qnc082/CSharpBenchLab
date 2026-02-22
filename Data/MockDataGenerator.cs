using Bogus;
using CSharpBenchLab.Data.Models;

namespace CSharpBenchLab.Data
{
    public static class MockDataGenerator
    {
        private static readonly string[] Departments = new[]
        {
            "Engineering", "Sales", "Marketing", "HR", "Finance", "Support", "IT"
        };

        public static List<Employee> GenerateEmployees(int count)
        {
            var id = 1;
            var faker = new Faker<Employee>()
                .RuleFor(e => e.Id, f => id++)
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.Department, f => f.PickRandom(Departments))
                .RuleFor(e => e.Salary, f => Math.Round(f.Random.Decimal(40000, 150000), 2))
                .RuleFor(e => e.DateHired, f => f.Date.Past(15, DateTime.Today.AddDays(-30)));

            return faker.Generate(count);
        }
    }
}