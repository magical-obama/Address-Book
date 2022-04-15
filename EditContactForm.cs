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
        Contact contactToEdit;
        public bool hasChanged { get; set; }

        public ContactList contacts { get; set; }

        public EditContactForm(Contact contactToEdit, ContactList originalContacts)
        {
            InitializeComponent();
            this.contactToEdit = contactToEdit;
            this.contacts = originalContacts;
            this.Text = "Edit Contact \"" + contactToEdit.Name + "\"";
            nameTextBox.Text = contactToEdit.Name;
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
            if (updatedContact == contactToEdit)
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
                //contacts.FindContactInList(contactToEdit.Name);
                //contacts.RemoveContact(contactToEdit);
                //contacts.AddContact(updatedContact);
                System.Diagnostics.Debug.WriteLine(contacts.EditContact(contactToEdit.Name, updatedContact));
                System.Diagnostics.Debug.WriteLine("Contacts has been edited");
                System.Diagnostics.Debug.WriteLine(contacts);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
