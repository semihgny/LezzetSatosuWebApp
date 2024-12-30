using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cafeSite2.Data;
using cafeSite2.Models;
using Microsoft.AspNetCore.Authorization;

namespace cafeSite2.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]

    public class menusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _he;

        public menusController(ApplicationDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: admin/menus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Menus.Include(m => m.category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: admin/menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus
                .Include(m => m.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menus == null)
            {
                return NotFound();
            }

            return View(menus);
        }

        // GET: admin/menus/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "id", "name");
            return View();
        }

        // POST: admin/menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( menus menus)
        {
            if (ModelState.IsValid)
            {

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_he.WebRootPath, @"Site\menu");
                    var ext = Path.GetExtension(files[0].FileName);

                    if (menus.Image != null) { 
                        var imagePath = Path.Combine(_he.WebRootPath, menus.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);

                    }
                    menus.Image = @"\Site\menu\" + fileName + ext;

                }
                _context.Add(menus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(menus);
        }

        // GET: admin/menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "id", "name", menus.CategoryID);
            return View(menus);
        }

        // POST: admin/menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(menus menus)
        {
            

            if (ModelState.IsValid)
            {


                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_he.WebRootPath, @"Site\menu");
                    var ext = Path.GetExtension(files[0].FileName);

                    if (menus.Image != null)
                    {
                        var imagePath = Path.Combine(_he.WebRootPath, menus.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);

                    }
                    menus.Image = @"\Site\menu\" + fileName + ext;

                }
                
                    _context.Update(menus);
                    await _context.SaveChangesAsync();
                
                
                return RedirectToAction(nameof(Index));
            }

            return View(menus);
        }

        // GET: admin/menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus
                .Include(m => m.category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (menus == null)
            {
                return NotFound();
            }

            return View(menus);
        }

        // POST: admin/menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menus = await _context.Menus.FindAsync(id);
            var imagePath = Path.Combine(_he.WebRootPath, menus.Image.TrimStart('\\'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            if (menus != null)
            {
                _context.Menus.Remove(menus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool menusExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
