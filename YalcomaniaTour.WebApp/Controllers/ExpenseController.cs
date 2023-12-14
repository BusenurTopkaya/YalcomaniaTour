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
    public class ExpenseController : Controller
    {
        private ExpenseManager expensemanager = new ExpenseManager();

        // GET: Expense
        public ActionResult Index()
        {
            return View(expensemanager.List());
        }

        // GET: Expense/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = expensemanager.Find(x => x.ExpenseId == id.Value);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseId,Explanation,Dept,ExpenseDate")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                expensemanager.Insert(expense);
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        // GET: Expense/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = expensemanager.Find(x => x.ExpenseId == id.Value);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseId,Explanation,Dept,ExpenseDate")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                expensemanager.Update(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        // GET: Expense/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = expensemanager.Find(x => x.ExpenseId == id.Value);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = expensemanager.Find(x => x.ExpenseId == id);
            expensemanager.Delete(expense);
            return RedirectToAction("Index");
        }

       
    }
}
