using ConsoleApp2;
class Program
{
    static void Main()
    {
        ContactManager manager = new();
        while (true)
        {
            Console.WriteLine("\n📒 Mini Contact Book");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Show All Contacts");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Search Contact");
            Console.WriteLine("5. Save to File");
            Console.WriteLine("6. Load from File");
            Console.WriteLine("7. Export to CSV");
            Console.WriteLine("8. Export to JSON");
            Console.WriteLine("9. Exit");
            Console.Write("Choose an option (1–9): ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Phone: ");
                    string phone = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    manager.AddContact(new Contact { Name = name, Phone = phone, Email = email });
                    break;

                case "2":
                    manager.ShowContacts();
                    break;

                case "3":
                    Console.Write("Enter name to delete: ");
                    manager.DeleteContact(Console.ReadLine());
                    break;

                case "4":
                    Console.Write("Enter name to search: ");
                    manager.SearchContact(Console.ReadLine());
                    break;

                case "5":
                    manager.SaveToFile();
                    break;

                case "6":
                    manager.LoadFromFile();
                    break;

                case "7":
                    manager.ExportToCSV();
                    break;

                case "8":
                    manager.ExportToJSON();
                    break;

                case "9":
                    Console.WriteLine("👋 Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
