using cafeSite2.Data;
using Microsoft.AspNetCore.Mvc;

namespace cafeSite2.ViewComponents
{
    public class iletisim: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public iletisim(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var iletisim = _db.iletisim.ToList();
            return View(iletisim);
        }
    }
}
