using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppEducation.Models;
using AppEducation.Models.Account;
using AppEducation.Models.MangerUser;
using Microsoft.AspNetCore.Http;
namespace AppEducation.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IIdentityUserRepository userRepository;
        public ClientController(IIdentityUserRepository userRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View("Index",userRepository.GetUserByKey(long.Parse(HttpContext.Session.GetString("_ID"))));
        }

        public IActionResult Profile()
        {
            return View("Profile",userRepository.GetUserByKey(long.Parse(HttpContext.Session.GetString("_ID"))));
        }
        [HttpPost]
        public IActionResult EditProfile()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
