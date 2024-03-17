using Blogy.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultFourthPartial : ViewComponent
{
	private readonly IArticleService _articleService;

	public _UIDefaultFourthPartial(IArticleService articleService)
	{
		_articleService = articleService;
	}

	public IViewComponentResult Invoke()
	{
		var values = _articleService.TGetArticleBySecondCategory();
		var cat = values.FirstOrDefault(x => x.CategoryID == 2);
		ViewBag.Category = cat.Categories.CategoryName;

		return View(values);
	}
}
