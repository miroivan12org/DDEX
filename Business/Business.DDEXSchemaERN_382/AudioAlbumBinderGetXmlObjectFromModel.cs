using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.DDEXSchemaERN_382
{
    public partial class AudioAlbumBinder
    {
        private NewReleaseMessage GetXmlNewReleaseMessage(AudioAlbumModel m)
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
            
            ret.FullFileName = m.FullFileName;

            ret.UpdateIndicator = m.UpdateIndicator;
            ret.UpdateIndicatorSpecified = true;

            ret.MessageHeader = GetXmlMessageHeader(m);
            ret.ResourceList = GetXmlResourceList(m);
            ret.ReleaseList = GetXmlReleaseList(m);

            ret.DealList = GetXmlDealList(m);

            return ret;
        }
        private string[] GetXmlDealListReleaseReferences(AudioAlbumModel m)
        {
            string[] ret;

            var releaseReferences = new List<string>();
            for (int i = 0; i <= m.Tracks.Count(); i++)
            {
                releaseReferences.Add(string.Format("R{0}", i.ToString()));
            }
            ret = releaseReferences.ToArray();

            return ret;
        }
        private DealList GetXmlDealListStandardDeezer(AudioAlbumModel m)
        {
            DealList ret = null;

            ret = new DealList();

            ret.ReleaseDeal = new ReleaseDeal[] { new ReleaseDeal() };
            var rd = ret.ReleaseDeal[0];

            rd.DealReleaseReference = GetXmlDealListReleaseReferences(m);

            rd.Deal = new Deal[] {
                    new Deal()
                    {
                        DealTerms = new DealTerms()
                        {
                            CommercialModelType = new CommercialModelType1[]
                            {
                                new CommercialModelType1() {  Value = CommercialModelType.SubscriptionModel },
                                new CommercialModelType1() {  Value = CommercialModelType.AdvertisementSupportedModel },
                                new CommercialModelType1() {  Value = CommercialModelType.PayAsYouGoModel }
                            },
                            ValidityPeriod = new Period[] {
                                new Period()
                                {
                                    ItemsElementName = new ItemsChoiceType3[] {  ItemsChoiceType3.StartDate },
                                    Items = new object[] { new EventDate() {  Value = m.DealStartDate.ToString("yyyy-MM-dd") } }
                                }
                            },
                            Items1 = new CurrentTerritoryCode[] {
                                new CurrentTerritoryCode()
                                {
                                    IdentifierType = TerritoryCodeType.ISO,
                                    IdentifierTypeSpecified = false,
                                    Value = "Worldwide"
                                }
                            },
                            Items1ElementName = new Items1ChoiceType[] { Items1ChoiceType.TerritoryCode },
                            Items = new object[] {
                                new Usage()
                                {

                                    UseType = new UseType1[] {
                                        new UseType1() {  Value = UseType.PermanentDownload },
                                        new UseType1() {  Value = UseType.OnDemandStream },
                                        new UseType1() {  Value = UseType.NonInteractiveStream }
                                    }
                                }
                            },
                            ItemsElementName = new ItemsChoiceType17[] { ItemsChoiceType17.Usage }
                        }
                    }
                };

            return ret;
        }
        private DealList GetXmlDealListStandardPandora(AudioAlbumModel m)
        {
            DealList ret = null;

            ret = new DealList();

            ret.ReleaseDeal = new ReleaseDeal[] { new ReleaseDeal() };
            var rd = ret.ReleaseDeal[0];
            rd.DealReleaseReference = GetXmlDealListReleaseReferences(m);

            rd.Deal = new Deal[] {
                    new Deal()
                    {
                        DealTerms = new DealTerms()
                        {
                            CommercialModelType = new CommercialModelType1[]
                            {
                                new CommercialModelType1() {  Value = CommercialModelType.AdvertisementSupportedModel },
                                new CommercialModelType1() {  Value = CommercialModelType.SubscriptionModel }
                            },
                            ValidityPeriod = new Period[] {
                                new Period()
                                {
                                    ItemsElementName = new ItemsChoiceType3[] {  ItemsChoiceType3.StartDate },
                                    Items = new object[] { new EventDate() {  Value = m.DealStartDate.ToString("yyyy-MM-dd") } }
                                }
                            },
                            Items1 = new CurrentTerritoryCode[] {
                                new CurrentTerritoryCode()
                                {
                                    IdentifierType = TerritoryCodeType.ISO,
                                    IdentifierTypeSpecified = false,
                                    Value = "Worldwide"
                                }
                            },
                            Items1ElementName = new Items1ChoiceType[] { Items1ChoiceType.TerritoryCode },
                            Items = new object[] {
                                new Usage()
                                {
                                    UseType = new UseType1[] {
                                        new UseType1() {  Value = UseType.ConditionalDownload },
                                        new UseType1() {  Value = UseType.OnDemandStream },
                                        new UseType1() {  Value = UseType.NonInteractiveStream }
                                    }
                                }
                            },
                            ItemsElementName = new ItemsChoiceType17[] { ItemsChoiceType17.Usage }
                        }
                    }
                };

            return ret;
        }
        private DealList GetXmlDealListStandardSoundCloud(AudioAlbumModel m)
        {
            DealList ret = null;

            ret = new DealList();

            ret.ReleaseDeal = new ReleaseDeal[] { new ReleaseDeal() };
            var rd = ret.ReleaseDeal[0];
            rd.DealReleaseReference = GetXmlDealListReleaseReferences(m);

            rd.Deal = new Deal[] {
                    new Deal()
                    {
                        DealTerms = new DealTerms()
                        {
                            CommercialModelType = new CommercialModelType1[]
                            {
                                new CommercialModelType1() {  Value = CommercialModelType.RightsClaimModel }
                            },
                            Items = new object[] {
                                new Usage()
                                {
                                    UseType = new UseType1[] {
                                        new UseType1() {  Value = UseType.UserDefined, UserDefinedValue = "UseForIdentification" }
                                    }
                                }
                            },
                            ItemsElementName = new ItemsChoiceType17[] { ItemsChoiceType17.Usage },
                            
                            Items1 = new CurrentTerritoryCode[] {
                                new CurrentTerritoryCode()
                                {
                                    IdentifierType = TerritoryCodeType.ISO,
                                    IdentifierTypeSpecified = false,
                                    Value = "Worldwide"
                                }
                            },
                            Items1ElementName = new Items1ChoiceType[] { Items1ChoiceType.TerritoryCode },
                            ValidityPeriod = new Period[] {
                                new Period()
                                {
                                    ItemsElementName = new ItemsChoiceType3[] {  ItemsChoiceType3.StartDate },
                                    Items = new object[] { new EventDate() {  Value = m.DealStartDate.ToString("yyyy-MM-dd") } }
                                }
                            },
                            RightsClaimPolicy = new RightsClaimPolicy[]
                            {
                                new RightsClaimPolicy()
                                {
                                    Condition = new Condition[] {
                                        new Condition() {  Value = 20, Unit = UnitOfConditionValue.Percent, RelationalRelator = RelationalRelator.MoreThan }
                                    },
                                    RightsClaimPolicyType = RightsClaimPolicyType.ReportUsage
                                }
                            }

                        }
                    },
                    new Deal()
                    {
                        DealTerms = new DealTerms()
                        {
                            CommercialModelType = new CommercialModelType1[]
                            {
                                new CommercialModelType1() {  Value = CommercialModelType.SubscriptionModel }
                            },
                            ValidityPeriod = new Period[] {
                                new Period()
                                {
                                    ItemsElementName = new ItemsChoiceType3[] {  ItemsChoiceType3.StartDate },
                                    Items = new object[] { new EventDate() {  Value = m.DealStartDate.ToString("yyyy-MM-dd") } }
                                }
                            },
                            Items1 = new CurrentTerritoryCode[] {
                                new CurrentTerritoryCode()
                                {
                                    IdentifierType = TerritoryCodeType.ISO,
                                    IdentifierTypeSpecified = false,
                                    Value = "Worldwide"
                                }
                            },
                            Items1ElementName = new Items1ChoiceType[] { Items1ChoiceType.TerritoryCode },
                            Items = new object[] {
                                new Usage()
                                {
                                    UseType = new UseType1[] {
                                        new UseType1() {  Value = UseType.OnDemandStream }
                                    }
                                }
                            },
                            ItemsElementName = new ItemsChoiceType17[] { ItemsChoiceType17.Usage }
                        }
                    },
                    new Deal()
                    {
                        DealTerms = new DealTerms()
                        {
                            CommercialModelType = new CommercialModelType1[]
                            {
                                new CommercialModelType1() {  Value = CommercialModelType.AdvertisementSupportedModel }
                            },
                            ValidityPeriod = new Period[] {
                                new Period()
                                {
                                    ItemsElementName = new ItemsChoiceType3[] {  ItemsChoiceType3.StartDate },
                                    Items = new object[] { new EventDate() {  Value = m.DealStartDate.ToString("yyyy-MM-dd") } }
                                }
                            },
                            Items1 = new CurrentTerritoryCode[] {
                                new CurrentTerritoryCode()
                                {
                                    IdentifierType = TerritoryCodeType.ISO,
                                    IdentifierTypeSpecified = false,
                                    Value = "Worldwide"
                                }
                            },
                            Items1ElementName = new Items1ChoiceType[] { Items1ChoiceType.TerritoryCode },
                            Items = new object[] {
                                new Usage()
                                {
                                    UseType = new UseType1[] {
                                        new UseType1() {  Value = UseType.OnDemandStream }
                                    }
                                }
                            },
                            ItemsElementName = new ItemsChoiceType17[] { ItemsChoiceType17.Usage }
                        }
                    }
                };

            return ret;
        }

        private DealList GetXmlDealListStandard(AudioAlbumModel m)
        {
            DealList ret = null;
            
            if (m.MusicService == AudioAlbumModel.eMusicService.Deezer)
            {
                ret = GetXmlDealListStandardDeezer(m);
            }
            else if (m.MusicService == AudioAlbumModel.eMusicService.Pandora)
            {
                ret = GetXmlDealListStandardPandora(m);
            }
            else if (m.MusicService == AudioAlbumModel.eMusicService.SoundCloud)
            {
                ret = GetXmlDealListStandardSoundCloud(m);
            }
            else
            {
                ret = GetXmlDealListStandardDeezer(m);
            }
            
            return ret;
        }

        private DealList GetXmlDealList(AudioAlbumModel m)
        {
            DealList ret = null;

            switch (m.DealType)
            {
                case AudioAlbumModel.eDealType.Standard:
                    ret = GetXmlDealListStandard(m);
                    break;
                default:
                    break;
            }

            return ret;
        }
        private MessageHeader GetXmlMessageHeader(AudioAlbumModel m)
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
            //ret.MessageCreatedDateTime = new DateTime(m.MessageCreatedDateTime.Ticks, DateTimeKind.Local);
            
            ret.MessageCreatedDateTime = DateTime.SpecifyKind(m.MessageCreatedDateTime, DateTimeKind.Local); 
            
            return ret;
        }
        private ReleaseList GetXmlReleaseList(AudioAlbumModel m)
        {
            ReleaseList ret = null;

            Release mainRelease = GetXmlMainRelease(m);
            int releaseListCount = (mainRelease == null ? 0 : 1) + m.Tracks.Count; ;
            if (releaseListCount > 0)
            {
                ret = new ReleaseList()
                {
                    Release = new Release[releaseListCount]
                };
                if (mainRelease != null) ret.Release[0] = mainRelease;

                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    ret.Release[i + 1] = GetXmlRelease(m.Tracks[i], m);
                }
            }
         
            return ret;
        }
        private ResourceGroup GetXmlMainReleaseResourceGroup(AudioAlbumModel m)
        {
            ResourceGroup ret = null;

            ret = new ResourceGroup()
            {
                ResourceGroup1 = new ResourceGroup[]
                {
                    new ResourceGroup()
                    {
                        Title = new Title[]
                        {
                            new Title()
                            {
                                TitleType = TitleType.GroupingTitle,
                                TitleTypeSpecified = true,
                                TitleText = new TitleText()
                                {
                                    Value = "Component 1"
                                }
                            }
                        },
                        SequenceNumber = "1",
                        Items = new object[m.Tracks.Count]
                    }
                }
            };

            for (int i = 0; i < m.Tracks.Count; i++)
            {
                ret.ResourceGroup1[0].Items[i] = new ExtendedResourceGroupContentItem
                {
                    ReleaseResourceReference = new ReleaseResourceReference()
                    {
                        ReleaseResourceType = ReleaseResourceType.PrimaryResource,
                        ReleaseResourceTypeSpecified = true,
                        Value = "A" + (i + 1).ToString()
                    },
                    ResourceType = new ResourceType1[]
                    {
                        new ResourceType1()
                        {
                             Value = ResourceType.SoundRecording
                        }
                    },
                    SequenceNumber = (i + 1).ToString()
                };
            }

            return ret;
        }
        private ReleaseDetailsByTerritory[] GetXmlMainReleaseDetailsByTerritory(AudioAlbumModel m)
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

            if (!string.IsNullOrWhiteSpace(m.MainArtist))
            {
                det.DisplayArtistName = new Name[]
                {
                    new Name()
                    {
                        Value = m.MainArtist
                    }
                };
            }            

            if (m.Tracks.Count > 0)
            {
                det.ResourceGroup = new ResourceGroup[]
                {
                    GetXmlMainReleaseResourceGroup(m)
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
                                    Value = "A" + (m.Tracks.Count + 1).ToString()
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
                    new Title() {  TitleText = new TitleText() {  Value = m.MainReleaseReferenceTitle } , TitleType = TitleType.FormalTitle, TitleTypeSpecified = true },
                    new Title() {  TitleText = new TitleText() {  Value = m.MainReleaseReferenceTitle } , TitleType = TitleType.DisplayTitle, TitleTypeSpecified = true}
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
        private Release GetXmlMainRelease(AudioAlbumModel m)
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
                    ReleaseDetailsByTerritory = GetXmlMainReleaseDetailsByTerritory(m)
                };

                if (!string.IsNullOrWhiteSpace(m.PLineText) || !string.IsNullOrWhiteSpace(m.PLineReleaseYear))
                {
                    ret.PLine = new PLine[]
                    {
                        new PLine()
                    };
                    if (!string.IsNullOrWhiteSpace(m.PLineText))
                    {
                        ret.PLine[0].PLineText = m.PLineText;
                    }
                    if (!string.IsNullOrWhiteSpace(m.PLineReleaseYear))
                    {
                        ret.PLine[0].Year = m.PLineReleaseYear;
                    }
                }

                if (!string.IsNullOrWhiteSpace(m.CLineText) || !string.IsNullOrWhiteSpace(m.CLineReleaseYear))
                {
                    ret.CLine = new CLine[]
                    {
                        new CLine()
                    };
                    if (!string.IsNullOrWhiteSpace(m.CLineText))
                    {
                        ret.CLine[0].CLineText = m.CLineText;
                    }
                    if (!string.IsNullOrWhiteSpace(m.CLineReleaseYear))
                    {
                        ret.CLine[0].Year = m.CLineReleaseYear;
                    }
                }

                for (int i = 0; i < m.Tracks.Count + 1; i++)
                {
                    ((ReleaseResourceReferenceList)ret.Item).ReleaseResourceReference[i] = new ReleaseResourceReference()
                    {
                        Value = "A" + (i + 1).ToString(),
                        ReleaseResourceType = (i==m.Tracks.Count ? ReleaseResourceType.SecondaryResource : ReleaseResourceType.PrimaryResource),
                        ReleaseResourceTypeSpecified = true
                    };
                }
            }

            return ret;
        }
        private ReleaseDetailsByTerritory GetXmlReleaseDetailsByTerritory(TrackModel track, AudioAlbumModel m)
        {
            ReleaseDetailsByTerritory ret = null;

            ret = new ReleaseDetailsByTerritory()
            {
                Items = new CurrentTerritoryCode[] { new CurrentTerritoryCode() { Value = "Worldwide" } },
                ItemsElementName = new ItemsChoiceType15[] 
                {
                    ItemsChoiceType15.TerritoryCode
                },
                ParentalWarningType = new ParentalWarningType1[]
                {
                    new ParentalWarningType1()
                    {
                        Value = ParentalWarningType.NotExplicit
                    }
                },
                ResourceGroup = new ResourceGroup[]
                {
                    new ResourceGroup()
                    {
                        Items = new ExtendedResourceGroupContentItem[]
                        {
                            new ExtendedResourceGroupContentItem()
                            {
                                ReleaseResourceReference = new ReleaseResourceReference()
                                {
                                    ReleaseResourceType = ReleaseResourceType.PrimaryResource,
                                    ReleaseResourceTypeSpecified = true,
                                    Value = "A" + track.Ordinal.ToString()
                                },
                                ResourceType = new ResourceType1[]
                                {
                                    new ResourceType1()
                                    {
                                        Value = ResourceType.SoundRecording
                                    }
                                },
                                SequenceNumber = "1"
                            }
                        }   
                    }
                }
            };
            if (!string.IsNullOrWhiteSpace(track.Genre) || !string.IsNullOrWhiteSpace(track.SubGenre))
            {
                ret.Genre = new Genre[]
                {
                    new Genre()
                };

                if (!string.IsNullOrWhiteSpace(track.Genre))
                {
                    ret.Genre[0].GenreText = new Description()
                    {
                        Value = track.Genre
                    };
                }

                if (!string.IsNullOrWhiteSpace(track.SubGenre))
                {
                    ret.Genre[0].SubGenre = new Description()
                    {
                        Value = track.SubGenre
                    };
                }
            }
            
            ret.ReleaseDate = new EventDate()
            {
                IsApproximate = true,
                IsApproximateSpecified = true,
                Value = m.ApproximateReleaseDate.ToString("yyyy-MM-dd")
            };
            

            if (!string.IsNullOrWhiteSpace(track.MainArtist))
            {
                ret.DisplayArtistName = new Name[]
                {
                    new Name()
                    {
                        Value = track.MainArtist
                    }
                };
                ret.DisplayArtist = new Artist[]
                {
                    new Artist()
                    {
                        ArtistRole = new ArtistRole1[]
                        {
                            new ArtistRole1() {  Value = ArtistRole.MainArtist }
                        },
                        Items = new object[]
                        {
                            new PartyName()
                            {
                                FullName = new Name()
                                {
                                    Value = track.MainArtist
                                }
                            }
                        },
                        SequenceNumber = "1"
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(m.LabelName))
            {
                ret.LabelName = new LabelName[]
                {
                    new LabelName()
                    {
                        Value = m.LabelName
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(track.Title))
            {
                ret.Title = new Title[]
                {
                    new Title()
                    {
                        TitleText = new TitleText() { Value = track.Title },
                        TitleType = TitleType.FormalTitle,
                        TitleTypeSpecified = true
                    },
                    new Title()
                    {
                        TitleText = new TitleText() { Value = track.Title },
                        TitleType = TitleType.DisplayTitle,
                        TitleTypeSpecified = true
                    }
                };
            }
            
            return ret;
        }
        private Release GetXmlRelease(TrackModel track, AudioAlbumModel m)
        {
            Release ret = new Release()
            {
                ReleaseId = new Schema.ReleaseId[]
                {
                    new ReleaseId()
                    {
                        ISRC = track.ISRC
                    }
                },

                ReleaseReference = new string[]
                {
                    "R" + track.Ordinal.ToString()
                }
            };

            if (!string.IsNullOrWhiteSpace(track.Title))
            {
                ret.ReferenceTitle = new ReferenceTitle()
                {
                    TitleText = new TitleText() { Value = track.Title }
                };
            };

            ret.Item = new ReleaseResourceReferenceList()
            {
                ReleaseResourceReference = new ReleaseResourceReference[]
                {
                    new ReleaseResourceReference()
                    {
                        ReleaseResourceType = ReleaseResourceType.PrimaryResource,
                        ReleaseResourceTypeSpecified = true,
                        Value = "A" + track.Ordinal.ToString()
                    }
                }
            };

            ret.ReleaseType = new ReleaseType1[]
            {
                new ReleaseType1()
                {
                    Value =  ReleaseType.TrackRelease
                }
            };

            ret.ReleaseDetailsByTerritory = new ReleaseDetailsByTerritory[]
            {
                GetXmlReleaseDetailsByTerritory(track, m)
            };

            if (!string.IsNullOrWhiteSpace(track.PLineText) || !string.IsNullOrWhiteSpace(track.PLineReleaseYear))
            {
                ret.PLine = new PLine[]
                {
                    new PLine()
                };

                if (!string.IsNullOrWhiteSpace(track.PLineText))
                {
                    ret.PLine[0].PLineText = track.PLineText;
                }

                if (!string.IsNullOrWhiteSpace(track.PLineReleaseYear))
                {
                    ret.PLine[0].Year = track.PLineReleaseYear;
                }
            }

            if (!string.IsNullOrWhiteSpace(track.CLineText) || !string.IsNullOrWhiteSpace(track.CLineReleaseYear))
            {
                ret.CLine = new CLine[]
                {
                    new CLine()
                };
                if (!string.IsNullOrWhiteSpace(track.CLineText))
                {
                    ret.CLine[0].CLineText = track.CLineText;
                }
                if (!string.IsNullOrWhiteSpace(track.CLineReleaseYear))
                {
                    ret.CLine[0].Year = track.CLineReleaseYear;
                }
            }
            
            ret.GlobalOriginalReleaseDate = new EventDate()
            {
                IsApproximate = true,
                IsApproximateSpecified = true,
                Value = m.ApproximateReleaseDate.ToString("yyyy-MM-dd")
            };
            
            return ret;
        }
        private ResourceList GetXmlResourceList(AudioAlbumModel m)
        {
            ResourceList ret = null;

            ret = new ResourceList();
            ret.Image = GetXmlFrontCoverImage(m);
            ret.SoundRecording = GetXmlSoundRecordings(m);
                        
            return ret;
        }
        private TechnicalSoundRecordingDetails GetXmlTechnicalSoundRecordingDetails(TrackModel track)
        {
            TechnicalSoundRecordingDetails ret = null;

            if (!string.IsNullOrWhiteSpace(track.FileName) || !string.IsNullOrWhiteSpace(track.FilePath))
            {
                ret = new TechnicalSoundRecordingDetails()
                {
                    TechnicalResourceDetailsReference = "T" + track.Ordinal.ToString(),
                    AudioCodecType = new AudioCodecType1()
                    {
                        Value = track.AudioCodec
                    },
                    NumberOfChannels = track.NumberOfChannels.ToString(),
                    SamplingRate = new SamplingRate()
                    {
                        UnitOfMeasure = UnitOfFrequency.kHz,
                        UnitOfMeasureSpecified = true,
                        Value = track.SamplingRate
                    },
                    BitsPerSample = track.BitsPerSample.ToString(),
                    IsPreview = false,
                    IsPreviewSpecified = true,
                    Items = new object[]
                    {
                        new File()
                        {
                            ItemsElementName = new ItemsChoiceType6[]
                            {
                                ItemsChoiceType6.FileName,
                                ItemsChoiceType6.FilePath
                            },
                            Items = new string[]
                            {
                                track.FileName,
                                track.FilePath
                            }
                        }
                    } 
                };
                if (track.FileHashSum_Materialized != null && ret != null && ret.Items != null && ret.Items.Length > 0 && ret.Items[0] is File) 
                {
                    ((File)ret.Items[0]).HashSum = new HashSum()
                    {
                        HashSumAlgorithmType = new HashSumAlgorithmType1()
                        {
                            Value = HashSumAlgorithmType.MD5
                        },
                        HashSum1 = track.FileHashSum_Materialized
                    };
                }
               
            }
            
            return ret;
        }
        private SoundRecording GetXmlSoundRecording(TrackModel track)
        {
            var sr = new SoundRecording()
            {
                LanguageOfPerformance = IsoLanguageCode.aa
            };

            sr.SoundRecordingType = new SoundRecordingType1() { Value = SoundRecordingType.MusicalWorkSoundRecording };
            if (!string.IsNullOrWhiteSpace(track.ISRC)) sr.SoundRecordingId = new SoundRecordingId[] { new SoundRecordingId() { ISRC = track.ISRC } };
            sr.ResourceReference = "A" + track.Ordinal;

            if (!string.IsNullOrWhiteSpace(track.Title)) sr.ReferenceTitle = new ReferenceTitle() { TitleText = new TitleText() { Value = track.Title } };
            sr.Duration = "PT" + track.DurationMin.ToString() + "M" + track.DurationSec.ToString().PadLeft(2, '0') + "S";

            sr.SoundRecordingDetailsByTerritory = new SoundRecordingDetailsByTerritory[] {
                        new SoundRecordingDetailsByTerritory()
                        {
                            Items = new CurrentTerritoryCode[] { new CurrentTerritoryCode() { Value = "Worldwide" } },
                            ItemsElementName = new ItemsChoiceType5[] { ItemsChoiceType5.TerritoryCode },
                            ParentalWarningType = new ParentalWarningType1[]
                            {
                                new ParentalWarningType1()
                                {
                                    Value = ParentalWarningType.NotExplicit
                                }
                            }
                        }
                    };

            if (!string.IsNullOrWhiteSpace(track.Title))
            {
                sr.SoundRecordingDetailsByTerritory[0].Title = new Title[]
                {
                            new Title {  TitleText = new TitleText() {  Value = track.Title }, TitleType = TitleType.FormalTitle, TitleTypeSpecified = true },
                            new Title {  TitleText = new TitleText() {  Value = track.Title }, TitleType = TitleType.DisplayTitle, TitleTypeSpecified = true }
                };
            }

            var lsDisplayArtists = new List<Artist>();
            if (track.DisplayArtists.Count > 0)
            {
                //sr.SoundRecordingDetailsByTerritory[0].DisplayArtist = new IndirectResourceContributor[track.IndirectContributors.Count];
                

                var roleLastSequenceNumber = new Dictionary<string, int>();
                for (int j = 0; j < track.DisplayArtists.Count; j++)
                {
                    Tuple<string, string> artistTuple = track.DisplayArtists[j];
                    var art = new Artist()
                    {
                        Items = new object[] { new PartyName() { FullName = new Name() { Value = artistTuple.Item1 } } },
                        ArtistRole = new ArtistRole1[] { new ArtistRole1() { Value = (ArtistRole) Enum.Parse(typeof(ArtistRole), artistTuple.Item2) } },
                    };
                    if (!roleLastSequenceNumber.ContainsKey(artistTuple.Item2))
                    {
                        roleLastSequenceNumber.Add(artistTuple.Item2, 1);
                    }
                    else
                    {
                        roleLastSequenceNumber[artistTuple.Item2] = roleLastSequenceNumber[artistTuple.Item2] + 1;
                    }
                    art.SequenceNumber = roleLastSequenceNumber[artistTuple.Item2].ToString();

                    //sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor[j] = art;
                    lsDisplayArtists.Add(art);
                }
            }
            /* TODO
                - rijesiti glavnog displayartista
                - ne zaboraviti dodati displyartiste u release dolje
             */
            if (!string.IsNullOrWhiteSpace(track.MainArtist))
            {
                lsDisplayArtists.Insert(0, 
                
                            new Artist()
                            {
                                SequenceNumber = "1",
                                ArtistRole = new ArtistRole1[] { new ArtistRole1() { Value = ArtistRole.MainArtist } },
                                Items = new object[] { new PartyName() {  FullName = new Name() { Value = track.MainArtist } } }
                            }
                );
             
            }
            if (lsDisplayArtists.Count > 0)
            {
                sr.SoundRecordingDetailsByTerritory[0].DisplayArtist = lsDisplayArtists.ToArray();
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
                var roleLastSequenceNumber = new Dictionary<string, int>();
                for (int j = 0; j < track.IndirectContributors.Count; j++)
                {
                    Tuple<string, string> contributor = track.IndirectContributors[j];
                    var irc = new IndirectResourceContributor()
                    {
                        Items = new object[] { new PartyName() { FullName = new Name() { Value = contributor.Item1 } } },
                        IndirectResourceContributorRole = new MusicalWorkContributorRole[] { new MusicalWorkContributorRole() { Value = contributor.Item2 } }
                    };
                    if (!roleLastSequenceNumber.ContainsKey(contributor.Item2))
                    {
                        roleLastSequenceNumber.Add(contributor.Item2, 1);
                    }
                    else
                    {
                        roleLastSequenceNumber[contributor.Item2] = roleLastSequenceNumber[contributor.Item2] + 1;
                    }
                    irc.SequenceNumber = roleLastSequenceNumber[contributor.Item2].ToString();

                    sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor[j] = irc;
                }
            }

            if (!string.IsNullOrWhiteSpace(track.PLineReleaseYear) || !string.IsNullOrWhiteSpace(track.PLineText))
            {
                sr.SoundRecordingDetailsByTerritory[0].PLine = new PLine[]
                {
                            new PLine()
                };

                if (!string.IsNullOrWhiteSpace(track.PLineReleaseYear))
                {
                    sr.SoundRecordingDetailsByTerritory[0].PLine[0].Year = track.PLineReleaseYear;
                    sr.SoundRecordingDetailsByTerritory[0].ResourceReleaseDate = new EventDate() { Value = track.PLineReleaseYear };
                }

                if (!string.IsNullOrWhiteSpace(track.PLineText))
                {
                    sr.SoundRecordingDetailsByTerritory[0].PLine[0].PLineText = track.PLineText;
                }
            }

            if (!string.IsNullOrWhiteSpace(track.Genre) || !string.IsNullOrWhiteSpace(track.SubGenre))
            {
                sr.SoundRecordingDetailsByTerritory[0].Genre = new Genre[]
                {
                            new Genre()
                };

                if (!string.IsNullOrWhiteSpace(track.Genre))
                {
                    sr.SoundRecordingDetailsByTerritory[0].Genre[0].GenreText = new Description()
                    {
                        Value = track.Genre
                    };
                }

                if (!string.IsNullOrWhiteSpace(track.SubGenre))
                {
                    sr.SoundRecordingDetailsByTerritory[0].Genre[0].SubGenre = new Description()
                    {
                        Value = track.SubGenre
                    };
                }
            }

            sr.SoundRecordingDetailsByTerritory[0].TechnicalSoundRecordingDetails = new TechnicalSoundRecordingDetails[]
            {
                GetXmlTechnicalSoundRecordingDetails(track)
            };

            return sr;
        }
        private SoundRecording[] GetXmlSoundRecordings(AudioAlbumModel m)
        {
            SoundRecording[] ret = null;

            if (m.Tracks != null && m.Tracks.Count > 0)
            {
                ret = new SoundRecording[m.Tracks.Count];
                
                for (int i = 0; i < m.Tracks.Count; i++)
                {
                    var track = m.Tracks[i];

                    SoundRecording sr = GetXmlSoundRecording(track);

                    ret[i] = sr;
                }
            }

            return ret;
        }
        private Image[] GetXmlFrontCoverImage(AudioAlbumModel m)
        {
            Image[] ret = null;

            if (m.FrontCoverImageFileName != null || m.FrontCoverImagePath != null)
            {
                int imageOrdinal = 1;
                if (m.Tracks != null && m.Tracks.Any())
                {
                    imageOrdinal = m.Tracks.Count + 1;
                }

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
                        },
                        ResourceReference = "A" + imageOrdinal.ToString(),
                        ImageDetailsByTerritory = new ImageDetailsByTerritory[]
                        {
                            new ImageDetailsByTerritory()
                            {
                                Items = new CurrentTerritoryCode[]
                                {
                                    new CurrentTerritoryCode()
                                    {
                                        Value = "Worldwide"
                                    }
                                },
                                ItemsElementName = new ItemsChoiceType9[]
                                {
                                    ItemsChoiceType9.TerritoryCode
                                },
                                TechnicalImageDetails = new TechnicalImageDetails[]
                                {
                                    new TechnicalImageDetails()
                                    {
                                        ImageCodecType = new ImageCodecType1() { Value = m.FrontCoverImageCodecType },
                                        ImageHeight = new Extent() { Value = m.FrontCoverImageHeight_Materialized },
                                        ImageWidth = new Extent() { Value = m.FrontCoverImageWidth_Materialized},
                                        Items = new File[]
                                        {
                                            new File()
                                            {
                                                HashSum = (m.FrontCoverImageHashSum_Materialized == null) ? null : new HashSum()
                                                {
                                                    HashSum1 = m.FrontCoverImageHashSum_Materialized,
                                                    HashSumAlgorithmType = new HashSumAlgorithmType1() {  Value = HashSumAlgorithmType.MD5 }
                                                },
                                                Items = new string[] { m.FrontCoverImageFileName, m.FrontCoverImagePath },
                                                ItemsElementName = new ItemsChoiceType6[] {  ItemsChoiceType6.FileName, ItemsChoiceType6.FilePath }
                                            }
                                        },
                                        TechnicalResourceDetailsReference = "T" + imageOrdinal.ToString()
                                    }
                                }
                            }
                        }
                    }                    
                };
            }

            return ret;
        }
        public IXmlObject GetXmlObjectFromModel(IBindableModel model)
        {
            NewReleaseMessage nrm;
            AudioAlbumModel m = (AudioAlbumModel)model;


            nrm = GetXmlNewReleaseMessage(m);
            
            
            return nrm;
        }
    }
}
