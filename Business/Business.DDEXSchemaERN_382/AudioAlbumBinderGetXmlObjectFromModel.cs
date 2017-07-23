using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DDEXSchemaERN_382
{
    public partial class AudioAlbumBinder
    {
        private NewReleaseMessage GetNewReleaseMessage(AudioAlbumModel m)
        {
            NewReleaseMessage ret = null;

            ret = new NewReleaseMessage()
            {
                ReleaseProfileVersionId = "CommonReleaseTypesTypes/13/AudioAlbumMusicOnly",
                LanguageAndScriptCode = "en",
                MessageSchemaVersionId = "ern/382",
                IsBackfill = false,
                IsBackfillSpecified = true
            };

            ret.UpdateIndicator = m.UpdateIndicator;
            ret.UpdateIndicatorSpecified = true;

            ret.MessageHeader = GetMessageHeader(m);
            ret.ResourceList = GetResourceList(m);

            return ret;
        }
        private MessageHeader GetMessageHeader(AudioAlbumModel m)
        {
            MessageHeader ret = null;

            ret = new MessageHeader();

            ret.MessageId = m.MessageID;
            ret.MessageThreadId = m.MessageID;

            if (m.SenderPartyID != null || m.SenderPartyName != null)
            {
                ret.MessageSender = new MessagingParty();
                if (m.SenderPartyID != null)
                {
                    ret.MessageSender.PartyId = new PartyId[1];
                    ret.MessageSender.PartyId[0] = new PartyId();
                    ret.MessageSender.PartyId[0].Value = m.SenderPartyID;
                }
                if (m.SenderPartyName != null)
                {
                    ret.MessageSender.PartyName = new PartyName();
                    ret.MessageSender.PartyName.FullName = new Name();
                    ret.MessageSender.PartyName.FullName.Value = m.SenderPartyName;
                }
            }
            if (m.RecipientPartyID != null || m.RecipientPartyName != null)
            {
                ret.MessageRecipient = new MessagingParty[1];
                ret.MessageRecipient[0] = new MessagingParty();
                if (m.RecipientPartyID != null)
                {
                    ret.MessageRecipient[0].PartyId = new PartyId[1];
                    ret.MessageRecipient[0].PartyId[0] = new PartyId() { Value = m.RecipientPartyID };
                }
                if (m.RecipientPartyName != null)
                {
                    ret.MessageRecipient[0].PartyName = new PartyName() { FullName = new Name() { Value = m.RecipientPartyName } };
                }
            }
                        
            ret.MessageCreatedDateTime = new DateTime(m.MessageCreatedDateTime.Ticks, DateTimeKind.Local);
            
            return ret;
        }
        private ReleaseList GetReleaseList(AudioAlbumModel m)
        {
            ReleaseList ret = null;
            
            

            return ret;
        }
        private Release GetMainRelease(AudioAlbumModel m)
        {
            Release ret = null; 

            return ret;
        }

        private ResourceList GetResourceList(AudioAlbumModel m)
        {
            ResourceList ret = null;

            ret = new ResourceList();
            ret.Image = GetFrontCoverImage(m);
            ret.SoundRecording = GetSoundRecording(m);
            
            return ret;
        }
        private SoundRecording[] GetSoundRecording(AudioAlbumModel m)
        {
            SoundRecording[] ret = null;

            if (m.Tracks != null && m.Tracks.Count > 0)
            {
                ret = new SoundRecording[m.Tracks.Count];
            }

            return ret;
        }
        private Image[] GetFrontCoverImage(AudioAlbumModel m)
        {
            Image[] ret = null;

            if (m.FrontCoverImageFileName != null || m.FrontCoverImagePath != null)
            {
                ret = new Image[1];
                ret[0] = new Image();
                ret[0].ImageId = new ResourceProprietaryId[1];
                ret[0].ImageType = new ImageType1() {  Value = ImageType.FrontCoverImage };
                ret[0].ImageId[0] = new ResourceProprietaryId() { ProprietaryId = new ProprietaryId[0] };
                ret[0].ImageId[0].ProprietaryId = new ProprietaryId[1];
                ret[0].ImageId[0].ProprietaryId[0] = new ProprietaryId() { Value = m.EAN + "_COVERART", Namespace = "DPID:" + m.SenderPartyID };

                ret[0].ImageDetailsByTerritory = new ImageDetailsByTerritory[1];
                ret[0].ImageDetailsByTerritory[0] = new ImageDetailsByTerritory();
                ret[0].ImageDetailsByTerritory[0].Items = new CurrentTerritoryCode[1];
                ret[0].ImageDetailsByTerritory[0].Items[0] = new CurrentTerritoryCode() { Value = "Worldwide" };

                int imageOrdinal = 1;
                if (m.Tracks != null && m.Tracks.Any())
                {
                    imageOrdinal = m.Tracks.Count + 1;
                }
                ret[0].ResourceReference = "A" + imageOrdinal.ToString();

                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails = new TechnicalImageDetails[1];
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0] = new TechnicalImageDetails();
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0].ImageCodecType = new ImageCodecType1() { Value = m.FrontCoverImageCodecType };
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0].ImageHeight = new Extent() { Value = m.FrontCoverImageHeight_Materialized };
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0].ImageWidth = new Extent() { Value = m.FrontCoverImageWidth_Materialized};
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0].Items = new File[1];
                ret[0].ImageDetailsByTerritory[0].TechnicalImageDetails[0].Items[0] = new File() {
                    HashSum = new HashSum() { HashSum1 = m.FrontCoverImageHashSum_Materialized, HashSumAlgorithmType = new HashSumAlgorithmType1() {  Value = HashSumAlgorithmType.MD5 } }
                    , Items = new string[] { m.FrontCoverImageFileName, m.FrontCoverImagePath }
                    , ItemsElementName = new ItemsChoiceType6[] {  ItemsChoiceType6.FileName, ItemsChoiceType6.FilePath }
                };
            }

            return ret;
        }

        public IXmlObject GetXmlObjectFromModel(IBindableModel model)
        {
            NewReleaseMessage nrm;
            AudioAlbumModel m = (AudioAlbumModel)model;

            nrm = GetNewReleaseMessage(m);
            
            if (nrm.ReleaseList == null)
            {
                nrm.ReleaseList = new ReleaseList();
            }
            if (nrm.ReleaseList.Release == null || nrm.ReleaseList.Release.Length == 0)
            {
                nrm.ReleaseList.Release = new Release[1];
                nrm.ReleaseList.Release[0] = new Release();
            }
            // main release
            nrm.ReleaseList.Release[0].IsMainRelease = true;
            nrm.ReleaseList.Release[0].IsMainReleaseSpecified = true;

            if (nrm.ReleaseList.Release[0].ReleaseId == null || nrm.ReleaseList.Release[0].ReleaseId.Length == 0)
            {
                nrm.ReleaseList.Release[0].ReleaseId = new ReleaseId[1];
                nrm.ReleaseList.Release[0].ReleaseId[0] = new ReleaseId();
            }

            if (nrm.ReleaseList.Release[0].ReleaseId[0].ICPN == null)
            {
                nrm.ReleaseList.Release[0].ReleaseId[0].ICPN = new ICPN();
            }
            nrm.ReleaseList.Release[0].ReleaseId[0].ICPN.IsEan = true;
            nrm.ReleaseList.Release[0].ReleaseId[0].ICPN.IsEanSpecified = true;
            nrm.ReleaseList.Release[0].ReleaseId[0].ICPN.Value = m.EAN;
                        
            if (m.Tracks.Any())
            {

                if (nrm.ReleaseList.Release.Count() < m.Tracks.Count + 1)
                {
                    var newRel = new Release[m.Tracks.Count + 1];
                    newRel[0] = nrm.ReleaseList.Release[0];
                    nrm.ReleaseList.Release = newRel;
                }

                Release mainRelease = nrm.ReleaseList.Release[0];
                if (mainRelease.Item == null) mainRelease.Item = new ReleaseResourceReferenceList();
                if (((ReleaseResourceReferenceList)mainRelease.Item).ReleaseResourceReference == null) ((ReleaseResourceReferenceList)mainRelease.Item).ReleaseResourceReference = new ReleaseResourceReference[m.Tracks.Count + 1];
                for (int i = 0; i < m.Tracks.Count + 1; i++)
                {
                    ((ReleaseResourceReferenceList)mainRelease.Item).ReleaseResourceReference[i] = new ReleaseResourceReference()
                    {
                        Value = "A" + (i + 1).ToString(),
                        ReleaseResourceType = ReleaseResourceType.PrimaryResource,
                        ReleaseResourceTypeSpecified = true
                    };
                    if (i == m.Tracks.Count + 1) ((ReleaseResourceReferenceList)mainRelease.Item).ReleaseResourceReference[i].ReleaseResourceType = ReleaseResourceType.SecondaryResource;
                }
                mainRelease.ReleaseType = new ReleaseType1[1];
                mainRelease.ReleaseType[0].Value = ReleaseType.Album;

                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    var track = m.Tracks[i];

                    if (nrm.ReleaseList.Release.Length <= (i + 1))
                    {
                        var x = nrm.ReleaseList.Release;
                        Array.Resize(ref x, i + 2);
                        nrm.ReleaseList.Release = x;
                        nrm.ReleaseList.Release[i + 1] = new Release();
                    }
                    var rel = nrm.ReleaseList.Release[i + 1];
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
            return nrm;
        }
    }
}
