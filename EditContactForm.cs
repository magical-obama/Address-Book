namespace Address_Book
{
    public partial class EditContactForm : Form
    {
        public Contact contactToEdit;
        public bool hasChanged { get; set; }
        public Contact? updatedContact { get; set; }
        public string originalId { get; set; }

        public EditContactForm(Contact contactToEdit)
        {
            InitializeComponent();
            this.contactToEdit = contactToEdit;
            this.originalId = contactToEdit.Id;
            if (contactToEdit.Name == "" || contactToEdit.Name == null)
            {
                this.Text = "Create New Contact";
            }
            else
            {
                this.Text = "Edit Contact \"" + contactToEdit.Name + "\"";
            }
            nameTextBox.Text = contactToEdit.Name;
            addressTextBox.Text = contactToEdit.Address;
            telephoneTextBox.Text = contactToEdit.TelephoneNumber;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (
                nameTextBox.Text == contactToEdit.Name && 
                addressTextBox.Text == contactToEdit.Address && 
                telephoneTextBox.Text == contactToEdit.TelephoneNumber)
            {
                this.DialogResult = DialogResult.OK;
                this.hasChanged = false;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.hasChanged = true;
                this.updatedContact = new Contact();
                updatedContact.Name = nameTextBox.Text;
                updatedContact.Address = addressTextBox.Text;
                updatedContact.TelephoneNumber = telephoneTextBox.Text;
                this.Close();
            }
        }
    }
}
