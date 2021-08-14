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

namespace thuctap_CTN_NEW.Controllers
{
    public class LoginController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult VerifyLogin(string email, string password)
        {
            var userDetails = _context.Ads.Where( x => x.AdUsername == email && x.AdPassword == password).FirstOrDefault();
            if(userDetails == null)
            {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("userName", userDetails.AdTen);
                HttpContext.Session.SetString("userID", userDetails.AdId);
                return RedirectToAction("Index","Home");
            }
        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("userID");
            return RedirectToAction("Index", "Login");
        }
    }
}