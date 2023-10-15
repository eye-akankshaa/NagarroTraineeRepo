using BookReadingEvent.Data.Repository;
using BookReadingEvent.Domain.Entities;
using BookReadingEvent.WebMVC.Models;
using BusinessLogicLayer_BLL_.DataTransferObjects;
using BusinessLogicLayer_BLL_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;         
        }

        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = new RegisterDTO()
                {
                    FullName = userModel.FullName,
                    EmailAddress = userModel.EmailAddress,
                    Password=userModel.Password
                };
                var result = await _accountService.CreateUserAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                //If User successfully Ragister in the portal so redirect into the Login Page
                return RedirectToAction("Login", "Account");

            }
            return View();


        }

        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        
        [Route("Login")]
        [HttpPost]        
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = new LoginDTO()
                {
                    EmailAddress = loginModel.EmailAddress,
                    Password = loginModel.Password,
                    RememberMe = loginModel.RememberMe,
                };
                var result = await _accountService.LoginUserAsync(user);

                //if User successfully login in the portal so redirect into the Home Page Otherwise Invaild Credentials
                if (result.Succeeded)
                {
                   
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invaild Credentials");
            }
            return View();
        }

        /// <summary>
        /// Used for Logout 
        /// </summary>
        /// <returns></returns>
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

    }

}

