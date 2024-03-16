using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers;
public class ArticleController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
