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

            contacts.CreateVisuals(addressListBox);
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
            string selectedContactName = addressListBox.SelectedItem.ToString();
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
            string selectedContactName = addressListBox.SelectedItem.ToString();
            Contact? selectedContact = contacts.FindContactInList(selectedContactName);
            if (selectedContact != null)
            {
                System.Diagnostics.Debug.WriteLine(selectedContact);
                previewNameLabel.Text = "Name: " + selectedContact.name;
                previewAddressLabel.Text = "Address: " + selectedContact.address;
                previewTelephoneLabel.Text = "Telephone: " + selectedContact.telephoneNumber;
            } else
            {
                System.Diagnostics.Debug.WriteLine("Contact is null");
            }
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            Contact selectedContact = contacts.FindContactInList(addressListBox.SelectedItem.ToString());
            using (var form = new EditContactForm(selectedContact, ref contacts))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK && form.hasChanged)
                {
                    contacts.CreateVisuals(addressListBox);
                }
            }
        }
    }

    public class Contact
    {
        public string name;
        public string address;
        public string telephoneNumber;

        public Contact(string name, string address, string telephoneNumber)
        {
            this.name = name;
            this.address = address;
            this.telephoneNumber = telephoneNumber;
        }

        public override string ToString()
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            foreach (var field in this.GetType().GetFields())
            {
                output.AppendLine(field.Name + ": " + field.GetValue(this));
            }
            return output.ToString();
        }
    }

    public class ContactList : List<Contact>
    {
        public Contact? FindContactInList(string nameOfContact)
        {
            return this.Find(x => x.name == nameOfContact);
        }

        public static Contact? FindContactInList(List<Contact> contactList, string nameOfContact)
        {
            return contactList.Find(x => x.name == nameOfContact);
        }

        public void CreateVisuals(ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var contact in this)
            {
                listBox.Items.Add(contact.name);
            }
        }

        public static void CreateVisuals(List<Address_Book.Contact> listOfContacts, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var contact in listOfContacts)
            {
                listBox.Items.Add(contact.name);
            }
        }

        public void EditContact(string name, Contact newContact)
        {
            Contact? contact = FindContactInList(name);
            if (contact != null)
            {
                contact = newContact;
            }
        }

        public void AddContact(Contact contact)
        {
            this.Add(contact);
        }

        public void RemoveContact(string name)
        {
            Contact? contact = FindContactInList(name);
            if (contact != null)
            {
                this.Remove(contact);
            }
        }
    }
}