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
    public class TourController : Controller
    {
        private TourManager tourmanager = new TourManager();

        // GET: Tour
        public ActionResult Index()
        {
            return View(tourmanager.List());
        }

        // GET: Tour/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourmanager.Find(x => x.TourId == id.Value);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourId,TourName,FullPrice,HalfPrice,GuestPrice,TourDate,IsActive,Tourproperties,VehicleId,EmployeeId")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourmanager.Insert(tour);
                return RedirectToAction("Index");
            }

            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", tour.EmployeeId);
            return View(tour);
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourmanager.Find(x => x.TourId == id.Value);
            if (tour == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", tour.EmployeeId);
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourId,TourName,FullPrice,HalfPrice,GuestPrice,TourDate,IsActive,Tourproperties,VehicleId,EmployeeId")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tourmanager.Update(tour);
                return RedirectToAction("Index");
            }
            //ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", tour.EmployeeId);
            return View(tour);
        }

        // GET: Tour/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = tourmanager.Find(x => x.TourId == id.Value);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = tourmanager.Find(x => x.TourId == id);
            tourmanager.Delete(tour);
            return RedirectToAction("Index");
        }

      

        public ActionResult AquaparkTour()
        {
            return View();
        }
        public ActionResult HamamTour()
        {
            return View();
        }
        public ActionResult JeepSafari()
        {
            return View();
        }
        public ActionResult YacthTour()
        {
            return View();
        }
    }
}
