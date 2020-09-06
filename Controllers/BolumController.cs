using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonelCoreMvc.Models;

namespace PersonelCoreMvc.Controllers
{
    public class BolumController : Controller
    {
        Context bolumcontext = new Context();

        [Authorize]

        public IActionResult Index()
        {
            var degerler = bolumcontext.Bolums.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult BolumEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BolumEkle(Bolum gelen)
        {
            bolumcontext.Bolums.Add(gelen);
            bolumcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BolumGetir(int id)
        {
            var giden = bolumcontext.Bolums.Find(id);
            return View("BolumGetir", giden);
        }

        public IActionResult BolumGuncelle(Bolum gelen)
        {
            var blm = bolumcontext.Bolums.Find(gelen.ID);
            blm.Ad = gelen.Ad;
            bolumcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BolumSil(int id)
        {
            var blm = bolumcontext.Bolums.Find(id);
            bolumcontext.Bolums.Remove(blm);
            bolumcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BolumDetay(int id)
        {
            var degerler = bolumcontext.Personels.Where(x => x.BolumID == id).ToList();
            var  bolumtitle = bolumcontext.Bolums.Find(id);
            ViewBag.blmttl = bolumtitle.Ad;
            return View(degerler);
        }
    }
}
