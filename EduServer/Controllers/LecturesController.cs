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
            var lectures = db.lectures.Include(l => l.lecture_at).Include(l => l.specialization).Include(l => l.dayinweek1);
            return View(lectures.ToList());
        }

        // GET: /Lectures/Details/5
        public ActionResult Details(int? id)
        {
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
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at");
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name");
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname");
            return View();
        }

        // POST: /Lectures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,name,year,specialization_id,clas,lecture_at_id,dayinweek")] lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.lectures.Add(lecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            return View(lecture);
        }

        // GET: /Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lecture lecture = db.lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            return View(lecture);
        }

        // POST: /Lectures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,name,year,specialization_id,clas,lecture_at_id,dayinweek")] lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lecture_at_id = new SelectList(db.lecture_at, "Id", "time_at", lecture.lecture_at_id);
            ViewBag.specialization_id = new SelectList(db.specializations, "Id", "name", lecture.specialization_id);
            ViewBag.dayinweek = new SelectList(db.dayinweeks, "id", "dayname", lecture.dayinweek);
            return View(lecture);
        }

        // GET: /Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
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
