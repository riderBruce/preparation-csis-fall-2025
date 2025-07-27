# 🧠 Week 5 – Day 3: File I/O & Data Persistence in C\#

## 🌟 Focus

Add the ability to **save, load, and persist student records** using `txt` and `csv` files. Learn how to use `StreamWriter`, `StreamReader`, and file checks to handle student data in your console app.

---

## 💠 Core Concepts to Practice

- Reading from and writing to `.txt` and `.csv` files
- Using `StreamWriter` and `StreamReader`
- Checking if a file exists before reading
- Persisting student data between sessions
- Building robust logic for saving/loading

---

## 📘 Tasks

### 1. 🔧 Add Save Method to `StudentManager`

- Save all student records to `students.txt`
- Format: `Name | Age | Major`

```csharp
public void SaveToFile(string path = "students.txt")
{
    using StreamWriter writer = new(path);
    foreach (var student in students)
    {
        writer.WriteLine($"{student.Name} | {student.Age} | {student.Major}");
    }
    Console.WriteLine("📂 Students saved to file.");
}
```

---

### 2. 📅 Add Load Method

- Read `students.txt`, split each line by `|`, and create Student objects

```csharp
public void LoadFromFile(string path = "students.txt")
{
    if (!File.Exists(path))
    {
        Console.WriteLine("⚠️ File not found.");
        return;
    }

    students.Clear();
    foreach (var line in File.ReadAllLines(path))
    {
        var parts = line.Split('|');
        if (parts.Length == 3)
        {
            string name = parts[0].Trim();
            int age = int.Parse(parts[1]);
            string major = parts[2].Trim();
            students.Add(new Student(name, age, major));
        }
    }
    Console.WriteLine("📅 Students loaded from file.");
}
```

---

### 3. 🧪 Update `Program.cs` with Options

```csharp
Console.WriteLine("5. Save to File");
Console.WriteLine("6. Load from File");
```

And update `switch`:

```csharp
case "5":
    manager.SaveToFile();
    break;

case "6":
    manager.LoadFromFile();
    break;
```

---

## ✅ Stretch Goals

- Add a method to export students to `CSV`
- Use `System.Text.Json` to save/load in JSON format
- Validate file content line-by-line
- Auto-load on program start (optional)

---

## ✍️ Journal Prompt

- What challenges did you face while reading or writing files?

>

- Did you notice any difference between `txt` and `csv` formatting?

>

- How might this persistence layer change if the data was stored in a database?

>

---

## 💬 Git Commit Message

```bash
git commit -m "📂 Add student save/load methods using text files for persistence"
```

---

## 🤯 Nerdy Joke

Why did the student get stuck in a text file?

> Because they didn’t know how to escape! 😱📄

---

## 📦 Deliverables

- Updated `StudentManager.cs` with `SaveToFile()` and `LoadFromFile()`
- Working `Program.cs` console options
- A sample `students.txt` file saved locally
- GitHub commit + reflection

---

## 🎉 You did it!

You’re now persisting data like a real app. Next up — inheritance & polymorphism… but first, make sure your students are safe in a file! 🗂️📄
