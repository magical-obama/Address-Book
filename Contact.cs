using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    public class Contact
    {
        public string Name { get; set; }
        public string Id { get; }

        public string address;
        public string telephoneNumber;

        public Contact(string name, string address, string telephoneNumber)
        {
            this.Name = name;
            this.address = address;
            this.telephoneNumber = telephoneNumber;
            this.Id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            System.Text.StringBuilder output = new System.Text.StringBuilder();
            output.AppendLine("Id: " + this.Id);
            output.AppendLine("Name: " + this.Name);
            output.AppendLine("Address: " + this.address);
            output.AppendLine("Telephone: " + this.telephoneNumber);
            return output.ToString();
        }
    }
}
