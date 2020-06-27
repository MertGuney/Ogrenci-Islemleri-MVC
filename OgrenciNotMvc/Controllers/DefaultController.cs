using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var dersler = db.TBL_Dersler.ToList();
            return View(dersler);
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDers(TBL_Dersler p)
        {
            db.TBL_Dersler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var ders = db.TBL_Dersler.Find(id);
            db.TBL_Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var drsgetir = db.TBL_Dersler.Find(id);
            return View("DersGetir", drsgetir);
        }
        public ActionResult Guncelle(TBL_Dersler p)
        {
            var ders = db.TBL_Dersler.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}