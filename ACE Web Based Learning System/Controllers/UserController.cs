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
       
        public User user;

        

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
        #region auto generated pages NOT USED

        //// GET: Users
        //public ActionResult Index()
        //{
        //    if (Session["UserID"] != null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View(db.User.ToList());
        //}
        //// GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User users = db.User.Find(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// GET: Users/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "LastName,FirstName")] User users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.User.Add(users);
        //        db.SaveChanges();
        //        //return RedirectToAction("Index");
        //        TempData["UserID"] = users.ID;
        //        return RedirectToAction("Create", "Credential");
        //    }

        //    return View(users);
        //}

        //// GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User users = db.User.Find(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,LastName,Password,FirstName,UserRole,UserContent")] User users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(users).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(users);
        //}

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User users = db.User.Find(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User users = db.User.Find(id);
        //    db.User.Remove(users);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        #endregion

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
        #region Edit User Content Section
        public ActionResult editFirstName(string newName, string password)
        {
            
            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    if (password == credentials.Password)
                    {
                        User user = dbContext.User.Find(sessionUser.ID);
                        User newUser = user;
                        newUser.FirstName = newName;
                        dbContext.Entry(user).CurrentValues.SetValues(newUser);

                        dbContext.SaveChanges();
                        Session["User"] = user;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);               
            }
                
        }

        public ActionResult editLastName(string newName, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    if (password == credentials.Password)
                    {
                        User user = dbContext.User.Find(sessionUser.ID);
                        User newUser = user;
                        newUser.LastName = newName;
                        dbContext.Entry(user).CurrentValues.SetValues(newUser);

                        dbContext.SaveChanges();
                        Session["User"] = user;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }
        public ActionResult editEmail(string newEmail, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    var sessionContent = Session["UserContent"] as UserContent;
                    if (password == credentials.Password)
                    {
                        UserContent content = dbContext.UserContent.Find(sessionContent.ID);
                        UserContent newContent = content;
                        newContent.Email = newEmail;
                        dbContext.Entry(content).CurrentValues.SetValues(newContent);

                        dbContext.SaveChanges();

                        Session["UserContent"] = content;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }

        public ActionResult editGender(string newGender, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    var sessionContent = Session["UserContent"] as UserContent;
                    if (password == credentials.Password)
                    {
                        UserContent content = dbContext.UserContent.Find(sessionContent.ID);
                        UserContent newContent = content;
                        newContent.Gender = newGender;
                        dbContext.Entry(content).CurrentValues.SetValues(newContent);

                        dbContext.SaveChanges();

                        Session["UserContent"] = content;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }

        public ActionResult editAge(int newAge, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    var sessionContent = Session["UserContent"] as UserContent;
                    if (password == credentials.Password)
                    {
                        UserContent content = dbContext.UserContent.Find(sessionContent.ID);
                        UserContent newContent = content;
                        newContent.Age = newAge;
                        dbContext.Entry(content).CurrentValues.SetValues(newContent);

                        dbContext.SaveChanges();

                        Session["UserContent"] = content;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }

        public ActionResult editStatus(string newStatus, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                    var credentials = Session["UserCredentials"] as Credential;
                    var sessionContent = Session["UserContent"] as UserContent;
                    if (password == credentials.Password)
                    {
                        UserContent content = dbContext.UserContent.Find(sessionContent.ID);
                        UserContent newContent = content;
                        newContent.Status = newStatus;
                        dbContext.Entry(content).CurrentValues.SetValues(newContent);

                        dbContext.SaveChanges();

                        Session["UserContent"] = content;
                        return Json(Url.Action("UserSettings", "User"));
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }

        public ActionResult editColor(string newColor, string password)
        {

            try
            {
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {

                    //grabs user and usercontent and crossreferences their password
                    var sessionUser = Session["User"] as User;
                var credentials = Session["UserCredentials"] as Credential;
                var sessionContent = Session["UserContent"] as UserContent;
                if (password == credentials.Password)
                {
                    UserContent content = dbContext.UserContent.Find(sessionContent.ID);
                    UserContent newContent = content;
                    newContent.Color = newColor;
                    dbContext.Entry(content).CurrentValues.SetValues(newContent);

                    dbContext.SaveChanges();

                    Session["UserContent"] = content;
                    return Json(Url.Action("UserSettings", "User"));
                }
                else
                {
                    throw new Exception("Incorrect password");
                }
                }

            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);
            }

        }
        #endregion
        public bool login(string username, string password)
        {
            try
            {
                //grabs user credential and user content
                //singleordefault will only grab if there is a single element in the databsae
                //if more than one or zero is found, then it will throw an exception
                //using statement automatically disposes after use
                using (SchoolContext dbContext = new SchoolContext())
                {
                    var userCredential = dbContext.Credential.SingleOrDefault(i => i.ID == username);
                    var userContent = dbContext.UserContent.SingleOrDefault(i => i.ID == username);


                    if (userCredential.Password != password)
                    {
                        throw new Exception("Incorrect password");
                    }

                    var userID = Convert.ToInt32(userCredential.UserID);
                    //grabs userID and checks what enrolled courses they are in
                    var enrollments = dbContext.Enrollment.Where(i => i.UserID == userID).ToList();
                    var courses = new List<Course>();

                    foreach(var enroll in enrollments)
                    {
                        courses.Add(enroll.Section.Course);
                    }
                   
                    //sets enrolled courses to session data
                    Session["Courses"] = courses;


                    Session["User"] = userCredential.User;

                    Session["UserContent"] = userContent;
                    Session["UserCredentials"] = userCredential;

                    
                }
                //if all is good, then return true

                return true;
                

            }
            catch (Exception e)
            {
                //will return false to resume operation
                //will NOT return an indication of exception for security reasons
                Console.WriteLine(e);
                return false;
            }
           
        }
        public ActionResult CheckIfUser(string email, string password)
        {

            if (login(email, password))
            {
                var loginresult = new JsonResult { Message = "success" };
                return Json(Url.Action("Index", "Home"));
            }
            else
            {
                var loginresult = new JsonResult { Message = "bad" };
                return Json(loginresult);

            }
        }
    }
    public class JsonResult
    {
        public string Message { get; set; }

    }
}
