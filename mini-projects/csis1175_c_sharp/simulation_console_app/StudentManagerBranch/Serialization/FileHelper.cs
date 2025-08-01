using System.Text.Json;
using StudentManagerBranch.Models;

namespace StudentManagerBranch.Serialization
{
    public static class FileHelper
    {
        private static readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            Converters = { new PersonConverter() }
        };

        public static async Task SaveToJsonAsync(List<Person> people, string filePath)
        {
            string json = JsonSerializer.Serialize(people, options);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task<List<Person>> LoadFromJsonAsync(string filePath)
        {
            if (!File.Exists(filePath)) return new();

            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<Person>>(json, options);
        }
    }
}
