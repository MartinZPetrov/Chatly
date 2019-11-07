using Chatly.Controllers.Shared;
using Chatly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chatly.Controllers
{
    public class LogOnController : ApplicationController<LogOnModel>
    {
        public ActionResult Index()
        {
            return View("LogOn");
        }

        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                /*Set model to session*/
                SetLogOnSessionModel(model);
                /*Shows the session*/
                LogOnModel sessionModel = GetLogOnSessionModel();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            /*distroy current session and go to login page*/
            AbandonSession();
            return RedirectToAction("Index", "LogOn");
        }
    }
}