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
    public class UserContentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: UserContent
        public ActionResult Index()
        {
            return View(db.UserContent.ToList());
        }

        // GET: UserContent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContent.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            return View(userContent);
        }

        // GET: UserContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserContent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Gender,Pronoun,Age,Color,StatusMessage")] UserContent userContent)
        {
            if (ModelState.IsValid)
            {
                db.UserContent.Add(userContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userContent);
        }

        // GET: UserContent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContent.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            return View(userContent);
        }

        // POST: UserContent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Gender,Pronoun,Age,Color,StatusMessage")] UserContent userContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userContent);
        }

        // GET: UserContent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContent.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            return View(userContent);
        }

        // POST: UserContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserContent userContent = db.UserContent.Find(id);
            db.UserContent.Remove(userContent);
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
