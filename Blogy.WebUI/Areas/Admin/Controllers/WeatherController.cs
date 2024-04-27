using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class WeatherController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
