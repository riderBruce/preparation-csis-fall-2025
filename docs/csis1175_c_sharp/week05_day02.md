# 🧠 Week 5 – Day 2: OOP Refresher & Student Manager App

## 🎯 Focus

- Strengthen your understanding of **Classes, Fields, Properties**
- Practice **constructors**, **method overloading**
- Apply **object creation + interaction** through console inputs
- Build a reusable, extensible app to manage students

## 📘 Core Concepts

- Define a `Student` class
- Use **constructor overloading**
- Create `StudentManager` to hold a list of students and methods to manage them
- Use **List<T>**, `ToLower()`, and `.Contains()` for flexible searching

## 🛠️ Step-by-Step Tasks

### 1. Create a `Student` Class

```csharp
public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }

    // Constructor 1
    public Student(string name)
    {
        Name = name;
    }

    // Constructor 2 (overloaded)
    public Student(string name, int age, string major)
    {
        Name = name;
        Age = age;
        Major = major;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"🎓 {Name} | Age: {Age} | Major: {Major}");
    }
}
```

### 2. Create a StudentManager Class

- Add Student
- List All Students
- Search Students by Name

```csharp
public class StudentManager
{
    private List<Student> students = new();

    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine("✅ Student added.");
    }

    public void ListStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n📋 Student List:");
        foreach (var student in students)
        {
            student.DisplayInfo();
        }
    }

    public void SearchByName(string keyword)
    {
        var found = students
            .Where(s => s.Name.ToLower().Contains(keyword.ToLower()))
            .ToList();

        if (!found.Any())
        {
            Console.WriteLine("🔍 No matching student found.");
            return;
        }

        Console.WriteLine("🔍 Search Results:");
        foreach (var s in found)
        {
            s.DisplayInfo();
        }
    }
}

```

### 3. Update Program.cs to Use It All

```csharp
class Program
{
    static void Main()
    {
        StudentManager manager = new();

        while (true)
        {
            Console.WriteLine("\n👨‍🏫 Student Manager");
            Console.WriteLine("1. Add Student (Name Only)");
            Console.WriteLine("2. Add Student (Full Info)");
            Console.WriteLine("3. List All Students");
            Console.WriteLine("4. Search Student by Name");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter name: ");
                    string name1 = Console.ReadLine();
                    manager.AddStudent(new Student(name1));
                    break;

                case "2":
                    Console.Write("Name: ");
                    string name2 = Console.ReadLine();
                    Console.Write("Age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Major: ");
                    string major = Console.ReadLine();
                    manager.AddStudent(new Student(name2, age, major));
                    break;

                case "3":
                    manager.ListStudents();
                    break;

                case "4":
                    Console.Write("Enter name to search: ");
                    manager.SearchByName(Console.ReadLine());
                    break;

                case "5":
                    Console.WriteLine("👋 Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}

```

## 🔧 Tools

- Visual Studio or VS Code
- .NET 6 or higher
- System.Linq

## 📘 Deliverables

- Student.cs
- StudentManager.cs
- Program.cs
- Daily journal/reflection
- GitHub commit after testing

## 🧠 Reflection Prompts (For Later)

- What advantages did constructor overloading give you here?

> The Constructor overloading means that create multiple constructors with the same name but different parameters. It allows for more flexable way that same class can be used with different input. I could create Student instance only with a name easily not with full detailed parameter. It save me time to input many student quickly.

- How did separating logic into StudentManager help your code structure?

> Seperating logic help the code clean and reusable because it is easy to refactor, remove redundant code and turn it into a reusable method if process handling methods are getting together in on place.

- Could this be extended into a GUI or database app?

> We already seperate main logic, operation class and data class. We can turn Student.cs to database, Program.cs to GUI page, and StudentManager to operation logic. I finally know that seperate logic make it easier to expansion and transformation.

## 🧪 Git Commit Message

- git commit -m "🎓 Add Student Manager console app with constructor overloading and search"
