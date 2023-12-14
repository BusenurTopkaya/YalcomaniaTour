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
    public class TicketController : Controller
    {
        private TicketManager ticketmanager = new TicketManager(); 

        // GET: Ticket
        public ActionResult Index()
        {
            var tickets = ticketmanager.ListQueryable().Include(t => t.Regions).Include(t => t.Tours).Include(t => t.User);
            return View(tickets.ToList());
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = ticketmanager.Find(x=>x.TicketId==id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            ViewBag.RegionId = new SelectList(CacheHelper.GetCategoriesFromCache(), "RegionId", "RegionName");
            ViewBag.TourId = new SelectList(CacheHelper.GetCategoriesFromCache(), "TourId", "TourName");
            ViewBag.UserId = new SelectList(CacheHelper.GetCategoriesFromCache(), "UserId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketId,TourId,CustomerName,RegionId,BranchOffice,UserId,TotalSum,Paid,Rest,TicketDate")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketmanager.Insert(ticket);
                return RedirectToAction("Index");
            }

            ViewBag.RegionId = new SelectList(CacheHelper.GetCategoriesFromCache(), "RegionId", "RegionName", ticket.RegionId);
            ViewBag.TourId = new SelectList(CacheHelper.GetCategoriesFromCache(), "TourId", "TourName", ticket.TourId);
            ViewBag.UserId = new SelectList(CacheHelper.GetCategoriesFromCache(), "UserId", "Name", ticket.UserId);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = ticketmanager.Find(x=>x.TicketId==id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionId = new SelectList(CacheHelper.GetCategoriesFromCache(), "RegionId", "RegionName", ticket.RegionId);
            ViewBag.TourId = new SelectList(CacheHelper.GetCategoriesFromCache(), "TourId", "TourName", ticket.TourId);
            ViewBag.UserId = new SelectList(CacheHelper.GetCategoriesFromCache(), "UserId", "Name", ticket.UserId);
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketId,TourId,CustomerName,RegionId,BranchOffice,UserId,TotalSum,Paid,Rest,TicketDate")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticketmanager.Update(ticket);
                return RedirectToAction("Index");
            }
            ViewBag.RegionId = new SelectList(CacheHelper.GetCategoriesFromCache(), "RegionId", "RegionName", ticket.RegionId);
            ViewBag.TourId = new SelectList(CacheHelper.GetCategoriesFromCache(), "TourId", "TourName", ticket.TourId);
            ViewBag.UserId = new SelectList(CacheHelper.GetCategoriesFromCache(), "UserId", "Name", ticket.UserId);
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = ticketmanager.Find(x => x.TicketId == id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = ticketmanager.Find(x => x.TicketId == id);
            ticketmanager.Delete(ticket);
            return RedirectToAction("Index");
        }

    }
}
