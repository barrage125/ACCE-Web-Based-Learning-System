using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACE_Web_Based_Learning_System.DAL;
using ACE_Web_Based_Learning_System.Models;
namespace ACE_Web_Based_Learning_System.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            if (Session["User"] != null)
            {
                return View(Session["User"] as User);
            }

            return RedirectToAction("LoginPage", "User");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if (Session["User"] != null)
            {
                return View(Session["User"] as User);
            }

            return RedirectToAction("LoginPage", "User");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Session["User"] != null)
            {
                return View(Session["User"] as User);
            }

            return RedirectToAction("LoginPage", "User");
        }
    }
}