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
    }
}
