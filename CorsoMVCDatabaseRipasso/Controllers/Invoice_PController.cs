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
    public class Invoice_PController : Controller
    {
        private FattureEntities db = new FattureEntities();

        // GET: Invoice_P
        public ActionResult Index()
        {
            var invoice_P = db.Invoice_P.Include(i => i.FK_Invoice_T);
            return View(invoice_P.ToList());
        }

        // GET: Invoice_P/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_P invoice_P = db.Invoice_P.Find(id);
            if (invoice_P == null)
            {
                return HttpNotFound();
            }
            return View(invoice_P);
        }

        // GET: Invoice_P/Create
        public ActionResult Create()
        {
            ViewBag.Invoice_TId = new SelectList(db.Invoice_T, "Id", "Id");
            return View();
        }

        // POST: Invoice_P/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Quantity,Price,UMA,Invoice_TId")] Invoice_P invoice_P)
        {
            if (ModelState.IsValid)
            {
                db.Invoice_P.Add(invoice_P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Invoice_TId = new SelectList(db.Invoice_T, "Id", "Id", invoice_P.Invoice_TId);
            return View(invoice_P);
        }

        // GET: Invoice_P/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_P invoice_P = db.Invoice_P.Find(id);
            if (invoice_P == null)
            {
                return HttpNotFound();
            }
            ViewBag.Invoice_TId = new SelectList(db.Invoice_T, "Id", "Id", invoice_P.Invoice_TId);
            return View(invoice_P);
        }

        // POST: Invoice_P/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Quantity,Price,UMA,Invoice_TId")] Invoice_P invoice_P)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice_P).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Invoice_TId = new SelectList(db.Invoice_T, "Id", "Id", invoice_P.Invoice_TId);
            return View(invoice_P);
        }

        // GET: Invoice_P/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice_P invoice_P = db.Invoice_P.Find(id);
            if (invoice_P == null)
            {
                return HttpNotFound();
            }
            return View(invoice_P);
        }

        // POST: Invoice_P/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice_P invoice_P = db.Invoice_P.Find(id);
            db.Invoice_P.Remove(invoice_P);
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
