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
    public class VehicleController : Controller
    {
        private VehicleManager vehiclemanager = new VehicleManager();
        public ActionResult Index()
        {
            return View(vehiclemanager.List());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclemanager.Find(x => x.VehicleId == id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Type,Plaque,Chauffeur")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclemanager.Insert(vehicle);
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclemanager.Find(x => x.VehicleId == id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Type,Plaque,Chauffeur")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehiclemanager.Update(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = vehiclemanager.Find(x => x.VehicleId == id.Value);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = vehiclemanager.Find(x => x.VehicleId == id);
            vehiclemanager.Delete(vehicle);
            return RedirectToAction("Index");
        }

    }
}
