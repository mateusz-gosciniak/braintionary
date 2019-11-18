using System.Xml.Serialization;

namespace braintionary
{
    public class Word
    {
        [XmlElement("Name1")]
        public string name1 { get; set; }
        [XmlElement("Name2")]
        public string name2 { get; set; }

        public void Add(string name1_, string name2_)
        {
            name1 = name1_;
            name2 = name2_;
        }
    }
}
