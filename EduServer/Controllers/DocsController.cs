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
    public class DocsController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Docs/
        public ActionResult Index()
        {
            var docs = db.docs.Include(d => d.teacher);
            return View(docs.ToList());
        }

        // GET: /Docs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doc doc = db.docs.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        // GET: /Docs/Create
        public ActionResult Create()
        {
            ViewBag.owner = new SelectList(db.teachers, "Id", "name");
            return View();
        }

        // POST: /Docs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,path,owner")] doc doc)
        {
            if (ModelState.IsValid)
            {
                db.docs.Add(doc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.owner = new SelectList(db.teachers, "Id", "name", doc.owner);
            return View(doc);
        }

        // GET: /Docs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doc doc = db.docs.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            ViewBag.owner = new SelectList(db.teachers, "Id", "name", doc.owner);
            return View(doc);
        }

        // POST: /Docs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,path,owner")] doc doc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.owner = new SelectList(db.teachers, "Id", "name", doc.owner);
            return View(doc);
        }

        // GET: /Docs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            doc doc = db.docs.Find(id);
            if (doc == null)
            {
                return HttpNotFound();
            }
            return View(doc);
        }

        // POST: /Docs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            doc doc = db.docs.Find(id);
            db.docs.Remove(doc);
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
