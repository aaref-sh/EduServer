using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EduServer.Models;

namespace EduServer.Controllers
{
    public class NotificationsController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Notifications/
        public ActionResult Index()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            var notifications = db.notifications.Include(n => n.teacher);
            return View(notifications.ToList());
        }

        // GET: /Notifications/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // GET: /Notifications/Create
        public ActionResult Create()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            ViewBag.author = new SelectList(db.teachers, "Id", "name");
            return View();
        }

        // POST: /Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,author,title,description")] notification notification)
        {
            if (ModelState.IsValid)
            {
                notification.author = (from x in db.teachers where x.name == "شؤون الطلاب" select x.Id).First();
                db.notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author = new SelectList(db.teachers, "Id", "name", notification.author);
            return View(notification);
        }

        // GET: /Notifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            ViewBag.author = new SelectList(db.teachers, "Id", "name", notification.author);
            return View(notification);
        }

        // POST: /Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,author,title,description")] notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author = new SelectList(db.teachers, "Id", "name", notification.author);
            return View(notification);
        }

        // GET: /Notifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notification notification = db.notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: /Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            notification notification = db.notifications.Find(id);
            db.notifications.Remove(notification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
