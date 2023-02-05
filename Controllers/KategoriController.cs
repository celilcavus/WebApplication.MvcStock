using System.Linq;
using System.Web.Mvc;
using MvcStock.Models.Entity;
namespace MvcStock.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        DbMvcStockEntities db = new DbMvcStockEntities();
        TblKategori kategori1 = new TblKategori();
        public ActionResult Index()
        {
            return View(db.TblKategori.ToList());
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TblKategori kategori)
        {
           
            kategori1.ad = kategori.ad;
            db.TblKategori.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {

            var returnid = db.TblKategori.Where(x => x.Id == id).FirstOrDefault();
            db.TblKategori.Remove(returnid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var returnList = db.TblKategori.Where(x => x.Id == id).First();
            return View(returnList);
        }
        [HttpPost]
        public ActionResult Guncelle(TblKategori kategori)
        {
            var returnid = db.TblKategori.Where(x => x.Id == kategori.Id).FirstOrDefault();
            returnid.Id = kategori.Id;
            returnid.ad = kategori.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}