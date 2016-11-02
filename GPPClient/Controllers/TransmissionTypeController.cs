using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPPClientBL;
using GPPClientModel;
namespace GPPClient.Controllers
{
    public class TransmissionTypeController : Controller
    {
        IMaintainableBL<TransmissionType> oTransmissionTypeBL = TransmissionTypeBL.GetInstance();

        // GET: TransmissionType
        public ActionResult Index()
        {
            List<TransmissionType> list            = new List<TransmissionType>();
            list                                   = oTransmissionTypeBL.GetAll();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TransmissionType item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oTransmissionTypeBL.Insert(item);

                if (result == 0)
                {
                    return HttpNotFound();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            TransmissionType item = oTransmissionTypeBL.GetAll().Where(x => x.TransmissionTypeID == id).SingleOrDefault();
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(TransmissionType item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oTransmissionTypeBL.Update(item);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            TransmissionType item = oTransmissionTypeBL.GetAll().Where(x => x.TransmissionTypeID == id).SingleOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oTransmissionTypeBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}