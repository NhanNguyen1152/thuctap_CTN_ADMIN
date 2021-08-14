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
    public class TaikhoansController : Controller
    {
       private readonly qltt_CTNContext _context = new qltt_CTNContext();


        

        // GET: Taikhoans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taikhoans.ToListAsync());
        }

        // GET: Taikhoans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .FirstOrDefaultAsync(m => m.TkId == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // GET: Taikhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taikhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TkId,TkUrn,TkPw")] Taikhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taikhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taikhoan);
        }

        // GET: Taikhoans/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans.FindAsync(id);
            if (taikhoan == null)
            {
                return NotFound();
            }
            return View(taikhoan);
        }

        // POST: Taikhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TkId,TkUrn,TkPw")] Taikhoan taikhoan)
        {
            if (id != taikhoan.TkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taikhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaikhoanExists(taikhoan.TkId))
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
            return View(taikhoan);
        }

        // GET: Taikhoans/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taikhoan = await _context.Taikhoans
                .FirstOrDefaultAsync(m => m.TkId == id);
            if (taikhoan == null)
            {
                return NotFound();
            }

            return View(taikhoan);
        }

        // POST: Taikhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var taikhoan = await _context.Taikhoans.FindAsync(id);
            _context.Taikhoans.Remove(taikhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaikhoanExists(string id)
        {
            return _context.Taikhoans.Any(e => e.TkId == id);
        }
        
        
        [HttpPost]
        public ActionResult VerifyLogin(string email, string password)
        {
            var userDetails = _context.Taikhoans.Where( x => x.TkUrn == email && x.TkPw == password).FirstOrDefault();
            if(userDetails == null)
            {
                    return Content("<script language='javascript' type='text/javascript'>alert('Wrong!');</script>");
            }
            else
            {
                HttpContext.Session.SetString("userID", JsonConvert.SerializeObject(userDetails.TkUrn));
                return RedirectToAction("Index", "Ads");
            }
        }
    }
}



        // [HttpPost]
        // public ActionResult VerifyLogin(thuctap_CTN.Models.Taikhoan taikhoanModel)
        // {
        //     var userDetails = _context.Taikhoan.Where( x => x.TkUrn == taikhoanModel.TkUrn && x.TkPw == taikhoanModel.TkPw).FirstOrDefault();
        //     if(userDetails == null)
        //     {
        //            return RedirectToAction("Index", "Ads");
        //     }
        //     else
        //     {
        //         HttpContext.Session.SetString("userID", userDetails.TkUrn);
        //         return RedirectToAction("Index", "Ads");
        //     }
        // }