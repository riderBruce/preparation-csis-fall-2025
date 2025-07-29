# 📘 Day 4 Plan – Advanced File I/O + LINQ in C\#

## 🗓️ Week 5 – Day 4: Advanced Topics

---

## 🧩 Focus Areas

- Master **LINQ** for searching/filtering data
- Handle **async file reading/writing**
- Add support for **XML format**
- (Optional) Begin **unit testing** file operations

---

## 📦 New Concepts

### 1. LINQ (Language Integrated Query)

- Powerful and elegant for querying collections
- Sample:

```csharp
var adults = students.Where(s => s.Age >= 18).ToList();
```

### 2. Async File I/O

- Use `StreamReader`/`StreamWriter` with `await`

```csharp
using StreamWriter writer = new(filePath);
await writer.WriteLineAsync("Hello async world");
```

### 3. XML Serialization (Bonus)

```csharp
XmlSerializer serializer = new(typeof(List<Student>));
using FileStream fs = new(filePath, FileMode.Create);
serializer.Serialize(fs, students);
```

### 4. Simple Unit Testing

- Start using assertions to test behavior
- Mock input/output or test specific logic methods

---

## 🛠️ Tasks

### ✅ Part 1 – LINQ Practice

- Search by partial name

- Filter students by age or major

- Sort students by name or age

### ✅ Part 2 – Async Save/Load

- Rewrite JSON save/load as async

- Apply await to async methods

### ✅ Part 3 – Add XML Support

- Add export/import to XML

- Use System.Xml.Serialization

- Update enum FileType to include Xml

### ✅ Part 4 – Test Code Structure

- Review main flow

- Check helper methods

- Identify repetitive logic

- Think about StudentValidator helper class (optional)

---

## 🎯 Stretch Goals

- Add CLI parameter support
- Save a backup file before overwrite
- Print summary report (e.g., count by major)

---

## 🧠 Reflection Prompts

- How did LINQ make querying easier?
- How does async improve performance?
- When would XML be better than JSON?
- What makes code testable?

---

## ✨ Let’s Build

Today is about leveling up: smarter queries, faster saves, and cleaner formats. You’re not just coding — you’re building like a pro. 🚀
