using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;

namespace Address_Book
{
    [XmlRoot("Contacts")]
    public class ContactBook : BindingList<Contact>, INotifyPropertyChanged
    {
        public ContactBook() { }

        public ContactBook(List<Contact> init)
        {
            foreach (var contact in init)
            {
                this.Add(contact);
                UpdateChanges();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateChanges() {
            NotifyPropertyChanged();
            this.ResetBindings();
        }

        public Contact? Find(string id)
        {
            return this.SingleOrDefault(contact => contact.Id == id);
        }

        public bool Remove(string id)
        {
            Contact? contact = this.Find(id);
            if (contact != null)
            {
                UpdateChanges();
                return this.Remove(contact);
            }
            return false;
        }

        public bool UpdateContact(string id, Contact newContact)
        {
            Contact? oldContact = this.Find(id);
            if (oldContact != null)
            {
                oldContact.Update(newContact.Name, newContact.Address, newContact.TelephoneNumber);
                System.Diagnostics.Debug.WriteLine("Contact updated");
                UpdateChanges();
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var contact in this)
            {
                sb.AppendLine(contact.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
