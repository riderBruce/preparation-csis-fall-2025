using StudentManagerBranch;
public class Program
{
    public static async Task Main(string[] args)
    {
        StudentManager manager = new();

        while (true)
        {
            Console.WriteLine($"\n{new string('-', 40)}");
            Console.WriteLine("Welcome to the Student Manager!");
            if (manager.StudentsCount == 0)
            {
                await manager.LoadStudents(FileType.Txt);
            }
            Console.WriteLine($"Current number of students: {manager.StudentsCount}");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Student Manager Menu:");
            Console.WriteLine("1. Add a student just with a name.");
            Console.WriteLine("2. Add a student with a name, an age, and a major.");
            Console.WriteLine("3. List all students.");
            Console.WriteLine("4. Search for a student by name.");
            Console.WriteLine("5. Save students to file.");
            Console.WriteLine("6. Load students to file.");
            Console.WriteLine("7. Exit.");
            Console.WriteLine(new string('-', 40)); 
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
                        string fileTypes = string.Join("/", Enum.GetNames(typeof(FileType)));
                        Console.Write($"Choose file type to save ({fileTypes}): ");
                        string input = Console.ReadLine();
                        if (Enum.TryParse<FileType>(input, true, out FileType fileType))
                        {
                            await manager.SaveStudents(fileType);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid file type. Please enter {fileTypes}.");
                        }
                        break;
                    }

                case "6":
                    {
                        string fileTypes = string.Join("/", Enum.GetNames(typeof(FileType)));
                        Console.Write($"Choose file type to load ({fileTypes}): ");
                        string input = Console.ReadLine();
                        if (Enum.TryParse<FileType>(input, true, out FileType fileType))
                        {
                            await manager.LoadStudents(fileType);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid file type. Please enter {fileTypes}.");
                        }
                        break;
                    }

                case "7":
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