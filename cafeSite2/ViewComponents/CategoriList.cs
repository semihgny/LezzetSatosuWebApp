using cafeSite2.Data;
using Microsoft.AspNetCore.Mvc;
namespace cafeSite2.ViewComponents
{

    public class CategoriList:ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public CategoriList(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var category = _db.Categories.ToList();
            return View(category);
        }
    }
}
