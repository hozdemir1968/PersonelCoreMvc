using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelCoreMvc.Models;

namespace PersonelCoreMvc.Controllers
{
    public class PersonelController : Controller
    {
        Context personelcontext = new Context();

        [Authorize]

        public IActionResult Index()
        {
            var degerler = personelcontext.Personels.Include(x=>x.Bolum).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult PersonelEkle()
        {
            List<SelectListItem> listem = (from x in personelcontext.Bolums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.lstm = listem;
            return View();
        }

        [HttpPost]
        public IActionResult PersonelEkle(Personel gelen)
        {
            var perbolum = personelcontext.Bolums.Where(x => x.ID == gelen.Bolum.ID).FirstOrDefault();
            gelen.Bolum = perbolum;
            personelcontext.Personels.Add(gelen);
            personelcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelGetir(int id)
        {
            List<SelectListItem> listem = (from x in personelcontext.Bolums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.lstm = listem;
            var giden = personelcontext.Personels.Find(id);
            return View("PersonelGetir", giden);
        }

        public IActionResult PersonelGuncelle(Personel gelen)
        {
            var perbolum = personelcontext.Bolums.Where(x => x.ID == gelen.Bolum.ID).FirstOrDefault();
            var prs = personelcontext.Personels.Find(gelen.ID);
            prs.Ad = gelen.Ad;
            prs.Soyad = gelen.Soyad;
            prs.Sehir = gelen.Sehir;
            prs.Bolum = perbolum;
            personelcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelSil(int id)
        {
            var prs = personelcontext.Personels.Find(id);
            personelcontext.Personels.Remove(prs);
            personelcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
