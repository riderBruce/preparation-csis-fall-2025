namespace MiniContactBook
{
    partial class contact_book
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLable = new System.Windows.Forms.Label();
            this.PhoneLable = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // NameLable
            // 
            this.NameLable.AutoSize = true;
            this.NameLable.Location = new System.Drawing.Point(45, 49);
            this.NameLable.Name = "NameLable";
            this.NameLable.Size = new System.Drawing.Size(55, 18);
            this.NameLable.TabIndex = 0;
            this.NameLable.Text = "Name";
            this.NameLable.Click += new System.EventHandler(this.label1_Click);
            // 
            // PhoneLable
            // 
            this.PhoneLable.AutoSize = true;
            this.PhoneLable.Location = new System.Drawing.Point(45, 110);
            this.PhoneLable.Name = "PhoneLable";
            this.PhoneLable.Size = new System.Drawing.Size(60, 18);
            this.PhoneLable.TabIndex = 1;
            this.PhoneLable.Text = "Phone";
            this.PhoneLable.Click += new System.EventHandler(this.label2_Click);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(45, 175);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(50, 18);
            this.EmailLabel.TabIndex = 2;
            this.EmailLabel.Text = "Email";
            this.EmailLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(159, 49);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(183, 28);
            this.txtName.TabIndex = 3;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(159, 110);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(183, 28);
            this.txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(159, 175);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(183, 28);
            this.txtEmail.TabIndex = 3;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(48, 241);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(294, 104);
            this.btnAddContact.TabIndex = 4;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // lstContacts
            // 
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.ItemHeight = 18;
            this.lstContacts.Location = new System.Drawing.Point(382, 49);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(383, 310);
            this.lstContacts.TabIndex = 5;
            // 
            // contact_book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.lstContacts);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.PhoneLable);
            this.Controls.Add(this.NameLable);
            this.Name = "contact_book";
            this.Text = "Contact Book";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLable;
        private System.Windows.Forms.Label PhoneLable;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.ListBox lstContacts;
    }
}

