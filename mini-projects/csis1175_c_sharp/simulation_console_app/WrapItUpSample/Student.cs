using System;
using System.Linq;

namespace LINQWith2DArray
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }

        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;
            Major = major;
        }

        public string GetDetails() => $"Name: {Name} | Age: {Age} | Major: {Major}";
    }

    class Program
    {
        static void Main()
        {
            Student[,] studentGrid = new Student[2, 2]
            {
                {
                    new Student("Alice", 20, "Math"),
                    new Student("Bob", 22, "Physics")
                },
                {
                    new Student("Charlie", 21, "Math"),
                    new Student("Diana", 23, "Biology")
                }
            };

            // 🌈 Convert to LINQ-friendly flat IEnumerable<Student>
            var allStudents = studentGrid.Cast<Student>();

            // 🔍 Find all Math majors, order by age
            var mathStudents = allStudents
                .Where(s => s.Major == "Math")
                .OrderBy(s => s.Age)
                .ToList();

            Console.WriteLine("🎓 Math Students:");
            foreach (var s in mathStudents)
                Console.WriteLine(s.GetDetails());

            // 📊 Group by Major
            var grouped = allStudents
                .GroupBy(s => s.Major)
                .Select(g => new
                {
                    Major = g.Key,
                    Count = g.Count(),
                    AvgAge = g.Average(s => s.Age)
                });

            Console.WriteLine("\n📊 Summary by Major:");
            foreach (var g in grouped)
                Console.WriteLine($"{g.Major}: {g.Count} students, Avg Age: {g.AvgAge:F1}");
        }
    }
}
