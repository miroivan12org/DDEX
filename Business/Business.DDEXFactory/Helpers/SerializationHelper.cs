using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Business.DDEXFactory.Helpers
{
    public static class SerializationHelper
    {
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
            
        }
        public class MyXmlSerializer : System.Xml.Serialization.XmlSerializer
        {
            public MyXmlSerializer(Type type) : base(type)
            {
            }
            protected override void Serialize(object o, XmlSerializationWriter writer)
            {
                base.Serialize(o, writer);
            }
        }

        public static string Serialize(object value)
        {
            string ret = null;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(value.GetType());
            using (var tw = new Utf8StringWriter())
            {
                x.Serialize(tw, value);
                ret = tw.ToString();
            }

            return ret;
        }

        public static object Deserialize(System.Type type, string value)
        {
            object ret = null;

            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(type);
            
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
