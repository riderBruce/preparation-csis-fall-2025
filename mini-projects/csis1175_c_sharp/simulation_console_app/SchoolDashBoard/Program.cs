using SchoolDashboard;
using System;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var people = new List<Person>
        {
            new Student("Alice", 20, "Computer Science"),
            new Teacher("Bob", 45, "Mathematics"),
            new Staff("Charlie", 35, "Admin"),
            new Student("Daisy", 22, "Design"),
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new PersonJsonConverter() }
        };

        // Save
        string file = "school_people.json";
        string json = JsonSerializer.Serialize(people, options);
        await File.WriteAllTextAsync(file, json);
        Console.WriteLine($"Saved to {file}");

        // Load
        string loadedJson = await File.ReadAllTextAsync(file);
        var loadedPeople = JsonSerializer.Deserialize<List<Person>>(loadedJson, options);

        Console.WriteLine("\n📋 Loaded People:");
        foreach (var person in loadedPeople)
        {
            Console.WriteLine(person.GetDetails());
        }
    }
}
