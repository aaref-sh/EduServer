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
    public class Request_typesController : Controller
    {
        private serdbEntities2 db = new serdbEntities2();

        // GET: /Request_types/
        public ActionResult Index()
        {
            return View(db.request_type.ToList());
        }

        // GET: /Request_types/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request_type request_type = db.request_type.Find(id);
            if (request_type == null)
            {
                return HttpNotFound();
            }
            return View(request_type);
        }

        // GET: /Request_types/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Request_types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name")] request_type request_type)
        {
            if (ModelState.IsValid)
            {
                db.request_type.Add(request_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(request_type);
        }

        // GET: /Request_types/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request_type request_type = db.request_type.Find(id);
            if (request_type == null)
            {
                return HttpNotFound();
            }
            return View(request_type);
        }

        // POST: /Request_types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name")] request_type request_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request_type);
        }

        // GET: /Request_types/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            request_type request_type = db.request_type.Find(id);
            if (request_type == null)
            {
                return HttpNotFound();
            }
            return View(request_type);
        }

        // POST: /Request_types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            request_type request_type = db.request_type.Find(id);
            db.request_type.Remove(request_type);
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
