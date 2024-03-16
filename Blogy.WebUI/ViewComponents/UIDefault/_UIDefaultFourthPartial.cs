using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFourthPartial : ViewComponent
{
	public IViewComponentResult Invoke()
	{
		return View();	
	}
}
