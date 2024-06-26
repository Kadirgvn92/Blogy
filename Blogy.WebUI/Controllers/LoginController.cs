﻿using Blogy.EntityLayer;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult SignUp()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(CreateUserViewModel model)
    {
        AppUser user = new AppUser
        {
            Name = model.Name,
            Surname = model.Surname,
            UserName = model.Username,
            Email = model.Mail,
            ImageUrl = "ASDFASDF"
        };

        if (ModelState.IsValid)
        {
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Kaydınız sistem tarafından onaylandıktan sonra giriş yapabilirsiniz.";

                return RedirectToAction("SignUp");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

        }

        return View();
    }
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInViewModel p)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByNameAsync(p.Username);
            if (user.IsAccepted)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
                if (result.Succeeded)
                {
                    if(user.Id == 12) 
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Dashboard", new { area = "Member" });
                }
                else
                {
                    TempData["ErrorMessage"] = "Geçersiz Kullanıcı adı veya Şifre. Lütfen tekrar deneyiniz.";
                    return View();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Hesabınız Onaylanmamıştır. Mailinizi kontrol ediniz";
                return View();
            }
        }
        else
        {
            TempData["ErrorMessage"] = "Lütfen giriş bilgilerinizi doğru şekilde doldurunuz.";
            return View();
        }
    }
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}
