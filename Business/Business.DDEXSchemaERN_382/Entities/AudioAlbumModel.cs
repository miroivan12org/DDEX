using Business.DDEXFactory.Intefaces;
using Business.DDEXSchemaERN_382.BindingObjects;
using Business.DDEXSchemaERN_382.Schema;
using System;
using System.ComponentModel;

namespace Business.DDEXSchemaERN_382.Entities
{
    
    public class AudioAlbumModel: BindableModel
    {
        public AudioAlbumModel()
        {
            MessageCreatedDateTime = DateTime.Now;
        }
        public string FullFileName { get { return Get<string>(); } set { Set(value); } }
        public string EAN { get { return Get<string>(); } set { Set(value); } }
        public string MessageID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyName { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyName { get { return Get<string>(); } set { Set(value); } }
        public DateTime MessageCreatedDateTime { get { return Get<DateTime>(); } set { Set(value); } }
        public UpdateIndicator UpdateIndicator { get { return Get<UpdateIndicator>(); } set { Set(value); } }
        public string MainReleaseReferenceTitle { get { return Get<string>(); } set { Set(value); } }

        public string FrontCoverImageFullFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImageFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImagePath { get { return Get<string>(); } set { Set(value); } }
        public ImageCodecType FrontCoverImageCodecType { get { return Get<ImageCodecType>(); } set { Set(value); } }
        public string FrontCoverImageHashSum_Materialized { get { return Get<string>(); } set { Set(value); } }

        public int FrontCoverImageHeight_Materialized { get { return Get<int>(); } set { Set(value); } }
        public int FrontCoverImageWidth_Materialized { get { return Get<int>(); } set { Set(value); } }

        public SortableBindingList<TrackModel> Tracks { get; set; } = new SortableBindingList<TrackModel>();

        public void ComputeMaterialized()
        {
            if (System.IO.File.Exists(FrontCoverImageFullFileName))
            {
                using (var im = System.Drawing.Image.FromFile(FrontCoverImageFullFileName))
                {
                    if (im.RawFormat == System.Drawing.Imaging.ImageFormat.Jpeg)
                    {
                        FrontCoverImageCodecType = ImageCodecType.JPEG;
                    }
                    else 
                    {
                        FrontCoverImageCodecType = ImageCodecType.Unknown;
                    }
                    FrontCoverImageHeight_Materialized = im.Size.Height;
                    FrontCoverImageWidth_Materialized = im.Size.Width;
                }

                FrontCoverImageHashSum_Materialized = DDEXFactory.Helpers.FilesHelper.GetMD5HashSum(FrontCoverImageFullFileName);
            }
        }
    }
}
