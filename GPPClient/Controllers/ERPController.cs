using GPPClientBL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace GPPClient.Controllers
{
    public class ERPController : Controller
    {
        IMaintainableBL<ERP> oERPBL = ERPBL.GetInstance();
      
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<ERP> list = new List<ERP>();
            list = oERPBL.GetAll().OrderBy(x => x.Erp).ToList();

            return View(list.ToPagedList(page, pageSize));
        }

        public ActionResult Details(string id)
        {
            ERP item = oERPBL.GetAll().Where(x => x.Erp == id).FirstOrDefault();

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
        public ActionResult Create(ERP item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oERPBL.Insert(item);
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
            IEnumerable<SelectListItem> suppList = new List<SelectListItem>();
            SupplierBL oSupplierBL = SupplierBL.GetInstance();
            suppList = oSupplierBL.GetAll().OrderBy(x => x.SuppID).Select(x => new SelectListItem { Text = x.Name, Value = x.SuppID });
            ViewBag.suppList = suppList;

            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL = CountryBL.GetInstance();
            countryList = oCountryBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.countryList = countryList;
        }

        public ActionResult Edit(string id)
        {
            ERP item = oERPBL.GetAll().Where(x => x.Erp == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            PopulateLOV();
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(ERP item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oERPBL.Update(item);
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
            ERP item = oERPBL.GetAll().Where(x => x.Erp == id).FirstOrDefault();

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
                result = oERPBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}