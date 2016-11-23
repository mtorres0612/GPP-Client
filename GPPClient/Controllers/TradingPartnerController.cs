using GPPClientBL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GPPUtilities;
using System.Text;
namespace GPPClient.Controllers
{
    public class TradingPartnerController : Controller
    {
        // GET: TradingPartner
        TradingPartnerBL oTradingPartnerBL = TradingPartnerBL.GetInstance();
        
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<TradingPartner> list = new List<TradingPartner>();
            list = oTradingPartnerBL.GetAll().OrderBy(x => x.TradingPartnerCode).ToList();
            return View(list.ToPagedList(page, pageSize));
        }

        // GET: TradingPartner/Details/5
        public ActionResult Details(int id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: TradingPartner/Create
        public ActionResult Create()
        {
            PopulateLOV();
            return View("~/Views/Maintenance/CreateTradingPartner.cshtml");
        }

        // POST: TradingPartner/Create
        [HttpPost]
        public ActionResult Create(TradingPartner item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                if (IsUserNameExist(item.UserName, "CREATE", item.TradingPartnerCode))
                {
                    PopulateLOV();
                    ModelState.AddModelError("UserName", "UserName already exist, Please choose another Username.");
                    return View();
                }
                else if (!Utility.CheckForStrongPassword(item.Password))
                {
                    if (!string.IsNullOrEmpty(item.UserName))
                    {
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("Password does not match the correct format.<br />");
                        _sb.Append("Passwords will contain at least (1) upper case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) lower case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) number or special character.<br />");
                        _sb.Append("Passwords will contain at least (8) characters in length.<br />");
                        _sb.Append("Password maximum length should not be arbitrarily limited.<br />");

                        PopulateLOV();
                        ModelState.AddModelError("Password", _sb.ToString());
                        return View();
                    }
                }
                else
                {
                    item.Password = Utility.Encrypt(item.Password);
                    result = oTradingPartnerBL.Insert(item);
                }
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

        // GET: TradingPartner/Edit/5
        public ActionResult Edit(long id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            item.Password = Utility.Decrypt(item.Password);
            
            PopulateLOV();
            return View("~/Views/Maintenance/EditTradingPartner.cshtml", item);

        }

        // POST: TradingPartner/Edit/5
        [HttpPost]
        public ActionResult Edit(TradingPartner item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                if (IsUserNameExist(item.UserName, "EDIT", item.TradingPartnerCode))
                {
                    PopulateLOV();
                    ModelState.AddModelError("UserName", "UserName is already in use.");
                    return View(item);
                }
                else if (!Utility.CheckForStrongPassword(item.Password))
                {
                    if (!string.IsNullOrEmpty(item.UserName))
                    {
                        StringBuilder _sb = new StringBuilder();
                        _sb.Append("Password does not match the correct format.<br />");
                        _sb.Append("Passwords will contain at least (1) upper case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) lower case letter.<br />");
                        _sb.Append("Passwords will contain at least (1) number or special character.<br />");
                        _sb.Append("Passwords will contain at least (8) characters in length.<br />");
                        _sb.Append("Password maximum length should not be arbitrarily limited.<br />");

                        PopulateLOV();
                        ModelState.AddModelError("Password", _sb.ToString());
                        return View(item);
                    }
                }
                else
                {
                    item.Password = Utility.Encrypt(item.Password);
                    result = oTradingPartnerBL.Update(item);
                }
            }
            else
            {
                PopulateLOV();
                return View(item);
            }

            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        // GET: TradingPartner/Delete/5
        public ActionResult Delete(long id)
        {
            TradingPartner item = oTradingPartnerBL.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oTradingPartnerBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }

        private void PopulateLOV()
        {
            IEnumerable<SelectListItem> countryList = new List<SelectListItem>();
            CountryBL oCountryBL                    = CountryBL.GetInstance();
            countryList                             = oCountryBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.countryList                     = countryList;

            IEnumerable<SelectListItem> erpList = new List<SelectListItem>();
            ERPBL oERPBL                        = ERPBL.GetInstance();
            erpList                             = oERPBL.GetAll().OrderBy(x => x.Erp).Select(x => new SelectListItem { Text = x.Erp, Value = x.Erp });
            ViewBag.erpList                     = erpList;
        }

        private bool IsUserNameExist(string userName, string method, string tradingPartnerCode)
        {
            if (method == "CREATE")
            {
                List<TradingPartner> list = new List<TradingPartner>();
                list = oTradingPartnerBL.GetAll().Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (list.Count > 0)
                {
                    return true;
                }
            }
            else if (method == "EDIT")
            {
                List<TradingPartner> list = new List<TradingPartner>();
                list = oTradingPartnerBL.GetAll().Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).ToList();
                if (list.Count > 0)
                {
                    if (list[0].TradingPartnerCode != tradingPartnerCode)
                    {
                        if (!string.IsNullOrEmpty(list[0].TradingPartnerCode))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;           
        }
    }
}
