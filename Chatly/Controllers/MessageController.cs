using Chatly.Models;
using Chatly.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chatly.Controllers
{
    public class MessageController : Controller
    {
        private DataServiceClient dataservice;

        public MessageController()
        {
            dataservice = new DataServiceClient();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetMessages()
        {
            var list = new List<ChatRoomViewModel>();
            var messages = await dataservice.GetMessagesListAsync();
            foreach (var msg in messages)
            {
                var chatRoomModel = new ChatRoomViewModel();
                chatRoomModel.Code = new CodeViewModel(){ Code = msg.Codes.PinCode, Id =msg.Codes.Id};
                chatRoomModel.CodeId = msg.Codes.Id;
                chatRoomModel.RoomCode = msg.Codes.PinCode;
                chatRoomModel.Message = msg.Message;
                chatRoomModel.UserName = msg.Users.UserName;
                chatRoomModel.MessageId = msg.Id;
                list.Add(chatRoomModel);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Message/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var msgList = await dataservice.GetMessagesListAsync();
            var codes = await dataservice.GetCodesListAsync();
            var msg = msgList.FirstOrDefault(e => e.Id == id);

            var listCodes = new List<CodeViewModel>();
            foreach (var item in codes)
            {
                var codeModel = new CodeViewModel();
                codeModel.Code = item.PinCode;
                codeModel.Id = item.Id;
                listCodes.Add(codeModel);
            }

            if (msg == null)
                return HttpNotFound();

            var viewModel = new ChatRoomViewModel();
            viewModel.CodeId = msg.Id;
            viewModel.RoomCode = msg.Codes.PinCode;
            viewModel.Code = new CodeViewModel() { Id = msg.Codes.Id, Code = msg.Codes.PinCode }; ;
            viewModel.Message = msg.Message;
            viewModel.MessageId = msg.Id;
            viewModel.Codes = listCodes;
            viewModel.UserName = msg.Users.UserName;

            return View("MessageForm", viewModel);
        }

        // POST: Message/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var itemToDelete = await dataservice.GetMessageAsync(id);
                await dataservice.DeleteMessageAsync(itemToDelete);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
                
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(ChatRoomViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ChatRoomViewModel();
                return View("MessageForm", viewModel);
            }

            if (model.MessageId != 0)
            {
                var msgInDb = await dataservice.GetMessageAsync(model.MessageId);
                msgInDb.Message = model.Message;

                await dataservice.UpdateMessageAsync(msgInDb);
            }
            return RedirectToAction("Index", "Message");
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
