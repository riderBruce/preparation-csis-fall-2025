
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagerBranch
{
    public class PersonManager
    {
        private List<Person> people = new();
        public int PeopleCount => people.Count();
        public void AddPerson(Person person)
        {
            people.Add(person);
            Console.WriteLine("Person added.");
        }
        public void ListPeople()
        {
            foreach (var person in people)
            {
                Console.WriteLine(person.GetDetails());
            }
        }
        public async Task SaveToJsonAsync(string filePath = "people.json")
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new PersonConverter() }
            };
            string json = JsonSerializer.Serialize(people, options);
            await File.WriteAllTextAsync(filePath, json);
        }
        public async Task LoadFromJsonAsync(string filePath = "people.json")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            var options = new JsonSerializerOptions
            {
                Converters = { new PersonConverter() }
            };
            string json = await File.ReadAllTextAsync(filePath);
            people = JsonSerializer.Deserialize<List<Person>>(json, options) ?? new();
        }
    }
}
