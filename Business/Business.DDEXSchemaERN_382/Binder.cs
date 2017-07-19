using System.Linq;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using Business.DDEXFactory.Interfaces;
using System;

namespace Business.DDEXSchemaERN_382
{
    public class Binder
    {
        IXmlGenerator Generator { get; set; }
        IXmlGenerationFactory Factory { get; set; }
        
        public Binder()
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

        public IXmlObject GetXmlObjectFromModel(IBindableModel model)
        {
            NewReleaseMessage ret;
            AudioAlbumModel m = (AudioAlbumModel)model;
            
            ret = new NewReleaseMessage()
            {
                ReleaseProfileVersionId = "CommonReleaseTypesTypes/13/AudioAlbumMusicOnly",
                LanguageAndScriptCode = "en",
                MessageSchemaVersionId = "ern/382",
                IsBackfill = false,
                IsBackfillSpecified = true
            };
            
            if (ret.MessageHeader == null)
            {
                ret.MessageHeader = new MessageHeader();
            }

            ret.MessageHeader.MessageId = m.MessageID;
            ret.MessageHeader.MessageThreadId = m.MessageID;
            if (ret.MessageHeader.MessageSender == null)
            {
                ret.MessageHeader.MessageSender = new MessagingParty();
            }
            if (ret.MessageHeader.MessageSender.PartyId == null)
            {
                PartyId[] senderIDs = { new PartyId() };
                ret.MessageHeader.MessageSender.PartyId = senderIDs;
            }
            ret.MessageHeader.MessageSender.PartyId[0].Value = m.SenderPartyID;

            if (ret.MessageHeader.MessageSender.PartyName == null)
            {
                ret.MessageHeader.MessageSender.PartyName = new PartyName();
            }
            if (ret.MessageHeader.MessageSender.PartyName.FullName == null)
            {
                ret.MessageHeader.MessageSender.PartyName.FullName = new Name();
            }
            ret.MessageHeader.MessageSender.PartyName.FullName.Value = m.SenderPartyName;

            if (ret.MessageHeader.MessageRecipient == null)
            {
                var o = new MessagingParty();
                MessagingParty[] messageRecipient = { o };
                ret.MessageHeader.MessageRecipient = messageRecipient;
            }
            if (ret.MessageHeader.MessageRecipient[0].PartyId == null)
            {
                PartyId[] recipientIDs = { new PartyId() };
                ret.MessageHeader.MessageRecipient[0].PartyId = recipientIDs;
            }

            ret.MessageHeader.MessageRecipient[0].PartyId[0].Value = m.RecipientPartyID;

            if (ret.MessageHeader.MessageRecipient[0].PartyName == null)
            {
                ret.MessageHeader.MessageRecipient[0].PartyName = new PartyName();
            }
            if (ret.MessageHeader.MessageRecipient[0].PartyName.FullName == null)
            {
                ret.MessageHeader.MessageRecipient[0].PartyName.FullName = new Name();
            }

            ret.MessageHeader.MessageRecipient[0].PartyName.FullName.Value = m.RecipientPartyName;
            ret.MessageHeader.MessageCreatedDateTime = new DateTime(m.MessageCreatedDateTime.Ticks, DateTimeKind.Local);

            ret.UpdateIndicator = m.UpdateIndicator;
            ret.UpdateIndicatorSpecified = true;

            if (ret.ReleaseList == null)
            {
                ret.ReleaseList = new ReleaseList();
            }
            if (ret.ReleaseList.Release == null || ret.ReleaseList.Release.Length == 0)
            {
                ret.ReleaseList.Release = new Release[1];
                ret.ReleaseList.Release[0] = new Release();
            }
            if (ret.ReleaseList.Release[0].ReleaseId == null || ret.ReleaseList.Release[0].ReleaseId.Length == 0)
            {
                ret.ReleaseList.Release[0].ReleaseId = new ReleaseId[1];
                ret.ReleaseList.Release[0].ReleaseId[0] = new ReleaseId();
            }
            if (ret.ReleaseList.Release[0].ReleaseId[0].ICPN == null)
            {
                ret.ReleaseList.Release[0].ReleaseId[0].ICPN = new ICPN();
            }
            ret.ReleaseList.Release[0].ReleaseId[0].ICPN.IsEan = true;
            ret.ReleaseList.Release[0].ReleaseId[0].ICPN.IsEanSpecified = true;
            ret.ReleaseList.Release[0].ReleaseId[0].ICPN.Value = m.EAN;

            //Ordinal = Convert.ToInt32(rel.ReleaseReference.FirstOrDefault().TrimStart('R')),
            //                    ISRC = rel.ReleaseId.FirstOrDefault().ISRC,
            //                    Title = rel.ReferenceTitle.TitleText.Value,
            //                    Genre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText.Value,
            //                    SubGenre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre.Value

            if (m.Tracks.Any())
            {
                if (ret.ReleaseList == null)
                {
                    ret.ReleaseList = new ReleaseList();
                }
                if (ret.ReleaseList.Release == null)
                {
                    ret.ReleaseList.Release = new Release[m.Tracks.Count];
                }
                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    var track = m.Tracks[i];
                    if (ret.ReleaseList.Release.Length <= (i + 1))
                    {
                        var x = ret.ReleaseList.Release;
                        Array.Resize(ref x, i + 2);
                        ret.ReleaseList.Release = x;
                        ret.ReleaseList.Release[i + 1] = new Release();
                    }
                    var rel = ret.ReleaseList.Release[i+1];
                    if (rel.ReleaseReference == null || rel.ReleaseReference.Length == 0) rel.ReleaseReference = new string[1];
                    rel.ReleaseReference[0] = "R" + track.Ordinal;
                    if (rel.ReleaseId == null || rel.ReleaseId.Length == 0) rel.ReleaseId = new ReleaseId[1];
                    if (rel.ReleaseId[0] == null) rel.ReleaseId[0] = new ReleaseId();
                    rel.ReleaseId[0].ISRC = track.ISRC;
                    if (rel.ReferenceTitle == null) rel.ReferenceTitle = new ReferenceTitle();
                    if (rel.ReferenceTitle.TitleText == null) rel.ReferenceTitle.TitleText = new TitleText();
                    rel.ReferenceTitle.TitleText.Value = track.Title;
                    if (rel.ReleaseDetailsByTerritory == null || rel.ReleaseDetailsByTerritory.Length == 0) rel.ReleaseDetailsByTerritory = new ReleaseDetailsByTerritory[1];
                    if (rel.ReleaseDetailsByTerritory[0] == null) rel.ReleaseDetailsByTerritory[0] = new ReleaseDetailsByTerritory();
                    if (rel.ReleaseDetailsByTerritory[0].Genre == null || rel.ReleaseDetailsByTerritory[0].Genre.Length == 0) rel.ReleaseDetailsByTerritory[0].Genre = new Genre[1];
                    if (rel.ReleaseDetailsByTerritory[0].Genre[0] == null) rel.ReleaseDetailsByTerritory[0].Genre[0] = new Genre();
                    if (rel.ReleaseDetailsByTerritory[0].Genre[0].GenreText == null) rel.ReleaseDetailsByTerritory[0].Genre[0].GenreText = new Description();
                    rel.ReleaseDetailsByTerritory[0].Genre[0].GenreText.Value = track.Genre;
                    if (rel.ReleaseDetailsByTerritory[0].Genre[0].SubGenre == null) rel.ReleaseDetailsByTerritory[0].Genre[0].SubGenre = new Description();
                    rel.ReleaseDetailsByTerritory[0].Genre[0].SubGenre.Value = track.SubGenre;
                }
                // TODO - tracks zapisati u soundrecordings
            }
            return ret;
        }

        public IBindableModel GetModelFromXmlObject(IXmlObject xmlObject)
        {
            AudioAlbumModel ret = new AudioAlbumModel();
            ret.FullFileName = xmlObject.FullFileName;

            NewReleaseMessage nrm = (NewReleaseMessage)xmlObject;
            if (nrm != null)
            {
                if (nrm.MessageHeader != null)
                {
                    ret.MessageID = nrm.MessageHeader.MessageId;
                    if (nrm.MessageHeader.MessageSender.PartyId.Length > 0)
                    {
                        ret.SenderPartyID = nrm.MessageHeader.MessageSender.PartyId[0].Value;
                    }
                    if (nrm.MessageHeader.MessageSender.PartyName != null && nrm.MessageHeader.MessageSender.PartyName.FullName != null)
                    {
                        ret.SenderPartyName = nrm.MessageHeader.MessageSender.PartyName.FullName.Value;
                    }
                    if (nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0].PartyId != null && nrm.MessageHeader.MessageRecipient[0].PartyId.Length > 0)
                    {
                        ret.RecipientPartyID = nrm.MessageHeader.MessageRecipient[0].PartyId[0].Value;
                    }
                    if (nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0].PartyName != null && nrm.MessageHeader.MessageRecipient[0].PartyName.FullName != null)
                    {
                        ret.RecipientPartyName = nrm.MessageHeader.MessageRecipient[0].PartyName.FullName.Value;
                    }
                    ret.MessageCreatedDateTime = nrm.MessageHeader.MessageCreatedDateTime;
                    ret.UpdateIndicator = nrm.UpdateIndicator;

                    if (nrm.ReleaseList != null && nrm.ReleaseList.Release != null && nrm.ReleaseList.Release.Length > 0 && nrm.ReleaseList.Release[0].ReleaseId != null && nrm.ReleaseList.Release[0].ReleaseId.Length > 0 && nrm.ReleaseList.Release[0].ReleaseId[0].ICPN != null)
                    {
                        ret.EAN = nrm.ReleaseList.Release[0].ReleaseId[0].ICPN.Value;
                    }

                    if (nrm.ReleaseList != null && nrm.ReleaseList.Release != null && nrm.ReleaseList.Release.Any())
                    {
                        ret.Tracks.RaiseListChangedEvents = false;
                        foreach (var rel in nrm.ReleaseList.Release.Where(x => !x.IsMainRelease))
                        {
                            var track = new TrackModel()
                            {
                                Ordinal = Convert.ToInt32(rel.ReleaseReference.FirstOrDefault().TrimStart('R')),
                                ISRC = rel.ReleaseId.FirstOrDefault().ISRC,
                                Title = rel.ReferenceTitle.TitleText.Value
                            };
                            if (rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText != null)
                            {
                                track.Genre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText.Value;
                            }
                            if (rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre != null)
                            {
                                track.SubGenre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre.Value;
                            }
                            
                            ret.Tracks.Add(track);
                        }
                        ret.Tracks.RaiseListChangedEvents = true;
                        ret.Tracks.ResetBindings();
                    }
                }
            }

            return ret;
        }

    }
}
