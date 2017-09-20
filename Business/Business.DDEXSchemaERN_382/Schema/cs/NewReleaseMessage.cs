using Business.DDEXFactory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Business.DDEXSchemaERN_382.Schema
{
    public partial class NewReleaseMessage : IXmlObject
    {
        [XmlIgnore]
        public string FullFileName { get; set; }

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation { get; set; } = "http://ddex.net/xml/ern/382 http://ddex.net/xml/ern/382/release-notification.xsd";
    }
}
