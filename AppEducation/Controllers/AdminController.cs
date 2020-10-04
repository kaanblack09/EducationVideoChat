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

namespace AppEducation.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IIdentityUserRepository userRepository;
        public AdminController(IIdentityUserRepository userRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View("Index",userRepository.IdentityUsers);
        }
        public IActionResult UpdateIdentityUser(long key) {
            return View(userRepository.GetUserByKey(key));
        }
        [HttpPost]
        public IActionResult UpdateIdentityUser(IdentityUser identityUser) {
            userRepository.UpdateIdentityUser(identityUser);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteUser(IdentityUser identityUser){
            userRepository.Delete(identityUser);
            return RedirectToAction(nameof(Index));
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
