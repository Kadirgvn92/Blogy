using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultThirdPartial : ViewComponent
{
	private readonly IArticleService _articleService;

	public _UIDefaultThirdPartial(IArticleService articleService)
	{
		_articleService = articleService;
	}

	public IViewComponentResult Invoke()
	{
		var values = _articleService.TGetArticleByFirstCategory();
		return View(values);	
	}
}
