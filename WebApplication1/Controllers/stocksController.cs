using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class stocksController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: stocks
        public ActionResult Index()
        {
            var stocks = db.stocks.Include(s => s.Book);
            return View(stocks.ToList());
        }

        // GET: stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: stocks/Create
        public ActionResult Create()
        {
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Id", "Book_Name");
            return View();
        }

        // POST: stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stock_Id,Book_Name,Qty,Available")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_Name = new SelectList(db.Books, "Book_Id", "Book_Name", stock.Book_Name);
            return View(stock);
        }

        // GET: stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Id", "Book_Name", stock.Book_Name);
            return View(stock);
        }

        // POST: stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stock_Id,Book_Name,Qty,Available")] stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_Name = new SelectList(db.Books, "Book_Id", "Book_Name", stock.Book_Name);
            return View(stock);
        }

        // GET: stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stock stock = db.stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stock stock = db.stocks.Find(id);
            db.stocks.Remove(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
