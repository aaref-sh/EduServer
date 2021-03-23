using EduServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduServer.Controllers
{
    public class HomeController : Controller
    {
        serdbEntities2 db = new serdbEntities2();
        public ActionResult Index()
        {
            ViewBag.Title = "الرئيسية";

            return View();
        }
        public FilePathResult Download(int id)
        {
            doc d = (from x in db.docs where x.id == id select x).First();
            return File(d.path, "multipart/form-data", d.path.Split('/').Last());
           
        }
    }
}
