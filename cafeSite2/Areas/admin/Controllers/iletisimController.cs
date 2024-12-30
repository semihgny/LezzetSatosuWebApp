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

    public class iletisimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public iletisimController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admin/iletisim
        public async Task<IActionResult> Index()
        {
            return View(await _context.iletisim.ToListAsync());
        }

        // GET: admin/iletisim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.iletisim
                .FirstOrDefaultAsync(m => m.id == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // GET: admin/iletisim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/iletisim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,eMail,telefon,adres")] iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: admin/iletisim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.iletisim.FindAsync(id);
            if (iletisim == null)
            {
                return NotFound();
            }
            return View(iletisim);
        }

        // POST: admin/iletisim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,eMail,telefon,adres")] iletisim iletisim)
        {
            if (id != iletisim.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!iletisimExists(iletisim.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: admin/iletisim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.iletisim
                .FirstOrDefaultAsync(m => m.id == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // POST: admin/iletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iletisim = await _context.iletisim.FindAsync(id);
            if (iletisim != null)
            {
                _context.iletisim.Remove(iletisim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool iletisimExists(int id)
        {
            return _context.iletisim.Any(e => e.id == id);
        }
    }
}
