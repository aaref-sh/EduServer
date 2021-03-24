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
    public class HallsController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Halls/
        public ActionResult Index()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            return View(db.halls.ToList());
        }

        // GET: /Halls/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: /Halls/Create
        public ActionResult Create()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            return View();
        }

        // POST: /Halls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name")] hall hall)
        {
            if (ModelState.IsValid)
            {
                db.halls.Add(hall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hall);
        }

        // GET: /Halls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: /Halls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name")] hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hall);
        }

        // GET: /Halls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hall hall = db.halls.Find(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: /Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hall hall = db.halls.Find(id);
            db.halls.Remove(hall);
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
