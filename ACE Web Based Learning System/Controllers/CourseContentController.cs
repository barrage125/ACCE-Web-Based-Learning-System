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
    public class CourseContentController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: CourseContent
        public ActionResult Index()
        {
            return View(db.CourseContent.ToList());
        }

        // GET: CourseContent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContent.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // GET: CourseContent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseContent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,CourseName,Content")] CourseContent courseContent)
        {
            if (ModelState.IsValid)
            {
                db.CourseContent.Add(courseContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courseContent);
        }

        // GET: CourseContent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContent.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // POST: CourseContent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,CourseName,Content")] CourseContent courseContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseContent);
        }

        // GET: CourseContent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseContent courseContent = db.CourseContent.Find(id);
            if (courseContent == null)
            {
                return HttpNotFound();
            }
            return View(courseContent);
        }

        // POST: CourseContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseContent courseContent = db.CourseContent.Find(id);
            db.CourseContent.Remove(courseContent);
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
