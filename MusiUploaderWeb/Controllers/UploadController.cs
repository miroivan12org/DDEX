using MusiUploaderWeb.Helpers;
using MusiUploaderWeb.Helpers.Attributes;
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

        [HttpPost]
        public ActionResult UploadForm([FromJson]UploadAlbumModel model)
        {
            return View("Index");
        }
        
        public JsonResult DeleteTrack(string guid, string fileName)
        {
            var path = Path.Combine(Server.MapPath("~/App_Data/"), guid + Path.GetExtension(fileName));
            System.IO.File.Delete(path);
            return Json(guid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<string> UploadFilePost()
        {
            var handler = new FileUploadHelper();
            var guid = Guid.NewGuid();

            UploadedFile fileObj = handler.GetFileFromRequest(this.Request);
            var path = Path.Combine(Server.MapPath("~/App_Data/"), guid + Path.GetExtension(fileObj.FileName));


            System.IO.File.WriteAllBytes(path, fileObj.Contents);

            return guid.ToString();
        }
    }
}