using MvcStock.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    [Authorize]
    public class UrunController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        #region Methods
        private void getKategori()
        {
            List<SelectListItem> kategori = (from x in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ad,
                                                 Value = x.Id.ToString()
                                             }).ToList();
            ViewBag.kategroiList = kategori;
        }
        #endregion

        public ActionResult Index()
        {
            return View(db.TblUrunler.Where(x=>x.durum == true).ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {

            getKategori();
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TblUrunler val)
        {
            TblUrunler urun = new TblUrunler();
            urun.marka = val.marka;
            urun.ad = val.ad;
            urun.alisfiyat = val.alisfiyat;
            urun.satisfiyat = val.satisfiyat;
            urun.stock = val.stock;
            urun.kategoriId = val.kategoriId;
            db.TblUrunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
        public ActionResult Sil(int id)
        {
            var returnValue = db.TblUrunler.Where(x => x.Id == id).First();
            returnValue.Id = id;
            returnValue.durum = false;
            //db.TblUrunler.Remove(returnValue);
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            getKategori();
            var returnValue = db.TblUrunler.Where(x => x.Id == id).First();
            return View(returnValue);
        }
        [HttpPost]
        public ActionResult Guncelle(TblUrunler urun)
        {
            var returnValue = db.TblUrunler.Where(x => x.Id == urun.Id).First();
            returnValue.Id = urun.Id;
            returnValue.ad = urun.ad;
            returnValue.marka = urun.marka;
            returnValue.alisfiyat = urun.alisfiyat;
            returnValue.satisfiyat = urun.satisfiyat;
            returnValue.stock = urun.stock;
            returnValue.kategoriId = urun.kategoriId;
            db.SaveChanges();
            return RedirectToAction("Index", "Urun");
        }
    }
}