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
        private List<string> Majors => students.Select(s => s.Major).Distinct().ToList();
        private string MajorsString => string.Join(", ", Majors);
        
        private string MajorsSummary()
        {
            var result = Majors
                .ToDictionary(m => m, m => students.Count(s => s.Major.Equals(m, StringComparison.OrdinalIgnoreCase)))
                .Select(d => $"{d.Key}: {d.Value}")
                .ToList();
            return string.Join(", ", result);
        }
        private string GetMajorsSummaryWithAverageAge()
        {
            var result = students.GroupBy(s => s.Major)
                .Select(g => new
                {
                    Major = g.Key,
                    Count = g.Count(),
                    AverageAge = g.Average(s => s.Age)
                })
                .Select(g => $"{g.Major}: {g.Count} students, Average Age: {g.AverageAge:F2}")
                .ToList();
            return string.Join(", \n", result);
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }
        private void DisplayStudentSummary()
        {
            Console.WriteLine($"Total students: {StudentsCount}");
            Console.WriteLine($"Majors: {MajorsString}");
            Console.WriteLine($"Majors count: {GetMajorsSummaryWithAverageAge()}");
        }
        
        private void DisplayStudents(string prompt, IEnumerable<Student> studentsForDisplay)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(prompt);
            Console.WriteLine(new string('-', 40));
            foreach (var student in studentsForDisplay)
            {
                Console.WriteLine(student.GetDetails());
            }
            Console.WriteLine(new string('-', 40));
        }
        private bool IsValidMajorInput(string input) => 
            !string.IsNullOrWhiteSpace(input) && 
            Majors.Contains(input, StringComparer.OrdinalIgnoreCase);

        private bool IsListEmpty<T>(List<T> list, string prompt)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine(prompt);
                return true;
            }
            return false;
        }
        public void ListStudents()
        {
            Console.WriteLine(new string('-', 40));

            if (IsListEmpty(students, "There arn't any students.")) 
                return;

            DisplayStudentSummary();

            Console.WriteLine($"Select a major to filter students (or press Enter to skip):");
            string selectedMajor = Console.ReadLine()?.Trim();

            if (!IsValidMajorInput(selectedMajor))
            {
                Console.WriteLine("No valid major selected. Press any key to view all students...");
                Console.ReadKey(intercept: true);
                DisplayStudents("List of all student : ", students);
                return;
            }

            var filtered = students
                            .Where(s => string.Equals(selectedMajor, s.Major, StringComparison.OrdinalIgnoreCase))
                            .OrderByDescending(s => s.Age)
                            .ToList();
            if (IsListEmpty(filtered, $"No students found in the major '{selectedMajor}'."))
                return;
            DisplayStudents($"Students in the major '{selectedMajor}'", filtered);
        }
        public void SearchByName(string name)
        {
            var normalized = name.ToLowerInvariant();
            var filteredStudents = students.Where(s => s.Name.ToLowerInvariant() == normalized).ToList();
            if (!filteredStudents.Any())
            {
                Console.WriteLine($"No students found with the name '{name}'.");
                return;
            }
            Console.WriteLine($"Found {filteredStudents.Count} student(s) with the name '{name}':");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.GetDetails());
            }
        }
        public void SaveStudents(FileType fileType, string filePath = "")
        {
            if (string.IsNullOrWhiteSpace(filePath))
                filePath = GetDefaultPath(fileType);

            if (!ValidateSaveConditions(filePath)) return;

            try
            {
                switch (fileType)
                {
                    case FileType.Txt:
                        SaveToFile(filePath, '|');
                        break;
                    case FileType.Csv:
                        SaveToFile(filePath, ',');
                        break;
                    case FileType.Json:
                        SaveToJson(filePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
            Console.WriteLine($"Students saved to {filePath}");
        }
        public void LoadStudents(FileType fileType, string filePath = "")
        {
            if (string.IsNullOrWhiteSpace(filePath))
                filePath = GetDefaultPath(fileType);

            if (!ValidateLoadConditions(filePath)) return;

            try
            {
                switch (fileType)
                {
                    case FileType.Txt:
                        LoadFromFile(filePath, '|');
                        break;
                    case FileType.Csv:
                        LoadFromFile(filePath, ',');
                        break;
                    case FileType.Json:
                        LoadFromJson(filePath);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
            Console.WriteLine($"Students loaded from {filePath}");
        }
        private bool ValidateSaveConditions(string filePath)
        {
            if (students == null || students.Count == 0)
            {
                Console.WriteLine("No students to save.");
                return false;
            }
            if (File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' will be overwritten.");
            }
            return true;
        }
        private bool ValidateLoadConditions(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File '{filePath}' not found.");
                return false;
            }
            return true;
        }
        private string GetDefaultPath(FileType fileType) => fileType switch
        {
            FileType.Txt => "students.txt",
            FileType.Csv => "students.csv",
            FileType.Json => "students.json",
            _ => "students.txt",
        };
        private void SaveToFile(string filePath, char divider)
        {
            using StreamWriter writer = new(filePath);
            foreach (var student in students)
            {
                writer.WriteLine(student.GetDetails(divider));
            }
        }
        private void LoadFromFile(string filePath, char divider)
        {
            students.Clear();
            foreach (string line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(divider);
                if (parts.Length != 3)
                {
                    Console.WriteLine($"Invalid line format: {line}");
                    continue;
                }
                if (parts[0] == "Name" && parts[1] == "Age" && parts[2] == "Major") continue;
                
                students.Add(new Student(parts[0].Trim(),
                                         int.TryParse(parts[1].Trim(), out int parsedAge) ? parsedAge : 0,
                                         parts[2].Trim()));
            }
        }
        private void SaveToJson(string filePath)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        private void LoadFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }
    }
    public enum FileType
    {
        Txt,
        Csv,
        Json,
    }
}
