using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AtmLocator.Models;

namespace AtmLocator.Controllers
{
    public class AtmsController : Controller
    {
        private AtmsContext db = new AtmsContext();

        // GET: Atms
        public ActionResult Index()
        {
            return View(db.Atms.ToList());
        }

        // GET: Atms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // GET: Atms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Longitude,Latitude,Name,Street,OpenHours,Wheelchair,Drive_Through")] Atm atm)
        {
            if (ModelState.IsValid)
            {
                db.Atms.Add(atm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atm);
        }

        // GET: Atms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // POST: Atms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Longitude,Latitude,Name,Street,OpenHours,Wheelchair,Drive_Through")] Atm atm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atm);
        }

        // GET: Atms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atm atm = db.Atms.Find(id);
            if (atm == null)
            {
                return HttpNotFound();
            }
            return View(atm);
        }

        // POST: Atms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atm atm = db.Atms.Find(id);
            db.Atms.Remove(atm);
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
