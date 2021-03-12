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
    public class TimesController : Controller
    {
        private serdbEntities1 db = new serdbEntities1();

        // GET: /Times/
        public ActionResult Index()
        {
            return View(db.lecture_at.ToList());
        }

        // GET: /Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture_at lecture_at = db.lecture_at.Find(id);
            if (lecture_at == null)
            {
                return HttpNotFound();
            }
            return View(lecture_at);
        }

        // GET: /Times/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Times/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,time_at")] lecture_at lecture_at)
        {
            if (ModelState.IsValid)
            {
                db.lecture_at.Add(lecture_at);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lecture_at);
        }

        // GET: /Times/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture_at lecture_at = db.lecture_at.Find(id);
            if (lecture_at == null)
            {
                return HttpNotFound();
            }
            return View(lecture_at);
        }

        // POST: /Times/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,time_at")] lecture_at lecture_at)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture_at).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecture_at);
        }

        // GET: /Times/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture_at lecture_at = db.lecture_at.Find(id);
            if (lecture_at == null)
            {
                return HttpNotFound();
            }
            return View(lecture_at);
        }

        // POST: /Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lecture_at lecture_at = db.lecture_at.Find(id);
            db.lecture_at.Remove(lecture_at);
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
