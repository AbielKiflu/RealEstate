using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealEstate.Controllers
{
    public class PropertyTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PropertyTypeController(ApplicationDbContext db)
        {
            _db = db;
        }


        [Authorize]
        public IActionResult Index()
        {
            IEnumerable<PropertyType> result = _db.PropertyType;
            return View(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(PropertyType model)
        {
            try
            {
                //ModelState.Remove("Properties");
                if (ModelState.IsValid)
                {
                    PropertyType mdl = new PropertyType { Name = model.Name };
                    _db.PropertyType.Add(mdl);
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
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(long id) 
        {
            
            return View(await _db.PropertyType.FindAsync(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(PropertyType model) 
        {
            if (ModelState.IsValid)
            {
                _db.PropertyType.Update(model);
               await _db.SaveChangesAsync();
            }
            return View();
        }

    }
}
