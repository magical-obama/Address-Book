using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Address_Book
{
    public partial class EditContactForm : Form
    {
        Contact originalContact;
        Contact editedContact;
        public bool hasChanged { get; set; }

        ContactList contacts;
        
        public EditContactForm(Contact contactToEdit, ref ContactList contacts)
        {
            InitializeComponent();
            originalContact = contactToEdit;
            this.contacts = contacts;
            this.Text = "Edit Contact \"" + contactToEdit.name + "\"";
            nameTextBox.Text = contactToEdit.name;
            addressTextBox.Text = contactToEdit.address;
            telephoneTextBox.Text = contactToEdit.telephoneNumber;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Contact updatedContact = new Contact(nameTextBox.Text, addressTextBox.Text, telephoneTextBox.Text);
            if (updatedContact == originalContact)
            {
                this.hasChanged = false;
                System.Diagnostics.Debug.WriteLine("No changes made");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.hasChanged = true;
                System.Diagnostics.Debug.WriteLine("Contact has changed");
                contacts.FindContactInList(originalContact.name);
                contacts.RemoveContact(originalContact.name);
                contacts.AddContact(updatedContact);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
