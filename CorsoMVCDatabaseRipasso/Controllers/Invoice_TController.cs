using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CorsoMVCDatabaseRipasso.Models;

namespace CorsoMVCDatabaseRipasso.Controllers
{
    public class Invoice_TController : Controller
    {
        private FattureEntities db = new FattureEntities();

        // GET: Invoice_T
        public ActionResult Index()
        {
            var invoice_T = db.Invoice_T.Include(i => i.Vendor);
            return View(invoice_T.ToList());
        }

        // GET: Invoice_T/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_T invoice_T = db.Invoice_T.Find(id);
            if (invoice_T == null)
            {
                return HttpNotFound();
            }
            return View(invoice_T);
        }

        // GET: Invoice_T/Create
        public ActionResult Create()
        {
            ViewBag.VendorId = new SelectList(db.VendorSet, "Id", "Name");
            return View();
        }

        // POST: Invoice_T/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,VendorId")] Invoice_T invoice_T)
        {
            if (ModelState.IsValid)
            {
                db.Invoice_T.Add(invoice_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorId = new SelectList(db.VendorSet, "Id", "Name", invoice_T.VendorId);
            return View(invoice_T);
        }

        // GET: Invoice_T/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_T invoice_T = db.Invoice_T.Find(id);
            if (invoice_T == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorId = new SelectList(db.VendorSet, "Id", "Name", invoice_T.VendorId);
            return View(invoice_T);
        }

        // POST: Invoice_T/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,VendorId")] Invoice_T invoice_T)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorId = new SelectList(db.VendorSet, "Id", "Name", invoice_T.VendorId);
            return View(invoice_T);
        }

        // GET: Invoice_T/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_T invoice_T = db.Invoice_T.Find(id);
            if (invoice_T == null)
            {
                return HttpNotFound();
            }
            return View(invoice_T);
        }

        // POST: Invoice_T/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice_T invoice_T = db.Invoice_T.Find(id);
            db.Invoice_T.Remove(invoice_T);
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
