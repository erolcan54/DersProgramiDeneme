using DersProgramiDeneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DersProgramiDeneme.Controllers
{
    public class HomeController : Controller
    {
        DersProgramiDbEntities db;
        public HomeController()
        {
            db = new DersProgramiDbEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<GunTable> GunListe = db.GunTable.ToList();
            ViewData["GunListe"]= GunListe;
            List<SaatTable> SaatListe = db.SaatTable.ToList();
            ViewData["SaatListe"] = SaatListe;
            List<DersTable> DersListe = db.DersTable.ToList();
            ViewData["DersListe"] = DersListe;
            return View();
        }

        [HttpPost]
        public ActionResult DersProgramiKaydet(FormCollection collection)
        {
            List<DersProgrami> dpliste = new List<DersProgrami>();
            List<string> ddlname = new List<string>();

            for(int g=0;g<5;g++)  //Günleri sayacak
            {
                for (int s = 0; s < 8; s++)
                {
                    DersProgrami dp = new DersProgrami();
                    var deger=collection["" + (g+1).ToString() + "" + "" + (s+1).ToString() + ""];
                    dp.GunID = g+1;
                    dp.SaatID = s+1;
                    dp.SinifID = 1;
                    dp.DersID = Convert.ToInt32(deger);
                    dpliste.Add(dp);
                }
            }

            foreach (var item in dpliste)
            {
                db.DersProgrami.Add(item);
            }
            db.SaveChanges();

            List<DersProgrami> kdpliste = db.DersProgrami.ToList();

            return View(kdpliste);
        }

        public ActionResult DersProgrami()
        {
            List<DersProgrami> kdpliste = db.DersProgrami.ToList();
            return View(kdpliste);
        }
    }
}