using Blogy.BusinessLayer.Abstract;
using Blogy.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UIDefault;

public class _UIDefaultSixthPartial :ViewComponent
{
	private readonly IArticleService _articleService;

	public _UIDefaultSixthPartial(IArticleService articleService)
	{
		_articleService = articleService;
	}

	public IViewComponentResult Invoke()
	{
		var values = _articleService.TGetArticleByFourthCategory();
		var cat = values.FirstOrDefault(x => x.CategoryID == 4);
		ViewBag.Category = cat.Categories.CategoryName;
		ViewBag.CategoryID = cat.Categories.CategoryID;
		return View(values);	
	}
}
