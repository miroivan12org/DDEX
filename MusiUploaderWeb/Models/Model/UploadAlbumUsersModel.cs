using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.Model
{
    public class UploadAlbumUsersModel
    {
        public Guid AlbumID { get; set; }
        //basic info
        public string Language { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public Artist[] Artists { get; set; }
        public string MainGenre { get; set; }
        public string SubGenre { get; set; }
        //tracks info
        public TrackModel[] TrackList { get; set; }
        //release info
        public string LabelName { get; set; }
        public string CatalogueNumber { get; set; }
        public string Barcode { get; set; }
        public DateTime CopyrightYear { get; set; }
        public string CopyRightRecording { get; set; }
        public DateTime OriginalRelease { get; set; }
        public DateTime DigitalReleaseDate { get; set; }
        //cover info
        public string CoverID { get; set; }
        public string ArtistName { get; set; }
        public DateTime CopyrightArtworkYear { get; set; }
    }

    public class BasicDetails
    {
        public string Language { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public Artist[] Artists { get; set; }
        public string MainGenre { get; set; }
        public string SubGenre { get; set; }

    }

    public class ReleaseDetail
    {
        public string LabelName { get; set; }
        public string CatalogueNumber { get; set; }
        public string Barcode { get; set; }
        public DateTime CopyrightYear { get; set; }
        public string CopyRightRecording { get; set; }
        public DateTime OriginalRelease { get; set; }
        public DateTime DigitalReleaseDate { get; set; }
    }

    public class CoverInfo
    {
        public Guid CoverID { get; set; }
        public string ArtistName { get; set; }
        public DateTime CopyrightArtworkYear { get; set; }
    }
    
    public class TrackModel
    {
        public Guid TrackId { get; set; }
        public string TrackName { get; set; }
        public string Version { get; set; }
        public string ISRC { get; set; }
        public DateTime CopyrightYear { get; set; }
        public string CopyrightHolder { get; set; }
        public string TrackArtist { get; set; }
        public Artist[] Artists { get; set; }
        public string[] Publishers { get; set; }
        public Contributor[] Contributors { get; set; }
        public bool CoverVersion { get; set; }
        public bool ExplicitContent { get; set; }
        public bool LiveVersion { get; set; }
        public bool Medley { get; set; }
    }

    public class Artist
    {
        public int SelectedRole { get; set; }
        public string ArtistName { get; set; }
    }

    public class Contributor
    {
        public int SelectedRole { get; set; }
        public string ContributorName { get; set; }
        public string Publisher { get; set; }
    }
}