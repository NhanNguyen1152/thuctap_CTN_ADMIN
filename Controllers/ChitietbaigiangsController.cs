using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thuctap_CTN_NEW.Models;

namespace thuctap_CTN_NEW.Controllers
{
    public class ChitietbaigiangsController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Chitietbaigiangs
        public async Task<IActionResult> Index()
        {
            var qltt_CTNContext = _context.Chitietbaigiangs.Include(c => c.Bg).Include(c => c.LIdNavigation);
            return View(await qltt_CTNContext.ToListAsync());
        }

        // GET: Chitietbaigiangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietbaigiang = await _context.Chitietbaigiangs
                .Include(c => c.Bg)
                .Include(c => c.LIdNavigation)
                .FirstOrDefaultAsync(m => m.CtbgId == id);
            if (chitietbaigiang == null)
            {
                return NotFound();
            }

            return View(chitietbaigiang);
        }

        // GET: Chitietbaigiangs/Create
        public IActionResult Create()
        {
            int min = 000001;
            int max = 999999;
            Chitietbaigiang obj = new Chitietbaigiang();
            Random rd = new Random();
            obj.CtbgId = rd.Next(min,max).ToString();
            ViewData["BgId"] = new SelectList(_context.Baigiangs, "BgId", "BgId");
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId");
            return View(obj);
        }

        // POST: Chitietbaigiangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtbgId,LId,BgId")] Chitietbaigiang chitietbaigiang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietbaigiang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BgId"] = new SelectList(_context.Baigiangs, "BgId", "BgId", chitietbaigiang.BgId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", chitietbaigiang.LId);
            return View(chitietbaigiang);
        }

        // GET: Chitietbaigiangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietbaigiang = await _context.Chitietbaigiangs.FindAsync(id);
            if (chitietbaigiang == null)
            {
                return NotFound();
            }
            ViewData["BgId"] = new SelectList(_context.Baigiangs, "BgId", "BgId", chitietbaigiang.BgId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", chitietbaigiang.LId);
            return View(chitietbaigiang);
        }

        // POST: Chitietbaigiangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtbgId,LId,BgId")] Chitietbaigiang chitietbaigiang)
        {
            if (id != chitietbaigiang.CtbgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietbaigiang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietbaigiangExists(chitietbaigiang.CtbgId))
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
            ViewData["BgId"] = new SelectList(_context.Baigiangs, "BgId", "BgId", chitietbaigiang.BgId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", chitietbaigiang.LId);
            return View(chitietbaigiang);
        }

        // GET: Chitietbaigiangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietbaigiang = await _context.Chitietbaigiangs
                .Include(c => c.Bg)
                .Include(c => c.LIdNavigation)
                .FirstOrDefaultAsync(m => m.CtbgId == id);
            if (chitietbaigiang == null)
            {
                return NotFound();
            }

            return View(chitietbaigiang);
        }

        // POST: Chitietbaigiangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chitietbaigiang = await _context.Chitietbaigiangs.FindAsync(id);
            _context.Chitietbaigiangs.Remove(chitietbaigiang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietbaigiangExists(string id)
        {
            return _context.Chitietbaigiangs.Any(e => e.CtbgId == id);
        }
    }
}
