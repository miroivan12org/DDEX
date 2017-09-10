using MusiUploaderWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace MusiUploaderWeb.Controllers
{
    public class XmlGeneratorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}