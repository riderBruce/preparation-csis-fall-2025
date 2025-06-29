using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;

            string contact = $"{name} - {phone} - {email}";
            lstContacts.Items.Add(contact);

            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
