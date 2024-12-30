using cafeSite2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cafeSite2.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var user = _context.ApplicationUser.ToList();
            var role = _context.Roles.ToList();
            var userRole = _context.UserRoles.ToList();

            foreach (var item in user)
            {
                var roleId = userRole.FirstOrDefault(i => i.UserId == item.Id).RoleId;
                item.rol = role.FirstOrDefault(u => u.Id == roleId).Name;
            }
            return View(user);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.ApplicationUser.FindAsync(id);
            if (user != null)
            {
                _context.ApplicationUser.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
