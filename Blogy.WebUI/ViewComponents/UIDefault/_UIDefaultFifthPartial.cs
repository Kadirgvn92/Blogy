using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFifthPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
