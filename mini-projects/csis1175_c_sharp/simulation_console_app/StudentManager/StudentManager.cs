using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    internal class StudentManager
    {
        List<Student> students = new();
        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }
        public void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("There aren't any students.");
                return;
            }
            Console.WriteLine("List of students:");
            foreach (var student in students)
            {
                Console.WriteLine(student.GetDetails());
            }
        }
        public void SearchByName(string name)
        {
            
            var foundStudents = students.Where(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!foundStudents.Any())
            {
                Console.WriteLine($"No students found with the name '{name}'.");
                return;
            }
            Console.WriteLine($"Found {foundStudents.Count} student(s) with the name '{name}':");
            foreach (var student in foundStudents)
            {
                Console.WriteLine(student.GetDetails());
            }
        }
        public void SaveToFile(string filePath = "students.txt")
        {
            try
            {
                using (StreamWriter writer = new(filePath))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine(student.GetDetails());
                    }
                    Console.WriteLine($"Students saved to {filePath} successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to file: {ex.Message}");
            }
        }
        public void LoadFromFile(string filePath = "students.txt")
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File '{filePath}' does not exist.");
                    return;
                }

                students.Clear();
                foreach (string line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length != 3) {
                        Console.WriteLine($"Invalid line format: {line}");
                        continue;
                    }
                    string name = parts[0].Trim();
                    int age = int.TryParse(parts[1].Trim(), out int parsedAge) ? parsedAge : 0;
                    string major = parts[2].Trim();
                    students.Add(new Student(name, age, major));
                }
                Console.WriteLine($"File '{filePath}' successfully loaded.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading from file: {ex.Message}");
            }
        }
    }
}
