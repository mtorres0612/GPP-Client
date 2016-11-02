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
    public class SourceFileLogController : Controller
    {
        // GET: SourceFileLog
        public ActionResult Index(string directionCode, DateTime? startDate, DateTime? endDate, string erp, string status, string trdpCode, string msgCode, string aplucode, int page = 1, int pageSize = 10)
        {
            List<SourceFileLog> list = new List<SourceFileLog>();

            if (startDate == null &&
                endDate == null &&
                string.IsNullOrEmpty(directionCode) &&
                string.IsNullOrEmpty(erp) &&
                string.IsNullOrEmpty(status) &&
                string.IsNullOrEmpty(trdpCode) &&
                string.IsNullOrEmpty(msgCode) &&
                string.IsNullOrEmpty(aplucode))
            {
                PopulateLOV();
            }
            else
            {
                SourceFileLogBL oSourceFileLogBL = SourceFileLogBL.GetInstance();
                list                             = oSourceFileLogBL.GetAll(directionCode, startDate, endDate, erp, status, trdpCode, msgCode, aplucode);
                ViewBag.startDate                = startDate;
                ViewBag.endDate                  = endDate;
                ViewBag.directionCode            = directionCode;
                ViewBag.erp                      = erp;
                ViewBag.status                   = status;
                ViewBag.trdpCode                 = trdpCode;
                ViewBag.msgCode                  = msgCode;
                ViewBag.aplucode                 = aplucode;

                PopulateLOV();
            }

            return View(list.ToPagedList(page, pageSize));
        }

        // GET: SourceFileLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SourceFileLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SourceFileLog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SourceFileLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SourceFileLog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SourceFileLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SourceFileLog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult PopulateMessageCodes(string trdpCode)
        {
            IEnumerable<SelectListItem> msgCodeList = new List<SelectListItem>();
            MessagesBL oMessagesBL                  = MessagesBL.GetInstance();
            msgCodeList                             = oMessagesBL.GetAllMessages(trdpCode).OrderBy(x => x.MsgCode).Select(x => new SelectListItem { Text = x.MsgCode, Value = x.MsgCode });
            return Json(msgCodeList, JsonRequestBehavior.AllowGet);
        }

        private void PopulateLOV()
        {
            IEnumerable<SelectListItem> messageDirectionList = new List<SelectListItem>();
            Dictionary<string, string> dMessageDirection     = new Dictionary<string, string>();
            dMessageDirection.Add("Receive", "Receive");
            dMessageDirection.Add("Send", "Send");
            messageDirectionList                = dMessageDirection.Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            ViewBag.messageDirectionList        = messageDirectionList;

            IEnumerable<SelectListItem> statusList = new List<SelectListItem>();
            Dictionary<string, string> dStatus     = new Dictionary<string, string>();
            dStatus.Add("Processed", "Processed");
            dStatus.Add("Error", "Error");
            statusList         = dStatus.Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            ViewBag.statusList = statusList;

            IEnumerable<SelectListItem> appCodeList = new List<SelectListItem>();
            ApplicationCodeBL oApplicationCodeBL    = ApplicationCodeBL.GetInstance();
            appCodeList                             = oApplicationCodeBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.appCodeList                     = appCodeList;

            IEnumerable<SelectListItem> erpList = new List<SelectListItem>();
            ERPBL oERPBL                        = ERPBL.GetInstance();
            erpList                             = oERPBL.GetAll().OrderBy(x => x.Erp).Select(x => new SelectListItem { Text = x.Erp, Value = x.Erp });
            ViewBag.erpList                     = erpList;

            IEnumerable<SelectListItem> tradingPartnerList = new List<SelectListItem>();
            TradingPartnerBL oTradingPartnerBL             = TradingPartnerBL.GetInstance();
            tradingPartnerList                             = oTradingPartnerBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.TradingPartnerCode });
            ViewBag.tradingPartnerList                     = tradingPartnerList;

            IEnumerable<SelectListItem> msgCodeList = new List<SelectListItem>();
            ViewBag.msgCodeList                     = msgCodeList;
        }
    }
}
