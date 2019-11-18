using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace braintionary
{
    [Serializable]
    public class Pack
    {
        [XmlElement("Pack")]
        public List<Word> pack = new List<Word>();
    }
}
