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
        public IBindableModel GetModelFromXmlObject(IXmlObject xmlObject)
        {
            AudioAlbumModel ret = null;
            try
            {
                ret = new AudioAlbumModel();
                NewReleaseMessage nrm = (NewReleaseMessage)xmlObject;
                if
                    (
                        nrm.ReleaseList != null &&
                        nrm.ReleaseList.Release != null &&
                        nrm.ReleaseList.Release[0] != null &&
                        nrm.ReleaseList.Release[0].ReleaseDetailsByTerritory != null &&
                        nrm.ReleaseList.Release[0].ReleaseDetailsByTerritory[0] != null &&
                        nrm.ReleaseList.Release[0].ReleaseDetailsByTerritory[0].LabelName != null &&
                        nrm.ReleaseList.Release[0].ReleaseDetailsByTerritory[0].LabelName[0] != null
                    )
                {
                    ret.LabelName = nrm.ReleaseList.Release[0].ReleaseDetailsByTerritory[0].LabelName[0].Value;
                }
                    
                ret.FullFileName = xmlObject.FullFileName;
                
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
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }

    }
}
