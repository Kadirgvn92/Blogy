using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.MemberLayout;

public class _MemberLayoutSidebarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
