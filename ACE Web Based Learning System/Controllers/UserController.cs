using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACE_Web_Based_Learning_System.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        Database db = new Database();
        public ActionResult Index()
        {
            var users = db.getUserList();
            if (users != null)
            {
                ViewBag["Users"] = users;
            }
           
            return View();
        }
        public ActionResult UserSignup()
        {
            return View();
        }
        
        
        
        public void AddUserToDatabase(string firstName, string lastName, string email, string gender, string pronoun, int age, string role, string color)
        {
            var newUser = new Users();
            var newUserContent = new UserContent();
            newUserContent.Pronoun = pronoun;
            newUserContent.Gender = gender;
            newUserContent.Color = color;
            newUserContent.Age = age;
            newUserContent.StatusMessage = "";
            

            newUser.FirstName = firstName;
            newUser.LastName = lastName;
            newUser.UserRole = role;
            newUser.Password = "password";
            db.addUserToDatabase(newUser, newUserContent);
            

            RedirectToAction("Index");
            
        }
    }
}