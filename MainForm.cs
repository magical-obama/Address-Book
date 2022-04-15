namespace Address_Book
{
    public partial class MainForm : Form
    {
        public ContactList contacts = new ContactList();
        public MainForm()
        {
            InitializeComponent();
            contacts.Add(new Contact("Maximilian Schwärzler", "Hier", "+436704025301"));
            contacts.Add(new Contact("Konstantin Schwärzler", "Auch Hier", "+0123456789"));
            contacts.Add(new Contact("Mami", "Zuhause", "+436641967422"));

            addressListBox.DataSource = contacts;
            addressListBox.DisplayMember = "Name";
            addressListBox.ValueMember = "Id";

            // contacts.UpdateVisuals(addressListBox);
            if (addressListBox.Items.Count > 0)
            {
                addressListBox.SelectedIndex = 0;
            }
        }

        private void addressListBox_DoubleClick(object sender, EventArgs e)
        {
            if (addressListBox.SelectedItems.Count == 0)
            {
                return;
            }
            string selectedContactName = ((Contact)addressListBox.SelectedItem).Name;
            Contact? selectedContact = contacts.FindContactInList(selectedContactName);
            if (selectedContact != null)
            {

            }
        }

        private void addressListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addressListBox.SelectedItems.Count == 0)
            {
                editContactButton.Enabled = false;
                return;
            }
            editContactButton.Enabled = true;
            Contact? selectedContact = addressListBox.SelectedItem as Contact;
            // Contact? selectedContact = contacts.FindContactInList(selectedContactName);
            if (selectedContact != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedContact);
                previewNameLabel.Text = "Name: " + selectedContact.Name;
                previewAddressLabel.Text = "Address: " + selectedContact.address;
                previewTelephoneLabel.Text = "Telephone: " + selectedContact.telephoneNumber;
            } else
            {
                System.Diagnostics.Debug.WriteLine("Contact is null");
            }
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            Contact? selectedContact = addressListBox.SelectedItem as Contact;
            if (selectedContact == null)
            {
                return;
            }
            using (var form = new EditContactForm(selectedContact, contacts))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK && form.hasChanged)
                {
                    contacts = form.contacts;
                    addressListBox.Update();
                    addressListBox_SelectedIndexChanged(sender, e);
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
            // Contact? selectedContact = contacts.FindContactInList(selectedContactName);
            if (selectedContact != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedContact);
                previewNameLabel.Text = "Name: " + selectedContact.Name;
                previewAddressLabel.Text = "Address: " + selectedContact.address;
                previewTelephoneLabel.Text = "Telephone: " + selectedContact.telephoneNumber;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Contact is null");
            }
        }
    }

    

    public class ContactList : List<Contact>
    {
        public Contact? FindContactInList(string nameOfContact)
        {
            return this.Find(x => x.Name == nameOfContact);
        }

        public static Contact? FindContactInList(List<Contact> contactList, string nameOfContact)
        {
            return contactList.Find(x => x.Name == nameOfContact);
        }

        //public void UpdateVisuals(ListBox listBox)
        //{
        //    listBox.Items.Clear();
        //    foreach (var contact in this)
        //    {
        //        listBox.Items.Add(contact.name);
        //    }
        //}

        //public static void UpdateVisuals(List<Address_Book.Contact> listOfContacts, ListBox listBox)
        //{
        //    listBox.Items.Clear();
        //    foreach (var contact in listOfContacts)
        //    {
        //        listBox.Items.Add(contact.name);
        //    }
        //}

        public bool EditContact(string name, Contact newContact)
        {
            Contact? contact = FindContactInList(name);
            if (contact != null)
            {
                contact.Name = newContact.Name;
                contact.address = newContact.address;
                contact.telephoneNumber = newContact.telephoneNumber;
                return true;
            }
            return false;
        }

        public void AddContact(Contact contact)
        {
            this.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            this.Remove(contact);
        }

        public override string ToString()
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            foreach (var contact in this)
            {
                output.AppendLine(contact.ToString());
            }
            return output.ToString();
        }
    }
}