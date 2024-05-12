using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
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
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetAll();
        return View(writer);
	}
}
