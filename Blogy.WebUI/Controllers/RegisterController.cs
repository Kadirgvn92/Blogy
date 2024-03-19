using Blogy.EntityLayer;
using Blogy.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
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
                TempData["SuccessMessage"] = "Kayıt başarılı şekilde gerçekleşmiştir.";

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
            var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz Kullanıcı adı veya Şifre. Lütfen tekrar deneyiniz.";
                return View();
            }
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}
