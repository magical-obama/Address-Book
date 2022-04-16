using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Address_Book
{
    internal static class XmlManager
    {
        public static void SaveContactBook(ContactBook contacts, string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContactBook));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, contacts);
            writer.Close();
        }

        public static ContactBook ReadContactBook(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ContactBook));

            serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
            serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);

            FileStream fileStream;

            try
            {
                fileStream = new FileStream(filename, FileMode.Open);
            }
            catch(FileNotFoundException)
            {
                return new ContactBook();
            }

            ContactBook contacts = serializer.Deserialize(fileStream) as ContactBook;
            if (contacts != null)
            {
                fileStream.Dispose();
                return contacts;
            }
            else
            {
                fileStream.Dispose();
                ContactBook newContacts = new ContactBook();
                XmlManager.SaveContactBook(newContacts, filename);
                return newContacts;
            }

            void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
            {
                Console.WriteLine("Unknown Node:" + e.Name + "\t" + e.Text);
            }

            void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
            {
                System.Xml.XmlAttribute attr = e.Attr;
                Console.WriteLine("Unknown attribute " +
                attr.Name + "='" + attr.Value + "'");
            }
        }
    }
}
