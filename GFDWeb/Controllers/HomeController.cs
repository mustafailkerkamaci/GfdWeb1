using System.Diagnostics;
using GFDWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace GFDWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("koordinatorlukler")]
        public IActionResult Koordinatorlukler()
        {
            return View();
        }

        [Route("hakkimizda")]
        public IActionResult Hakkimizda()
        {
            return View();
        }

        [Route("paydaslar")]
        public IActionResult Paydaslar()
        {
            return View();
        }

        [Route("genc-zirveler")]
        public IActionResult GencZirveler()
        {
            return View();
        }

        [Route("galeri")]
        public IActionResult Galeri()
        {
            // 1. wwwroot/images/Gallery klasörünün tam yolunu belirliyoruz
            string galleryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "Gallery");

            // 2. Fotoğraf isimlerini tutacağımız boş bir liste oluşturuyoruz
            List<string> imageNames = new List<string>();

            // 3. Eğer klasör varsa içindeki dosyaları okuyup listeye ekliyoruz
            if (Directory.Exists(galleryPath))
            {
                string[] files = Directory.GetFiles(galleryPath);
                foreach (var file in files)
                {
                    imageNames.Add(Path.GetFileName(file)); // Sadece dosya adını alır (Örn: gorsel_1.jpg)
                }
            }

            // 4. Hazırladığımız listeyi sayfaya (View'a) gönderiyoruz
            return View(imageNames);
        }

        [Route("makaleler")]
        public IActionResult Makaleler()
        {
            return View();
        }

        // İletişim sayfasını AÇMAK için (HttpGet)
        [Route("iletisim")]
        [HttpGet]
        public IActionResult Iletisim()
        {
            return View();
        }

        // İletişim formunu GÖNDERMEK için (HttpPost)
        [Route("iletisim")]
        [HttpPost]
        public IActionResult Iletisim(string adSoyad, string email, string konu, string mesaj)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress("gfd@gfd.org.tr");
                mail.To.Add("gfd@gfd.org.tr");
                mail.Subject = $"Web Sitesi İletişim Formu: {konu}";
                mail.Body = $"Gönderen: {adSoyad}\nE-Posta: {email}\nKonu: {konu}\n\nMesaj:\n{mesaj}";

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.gfd.org.tr", 587);
                smtp.Credentials = new System.Net.NetworkCredential("gfd@gfd.org.tr", "yn442!6za");
                smtp.EnableSsl = false;

                smtp.Send(mail);
                ViewBag.BasariMesaji = "Mesajınız başarıyla iletildi. En kısa sürede dönüş yapılacaktır.";
            }
            catch (Exception ex)
            {
                ViewBag.HataMesaji = "Mesaj gönderilirken bir hata oluştu. Lütfen daha sonra tekrar deneyin. Detay: " + ex.Message;
            }

            return View();
        }

        [Route("tuzuk")]
        public IActionResult Tuzuk()
        {
            return View();
        }

        [Route("faaliyet-belgesi")]
        public IActionResult FaaliyetBelgesi()
        {
            return View();
        }

        [Route("uyelik-basvurusu")]
        public IActionResult UyelikBasvuru()
        {
            return View();
        }

        [Route("uye-ol")]
        public IActionResult UyeOl()
        {
            return View();
        }

        [Route("uye-girisi")]
        public IActionResult UyeGirisi()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}