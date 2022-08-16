using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using System.Diagnostics;
using RealEstate.ViewModels;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;

namespace RealEstate.Controllers
{
    public class SaleController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _env;
        UserManager<ApplicationUser> _userManager;
        public static long userID;


        public SaleController(ApplicationDbContext db, ILogger<PropertyController> logger, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _env = env;
            _logger = logger;
            _userManager = userManager;

        }



        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Property> rent = _db.Property.Where(p => p.Service == "Sale");
            return View(rent);
        }



    }






}

