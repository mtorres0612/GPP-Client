using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPPClientModel;
using GPPClientBL;
using PagedList;
namespace GPPClient.Controllers
{
    public class EmailDistributionListController : Controller
    {
        IMaintainableBL<EmailDistributionList> oEmailDistributionListBL = EmailDistributionListBL.GetInstance();

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<EmailDistributionList> list = new List<EmailDistributionList>();
            list = oEmailDistributionListBL.GetAll().OrderBy(x => x.MsgCode).ToList();

            return View(list.ToPagedList(page, pageSize));
        }

        public ActionResult Details(string id)
        {
            EmailDistributionList item = oEmailDistributionListBL.GetAll().Where(x => x.Emldkey == Convert.ToInt32(id)).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Create()
        {
            PopulateLOV();
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmailDistributionList item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oEmailDistributionListBL.Insert(item);
            }
            else
            {
                PopulateLOV();
                return View();
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        private void PopulateLOV()
        {
            IEnumerable<SelectListItem> erpList = new List<SelectListItem>();
            ERPBL oERPBL = ERPBL.GetInstance();
            erpList = oERPBL.GetAll().OrderBy(x => x.Erp).Select(x => new SelectListItem { Text = x.Erp, Value = x.Erp });
            ViewBag.erpList = erpList;
        }

        public ActionResult Edit(string id)
        {
            EmailDistributionList item = oEmailDistributionListBL.GetAll().Where(x => x.Emldkey == Convert.ToInt32(id)).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            PopulateLOV();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(EmailDistributionList item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oEmailDistributionListBL.Update(item);
            }
            else
            {
                PopulateLOV();
                return View();
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            EmailDistributionList item = oEmailDistributionListBL.GetAll().Where(x => x.Emldkey == Convert.ToInt32(id)).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oEmailDistributionListBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}
