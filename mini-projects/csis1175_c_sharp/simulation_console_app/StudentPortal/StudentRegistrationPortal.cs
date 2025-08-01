using StudentPortal.Models;
using StudentPortal.Services;

namespace StudentPortal
{
    public class StudentRegistrationPortal
    {
        private readonly StudentRepository repository = new();
        private readonly string filePath = "students.csv";

        public async Task RunAsync()
        {
            await repository.LoadFromFileAsync(filePath);

            while (true)
            {
                ShowMenu();
                string input = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                switch (input)
                {
                    case "1": AddStudent(); break;
                    case "2": ListAll(); break;
                    case "3": SearchStudent(); break;
                    case "4": Stats(); break;
                    case "5": await Save(); break;
                    case "6": await Load(); break;
                    case "7": Console.WriteLine("Goodbye!"); return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\n===== Student Portal =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. List All Students");
            Console.WriteLine("3. Search by Name");
            Console.WriteLine("4. Show Stats");
            Console.WriteLine("5. Save to File");
            Console.WriteLine("6. Load from File");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
        }

        private void AddStudent()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Major: ");
            string major = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Age: ");
            int.TryParse(Console.ReadLine(), out int age);

            var student = new Student(name, major, age);
            repository.Add(student);
            Console.WriteLine("✅ Student added.");
        }

        private void ListAll()
        {
            if (!repository.Students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            Console.WriteLine("\n--- Student List ---");
            foreach (var student in repository.Students)
                Console.WriteLine(student);
        }

        private void SearchStudent()
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            var result = repository.FindByName(name);
            if (result != null)
                Console.WriteLine(result);
            else
                Console.WriteLine("Not found.");
        }

        private void Stats()
        {
            if (!repository.Students.Any())
            {
                Console.WriteLine("No data to analyze.");
                return;
            }

            Console.WriteLine("\n--- Major Stats ---");
            repository.DisplayStats();
        }

        private async Task Save()
        {
            await repository.SaveToFileAsync(filePath);
            Console.WriteLine("✅ Students saved.");
        }

        private async Task Load()
        {
            await repository.LoadFromFileAsync(filePath);
            Console.WriteLine("✅ Students loaded.");
        }
    }
}
