using MusiUploaderWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Helpers
{
    public class FileUploadHelper
    {
        public UploadedFile GetFileFromRequest (HttpRequestBase request)
        {
            string fileName = null;
            string fileType = null;
            string fileData = null;
            byte[] fileContents = null;

            if (request.ContentLength > 0)
            {
                // Using FileAPI the content is in Request.InputStream!!!!
                fileContents = new byte[request.ContentLength];
                request.InputStream.Read(fileContents, 0, request.ContentLength);
                fileName = request.Headers["X-File-Name"];
                fileType = request.Headers["X-File-Type"];
                fileData = request.Headers["X-File-Data"];
            }

            return new UploadedFile()
            {
                FileName = fileName,
                ContentType = fileType,
                FileSize = fileContents != null ? fileContents.Length : 0,
                Contents = fileContents,
                FileData = fileData
            };
        }
    }
}