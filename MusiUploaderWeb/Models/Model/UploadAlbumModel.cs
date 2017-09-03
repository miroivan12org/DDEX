using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.Model
{
    public class UploadAlbumModel
    {
        public string EAN { get; set; }
        public string Title { get; set; }
        public string UpdateIndicator { get; set; }
        public string MainArtist { get; set; }
        public string Label { get; set; }
        public string Genre { get; set; }
        public string SubGenre { get; set; }
        public DateTime ApproximateReleaseDate { get; set; }
        public string PLineText { get; set; }
        public string PLineReleaseYear { get; set; }
        public string CLineText { get; set; }
        public string CLineReleaseYear { get; set; }
        public string MessageID { get; set; }
        public string SenderPartyID { get; set; }
        public string SenderPartyName { get; set; }
        public string RecipientPartyID { get; set; }
        public string RecipientPartyName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public FileObj[] FileList { get; set; }

    }

    public class FileObj
    {
        public Guid Guid { get; set; }
        public int Ordinal { get; set; }
        public string ISRC { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string SubGenre { get; set; }
        public string PLineText { get; set; }
        public string PLineReleaseYear { get; set; }
        public string ResourceReleaseDate { get; set; }
        public string CLineText { get; set; }
        public string CLineReleaseYear { get; set; }
        public int DurationMin { get; set; }
        public int DurationSec { get; set; }
        public string MainArtist { get; set; }
        public string Producer { get; set; }
        public int AudioCode { get; set; }
        public int NumberOfChannels { get; set; }
        public decimal SamplingRate { get; set; }
        public int BitsPerSample { get; set; }
        public string FileName { get; set; }
        public string Contributor { get; set; }
        public string ContributorRole { get; set; }
    }
}