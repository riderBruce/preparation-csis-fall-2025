using StudentManagerBranch.Models;
using StudentManagerBranch.Serialization;

namespace StudentManagerBranch.Services
{
    public class PeopleManager
    {
        private List<Person> people = new();
        private const string JsonPath = "people.json";

        public async Task LoadPeopleAsync()
        {
            people = await FileHelper.LoadFromJsonAsync(JsonPath) ?? new();
            Console.WriteLine("Data loaded!");
        }

        public async Task SavePeopleAsync()
        {
            await FileHelper.SaveToJsonAsync(people, JsonPath);
            Console.WriteLine("Data saved!");
        }

        public void DisplayDashboard()
        {
            Console.WriteLine("=== People Dashboard ===");
            foreach (var person in people)
            {
                Console.WriteLine(person.GetDetails());
            }
        }
    }
}
