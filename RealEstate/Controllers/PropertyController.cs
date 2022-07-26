using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly ApplicationDbContext _db;
        public PropertyController(ApplicationDbContext db, ILogger<PropertyController> logger)
        {
            _db = db;
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Create()
        {
            var propertyType=_db.PropertyType.Select(p => new { p.ID, p.Name });
            ViewBag.PropertyType = propertyType;
            return View();
        }



        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Property model)
        {
            var propertyType = _db.PropertyType.Select(p => new { p.ID, p.Name });
            ViewBag.PropertyType = propertyType;

            model.ApplicationUserID = 1;

            try
            {
                if (ModelState.IsValid)
                {
                    _db.Add(model);
                    _db.SaveChanges();

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Data");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");

            }



            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
