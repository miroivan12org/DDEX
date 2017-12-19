using System.Linq;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using Business.DDEXFactory.Interfaces;
using System;

namespace Business.DDEXSchemaERN_382
{
    public partial class AudioAlbumBinder
    {
        public class AudioAlbumBinderSettings
        {
            public string DeezerPartyID { get; set; }
            public string PandoraPartyID { get; set; }
            public string SoundCloudPartyID { get; set; }
        }

        IXmlGenerator Generator { get; set; }
        IXmlGenerationFactory Factory { get; set; }
        AudioAlbumBinderSettings Settings { get; set; }
        private AudioAlbumBinder()
        {
            Factory = new Generation.ERN_382GenerationFactory();
            Generator = Factory.GetGenerator();
        }

        private string SerializeXmlObject(IXmlObject xmlObject, AudioAlbumModel m)
        {
            IXmlGenerator gen = Factory.GetGenerator();
            string ret = gen.SerializeXmlObject(xmlObject);

            m.MusicService = GetModelMusicService(m.RecipientPartyID);
            if (m.MusicService == AudioAlbumModel.eMusicService.SoundCloud)
            {
                string newValue = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<ern:NewReleaseMessage MessageSchemaVersionId=\"ern/382\" BusinessProfileVersionId=\"CommonDealTypes/13/RightsClaimsOnUserGeneratedContent\" LanguageAndScriptCode=\"en\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:ern=\"http://ddex.net/xml/ern/382\" xs:schemaLocation=\"http://ddex.net/xml/ern/382 http://ddex.net/xml/ern/382/release-notification.xsd\">\n";
                ret = string.Concat(newValue, ret.Substring(ret.IndexOf("<MessageHeader"))).Replace("</NewReleaseMessage>", "</ern:NewReleaseMessage>");
            }

            return ret;
        }

        public AudioAlbumBinder(AudioAlbumBinderSettings settings) : this()
        {
            Settings = settings;
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
            string str = SerializeXmlObject(xmlObject, (AudioAlbumModel) model);

            isValid = Generator.IsValid(str, out message);

            return isValid;
        }

        public void WriteXmlObjectToFile(IXmlObject xmlObject, AudioAlbumModel m)
        {
            IXmlGenerator gen = Factory.GetGenerator();
            string str = SerializeXmlObject(xmlObject, m);
            gen.WriteXmlFile(xmlObject.FullFileName, str);
        }

        public IXmlGenerator GetGenerator()
        {
            return Generator;
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
