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
       
        public static string Serialize(object dataToSerialize)
        {
            string ret = null;
            try
            {
                using (var stringwriter = new StringWriter())
                {
                    using (var utf8tw = new Utf8XmlTextWriter(stringwriter))
                    {
                        var serializer = new XmlSerializer(dataToSerialize.GetType());
                        utf8tw.Formatting = Formatting.Indented;
                        serializer.Serialize(utf8tw, dataToSerialize);

                        ret = stringwriter.ToString();
                    }
                }                    
            }
            catch
            {
                throw;
            }

            return ret;
        }

        public static T Deserialize<T>(string xmlText)
        {
            T ret;
            try
            {
                using (var stringReader = new System.IO.StringReader(xmlText))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    ret = (T)serializer.Deserialize(stringReader);
                }
            }
            catch
            {
                throw;
            }

            return ret;
        }
    }
}
