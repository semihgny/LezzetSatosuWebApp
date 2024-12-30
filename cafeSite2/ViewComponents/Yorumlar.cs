using cafeSite2.Data;
using Microsoft.AspNetCore.Mvc;

namespace cafeSite2.ViewComponents
{
    public class Yorumlar: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public Yorumlar(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var yorumlar = _db.Blog.Where(i=>i.Onay).ToList();
            return View(yorumlar);
        }
    }
}
