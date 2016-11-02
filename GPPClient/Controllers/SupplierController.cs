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
    public class SupplierController : Controller
    {
        IMaintainableBL<Supplier> oSupplierBL = SupplierBL.GetInstance();

        // GET: Supplier
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<Supplier> list    = new List<Supplier>();
            list                   = oSupplierBL.GetAll();
            return View(list.ToPagedList(page, pageSize));
        }

        public ActionResult Details(string id)
        {
            Supplier item = oSupplierBL.GetAll().Where(x => x.SuppID == id).SingleOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult Create()
        {
            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL                    = CountryBL.GetInstance();
            countryList                             = oCountryBL.GetAll().OrderBy(x => x.Name).Select(country => new SelectListItem { Text = country.Name, Value = country.Code });
            ViewBag.countryList                     = countryList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier item)
        {
            int result = 0;

            if (ModelState.IsValid)
            {
                result = oSupplierBL.Insert(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            Supplier item                           = oSupplierBL.GetAll().Where(x => x.SuppID == id).SingleOrDefault();
            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL                    = new CountryBL();
            countryList                             = oCountryBL.GetAll().OrderBy(x => x.Name).Select(country => new SelectListItem { Text = country.Name, Value = country.Code });
            ViewBag.countryList                     = countryList;

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Supplier item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oSupplierBL.Update(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            Supplier item = oSupplierBL.GetAll().Where(x => x.SuppID == id).SingleOrDefault();
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
                result = oSupplierBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}