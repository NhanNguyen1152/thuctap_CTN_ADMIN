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
    public class ThoikhoabieusController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Thoikhoabieus
        public async Task<IActionResult> Index()
        {
            var qltt_CTNContext = _context.Thoikhoabieus.Include(t => t.Hv).Include(t => t.LIdNavigation);
            return View(await qltt_CTNContext.ToListAsync());
        }

        // GET: Thoikhoabieus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieus
                .Include(t => t.Hv)
                .Include(t => t.LIdNavigation)
                .FirstOrDefaultAsync(m => m.TkbId == id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }

            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Create
        public IActionResult Create()
        {
            ViewData["HvId"] = new SelectList(_context.Hocviens, "HvId", "HvId");
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId");
            return View();
        }

        // POST: Thoikhoabieus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TkbId,LId,HvId,TkbMonhoc,TkbKhunggio,TkbNgaybatdau,TkbNgayketthuc,TkbThu,TkbLinkhoc")] Thoikhoabieu thoikhoabieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thoikhoabieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HvId"] = new SelectList(_context.Hocviens, "HvId", "HvId", thoikhoabieu.HvId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", thoikhoabieu.LId);
            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieus.FindAsync(id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }
            ViewData["HvId"] = new SelectList(_context.Hocviens, "HvId", "HvId", thoikhoabieu.HvId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", thoikhoabieu.LId);
            return View(thoikhoabieu);
        }

        // POST: Thoikhoabieus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TkbId,LId,HvId,TkbMonhoc,TkbKhunggio,TkbNgaybatdau,TkbNgayketthuc,TkbThu,TkbLinkhoc")] Thoikhoabieu thoikhoabieu)
        {
            if (id != thoikhoabieu.TkbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thoikhoabieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThoikhoabieuExists(thoikhoabieu.TkbId))
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
            ViewData["HvId"] = new SelectList(_context.Hocviens, "HvId", "HvId", thoikhoabieu.HvId);
            ViewData["LId"] = new SelectList(_context.Lops, "LId", "LId", thoikhoabieu.LId);
            return View(thoikhoabieu);
        }

        // GET: Thoikhoabieus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thoikhoabieu = await _context.Thoikhoabieus
                .Include(t => t.Hv)
                .Include(t => t.LIdNavigation)
                .FirstOrDefaultAsync(m => m.TkbId == id);
            if (thoikhoabieu == null)
            {
                return NotFound();
            }

            return View(thoikhoabieu);
        }

        // POST: Thoikhoabieus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thoikhoabieu = await _context.Thoikhoabieus.FindAsync(id);
            _context.Thoikhoabieus.Remove(thoikhoabieu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThoikhoabieuExists(string id)
        {
            return _context.Thoikhoabieus.Any(e => e.TkbId == id);
        }
    }
}
