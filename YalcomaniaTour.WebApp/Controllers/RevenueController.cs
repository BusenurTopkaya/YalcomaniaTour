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
    public class RevenueController : Controller
    {
        private RevenueManager revenuemanager = new RevenueManager();

        // GET: Revenue
        public ActionResult Index()
        {
            return View(revenuemanager.List());
        }

        // GET: Revenue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = revenuemanager.Find(x => x.RevenueId == id.Value);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // GET: Revenue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revenue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RevenueId,Explanation,Gain,RevenueDate")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                revenuemanager.Insert(revenue);
                return RedirectToAction("Index");
            }

            return View(revenue);
        }

        // GET: Revenue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = revenuemanager.Find(x => x.RevenueId == id.Value);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // POST: Revenue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevenueId,Explanation,Gain,RevenueDate")] Revenue revenue)
        {
            if (ModelState.IsValid)
            {
                revenuemanager.Update(revenue);
                return RedirectToAction("Index");
            }
            return View(revenue);
        }

        // GET: Revenue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revenue revenue = revenuemanager.Find(x => x.RevenueId == id.Value);
            if (revenue == null)
            {
                return HttpNotFound();
            }
            return View(revenue);
        }

        // POST: Revenue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revenue revenue = revenuemanager.Find(x => x.RevenueId == id);
            revenuemanager.Delete(revenue);
            return RedirectToAction("Index");
        }

      
    }
}
