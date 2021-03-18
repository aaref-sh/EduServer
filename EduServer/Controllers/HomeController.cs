using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public FilePathResult Download()
        {
            return File(Server.MapPath("~/docs/a.png"), "multipart/form-data", "a.png");
        }
    }
}
