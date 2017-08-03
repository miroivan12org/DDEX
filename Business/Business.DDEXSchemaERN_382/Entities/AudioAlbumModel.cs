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
        public string MainArtist { get { return Get<string>(); } set { Set(value); } }
        public string LabelName { get { return Get<string>(); } set { Set(value); } }
        public string MessageID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyID { get { return Get<string>(); } set { Set(value); } }
        public string SenderPartyName { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyID { get { return Get<string>(); } set { Set(value); } }
        public string RecipientPartyName { get { return Get<string>(); } set { Set(value); } }
        public DateTime MessageCreatedDateTime { get { return Get<DateTime>(); } set { Set(value); } }
        public DateTime ApproximateReleaseDate { get { return Get<DateTime>(); } set { Set(value); } }
        public UpdateIndicator UpdateIndicator { get { return Get<UpdateIndicator>(); } set { Set(value); } }
        public string MainReleaseReferenceTitle { get { return Get<string>(); } set { Set(value); } }
        public string Genre { get { return Get<string>(); } set { Set(value); } }
        public string SubGenre { get { return Get<string>(); } set { Set(value); } }
        public string PCLineText { get { return Get<string>(); } set { Set(value); } }
        public string ReleaseYear { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImageFullFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImageFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImagePath { get { return Get<string>(); } set { Set(value); } }
        public ImageCodecType FrontCoverImageCodecType { get { return Get<ImageCodecType>(); } set { Set(value); } }
        public string FrontCoverImageHashSum_Materialized { get { return Get<string>(); } set { Set(value); } }
        public int FrontCoverImageHeight_Materialized { get { return Get<int>(); } set { Set(value); } }
        public int FrontCoverImageWidth_Materialized { get { return Get<int>(); } set { Set(value); } }        
        public SortableBindingList<TrackModel> Tracks { get; set; } = new SortableBindingList<TrackModel>();

        public string GetFullFileNameFromRelativePathAndFileName(string relativePath, string fileName)
        {
            string ret = "";

            string dir = System.IO.Path.GetDirectoryName(FullFileName);
            ret = dir + @"\" + relativePath.TrimEnd('/') + @"\" + fileName;

            return ret;
        }
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
            else
            {
                FrontCoverImageHeight_Materialized = 0;
                FrontCoverImageWidth_Materialized = 0;
                FrontCoverImageCodecType = ImageCodecType.Unknown;
            }
        }
        public override bool IsValid(out string message)
        {
            bool isValid = base.IsValid(out message);
            if (isValid)
            {
                foreach (var track in Tracks)
                {
                    isValid = track.IsValid(out message);
                    if (!isValid)
                    {
                        break;
                    }
                }
            }

            return isValid;
        }
    }
}
