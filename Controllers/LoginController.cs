using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PersonelCoreMvc.Models;

namespace PersonelCoreMvc.Controllers
{
    public class LoginController : Controller
    {
        Context logincontext = new Context();

        [HttpGet]
        public IActionResult GirisYap()
        {

            return View();
        }
        public async Task<IActionResult> GirisYap(Admin gelen)
        {
            var bilgiler = logincontext.Admins.FirstOrDefault(x => x.User == gelen.User && x.Password == gelen.Password);
            if (bilgiler != null)
            {
                //giriş yapıldıysa
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,gelen.User)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal cprincipal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(cprincipal);
                return RedirectToAction("Index", "Personel");
            }
            return View();
        }


    }
}
