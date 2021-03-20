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
    public class RequestsController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Requests/
        public ActionResult Index()
        {
            var requests = db.requests.Include(r => r.request_type1).Include(r => r.student).Include(r => r.status1);
            return View(requests.ToList());
        }

        // GET: /Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = db.requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: /Requests/Create
        public ActionResult Create()
        {
            ViewBag.request_type = new SelectList(db.request_type, "id", "name");
            ViewBag.requester = new SelectList(db.students, "Id", "firstname");
            ViewBag.status = new SelectList(db.status, "id", "status1");
            return View();
        }

        // POST: /Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,requester,request_type,status")] request request)
        {
            if (ModelState.IsValid)
            {
                db.requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.request_type = new SelectList(db.request_type, "id", "name", request.request_type);
            ViewBag.requester = new SelectList(db.students, "Id", "firstname", request.requester);
            ViewBag.status = new SelectList(db.status, "id", "status1", request.status);
            return View(request);
        }

        // GET: /Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = db.requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.request_type = new SelectList(db.request_type, "id", "name", request.request_type);
            ViewBag.requester = new SelectList(db.students, "Id", "firstname", request.requester);
            ViewBag.status = new SelectList(db.status, "id", "status1", request.status);
            return View(request);
        }

        // POST: /Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,requester,request_type,status")] request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.request_type = new SelectList(db.request_type, "id", "name", request.request_type);
            ViewBag.requester = new SelectList(db.students, "Id", "firstname", request.requester);
            ViewBag.status = new SelectList(db.status, "id", "status1", request.status);
            return View(request);
        }

        // GET: /Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request request = db.requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            request request = db.requests.Find(id);
            db.requests.Remove(request);
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
