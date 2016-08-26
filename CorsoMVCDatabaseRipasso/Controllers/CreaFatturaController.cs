using CorsoMVCDatabaseRipasso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorsoMVCDatabaseRipasso.Controllers
{
    public class CreaFatturaController : Controller
    {
        private FattureEntities db = new FattureEntities();

        // GET: CreaFattura
        public ActionResult Index()
        {
            ViewBag.VendorId = new SelectList(db.VendorSet, "Id", "Name");
            return View();
        }


        // POST: CreaFattura/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Data,VendorId,Invoice_P")]Invoice_T invoice_T)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    invoice_T.Date = DateTime.Now;
                    db.Invoice_T.Add(invoice_T);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                } else
                {
                    ModelState.AddModelError(string.Empty, "Fattura errata.");
                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        // GET: CreaFattura
        public ActionResult Edit()
        {
            return View();
        }

    }
}
