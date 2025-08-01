using StudentManagerBranch.Models;
using StudentManagerBranch.Services;

class Program
{
    static async Task Main(string[] args)
    {
        PeopleManager manager = new();
        await manager.LoadPeopleAsync(); // from JSON

        manager.DisplayDashboard();

        await manager.SavePeopleAsync(); // to JSON
    }
}
