
using System;
using Business.DDEXFactory.Interfaces;

namespace Business.DDEXFactory.Generation
{
    public abstract class Generator: IXmlGenerator
    {
        public virtual string SerializeXmlObject(IXmlObject value)
        {
            string xml = Helpers.SerializationHelper.Serialize(value);
            return xml;
        }

        public abstract bool IsValid(string xmlValue, out string outMessage);

        public abstract IXmlObject DeserializeXmlObject(string value);

        public string LoadXmlFile(string fileName)
        {
            return System.IO.File.ReadAllText(fileName);
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
