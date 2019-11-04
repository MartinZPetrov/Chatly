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

        public async Task<ActionResult> Chat()
        {
            var user = Session["user"] as Users;
            var codes = await dataservice.GetCodesListAsync();
            if (user == null || codes == null) return RedirectToAction("Index", "Home");

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

        public async Task<ActionResult> AddMessage(string user, string message, string roomCode)
        {
            var usersFromDB = await dataservice.GetUsersListAsync();
            bool createNewuser = false;
            var users = dataservice.GetCodesListAsync();
            var usr = Session["user"] as Users;
            if (user != usr.UserName) createNewuser = true;
            Users newUser = null;
            if (createNewuser)
            {
                newUser = usersFromDB.FirstOrDefault(e => e.UserName.ToLower().Trim() == user.ToLower().Trim());
                if (newUser == null)
                {
                    var userToCreate = new Users();
                    userToCreate.UserName = user;
                    userToCreate.Email = user + "@yahoo.com";
                    newUser = await dataservice.CreateAsync(userToCreate, user);
                }
            }

            var codes = await dataservice.GetCodesListAsync();
            var code = codes.FirstOrDefault(e => e.PinCode == roomCode);
            var msg = new Messages();
            msg.Message = message;
            int userId = 0;
            userId = newUser != null ? newUser.Id : usr.Id;
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

