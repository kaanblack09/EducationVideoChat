using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppEducation.Models;
using AppEducation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppEducation.Models.Account;
using AppEducation.Models.MangerUser;
using Microsoft.AspNetCore.Http;
namespace AppEducation.Controllers {
    public class AccountController : Controller 
    {
        private IIdentityUserRepository userRepository;
        private readonly ILogger<AccountController> logger;

        public AccountController( IIdentityUserRepository userRepository, ILogger<AccountController> logger)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public IActionResult Index() => View();
        
        #region Login method
        public IActionResult Login() => View();
        [HttpPost]
        public IActionResult Login(string UserName, string Password) {
            var result = userRepository.Login(UserName, Password);
          
            if(result)
            {
                var UserSession = userRepository.GetUserByUserName(UserName);
                HttpContext.Session.SetString("_Name", UserSession.UserName);
                HttpContext.Session.SetString("_ID" , UserSession.Id.ToString());
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Login not success!");
                return RedirectToAction("Login","Account");
            }
            
        }
        #endregion
        
        #region Register method
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(IdentityUser identityUser)
        {
            userRepository.AddIdentityUser(identityUser);
            return RedirectToAction(nameof(Login));
        }
        #endregion
                                    
    }
}