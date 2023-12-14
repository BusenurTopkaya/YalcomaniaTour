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
    public class HotelController : Controller
    {
        private HotelManager hotelManager = new HotelManager();
        
        public ActionResult Index()
        {
            return View(hotelManager.List());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = hotelManager.Find(x=>x.HotelId==id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelManager.Insert(hotel);
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = hotelManager.Find(x => x.HotelId == id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotelManager.Update(hotel);
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = hotelManager.Find(x => x.HotelId == id.Value);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = hotelManager.Find(x => x.HotelId == id);
            hotelManager.Delete(hotel);
            return RedirectToAction("Index");
        }

       
    }
}
