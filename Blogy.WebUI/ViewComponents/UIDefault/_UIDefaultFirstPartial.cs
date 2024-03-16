using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFirstPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();
	}
}
