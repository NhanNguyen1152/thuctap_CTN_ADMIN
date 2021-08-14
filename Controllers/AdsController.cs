using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
using thuctap_CTN_NEW.Models;

namespace thuctap_CTN.Controllers
{
    public class AdsController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();


        // GET: Ads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ads.ToListAsync());
        }

        // GET: Ads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // GET: Ads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdId,AdUsername,AdPassword,AdTen")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AdId,AdUsername,AdPassword,AdTen")] Ad ad)
        {
            if (id != ad.AdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.AdId))
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
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(string id)
        {
            return _context.Ads.Any(e => e.AdId == id);
        }

        [HttpPost]
        public ActionResult VerifyLogin(string email, string password)
        {
            var userDetails = _context.Ads.Where( x => x.AdUsername == email && x.AdPassword == password).FirstOrDefault();
            if(userDetails == null)
            {
                    return Content("<script language='javascript' type='text/javascript'>alert('Wrong!');</script>");
            }
            else
            {
                
                HttpContext.Session.SetString("userID", JsonConvert.SerializeObject(userDetails.AdUsername));
                return View("_LayoutDashboardAD");
            }
        }

        public const string SSKEY = "user";

        public ActionResult Logout() {
            var session = HttpContext.Session;
            session.Remove(SSKEY);
            return Content("<script language='javascript' type='text/javascript'>alert('You are out !');</script>");
        }
    }
}
