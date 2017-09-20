using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Business.DDEXFactory.Helpers
{
    public static class SerializationHelper
    {
        public class Utf8XmlTextWriter : XmlTextWriter
        {
            public Utf8XmlTextWriter(TextWriter w) : base(w)
            { }
            
        } 
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
      
        public static string Serialize(object value, string fullFileName = null)
        {
            string ret = null;


            //XmlAttributes attrs = new XmlAttributes();
            //XmlAttributeOverrides xOver = new XmlAttributeOverrides();
            //XmlRootAttribute xRoot = new XmlRootAttribute();
            //// Set a new Namespace and ElementName for the root element.
            //xRoot.Namespace = "http://ddex.net/xml/ern/3821";
            //xRoot.IsNullable = false;
            //xRoot.ElementName = "NewReleaseMessage";
            //attrs.XmlRoot = xRoot;

            ////xOver.Add(typeof(NewReleaseMessage), attrs);
            //xOver.Add(value.GetType(), attrs);

            //var x = new XmlSerializer(value.GetType(), xOver);
            var x = new XmlSerializer(value.GetType());

            using (var tw = new Utf8StringWriter())
            {
                using (var xmlw = new Utf8XmlTextWriter(tw))
                {
                    xmlw.Formatting = Formatting.Indented;
                    xmlw.Indentation = 1;

                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;
                    
                    string fileName = fullFileName;
                    if (fullFileName == null)
                    {
                        fileName = Path.GetTempFileName();
                    }

                    using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("xs", "http://www.w3.org/2001/XMLSchema-instance");
                    
                        x.Serialize(writer, value, ns);
                    }
                    ret = File.ReadAllText(fileName);
                    if (fullFileName == null)
                    {
                        File.Delete(fileName);
                    }
                }
            }

            return ret;
        }
        public static object Deserialize(Type type, string value)
        {
            object ret = null;

            var x = new XmlSerializer(type);
            
            using (var sr = new StringReader(value) )
            {
                using (var rdr = XmlReader.Create(sr))
                {
                    ret = x.Deserialize(rdr);
                }                    
            }

            return ret;
        }
    }
}
