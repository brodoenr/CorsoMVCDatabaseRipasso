using CorsoMVCDatabaseRipasso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorsoMVCDatabaseRipasso.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult JsonVendor()
        {
            FattureEntities db = new FattureEntities();
            var result = db.VendorSet.ToList();
            var listResult = result.ToList();

            return Json(listResult, JsonRequestBehavior.AllowGet);
        }

    }
}