using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.Model
{
    public class UploadedFile
    {
        public int FileSize { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Contents { get; set; }
        public string FileData { get; set; }
    }
}