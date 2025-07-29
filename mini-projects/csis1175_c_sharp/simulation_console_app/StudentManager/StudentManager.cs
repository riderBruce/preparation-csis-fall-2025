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
        private Dictionary<string, int> MajorsCount 
            => Majors.ToDictionary(majors => majors,
                                    majors => students.Count(s => s.Major.Equals(majors, StringComparison.OrdinalIgnoreCase)));
        private string MajorsCountString
            => string.Join(", ", MajorsCount.Select(KeyValuePair => $"{KeyValuePair.Key}: {KeyValuePair.Value}"));

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }
        private void DisplayStudentSummary()
        {
            Console.WriteLine($"Total students: {StudentsCount}");
            Console.WriteLine($"Majors: {MajorsString}");
            Console.WriteLine($"Majors count: {MajorsCountString}");
        }
        public void ListStudents()
        {
            Console.WriteLine(new string('-', 40));
            
            if (students.Count == 0)
            {
                Console.WriteLine("There aren't any students.");
                return;
            }
            DisplayStudentSummary();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Select a major to filter students (or press Enter to skip):");
            string selectedMajor = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(selectedMajor) && Majors.Contains(selectedMajor, StringComparer.OrdinalIgnoreCase))
            {

                var normalized = selectedMajor.ToLowerInvariant();
                var filtered = students.Where(s => s.Major.ToLowerInvariant() == normalized).OrderByDescending(s => s.Age).ToList(); ;
                if (filtered.Count == 0)
                {
                    Console.WriteLine($"No students found in the major '{selectedMajor}'.");
                    return;
                }
                Console.WriteLine($"Students in the major '{selectedMajor}':");
                foreach (var student in filtered)
                {
                    Console.WriteLine(student.GetDetails());
                }
                return;
            }
            Console.WriteLine("Listing all students:");
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
