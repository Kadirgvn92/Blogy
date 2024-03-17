using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultSixthPartial :ViewComponent
{
	
	public IViewComponentResult Invoke()
	{
		return View();	
	}
}
