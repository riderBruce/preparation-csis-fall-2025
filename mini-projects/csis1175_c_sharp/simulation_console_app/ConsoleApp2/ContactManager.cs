using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp2
{
    internal class ContactManager
    {
        private List<Contact> contacts = new();

        public void AddContact(Contact contact)
        {
            if (contacts.Any(c => c.Name == contact.Name && c.Phone == contact.Phone))
            {
                Console.WriteLine("Contact already exists.");
                return;
            }
            contacts.Add(contact);
            Console.WriteLine("✅ Contact added.");
        }

        public void ShowContacts()
        {
            if (!contacts.Any())
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            Console.WriteLine("\n📋 Contact List:");
            foreach (var c in contacts)
            {
                Console.WriteLine($"- {c.Name} | {c.Phone} | {c.Email}");
            }
        }

        public void DeleteContact(string name)
        {
            var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }
            contacts.Remove(contact);
            Console.WriteLine("🗑️ Contact deleted.");
        }

        public void SearchContact(string name)
        {
            var found = contacts
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            if (!found.Any())
            {
                Console.WriteLine("🔍 No matching contact found.");
                return;
            }

            Console.WriteLine("\n🔍 Search Results:");
            foreach (var c in found)
            {
                Console.WriteLine($"- {c.Name} | {c.Phone} | {c.Email}");
            }
        }

        public void SaveToFile(string path = "contacts.txt")
        {
            using StreamWriter writer = new(path);
            foreach (var c in contacts)
            {
                writer.WriteLine($"{c.Name} | {c.Phone} | {c.Email}");
            }
            Console.WriteLine("💾 Contacts saved.");
        }

        public void LoadFromFile(string path = "contacts.txt")
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found.");
                return;
            }

            contacts.Clear();
            foreach (var line in File.ReadAllLines(path))
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    contacts.Add(new Contact
                    {
                        Name = parts[0].Trim(),
                        Phone = parts[1].Trim(),
                        Email = parts[2].Trim()
                    });
                }
            }
            Console.WriteLine("📥 Contacts loaded.");
        }

        public void ExportToCSV(string path = "contacts.csv")
        {
            using StreamWriter writer = new(path);
            writer.WriteLine("Name,Phone,Email");
            foreach (var c in contacts)
            {
                writer.WriteLine($"{c.Name},{c.Phone},{c.Email}");
            }
            Console.WriteLine("📤 Contacts exported to CSV.");
        }

        public void ExportToJSON(string path = "contacts.json")
        {
            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
            Console.WriteLine("📤 Contacts exported to JSON.");
        }
    }

}
