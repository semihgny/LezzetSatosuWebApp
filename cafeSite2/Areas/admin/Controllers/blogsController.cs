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

    public class blogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _he;


        public blogsController(ApplicationDbContext context, IWebHostEnvironment he)
        {
            _context = context;
            _he = he;
        }

        // GET: admin/blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blog.ToListAsync());
        }

        // GET: admin/blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: admin/blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(blog blog)
        {
            if (ModelState.IsValid)
            {

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
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: admin/blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: admin/blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Name,eMail,Image,Onay,Mesaj,Tarih")] blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!blogExists(blog.Id))
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
            return View(blog);
        }

        // GET: admin/blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: admin/blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog != null)
            {
                _context.Blog.Remove(blog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool blogExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
