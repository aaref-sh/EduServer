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
    public class MarksController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Marks/
        public ActionResult Index()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            var marks = db.marks.Include(m => m.material).Include(m => m.student);
            return View(marks.ToList());
        }

        // GET: /Marks/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // GET: /Marks/Create
        public ActionResult Create()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name");
            ViewBag.student_id = new SelectList(db.students, "Id", "fullname");
            return View();
        }

        // POST: /Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,student_id,material_id,mark1")] mark mark)
        {
            if (ModelState.IsValid)
            {
                db.marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", mark.material_id);
            ViewBag.student_id = new SelectList(db.students, "Id", "fullname", mark.student_id);
            return View(mark);
        }

        // GET: /Marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", mark.material_id);
            ViewBag.student_id = new SelectList(db.students, "Id", "fullname", mark.student_id);
            return View(mark);
        }

        // POST: /Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,student_id,material_id,mark1")] mark mark)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", mark.material_id);
            ViewBag.student_id = new SelectList(db.students, "Id", "fullname", mark.student_id);
            return View(mark);
        }

        // GET: /Marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mark mark = db.marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        // POST: /Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mark mark = db.marks.Find(id);
            db.marks.Remove(mark);
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
