using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.MemberLayout;

public class _MemberLayoutNavbarPartial : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;

    public _MemberLayoutNavbarPartial(UserManager<AppUser> userManager, IWriterService writerService)
    {
        _userManager = userManager;
        _writerService = writerService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        ViewBag.Writer = writer.ImageUrl;
        ViewBag.User = writer.Name;

        return View();  
    }
}
