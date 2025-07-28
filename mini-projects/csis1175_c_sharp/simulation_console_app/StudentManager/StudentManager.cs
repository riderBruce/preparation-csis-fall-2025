using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    internal class StudentManager
    {
        List<Student> students = new();
        public int StudentsCount => students.Count;
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
        public void SaveToTxtFile(string filePath = "students.txt", char divider = '|')
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = "students.txt";
            }
            if (File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' already exists. It will be overwritten.");
            }
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students to save.");
                return;
            }

            try
            {
                using StreamWriter writer = new(filePath);
                foreach (var student in students)
                {
                    writer.WriteLine(student.GetDetails(divider));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to file: {ex.Message}");
            }
            Console.WriteLine($"Students saved to {filePath} successfully.");
        }
        public void LoadFromTxtFile(string filePath = "students.txt", char divider = '|')
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = "students.txt";
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }
            students.Clear();
            try
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split(divider);
                    if (parts.Length != 3)
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                        continue;
                    }
                    string name = parts[0].Trim();
                    int age = int.TryParse(parts[1].Trim(), out int parsedAge) ? parsedAge : 0;
                    string major = parts[2].Trim();
                    students.Add(new Student(name, age, major));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading from file: {ex.Message}");
            }
            Console.WriteLine($"File '{filePath}' successfully loaded.");
        }
        public void SaveToCsvFile(string filePath = "students.csv", char divider = ',')
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = "students.csv";
            }
            if (File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' already exists. It will be overwritten.");
            }
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students to save.");
                return;
            }

            try
            {
                using StreamWriter writer = new(filePath);
                writer.WriteLine($"Name{divider}Age{divider}Major");
                foreach (var student in students)
                {
                    writer.WriteLine(student.GetDetails(divider));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to file: {ex.Message}");
            }
            Console.WriteLine($"Students saved to {filePath} successfully.");
        }
        public void LoadFromCsvFile(string filePath = "students.csv", char divider = ',')
        {
            if (string.IsNullOrWhiteSpace(filePath)) {
                filePath = "students.csv";
            }
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }
            students.Clear();
            try
            {
                foreach (string line in File.ReadAllLines(filePath).Skip(1))
                {
                    var parts = line.Split(divider);
                    if (parts.Length != 3)
                    {
                        Console.WriteLine($"Invalid line format: {line}");
                        continue;
                    }
                    string name = parts[0].Trim();
                    int age = int.TryParse(parts[1].Trim(), out int parsedAge) ? parsedAge : 0;
                    string major = parts[2].Trim();
                    students.Add(new Student(name, age, major));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while loading from file: {ex.Message}");
            }
            Console.WriteLine($"Students loaded from {filePath} successfully.");
        }
        public void ExportToJson(string filePath = "students.json")
        {
            try
            {
                string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while exporting to JSON: {ex.Message}");
            }
            Console.WriteLine($"Students exported to {filePath} successfully.");
        }
        public void ImportFromJson(string filePath = "students.json")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' does not exist.");
                return;
            }
            try
            {
                string json = File.ReadAllText(filePath);
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while importing from JSON: {ex.Message}");
            }
            Console.WriteLine($"File '{filePath}' successfully imported.");
        }        
    }
}
