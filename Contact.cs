using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Address_Book
{
    [XmlRoot]
    public class Contact
    {
        [XmlAttribute]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }

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
