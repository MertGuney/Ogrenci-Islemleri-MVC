using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var notlar = db.TBL_Notlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult NotGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotGiris(TBL_Notlar p)
        {
            db.TBL_Notlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var notgetir = db.TBL_Notlar.Find(id);
            return View("NotGetir", notgetir);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model,TBL_Notlar p, int sınav1 = 0, int sınav2 = 0, int sınav3 = 0, int proje = 0)
        {
            if (model.islem == "Hesapla")
            {
                int ortalama = (sınav1 + sınav2 + sınav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem == "Guncelle")
            {
                var not = db.TBL_Notlar.Find(p.NOTID);
                not.SINAV1 = p.SINAV1;
                not.SINAV2 = p.SINAV2;
                not.SINAV3 = p.SINAV3;
                not.PROJE = p.PROJE;
                not.ORTALAMA = p.ORTALAMA;
                not.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }

    }
}