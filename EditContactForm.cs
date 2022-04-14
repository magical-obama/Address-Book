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
        public Contact originalContact { get; set; }
        public Contact editedContact { get; set; }
        public bool hasChanged { get; set; }
        
        public EditContactForm(Contact contactToEdit)
        {
            InitializeComponent();
            originalContact = contactToEdit;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.hasChanged = true;
                this.editedContact = updatedContact;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
