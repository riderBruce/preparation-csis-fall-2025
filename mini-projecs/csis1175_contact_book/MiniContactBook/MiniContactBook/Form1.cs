using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.Json;

namespace MiniContactBook
{
    public partial class contact_book : Form
    {
        public contact_book()
        {
            InitializeComponent();
        }

        private int sortColumn = -1;
        private SortOrder sortOrder = SortOrder.Ascending;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextGrey()
        {
            txtSearch.Text = "Search by Name";
            txtSearch.ForeColor = Color.Gray;
        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSearch_TextGrey();
            txtName.Focus(); // Set focus back to the name input field
            lvContacts.SelectedItems.Clear(); // Clear the selection in the ListView
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validate input
            bool isValid = true;

            txtName.BackColor = SystemColors.Window;
            txtPhone.BackColor = SystemColors.Window;

            if (string.IsNullOrWhiteSpace(name))
            {
                txtName.BackColor = Color.MistyRose;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                txtPhone.BackColor = Color.MistyRose;
                isValid = false;
            }
            if (!isValid)
            {
                MessageBox.Show("Name and phone number are required", "Input Error");
                return;
            }


            string contactInfo = $"{name} | {phone} | {email}";


            if (lvContacts.SelectedItems.Count > 0)
            {
                // Update existing contact
                ListViewItem selectedItem = lvContacts.SelectedItems[0];
                selectedItem.SubItems[0].Text = name;
                selectedItem.SubItems[1].Text = phone;
                selectedItem.SubItems[2].Text = email;
                MessageBox.Show($"Contact Updated: {name} | {phone} | {email}", "Contact Updated");
                ClearInputFields();
                return;
            }

            // Set up a new ListViewItem
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(phone);
            item.SubItems.Add(email);

            // Check for duplicate contacts
            bool duplicate = lvContacts.Items.Cast<ListViewItem>()
                .Any(i => i.SubItems[0].Text == name && i.SubItems[1].Text == phone);

            if (duplicate)
            {
                MessageBox.Show("This contact already exists.", "Duplicate Contact");
                return;
            }

            // Add the new contact to the ListView
            lvContacts.Items.Add(item);
            MessageBox.Show($"Contact Added: {name} | {phone} | {email}", "Contact Saved");
            ClearInputFields();

            // Group contacts by first letter after loading
            GroupContactsByFirstLetter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the search text box
            txtSearch_TextGrey();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvContacts.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the seleted contact?", "Confirm Delete", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                {
                    return; // User cancelled the deletion
                }

                lvContacts.Items.Remove(lvContacts.SelectedItems[0]);
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Please select a contact to delete.", "No Selection");
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            string filePath = "contacts.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (ListViewItem item in lvContacts.Items)
                {
                    writer.WriteLine($"{item.SubItems[0].Text} | " +
                                     $"{item.SubItems[1].Text} | " +
                                     $"{item.SubItems[2].Text}");
                }
            }
            MessageBox.Show($"Contacts saved to {filePath}", "Saved Successfully");
            // Clear the input fields after saving
            ClearInputFields();
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            string filePath = "contacts.txt";

            if (File.Exists(filePath))
            {
                lvContacts.Items.Clear();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string name = parts[0].Trim();
                        string phone = parts[1].Trim();
                        string email = parts[2].Trim();
                        ListViewItem item = new ListViewItem(name);
                        item.SubItems.Add(phone);
                        item.SubItems.Add(email);

                        lvContacts.Items.Add(item);
                    }
                }

                MessageBox.Show($"Contacts loaded from {filePath}", "Loaded Successfully");

            }
            else
            {
                MessageBox.Show($"File {filePath} does not exist.", "File Not Found");
            }

            // Clear the input fields after loading
            ClearInputFields();

            // Group contacts by first letter after loading
            GroupContactsByFirstLetter();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a name to search.", "Empty Search");
                return;
            }

            foreach (ListViewItem item in lvContacts.Items)
            {
                if (item.Text.ToLower().Contains(query))
                {
                    item.Selected = true;
                    item.EnsureVisible(); // Scroll to the selected item
                    return;
                }
            }

            MessageBox.Show($"No contact found with the name '{query}'.", "Not Found");

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by Name")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch_TextGrey();
            }
        }

        private void lvContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvContacts.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvContacts.SelectedItems[0];
                txtName.Text = selectedItem.SubItems[0].Text;
                txtPhone.Text = selectedItem.SubItems[1].Text;
                txtEmail.Text = selectedItem.SubItems[2].Text;
            }
        }

        private void lvContacts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                // If the same column is clicked, toggle the sort order
                sortOrder = (sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // If a different column is clicked, sort by that column in ascending order
                sortColumn = e.Column;
                sortOrder = SortOrder.Ascending;
            }

            // Sort the ListView items
            lvContacts.ListViewItemSorter = new ListViewItemComparer(e.Column, sortOrder);
            lvContacts.Sort();
        }

        private void GroupContactsByFirstLetter()
        {
            lvContacts.Groups.Clear();

            // Create groups A-Z
            Dictionary<char, ListViewGroup> groups = new Dictionary<char, ListViewGroup>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                ListViewGroup group = new ListViewGroup(c.ToString(), HorizontalAlignment.Left);
                lvContacts.Groups.Add(group);
                groups[c] = group;
            }
            
            // Assign each item to the correct group
            foreach (ListViewItem item in lvContacts.Items)
            {
                if (!string.IsNullOrWhiteSpace(item.Text))
                {
                    char firstChar = char.ToUpper(item.Text[0]);
                    if (groups.ContainsKey(firstChar))
                    {
                        item.Group = groups[firstChar];
                    }
                    else
                    {
                        // If the first character is not A-Z, assign to a default group
                        item.Group = lvContacts.Groups[0]; // Default to the first group (A)
                    }
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            string filePath = "contacts.csv";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write header
                writer.WriteLine("Name,Phone,Email");
                foreach (ListViewItem item in lvContacts.Items)
                {
                    string name = item.SubItems[0].Text.Replace(",", " ");
                    string phone = item.SubItems[1].Text.Replace(",", " ");
                    string email = item.SubItems[2].Text.Replace(",", " ");
                    writer.WriteLine($"{name},{phone},{email}");
                }
            }
            MessageBox.Show($"Contacts exported to {filePath}", "CSV Exported");
        }

        private void btnExportJSON_Click(object sender, EventArgs e)
        {
            List<Contact> contacts = new List<Contact>();

            foreach (ListViewItem item in lvContacts.Items)
            {
                Contact contact = new Contact
                {
                    Name = item.SubItems[0].Text,
                    Phone = item.SubItems[1].Text,
                    Email = item.SubItems[2].Text
                };
                contacts.Add(contact);
            }

            string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });

            string filePath = "contacts.json";
            File.WriteAllText(filePath, json);

            MessageBox.Show($"Contacts exported to {filePath}", "JSON Exported");
        }

    }

    class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private SortOrder order;
        public ListViewItemComparer(int column, SortOrder sortOrder)
        {
            col = column;
            order = sortOrder;
        }
        public int Compare(object x, object y)
        {
            string xText = ((ListViewItem)x).SubItems[col].Text;
            string yText = ((ListViewItem)y).SubItems[col].Text;

            int result = String.Compare(xText, yText);

            return (order == SortOrder.Ascending) ? result : -result;
        }
    }
    
    public class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}