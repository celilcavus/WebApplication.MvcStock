using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        public ActionResult Index()
        {
            return View(db.TblAdmin.ToList());
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin admin)
        {
            db.TblAdmin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}