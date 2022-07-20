using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
           // IEnumerable<Property> list = _db.
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Property model)
        {


            model.PropertyTypeID = 1;
            model.ApplicationUserID = 1;

            if (ModelState.IsValid)
            {
               

             
                _db.Property.Add(model);
                _db.SaveChanges();


            }

            return View(model);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
