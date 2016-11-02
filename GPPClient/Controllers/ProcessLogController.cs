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
    public class ProcessLogController : Controller
    {
        // GET: ProcessLog
        public ActionResult Index(DateTime? startDate, DateTime? endDate, string erp, string status, string msgCode, string applicationCode, int page = 1, int pageSize = 10)
        {
            List<ProcessLog> list = new List<ProcessLog>();

            if (startDate == null &&
                endDate == null &&
                string.IsNullOrEmpty(erp) &&
                string.IsNullOrEmpty(status) &&
                string.IsNullOrEmpty(msgCode) &&
                string.IsNullOrEmpty(applicationCode))
            {
                PopulateLOV();
            }
            else
            {
                ProcessLogBL oProcessLogBL = ProcessLogBL.GetInstance();
                list                       = oProcessLogBL.GetAll(startDate, endDate, erp, status, msgCode, applicationCode);
                ViewBag.startDate          = startDate;
                ViewBag.endDate            = endDate;
                ViewBag.erp                = erp;
                ViewBag.status             = status;
                ViewBag.msgCode            = msgCode;
                ViewBag.applicationCode    = applicationCode;

                PopulateLOV();
            }

            return View(list.ToPagedList(page, pageSize));
        }   

        // GET: ProcessLog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcessLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcessLog/Create
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

        // GET: ProcessLog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcessLog/Edit/5
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

        // GET: ProcessLog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcessLog/Delete/5
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

        private void PopulateLOV()
        {
            IEnumerable<SelectListItem> appCodeList = new List<SelectListItem>();
            ApplicationCodeBL oApplicationCodeBL    = ApplicationCodeBL.GetInstance();
            appCodeList                             = oApplicationCodeBL.GetAll().OrderBy(x => x.Name).Select(x => new SelectListItem { Text = x.Name, Value = x.Code });
            ViewBag.appCodeList                     = appCodeList;

            IEnumerable<SelectListItem> msgCodeList = new List<SelectListItem>();
            MessagesBL oMessagesBL                  = MessagesBL.GetInstance();
            msgCodeList                             = oMessagesBL.GetAllMessages().OrderBy(x => x.MsgCode).Select(x => new SelectListItem { Text = x.MsgCode, Value = x.MsgCode });
            ViewBag.msgCodeList                     = msgCodeList;

            IEnumerable<SelectListItem> erpList = new List<SelectListItem>();
            ERPBL oERPBL                        = ERPBL.GetInstance();
            erpList                             = oERPBL.GetAll().OrderBy(x => x.Erp).Select(x => new SelectListItem { Text = x.Erp, Value = x.Erp });
            ViewBag.erpList                     = erpList;

            IEnumerable<SelectListItem> statusList = new List<SelectListItem>();
            Dictionary<string, string> dStatus     = new Dictionary<string, string>();
            dStatus.Add("Success", "Success");
            dStatus.Add("Failed", "Failed");
            statusList      = dStatus.Select(x => new SelectListItem { Text = x.Value, Value = x.Key });
            ViewBag.statusList = statusList;
        }
    }
}
