using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultSecondPartial :ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
