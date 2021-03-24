using EduServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduServer.Controllers
{
    public class LoginController : Controller
    {
        serdbEntities2 db = new serdbEntities2();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string submit, FormCollection col)
        {
            string name = col[1], pass = col[2];
            List<teacher> tl = (from x in db.teachers where x.name == name && x.password == pass select x).ToList();
            if (tl.Count > 0)
            {
                Session["logged"] = "1";
                return RedirectToAction("Index", "Home", null);
            }
            return View();
        }
	}
}