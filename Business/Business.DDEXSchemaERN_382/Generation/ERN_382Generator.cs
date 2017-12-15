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
using System.Diagnostics;

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
            ret = SerializationHelper.Deserialize<NewReleaseMessage>(value);
            
            return ret;
        }

        public override string SerializeXmlObject(IXmlObject value)
        {
            string ret = base.SerializeXmlObject(value);
            
            var doc = new XmlDocument();
            doc.LoadXml(ret);

            NewReleaseMessage nrm = (NewReleaseMessage)value;
            var dat = nrm.MessageHeader.MessageCreatedDateTime;

            string valueToReplace = ret.Substring(ret.IndexOf("<MessageCreatedDateTime>"), ret.IndexOf("</MessageCreatedDateTime>") + "</MessageCreatedDateTime>".Length - ret.IndexOf("<MessageCreatedDateTime>"));
            string newValue = string.Format("<MessageCreatedDateTime>{0}</MessageCreatedDateTime>", DateTime.SpecifyKind(dat, DateTimeKind.Utc).ToString("yyyy-MM-ddTHH:mm:ss") + "+00:00");
            ret = ret.Replace(valueToReplace, newValue);

            ret = ret.Replace(" xmlns=\"\"", "");
            ret = ret.Replace("xmlns=\"\"", "");

            newValue = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<ern:NewReleaseMessage MessageSchemaVersionId=\"ern/382\" ReleaseProfileVersionId=\"CommonReleaseTypesTypes/13/AudioAlbumMusicOnly\" LanguageAndScriptCode=\"en\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:ern=\"http://ddex.net/xml/ern/382\" xs:schemaLocation=\"http://ddex.net/xml/ern/382 http://ddex.net/xml/ern/382/release-notification.xsd\">\n";
            ret = string.Concat(newValue, ret.Substring(ret.IndexOf("<MessageHeader"))).Replace("</NewReleaseMessage>", "</ern:NewReleaseMessage>");

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
