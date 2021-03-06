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
                ViewData["users"] = users;
            }
           
            return View();
        }
        public ActionResult UserSignup()
        {
            return View();
        }

        public ActionResult UserSettings()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }


        public ActionResult CheckIfUser(string email, string password)
        {
          
            if (db.login(email, password))
            {
                var loginresult = new LoginResult { Message = "success" };
                return Json(loginresult);
            }
            else
            {
               
                    var loginresult = new LoginResult { Message = "bad" };
                    return Json(loginresult);
                
            }


            

        }

        public ActionResult AddUserToDatabase(string firstName, string lastName, string email, string gender, string pronoun, int age, string role, string color, string password)
        {
            var newUser = new Users();
            var newUserContent = new UserContent();
            newUserContent.UserID = Guid.NewGuid();
            newUser.ID = newUserContent.UserID;
            newUserContent.Pronoun = pronoun;
            newUserContent.Gender = gender;
            newUserContent.Color = color;
            newUserContent.Age = age;
            newUserContent.StatusMessage = "";
           
            newUser.Email = email;
            newUser.FirstName = firstName;
            newUser.LastName = lastName;
            newUser.UserRole = role;
            newUser.Password = password;
            db.addUserToDatabase(newUser, newUserContent);


            return Json(Url.Action("Index", "User"));

        }
    }
}
public class LoginResult
{
   
    public string Message { get; set; }
  
}