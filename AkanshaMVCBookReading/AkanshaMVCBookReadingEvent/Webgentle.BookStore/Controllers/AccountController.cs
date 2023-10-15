using BookEvents.Models;
using BookEvents.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookEvents.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountController> _logger;

       

        public AccountController(IAccountRepository accountRepository, ILogger<AccountController> logger)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            _logger.LogInformation("The Signup page has been accessed");
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
               
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }

                ModelState.Clear();
            }

            return View(userModel);
        }
        [Route("login")]
        public IActionResult Login()
        {
            _logger.LogInformation("The Login page has been accessed");
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("Email",signInModel.Email);
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                
                if (result.Succeeded)
                {
                    //if (HttpContext.Session.GetString("Email")== "myadmin@bookevents.com")
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid credentials");
            }
           
            return View();
        }
       [ Route("logout")]
       public async Task <IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        

    }
}
