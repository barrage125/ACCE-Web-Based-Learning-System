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
    public class UserController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public User user;

        // GET: Users
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("Index");
            }
            return View(db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User users = db.User.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstName")] User users)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(users);
                db.SaveChanges();
                //return RedirectToAction("Index");
                TempData["UserID"] = users.ID;
                return RedirectToAction("Create", "Credential");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User users = db.User.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,Password,FirstName,UserRole,UserContent")] User users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User users = db.User.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User users = db.User.Find(id);
            db.User.Remove(users);
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

        // GET: Users/LoginPage
        public ActionResult LoginPage()
        {
            return View();
        }

        // GET: Users/UserSignup
        public ActionResult UserSignup()
        {
            return View();
        }

        // GET: Users/UserSettings
        public ActionResult UserSettings()
        {
            if (Session["User"] != null)
            {
                ViewData["UserContent"] = Session["UserContent"];
                ViewData["UserCredentials"] = Session["UserCredentials"];
                return View(Session["User"] as User);
            }

            return RedirectToAction("LoginPage", "User");
        }

        public bool login(string username, string password)
        {

            var users = db.Credential.Where(i => i.ID == username).ToList();
            var userCotnent = db.UserContent.Where(i => i.ID == username).ToList();
            Console.WriteLine(users.Count);
            if (users.Count == 0)
            {

                return false;
               
            }
            if (users[0].Password != password)
            {
                return false;
            }
            var userID = Convert.ToInt32(users[0].UserID);
            var enrollments = db.Enrollment.Where(i => i.UserID == userID).ToList();
            var courses = new List<Course>();
            foreach (var enroll in enrollments)
            {
                courses.Add(enroll.Section.Course);
            }
            Session["Courses"] = courses;


            Session["User"] = users[0].User;
           
            Session["UserContent"] = userCotnent[0];
            Session["UserCredentials"] = users[0];

            return true;
        }
        public ActionResult CheckIfUser(string email, string password)
        {

            if (login(email, password))
            {
                var loginresult = new LoginResult { Message = "success" };
                return Json(Url.Action("Index", "Home"));
            }
            else
            {
                var loginresult = new LoginResult { Message = "bad" };
                return Json(loginresult);

            }
        }
    }
    public class LoginResult
    {
        public string Message { get; set; }

    }
}
