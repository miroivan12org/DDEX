using Business.DDEXFactory.Intefaces;
using Business.DDEXFactory.Interfaces;
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
            ApproximateReleaseDate = DateTime.Now;
            DealStartDate = DateTime.Now;
        }
        public enum eDealType
        {
            Standard = 0
        }

        public enum eMusicService
        {
            Unknown = 0,
            Deezer = 1,
            Pandora = 2,
            SoundCloud = 3
        }
        [NotNull, DefaultValue(eMusicService.Unknown)]
        public eMusicService MusicService { get { return Get<eMusicService>(); } set { Set(value); } }
        public eDealType DealType { get { return Get<eDealType>(); } set { Set(value); } }
        public DateTime DealStartDate { get { return Get<DateTime>(); } set { Set(value); } }
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
        public string PLineText { get { return Get<string>(); } set { Set(value); } }
        public string PLineReleaseYear { get { return Get<string>(); } set { Set(value); } }
        public string CLineText { get { return Get<string>(); } set { Set(value); } }
        public string CLineReleaseYear { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImageFullFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImageFileName { get { return Get<string>(); } set { Set(value); } }
        public string FrontCoverImagePath { get { return Get<string>(); } set { Set(value); } }
        public ImageCodecType FrontCoverImageCodecType { get { return Get<ImageCodecType>(); } set { Set(value); } }
        public string FrontCoverImageHashSum_Materialized { get { return Get<string>(); } set { Set(value); } }
        public int FrontCoverImageHeight_Materialized { get { return Get<int>(); } set { Set(value); } }
        public int FrontCoverImageWidth_Materialized { get { return Get<int>(); } set { Set(value); } }        
        public SortableBindingList<TrackModel> Tracks { get; set; } = new SortableBindingList<TrackModel>();

        public DealList DealList { get; set; }

        public string GetFullFileNameFromRelativePathAndFileName(string relativePath, string fileName)
        {
            string ret = null;

            if (relativePath != null && fileName != null)
            {
                string dir = System.IO.Path.GetDirectoryName(FullFileName);
                ret = dir + @"\" + relativePath.TrimEnd('/') + @"\" + fileName;
            }

            return ret;
        }
        public void ComputeMaterialized()
        {
            FrontCoverImageFullFileName = GetFullFileNameFromRelativePathAndFileName(FrontCoverImagePath, FrontCoverImageFileName);
            if (System.IO.File.Exists(FrontCoverImageFullFileName))
            {
                using (var im = System.Drawing.Image.FromFile(FrontCoverImageFullFileName))
                {
                    if (im.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    {
                        FrontCoverImageCodecType = ImageCodecType.JPEG;
                    }
                    else if (im.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    {
                        FrontCoverImageCodecType = ImageCodecType.PNG;
                    }
                    else if (im.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    {
                        FrontCoverImageCodecType = ImageCodecType.GIF;
                    }
                    else if (im.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Tiff.Guid)
                    {
                        FrontCoverImageCodecType = ImageCodecType.TIFF;
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
                FrontCoverImageHashSum_Materialized = null;
            }

            foreach (TrackModel track in Tracks)
            {
                track.ComputeMaterialized();
            }
        }
        public override bool IsValid(out string message)
        {
            bool isValid = base.IsValid(out message);
            if (isValid)
            {
                string name = CalculateFrontCoverImageFileName();
                if (!Equals(name.ToUpper(), FrontCoverImageFileName.Substring(0, FrontCoverImageFileName.LastIndexOf('.')).ToUpper()))
                {
                    isValid = false;
                    message = string.Format("FrontCoverImageFileName not equal to {0}.", CalculateFrontCoverImageFileName());
                }
            }

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
        public string CalculateFrontCoverImageFileName()
        {
            string ret = "";

            ret = EAN;

            return ret;
        }        
    }
}
