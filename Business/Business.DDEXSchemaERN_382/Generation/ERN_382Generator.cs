using System;
using Business.DDEXFactory.Interfaces;
using Business.DDEXFactory.Helpers;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using Business.DDEXFactory.Generation;
using Business.DDEXSchemaERN_382.Schema;
using System.Reflection;

namespace Business.DDEXSchemaERN_382.Generation
{
    public class ERN_382Generator : Generator
    {
        public ERN_382Generator(IXmlGenerationFactory factory)
        {
            _Factory = factory;
        }

        public override IXmlObject DeserializeXmlObject(string value)
        {
            IXmlObject ret = null;
            ret = (IXmlObject)SerializationHelper.Deserialize(typeof(NewReleaseMessage), value);

            return ret;
        }

        private static Assembly _CurrentAssembly = Assembly.GetExecutingAssembly();
        public static Assembly CurrentAssembly
        {
            get
            {
                return _CurrentAssembly;
            }
        }

        public override bool IsValid(string value, out string outMessage)
        {
            bool ret = true;
            
            XmlSchemaSet schemas = new XmlSchemaSet();

            string xsdEmbeddedResourceName = null;
            string xsdMarkup = null;

            xsdEmbeddedResourceName = "Business.DDEXSchemaERN_382.Schema.xsd.release-notification.xsd";
            xsdMarkup = ReflectionHelper.ReadEmbeddedResource(ERN_382Generator.CurrentAssembly, xsdEmbeddedResourceName);
            schemas.Add("http://ddex.net/xml/ern/382", XmlReader.Create(new StringReader(xsdMarkup)));

            xsdEmbeddedResourceName = "Business.DDEXSchemaERN_382.Schema.xsd.avs.xsd";
            xsdMarkup = ReflectionHelper.ReadEmbeddedResource(ERN_382Generator.CurrentAssembly, xsdEmbeddedResourceName);
            schemas.Add("http://ddex.net/xml/avs/avs", XmlReader.Create(new StringReader(xsdMarkup)));

            outMessage = "";

            var rdr = new StringReader(value);

            XDocument doc = XDocument.Load(rdr, LoadOptions.None);
            string msg = "";
            doc.Validate(schemas, (o, e) => {
                msg += e.Message + Environment.NewLine;
            });

            ret = (msg == "" ? true : false);

            outMessage = msg;

            return ret;
        }
    }
}
