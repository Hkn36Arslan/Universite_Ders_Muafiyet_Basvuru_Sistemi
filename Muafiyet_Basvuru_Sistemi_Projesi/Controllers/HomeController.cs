using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MuafiyetProjesi2024.Data;
using MuafiyetProjesi2024.Models;

namespace MuafiyetProjesi2024.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public HomeController(IConfiguration configuration,AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {
            TempData.Clear(); // Home-Index açıldığında TempData sıfırlanacak. front-end de bu sayfaya yönlendirmek aynı zamanda çıkış yapmayı sağlar.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Index(Kullanici kullanici)
        {

             var result = _context.Kullanicilar
                .Any(x => x.Mail == kullanici.Mail && x.Parola == kullanici.Parola);
            //sorguyu yukaridan yapiyoruz. result true veya false dönüyor. Models'daki veri ile veritabani kiyaslaniyor. ??

            if (result)
            {
                var OturumAcanKullanici= _context.Kullanicilar
                    .SingleOrDefault(x => x.Mail == kullanici.Mail && x.Parola == kullanici.Parola);
                TempData["oturumAcanTc"] = OturumAcanKullanici.Tckimlik;
                var basvuruVarMi = _context.Basvurular.Any(b => b.Tckimlik == OturumAcanKullanici.Tckimlik);
                if (basvuruVarMi)
                {

                    return RedirectToAction("BasvuruBelgeleri", "Student");

                }
                else
                {

                    return RedirectToAction("BasvuruFormu", "Student");
                }

            }

            ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya parola.");
            
            return View();
        }

        public ActionResult LogoutAndRedirect()
        {
            // TempData'yı temizle
            TempData.Clear();

            // İstediğiniz sayfaya yönlendirin (örneğin, BasvuruFormu sayfası)
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Kullanici kullanici)
        {
            ModelState.Clear();
            // Veritabanında kullanıcı var mı kontrol ediyoruz
            var existingUser = await _context.Kullanicilar.FirstOrDefaultAsync(x => x.Mail == kullanici.Mail || x.Tckimlik == kullanici.Tckimlik ) ;

            if (existingUser != null)
            {
                // Eğer kullanıcı varsa, hata mesajı ekleyip aynı görünümü tekrar gösteriyoruz
                ModelState.AddModelError(string.Empty, "Bu e-posta adresi veya Tc kimlik no zaten kullanılmaktadır.");
                return View();
            }

            // Eğer kullanıcı yoksa, yeni kullanıcıyı ekliyoruz
            _context.Kullanicilar.Add(kullanici);
            await _context.SaveChangesAsync();

            // Başarılı kayıt durumunda yönlendirme
            return RedirectToAction("Index");
        }
        
         public IActionResult Error()
         
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> SavePDF()
        {
            var formData = await Request.ReadFormAsync();
            var pdfBase64 = formData["pdf"];
            var ogrTC = TempData.Peek("oturumAcanTc") as string;

            if (string.IsNullOrEmpty(pdfBase64))
            {
                return BadRequest("PDF verisi alınamadı");
            }

            // PDF'yi base64 formatından byte dizisine çevir
            byte[] pdfBytes = Convert.FromBase64String(pdfBase64);

            // Dosya adını ve yolunu belirle
            string fileName = $"{ogrTC}-Basvuru.pdf";
            string filePath = Path.Combine("wwwroot/uploads", fileName);

            // PDF'yi sunucuda kaydet
            await System.IO.File.WriteAllBytesAsync(filePath, pdfBytes);

            // Check if ogrTC exists in Kullanicilar
            var kullanici = await _context.Kullanicilar.FirstOrDefaultAsync(k => k.Tckimlik == ogrTC);
            if (kullanici == null)
            {
                return BadRequest("Geçersiz ogrTC. Kullanıcı bulunamadı.");
            }

            // Dosya yolunu veritabanına kaydet
            var evrak = await _context.Evraklar.FirstOrDefaultAsync(e => e.Tckimlik == ogrTC);
            if (evrak != null)
            {
                evrak.BasvuruBelgesi = filePath;
            }
            else
            {
                evrak = new Evrak
                {
                    Tckimlik = ogrTC,
                    BasvuruBelgesi = filePath
                };
                _context.Evraklar.Add(evrak);
            }

            await _context.SaveChangesAsync();

            return Json(new { filePath = filePath });
        }

    }
    
}
