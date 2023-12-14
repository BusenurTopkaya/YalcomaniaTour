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
using YalcomaniaTour.WebApp.Models;

namespace YalcomaniaTour.WebApp.Controllers
{
    public class RegionController : Controller
    {
        private RegionManager regionmanager =new RegionManager();

        // GET: Region
        public ActionResult Index()
        {
            var regions = regionmanager.ListQueryable().Include(r => r.Hotels);
            return View(regions.ToList());
        }

        // GET: Region/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = regionmanager.Find(x => x.RegionId == id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Region/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(CacheHelper.GetCategoriesFromCache(), "HotelId", "HotelName");
            return View();
        }

        // POST: Region/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionId,RegionName,HotelId,ServiceHour")] Region region)
        {
            if (ModelState.IsValid)
            {
                regionmanager.Insert(region);
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(CacheHelper.GetCategoriesFromCache(), "HotelId", "HotelName", region.HotelId);
            return View(region);
        }

        // GET: Region/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = regionmanager.Find(x => x.RegionId == id);
            if (region == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(CacheHelper.GetCategoriesFromCache(), "HotelId", "HotelName", region.HotelId);
            return View(region);
        }

        // POST: Region/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionId,RegionName,HotelId,ServiceHour")] Region region)
        {
            if (ModelState.IsValid)
            {
                regionmanager.Update(region);
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(CacheHelper.GetCategoriesFromCache(), "HotelId", "HotelName", region.HotelId);
            return View(region);
        }

        // GET: Region/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = regionmanager.Find(x => x.RegionId == id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Region/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Region region = regionmanager.Find(x => x.RegionId == id);
            regionmanager.Delete(region);
            return RedirectToAction("Index");
        }

    }
}
