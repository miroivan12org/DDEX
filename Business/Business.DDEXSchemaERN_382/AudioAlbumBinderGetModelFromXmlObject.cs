using Business.DDEXFactory.Interfaces;
using Business.DDEXSchemaERN_382.Entities;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ret = nrm.MessageHeader.MessageCreatedDateTime;
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
        private string GetModelPCLineText(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.PLine != null && mainRelease.PLine.Length > 0 && mainRelease.PLine[0] != null)
            {
                ret = mainRelease.PLine[0].PLineText;
            }

            return ret;
        }
        private string GetModelReleseYear(NewReleaseMessage nrm)
        {
            string ret = null;

            Release mainRelease = GetModelMainRelease(nrm);
            if (mainRelease != null && mainRelease.PLine != null && mainRelease.PLine.Length > 0 && mainRelease.PLine[0] != null)
            {
                ret = mainRelease.PLine[0].Year;
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
            if (imgFile != null && imgFile.ItemsElementName != null && imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FileName) >= 0 && imgFile.Items != null && imgFile.Items.Length > imgFile.ItemsElementName.ToList().IndexOf(ItemsChoiceType6.FilePath))
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
                    ret.RecipientPartyName = GetModelRecipientPartyName(nrm);
                    ret.MessageCreatedDateTime = GetModelMessageCreatedDateTime(nrm);
                    ret.ApproximateReleaseDate = GetModelApproximateReleaseDate(nrm);
                    ret.UpdateIndicator = GetModelUpdateIndicator(nrm);
                    ret.MainReleaseReferenceTitle = GetModelMainReleaseReferenceTitle(nrm);
                    ret.Genre = GetModelGenre(nrm);
                    ret.SubGenre = GetModelSubGenre(nrm);
                    ret.PCLineText = GetModelPCLineText(nrm);
                    ret.ReleaseYear = GetModelReleseYear(nrm);
                    ret.FrontCoverImageFileName = GetModelFrontCoverImageFileName(nrm);
                    ret.FrontCoverImagePath = GetModelFrontCoverImagePath(nrm);
                    ret.FrontCoverImageFullFileName = ret.GetFullFileNameFromRelativePathAndFileName(ret.FrontCoverImagePath, ret.FrontCoverImageFileName);
                    ret.FrontCoverImageHashSum_Materialized = GetModelFrontCoverImageHashSum(nrm);
                    ret.FrontCoverImageHeight_Materialized = GetModelFrontCoverImageHeight_Materialized(nrm);
                    ret.FrontCoverImageWidth_Materialized = GetModelFrontCoverImageWidth_Materialized(nrm);
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }

        #region Comments
        //private void FillMainReleaseData(NewReleaseMessage nrm, AudioAlbumModel m)
        //{
        //    Release mainRelease = GetMainRelease(nrm);
        //    ReleaseDetailsByTerritory mainReleaseDetailsByTerritory = GetMainReleaseDetailsByTerritory(nrm);

        //    if
        //        (
        //            mainReleaseDetailsByTerritory != null &&
        //            mainReleaseDetailsByTerritory.LabelName != null &&
        //            mainReleaseDetailsByTerritory.LabelName[0] != null
        //        )
        //    {
        //        m.LabelName = mainReleaseDetailsByTerritory.LabelName[0].Value;
        //    }

        //    if
        //        (
        //            mainRelease != null &&
        //            mainRelease.ReferenceTitle != null &&
        //            mainRelease.ReferenceTitle.TitleText != null
        //        )
        //    {
        //        m.MainReleaseReferenceTitle = nrm.ReleaseList.Release[0].ReferenceTitle.TitleText.Value;
        //    }

        //    if
        //        (
        //            mainRelease != null && mainRelease.ReleaseDetailsByTerritory != null && mainRelease.ReleaseDetailsByTerritory[0] != null &&
        //            mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist != null && mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0] != null &&
        //            mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0].Items != null && mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0].Items[0] != null &&
        //            mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0].Items[0] is PartyName && ((PartyName)mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0].Items[0]).FullName != null
        //        )
        //    {
        //        m.MainArtist = ((PartyName)mainRelease.ReleaseDetailsByTerritory[0].DisplayArtist[0].Items[0]).FullName.Value;
        //    }
        //}
        //public IBindableModel GetModelFromXmlObject(IXmlObject xmlObject)
        //{
        //    AudioAlbumModel ret = null;
        //    try
        //    {
        //        ret = new AudioAlbumModel();
        //        NewReleaseMessage nrm = (NewReleaseMessage)xmlObject;

        //        FillMainReleaseData(nrm, ret);

        //        ret.FullFileName = xmlObject.FullFileName;

        //        if (nrm != null)
        //        {
        //            if (nrm.MessageHeader != null)
        //            {
        //                ret.MessageID = nrm.MessageHeader.MessageId;
        //                if (nrm.MessageHeader.MessageSender.PartyId.Length > 0)
        //                {
        //                    ret.SenderPartyID = nrm.MessageHeader.MessageSender.PartyId[0].Value;
        //                }
        //                if (nrm.MessageHeader.MessageSender.PartyName != null && nrm.MessageHeader.MessageSender.PartyName.FullName != null)
        //                {
        //                    ret.SenderPartyName = nrm.MessageHeader.MessageSender.PartyName.FullName.Value;
        //                }
        //                if (nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0].PartyId != null && nrm.MessageHeader.MessageRecipient[0].PartyId.Length > 0)
        //                {
        //                    ret.RecipientPartyID = nrm.MessageHeader.MessageRecipient[0].PartyId[0].Value;
        //                }
        //                if (nrm.MessageHeader.MessageRecipient != null && nrm.MessageHeader.MessageRecipient.Length > 0 && nrm.MessageHeader.MessageRecipient[0].PartyName != null && nrm.MessageHeader.MessageRecipient[0].PartyName.FullName != null)
        //                {
        //                    ret.RecipientPartyName = nrm.MessageHeader.MessageRecipient[0].PartyName.FullName.Value;
        //                }
        //                ret.MessageCreatedDateTime = nrm.MessageHeader.MessageCreatedDateTime;
        //                ret.UpdateIndicator = nrm.UpdateIndicator;

        //                if (nrm.ReleaseList != null && nrm.ReleaseList.Release != null && nrm.ReleaseList.Release.Length > 0 && nrm.ReleaseList.Release[0].ReleaseId != null && nrm.ReleaseList.Release[0].ReleaseId.Length > 0 && nrm.ReleaseList.Release[0].ReleaseId[0].ICPN != null)
        //                {
        //                    ret.EAN = nrm.ReleaseList.Release[0].ReleaseId[0].ICPN.Value;

        //                }
        //                if (nrm.ReleaseList != null && nrm.ReleaseList.Release != null && nrm.ReleaseList.Release.Any())
        //                {
        //                    ret.Tracks.RaiseListChangedEvents = false;

        //                    foreach (var rel in nrm.ReleaseList.Release.Where(x => !x.IsMainRelease))
        //                    {
        //                        var track = new TrackModel()
        //                        {
        //                            Ordinal = Convert.ToInt32(rel.ReleaseReference.FirstOrDefault().TrimStart('R')),
        //                            ISRC = rel.ReleaseId.FirstOrDefault().ISRC,
        //                            Title = rel.ReferenceTitle.TitleText.Value
        //                        };
        //                        if (rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText != null)
        //                        {
        //                            track.Genre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().GenreText.Value;
        //                        }
        //                        if (rel.ReleaseDetailsByTerritory != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre != null && rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre != null)
        //                        {
        //                            track.SubGenre = rel.ReleaseDetailsByTerritory.FirstOrDefault().Genre.FirstOrDefault().SubGenre.Value;
        //                        }

        //                        ret.Tracks.Add(track);
        //                    }
        //                    ret.Tracks.RaiseListChangedEvents = true;
        //                    ret.Tracks.ResetBindings();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return ret;
        //}
        #endregion
    }

}
