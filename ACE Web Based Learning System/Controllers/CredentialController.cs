using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ACE_Web_Based_Learning_System.DAL;
using ACE_Web_Based_Learning_System.Models;

namespace ACE_Web_Based_Learning_System.Controllers
{
    public class CredentialController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Credential
        public ActionResult Index()
        {
            return View(db.Credential.ToList());
        }

        // GET: Credential/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credential.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // GET: Credential/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Credential/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Password")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                credential.UserID = (int) TempData["UserID"];
                credential.User = db.User.First(u => u.ID == credential.UserID);
                db.Credential.Add(credential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(credential);
        }

        // GET: Credential/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credential.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // POST: Credential/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Password,UserID")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(credential);
        }

        // GET: Credential/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credential.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // POST: Credential/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Credential credential = db.Credential.Find(id);
            db.Credential.Remove(credential);
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
