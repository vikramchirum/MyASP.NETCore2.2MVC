using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using frontier.myAccount.web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace frontier.myAccount.web.Controllers.Account
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel loginRequestViewModal, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (loginRequestViewModal.UserName == "ab" && loginRequestViewModal.Password == "ab")
                {
                    var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,  loginRequestViewModal.UserName),
                    new Claim(ClaimTypes.Email, "test@test.com"),
                    new Claim(ClaimTypes.DateOfBirth, DateTime.Now.ToShortDateString()),
                    new Claim("FullName","abc def")
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = true;
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);



                    //if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    //{
                    //    return View("~/Views/Home/Privacy.cshtml");
                    //}
                    //return View("~/Views/Home/Privacy.cshtml");


                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ViewData["ErrorMesage"] = "Invalid Credentials!! Either username or password is wrong.";
                    ModelState.AddModelError(string.Empty, "Invalid Credentials!! Either username or password is wrong.");
                }
            }

            return View("Login");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}