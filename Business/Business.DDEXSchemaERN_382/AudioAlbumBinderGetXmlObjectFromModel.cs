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
            ret.ReleaseList = GetReleaseList(m);

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

            Release mainRelease = GetMainRelease(m);
            int releaseListCount = (mainRelease == null ? 0 : 1) + m.Tracks.Count; ;
            if (releaseListCount > 0)
            {
                ret = new ReleaseList() { Release = new Release[releaseListCount] };
                if (mainRelease != null) ret.Release[0] = mainRelease;

                for (int i = 0; i < m.Tracks.Count; i++)
                {
            
                }
            }
         
            return ret;
        }

        private ReleaseDetailsByTerritory[] GetMainReleaseDetailsByTerritory(AudioAlbumModel m)
        {
            ReleaseDetailsByTerritory[] ret = null;

            ret = new ReleaseDetailsByTerritory[]
            {
                new ReleaseDetailsByTerritory()
                {
                    Items = new CurrentTerritoryCode[]
                    {
                        new CurrentTerritoryCode()
                        {
                            Value = "Worldwide"
                        }
                    },
                    ItemsElementName = new ItemsChoiceType15[] {  ItemsChoiceType15.TerritoryCode },
                    ParentalWarningType = new ParentalWarningType1[]
                    {
                        new ParentalWarningType1()
                        {
                            Value = ParentalWarningType.NotExplicit
                        }
                    }
                }
            };

            ReleaseDetailsByTerritory det = ret[0];

            if (m.Tracks.Count > 0)
            {
                det.ResourceGroup = new ResourceGroup[]
                {
                        new ResourceGroup()
                        {
                            Title = new Title[]
                            {
                                new Title()
                                {
                                    TitleType = TitleType.GroupingTitle,
                                    TitleText = new TitleText()
                                    {
                                        Value = "Component 1"
                                    }
                                }
                            },
                            SequenceNumber = "1"
                        }
                };

                if (!string.IsNullOrWhiteSpace(m.FrontCoverImageFullFileName))
                {
                    det.ResourceGroup[0].Items = new object[]
                    {
                            new ExtendedResourceGroupContentItem()
                            {
                                ReleaseResourceReference = new ReleaseResourceReference()
                                {
                                    ReleaseResourceType = ReleaseResourceType.SecondaryResource,
                                    ReleaseResourceTypeSpecified = true,
                                    Value = "A" + m.Tracks.Count.ToString()
                                },
                                ResourceType = new ResourceType1[]
                                {
                                    new ResourceType1()
                                    {
                                        Value = ResourceType.Image
                                    }
                                }
                            }
                    };
                }
                det.ResourceGroup[0].ResourceGroup1 = new ResourceGroup[]
                {
                        new ResourceGroup()
                        {
                            Items = new object[m.Tracks.Count]
                        }
                };
                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    det.ResourceGroup[0].ResourceGroup1[0].Items[i] = new ExtendedResourceGroupContentItem
                    {
                        ReleaseResourceReference = new ReleaseResourceReference()
                        {
                            ReleaseResourceType = ReleaseResourceType.PrimaryResource,
                            ReleaseResourceTypeSpecified = true,
                            Value = "A" + (i + 1).ToString()
                        },
                        SequenceNumber = (i + 1).ToString()
                    };
                }
            }

            if (!string.IsNullOrWhiteSpace(m.Genre) || !string.IsNullOrWhiteSpace(m.SubGenre))
            {
                det.Genre = new Genre[]
                {
                        new Genre()
                        {
                             GenreText = new Description() {  Value = m.Genre },
                             SubGenre = new Description() { Value = m.SubGenre }
                        }
                };
            }

            if (!string.IsNullOrWhiteSpace(m.LabelName))
            {
                det.LabelName = new LabelName[]
                {
                        new LabelName() {  Value = m.LabelName }
                };
            }

            if (!string.IsNullOrWhiteSpace(m.MainReleaseReferenceTitle))
            {
                det.Title = new Title[]
                {
                        new Title() {  TitleText = new TitleText() {  Value = m.MainReleaseReferenceTitle } , TitleType = TitleType.FormalTitle },
                        new Title() {  TitleText = new TitleText() {  Value = m.MainReleaseReferenceTitle } , TitleType = TitleType.DisplayTitle}
                };
            }

            if (!string.IsNullOrWhiteSpace(m.MainArtist))
            {
                det.DisplayArtist = new Artist[]
                {
                        new Artist()
                        {
                            SequenceNumber = "1",
                            ArtistRole = new ArtistRole1[] { new ArtistRole1() { Value = ArtistRole.MainArtist } },
                            Items = new object[] { new PartyName() {  FullName = new Name() { Value = m.MainArtist } } }
                        }
                };
            }

            det.ReleaseDate = new EventDate() { IsApproximate = true, IsApproximateSpecified = true, Value = m.ApproximateReleaseDate.ToString("yyyy-MM-dd") };

            return ret;
        }
        private Release GetMainRelease(AudioAlbumModel m)
        {
            Release ret = null;
            if (!string.IsNullOrWhiteSpace(m.EAN))
            {
                ret = new Release()
                {
                    IsMainRelease = true,
                    IsMainReleaseSpecified = true,
                    ReleaseId = new ReleaseId[] 
                    {
                        new ReleaseId()
                        {
                            ICPN = new ICPN()
                            {
                                    IsEan = true,
                                    IsEanSpecified = true,
                                    Value = m.EAN
                            }
                        }
                    },
                    ReleaseReference = new string[] { "R0" },
                    ReferenceTitle = new ReferenceTitle() {  TitleText = new TitleText() {  Value = m.MainReleaseReferenceTitle } },
                    Item = new ReleaseResourceReferenceList()
                    {
                            ReleaseResourceReference = new ReleaseResourceReference[m.Tracks.Count + 1]
                    },
                    ReleaseType = new ReleaseType1[] { new ReleaseType1() { Value = ReleaseType.Album } },
                    ReleaseDetailsByTerritory = GetMainReleaseDetailsByTerritory(m)
                };

                if (!string.IsNullOrWhiteSpace(m.PCLineText) || !string.IsNullOrWhiteSpace(m.ReleaseYear))
                {
                    ret.PLine = new PLine[]
                    {
                        new PLine()
                    };
                    if (!string.IsNullOrWhiteSpace(m.PCLineText))
                    {
                        ret.PLine[0].PLineText = m.PCLineText;
                    }
                    if (!string.IsNullOrWhiteSpace(m.ReleaseYear))
                    {
                        ret.PLine[0].Year = m.ReleaseYear;
                    }
                }

                for (int i = 0; i < m.Tracks.Count + 1; i++)
                {
                    ((ReleaseResourceReferenceList)ret.Item).ReleaseResourceReference[i] = new ReleaseResourceReference()
                    {
                        Value = "A" + (i + 1).ToString(),
                        ReleaseResourceType = (i==m.Tracks.Count ? ReleaseResourceType.SecondaryResource : ReleaseResourceType.PrimaryResource)
                    };
                }
            }

            return ret;
        }
        private ResourceList GetResourceList(AudioAlbumModel m)
        {
            ResourceList ret = null;

            ret = new ResourceList();
            ret.Image = GetFrontCoverImage(m);
            ret.SoundRecording = GetSoundRecordings(m);
                        
            return ret;
        }
        private SoundRecording[] GetSoundRecordings(AudioAlbumModel m)
        {
            SoundRecording[] ret = null;

            if (m.Tracks != null && m.Tracks.Count > 0)
            {
                ret = new SoundRecording[m.Tracks.Count];
                
                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    var track = m.Tracks[i];
                    var sr = new SoundRecording()
                    {
                        LanguageOfPerformance = IsoLanguageCode.aa
                    };

                    sr.SoundRecordingType = new SoundRecordingType1() { Value = SoundRecordingType.MusicalWorkSoundRecording };
                    if (!string.IsNullOrWhiteSpace(track.ISRC)) sr.SoundRecordingId = new SoundRecordingId[] { new SoundRecordingId() {  ISRC = track.ISRC } };
                    sr.ResourceReference = "A" + track.Ordinal;

                    if (!string.IsNullOrWhiteSpace(track.Title)) sr.ReferenceTitle = new ReferenceTitle() {  TitleText = new TitleText() {  Value = track.Title } };
                    sr.Duration = "PT" + track.DurationMin.ToString() + "M" + track.DurationSec.ToString() + "S";

                    sr.SoundRecordingDetailsByTerritory = new SoundRecordingDetailsByTerritory[] {
                        new SoundRecordingDetailsByTerritory()
                        {
                            Items = new CurrentTerritoryCode[] { new CurrentTerritoryCode() { Value = "Worldwide" } },
                            ItemsElementName = new ItemsChoiceType5[] { ItemsChoiceType5.TerritoryCode }
                        }
                    };

                    if (!string.IsNullOrWhiteSpace(track.Title))
                    {
                        sr.SoundRecordingDetailsByTerritory[0].Title = new Title[]
                        {
                            new Title {  TitleText = new TitleText() {  Value = track.Title }, TitleType = TitleType.FormalTitle },
                            new Title {  TitleText = new TitleText() {  Value = track.Title }, TitleType = TitleType.DisplayTitle }
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(track.MainArtist))
                    {
                        sr.SoundRecordingDetailsByTerritory[0].DisplayArtist = new Artist[]
                        {
                            new Artist()
                            {
                                SequenceNumber = "1",
                                ArtistRole = new ArtistRole1[] { new ArtistRole1() { Value = ArtistRole.MainArtist } },
                                Items = new object[] { new PartyName() {  FullName = new Name() { Value = track.MainArtist } } }
                            }
                        };
                    }

                    if (!string.IsNullOrWhiteSpace(track.Producer))
                    {
                        sr.SoundRecordingDetailsByTerritory[0].ResourceContributor = new DetailedResourceContributor[]
                        {
                            new DetailedResourceContributor()
                            {
                                SequenceNumber = "1",
                                Items = new object[] { new PartyName() {  FullName = new Name() { Value = track.Producer } } },
                                ResourceContributorRole = new ResourceContributorRole1[] { new ResourceContributorRole1() {  Value = ResourceContributorRole.Producer } }

                            }
                        };
                    }

                    if (track.IndirectContributors.Count > 0)
                    {
                        sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor = new IndirectResourceContributor[track.IndirectContributors.Count];
                        for (int j = 0; j < track.IndirectContributors.Count; j++)
                        {
                            Tuple<string, string> contributor = track.IndirectContributors[j];
                            sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor[j] = new IndirectResourceContributor()
                            {
                                SequenceNumber = (j + 1).ToString(),
                                Items = new object[] { new PartyName() { FullName = new Name() { Value = contributor.Item1 } } },
                                IndirectResourceContributorRole = new MusicalWorkContributorRole[] { new MusicalWorkContributorRole() { Value = contributor.Item2 } }
                            };
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(track.ReleaseYear) || !string.IsNullOrWhiteSpace(track.PLineText))
                    {
                        sr.SoundRecordingDetailsByTerritory[0].PLine = new PLine[]
                        {
                                new PLine()
                        };

                        if (!string.IsNullOrWhiteSpace(track.ReleaseYear))
                        {
                            sr.SoundRecordingDetailsByTerritory[0].PLine[0].Year = track.ReleaseYear;
                            sr.SoundRecordingDetailsByTerritory[0].ResourceReleaseDate = new EventDate() { Value = track.ReleaseYear };
                        }

                        if (!string.IsNullOrWhiteSpace(track.PLineText))
                        {
                            sr.SoundRecordingDetailsByTerritory[0].PLine[0].PLineText = track.PLineText;
                        }
                    }

                    ret[i] = sr;
                }
            }

            return ret;
        }
        private Image[] GetFrontCoverImage(AudioAlbumModel m)
        {
            Image[] ret = null;

            if (m.FrontCoverImageFileName != null || m.FrontCoverImagePath != null)
            {
                ret = new Image[]
                {
                    new Image()
                    {
                        ImageType = new ImageType1() {  Value = ImageType.FrontCoverImage },
                        ImageId = new ResourceProprietaryId[]
                        {
                            new ResourceProprietaryId()
                            {
                                ProprietaryId = new ProprietaryId[]
                                {
                                    new ProprietaryId() { Value = m.EAN + "_COVERART", Namespace = "DPID:" + m.SenderPartyID }
                                }
                            }
                        }
                    }
                };

                ret[0].ImageDetailsByTerritory = new ImageDetailsByTerritory[1];
                ret[0].ImageDetailsByTerritory[0] = new ImageDetailsByTerritory();
                ret[0].ImageDetailsByTerritory[0].Items = new CurrentTerritoryCode[1];
                ret[0].ImageDetailsByTerritory[0].Items[0] = new CurrentTerritoryCode() { Value = "Worldwide" };
                ret[0].ImageDetailsByTerritory[0].ItemsElementName = new ItemsChoiceType9[] { ItemsChoiceType9.TerritoryCode };

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
            
            
            return nrm;
        }
    }
}
