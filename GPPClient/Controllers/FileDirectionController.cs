using GPPClientBL;
using GPPClientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GPPClient.Controllers
{
    public class FileDirectionController : Controller
    {
        // GET: FileDirection
        IMaintainableBL<FileDirection> oFileDirectionBL = FileDirectionBL.GetInstance();

        public ActionResult Index()
        {
            List<FileDirection> list = new List<FileDirection>();
            list = oFileDirectionBL.GetAll();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            FileDirection item = oFileDirectionBL.GetAll().Where(x => x.FileDirectionCode == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FileDirection item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oFileDirectionBL.Insert(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            FileDirection item = oFileDirectionBL.GetAll().Where(x => x.FileDirectionCode == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(FileDirection item)
        {
            int result = 0;

            if (ModelState.IsValid)
            {
                result = oFileDirectionBL.Update(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            FileDirection item = oFileDirectionBL.GetAll().Where(x => x.FileDirectionCode == id).FirstOrDefault();

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
                result = oFileDirectionBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}