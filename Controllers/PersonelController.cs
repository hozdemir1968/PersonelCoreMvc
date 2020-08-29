using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelCoreMvc.Models;

namespace PersonelCoreMvc.Controllers
{
    public class PersonelController : Controller
    {
        Context personelcontext = new Context();

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
            var per = personelcontext.Bolums.Where(x => x.ID == gelen.Bolum.ID).FirstOrDefault();
            gelen.Bolum = per;
            personelcontext.Personels.Add(gelen);
            personelcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
