﻿using System;
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

            if (Session["UserID"] != null)
            {
                return View(Session["UserID"] as User);
            }

            return RedirectToAction("LoginPage", "Users");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            if (Session["UserID"] != null)
            {
                return View(Session["UserID"] as User);
            }

            return RedirectToAction("LoginPage", "Users");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Session["UserID"] != null)
            {
                return View(Session["UserID"] as User);
            }

            return RedirectToAction("LoginPage", "Users");
        }
    }
}