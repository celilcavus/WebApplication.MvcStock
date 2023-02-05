using MvcStock.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace MvcStock.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        public ActionResult Index(int page = 1)
        {
            var musteriList = db.TblMusteri.Where(x=>x.durum == true).ToList().ToPagedList(page,10);
            return View(musteriList);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri m)
        {
            TblMusteri musteri = new TblMusteri();
            musteri.ad = m.ad;
            musteri.soyad = m.soyad;
            musteri.sehir = m.sehir;
            musteri.bakiye = m.bakiye;
            db.TblMusteri.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
        public ActionResult Sil(int id)
        {
            var returnValue = db.TblMusteri.Where(x => x.Id == id).First();
            returnValue.Id = id;
            returnValue.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var value = db.TblMusteri.Where(x => x.Id == id).First();
            return View(value);
        }
        [HttpPost]
        public ActionResult Guncelle(TblMusteri m)
        {
            var musteri = db.TblMusteri.Where(x => x.Id == m.Id).First();
            musteri.Id = m.Id;
            musteri.ad = m.ad;
            musteri.soyad = m.soyad;
            musteri.sehir = m.sehir;
            musteri.bakiye = m.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index", "Musteri");
        }
    }
}