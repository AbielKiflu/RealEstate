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


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditType(long? id) 
        {
            if (id == null)
            {
                return NotFound();
            } 
             
                var proportyType= await _db.PropertyType.FirstOrDefaultAsync(pt => pt.ID == id);
            if (await TryUpdateModelAsync<PropertyType>(proportyType, "", pt => pt.Name))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            

            return View(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            var propertyType =await  _db.PropertyType.FirstOrDefaultAsync(pt => pt.ID == id);
            return View(propertyType);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var student = await _db.PropertyType.FindAsync(id);
            if (student == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _db.PropertyType.Remove(student);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }




    }
}
