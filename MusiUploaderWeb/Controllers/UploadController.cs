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
        public ActionResult UploadForm([FromJson]UploadAlbumUsersModel model)
        {
            return View("Index");
        }
        
        public JsonResult DeleteTrack(string ID, string fileName)
        {
            var path = Path.Combine(Server.MapPath("~/App_Data/"), ID + Path.GetExtension(fileName));
            System.IO.File.Delete(path);
            return Json(ID, JsonRequestBehavior.AllowGet);
        }

        public class Language
        {
            public int ID { get; set; }
            public string LanguageName { get; set; }
        }

        public class Role
        {
            public int ID { get; set; }
            public string RoleName { get; set; }
        }

        public class Genre
        {
            public int ID { get; set; }
            public string GenreName { get; set; }
        }

        public class Year
        {
            public int ID { get; set; }
            public string OnlyYear { get; set; }
        }

        public class Publisher
        {
            public int ID { get; set; }
            public string PublisherName { get; set; }
        }

        public JsonResult GetPublishers()
        {
            var publishers = new List<Publisher>();
            var one = new Publisher
            {
                ID = 1,
                PublisherName = "Ivan"
            };

            var longplay = new Publisher
            {
                ID = 2,
                PublisherName = "Longplay"
            };

            publishers.Add(one);
            publishers.Add(longplay);

            return Json(publishers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYears ()
        {
            var years = new List<Year>();
            var twoseventin = new Year
            {
                ID = 1,
                OnlyYear = "2017"
            };

            var twosixteen = new Year
            {
                ID = 2,
                OnlyYear = "2016"
            };

            years.Add(twoseventin);
            years.Add(twosixteen);

            return Json(years, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGenres()
        {
            var genres = new List<Genre>();
            var rock = new Genre
            {
                ID = 1,
                GenreName = "Rock"
            };

            var pop = new Genre
            {
                ID = 1,
                GenreName = "POP"
            };

            genres.Add(rock);
            genres.Add(pop);

            return Json(genres, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoles()
        {
            var roles = new List<Role>();
            var main = new Role
            {
                ID = 1,
                RoleName = "Main artist"
            };

            var versus = new Role
            {
                ID = 2,
                RoleName = "Versus"
            };

            roles.Add(main);
            roles.Add(versus);

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRolesForContributors()
        {
            var roles = new List<Role>();
            var main = new Role
            {
                ID = 1,
                RoleName = "Composer"
            };

            var versus = new Role
            {
                ID = 2,
                RoleName = "Lyricist"
            };

            roles.Add(main);
            roles.Add(versus);

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLanguages()
        {
            var languages = new List<Language>();
            var language = new Language
            {
                LanguageName = "English",
                ID = 1
            };

            var language2 = new Language
            {
                LanguageName = "Croatian",
                ID = 2
            };

            languages.Add(language);
            languages.Add(language2);

            return Json(languages, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<string> UploadFilePost()
        {
            var handler = new FileUploadHelper();
            var ID = Guid.NewGuid();

            UploadedFile trackModel = handler.GetFileFromRequest(this.Request);
            var path = Path.Combine(Server.MapPath("~/App_Data/"), ID + Path.GetExtension(trackModel.FileName));

            System.IO.File.WriteAllBytes(path, trackModel.Contents);

            return ID.ToString();
        }
    }
}