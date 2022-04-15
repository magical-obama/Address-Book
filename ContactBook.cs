using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;

namespace Address_Book
{
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
                return this.Remove(contact);
                UpdateChanges();
            }
            return false;
        }

        public bool UpdateContact(string id, string name, string address, string telephoneNumber)
        {
            Contact? contact = this.Find(id);
            if (contact != null)
            {
                contact.Update(name, address, telephoneNumber);
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
