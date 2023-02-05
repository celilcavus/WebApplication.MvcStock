using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace MvcStock.Controllers
{
    public class GirisController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TblAdmin admin)
        {
            var AdminControl = db.TblAdmin.Where(x => x.kullaniciAdi == admin.kullaniciAdi && x.sifre == admin.sifre).FirstOrDefault();
            if (AdminControl != null)
            {
                FormsAuthentication.SetAuthCookie(admin.kullaniciAdi, false);
                return RedirectToAction("Index", "Musteri");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris","Giris");
        }
    }
}