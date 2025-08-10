using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleShoppingCart.Data;
using SimpleShoppingCart.Helpers;
using SimpleShoppingCart.Helpers.InterfacesHelpers;
using SimpleShoppingCart.Models;
using SimpleShoppingCart.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SimpleShoppingCart.Controllers
{
    public class AuthController(ILogger<AuthController> _logger, IValidate _validate, IDBWorker _dBWorker) : Controller
    {        
        public async Task<IActionResult> SignUp()
        {
            return View("LoginPageViews/Login");
        }

        public async Task<IActionResult> SignInView()
        {
            return View("SignInPageViews/SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel signIn)
        {
            if (await _dBWorker.CheckUserContainsInDB(signIn.Login, signIn.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, signIn.Login),
                    new Claim(ClaimTypes.Name, signIn.Login),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                });

                return RedirectToAction("Me");
            }

            ModelState.AddModelError(string.Empty, "Not registered");    
            return View("SignInPageViews/SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLogin(RegistrationUserModel loginModel)
        {            
            if (loginModel is null)
                return BadRequest("No data provided.");

            if (!await _validate.IsContainsItem(loginModel))
            {
                _logger.LogWarning("Not valid request");
                return View("LoginPageViews/Login");
            }

            ViewBag.Password = loginModel.Password;
            ViewBag.ConfirmPassword = loginModel.ConfirmPassword;
            if (!ModelState.IsValid)
            {
                ViewBag.Password = string.Empty;
                ViewBag.ConfirmPassword = string.Empty;
                return View("LoginPageViews/Login");
            }            

            if(!await _dBWorker.CheckUserContainsInDB(loginModel.Login, loginModel.Password))
            {
                _dBWorker.SaveDataInDB(loginModel);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginModel.Login),
                    new Claim(ClaimTypes.Name, loginModel.Login),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                });

                return RedirectToAction("Me");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Not registered");
                return View("LoginPageViews/Login");
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Me()
        {
            return RedirectToAction("Main", "ShopCart");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Main", "ShopCart");
        }
    }
}
