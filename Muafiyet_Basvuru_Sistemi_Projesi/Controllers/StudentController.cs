using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuafiyetProjesi2024.Data;
using MuafiyetProjesi2024.Models;

namespace MuafiyetProjesi2024.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _hostingEnvironment;

        public StudentController(AppDbContext context, IWebHostEnvironment env)
        {
            _hostingEnvironment = env;
            _context = context;
        }   
        
        public IActionResult BasvuruFormu()
        {
            var oturumTC = TempData.Peek("oturumAcanTc") as string;
            if (oturumTC == null)
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.OturumTC = oturumTC;
            var user = _context.Kullanicilar.FirstOrDefault(u => u.Tckimlik == oturumTC);
            if (user != null)
            {
                ViewBag.Mail = user.Mail;
            }
            else
            {
                ViewBag.Mail = "Email bulunamadı"; // Eğer kullanıcı bulunamazsa
            }

            return View();
        }


        public IActionResult BasvuruBelgeleri()
        {
            var oturumTC = TempData["oturumAcanTc"] as String;
            if (oturumTC == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Oturum TC bilgisini kullanarak gerekli işlemleri yapabilirsiniz
            ViewBag.oturumTC = oturumTC;

            return View();
        }



        public IActionResult BasvuruFormuPdf()
        {
            var oturumTC = TempData.Peek("oturumAcanTc") as string;
            if (oturumTC == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SubmitApplication(Basvuru basvuruBilgisi, Evrak evrakBilgisi, Ders dersBilgisi, IFormFile Transkript, IFormFile DersIcerik)
        {
            if (ModelState.IsValid)
            {
                if (Transkript != null && Transkript.Length > 0)
                {
                    var transkriptDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", $"{basvuruBilgisi.Tckimlik}-Transkript.pdf");
                    using (var stream = new FileStream(transkriptDosyaYolu, FileMode.Create))
                    {
                        await Transkript.CopyToAsync(stream);
                    }
                    evrakBilgisi.Transkript = transkriptDosyaYolu;
                }

                if (DersIcerik != null && DersIcerik.Length > 0)
                {
                    var dersDokumDosyaYolu = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", $"{basvuruBilgisi.Tckimlik}-DersDokum.pdf");
                    using (var stream = new FileStream(dersDokumDosyaYolu, FileMode.Create))
                    {
                        await DersIcerik.CopyToAsync(stream);
                    }
                    evrakBilgisi.DersIcerik = dersDokumDosyaYolu;
                }

                var oturumuAcanTc = TempData.Peek("oturumAcanTc") as String;
                var oturumuAcankullanici = _context.Kullanicilar.SingleOrDefault(x => x.Tckimlik == oturumuAcanTc);
                
                basvuruBilgisi.Kullanici = oturumuAcankullanici;
                _context.Basvurular.Add(basvuruBilgisi);
                
                evrakBilgisi.Kullanici = oturumuAcankullanici;
                evrakBilgisi.Tckimlik = basvuruBilgisi.Tckimlik;
                _context.Evraklar.Add(evrakBilgisi);

                dersBilgisi.Kullanici = oturumuAcankullanici;
                dersBilgisi.Tckimlik = basvuruBilgisi.Tckimlik;
                _context.Dersler.Add(dersBilgisi);
                
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Home"); // Başka bir sayfaya yönlendir
            }
            
            return RedirectToAction("Register", "Home"); 
        }
        
    }
}