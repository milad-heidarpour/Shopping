using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shopping.Core.Interface;
using Shopping.Core.ViewModels;
using System.Security.Claims;

namespace Shopping.Controllers;

public class AccountController : Controller
{
    IAccount _account;
    public AccountController(IAccount account)
    {
        _account = account;
    }
    public async Task<IActionResult> Register()
    {
        return await Task.FromResult(View());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            if (await _account.RegisterUser(register))
            {
                return RedirectToAction(nameof(Login));
            }
            ModelState.AddModelError("PhoneNumb", "احتمالا این شماره موبایل پیش از این ثبت شده است");
            return await Task.FromResult(View(register));
        }
        return await Task.FromResult(View(register));
    }

    public async Task<IActionResult> Login()
    {
        ViewBag.Message = TempData["Message"];
        return await Task.FromResult(View());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        if (ModelState.IsValid)
        {
            var user = await _account.Login(login);
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.PhoneNumb),
                    new Claim(ClaimTypes.Role,user.Role.RoleEnName),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principale = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true, //remember me
                };
                await HttpContext.SignInAsync(principale, properties);

                //redirect base on user role(admin/user)
                if (user.Role.RoleEnName == "Admin")
                {
                    return Redirect("~/admin/admin/index");
                }
                return RedirectToAction("index", "user");
            }
            TempData["Message"] = "کاربری با این مشخصات وجود ندارد";
        }
        if (login.PhoneNumb == null && login.Password == null)
        {
            TempData["Message"] = "لطفا فیلد هارا کامل پر نمایید";
        }
        else if (login.PhoneNumb == null)
        {
            TempData["Message"] = "لطفا فیلد شماره تلفن پر نمایید";
        }
        else if (login.Password == null)
        {
            TempData["Message"] = "لطفا فیلد کلمه عبور را پر نمایید";
        }

        return RedirectToAction(nameof(Login));
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("index", "home");
    }



}
