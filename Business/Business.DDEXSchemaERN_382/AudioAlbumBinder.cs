using System.Linq;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using Business.DDEXFactory.Interfaces;
using System;

namespace Business.DDEXSchemaERN_382
{
    public partial class AudioAlbumBinder
    {
        IXmlGenerator Generator { get; set; }
        IXmlGenerationFactory Factory { get; set; }
        
        public AudioAlbumBinder()
        {
            Factory = new Generation.ERN_382GenerationFactory();
            Generator = Factory.GetGenerator();
        }

        public bool IsFileValid(string fileName, out string message)
        {
            string xmlValue = Generator.LoadXmlFile(fileName);
            return Generator.IsValid(xmlValue, out message);
        }

        public bool IsModelValid(IBindableModel model, out string message)
        {
            bool isValid = true;

            var xmlObject = GetXmlObjectFromModel(model);
            var str = Generator.SerializeXmlObject(xmlObject);
            isValid = Generator.IsValid(str, out message);

            return isValid;
        }

        public void WriteXmlObjectToFile(IXmlObject xmlObject, string fileName)
        {
            IXmlGenerator gen = Factory.GetGenerator();

            var str = gen.SerializeXmlObject(xmlObject);
            gen.WriteXmlFile(fileName, str);
            System.IO.File.WriteAllText(fileName, str);
        }

        public IXmlObject GetXmlObjectFromFile(string fileName)
        {
            string str = Generator.LoadXmlFile(fileName);

            var ret = Generator.DeserializeXmlObject(str);
            ret.FullFileName = fileName;

            return ret;
        }
    }
}
