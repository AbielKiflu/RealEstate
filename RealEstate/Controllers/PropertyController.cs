using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System.Diagnostics;
using RealEstate.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace RealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _env;


        public PropertyController(ApplicationDbContext db, ILogger<PropertyController> logger, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
            _logger = logger;
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
                            ApplicationUserID = 1

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



            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
