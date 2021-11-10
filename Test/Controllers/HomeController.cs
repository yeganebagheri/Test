using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;
using Test.Repositories;


namespace Test.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IUserService _userService;
        private readonly TestDbContext _db;




        public HomeController(ILogger<HomeController> logger, IUserService userService, TestDbContext db)
        {
            _userService = userService;
            _logger = logger;
            _db = db;

        }



        //Get : Account
        public ActionResult Index()
        {
            return View(_db.Users.ToList());
        }

        // GET: Register

        public ActionResult Register()
        {
            return View();
        }

        

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            //if (ModelState.IsValid)
            //{
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                    return RedirectToAction("Index");
            //}

            return View(model);
        }


        //Get Login 
        public ActionResult Login()
        {
            return View();
        }

        


        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                     int id = result.ID;

                    return RedirectToAction("Prof" , new { Id = id });
                }

                return View();
;
        }


        public IActionResult Prof(int Id)
        {
            //if (HttpContext.Session.GetInt32("NationalCode") != null)
            //{
            //User user = new User()
            //{
            var user = _db.Users.Where(u => u.Id == Id).FirstOrDefault();
            //};
            //ViewBag.Message = User;
            return View(user);
            //}
            //else
            //{
                //return RedirectToAction("Login");
            //}
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
