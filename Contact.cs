using System.Text;

namespace Address_Book
{
    public class Contact
    {
        public string Name { get; set; }
        public string Id { get; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }

        public Contact(string name, string address, string telephoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.TelephoneNumber = telephoneNumber;
            this.Id = Guid.NewGuid().ToString();
        }

        public Contact Update(string name, string address, string telephoneNumber)
        {
            this.Name = name;
            this.Address = address;
            this.TelephoneNumber = telephoneNumber;
            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Id: " + this.Id);
            sb.AppendLine("Name: " + this.Name);
            sb.AppendLine("Address: " + this.Address);
            sb.AppendLine("Telephone: " + this.TelephoneNumber);
            return sb.ToString();
        }
    }
}
