using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class ContactBook : List<Contact>
    {
        public ContactBook(List<Contact> init)
        {
            this.AddRange(init);
        }
        
        public Contact? Find(string id)
        {
            return this.Find(c => c.Id == id);
        }

        public bool Remove(string id)
        {
            var contact = this.Find(id);
            if (contact != null)
            {
                return this.Remove(contact);
            }
            return false;
        }

        public bool UpdateContact(string id, Contact newContact)
        {
            var oldContact = this.Find(id);
            if (oldContact != null)
            {
                oldContact.Name = newContact.Name;
                oldContact.address = newContact.address;
                oldContact.telephoneNumber = newContact.telephoneNumber;
                return true;
            }
            return false;
        }
    }
}
