using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
[AllowAnonymous]
public class AboutController : Controller
{
	private readonly IWriterService _writerService;
	private readonly UserManager<AppUser> _userManager;

    public AboutController(UserManager<AppUser> userManager, IWriterService writerService)
    {
        _userManager = userManager;
        _writerService = writerService;
    }

    public async Task<IActionResult> Index()
	{
        var writer = _writerService.TGetAll();
        return View(writer);
	}
}
