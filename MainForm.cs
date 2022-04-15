namespace Address_Book
{
    public partial class MainForm : Form
    {
        public ContactBook contacts = new ContactBook();
        public MainForm()
        {
            InitializeComponent();
            contacts.Add(new Contact("Maximilian Schwärzler", "Hier", "+436704025301"));
            contacts.Add(new Contact("Konstantin Schwärzler", "Auch Hier", "+0123456789"));
            contacts.Add(new Contact("Mami", "Zuhause", "+436641967422"));

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
            if (addressListBox.SelectedItems.Count == 0)
            {
                editContactButton.Enabled = false;
                return;
            }
            editContactButton.Enabled = true;
            System.Diagnostics.Debug.WriteLine(addressListBox.SelectedValue);
            Contact? selectedContact = FindCurrentlySelectedContact();
            if (selectedContact != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedContact);
                UpdatePreviewLables(selectedContact);
            } else
            {
                System.Diagnostics.Debug.WriteLine("Contact is null");
            }
        }

        private void UpdatePreviewLables()
        {
            Contact? selectedContact = FindCurrentlySelectedContact();
            if (selectedContact != null)
            {
                UpdatePreviewLables(selectedContact);
            }
        }

        private void UpdatePreviewLables(Contact contact)
        {
            previewNameLabel.Text = "Name: " + contact.Name;
            previewAddressLabel.Text = "Address: " + contact.Address;
            previewTelephoneLabel.Text = "Telephone: " + contact.TelephoneNumber;
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
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
                    contacts.UpdateContact(form.originalId, updatedContact.Name, updatedContact.Address, updatedContact.TelephoneNumber);
                    UpdatePreviewLables();
                    addressListBox.DataSource = contacts;
                }
            }
        }

        private void addressListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (addressListBox.SelectedItems.Count == 0)
            {
                editContactButton.Enabled = false;
                return;
            }
            editContactButton.Enabled = true;
            Contact? selectedContact = addressListBox.SelectedItem as Contact;
            if (selectedContact != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedContact);
                previewNameLabel.Text = "Name: " + selectedContact.Name;
                previewAddressLabel.Text = "Address: " + selectedContact.Address;
                previewTelephoneLabel.Text = "Telephone: " + selectedContact.TelephoneNumber;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Contact is null");
            }
        }
    }
}