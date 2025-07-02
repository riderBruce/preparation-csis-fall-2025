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

namespace MiniContactBook
{
    public partial class contact_book : Form
    {
        public contact_book()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ClearInputFields()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSearch.Text = "Search by Name";
            txtSearch.ForeColor = Color.Gray;
            txtName.Focus(); // Set focus back to the name input field
            // lstContacts.ClearSelected(); // Clear the selection in the list box
            lvContacts.SelectedItems.Clear(); // Clear the selection in the ListView
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (name == "" || phone == "")
            {
                // Validate input
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

            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(phone);
            item.SubItems.Add(email);

            bool duplicate = lvContacts.Items.Cast<ListViewItem>()
                .Any(i => i.SubItems[0].Text == name && i.SubItems[1].Text == phone);



            if (duplicate)
            {
                // Check for duplicates
                MessageBox.Show("This contact already exists.", "Duplicate Contact");
                return;
            }

            lvContacts.Items.Add(item);


            MessageBox.Show($"Contact Added: {name} | {phone} | {email}", "Contact Saved");
            ClearInputFields();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the search text box
            txtSearch.Text = "Search by Name";
            txtSearch.ForeColor = Color.Gray;
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
                    writer.WriteLine($"{item.SubItems[0].Text} | {item.SubItems[1].Text} | {item.SubItems[2].Text}");
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
                txtSearch.Text = "Search by Name";
                txtSearch.ForeColor = Color.Gray;
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
    }
}
