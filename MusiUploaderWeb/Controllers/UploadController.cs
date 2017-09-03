using MusiUploaderWeb.Helpers;
using MusiUploaderWeb.Models.Model;
using MusiUploaderWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusiUploaderWeb.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFile(UploadViewModel model)
        {
            var file = model.File;

            return View(model);
        }

        [HttpPost]
        public async Task<string> UploadFilePost()
        {
            var handler = new FileUploadHelper();

            UploadedFile fileObj = handler.GetFileFromRequest(this.Request);
            var path = Path.Combine(Server.MapPath("~/App_Data/"), Guid.NewGuid() + Path.GetExtension(fileObj.FileName));


            System.IO.File.WriteAllBytes(path, fileObj.Contents);
            var message = "File uploaded";

            return message;
        }
    }
}