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
    public class MaterialsController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Materials/
        public ActionResult Index()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            return View(db.materials.ToList());
        }

        // GET: /Materials/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: /Materials/Create
        public ActionResult Create()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            return View();
        }

        // POST: /Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,material_name")] material material)
        {
            if (ModelState.IsValid)
            {
                db.materials.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(material);
        }

        // GET: /Materials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: /Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,material_name")] material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(material);
        }

        // GET: /Materials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.materials.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: /Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            material material = db.materials.Find(id);
            db.materials.Remove(material);
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
