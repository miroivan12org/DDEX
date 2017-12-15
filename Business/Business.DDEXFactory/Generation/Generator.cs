
using System;
using Business.DDEXFactory.Interfaces;
using Business.DDEXFactory.Helpers;

namespace Business.DDEXFactory.Generation
{
    public abstract class Generator: IXmlGenerator
    {
        public virtual string SerializeXmlObject(IXmlObject value)
        {
            //string xml = Helpers.SerializationHelper.Serialize(value, (useTempFile == true ? null : value.FullFileName));
            string xml = SerializationHelper.Serialize(value);
            return xml;
        }

        public abstract bool IsValid(string xmlValue, out string outMessage);

        public abstract IXmlObject DeserializeXmlObject(string value);

        public string LoadXmlFile(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
        }

        public void WriteXmlObjectToFile(string fileName, IXmlObject xmlObject)
        {
            var str = SerializationHelper.Serialize(xmlObject);
            WriteXmlFile(fileName, str);
        }
        public void WriteXmlFile(string fileName, string value)
        {
            System.IO.File.WriteAllText(fileName, value);
        }

        protected IXmlGenerationFactory _Factory = null;
        public IXmlGenerationFactory Factory
        {
            get
            {
                return _Factory;
            }
        }

    }
}
