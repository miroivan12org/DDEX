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
        public class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding { get { return Encoding.UTF8; } }
        }
      
        public static string Serialize(object value)
        {
            string ret = null;

            var x = new XmlSerializer(value.GetType());
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
