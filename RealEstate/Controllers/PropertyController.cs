using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System.Diagnostics;
using RealEstate.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;
 

namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _env;
        UserManager<ApplicationUser> _userManager;
        public static long userID;



        public PropertyController(ApplicationDbContext db, ILogger<PropertyController> logger, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _env = env;
            _logger = logger;
            _userManager = userManager;
             
        }




        [HttpGet]
        public IActionResult Create()
        {
            var propertyType = _db.PropertyType.Select(p => new { p.ID, p.Name });
            ViewBag.PropertyType = propertyType;
            return View();
        }



        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PropertyViewModel model)
        {
            //string filename = $"{_env.WebRootPath}\\Images";

            var propertyType = _db.PropertyType.Select(p => new { p.ID, p.Name });
            ViewBag.PropertyType = propertyType;

            userID = long.Parse(_userManager.GetUserId(User));


            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Picture != null)
                    {
                        string uploadsFolder = Path.Combine(_env.WebRootPath, "Images");
                        string fileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                        string filePath = Path.Combine(uploadsFolder, fileName);
                        model.Picture.CopyTo(new FileStream(filePath, FileMode.Create));


                         

                        Property property = new Property
                        {
                            Description = model.Description,
                            City = model.City,
                            PostalCode = model.PostalCode,
                            Street = model.Street,
                            Picture = fileName,
                            Area = model.Area,
                            Price = model.Price,
                            Service = model.Service,
                            PropertyTypeID = model.PropertyTypeID,
                            ApplicationUserID = userID

                        };
                        
                        _db.Property.Add(property);
                        _db.SaveChanges(); 
                    }
                     
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



            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Index()
        {
            userID = long.Parse(_userManager.GetUserId(User));
            IEnumerable<Property> property = _db.Property.Where(p=>p.ApplicationUserID == userID);
            return View(property);
        }


 

        public  async Task<IActionResult> Details(long id)
        {
            return View( await _db.Property.FindAsync(id));
        }


        public async Task<IActionResult> Delete(long id)
        {
            return View(await _db.Property.FindAsync(id));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var property = await _db.Property.FindAsync(id);
            if (property == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _db.Property.Remove(property);
                await _db.SaveChangesAsync();

                //delete the uploaded image
                string uploadsFolder = Path.Combine(_env.WebRootPath, "Images");
                string filePath = Path.Combine(uploadsFolder, property.Picture);
                System.IO.File.Delete(filePath);
                

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


        public async Task<IActionResult> Edit(long id)
        {
            var propertyType = _db.PropertyType.Select(p => new { p.ID, p.Name });
            ViewBag.PropertyType = propertyType;
            var proporty = await _db.Property.FirstOrDefaultAsync(p => p.Id == id);
            return View(proporty);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditProperty(Property model)
        {

            if (model.Picture == null)
            {
                 
            }
            if (!ModelState.IsValid)
            {

            }

            try
            {
               // _db.Update()
            }
            catch(DbUpdateException ex)
            {
                // handle ex
            }
            return View();
        }


    }
}
