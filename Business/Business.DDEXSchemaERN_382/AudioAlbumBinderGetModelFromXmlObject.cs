using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.BindingObjects;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Business.DDEXSchemaERN_382
{
    public partial class AudioAlbumBinder
    {
        private Release GetModelMainRelease(NewReleaseMessage nrm)
        {
            Release mainRelease = null;

            if (nrm != null && nrm.ReleaseList != null && nrm.ReleaseList.Release != null)
            {
                mainRelease = nrm.ReleaseList.Release[0];
            }

            return mainRelease;
        }
        private ReleaseDetailsByTerritory GetModelMainReleaseDetailsByTerritory(NewReleaseMessage nrm)
        {
            ReleaseDetailsByTerritory ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.ReleaseDetailsByTerritory != null && mainRelease.ReleaseDetailsByTerritory.Length > 0)
            {
                ret = mainRelease.ReleaseDetailsByTerritory[0];
            }
                
            return ret;
        }
        private Image GetModelFrontCoverImage(NewReleaseMessage nrm)
        {
            Image ret = null;

            if (nrm != null && nrm.ResourceList != null && nrm.ResourceList.Image != null && nrm.ResourceList.Image.Length > 0 && nrm.ResourceList.Image[0] != null)
            {
                ret = nrm.ResourceList.Image[0];
            }

            return ret;
        }
        private ImageDetailsByTerritory GetModelFrontCoverImageDetailsByTerritory(NewReleaseMessage nrm)
        {
            ImageDetailsByTerritory ret = null;
            Image img = GetModelFrontCoverImage(nrm);
            if (img != null && img.ImageDetailsByTerritory != null && img.ImageDetailsByTerritory.Length > 0 )
            {
                ret = img.ImageDetailsByTerritory[0];
            }
            
            return ret;
        }
        private TechnicalImageDetails GetModelFrontCoverImageTechnicalImageDetails(NewReleaseMessage nrm)
        {
            TechnicalImageDetails ret = null;

            ImageDetailsByTerritory imgDet = GetModelFrontCoverImageDetailsByTerritory(nrm);
            if (imgDet != null && imgDet.TechnicalImageDetails != null && imgDet.TechnicalImageDetails.Length > 0)
            {
                ret = imgDet.TechnicalImageDetails[0];
            }

            return ret;
        }
        private File GetModelFrontCoverImageFile(NewReleaseMessage nrm)
        {
            File ret = null;

            TechnicalImageDetails det = GetModelFrontCoverImageTechnicalImageDetails(nrm);
            if (det != null && det.Items != null && det.Items.Length > 0 && det.Items[0] != null && det.Items[0] is File)
            {
                ret = (File)det.Items[0];
            }

            return ret;
        }
        private string GetModelEAN(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);

            if (mainRelease != null && mainRelease.ReleaseId != null && mainRelease.ReleaseId.Length > 0 && mainRelease.ReleaseId[0].ICPN != null)
            {
                ret = mainRelease.ReleaseId[0].ICPN.Value;
            }

            return ret;
        }
        private string GetModelMainArtist(NewReleaseMessage nrm)
        {
            string ret = null;

            ReleaseDetailsByTerritory mainReleaseDetailsByTerritory = GetModelMainReleaseDetailsByTerritory(nrm);

            if (mainReleaseDetailsByTerritory != null && mainReleaseDetailsByTerritory.DisplayArtist != null && mainReleaseDetailsByTerritory.DisplayArtist.Length > 0 && mainReleaseDetailsByTerritory.DisplayArtist[0] != null && mainReleaseDetailsByTerritory.DisplayArtist[0].Items != null && mainReleaseDetailsByTerritory.DisplayArtist[0].Items.Length > 0 && mainReleaseDetailsByTerritory.DisplayArtist[0].Items[0] != null && mainReleaseDetailsByTerritory.DisplayArtist[0].Items[0] is PartyName && ((PartyName)mainReleaseDetailsByTerritory.DisplayArtist[0].Items[0]).FullName != null)
            {
                ret = ((PartyName)mainReleaseDetailsByTerritory.DisplayArtist[0].Items[0]).FullName.Value;
            }

            return ret;
        }
        private string GetModelLabelName(NewReleaseMessage nrm)
        {
            string ret = null;

            ReleaseDetailsByTerritory mainReleaseDetailsByTerritory = GetModelMainReleaseDetailsByTerritory(nrm);

            if (mainReleaseDetailsByTerritory != null && mainReleaseDetailsByTerritory.LabelName != null && mainReleaseDetailsByTerritory.LabelName.Length > 0 && mainReleaseDetailsByTerritory.LabelName[0] != null)
            {
                ret = mainReleaseDetailsByTerritory.LabelName[0].Value;
            }

            return ret;
        }
        private string GetModelMessageId(NewReleaseMessage nrm)
        {
            string ret = null;

            if (nrm.MessageHeader != null)
            {
                ret = nrm.MessageHeader.MessageId;
            }

            return ret;
        }
        private string GetModelSenderPartyId(NewReleaseMessage nrm)
        {
            string ret = null;

            if (nrm.MessageHeader != null && nrm.MessageHeader.MessageSender != null && nrm.MessageHeader.MessageSender.PartyId != null && nrm.MessageHeader.MessageSender.PartyId.Length > 0 && nrm.MessageHeader.MessageSender.PartyId[0] != null)
            {
                ret = nrm.MessageHeader.MessageSender.PartyId[0].Value;
            }

            return ret;
        }
        private string GetModelSenderPartyName(NewReleaseMessage nrm)
        {
            string ret = null;

            if (nrm.MessageHeader != null && nrm.MessageHeader.MessageSender != null && nrm.MessageHeader.MessageSender.PartyName != null && nrm.MessageHeader.MessageSender.PartyName.FullName != null)
            {
                ret = nrm.MessageHeader.MessageSender.PartyName.FullName.Value;
            }

            return ret;
        }
        private string GetModelRecipientPartyId(NewReleaseMessage nrm)
        {
            string ret = null;

            if (nrm.MessageHeader != null && nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0] != null && nrm.MessageHeader.MessageRecipient[0].PartyId != null && nrm.MessageHeader.MessageRecipient[0].PartyId.Length > 0 && nrm.MessageHeader.MessageRecipient[0].PartyId[0] != null)
            {
                ret = nrm.MessageHeader.MessageRecipient[0].PartyId[0].Value;
            }

            return ret;
        }
        private string GetModelRecipientPartyName(NewReleaseMessage nrm)
        {
            string ret = null;

            if (nrm.MessageHeader != null && nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0] != null && nrm.MessageHeader.MessageRecipient[0].PartyName != null && nrm.MessageHeader.MessageRecipient[0].PartyName.FullName != null)
            {
                ret = nrm.MessageHeader.MessageRecipient[0].PartyName.FullName.Value;
            }

            return ret;
        }
        private DateTime GetModelMessageCreatedDateTime(NewReleaseMessage nrm)
        {
            DateTime ret = DateTime.MinValue;

            if (nrm != null && nrm.MessageHeader != null)
            {
                // TODO - provjeriti konverziju za razlicite timezone
                ret = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeToUtc(nrm.MessageHeader.MessageCreatedDateTime), DateTimeKind.Local);
            }

            return ret;
        }
        private DateTime GetModelDealStartDate(NewReleaseMessage nrm)
        {
            DateTime ret = DateTime.MinValue;

            DealList dl = nrm.DealList;
            if (dl != null && dl.ReleaseDeal != null && dl.ReleaseDeal.Length > 0 && dl.ReleaseDeal[0] != null && dl.ReleaseDeal[0].Deal != null && dl.ReleaseDeal[0].Deal.Length > 0 && dl.ReleaseDeal[0].Deal[0] != null && dl.ReleaseDeal[0].Deal[0].DealTerms != null && dl.ReleaseDeal[0].Deal[0].DealTerms.ValidityPeriod != null && dl.ReleaseDeal[0].Deal[0].DealTerms.ValidityPeriod.Length > 0 && dl.ReleaseDeal[0].Deal[0].DealTerms.ValidityPeriod[0] != null)
            {
                int index = -1;
                EventDate ed = null;
                var vp = dl.ReleaseDeal[0].Deal[0].DealTerms.ValidityPeriod[0];
                if (vp.ItemsElementName != null)
                {
                    for (int i = 0; i < vp.ItemsElementName.Length; i++)
                    {
                        if (vp.ItemsElementName[i] == ItemsChoiceType3.StartDate)
                        {
                            index = i;
                            break;
                        }
                    }
                }
                if (index != -1)
                {
                    if (vp.Items != null && vp.Items.Length > index && vp.Items[index] is EventDate)
                    {
                        ed = (EventDate) vp.Items[index];
                        ret = DateTime.ParseExact(ed.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                }
            }

            return ret;
        }
        private DateTime GetModelApproximateReleaseDate(NewReleaseMessage nrm)
        {
            DateTime ret = DateTime.MinValue;

            ReleaseDetailsByTerritory det = GetModelMainReleaseDetailsByTerritory(nrm);
            if (det != null && det.ReleaseDate != null)
            {
                ret = DateTime.ParseExact(det.ReleaseDate.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            return ret;
        }
        private UpdateIndicator GetModelUpdateIndicator(NewReleaseMessage nrm)
        {
            UpdateIndicator ret = UpdateIndicator.OriginalMessage;

            ret = nrm.UpdateIndicator;

            return ret;
        }
        private string GetModelMessageControlType(NewReleaseMessage nrm)
        {
            string ret = "LiveMessage";
            var mct = MessageControlType.LiveMessage;

            if (nrm != null & nrm.MessageHeader != null)
            {
                mct = nrm.MessageHeader.MessageControlType;
                if (mct == MessageControlType.TestMessage)
                {
                    ret = "TestMessage";
                }
            }
            
            return ret;
        }
        private string GetModelMainReleaseReferenceTitle(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);

            if (mainRelease != null && mainRelease.ReferenceTitle != null && mainRelease.ReferenceTitle.TitleText != null)
            {
                ret = mainRelease.ReferenceTitle.TitleText.Value;
            }

            return ret;
        }
        private string GetModelGenre(NewReleaseMessage nrm)
        {
            string ret = null;

            ReleaseDetailsByTerritory mainReleaseDetailsByTerritory = GetModelMainReleaseDetailsByTerritory(nrm);

            if (mainReleaseDetailsByTerritory != null && mainReleaseDetailsByTerritory.Genre != null && mainReleaseDetailsByTerritory.Genre != null && mainReleaseDetailsByTerritory.Genre.Length > 0 && mainReleaseDetailsByTerritory.Genre[0] != null && mainReleaseDetailsByTerritory.Genre[0].GenreText != null)
            {
                ret = mainReleaseDetailsByTerritory.Genre[0].GenreText.Value;
            }

            return ret;
        }
        private string GetModelSubGenre(NewReleaseMessage nrm)
        {
            string ret = null;

            ReleaseDetailsByTerritory mainReleaseDetailsByTerritory = GetModelMainReleaseDetailsByTerritory(nrm);

            if (mainReleaseDetailsByTerritory != null && mainReleaseDetailsByTerritory.Genre != null && mainReleaseDetailsByTerritory.Genre != null && mainReleaseDetailsByTerritory.Genre.Length > 0 && mainReleaseDetailsByTerritory.Genre[0] != null && mainReleaseDetailsByTerritory.Genre[0].SubGenre != null)
            {
                ret = mainReleaseDetailsByTerritory.Genre[0].SubGenre.Value;
            }

            return ret;
        }
        private string GetModelPLineText(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.PLine != null && mainRelease.PLine.Length > 0 && mainRelease.PLine[0] != null)
            {
                ret = mainRelease.PLine[0].PLineText;
            }

            return ret;
        }
        private string GetModelCLineText(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.CLine != null && mainRelease.CLine.Length > 0 && mainRelease.CLine[0] != null)
            {
                ret = mainRelease.CLine[0].CLineText;
            }

            return ret;
        }
        private string GetModelPLineReleseYear(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.PLine != null && mainRelease.PLine.Length > 0 && mainRelease.PLine[0] != null)
            {
                ret = mainRelease.PLine[0].Year;
            }

            return ret;
        }
        private string GetModelCLineReleseYear(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.CLine != null && mainRelease.CLine.Length > 0 && mainRelease.CLine[0] != null)
            {
                ret = mainRelease.CLine[0].Year;
            }

            return ret;
        }
        private string GetModelFrontCoverImageFileName(NewReleaseMessage nrm)
        {
            string ret = null;

            File imgFile = GetModelFrontCoverImageFile(nrm);
            if (imgFile != null && imgFile.ItemsElementName != null && imgFile.ItemsElementName.ToList().IndexOf( ItemsChoiceType6.FileName) >= 0 && imgFile.Items != null && imgFile.Items.Length > imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FileName))
            {
                ret = imgFile.Items[imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FileName)];
            }

            return ret;
        }
        private string GetModelFrontCoverImagePath(NewReleaseMessage nrm)
        {
            string ret = null;

            File imgFile = GetModelFrontCoverImageFile(nrm);
            if (imgFile != null && imgFile.ItemsElementName != null && imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FileName) >= 0 && imgFile.Items != null && imgFile.Items.Length > imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FilePath) && imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FilePath) != -1)
            {
                ret = imgFile.Items[imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FilePath)];
            }

            return ret;
        }
        private string GetModelFrontCoverImageHashSum(NewReleaseMessage nrm)
        {
            string ret = null;

            File imgFile = GetModelFrontCoverImageFile(nrm);
            if (imgFile != null && imgFile.HashSum != null )
            {
                ret = imgFile.HashSum.HashSum1;
            }

            return ret;
        }
        private int GetModelFrontCoverImageHeight_Materialized(NewReleaseMessage nrm)
        {
            int ret = 0;
            TechnicalImageDetails det = GetModelFrontCoverImageTechnicalImageDetails(nrm);
            if (det != null && det.ImageHeight != null)
            {
                ret = (int) det.ImageHeight.Value;
            }

            return ret;
        }
        private int GetModelFrontCoverImageWidth_Materialized(NewReleaseMessage nrm)
        {
            int ret = 0;
            TechnicalImageDetails det = GetModelFrontCoverImageTechnicalImageDetails(nrm);
            if (det != null && det.ImageWidth != null)
            {
                ret = (int)det.ImageWidth.Value;
            }

            return ret;
        }

        #region GetTrackModel
        private int GetModelTrackOrdinal(Release rel)
        {
            int ret = 0;
            if (rel != null)
            {
                ret = Convert.ToInt32(rel.ReleaseReference.FirstOrDefault().TrimStart('R'));
            }
            return ret;
        }
        private string GetModelTrackISRC(Release rel)
        {
            string ret = null;

            if (rel != null && rel.ReleaseId != null && rel.ReleaseId.Length > 0)
            {
                ret = rel.ReleaseId.FirstOrDefault().ISRC;
            }

            return ret;
        }
        private string GetModelTrackTitle(Release rel)
        {
            string ret = null;

            if (rel != null && rel.ReferenceTitle != null && rel.ReferenceTitle.TitleText != null)
            {
                ret = rel.ReferenceTitle.TitleText.Value;
            }

            return ret;
        }
        private string GetModelTrackResourceReleaseDate(SoundRecording sr)
        {
            string ret = null;

            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].ResourceReleaseDate != null)
            {
                ret = sr.SoundRecordingDetailsByTerritory[0].ResourceReleaseDate.Value;
            }

            return ret;
        }
        private string GetModelTrackPLineText(Release rel)
        {
            string ret = null;

            if (rel != null && rel.PLine != null && rel.PLine.Length > 0 && rel.PLine[0] != null)
            {
                ret = rel.PLine[0].PLineText;
            }

            return ret;
        }
        private string GetModelTrackCLineText(Release rel)
        {
            string ret = null;

            if (rel != null && rel.CLine != null && rel.CLine.Length > 0 && rel.CLine[0] != null)
            {
                ret = rel.CLine[0].CLineText;
            }

            return ret;
        }
        private string GetModelTrackPLineReleaseYear(Release rel)
        {
            string ret = null;

            if (rel != null && rel.PLine != null && rel.PLine.Length > 0 && rel.PLine[0] != null)
            {
                ret = rel.PLine[0].Year;
            }

            return ret;
        }
        private string GetModelTrackCLineReleaseYear(Release rel)
        {
            string ret = null;

            if (rel != null && rel.CLine != null && rel.CLine.Length > 0 && rel.CLine[0] != null)
            {
                ret = rel.CLine[0].Year;
            }

            return ret;
        }
        private string GetModelTrackGenre(Release rel)
        {
            string ret = null;

            if (rel != null && rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText != null)
            {
                ret = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText.Value;
            }

            return ret;
        }
        private string GetModelTrackSubGenre(Release rel)
        {
            string ret = null;

            if (rel != null && rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre != null)
            {
                ret = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre.Value;
            }

            return ret;
        }
        private string GetModelTrackMainArtist(SoundRecording sr)
        {
            string ret = null;

            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtist != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtist.Length > 0)
            {
                foreach (var artist in sr.SoundRecordingDetailsByTerritory[0].DisplayArtist)
                {
                    if (artist.ArtistRole != null)
                    {
                        foreach (var artistRole in artist.ArtistRole)
                        {
                            if (artistRole.Value == ArtistRole.MainArtist && artist.Items != null && artist.Items.Length > 0 && artist.Items[0] is PartyName && ((PartyName)artist.Items[0]).FullName != null) 
                            {
                                ret = ((PartyName)artist.Items[0]).FullName.Value;
                                break;
                            }
                        }
                        if (ret != null) break;
                    }
                }
            }

            return ret;
        }
        private string GetModelTrackDisplayArtistName(SoundRecording sr)
        {
            string ret = null;

            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtistName != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtistName.Length > 0)
            {
                ret = sr.SoundRecordingDetailsByTerritory[0].DisplayArtistName[0].Value;
            }

            return ret;
        }
        private string GetModelTrackProducer(SoundRecording sr)
        {
            string ret = null;

            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].ResourceContributor != null && sr.SoundRecordingDetailsByTerritory[0].ResourceContributor.Length > 0)
            {
                foreach (DetailedResourceContributor con in sr.SoundRecordingDetailsByTerritory[0].ResourceContributor)
                {
                    if (con.ResourceContributorRole != null)
                    {
                        foreach (var artistRole in con.ResourceContributorRole)
                        {
                            if (artistRole.Value == ResourceContributorRole.Producer && con.Items != null && con.Items.Length > 0 && con.Items[0] is PartyName && ((PartyName)con.Items[0]).FullName != null)
                            {
                                ret = ((PartyName)con.Items[0]).FullName.Value;
                                break;
                            }
                        }
                        if (ret != null) break;
                    }
                }
            }

            return ret;
        }
        private TechnicalSoundRecordingDetails GetModelTrackHelperTechnicalSoundRecordingDetails(SoundRecording sr)
        {
            TechnicalSoundRecordingDetails ret = null;

            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].TechnicalSoundRecordingDetails != null && sr.SoundRecordingDetailsByTerritory[0].TechnicalSoundRecordingDetails.Length > 0)
            {
                ret = sr.SoundRecordingDetailsByTerritory[0].TechnicalSoundRecordingDetails[0];
            }

            return ret;
        }
        private AudioCodecType GetModelTrackAudioCodecType(SoundRecording sr)
        {
            AudioCodecType ret = AudioCodecType.Unknown;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.AudioCodecType != null)
            {
                ret = det.AudioCodecType.Value;
            }
            
            return ret;
        }
        private int GetModelTrackNumberOfChannels(SoundRecording sr)
        {
            int ret = 0;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.NumberOfChannels != null)
            {
                int res = -1;
                int.TryParse(det.NumberOfChannels, out res);
                if (res != -1)
                {
                    ret = res;
                }
            }

            return ret;
        }
        private decimal GetModelTrackSamplingRate(SoundRecording sr)
        {
            decimal ret = 0;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.SamplingRate != null)
            {
                ret = det.SamplingRate.Value;
            }

            return ret;
        }
        private int GetModelTrackBitsPerSample(SoundRecording sr)
        {
            int ret = 0;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.BitsPerSample != null)
            {
                int res = -1;
                int.TryParse(det.BitsPerSample, out res);
                if (res != -1)
                {
                    ret = res;
                }
            }

            return ret;
        }
        private string GetModelTrackFileName(SoundRecording sr)
        {
            string ret = null;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.Items != null && det.Items.Length > 0 && det.Items[0] is File && ((File)det.Items[0]).ItemsElementName != null && ((File)det.Items[0]).ItemsElementName.Length > 0)
            {
                File f = (File) det.Items[0];
                int ix = f.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FileName);
                if (ix != -1)
                {
                    ret = f.Items[ix];
                }
            }

            return ret;
        }
        private string GetModelTrackFilePath(SoundRecording sr)
        {
            string ret = null;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.Items != null && det.Items.Length > 0 && det.Items[0] is File && ((File)det.Items[0]).ItemsElementName != null && ((File)det.Items[0]).ItemsElementName.Length > 0)
            {
                File f = (File)det.Items[0];
                int ix = f.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FilePath);
                if (ix != -1)
                {
                    ret = f.Items[ix];
                }
            }

            return ret;
        }
        private string GetModelTrackHashSum(SoundRecording sr)
        {
            string ret = null;

            TechnicalSoundRecordingDetails det = GetModelTrackHelperTechnicalSoundRecordingDetails(sr);

            if (det != null && det.Items != null && det.Items.Length > 0 && det.Items[0] is File && ((File)det.Items[0]).ItemsElementName != null && ((File)det.Items[0]).ItemsElementName.Length > 0)
            {
                File f = (File)det.Items[0];
                if (f.HashSum != null)
                {
                    ret = f.HashSum.HashSum1;
                }
            }

            return ret;
        }
        private List<Tuple<string, string>> GetModelTrackIndirectContributors(SoundRecording sr)
        {
            var ret = new List<Tuple<string, string>>();
            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor != null && sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor.Length > 0)
            {
                var cons = sr.SoundRecordingDetailsByTerritory[0].IndirectResourceContributor.ToList();
                for (int i = 0; i < cons.Count; i++)
                {
                    string name = null;
                    string role = null;
                    if (cons[i].Items != null && cons[i].Items.Length > 0 && cons[i].Items[0] is PartyName && ((PartyName)cons[i].Items[0]).FullName != null && ((PartyName)cons[i].Items[0]).FullName.Value != null)
                    {
                        name = ((PartyName)cons[i].Items[0]).FullName.Value;
                        if (cons[i].IndirectResourceContributorRole != null && cons[i].IndirectResourceContributorRole.Length > 0 && cons[i].IndirectResourceContributorRole[0] != null)
                        {
                            role = cons[i].IndirectResourceContributorRole[0].Value;
                            ret.Add(new Tuple<string, string>(name, role));
                        }
                    }
                }
            }
            return ret;
        }
        private List<Tuple<string, string>> GetModelTrackDisplayArtists(SoundRecording sr)
        {
            var ret = new List<Tuple<string, string>>();
            if (sr != null && sr.SoundRecordingDetailsByTerritory != null && sr.SoundRecordingDetailsByTerritory.Length > 0 && sr.SoundRecordingDetailsByTerritory[0] != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtist != null && sr.SoundRecordingDetailsByTerritory[0].DisplayArtist.Length > 0)
            {
                var cons = sr.SoundRecordingDetailsByTerritory[0].DisplayArtist.ToList();
                int firstMainArtistIndex = -1;
                for (int i = 0; i < cons.Count; i++)
                {
                    string name = null;
                    string role = null;
                    if (cons[i].Items != null && cons[i].Items.Length > 0 && cons[i].Items[0] is PartyName && ((PartyName)cons[i].Items[0]).FullName != null && ((PartyName)cons[i].Items[0]).FullName.Value != null)
                    {
                        name = ((PartyName)cons[i].Items[0]).FullName.Value;
                        if (cons[i].ArtistRole != null && cons[i].ArtistRole.Length > 0 && cons[i].ArtistRole[0] != null)
                        {
                            if (firstMainArtistIndex == -1 && cons[i].ArtistRole[0].Value == ArtistRole.MainArtist)
                            {
                                firstMainArtistIndex = i;
                            }
                            else
                            {
                                role = cons[i].ArtistRole[0].Value.ToString();
                                ret.Add(new Tuple<string, string>(name, role));
                            }
                        }
                    }
                }
            }
            return ret;
        }
        private void FillIndirectContributors(TrackModel m, List<Tuple<string, string>> nameRolePairs)
        {
            if (nameRolePairs.Count > 0)
            {
                m.Contributor1 = nameRolePairs[0].Item1;
                m.Contributor1Role = nameRolePairs[0].Item2;
            }
            if (nameRolePairs.Count > 1)
            {
                m.Contributor2 = nameRolePairs[1].Item1;
                m.Contributor2Role = nameRolePairs[1].Item2;
            }
            if (nameRolePairs.Count > 2)
            {
                m.Contributor3 = nameRolePairs[2].Item1;
                m.Contributor3Role = nameRolePairs[2].Item2;
            }
            if (nameRolePairs.Count > 3)
            {
                m.Contributor4 = nameRolePairs[3].Item1;
                m.Contributor4Role = nameRolePairs[3].Item2;
            }
            if (nameRolePairs.Count > 4)
            {
                m.Contributor5 = nameRolePairs[4].Item1;
                m.Contributor5Role = nameRolePairs[4].Item2;
            }
            if (nameRolePairs.Count > 5)
            {
                m.Contributor6 = nameRolePairs[5].Item1;
                m.Contributor6Role = nameRolePairs[5].Item2;
            }
        }

        private void FillDisplayArtists(TrackModel m, List<Tuple<string, string>> nameRolePairs)
        {
            if (nameRolePairs.Count > 0)
            {
                m.DisplayArtist1 = nameRolePairs[0].Item1;
                m.DisplayArtist1Role = nameRolePairs[0].Item2;
            }
            if (nameRolePairs.Count > 1)
            {
                m.DisplayArtist2 = nameRolePairs[1].Item1;
                m.DisplayArtist2Role = nameRolePairs[1].Item2;
            }
            if (nameRolePairs.Count > 2)
            {
                m.DisplayArtist3 = nameRolePairs[2].Item1;
                m.DisplayArtist3Role = nameRolePairs[2].Item2;
            }
            if (nameRolePairs.Count > 3)
            {
                m.DisplayArtist4 = nameRolePairs[3].Item1;
                m.DisplayArtist4Role = nameRolePairs[3].Item2;
            }
            if (nameRolePairs.Count > 4)
            {
                m.DisplayArtist5 = nameRolePairs[4].Item1;
                m.DisplayArtist5Role = nameRolePairs[4].Item2;
            }
            if (nameRolePairs.Count > 5)
            {
                m.DisplayArtist6 = nameRolePairs[5].Item1;
                m.DisplayArtist6Role = nameRolePairs[5].Item2;
            }
        }
        private int GetModelTrackDurationMin(SoundRecording sr)
        {
            int ret = 0;
            //sr.Duration = "PT" + track.DurationMin.ToString() + "M" + track.DurationSec.ToString() + "S";
            if (sr != null && sr.Duration != null && sr.Duration.StartsWith("PT"))
            {
                var sMin = sr.Duration.Substring(2, sr.Duration.IndexOf('M') - 2);
                ret = Convert.ToInt32(sMin);
            }
            return ret;
        }
        private int GetModelTrackDurationSec(SoundRecording sr)
        {
            int ret = 0;
            //sr.Duration = "PT" + track.DurationMin.ToString() + "M" + track.DurationSec.ToString() + "S";
            if (sr != null && sr.Duration != null && sr.Duration.StartsWith("PT"))
            {
                var sSec = sr.Duration.Substring(sr.Duration.IndexOf('M') + 1, sr.Duration.IndexOf('S') - sr.Duration.IndexOf('M') - 1);
                try
                {
                    ret = Convert.ToInt32(Convert.ToDecimal(sSec, CultureInfo.InvariantCulture));
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error reading track duration {0}", sr.Duration), ex);
                }
            }
            return ret;
        }
        private TrackModel GetModelTrack(NewReleaseMessage nrm, int trackIndex)
        {
            var ret = new TrackModel();
            SoundRecording sr = null;
            if (nrm.ResourceList != null && nrm.ResourceList.SoundRecording != null && nrm.ResourceList.SoundRecording.Length > trackIndex)
            {
                sr = nrm.ResourceList.SoundRecording[trackIndex];
            }
            Release rel = null;
            if (nrm.ReleaseList != null && nrm.ReleaseList.Release != null && nrm.ReleaseList.Release.Length > trackIndex + 1)
            {
                rel = nrm.ReleaseList.Release[trackIndex + 1];
            }

            ret.Ordinal = GetModelTrackOrdinal(rel);
            ret.ISRC = GetModelTrackISRC(rel);
            ret.Title = GetModelTrackTitle(rel);
            ret.DurationMin = GetModelTrackDurationMin(sr);
            ret.DurationSec = GetModelTrackDurationSec(sr);
            ret.Genre = GetModelTrackGenre(rel);
            ret.SubGenre = GetModelTrackSubGenre(rel);
            ret.ResourceReleaseDate = GetModelTrackResourceReleaseDate(sr);
            ret.PLineText = GetModelTrackPLineText(rel);
            ret.PLineReleaseYear = GetModelTrackPLineReleaseYear(rel);
            ret.CLineText = GetModelTrackCLineText(rel);
            ret.CLineReleaseYear = GetModelTrackCLineReleaseYear(rel);
            ret.MainArtist = GetModelTrackMainArtist(sr);
            ret.DisplayArtistName = GetModelTrackDisplayArtistName(sr);
            ret.Producer = GetModelTrackProducer(sr);
            ret.AudioCodec = GetModelTrackAudioCodecType(sr);
            ret.NumberOfChannels = GetModelTrackNumberOfChannels(sr);
            ret.SamplingRate = GetModelTrackSamplingRate(sr);
            ret.BitsPerSample = GetModelTrackBitsPerSample(sr);
            ret.FileName = GetModelTrackFileName(sr);
            ret.FilePath = GetModelTrackFilePath(sr);
            ret.FileHashSum_Materialized = GetModelTrackHashSum(sr);

            FillIndirectContributors(ret, GetModelTrackIndirectContributors(sr));
            FillDisplayArtists(ret, GetModelTrackDisplayArtists(sr));


            return ret;
        }
        #endregion
        private SortableBindingList<TrackModel> GetModelTracks(NewReleaseMessage nrm)
        {
            var ret = new SortableBindingList<TrackModel>();

            int nrOfTracks = 0;
            if (nrm.ResourceList != null && nrm.ResourceList.SoundRecording != null && nrm.ResourceList.SoundRecording.Length > 0)
            {
                nrOfTracks = nrm.ResourceList.SoundRecording.Length;
            }
            for (int i = 0; i < nrOfTracks; i++)
            {
                TrackModel track = GetModelTrack(nrm, i);
                ret.Add(track);
            }

            return ret;
        }
        private void GotModel(IXmlObject xmlObject, ref AudioAlbumModel ret)
        {
            if (xmlObject != null && xmlObject.FullFileName != null && System.IO.File.Exists(xmlObject.FullFileName))
            {
                XmlDocument doc = new XmlDocument();
                string xml = Generator.LoadXmlFile(xmlObject.FullFileName);
                doc.LoadXml(xml);

                string strMsgCreatedDateTime = "";
                try
                {
                    if (doc.SelectNodes(".//MessageHeader/MessageCreatedDateTime")[0] != null)
                    {
                        strMsgCreatedDateTime = doc.SelectNodes(".//MessageHeader/MessageCreatedDateTime")[0].InnerText;
                        ret.MessageCreatedDateTime = DateTime.SpecifyKind(TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(strMsgCreatedDateTime)), DateTimeKind.Local);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }
        }
        private AudioAlbumModel.eMusicService GetModelMusicService(string recipientPartyID)
        {
            AudioAlbumModel.eMusicService ret = AudioAlbumModel.eMusicService.Unknown;

            if (recipientPartyID == Settings.DeezerPartyID)
            {
                ret = AudioAlbumModel.eMusicService.Deezer;
            }
            else if (recipientPartyID == Settings.PandoraPartyID)
            {
                ret = AudioAlbumModel.eMusicService.Pandora;
            }
            else if (recipientPartyID == Settings.SoundCloudPartyID)
            {
                ret = AudioAlbumModel.eMusicService.SoundCloud;
            }

            return ret;
        }
        private AudioAlbumModel.eMusicService GetModelMusicService(NewReleaseMessage nrm)
        {
            string recipientPartyID = GetModelRecipientPartyId(nrm);

            return GetModelMusicService(recipientPartyID);
        }

        public IBindableModel GetModelFromXmlObject(IXmlObject xmlObject)
        {
            AudioAlbumModel ret = null;

            try
            {
                if (xmlObject != null)
                {
                    NewReleaseMessage nrm = (NewReleaseMessage)xmlObject;
                    ret = new AudioAlbumModel()
                    {
                        FullFileName = xmlObject.FullFileName
                    };
                    
                    ret.EAN = GetModelEAN(nrm);
                    ret.MainArtist = GetModelMainArtist(nrm);
                    ret.LabelName = GetModelLabelName(nrm);
                    ret.MessageID = GetModelMessageId(nrm);
                    ret.SenderPartyID = GetModelSenderPartyId(nrm);
                    ret.SenderPartyName = GetModelSenderPartyName(nrm);

                    ret.RecipientPartyID = GetModelRecipientPartyId(nrm);
                    ret.MusicService = GetModelMusicService(nrm);

                    ret.RecipientPartyName = GetModelRecipientPartyName(nrm);
                    ret.MessageCreatedDateTime = GetModelMessageCreatedDateTime(nrm);
                    ret.ApproximateReleaseDate = GetModelApproximateReleaseDate(nrm);
                    ret.DealStartDate = GetModelDealStartDate(nrm);
                    ret.UpdateIndicator = GetModelUpdateIndicator(nrm);
                    ret.MessageControlType = GetModelMessageControlType(nrm);
                    ret.MainReleaseReferenceTitle = GetModelMainReleaseReferenceTitle(nrm);
                    ret.Genre = GetModelGenre(nrm);
                    ret.SubGenre = GetModelSubGenre(nrm);
                    ret.PLineText = GetModelPLineText(nrm);
                    ret.PLineReleaseYear = GetModelPLineReleseYear(nrm);
                    ret.CLineText = GetModelCLineText(nrm);
                    ret.CLineReleaseYear = GetModelCLineReleseYear(nrm);
                    ret.FrontCoverImageFileName = GetModelFrontCoverImageFileName(nrm);
                    ret.FrontCoverImagePath = GetModelFrontCoverImagePath(nrm);
                    ret.FrontCoverImageFullFileName = ret.GetFullFileNameFromRelativePathAndFileName(ret.FrontCoverImagePath, ret.FrontCoverImageFileName);
                    ret.FrontCoverImageHashSum_Materialized = GetModelFrontCoverImageHashSum(nrm);
                    ret.FrontCoverImageHeight_Materialized = GetModelFrontCoverImageHeight_Materialized(nrm);
                    ret.FrontCoverImageWidth_Materialized = GetModelFrontCoverImageWidth_Materialized(nrm);
                    
                    ret.Tracks = GetModelTracks(nrm);
                    foreach (var track in ret.Tracks)
                    {
                        track.Parent = ret;
                    }

                    ret.DealList = nrm.DealList;
                    

                    GotModel(xmlObject, ref ret);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }

    }

}
