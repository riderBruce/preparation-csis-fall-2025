# 🧠 Week 5 – Day 3: File I/O & Data Persistence in C# (Refactored with `enum` and Clean Practices)

## 🌟 Focus

Refactor file save/load logic with **enum FileType**, reduce repetitive code, and improve maintainability. You’ll apply clean coding practices including helper methods, better parameter handling, and structured file operations.

---

## 💡 New Concept Introduced

### `enum FileType`

```csharp
public enum FileType
{
    Txt,
    Csv,
    Json
}
```

Use this to cleanly pass file format options.

---

## 🔧 Refactored Methods in `StudentManager`

### 1. 📥 Generalized Save Method

```csharp
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
    Console.WriteLine($"✅ Students saved to {filePath}");
}
```

---

### 2. 📤 Generalized Load Method

```csharp
public void LoadStudents(FileType fileType, string filePath = "")
{
    if (string.IsNullOrWhiteSpace(filePath))
        filePath = GetDefaultPath(fileType);

    if (!File.Exists(filePath))
    {
        Console.WriteLine($"❌ File '{filePath}' not found.");
        return;
    }

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
    Console.WriteLine($"📂 Students loaded from {filePath}");
}
```

---

### 3. 🧹 Extracted Helper Methods

```csharp
private bool ValidateSaveConditions(string filePath)
{
    if (students == null || students.Count == 0)
    {
        Console.WriteLine("⚠️ No students to save.");
        return false;
    }
    if (File.Exists(filePath))
    {
        Console.WriteLine($"⚠️ File '{filePath}' will be overwritten.");
    }
    return true;
}

private string GetDefaultPath(FileType type) => type switch
{
    FileType.Txt => "students.txt",
    FileType.Csv => "students.csv",
    FileType.Json => "students.json",
    _ => "students.txt"
};
```

---

### 4. ✍️ File I/O Logic (Internally Called by `SaveStudents`)

```csharp
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
    foreach (var line in File.ReadAllLines(filePath))
    {
        var parts = line.Split(divider);
        if (parts.Length != 3) continue;
        students.Add(new Student(parts[0].Trim(),
                                  int.TryParse(parts[1].Trim(), out int age) ? age : 0,
                                  parts[2].Trim()));
    }
}

private void SaveToJson(string filePath)
{
    var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(filePath, json);
}

private void LoadFromJson(string filePath)
{
    string json = File.ReadAllText(filePath);
    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
}
```

---

## 🔁 Updated `Program.cs` Usage

```csharp
// Example
manager.SaveStudents(FileType.Csv);
manager.LoadStudents(FileType.Json);
```

If you want user choice:

```csharp
Console.Write("Choose file type (txt/csv/json): ");
string input = Console.ReadLine();
if (Enum.TryParse<FileType>(input, true, out FileType fileType))
{
    manager.SaveStudents(fileType);
}
else
{
    Console.WriteLine("Invalid file type entered.");
}
```

---

## 🎉 You’ve Got This!

Now your student manager is smarter, cleaner, and easier to scale. Keep refactoring, and always keep enums close to your heart 💖.
