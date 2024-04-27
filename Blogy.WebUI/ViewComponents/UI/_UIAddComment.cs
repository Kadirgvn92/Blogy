using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UI;

public class _UIAddComment :ViewComponent
{
    public IViewComponentResult Invoke(int id)
    {
        ViewBag.Id = id;
        return View();
    }
}
