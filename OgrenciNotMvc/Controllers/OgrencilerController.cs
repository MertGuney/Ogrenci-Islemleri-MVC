using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenci = db.TBL_Ogrenciler.ToList();
            return View(ogrenci);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBL_Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }

                                          ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBL_Ogrenciler p)
        {
            var klp = db.TBL_Kulupler.Where(m => m.KULUPID == p.TBL_Kulupler.KULUPID).FirstOrDefault();
            p.TBL_Kulupler = klp;
            db.TBL_Ogrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBL_Ogrenciler.Find(id);
            db.TBL_Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OGRGetir(int id)
        {
            var ogrgetir = db.TBL_Ogrenciler.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_Kulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }

                                          ).ToList();
            ViewBag.dgr = degerler;
            return View("OGRGetir", ogrgetir);
        }
        public ActionResult Guncelle(TBL_Ogrenciler p)
        {
            var ogr = db.TBL_Ogrenciler.Find(p.OGRENCIID);
            ogr.OGRAD = p.OGRAD;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRFOTOGRAF = p.OGRFOTOGRAF;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }
    }
}