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

    public class rezervasyonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public rezervasyonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: admin/rezervasyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.rezervasyon.ToListAsync());
        }

        // GET: admin/rezervasyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.rezervasyon
                .FirstOrDefaultAsync(m => m.id == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // GET: admin/rezervasyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/rezervasyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,eMail,telefonNo,sayi,saat,Tarih")] rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        // GET: admin/rezervasyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.rezervasyon.FindAsync(id);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            return View(rezervasyon);
        }

        // POST: admin/rezervasyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,eMail,telefonNo,sayi,saat,Tarih")] rezervasyon rezervasyon)
        {
            if (id != rezervasyon.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!rezervasyonExists(rezervasyon.id))
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
            return View(rezervasyon);
        }

        // GET: admin/rezervasyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.rezervasyon
                .FirstOrDefaultAsync(m => m.id == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // POST: admin/rezervasyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.rezervasyon.FindAsync(id);
            if (rezervasyon != null)
            {
                _context.rezervasyon.Remove(rezervasyon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool rezervasyonExists(int id)
        {
            return _context.rezervasyon.Any(e => e.id == id);
        }
    }
}
