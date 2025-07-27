using StudentManagerBranch;
public class Program
{
    public static void Main(string[] args)
    {
        StudentManager manager = new();

        while (true)
        {
            Console.WriteLine($"\n{new string('-', 20)}");
            Console.WriteLine("Student Manager Menu:");
            Console.WriteLine("1. Add a student just with a name.");
            Console.WriteLine("2. Add a student with a name, an age, and a major.");
            Console.WriteLine("3. List all students.");
            Console.WriteLine("4. Search for a student by name.");
            Console.WriteLine("5. Save students to file.");
            Console.WriteLine("6. Load students from file.");
            Console.WriteLine("7. Exit.");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter the student's name: ");
                    string name1 = Console.ReadLine();
                    manager.AddStudent(new Student(name1));
                    break;

                case "2":
                    Console.Write("Enter the student's name: ");
                    string name2 = Console.ReadLine();
                    Console.Write("Enter the student's age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter the student's major: ");
                    string major = Console.ReadLine();
                    manager.AddStudent(new Student(name2, age, major));
                    break;

                case "3":
                    manager.ListStudents();
                    break;

                case "4":
                    Console.Write("Enter the name of the student to search: ");
                    string name3 = Console.ReadLine();
                    manager.SearchByName(name3);
                    break;

                case "5":
                    Console.Write("Enter the file path to save students (default: students.txt): ");
                    string filePathSave = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(filePathSave))
                    {
                        filePathSave = "students.txt";
                    }
                    manager.SaveToFile(filePathSave);
                    break;

                case "6":
                    Console.Write("Enter the file path to load students (default: students.txt): ");
                    string filePathLoad = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(filePathLoad))
                    {
                        filePathLoad = "students.txt";
                    }
                    manager.LoadFromFile(filePathLoad);
                    break;

                case "7":
                    Console.WriteLine("Exiting the program.");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }


    }
}