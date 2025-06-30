using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (name == "" || phone == "" || email == "")
            {
                MessageBox.Show("Please fill in all fields.", "Input Error");
                return;
            }

            MessageBox.Show($"Contact Added: {name}, {phone}, {email}","Contact Saved");

            string contactInfo = $"{name} | {phone} | {email}";
            lstContacts.Items.Add(contactInfo);

            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtName.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "Search by Name";
            txtSearch.ForeColor = Color.Gray;
        }

        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex != -1)
            {
                lstContacts.Items.RemoveAt(lstContacts.SelectedIndex);
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
                foreach (var item in lstContacts.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }

            MessageBox.Show($"Contacts saved to {filePath}", "Saved Successfully");
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            string filePath = "contacts.txt";

            if (File.Exists(filePath))
            {
                lstContacts.Items.Clear();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    lstContacts.Items.Add(line);
                }

                MessageBox.Show($"Contacts loaded from {filePath}", "Loaded Successfully");

            }
            else
            {
                MessageBox.Show($"File {filePath} does not exist.", "File Not Found");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(query))
            {
                MessageBox.Show("Please enter a name to search.", "Empty Search");
                return;
            }

            foreach (var item in lstContacts.Items)
            {
                if (item.ToString().ToLower().Contains(query))
                {
                    lstContacts.SelectedItem = item;
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

    }
}
