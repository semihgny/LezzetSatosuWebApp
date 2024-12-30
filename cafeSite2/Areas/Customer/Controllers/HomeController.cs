using System.Diagnostics;
using cafeSite2.Data;
using cafeSite2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace cafeSite2.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IToastNotification _toast;
        private readonly IWebHostEnvironment _he;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IToastNotification toast, IWebHostEnvironment he)
        {
           
            _logger = logger;
            _db = db;
            _toast = toast;
            _he = he;
        }

        public IActionResult Index()
        {

            
            var menu = _db.Menus.Where(i=>i.Ozel).ToList();
            return View(menu);
        }
        public IActionResult Menu()
        {
            var menu = _db.Menus.ToList();
            return View(menu);
        }

        public IActionResult Rezervasyon()
        {
            return View();
        }

        // POST: admin/rezervasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon([Bind("id,name,eMail,telefonNo,sayi,saat,Tarih")] rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                
                _db.Add(rezervasyon);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Teþekkürler, rezervasyonunuz alýnmýþtýr.");
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Galeri()
        {
            var galeri = _db.Galleri.ToList();
            return View(galeri);
        }

        public IActionResult Hakkimizda()
        {
            var about = _db.About.ToList(); 
            return View(about);
        }

        public IActionResult Blog()
        {
            return View();
        }

        // POST: admin/blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blog(blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_he.WebRootPath, @"Site\menu");
                    var ext = Path.GetExtension(files[0].FileName);

                    if (blog.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, blog.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);

                    }
                    blog.Image = @"\Site\menu\" + fileName + ext;

                }
                _db.Add(blog);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Teþekkürler, yorumunuz iletildi, yorumunuz onaylandýðýnda yayýnlanacaktýr.");
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        public IActionResult CategoryDetails(int? id)
        {
            var menu = _db.Menus.Where(i=>i.CategoryID == id).ToList();
            ViewBag.KategoriId = id;
            return View(menu);
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        // POST: admin/Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Iletisim([Bind("id,name,eMail,mesaj,telefon,Tarih")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Tarih = DateTime.Now;
                _db.Add(contact);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Teþekkürler, mesajýnýz baþarýyla iletildi...");
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
