using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        MvcOkulEntities db = new MvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler = db.TBL_Kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBL_Kulupler p)
        {
            db.TBL_Kulupler.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBL_Kulupler.Find(id);
            db.TBL_Kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KulupGetir(int id)
        {
            var klpgetir = db.TBL_Kulupler.Find(id);
            return View("KulupGetir", klpgetir);
        }
        public ActionResult Guncelle(TBL_Kulupler p)
        {
            var klp = db.TBL_Kulupler.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            klp.KULUPKONTENJAN = p.KULUPKONTENJAN;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}