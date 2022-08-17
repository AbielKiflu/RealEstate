﻿using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;




namespace RealEstate.Controllers
{
     
    public class FavoriteController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _env;
        UserManager<ApplicationUser> _userManager;
        public static long userID;


        public FavoriteController(ApplicationDbContext db, ILogger<PropertyController> logger, IHostingEnvironment env, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _env = env;
            _logger = logger;
            _userManager = userManager;

        }



        [HttpGet]
        public IActionResult Index()
        {
            userID = long.Parse(_userManager.GetUserId(User));
            IEnumerable<Property> favorite = _db.Property.Where(p => p.ApplicationUserID == userID);
            return View(favorite);
        }

        [HttpGet]
     
        public IActionResult Create(long id)
        {
            userID = long.Parse(_userManager.GetUserId(User));
            Favorite favorite = new Favorite{
                ApplicationUserID = userID,
                PropertyID = id
            };
            _db.Favorite.Add(favorite);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





    }






}
