using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chatly.ServiceReference;
using Chatly.Models;
using System.Net;
using System.Threading.Tasks;

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
            return View();
        }

        public ActionResult Chat()
        {
            var user = Session["user"] as Users;
            if (user == null) return RedirectToAction("Index", "Home");
            var model = new ChatRoomViewModel()
            {
                UserName = user.UserName,
                GameRoomCode = "ABC777"

            };
       
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> AddMessage(string message)
        {
            var usr = Session["user"] as Users;
            var msg = new Messages();
            msg.Message = message;
            msg.UserId = usr.Id;
            msg.PinId = 1;

            await dataservice.AddMessageAsync(msg);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (dataservice != null)
            {
                if (dataservice.State != System.ServiceModel.CommunicationState.Closed)
                {
                    dataservice.Close();
                }
            }
            base.Dispose(disposing);
        }
    }
}

