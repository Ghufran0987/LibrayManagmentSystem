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
    public class Borrower_DetailsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: Borrower_Details
        public ActionResult Index()
        {
            var borrower_Details = db.Borrower_Details.Include(b => b.Book).Include(b => b.Staff);
            return View(borrower_Details.ToList());
        }

        // GET: Borrower_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower_Details borrower_Details = db.Borrower_Details.Find(id);
            if (borrower_Details == null)
            {
                return HttpNotFound();
            }
            return View(borrower_Details);
        }

        // GET: Borrower_Details/Create
        public ActionResult Create()
        {
            ViewBag.Book_Id = new SelectList(db.Books, "Book_Id", "Book_Name");
            ViewBag.Issue_By = new SelectList(db.Staffs, "Staff_Id", "First_Name");
            return View();
        }

        // POST: Borrower_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Borrower_Id,Book_Id,Borrower_From,Borrower_To,Issue_By")] Borrower_Details borrower_Details)
        {
            if (ModelState.IsValid)
            {
                db.Borrower_Details.Add(borrower_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_Id = new SelectList(db.Books, "Book_Id", "Book_Name", borrower_Details.Book_Id);
            ViewBag.Issue_By = new SelectList(db.Staffs, "Staff_Id", "First_Name", borrower_Details.Issue_By);
            return View(borrower_Details);
        }

        // GET: Borrower_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower_Details borrower_Details = db.Borrower_Details.Find(id);
            if (borrower_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_Id = new SelectList(db.Books, "Book_Id", "Book_Name", borrower_Details.Book_Id);
            ViewBag.Issue_By = new SelectList(db.Staffs, "Staff_Id", "First_Name", borrower_Details.Issue_By);
            return View(borrower_Details);
        }

        // POST: Borrower_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Borrower_Id,Book_Id,Borrower_From,Borrower_To,Issue_By")] Borrower_Details borrower_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrower_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_Id = new SelectList(db.Books, "Book_Id", "Book_Name", borrower_Details.Book_Id);
            ViewBag.Issue_By = new SelectList(db.Staffs, "Staff_Id", "First_Name", borrower_Details.Issue_By);
            return View(borrower_Details);
        }

        // GET: Borrower_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Borrower_Details borrower_Details = db.Borrower_Details.Find(id);
            if (borrower_Details == null)
            {
                return HttpNotFound();
            }
            return View(borrower_Details);
        }

        // POST: Borrower_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Borrower_Details borrower_Details = db.Borrower_Details.Find(id);
            db.Borrower_Details.Remove(borrower_Details);
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
