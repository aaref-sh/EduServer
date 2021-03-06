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
    public class LecturesController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Lectures/
        public ActionResult Index()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            var lectures = db.lectures.Include(l => l.dayinweek1).Include(l => l.hall).Include(l => l.lecture_at).Include(l => l.material).Include(l => l.specialization);
            return View(lectures.ToList());
        }

        // GET: /Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: /Lectures/Create
        public ActionResult Create()
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname");
            ViewBag.hall_id = new SelectList(db.halls, "id", "name");
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at");
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name");
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name");
            return View();
        }

        // POST: /Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,year,specialization_id,clas,lecture_at_id,dayinweek,hall_id,material_id")] lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.lectures.Add(lecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            ViewBag.hall_id = new SelectList(db.halls, "id", "name", lecture.hall_id);
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", lecture.material_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            return View(lecture);
        }

        // GET: /Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            ViewBag.hall_id = new SelectList(db.halls, "id", "name", lecture.hall_id);
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", lecture.material_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            return View(lecture);
        }

        // POST: /Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,year,specialization_id,clas,lecture_at_id,dayinweek,hall_id,material_id")] lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            ViewBag.hall_id = new SelectList(db.halls, "id", "name", lecture.hall_id);
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.material_id = new SelectList(db.materials, "id", "material_name", lecture.material_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            return View(lecture);
        }

        // GET: /Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["logged"] == null) return RedirectToAction("Index", "login", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: /Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lecture lecture = db.lectures.Find(id);
            db.lectures.Remove(lecture);
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
