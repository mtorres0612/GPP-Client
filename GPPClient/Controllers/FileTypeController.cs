using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GPPClientModel;
using GPPClientBL;
namespace GPPClient.Controllers
{
    public class FileTypeController : Controller
    {
        // GET: FileType
        IMaintainableBL<FileType> oFileTypeBL = FileTypeBL.GetInstance();

        public ActionResult Index()
        {
            List<FileType> list    = new List<FileType>();
            list                   = oFileTypeBL.GetAll();
            return View(list);
        }

        public ActionResult Details(string id)
        {
            FileType item = oFileTypeBL.GetAll().Where(x => x.FileTypeCode == id).FirstOrDefault();

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
        public ActionResult Create(FileType item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oFileTypeBL.Insert(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            FileType item = oFileTypeBL.GetAll().Where(x => x.FileTypeCode == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(FileType item)
        {
            int result = 0;

            if (ModelState.IsValid)
            {
                result = oFileTypeBL.Update(item);
            }
            if (result == -1)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            FileType item = oFileTypeBL.GetAll().Where(x => x.FileTypeCode == id).FirstOrDefault();

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
                result = oFileTypeBL.Delete(id);
            }
            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }

    }
}