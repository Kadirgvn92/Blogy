using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultThirdPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();	
	}
}
