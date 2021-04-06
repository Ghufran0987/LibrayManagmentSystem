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
    public class Member_DetailsController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: Member_Details
        public ActionResult Index()
        {
            var member_Details = db.Member_Details.Include(m => m.Role);
            return View(member_Details.ToList());
        }

        // GET: Member_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Details member_Details = db.Member_Details.Find(id);
            if (member_Details == null)
            {
                return HttpNotFound();
            }
            return View(member_Details);
        }

        // GET: Member_Details/Create
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name");
            return View();
        }

        // POST: Member_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Member_Id,First_Name,Last_Name,Phone_No,Email,User_No,Pass,Role_Id")] Member_Details member_Details)
        {
            if (ModelState.IsValid)
            {
                db.Member_Details.Add(member_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", member_Details.Role_Id);
            return View(member_Details);
        }

        // GET: Member_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Details member_Details = db.Member_Details.Find(id);
            if (member_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", member_Details.Role_Id);
            return View(member_Details);
        }

        // POST: Member_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Member_Id,First_Name,Last_Name,Phone_No,Email,User_No,Pass,Role_Id")] Member_Details member_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Role_Id = new SelectList(db.Roles, "Role_Id", "Role_Name", member_Details.Role_Id);
            return View(member_Details);
        }

        // GET: Member_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Details member_Details = db.Member_Details.Find(id);
            if (member_Details == null)
            {
                return HttpNotFound();
            }
            return View(member_Details);
        }

        // POST: Member_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member_Details member_Details = db.Member_Details.Find(id);
            db.Member_Details.Remove(member_Details);
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
