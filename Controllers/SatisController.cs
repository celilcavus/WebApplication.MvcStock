using MvcStock.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
namespace MvcStock.Controllers
{
    [Authorize]
    public class SatisController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        #region Methods
        private void geturun()
        {
            List<SelectListItem> urun = (from x in db.TblUrunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.urunList = urun;
        }
        private void getMusteri()
        {
            List<SelectListItem> musteri = (from x in db.TblMusteri.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.Id.ToString()
                                         }).ToList();
            ViewBag.musteriList = musteri;
        }
        private void getPersonel()
        {
            List<SelectListItem> personel = (from x in db.TblPersonel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad,
                                             Value = x.Id.ToString()
                                         }).ToList();
            ViewBag.personelList = personel;
        }
        #endregion
        public ActionResult Index(int page = 1)
        {
            return View(db.TblSatis.ToList().ToPagedList(page, 5));
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            getMusteri();
            getPersonel();
            geturun();
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatis satis)
        {
            TblSatis s = new TblSatis();
            s.urunid = satis.urunid;
            s.musteriid = satis.musteriid;
            s.personelid = satis.personelid;
            s.fiyat = satis.fiyat;
            s.tarih = DateTime.Now;
            db.TblSatis.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}