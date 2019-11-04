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
    public class CodeController : Controller
    {
        private DataServiceClient dataservice;

        public CodeController()
        {
            dataservice = new DataServiceClient();
        }

        public ViewResult Index()
        {
            return View("List");
        }

        public async Task<ActionResult> GetCodes()
        {
            var list = new List<CodeViewModel>();
            var items = await dataservice.GetCodesListAsync();
            foreach (var item in items)
            {
                var codeModel = new CodeViewModel();
                codeModel.Code = item.PinCode;
                codeModel.Id = item.Id;
                list.Add(codeModel);
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ViewResult New()
        {

            var viewModel = new CodeViewModel();

            return View("CodeForm", viewModel);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var code = await dataservice.GetCodeAsync(id);

            if (code == null)
                return HttpNotFound();

            var viewModel = new CodeViewModel();
            viewModel.Code = code.PinCode;
            viewModel.Id = code.Id;

            return View("CodeForm", viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(CodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CodeViewModel();
                return View("CodeForm", viewModel);
            }

            if (model.Id == 0)
            {
                var codeDB = new Codes();
                codeDB.PinCode = model.Code;
                await dataservice.AddCodeAsync(codeDB);
            }
            else
            {
                var codeInDb = await dataservice.GetCodeAsync(model.Id);
                codeInDb.PinCode = model.Code;
                await dataservice.UpdateCodeAsync(codeInDb);
            }
            return RedirectToAction("Index", "Code");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Delete(int Id)
        {
            var itemToDelete = await dataservice.GetCodeAsync(Id);
            await dataservice.DeleteCodeAsync(itemToDelete);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
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