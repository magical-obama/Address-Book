namespace Address_Book
{
    public partial class MainForm : Form
    {
        const string contactsSavePath = "data/addressbook.xml";

        public ContactBook contacts = new ContactBook();
        public MainForm()
        {
            InitializeComponent();
            contacts = XmlManager.ReadContactBook(contactsSavePath);
            UpdatePreviewLables();

            addressListBox.DisplayMember = "Name";
            addressListBox.ValueMember = "Id";
            addressListBox.DataSource = contacts;

            if (addressListBox.Items.Count > 0)
            {
                addressListBox.SelectedIndex = 0;
            }
        }

        private Contact? FindCurrentlySelectedContact()
        {
            if (addressListBox.SelectedItems.Count != 0)
            {
                return contacts.Find((addressListBox.SelectedItem as Contact).Id);
            }
            return null;
        }

        private void addressListBox_DoubleClick(object sender, EventArgs e)
        {
            EditContact();
        }

        private void addressListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListBoxAndButtons();
        }

        private void UpdateListBoxAndButtons()
        {
            if (addressListBox.SelectedItems.Count == 0)
            {
                editContactButton.Enabled = false;
                deleteContactButton.Enabled = false;
                return;
            }
            editContactButton.Enabled = true;
            deleteContactButton.Enabled = true;
            Contact? selectedContact = FindCurrentlySelectedContact();
            if (selectedContact != null)
            {
                UpdatePreviewLables();
            }
        }

        private void UpdatePreviewLables()
        {
            Contact? selectedContact = FindCurrentlySelectedContact();
            if (selectedContact != null)
            {
                nameLabel.Text = selectedContact.Name;
                addressLabel.Text = selectedContact.Address;
                telephoneLabel.Text = selectedContact.TelephoneNumber;
            }
            else if (addressListBox.Items.Count == 0)
            {
                nameLabel.Text = "";
                addressLabel.Text = "";
                telephoneLabel.Text = "";
            }
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    XmlManager.SaveContactBook(contacts, contactsSavePath);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void EditContact()
        {
            Contact? selectedContact = FindCurrentlySelectedContact();
            if (selectedContact == null)
            {
                return;
            }
            using (var form = new EditContactForm(selectedContact))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK && form.hasChanged)
                {
                    var updatedContact = form.updatedContact;
                    contacts.UpdateContact(form.originalId, updatedContact);
                    UpdatePreviewLables();
                    UpdateListBoxAndButtons();
                }
            }
        }

        private void CreateNewContact()
        {
            Contact newContact = new Contact();
            using (var form = new EditContactForm(newContact))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK && form.hasChanged)
                {
                    Contact? updatedContact = form.updatedContact;
                    contacts.Add(updatedContact);
                    UpdatePreviewLables();
                }
            }
        }

        private void addContactButton_Click(object sender, EventArgs e)
        {
            CreateNewContact();
        }

        private void deleteContactButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void DeleteContact()
        {
            if (addressListBox.SelectedItems.Count == 0)
            {
                return;
            }
            Contact? selectedContact = FindCurrentlySelectedContact();
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete " + selectedContact.Name + "?",
                "Delete Contact", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                contacts.Remove(selectedContact.Id);
                UpdatePreviewLables();
            }
        }
    }
}