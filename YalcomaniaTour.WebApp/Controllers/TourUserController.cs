using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YalcomaniaTour.BusinessLayer;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.WebApp.Controllers
{
    public class TourUserController : Controller
    {
        private TourUserManager UserManager = new TourUserManager();
        // GET: TourUser
        public ActionResult Index()
        {
            return View(UserManager.List());
        }

        // GET: TourUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourUser tourUser = UserManager.Find(x => x.UserId == id.Value);
            if (tourUser == null)
            {
                return HttpNotFound();
            }
            return View(tourUser);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( TourUser tourUser)
        {
            if (ModelState.IsValid)
            {
                UserManager.Insert(tourUser);
                return RedirectToAction("Index");
            }

            return View(tourUser);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourUser tourUser = UserManager.Find(x => x.UserId== id.Value);
            if (tourUser == null)
            {
                return HttpNotFound();
            }
            return View(tourUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourUser tourUser)
        {
            if (ModelState.IsValid)
            {
                
                TourUser db_User = UserManager.Find(x => x.UserId == tourUser.UserId);
                UserManager.Update(tourUser);
                return RedirectToAction("Index");
            }
            return View(tourUser);
        }

        // GET: TourUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourUser tourUser = UserManager.Find(x => x.UserId == id.Value);
            if (tourUser == null)
            {
                return HttpNotFound();
            }
            return View(tourUser);
        }

        // POST: TourUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourUser tourUser = UserManager.Find(x => x.UserId == id);
            UserManager.Delete(tourUser);
            return RedirectToAction("Index");
        }

        
    }
}
