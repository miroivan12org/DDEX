using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.ViewModel
{
    public class UploadViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string FileName { get; set; }
    }
}