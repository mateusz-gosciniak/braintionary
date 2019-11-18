using System;
using System.IO;
using System.Xml.Serialization;

namespace braintionary
{
    public class XmlMaker<T>
    {
        private XmlSerializer xmlSerializer;

        public XmlMaker()
        {
            xmlSerializer = new XmlSerializer(typeof(T));
        }

        public void Save(T item, string path)
        {
            using (var fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, item);
            }
        }

        public T Read(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                return (T)Convert.ChangeType(xmlSerializer.Deserialize(fs), typeof(T));
            }
        }
    }
}
