using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chatly.ServiceReference;
using Chatly.Models;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ChatlyServices;
using Microsoft.Owin.Security;

namespace Chatly.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;


        private DataServiceClient dataservice;
        public HomeController()
        {
            dataservice = new DataServiceClient();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Authorize]
        public async Task<ActionResult> Chat()
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var codes = await dataservice.GetCodesListAsync();
            if (user == null || codes.Count() == 0) return RedirectToAction("Index", "Home");

            var res = CastToCodeViewModel(codes);

            var model = new ChatRoomViewModel()
            {
                UserName = user.UserName,
                Codes = res,
                CodeId = res[0].Id

            };
       
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddMessage(string user, string message, string roomCode)
        {
            var usersFromDB = await dataservice.GetUserListAsync();
            //var userModel = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var userModel = usersFromDB.FirstOrDefault(e => e.Email.Trim().ToLower() == user);
            var codes = await dataservice.GetCodesListAsync();

            var code = codes.FirstOrDefault(e => e.PinCode == roomCode);
            var msg = new Messages();
            msg.Message = message;
            string userId = string.Empty;
            userId = userModel.Id;
            msg.UserId = userId;
            msg.PinId = code.Id;

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

        public static List<CodeViewModel> CastToCodeViewModel(Codes[] codes)
        {
            List<CodeViewModel> listCodes = new List<CodeViewModel>();
            foreach(var item in codes)
            {
                CodeViewModel code = new CodeViewModel();
                code.Code = item.PinCode;
                code.Id = item.Id;
                listCodes.Add(code);
            }
            return listCodes;
        }
    }
}

