using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACE_Web_Based_Learning_System.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var db = new masterEntities1();
            Console.WriteLine(db.Users);
            Console.WriteLine(db.CourseContent);
            var usercontent = new UserContent();
            db.UserContent.Add(usercontent);
            db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}