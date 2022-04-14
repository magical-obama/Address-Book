namespace Address_Book
{
    public partial class Form1 : Form
    {
        ContactList contacts = new ContactList();
        public Form1()
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
                return;
            }
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
    }
}