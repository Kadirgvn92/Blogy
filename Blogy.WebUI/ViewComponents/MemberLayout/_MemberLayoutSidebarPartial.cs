using Blogy.BusinessLayer.Abstract;
using Blogy.EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.MemberLayout;

public class _MemberLayoutSidebarPartial : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IWriterService _writerService;

    public _MemberLayoutSidebarPartial(UserManager<AppUser> userManager, IWriterService writerService)
    {
        _userManager = userManager;
        _writerService = writerService;
    }

    public IViewComponentResult Invoke()
    {
        var user = _userManager.FindByNameAsync(User.Identity.Name);
        var writer = _writerService.TGetWriter(user.Id);
        ViewBag.Writer = writer.Name;
        return View();
    }
}
