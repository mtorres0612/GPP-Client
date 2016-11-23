using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using GPPClientBL;
using GPPClientModel;

namespace GPPClient.Controllers
{
    public class UserMaintenanceController : Controller
    {
        UserBL oUserBL = UserBL.GetInstance();

        // GET: UserMaintenance
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            List<User> list = new List<User>();
            list = oUserBL.GetAll(string.Empty, string.Empty).OrderBy(x => x.LastName).ToList();

            return View(list.ToPagedList(page, pageSize));
        }

        // GET: UserMaintenance/Details/5
        public ActionResult Details(int id)
        {
            User item = new User();
            item = oUserBL.GetAll(string.Empty, string.Empty).Where(x => x.ID == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // GET: UserMaintenance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMaintenance/Create
        [HttpPost]
        public ActionResult Create(User item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oUserBL.Insert(item);
            }
            else
            {
                return View();
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        // GET: UserMaintenance/Edit/5
        public ActionResult Edit(int id)
        {
            User item = new User();
            item = oUserBL.GetAll(string.Empty, string.Empty).Where(x => x.ID == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: UserMaintenance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User item)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = oUserBL.Update(item);
            }
            else
            {
                return View();
            }
            if (result == -1)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        // GET: UserMaintenance/Delete/5
        public ActionResult Delete(int id)
        {
            User item = new User();
            item = oUserBL.GetAll(string.Empty, string.Empty).Where(x => x.ID == id).FirstOrDefault();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: UserMaintenance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int result = 0;

            result = oUserBL.Delete(id);

            if (result != 1)
            {
                return HttpNotFound();

            }
            return RedirectToAction("Index");
        }
    }
}
