using StudentManagerBranch;
public class Program
{
    public static void Main(string[] args)
    {
        StudentManager manager = new();

        while (true)
        {
            Console.WriteLine($"\n{new string('-', 20)}");
            Console.WriteLine("Welcome to the Student Manager!");
            manager.ImportFromJson("students.json");
            Console.WriteLine($"Current number of students: {manager.StudentsCount}");
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Student Manager Menu:");
            Console.WriteLine("1. Add a student just with a name.");
            Console.WriteLine("2. Add a student with a name, an age, and a major.");
            Console.WriteLine("3. List all students.");
            Console.WriteLine("4. Search for a student by name.");
            Console.WriteLine("5. Save students to txt file.");
            Console.WriteLine("6. Load students from txt file.");
            Console.WriteLine("7. Save students to csv file.");
            Console.WriteLine("8. Load students from csv file.");
            Console.WriteLine("9. Save students to json file.");
            Console.WriteLine("10. Load students from json file.");
            Console.WriteLine("11. Exit.");
            Console.Write("Choose an option: ");


            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        Console.Write("Enter the student's name: ");
                        string name = Console.ReadLine();
                        manager.AddStudent(new Student(name));
                        break;
                    }

                case "2":
                    {
                        Console.Write("Enter the student's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the student's age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter the student's major: ");
                        string major = Console.ReadLine();
                        manager.AddStudent(new Student(name, age, major));
                        break;
                    }

                case "3":
                    {
                        manager.ListStudents();
                        break;
                    }

                case "4":
                    {
                        Console.Write("Enter the name of the student to search: ");
                        string name = Console.ReadLine();
                        manager.SearchByName(name);
                        break;
                    }

                case "5":
                    {
                        string prompt = "Enter the file path to save students (default: students.txt): ";
                        string defaultValue = "students.txt";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.SaveToTxtFile(filePath);
                        break;
                    }

                case "6":
                    {
                        string prompt = "Enter the file path to load students (default: students.txt): ";
                        string defaultValue = "students.txt";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.LoadFromTxtFile(filePath);
                        break;
                    }


                case "7":
                    {
                        string prompt = "Enter the file path to save students (default: students.csv): ";
                        string defaultValue = "students.csv";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.SaveToCsvFile(filePath);
                        break;
                    }


                case "8":
                    {
                        string prompt = "Enter the file path to load students (default: students.csv): ";
                        string defaultValue = "students.csv";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.LoadFromCsvFile(filePath);
                        break;
                    }


                case "9":
                    {
                        string prompt = "Enter the file path to save students (default: students.json): ";
                        string defaultValue = "students.json";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.ExportToJson(filePath);
                        break;
                    }


                case "10":
                    {
                        string prompt = "Enter the file path to load students (default: students.json): ";
                        string defaultValue = "students.json";
                        string filePath = ReadOrDefault(prompt, defaultValue);
                        manager.ImportFromJson(filePath);
                        break;
                    }
                case "11":
                    {
                        Console.WriteLine("Exiting the program.");
                        return;
                    }

                default:
                    {
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                    }
            }
        }
    }
    public static string ReadOrDefault(string prompt, string defaultValue)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
    }
}