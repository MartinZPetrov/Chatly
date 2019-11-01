using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chatly.ServiceReference;

namespace Chatly.Controllers
{
    public class HomeController : Controller
    {
        private DataServiceClient dataservice;
        public HomeController()
        {
            dataservice = new DataServiceClient();
        }
        public ActionResult Index()
        {
            //var msg = new Messages();
            //msg.Message = "Test your skills";
            //dataservice.AddMessage(msg);
            
            return View();
        }

        public ActionResult Chat()
        {
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
        protected override void Dispose(bool disposing)
        {
            dataservice.Close();
            base.Dispose(disposing);
        }
    }
}